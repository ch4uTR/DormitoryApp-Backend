using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DTOs.Laundry
{
    public record LaundrySlotDto
    {
        public int Id { get; init; }
        public DateTime Date { get; init; }
        public string StartTime { get; init; } 
        public string EndTime { get; init; }
        public int AvailableCapacity { get; init; } 
        public string Status { get; init; } 
    }

}
