using AutoMapper;
using ProSolution.BL.DTOs.PartnerDTO;
using ProSolution.BL.DTOs.PartnerDTOs;
using ProSolution.BL.DTOs.SliderDTO;
using ProSolution.BL.Services.ExternalServices;
using ProSolution.BL.Services.InternalServices.Abstractions;
using ProSolution.Core.Entities;
using ProSolution.Core.Enums;
using ProSolution.DAL.Repositories.Abstractions;

namespace ProSolution.BL.Services.InternalServices.Implementations
{
    public class PartnerService : IPartnerService
    {
        private readonly IPartnerReadRepository _partnerReadRepository;
        private readonly IPartnerWriteRepository _partnerWriteRepository;
        private readonly IMapper _mapper;

        public PartnerService(IMapper mapper, IPartnerWriteRepository partnerWriteRepository, IPartnerReadRepository partnerReadRepository)
        {
            _mapper = mapper;
            _partnerWriteRepository = partnerWriteRepository;
            _partnerReadRepository = partnerReadRepository;
        }

        public async Task<Partner> CreateAsync(PartnerCreateDTO partnerDTO)
        {
            if (partnerDTO.ImagePath == null || !partnerDTO.ImagePath.IsValidFile())
            {
                throw new Exception("Invalid file type or size");
            }
            Partner slider = _mapper.Map<Partner>(partnerDTO);
            slider.ImagePath = await partnerDTO.ImagePath.SaveAsync("Partners");
            slider.CreateAt = DateTime.UtcNow.AddHours(4);
            var res = await _partnerWriteRepository.CreateAsync(slider);
            await _partnerWriteRepository.SaveChangeAsync();
            return res;
        }

        public async Task<ICollection<Partner>> GetAllAsync()
        {
            return await _partnerReadRepository.GetAllAsync(false);

        }

        public async Task<ICollection<Partner>> GetAllDeletedAsync()
        {
            return await _partnerReadRepository.GetAllAsync(true);

        }

        public async Task<Partner> GetByIdAsync(int id)
        {
            Partner slider = await _partnerReadRepository.GetByIdAsync(id, false);
            if (slider is null)
            {
                throw new Exception("Bu Id-e uygun deyer tapilmadi");
            }
            return slider;
        }

        public async Task<Partner> HardDeleteAsync(int id)
        {
            Partner catagory = await _partnerReadRepository.GetByIdAsync(id, true);
            if (catagory is null)
            {
                throw new Exception("Bu Id-e uygun deyer tapilmadi");
            }
            var res = _partnerWriteRepository.HardDelete(catagory);
            await _partnerWriteRepository.SaveChangeAsync();
            return res;
        }

        public async Task<Partner> RestoreAsync(int id)
        {
            Partner catagory = await _partnerReadRepository.GetByIdAsync(id, true);
            if (catagory is null)
            {
                throw new Exception("Bu Id-e uygun deyer tapilmadi");
            }
            var res = _partnerWriteRepository.Restore(catagory);
            await _partnerWriteRepository.SaveChangeAsync();
            return res;
        }
        public async Task<PagedResult<Partner>> GetPaginatedAsync(PaginationParams @params)
        {
            var allCategories = await _partnerReadRepository.GetAllAsync(false);

            var filtered = allCategories
                //.OrderByDescending(c => c.CreateAt)
                .Skip((@params.PageNumber - 1) * @params.PageSize)
                .Take(@params.PageSize)
                .ToList();

            int totalCount = allCategories.Count;

            return new PagedResult<Partner>(filtered, totalCount, @params.PageNumber, @params.PageSize);
        }
        public async Task<Partner> SoftDeleteAsync(int id)
        {
            Partner catagory = await _partnerReadRepository.GetByIdAsync(id, true);
            if (catagory is null)
            {
                throw new Exception("Bu Id-e uygun deyer tapilmadi");
            }
            var res = _partnerWriteRepository.SoftDelete(catagory);
            await _partnerWriteRepository.SaveChangeAsync();
            return res;
        }

        public async Task<Partner> UpdateAsync(int id, PartnerDTO partnerDTO)
        {
            Partner oldProduct = await _partnerReadRepository.GetByIdAsync(id, true);
            if (oldProduct == null)
            {
                throw new Exception("Bu Id-e uygun mehsul tapilmadi.");
            }
            string path = oldProduct.ImagePath;
            Partner product = _mapper.Map(partnerDTO, oldProduct);
            product.UpdateAt = DateTime.UtcNow.AddHours(4);
            product.Id = oldProduct.Id;
            product.CreateAt = oldProduct.CreateAt;

            if (partnerDTO.ImagePath != null)
            {
                product.ImagePath = await partnerDTO.ImagePath.SaveAsync("Partners");
            }
            else
            {
                product.ImagePath = path;
            }
            Partner product1 = _partnerWriteRepository.Update(product);
            if (partnerDTO.ImagePath != null)
            {
                File.Delete(Path.Combine(Path.GetFullPath("Resource"), "ImageUpload", "Partners", oldProduct.ImagePath));
            }
            await _partnerWriteRepository.SaveChangeAsync();
            return product1;
        }
    }
}
