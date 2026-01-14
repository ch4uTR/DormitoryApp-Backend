using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.EFCore
{
    public class PostgresRepositoryContext : RepositoryContext
    {
        public PostgresRepositoryContext(DbContextOptions<PostgresRepositoryContext> options) : base(options)
        {
        }
    }
    
}
