using Entity.Models;
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
    public class AdminConfiguration : IEntityTypeConfiguration<Admin>
    {
        public void Configure(EntityTypeBuilder<Admin> builder)
        {
            var hasher = new PasswordHasher<Admin>();

            builder.HasData(

                new Admin
                {
                    Id = "8e445865-a24d-4543-a6c6-9443d048cdb9",
                    UserName = "admin@yudorm.com",
                    NormalizedUserName = "ADMIN",
                    Email = "admin@yudorm.com",
                    NormalizedEmail = "ADMIN@YUDORM.COM",
                    FirstName = "Sistem",
                    LastName = "Yöneticisi",
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "Admin123!")
                });
        }
        
    }

    public class LaundryManConfiguration : IEntityTypeConfiguration<LaundryMan>
    {
        public void Configure(EntityTypeBuilder<LaundryMan> builder)
        {
            var hasher = new PasswordHasher<LaundryMan>();

            builder.HasData(
                
                new LaundryMan
                {
                    Id = "9dcfe6a4-9f6d-42ad-9a9a-d85423c08468",
                    UserName = "laundryman@yudorm.com",
                    NormalizedUserName = "LAUNDRYMAN",
                    Email = "laundryman@yudorm.com",
                    NormalizedEmail = "LAUNDRYMAN@YUDORM.COM",
                    FirstName = "Laundry",
                    LastName = "Service",
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "Laundry123!")
                });
            
        }
    }
}
