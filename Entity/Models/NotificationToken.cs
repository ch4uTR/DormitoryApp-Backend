using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Models
{
    public class NotificationToken
    {

        public int Id { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }

        public string FcmToken { get; set; }   
        public string? DeviceInfo { get; set; }
        public DateTime? CreatedAt { get; set; } = DateTime.UtcNow;    



    }
}
