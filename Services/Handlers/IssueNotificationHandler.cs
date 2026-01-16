using Entity.DTOs.Notification;
using Entity.Events;
using Entity.Models;
using MediatR;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Handlers
{
    public class IssueNotificationHandler : INotificationHandler<IssueStatusChangedEvent>
    {
        private readonly IServiceManager _serviceManager;

        public IssueNotificationHandler(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        private static readonly Dictionary<IssueType, string> _typeTranslation = new()
        {
            { IssueType.Refrigerator, "Buzdolabı ❄️" },
            { IssueType.Electricity, "Elektrik ⚡" },
            { IssueType.Internet, "İnternet 🌐" },
            { IssueType.Radiator, "Kalorifer 🌡️" },
            { IssueType.Plumbing, "Su Tesisatı 💧" },
            { IssueType.Furniture, "Mobilya 🪑" }
        };





        public async Task Handle(IssueStatusChangedEvent notification, CancellationToken cancellationToken)
        {
            var typeName = _typeTranslation.GetValueOrDefault(notification.Type, notification.Type.ToString());

            string title = "";
            string body = "";

            switch (notification.Status)
            {
                case IssueStatus.InProgress:
                    title = "Yoldayız! 🏃‍";
                    body = $"{typeName} arızanla ilgilenmeye başladık. En kısa sürede çözeceğiz, beklemede kal! ✨";
                    break;

                case IssueStatus.Resolved:
                    title = "Müjde, Hallettik! ✅";
                    body = $"Harika haber! {typeName} sorunun jilet gibi çözüldü. Artık keyfine bakabilirsin. 😊";
                    break;

                default: return;
            }


            await _serviceManager.NotificationService.SendNotificationToUserAsync(
                notification.UserId,
                new NotificationContentDto { Title = title, Body = body }
                );

            Console.WriteLine("IssueNotificationHandler az önce serviceManager ile sendNotificationTuUserAsync methodunu çağırdı");
            Console.WriteLine($"*Bildirim--------------------\n{title}\n{body}");
        }
    }
}
