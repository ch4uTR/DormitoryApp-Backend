using Entity.DTOs.Notification;
using Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Contracts
{
    public interface INotificationTokenRepository : IRepositoryBase<NotificationToken>
    {

        Task<IEnumerable<NotificationToken>> GetAllByUserId(string userId, bool trackChanges);
        
    }
}
