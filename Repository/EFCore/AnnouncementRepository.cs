using Entity.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository.EFCore
{
    public class AnnouncementRepository : RepositoryBase<Announcement>, IAnnouncementRepository
    {
        public AnnouncementRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public async Task<IEnumerable<Announcement>> GetAllAnnouncementAsync(bool newAnnouncementFirst, bool trackChanges)
        {
            var query = FindByCondition(a => a.IsActive, trackChanges);
            query = newAnnouncementFirst ? query.OrderByDescending(a => a.CreatedAt) : query;

            return await query.ToListAsync();
        }

        public async Task<Announcement?> GetAnnouncementByIdAsync(int id, bool trackChanges)
        {
            var query = FindByCondition(a => a.IsActive && a.Id.Equals(id), trackChanges);
            return await query.FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Announcement>> GetAnnouncementsForStudentAsync(int? blockId, int? floorId, bool trackChanges)
        {
            var query = FindByCondition(a => a.IsActive, trackChanges);

            query = query.Where(a =>
                (a.BlockId == null && a.FloorId == null) ||
                (a.BlockId.Equals(blockId) && a.FloorId == null) ||
                (a.BlockId.Equals(blockId) && a.FloorId.Equals(floorId))
            );

            return await query.OrderByDescending(a => a.CreatedAt).ToListAsync();


        }
    }

        
}
