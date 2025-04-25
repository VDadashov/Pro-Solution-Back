using AutoMapper;
using Microsoft.AspNetCore.Http;
using ProSolution.BL.Services.InternalServices.Abstractions;
using ProSolution.Business.DTOs.SEOUrlDTOs;
using ProSolution.Core.Entities;
using ProSolution.DAL.Repositories.Abstractions.ISeoRepo;

namespace ProSolution.Business.Services.InternalServices.Abstractions
{
    public class SeoUrlService : ISeoUrlService
    {
        private readonly ISeoUrlReadRepository _readRepository;
        private readonly ISeoUrlWriteRepository _writeRepository;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _http;

        public SeoUrlService(
            ISeoUrlReadRepository readRepository,
            ISeoUrlWriteRepository writeRepository,
            IMapper mapper,
            IHttpContextAccessor http)
        {
            _readRepository = readRepository;
            _writeRepository = writeRepository;
            _mapper = mapper;
            _http = http;
        }

        public async Task<IEnumerable<SEOUrlDTO>> GetAllAsync()
        {
            var entities = await _readRepository.GetAllAsync(false);
            return entities.Select(MapToSEOUrlDTO);
        }

        public async Task<SEOUrlDTO> GetByIdAsync(GetByIdSEOUrlDTO dto)
        {
            var entity = await _readRepository.GetByIdAsync(dto.Id, false);
            if (entity == null)
                throw new Exception("SEO URL entry not found");

            return MapToSEOUrlDTO(entity);
        }

        public async Task<SEOUrlDTO> AddAsync(CreateSEOUrlDTO dto)
        {
            var entity = _mapper.Map<SeoUrl>(dto);
            await _writeRepository.CreateAsync(entity);
            await _writeRepository.SaveChangeAsync();

            return MapToSEOUrlDTO(entity);
        }

        public async Task<SEOUrlDTO> UpdateAsync(UpdateSEOUrlDTO dto)
        {
            var existingEntity = await _readRepository.GetByIdAsync(dto.Id, true);
            if (existingEntity == null)
                throw new Exception("SEO URL entry not found");

            _mapper.Map(dto, existingEntity);
            _writeRepository.Update(existingEntity);
            await _writeRepository.SaveChangeAsync();

            return MapToSEOUrlDTO(existingEntity);
        }

        public async Task<SEOUrlDTO> DeleteAsync(DeleteSEOUrlDTO dto)
        {
            var entity = await _readRepository.GetByIdAsync(dto.Id, true);
            if (entity == null)
                throw new Exception("SEO URL entry not found");

            _writeRepository.SoftDelete(entity);
            await _writeRepository.SaveChangeAsync();

            return MapToSEOUrlDTO(entity);
        }

        private SEOUrlDTO MapToSEOUrlDTO(SeoUrl entity)
        {
            return new SEOUrlDTO
            {
                Id = entity.Id,
                Url = entity.Url,
                RedirectUrl = entity.RedirectUrl
            };
        }
    }
}
