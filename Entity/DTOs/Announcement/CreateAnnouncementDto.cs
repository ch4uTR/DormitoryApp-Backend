using Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DTOs.Announcement
{
    public record CreateAnnouncementDto
    {
        public required string Title { get; init; }
        public required string Content { get; init; }
        public AnnouncementPriority Priority { get; set; }

        public int? BlockId { get; set; }
        public int? FloorId { get; set; }

       

    }
}
