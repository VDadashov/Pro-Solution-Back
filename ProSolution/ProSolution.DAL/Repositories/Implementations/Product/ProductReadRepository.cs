using ProSolution.DAL.Contexts;
using ProSolution.DAL.Repositories.Abstractions;

namespace ProSolution.DAL.Repositories.Implementations.Product
{
    public class ProductReadRepository : ReadRepository<ProSolution.Core.Entities.Product>, IProductReadRepository
    {
        public ProductReadRepository(AppDbContext context) : base(context)
        {
        }
    }   
    
}
