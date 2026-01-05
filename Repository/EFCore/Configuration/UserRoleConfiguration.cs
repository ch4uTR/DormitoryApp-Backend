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
    public class UserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.HasData(
                
                new IdentityUserRole<string>
                {
                    UserId = "8e445865-a24d-4543-a6c6-9443d048cdb9",
                    RoleId = "ab1e6881-efaf-4d83-9fb2-db9ddd61990a"
                },

                new IdentityUserRole<string>
                {
                    UserId = "9dcfe6a4-9f6d-42ad-9a9a-d85423c08468",
                    RoleId = "2ac675ca-05b1-4fce-b9dd-7f1f98ab8ce0"
                }
                );
        }
    }
}
