using AutoMapper;
using ProSolution.BL.DTOs.BrandDTO;
using ProSolution.BL.DTOs.BrandDTOs;
using ProSolution.BL.DTOs.PartnerDTO;
using ProSolution.BL.Services.ExternalServices;
using ProSolution.BL.Services.InternalServices.Abstractions;
using ProSolution.Core.Entities;
using ProSolution.Core.Enums;
using ProSolution.DAL.Repositories.Abstractions;
using ProSolution.DAL.Repositories.Implementations;

namespace ProSolution.BL.Services.InternalServices.Implementations
{
    public class BrandService : IBrandService
    {
        private readonly IBrandReadRepository _brandReadRepository;
        private readonly IBrandWriteRepository _brandWriteRepository;
        private readonly IFileManagerService _fileManagerService;
        private readonly IMapper _mapper;

        public BrandService(IMapper mapper, IBrandWriteRepository brandWriteRepository, IBrandReadRepository brandReadRepository, IFileManagerService fileManagerService)
        {
            _mapper = mapper;
            _brandWriteRepository = brandWriteRepository;
            _brandReadRepository = brandReadRepository;
            _fileManagerService = fileManagerService;
        }

        public async Task<Brand> CreateAsync(BrandCreateDTO partnerDTO)
        {
            if (partnerDTO.ImagePath == null || !partnerDTO.ImagePath.IsValidFile())
            {
                throw new Exception("Invalid file type or size");
            }

            var imageUrl = await _fileManagerService.UploadFileAsync(partnerDTO.ImagePath);

            Brand slider = _mapper.Map<Brand>(partnerDTO);
            slider.ImagePath = imageUrl;
            slider.CreateAt = DateTime.UtcNow.AddHours(4);
            var res = await _brandWriteRepository.CreateAsync(slider);
            await _brandWriteRepository.SaveChangeAsync();
            return res;
        }

        public async Task<ICollection<Brand>> GetAllAsync()
        {
            return await _brandReadRepository.GetAllAsync(false);
        }

        public async Task<ICollection<Brand>> GetAllDeletedAsync()
        {
            return await _brandReadRepository.GetAllAsync(true);
        }

        public async Task<Brand> GetByIdAsync(int id)
        {
            Brand slider = await _brandReadRepository.GetByIdAsync(id, false);
            if (slider is null)
            {
                throw new Exception("Bu Id-e uygun deyer tapilmadi");
            }
            return slider;
        }

        public async Task<Brand> HardDeleteAsync(int id)
        {
            Brand catagory = await _brandReadRepository.GetByIdAsync(id, true);
            if (catagory is null)
            {
                throw new Exception("Bu Id-e uygun deyer tapilmadi");
            }
            var res = _brandWriteRepository.HardDelete(catagory);
            await _brandWriteRepository.SaveChangeAsync();
            return res;
        }

        public async Task<Brand> RestoreAsync(int id)
        {
            Brand catagory = await _brandReadRepository.GetByIdAsync(id, true);
            if (catagory is null)
            {
                throw new Exception("Bu Id-e uygun deyer tapilmadi");
            }
            var res = _brandWriteRepository.Restore(catagory);
            await _brandWriteRepository.SaveChangeAsync();
            return res;
        }

        public async Task<Brand> SoftDeleteAsync(int id)
        {
            Brand catagory = await _brandReadRepository.GetByIdAsync(id, true);
            if (catagory is null)
            {
                throw new Exception("Bu Id-e uygun deyer tapilmadi");
            }
            var res = _brandWriteRepository.SoftDelete(catagory);
            await _brandWriteRepository.SaveChangeAsync();
            return res;
        }

        public async Task<Brand> UpdateAsync(int id, BrandDTO partnerDTO)
        {
            Brand oldProduct = await _brandReadRepository.GetByIdAsync(id, true);
            string path = oldProduct.ImagePath;
            if (oldProduct == null)
            {
                throw new Exception("Bu Id-e uygun mehsul tapilmadi.");
            }

            var imageUrl = await _fileManagerService.UploadFileAsync(partnerDTO.ImagePath);
            Brand product = _mapper.Map(partnerDTO, oldProduct);
            product.UpdateAt = DateTime.UtcNow.AddHours(4);
            product.Id = oldProduct.Id;
            product.CreateAt = oldProduct.CreateAt;

            if (partnerDTO.ImagePath != null)
            {
                product.ImagePath = imageUrl;
            }
            else
            {
                product.ImagePath = path;
            }
            Brand product1 = _brandWriteRepository.Update(product);
            //if (partnerDTO.ImagePath != null)
            //{
            //    File.Delete(Path.Combine(Path.GetFullPath("Resource"), "ImageUpload", "Brands", oldProduct.ImagePath));
            //}
            await _brandWriteRepository.SaveChangeAsync();
            return product1;
        }
        public async Task<PagedResult<Brand>> GetPaginatedAsync(PaginationParams @params)
        {
            var allCategories = await _brandReadRepository.GetAllAsync(false);

            var filtered = allCategories
                 //.OrderByDescending(c => c.CreateAt)
                .Skip((@params.PageNumber - 1) * @params.PageSize)
                .Take(@params.PageSize)
                .ToList();

            int totalCount = allCategories.Count;

            return new PagedResult<Brand>(filtered, totalCount, @params.PageNumber, @params.PageSize);
        }
    }
}
