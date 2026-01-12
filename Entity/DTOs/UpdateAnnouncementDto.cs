using Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DTOs
{
    public record UpdateAnnouncementDto
    {
        public string? Title { get; init; }
        public string? Content { get; init; }
        public int? BlockId { get; set; }
        public int? FloorId { get; set; }

        public AnnouncementPriority? Priority { get; set; }
        public bool isActive { get; set; } = true;

    }
}
