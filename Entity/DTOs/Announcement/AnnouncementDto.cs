using Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DTOs.Announcement
{
    public record AnnouncementDto
    {   
        public int Id { get; set; }
        public required string Title { get; init; }
        public string Content { get; init; }

        public AnnouncementPriority Priority { get; init; }
        public DateTime CreatedAt { get; init; }
    }

    
}
