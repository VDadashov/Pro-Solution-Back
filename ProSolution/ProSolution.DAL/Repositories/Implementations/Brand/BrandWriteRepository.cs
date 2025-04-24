using ProSolution.Core.Entities;
using ProSolution.DAL.Contexts;
using ProSolution.DAL.Repositories.Abstractions;

namespace ProSolution.DAL.Repositories.Implementations
{
    public class BrandWriteRepository : WriteRepository<Brand>, IBrandWriteRepository
    {
        public BrandWriteRepository(AppDbContext context) : base(context)
        {
        }
    }
}
