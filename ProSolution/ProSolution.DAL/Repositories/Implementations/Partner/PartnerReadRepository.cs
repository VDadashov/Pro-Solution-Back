using ProSolution.Core.Entities;
using ProSolution.DAL.Contexts;
using ProSolution.DAL.Repositories.Abstractions;

namespace ProSolution.DAL.Repositories.Implementations
{
    public class PartnerReadRepository : ReadRepository<Partner>, IPartnerReadRepository
    {
        public PartnerReadRepository(AppDbContext context) : base(context)
        {
        }
    }
}
