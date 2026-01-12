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
    public class BlockConfiguration : IEntityTypeConfiguration<Block>
    {
        public void Configure(EntityTypeBuilder<Block> builder)
        {
            builder.HasData(
                
                new Block { Id = 1, BlockName = "A"},
                new Block { Id = 2, BlockName = "B"},
                new Block { Id = 3, BlockName = "C"},
                new Block { Id = 4, BlockName = "D"},
                new Block { Id = 5, BlockName = "E"}
                );
        }
    }
}
