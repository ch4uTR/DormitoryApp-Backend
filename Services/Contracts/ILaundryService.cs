using Entity.DTOs.Laundry;
using Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface ILaundryService
    {
        Task GenerateDailySlotsAsync(DateTime date);
        Task<IEnumerable<LaundrySlotDto>> GetSlotsByDateAsync(DateTime date, bool trackChanges);
        Task<LaundrySlotDto> CloseSlotById(int slotId);

        Task<IEnumerable<LaundrySlotDto>> GetSlotsWithin24HoursAsync(bool trackChanges);


        /* ---------------------------------- R E S E R V A T I O N S ------------------------------*/
        Task<LaundryReservationDto> CreateReservationAsync(string userId, CreateReservationDto createReservationDto);
        //Task<LaundryReservationDto> ConfirmReservation(int reservationId);
        //Task<LaundryReservationDto> CancelReservation(int reservationId);
        Task<IEnumerable<LaundryReservationDto>> GetUserReservations(string userId);

        Task<IEnumerable<LaundryReservationDto>> GetReservationsForStaff(DateTime? date, bool trackChanges);

        Task<LaundryReservationDto> UpdateReservationStatus(int reservationId, UpdateReservationStatusDto dto);
    }
}
