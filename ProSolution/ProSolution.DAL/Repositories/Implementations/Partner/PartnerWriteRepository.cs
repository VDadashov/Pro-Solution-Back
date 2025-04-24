using ProSolution.Core.Entities;
using ProSolution.DAL.Contexts;
using ProSolution.DAL.Repositories.Abstractions;

namespace ProSolution.DAL.Repositories.Implementations
{
    public class PartnerWriteRepository : WriteRepository<Partner>, IPartnerWriteRepository
    {
        public PartnerWriteRepository(AppDbContext context) : base(context)
        {
        }
    }
}
