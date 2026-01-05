using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Models
{
    public class Block
    {

        public int Id { get; set; }

        public string BlockName { get; set; }

        public ICollection<Floor> Floors { get; set; } = new List<Floor>();

    }
}
