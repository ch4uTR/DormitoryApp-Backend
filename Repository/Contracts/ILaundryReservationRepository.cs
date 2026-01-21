using Entity.DTOs.Laundry;
using Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Contracts
{
    public interface ILaundryReservationRepository : IRepositoryBase<LaundryReservation>
    {

        Task<LaundryReservation?> GetReservationById(int reservationId, bool trackChanges);
        Task<IEnumerable<LaundryReservation>> GetReservationsByUserId(string userId, bool trackChanges);
        Task<IEnumerable<LaundryReservation>> GetReservationsBySlotIdAsync(int slotId, bool trackChanges);

        Task<IEnumerable<LaundryReservation>> GetReservationsByDate(DateTime date, bool trackChanges);


    }
}
