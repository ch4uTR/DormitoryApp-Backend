using Entity.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Repository.EFCore.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.EFCore
{
    public abstract class RepositoryContext : IdentityDbContext<User>
    {

        protected RepositoryContext(DbContextOptions options) : base(options) { }



        public DbSet<Block> Blocks { get; set; }
        public DbSet<Floor> Floors { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<RoomAssignment> RoomAssignments { get; set; }
        public DbSet<Issue> Issues { get; set; }
        public DbSet<IssueVote> IssueVotes { get; set; }
        public DbSet<Announcement> Announcements { get; set; }
        public DbSet<LaundrySlot> LaundrySlots { get; set; }
        public DbSet<LaundryReservation> LaundryReservations { get; set; }



        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<User>()
                .HasDiscriminator<string>("UserType")
                .HasValue<Student>("Student")
                .HasValue<Admin>("Admin")
                .HasValue<LaundryMan>("LaundryMan");

            builder.ApplyConfiguration(new RoleConfiguration());
            builder.ApplyConfiguration(new AdminConfiguration());
            builder.ApplyConfiguration(new LaundryManConfiguration());
            builder.ApplyConfiguration(new UserRoleConfiguration());
            builder.ApplyConfiguration(new BlockConfiguration());
            builder.ApplyConfiguration(new FloorConfiguration());
            builder.ApplyConfiguration(new RoomConfiguration());



            builder.Entity<Issue>()
                .HasOne(i => i.User)
                .WithMany(u => u.Issues)
                .HasForeignKey(i => i.UserId)
                .OnDelete(DeleteBehavior.Restrict); // Cascade yerine Restrict dedik!

            builder.Entity<Issue>()
                .HasOne(i => i.Room)
                .WithMany(r => r.Issues)
                .HasForeignKey(i => i.RoomId)
                .OnDelete(DeleteBehavior.Restrict);

        }


    }
}
