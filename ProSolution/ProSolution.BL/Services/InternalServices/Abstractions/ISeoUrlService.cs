using ProSolution.Business.DTOs.SEOUrlDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProSolution.BL.Services.InternalServices.Abstractions
{
    public interface ISeoUrlService
    {
        public Task<IEnumerable<SEOUrlDTO>> GetAllAsync();
        public Task<SEOUrlDTO> GetByIdAsync(GetByIdSEOUrlDTO dto);
        public Task<SEOUrlDTO> AddAsync(CreateSEOUrlDTO dto);
        public Task<SEOUrlDTO> UpdateAsync(UpdateSEOUrlDTO dto);
        public Task<SEOUrlDTO> DeleteAsync(DeleteSEOUrlDTO dto);
    }
}
