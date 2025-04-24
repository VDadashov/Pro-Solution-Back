using ProSolution.Core.Entities;
using ProSolution.DAL.Contexts;
using ProSolution.DAL.Repositories.Abstractions.ProductImage;

namespace ProSolution.DAL.Repositories.Implementations
{
    public class ProductImageWriteRepository : WriteRepository<Core.Entities.ProductImage>, IProductImageWriteRepository
    {
        public ProductImageWriteRepository(AppDbContext context) : base(context)
        {
        }
    }
}
