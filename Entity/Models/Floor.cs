using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Models
{
    public  class Floor
    {

        public int Id { get; set; }

        public int FloorNumber { get; set; }

        public int BlockId { get; set; }
        public Block Block { get; set; }    

        public ICollection<Room> Rooms { get; set; }

    }

}
