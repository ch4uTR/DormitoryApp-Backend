using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Models
{
    public class RoomAssignment
    {
        public int Id { get; set; }


        public string UserId { get; set; }
        public User User { get; set; } 

        public int RoomId { get; set; }
        public Room Room { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public bool IsActive { get; set; }





    }
}
