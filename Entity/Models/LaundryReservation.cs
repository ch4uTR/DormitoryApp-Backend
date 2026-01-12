using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Models
{
    public class LaundryReservation
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        public int SlotId { get; set; }
        public LaundrySlot Slot { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public ReservationStatus Status { get; set; } = ReservationStatus.Pending;
    }

    public enum ReservationStatus { Pending, Completed, Cancelled }
}
