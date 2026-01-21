using Entity.DTOs.Notification;
using Entity.Events.Laundry;
using Entity.Models;
using MediatR;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace Services.Handlers
{
    public class LaundryNotificationHandler : INotificationHandler<LaundryReservedEvent>, INotificationHandler<LaundryReservationStatusChangedEvent>
    {
        private readonly IServiceManager _serviceManager;

        public LaundryNotificationHandler(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        public async Task Handle(LaundryReservedEvent notification, CancellationToken cancellationToken)
        {
            var culture = new CultureInfo("tr-TR");
            var dayName = notification.ReservationDate.ToString("dddd", culture);

            var title = "Randevun başarıyla oluşturuldu! 🧺";
            var body = $"{notification.ReservationDate:dd/MM} {dayName} tarihindeki {notification.TimeInterval} randevun başarıyla oluşturuldu! 🥳🎉";

            var notificationContent = new NotificationContentDto() { Title = title, Body = body };

            await _serviceManager.NotificationService.SendNotificationToUserAsync(notification.UserId, notificationContent);

            Console.WriteLine("LaundryNotificationHandler az önce serviceManager ile sendNotificationTuUserAsync methodunu çağırdı");
            Console.WriteLine($"*Bildirim--------------------\n{title}\n{body}");

        }

        public async Task Handle(LaundryReservationStatusChangedEvent notification, CancellationToken cancellationToken)
        {

            var title = "";
            var body = "";
            var culture = new CultureInfo("tr-TR");
            var dayName = notification.ReservationDate.ToString("dddd", culture);

            switch (notification.Status)
            {
                case ReservationStatus.Confirmed:
                    title = "Randevunu Onayladın! ✅";
                    body = $"{notification.ReservationDate:dd/MM} {dayName} tarihindeki {notification.TimeInterval} randevun başarıyla onaylandı! Çamaşırların yıkanınca haber vereceğiz 🙃✨";
                    break;

                case ReservationStatus.Completed:
                    title = "Yıkama Tamamlandı! 🧺";
                    body = "Çamaşırların başarıyla yıkandı. ✨";
                    break;

                case ReservationStatus.Cancelled:
                    title = "Randevu İptal Edildi! ❌";
                    body = $"{notification.ReservationDate:dd/MM} {dayName} tarihindeki randevun maalesef iptal edildi.";
                    break;

                default:
                    return;
            }

            if (!string.IsNullOrEmpty(title))
            {
                var notificationContent = new NotificationContentDto() { Title = title, Body = body };

                await _serviceManager.NotificationService.SendNotificationToUserAsync(notification.UserId, notificationContent);

                Console.WriteLine($"[Laundry] Durum Değişti: {notification.Status} - Bildirim Gönderildi.");

            }   


        }
    }
}
