using ProSolution.DAL.Contexts;
using ProSolution.DAL.Repositories.Abstractions.ISeoRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProSolution.DAL.Repositories.Implementations.SeoRepo
{
    public class SeoReadRepository : ReadRepository<Core.Entities.SeoData>, ISeoReadRepository
    {
        public SeoReadRepository(AppDbContext context) : base(context)
        {
        }
    }
    
}
