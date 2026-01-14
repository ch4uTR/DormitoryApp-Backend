using Entity.DTOs.Notification;
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
    public class NotificationTokenRepository : RepositoryBase<NotificationToken>, INotificationTokenRepository
    {
        public NotificationTokenRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public async Task<IEnumerable<NotificationToken>> GetAllByUserId(string userId, bool trackChanges)
        {
            var result = await FindByCondition(t => t.UserId.Equals(userId), trackChanges).ToListAsync();
            return result;
        }
    }
}
