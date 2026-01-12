using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DTOs.Laundry
{
    public record LaundryReservationDto
    {
        public int Id { get; init; }
        public string UserName { get; init; } 
        public DateTime SlotDate { get; init; }
        public string TimeInterval { get; init; } 
        public string Status { get; init; }

    }
}
