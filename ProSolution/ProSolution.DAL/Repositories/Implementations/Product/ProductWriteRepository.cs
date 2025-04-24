using ProSolution.DAL.Contexts;
using ProSolution.DAL.Repositories.Abstractions.Product;

namespace ProSolution.DAL.Repositories.Implementations.Product
{
    public class ProductWriteRepository : WriteRepository<ProSolution.Core.Entities.Product>, IProductWriteRepository
    {
        public ProductWriteRepository(AppDbContext context) : base(context)
        {
        }

    }  
}