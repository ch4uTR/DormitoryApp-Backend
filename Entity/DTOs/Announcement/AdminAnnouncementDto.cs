using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DTOs.Announcement
{
    public record AdminAnnouncementDto : AnnouncementDto
    {
        public int? BlockId { get; set; }
        public int? FloorId { get; set; }
        public DateTime LastUpdatedAt { get; set; }
    }
}
