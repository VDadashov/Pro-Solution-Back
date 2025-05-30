﻿using ProSolution.Core.Entities.Commons;

namespace ProSolution.DAL.Repositories.Abstractions
{
    public interface IWriteRepository<Tentity> : IRepository<Tentity> where Tentity : BaseEntity, new()
    {
        Task<Tentity> CreateAsync(Tentity tentity);
        Tentity Update(Tentity tentity);
        Tentity SoftDelete(Tentity tentity);
        Tentity HardDelete(Tentity tentity);
        Tentity Restore(Tentity tentity);
        Task SaveChangeAsync();
    }
    
}
