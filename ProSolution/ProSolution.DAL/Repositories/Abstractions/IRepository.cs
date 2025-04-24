using Microsoft.EntityFrameworkCore;
using ProSolution.Core.Entities.Commons;

namespace ProSolution.DAL.Repositories.Abstractions
{
    public interface IRepository<Tentity> where Tentity : BaseEntity , new()
    {
        public DbSet<Tentity> Table { get; }
    }
}
