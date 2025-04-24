using ProSolution.Core.Entities;
using ProSolution.DAL.Contexts;
using ProSolution.DAL.Repositories.Abstractions;

namespace ProSolution.DAL.Repositories.Implementations
{
    public class CatagoryWriteRepository : WriteRepository<Catagory>, ICatagoryWriteRepository
    {
        public CatagoryWriteRepository(AppDbContext context) : base(context)
        {
        }
    }
}
