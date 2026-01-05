using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.EFCore.Configuration
{
    public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
                
                new IdentityRole { Id = "ab1e6881-efaf-4d83-9fb2-db9ddd61990a", Name = "Admin", NormalizedName = "ADMIN"},
                new IdentityRole { Id = "2ac675ca-05b1-4fce-b9dd-7f1f98ab8ce0", Name = "LaundryMan", NormalizedName = "LAUNDRYMAN" },
                new IdentityRole { Id = "aba0f76e-42b4-40e1-838f-bb7108b81941", Name = "Student", NormalizedName = "STUDENT" }
                );
        }
    }
}
