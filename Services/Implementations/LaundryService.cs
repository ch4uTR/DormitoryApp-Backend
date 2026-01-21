using AutoMapper;
using Entity.DTOs.Laundry;
using Entity.Events.Laundry;
using Entity.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Repository.Contracts;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Implementations
{
    public class LaundryService : ILaundryService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        

        public LaundryService(IRepositoryManager repositoriesManager, IMapper mapper, IMediator mediator)
        {
            _repositoryManager = repositoriesManager;
            _mapper = mapper;
            _mediator = mediator;
        }


        /* -----------------------  S L O T  ----------------------- */

        public async Task GenerateDailySlotsAsync(DateTime date)
        {
            var existingSlots = await _repositoryManager.LaundrySlot.GetSlotsByDateAsync(date, false);
            if (existingSlots.Any())  return; 


            var startTime = new TimeSpan(8, 0, 0);
            var endTime = new TimeSpan(22, 0, 0);
            var duration = TimeSpan.FromHours(2);

            for (var current = startTime; current < endTime; current = current.Add(duration))
            {
                var slot = new LaundrySlot
                {
                    Date = date,
                    StartTime = current,
                    EndTime = current.Add(duration),
                    TotalCapacity = 5, // Standart kapasite
                    Status = SlotStatus.Open
                };
                _repositoryManager.LaundrySlot.Create(slot);
            }
            await _repositoryManager.SaveAsync();
            
        }

        public async Task<IEnumerable<LaundrySlotDto>> GetSlotsByDateAsync(DateTime date, bool trackChanges)
        {   
            //o güne dair slot yoksa oluştur
            await GenerateDailySlotsAsync(date);

            var slots = await _repositoryManager.LaundrySlot.GetSlotsByDateAsync(date, trackChanges);

            return _mapper.Map<IEnumerable<LaundrySlotDto>>(slots);
        }

        public async Task<LaundrySlotDto> CloseSlotById(int slotId)
        {
            var slot = await _repositoryManager.LaundrySlot.GetByIdAsync(slotId, true);
            if (slot == null) { throw new Exception($"Idsi : {slotId} olan slot bulunamadı!"); }

            slot.Status = SlotStatus.Close;

            var reservations = await _repositoryManager.LaundryReservation.GetReservationsBySlotIdAsync(slotId, true);
            if (!reservations.Any()) {
                await _repositoryManager.SaveAsync();
                return _mapper.Map<LaundrySlotDto>(slot); 
            }

            foreach (var reservation in reservations)
            {
                reservation.Status = ReservationStatus.Cancelled;

                await _mediator.Publish(
                    new LaundryReservationStatusChangedEvent(
                    reservation.UserId,
                    reservation.Slot.TimeInterval,
                    reservation.Status,
                    reservation.Slot.Date
                    ));

            }

            await _repositoryManager.SaveAsync();
            return _mapper.Map<LaundrySlotDto>(slot);




           



        }


        public async Task<IEnumerable<LaundrySlotDto>> GetSlotsWithin24HoursAsync(bool trackChanges)
        {
            var now = DateTime.UtcNow;

            var slots = await _repositoryManager.LaundrySlot.GetSlotsWithin24HoursAsync(now, trackChanges);

            return _mapper.Map<IEnumerable<LaundrySlotDto>>(slots);
        }

        /* -----------------------  R E S E R V A T I O N S  ----------------------- */
        public async Task<LaundryReservationDto> CreateReservationAsync(string userId, CreateReservationDto createReservationDto)
        {

            try
            {
                var slot = await _repositoryManager.LaundrySlot.GetByIdAsync(createReservationDto.SlotId, true);

                if (slot == null) { throw new Exception($"Idsi: {createReservationDto.SlotId} olan slot bulunamadı!"); }

                if (slot.Status != SlotStatus.Open) { throw new Exception($"Idsi: {createReservationDto.SlotId} olan slot kapalı!"); }

                if (slot.ReservedCount >= slot.TotalCapacity) throw new Exception($"Idsi: {createReservationDto.SlotId} olan slot dolu!");

                if (slot.Reservations.Any(r => r.UserId.Equals(userId) && r.Status != ReservationStatus.Cancelled)) { 
                    throw new Exception("Bu saat dilimi için zaten rezervasyon yapılmış");}

                var reservation = _mapper.Map<LaundryReservation>(createReservationDto);
                reservation.UserId = userId;

                _repositoryManager.LaundryReservation.Create(reservation);

                slot.ReservedCount++;
                if (slot.ReservedCount == slot.TotalCapacity) slot.Status = SlotStatus.Full;

                await _repositoryManager.SaveAsync();

                await _mediator.Publish(new LaundryReservedEvent(userId, slot.TimeInterval, slot.Date));

                return _mapper.Map<LaundryReservationDto>(reservation);
            }

            catch (DbUpdateConcurrencyException)
            {
                throw new Exception("Üzgünüz, bu slot siz seçiminizi onaylarken doldu. Lütfen başka bir slot seçin.");
            }
            

        }
        
        //public async Task<LaundryReservationDto> ConfirmReservation(int reservationId)
        //{
        //    var reservation = await _repositoryManager.LaundryReservation.GetReservationById(reservationId, true);
        //    if (reservation == null) { throw new Exception($"Rezervasyon idsi: {reservationId} olan rezervasyon bulunamadı!"); }

        //    reservation.Status = ReservationStatus.Confirmed;
        //    await _repositoryManager.SaveAsync();

        //    var studentId = reservation.UserId;
        //    await _mediator.Publish(new LaundryReservationStatusChangedEvent(studentId, reservation.Slot.TimeInterval, reservation.Status, reservation.Slot.Date));

        //    return  _mapper.Map<LaundryReservationDto>(reservation);
        //}
    
        //public async Task<LaundryReservationDto> CancelReservation(int reservationId)
        //{
        //    var reservartion = await _repositoryManager.LaundryReservation.GetReservationById(reservationId, true);
        //    if (reservartion == null) { throw new Exception($"Idsi : {reservartion} olan rezervasyon bulunamadı!"); }

        //    reservartion.Status = ReservationStatus.Cancelled;

        //    var slot = await _repositoryManager.LaundrySlot.GetByIdAsync(reservartion.SlotId, true);
        //    if (slot != null && slot.ReservedCount > 0)
        //    {
        //        slot.ReservedCount--;
        //        if (slot.Status == SlotStatus.Full) slot.Status = SlotStatus.Open;
        //    }

        //    await _repositoryManager.SaveAsync();

        //    await _mediator.Publish(
        //        new LaundryReservationStatusChangedEvent(
        //            reservartion.UserId,
        //            reservartion.Slot.TimeInterval,
        //            reservartion.Status,
        //            reservartion.Slot.Date
        //            )
        //        );

        //    return _mapper.Map<LaundryReservationDto>(reservartion);

        //}

        public async Task<IEnumerable<LaundryReservationDto>> GetUserReservations(string userId)
        {
            var reservations = await _repositoryManager.LaundryReservation.GetReservationsByUserId(userId, false);
            return _mapper.Map<IEnumerable<LaundryReservationDto>>(reservations);
        }

        public async Task<IEnumerable<LaundryReservationDto>> GetReservationsForStaff(DateTime? date, bool trackChanges)
        {
            var queryDate = date?.Date ?? DateTime.UtcNow.Date;

            var reservations = await _repositoryManager.LaundryReservation.GetReservationsByDate(queryDate, trackChanges);

            return _mapper.Map<IEnumerable<LaundryReservationDto>>(reservations);

        }

        public async Task<LaundryReservationDto> UpdateReservationStatus(int reservationId, UpdateReservationStatusDto dto)
        {
            var reservation = await _repositoryManager.LaundryReservation.GetReservationById(reservationId, true);
            if (reservation == null) { throw new Exception($"Rezervasyon idsi: {reservationId} olan rezervasyon bulunamadı!"); }


            if (dto.Status == ReservationStatus.Cancelled && reservation.Status != ReservationStatus.Cancelled)
            {
                var slot = await _repositoryManager.LaundrySlot.GetByIdAsync(reservationId, true);
                if (slot != null && slot.ReservedCount > 0)
                {
                    slot.ReservedCount--;
                    if (slot.Status == SlotStatus.Full) slot.Status = SlotStatus.Open;
                }
            }

            reservation.Status = dto.Status;
            await _repositoryManager.SaveAsync();

            var studentId = reservation.UserId;
            await _mediator.Publish(new LaundryReservationStatusChangedEvent(studentId, reservation.Slot.TimeInterval, reservation.Status, reservation.Slot.Date));

            return _mapper.Map<LaundryReservationDto>(reservation);


        }
    }
}
