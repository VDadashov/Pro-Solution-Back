using ProSolution.Core.Entities;
using ProSolution.DAL.Contexts;
using ProSolution.DAL.Repositories.Abstractions.Blog;

namespace ProSolution.DAL.Repositories.Implementations
{
    public class BlogWriteRepository : WriteRepository<Blog>, IBlogWriteRepository
    {
        public BlogWriteRepository(AppDbContext context) : base(context)
        {
        }
    }
}
