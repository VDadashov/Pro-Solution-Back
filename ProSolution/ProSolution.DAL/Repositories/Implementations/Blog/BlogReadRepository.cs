using ProSolution.Core.Entities;
using ProSolution.DAL.Contexts;
using ProSolution.DAL.Repositories.Abstractions;

namespace ProSolution.DAL.Repositories.Implementations
{
    public class BlogReadRepository : ReadRepository<Blog>, IBlogReadRepository
    {
        public BlogReadRepository(AppDbContext context) : base(context)
        {
        }
    }
}
