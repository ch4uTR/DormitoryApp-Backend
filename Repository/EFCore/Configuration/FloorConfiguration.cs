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
    public class FloorConfiguration : IEntityTypeConfiguration<Floor>
    {
        public void Configure(EntityTypeBuilder<Floor> builder)
        {
            var floors = new List<Floor>();
            int floorId = 1;

            for (int blockId = 1; blockId <=5; blockId++)
            {
                for (int floorNumber = 0; floorNumber <= 12; floorNumber++)
                {
                    floors.Add(new Floor
                    {
                        Id = floorId++,
                        BlockId = blockId,
                        FloorNumber = floorNumber
                    }
                    );
                }
            }

            builder.HasData(floors);

           
        }
    }
}
