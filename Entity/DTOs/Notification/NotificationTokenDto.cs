using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DTOs.Notification
{
    public record NotificationTokenDto
    {
        public required string FcmToken { get; init; }
        public string? DeviceInfo { get; init; }
       
    }
}
