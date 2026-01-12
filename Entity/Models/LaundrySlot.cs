using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Models
{
    public class LaundrySlot
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public int TotalCapacity { get; set; } = 10;
        public int ReservedCount { get; set; } = 0;
        public SlotStatus Status { get; set; } = SlotStatus.Open;

        public ICollection<LaundryReservation> Reservations { get; set; } = new List<LaundryReservation>();

    }

    public enum SlotStatus { Open, Close, Full }
}
