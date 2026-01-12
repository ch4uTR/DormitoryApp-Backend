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
    public class LaundrySlotRepository : RepositoryBase<LaundrySlot>, ILaundrySlotRepository
    {
        public LaundrySlotRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public async Task<LaundrySlot?> GetByIdAsync(int id, bool trackChanges)
        {
            var query = FindByCondition(s => s.Id.Equals(id), trackChanges);
            return await query.SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<LaundrySlot>> GetSlotsByDateAsync(DateTime date, bool trackChanges)
        {
            return await FindByCondition(s => s.Date.Date == date.Date, trackChanges)
                .OrderBy(s => s.StartTime)
                .ToListAsync();
        }
    }
}
