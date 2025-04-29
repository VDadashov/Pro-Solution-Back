using AutoMapper;
using ProSolution.BL.DTOs.CatagoryDTOs;
using ProSolution.BL.Services.InternalServices.Abstractions;
using ProSolution.Core.Entities;
using ProSolution.Core.Enums;
using ProSolution.DAL.Repositories.Abstractions;

namespace ProSolution.BL.Services.InternalServices.Implementations
{
    public class CatagoryService : ICatagoryService
    {
        private readonly ICatagoryReadRepository _catagoryReadRepository;
        private readonly ICatagoryWriteRepository _catagoryWriteRepository;
        private readonly IMapper _mapper;

        public CatagoryService(ICatagoryWriteRepository catagoryWriteRepository, ICatagoryReadRepository catagoryReadRepository, IMapper mapper)
        {
            _catagoryWriteRepository = catagoryWriteRepository;
            _catagoryReadRepository = catagoryReadRepository;
            _mapper = mapper;
        }
        public async Task<ICollection<Catagory>> GetCategoriesByParentIdAsync(int parentId)
        {
            var allCategories = await _catagoryReadRepository.GetAllAsync(false);
            var filteredCategories = allCategories.Where(c => c.ParentCatagoryId == parentId).ToList();
            return filteredCategories;
        }
        public async Task<Catagory> CreateAsync(CatagoryCreateDTO catagoryDto)
        {
            Catagory catagory = _mapper.Map<Catagory>(catagoryDto);
            catagory.ParentCatagoryId = catagoryDto.ParentCategoryId;
            catagory.CreateAt = DateTime.UtcNow.AddHours(4);
            var res = await _catagoryWriteRepository.CreateAsync(catagory);
            await _catagoryWriteRepository.SaveChangeAsync();
            return res;
        }
        public async Task<Catagory> UpdateAsync(int id, CatagoryDTO catagoryDto)
        {
            Catagory catagory = await _catagoryReadRepository.GetByIdAsync(id, false);
            if (catagory is null)
            {
                throw new Exception("Bu Id ye uygun deyer tapilmadi");
            }
            Catagory updateCatagory = _mapper.Map<Catagory>(catagoryDto);
            updateCatagory.Id = id;
            updateCatagory.CreateAt = catagory.CreateAt;
            updateCatagory.UpdateAt = DateTime.UtcNow.AddHours(4);
            var res = _catagoryWriteRepository.Update(updateCatagory);
            await _catagoryWriteRepository.SaveChangeAsync();
            return res;
        }

        public async Task<ICollection<Catagory>> GetAllAsync()
        {
            return await _catagoryReadRepository.GetAllAsync(false);
        }

        public async Task<ICollection<Catagory>> GetAllDeletedAsync()
        {
            return await _catagoryReadRepository.GetAllAsync(true);
        }

        public async Task<Catagory> GetByIdAsync(int id)
        {
            Catagory catagory = await _catagoryReadRepository.GetByIdAsync(id, false);
            if (catagory is null)
            {
                throw new Exception("Bu Id ye uygun deyer tapilmadi");
            }
            return catagory;
        }

        public async Task<Catagory> HardDeleteAsync(int id)
        {
            Catagory catagory = await _catagoryReadRepository.GetByIdAsync(id, true);
            if (catagory is null)
            {
                throw new Exception("Bu Id ye uygun deyer tapilmadi");
            }
            var res = _catagoryWriteRepository.HardDelete(catagory);
            await _catagoryWriteRepository.SaveChangeAsync();
            return res;
        }

        public async Task<Catagory> RestoreAsync(int id)
        {
            Catagory catagory = await _catagoryReadRepository.GetByIdAsync(id, true);
            if (catagory is null)
            {
                throw new Exception("Bu Id ye uygun deyer tapilmadi");
            }
            var res = _catagoryWriteRepository.Restore(catagory);
            await _catagoryWriteRepository.SaveChangeAsync();
            return res;
        }

        public async Task<Catagory> SoftDeleteAsync(int id)
        {
            Catagory catagory = await _catagoryReadRepository.GetByIdAsync(id, true);
            if (catagory is null)
            {
                throw new Exception("Bu Id ye uygun deyer tapilmadi");
            }
            var res = _catagoryWriteRepository.SoftDelete(catagory);
            await _catagoryWriteRepository.SaveChangeAsync();
            return res;
        }
        public async Task<PagedResult<Catagory>> GetPaginatedAsync(PaginationParams @params)
        {
            var allCategories = await _catagoryReadRepository.GetAllAsync(false);

            var filtered = allCategories
                .OrderByDescending(c => c.CreateAt)
                .Skip((@params.PageNumber - 1) * @params.PageSize)
                .Take(@params.PageSize)
                .ToList();

            int totalCount = allCategories.Count;

            return new PagedResult<Catagory>(filtered, totalCount, @params.PageNumber, @params.PageSize);
        }


    }
}
