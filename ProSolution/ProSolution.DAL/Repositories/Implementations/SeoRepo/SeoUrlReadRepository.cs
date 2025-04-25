using ProSolution.Core.Entities;
using ProSolution.DAL.Contexts;
using ProSolution.DAL.Repositories.Abstractions.ISeoRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProSolution.DAL.Repositories.Implementations.SeoRepo
{
    public class SeoUrlReadRepository : ReadRepository<SeoUrl>, ISeoUrlReadRepository
    {
        public SeoUrlReadRepository(AppDbContext context) : base(context)
        {
        }
    }
}
