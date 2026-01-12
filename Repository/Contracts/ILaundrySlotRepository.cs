using Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Contracts
{
    public interface ILaundrySlotRepository : IRepositoryBase<LaundrySlot>
    {
        Task<IEnumerable<LaundrySlot>> GetSlotsByDateAsync(DateTime date, bool trackChanges);
        Task<LaundrySlot?> GetByIdAsync(int id, bool trackChanges);

    }
}
