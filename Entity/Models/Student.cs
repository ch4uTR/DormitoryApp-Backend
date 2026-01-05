using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Models
{
    public class Student : User
    {

        public string StudentNumber { get; set; }
        public string Department {  get; set; }

        [ForeignKey("Room")]
        public int? RoomId { get; set; }
        public Room Room { get; set; }

        public ICollection<RoomAssignment> RoomAssignments { get; set; } = new List<RoomAssignment>();
        


    }
}
