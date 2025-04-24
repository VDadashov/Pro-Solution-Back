using ProSolution.DAL.Contexts;
using ProSolution.DAL.Repositories.Abstractions;

namespace ProSolution.DAL.Repositories.Implementations.ProductImage
{
    public class ProductImageReadRepository : ReadRepository<Core.Entities.ProductImage>, IProductImageReadRepository
    {
        public ProductImageReadRepository(AppDbContext context) : base(context)
        {
        }
    }

}
