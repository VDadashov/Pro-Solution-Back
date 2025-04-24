using ProSolution.DAL.Contexts;
using ProSolution.DAL.Repositories.Abstractions;

namespace ProSolution.DAL.Repositories.Implementations
{
    public class CatagoryReadRepository : ReadRepository<ProSolution.Core.Entities.Catagory>, ICatagoryReadRepository
    {
        public CatagoryReadRepository(AppDbContext context) : base(context)
        {
        }
    }
}
