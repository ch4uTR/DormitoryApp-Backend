using Entity.DTOs.Notification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface INotificationService
    {
        Task SendNotificationAsync(string token, NotificationContentDto notificationContentDto);

        Task SendNotificationToUserAsync(string userId, NotificationContentDto notificationContentDto);

        Task<NotificationTokenDto> SaveUserToken(string userId, NotificationTokenDto notificationTokenDto);

    }
}
