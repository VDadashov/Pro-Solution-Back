using ProSolution.DAL.Contexts;
using ProSolution.DAL.Repositories.Abstractions.IAbourRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProSolution.DAL.Repositories.Implementations.AboutRepo
{
    public class AboutReadRepository : ReadRepository<Core.Entities.About>, IAboutReadRepository
    {
        public AboutReadRepository(AppDbContext context) : base(context)
        {
        }
    }

}
