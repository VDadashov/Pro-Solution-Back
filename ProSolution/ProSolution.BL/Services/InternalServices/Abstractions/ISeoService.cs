using ProSolution.Business.DTOs.SEODTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProSolution.BL.Services.InternalServices.Abstractions
{
    public interface ISeoService
    {

        public Task<IEnumerable<SEODTO>> GetAllAsync();
        public Task<SEODTO> GetByIdAsync(GetByIdSEODTO dto);
        public Task<SEODTO> AddAsync(CreateSEODTO dto);
        public Task<SEODTO> UpdateAsync(UpdateSEODTO dto);
        public Task<SEODTO> DeleteAsync(DeleteSEODTO dto);
    }
}
