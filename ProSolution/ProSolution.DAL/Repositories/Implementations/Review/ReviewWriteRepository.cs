using ProSolution.Core.Entities;
using ProSolution.DAL.Contexts;
using ProSolution.DAL.Repositories.Abstractions.Review;

namespace ProSolution.DAL.Repositories.Implementations
{
    public class ReviewWriteRepository : WriteRepository<Core.Entities.Review>, IReviewWriteRepository
    {
        public ReviewWriteRepository(AppDbContext context) : base(context)
        {
        }
    }
}
