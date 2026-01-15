using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DTOs.Notification
{
    public record NotificationContentDto
    {
        public required string Title { get; init; }
        public string? Body  { get; init; }
    }
}
