using Entity.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.EFCore.Configuration
{
    public class RoomConfiguration : IEntityTypeConfiguration<Room>
    {
        public void Configure(EntityTypeBuilder<Room> builder)
        {
            var rooms = new List<Room>();
            int idCounter = 1;



            for (int currentFloorId = 1; currentFloorId <= 65; currentFloorId++)
            {
                for (int roomNumber = 1; roomNumber <= 15; roomNumber++)
                {
                    rooms.Add(new Room
                    {
                        Id = idCounter++,
                        RoomNumber = roomNumber,
                        FloorId = currentFloorId,
                        Capacity = 2
                    });
                }
            }
            builder.HasData(rooms);


        }
    }
}
            

            
            

