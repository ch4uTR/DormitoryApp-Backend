using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Models
{
    public class Announcement
    {
        public int Id { get; set; } 
        public required string Title { get; set; }
        public string Content { get; set; }
        public AnnouncementPriority Priority { get; set; }
        public required string AdminId { get; set; }

        public int? BlockId { get; set; }
        public int? FloorId { get; set; }
        
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime LastUpdatedAt { get; set; }
        public bool IsActive { get; set; } = true;
    }

    public enum AnnouncementPriority { Low, Medium, High }
}
