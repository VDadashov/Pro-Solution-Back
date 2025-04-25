using ProSolution.Business.DTOs.SEODTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProSolution.BL.Services.InternalServices.Abstractions
{
    public interface ISeoMetaService
    {
        public Task<IEnumerable<SEOMetaDTO>> GetAllAsync();
        public Task<SEOMetaDTO> GetByIdAsync(GetByIdSEOMetaDTO dto);
        public Task<SEOMetaDTO> AddAsync(CreateSEOMetaDTO dto);
        public Task<SEOMetaDTO> UpdateAsync(UpdateSEOMetaDTO dto);
        public Task<SEOMetaDTO> DeleteAsync(DeleteSEOMetaDTO dto);
    }
}
