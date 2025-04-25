using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using ProSolution.BL.Services.InternalServices.Abstractions;
using ProSolution.Business.DTOs.SEODTOs;
using ProSolution.Core.Entities;
using ProSolution.DAL.Contexts;
using ProSolution.DAL.Repositories.Abstractions.ISeoRepo;

namespace ProSolution.Business.Services.InternalServices.Abstractions
{
    public class SeoMetaService : ISeoMetaService
    {
        private readonly ISeoMetaReadRepository _readRepository;
        private readonly ISeoMetaWriteRepository _writeRepository;
        private readonly IMapper _mapper;
        private readonly AppDbContext _dbContext;
        private readonly IHttpContextAccessor _http;

        public SeoMetaService(
            ISeoMetaReadRepository readRepository,
            ISeoMetaWriteRepository writeRepository,
            IMapper mapper,
            IHttpContextAccessor http,
            AppDbContext dbContext)
        {
            _readRepository = readRepository;
            _writeRepository = writeRepository;
            _mapper = mapper;
            _http = http;
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<SEOMetaDTO>> GetAllAsync()
        {
            var entities = await _readRepository.GetAllAsync(false);
            return entities.Select(MapToSEOMetaDTO);
        }

        public async Task<SEOMetaDTO> GetByIdAsync(GetByIdSEOMetaDTO dto)
        {
            var entity = await _readRepository.GetByIdAsync(dto.Id, false);
            if (entity == null) throw new Exception("SEO Meta entry not found");

            return MapToSEOMetaDTO(entity);
        }

        public async Task<SEOMetaDTO> AddAsync(CreateSEOMetaDTO dto)
        {
            var allEntities = await _dbContext.SeoMetas
                .Where(e =>
                    (e.MetaTitle != null || e.MetaDescription != null || e.MetaTags != null) &&
                    e.IsDeleted == false)
                .ToListAsync();

            if (!string.IsNullOrWhiteSpace(dto.MetaTitle) &&
                allEntities.Any(e => e.MetaTitle == dto.MetaTitle))
            {
                throw new InvalidOperationException($"MetaTitle '{dto.MetaTitle}' already exists.");
            }

            if (!string.IsNullOrWhiteSpace(dto.MetaDescription) &&
                allEntities.Any(e => e.MetaDescription == dto.MetaDescription))
            {
                throw new InvalidOperationException($"MetaDescription '{dto.MetaDescription}' already exists.");
            }

            var entity = _mapper.Map<SeoMeta>(dto);
            await _writeRepository.CreateAsync(entity);
            await _writeRepository.SaveChangeAsync();

            return MapToSEOMetaDTO(entity);
        }

        public async Task<SEOMetaDTO> UpdateAsync(UpdateSEOMetaDTO dto)
        {
            var existingEntity = await _readRepository.GetByIdAsync(dto.Id, true);
            if (existingEntity == null)
                throw new Exception("SEO Meta entry not found");

            _mapper.Map(dto, existingEntity);
            _writeRepository.Update(existingEntity);
            await _writeRepository.SaveChangeAsync();

            return MapToSEOMetaDTO(existingEntity);
        }

        public async Task<SEOMetaDTO> DeleteAsync(DeleteSEOMetaDTO dto)
        {
            var entity = await _readRepository.GetByIdAsync(dto.Id, true);
            if (entity == null)
                throw new Exception("SEO Meta entry not found");

            _writeRepository.SoftDelete(entity);
            await _writeRepository.SaveChangeAsync();

            return MapToSEOMetaDTO(entity);
        }

        private SEOMetaDTO MapToSEOMetaDTO(SeoMeta entity)
        {
            return new SEOMetaDTO
            {
                Id = entity.Id,
                MetaTitle = $"<meta name=\"title\" content=\"{entity.MetaTitle}\"></meta>",
                MetaDescription = $"<meta name=\"description\" content=\"{entity.MetaDescription}\"></meta>",
                MetaTags = $"<meta content=\"{entity.MetaTags}\"></meta>"
            };
        }
    }

}
