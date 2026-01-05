using Entity.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.EFCore
{
    public class RepositoryContext : IdentityDbContext<User>
    {

        public RepositoryContext(DbContextOptions options) : base(options) { }



        public DbSet<Block> Blocks { get; set; }
        public DbSet<Floor> Floors { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<RoomAssignment> RoomAssignments { get; set; }
        public DbSet<Issue> Issues { get; set; }
        public DbSet<IssueVote> IssueVotes { get; set; }



        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }


    }
}
