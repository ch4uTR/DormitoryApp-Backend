using Entity.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Events.Laundry
{
    public record LaundryReservedEvent(

        string UserId,
        string TimeInterval,
        DateTime ReservationDate) : INotification
    {
    }
}
