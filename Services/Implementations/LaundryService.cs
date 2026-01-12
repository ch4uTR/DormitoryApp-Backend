using AutoMapper;
using Entity.DTOs.Laundry;
using Entity.Models;
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

        public LaundryService(IRepositoryManager repositoriesManager, IMapper mapper)
        {
            _repositoryManager = repositoriesManager;
            _mapper = mapper;
        }
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


        //Slotları getirme
        public async Task<IEnumerable<LaundrySlotDto>> GetSlotsByDateAsync(DateTime date, bool trackChanges)
        {   
            //o güne dair slot yoksa oluştur
            await GenerateDailySlotsAsync(date);

            var slots = await _repositoryManager.LaundrySlot.GetSlotsByDateAsync(date, trackChanges);

            return _mapper.Map<IEnumerable<LaundrySlotDto>>(slots);
        }


        public async Task<LaundryReservationDto> CreateReservationAsync(string userId, CreateReservationDto createReservationDto)
        {
            var slot = await _repositoryManager.LaundrySlot.GetByIdAsync(createReservationDto.SlotId, true);

            if (slot == null) { throw new Exception($"Idsi: {createReservationDto.SlotId} olan slot bulunamadı!"); }

            if (slot.Status != SlotStatus.Open) { throw new Exception($"Idsi: {createReservationDto.SlotId} olan slot kapalı!"); }

            if (slot.ReservedCount >= slot.TotalCapacity) throw new Exception($"Idsi: {createReservationDto.SlotId} olan slot dolu!");

            var reservation = _mapper.Map<LaundryReservation>(createReservationDto);
            reservation.UserId = userId;

            _repositoryManager.LaundryReservation.Create(reservation);

            slot.ReservedCount++;
            if (slot.ReservedCount == slot.TotalCapacity) slot.Status = SlotStatus.Full;

            await _repositoryManager.SaveAsync();
            return _mapper.Map<LaundryReservationDto>(reservation);

        }

       
    }
}
