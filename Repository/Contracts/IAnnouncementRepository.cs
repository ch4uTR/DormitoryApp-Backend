using Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Contracts
{
    public interface IAnnouncementRepository : IRepositoryBase<Announcement>
    {
        Task<IEnumerable<Announcement>> GetAllAnnouncementAsync(bool newAnnouncementFirst,bool trackChanges);

        Task<IEnumerable<Announcement>> GetAnnouncementsForStudentAsync(int? blockId, int? floorId, bool trackChanges);

        Task<Announcement?> GetAnnouncementByIdAsync(int id, bool trackChanges);
    }
}
