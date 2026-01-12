using Entity.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.EFCore
{
    public class RoomRepository : RepositoryBase<Room>, IRoomRepository
    {
        public RoomRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {


        }

        public async Task<bool> IsRoomFull(int roomId)
        {
            var room = await _repositoryContext.Rooms
                .Include(r => r.Assignments)
                .Where(r => r.Id.Equals(roomId))
                .SingleOrDefaultAsync();

            if (room == null) { throw new Exception($"Id nosu {roomId} olan oda bulunamadı!"); }

            return room.Assignments.Count(ra => ra.IsActive) < room.Capacity ? false : true;

        }
    }
}
