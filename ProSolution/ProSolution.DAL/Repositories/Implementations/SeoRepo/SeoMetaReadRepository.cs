using ProSolution.DAL.Contexts;
using ProSolution.DAL.Repositories.Abstractions.ISeoRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProSolution.DAL.Repositories.Implementations.SeoRepo
{
    public class SeoMetaReadRepository : ReadRepository<Core.Entities.SeoMeta>, ISeoMetaReadRepository
    {
        public SeoMetaReadRepository(AppDbContext context) : base(context)
        {
        }
    }
  
}
