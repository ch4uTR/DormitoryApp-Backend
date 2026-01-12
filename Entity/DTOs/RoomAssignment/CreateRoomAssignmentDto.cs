using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DTOs.RoomAssignment
{
    public record CreateRoomAssignmentDto
    {
        public string StudentId { get; init; }
        public int RoomId { get; init; }
    }
}
