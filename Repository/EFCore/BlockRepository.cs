using Entity.Models;
using Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.EFCore
{
    public class BlockRepository : RepositoryBase<Block>, IBlockRepository
    {
        public BlockRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }
    }
}
