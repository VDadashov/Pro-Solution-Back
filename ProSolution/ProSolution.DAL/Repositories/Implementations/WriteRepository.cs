using Microsoft.EntityFrameworkCore;
using ProSolution.Core.Entities.Commons;
using ProSolution.DAL.Contexts;
using ProSolution.DAL.Repositories.Abstractions;

namespace ProSolution.DAL.Repositories.Implementations
{
    public class WriteRepository<Tentity> : IWriteRepository<Tentity> where Tentity : BaseEntity, new()
    {
        private readonly AppDbContext _context;

        public WriteRepository(AppDbContext context)
        {
            _context = context;
        }

        public DbSet<Tentity> Table => _context.Set<Tentity>();

        public async Task<Tentity> CreateAsync(Tentity tentity)
        {
            await Table.AddAsync(tentity);
            return tentity;
        }

        public Tentity SoftDelete(Tentity tentity)
        {
            if (tentity is null)
            {
                throw new Exception("Bu Id ye uygun deyer tapilmadi");
            }
            tentity.IsDeleted = true;
            return tentity;

        }
        public Tentity HardDelete(Tentity tentity)
        {
            if (tentity is null)
            {
                throw new Exception("Bu Id ye uygun deyer tapilmadi");
            }
            Table.Remove(tentity);
            return tentity;

        }

        public Tentity Restore(Tentity tentity)
        {
            if (tentity is null)
            {
                throw new Exception("Bu Id ye uygun deyer tapilmadi");
            }
            tentity.IsDeleted = false;
            return tentity;
        }

        public async Task SaveChangeAsync()
        {
            await _context.SaveChangesAsync();

        }

        public Tentity Update(Tentity tentity)
        {
            Table.Update(tentity);
            return tentity;
        }
    }
}
