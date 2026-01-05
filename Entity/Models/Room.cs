using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Models
{
    public class Room
    {
        public int Id { get; set; }
        public int RoomNumber { get; set; }
        public int Capacity { get; set; }
        
        
        public int FloorId { get; set; }
        public Floor Floor { get; set; }    

        
        public ICollection<RoomAssignment> Assignments { get; set; }   = new List<RoomAssignment>();

        public ICollection<Issue> Issues { get; set; } = new List<Issue>();

    }
}
