using AutoMapper;
using Microsoft.AspNetCore.Http;
using ProSolution.BL.Services.InternalServices.Abstractions;
using ProSolution.Business.DTOs.SEODTOs;
using ProSolution.Core.Entities;
using ProSolution.DAL.Repositories.Abstractions.ISeoRepo;
using ProSolution.DAL.Repositories.Implementations.SeoRepo;

namespace ProSolution.Business.Services.InternalServices.Abstractions
{
    public class SEOService : ISeoService
    {
        private readonly ISeoReadRepository _readRepository;
        private readonly ISeoWriteRepository _writeRepository;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _http;

        public SEOService(ISeoReadRepository readRepository, ISeoWriteRepository writeRepository, IMapper mapper, IHttpContextAccessor http)
        {
            _readRepository = readRepository;
            _writeRepository = writeRepository;
            _mapper = mapper;
            _http = http;
        }

        public async Task<IEnumerable<SEODTO>> GetAllAsync()
        {
            var entities = await _readRepository.GetAllAsync(false);
            return entities.Select(MapToSEODTOWithMetaTags);
        }

        public async Task<SEODTO> GetByIdAsync(GetByIdSEODTO dto)
        {
            var entity = await _readRepository.GetByIdAsync(dto.Id, false);
            if (entity == null)
                throw new Exception("SEO entry not found");

            return MapToSEODTOWithMetaTags(entity);
        }

        public async Task<SEODTO> AddAsync(CreateSEODTO dto)
        {
            var entity = _mapper.Map<SeoData>(dto);
            await _writeRepository.CreateAsync(entity);
            await _writeRepository.SaveChangeAsync();

            return MapToSEODTOWithMetaTags(entity);
        }

        public async Task<SEODTO> UpdateAsync(UpdateSEODTO dto)
        {
            var existing = await _readRepository.GetByIdAsync(dto.Id, true);
            if (existing == null)
                throw new Exception("SEO entry not found");

            _mapper.Map(dto, existing);
            _writeRepository.Update(existing);
            await _writeRepository.SaveChangeAsync();

            return MapToSEODTOWithMetaTags(existing);
        }

        public async Task<SEODTO> DeleteAsync(DeleteSEODTO dto)
        {
            var entity = await _readRepository.GetByIdAsync(dto.Id, true);
            if (entity == null)
                throw new Exception("SEO entry not found");

            _writeRepository.SoftDelete(entity);
            await _writeRepository.SaveChangeAsync();

            return MapToSEODTOWithMetaTags(entity);
        }

        private SEODTO MapToSEODTOWithMetaTags(SeoData entity)
        {
            return new SEODTO
            {
                Id = entity.Id,
                AltText = entity.AltText,
                AnchorText = entity.AnchorText,
            };
        }
    }
}
