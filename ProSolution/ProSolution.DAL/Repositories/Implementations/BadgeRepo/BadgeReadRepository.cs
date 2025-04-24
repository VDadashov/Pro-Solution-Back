using ProSolution.Core.Entities;
using ProSolution.DAL.Contexts;
using ProSolution.DAL.Repositories.Abstractions.IBadgeRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProSolution.DAL.Repositories.Implementations.BadgeRepo
{
    public class BadgeReadRepository : ReadRepository<Badge>, IBadgeReadRepository
    {
        public BadgeReadRepository(AppDbContext context) : base(context)
        {
        }
    }
    
    
}
