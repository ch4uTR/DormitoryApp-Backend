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
        Task<LaundryReservationDto> CreateReservationAsync(string userId, CreateReservationDto createReservationDto);
    }
}
