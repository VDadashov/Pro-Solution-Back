using ProSolution.DAL.Contexts;
using ProSolution.DAL.Repositories.Abstractions.Review;

namespace ProSolution.DAL.Repositories.Implementations.Review
{
    public class ReviewReadRepository : ReadRepository<Core.Entities.Review>, IReviewReadRepository
    {
        public ReviewReadRepository(AppDbContext context) : base(context)
        {
        }
    }

}
