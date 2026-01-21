using Entity.DTOs.Laundry;
using Entity.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.EFCore
{
    public class LaundryReservationRepository : RepositoryBase<LaundryReservation>, ILaundryReservationRepository
    {
        public LaundryReservationRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {


        }

        public async Task<LaundryReservation?> GetReservationById(int reservationId, bool trackChanges)
        {
            var reservation = await FindByCondition(r => r.Id.Equals(reservationId), trackChanges)
                .Include(r => r.Slot)
                .SingleOrDefaultAsync();

            return reservation;
        }

        public async Task<IEnumerable<LaundryReservation>> GetReservationsByUserId(string userId, bool trackChanges)
        {
            var reservations = await FindByCondition(r => r.UserId.Equals(userId), trackChanges)
                .Include(r => r.User)
                .Include(r => r.Slot)
                .OrderByDescending(r => r.Slot.Date)
                .ThenByDescending(r => r.Slot.StartTime)
                .ToListAsync();
            return reservations;
        }

        public async Task<IEnumerable<LaundryReservation>> GetReservationsBySlotIdAsync(int slotId, bool trackChanges)
        {
            var reservations = await FindByCondition(r => r.SlotId.Equals(slotId), trackChanges).ToListAsync();
            return reservations;
        }

        public async Task<IEnumerable<LaundryReservation>> GetReservationsByDate(DateTime date, bool trackChanges)
        {
            var reservations = await FindByCondition(r => r.Slot.Date.Equals(date), trackChanges)
                .Include(r => r.Slot)
                .Include(r => r.User)
                .OrderBy(r => r.Slot.StartTime)
                .ToListAsync();

            return reservations;
        }
    }
    
}
