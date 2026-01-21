using Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DTOs.Laundry
{
    public record UpdateReservationStatusDto
    {
        public ReservationStatus Status { get; init; }
    }
}
