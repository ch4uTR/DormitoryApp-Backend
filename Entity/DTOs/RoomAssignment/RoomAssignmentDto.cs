using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DTOs.RoomAssignment
{
    public record RoomAssignmentDto
    {
        public int RoomNumber { get; init; }
        public int FloorNumber { get; init; }
        public string BlockName { get; init; }

        public string RoomName => $"{BlockName} {FloorNumber}{RoomNumber}"; // A112

    }
}
