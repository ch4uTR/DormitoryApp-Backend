using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DTOs.Laundry
{
    public record CreateReservationDto
    {
        public int SlotId { get; set; }
    }
}
