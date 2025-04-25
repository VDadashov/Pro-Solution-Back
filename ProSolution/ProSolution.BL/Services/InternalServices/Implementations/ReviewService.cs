using AutoMapper;
using ProSolution.BL.DTOs.CatagoryDTOs;
using ProSolution.BL.DTOs.ReviewDTOs;
using ProSolution.BL.Services.InternalServices.Abstractions;
using ProSolution.Core.Entities;
using ProSolution.Core.Enums;
using ProSolution.DAL.Repositories.Abstractions.Review;

namespace ProSolution.BL.Services.InternalServices.Implementations
{
    public class ReviewService : IReviewService
    {
        private readonly IReviewReadRepository _reviewReadRepository;
        private readonly IReviewWriteRepository _reviewWriteRepository;
        private readonly IMapper _mapper;

        public ReviewService(IMapper mapper, IReviewWriteRepository reviewWriteRepository, IReviewReadRepository reviewReadRepository)
        {
            _mapper = mapper;
            _reviewWriteRepository = reviewWriteRepository;
            _reviewReadRepository = reviewReadRepository;
        }

        public async Task<Review> CreateAsync(ReviewDTO reviewDTO)
        {
            Review catagory = _mapper.Map<Review>(reviewDTO);
            catagory.CreateAt = DateTime.UtcNow.AddHours(4);
            var res = await _reviewWriteRepository.CreateAsync(catagory);
            await _reviewWriteRepository.SaveChangeAsync();
            return res;
        }

        public async Task<ICollection<Review>> GetAllAsync()
        {
            return await _reviewReadRepository.GetAllAsync(false);

        }

        public async Task<ICollection<Review>> GetAllDeletedAsync()
        {
            return await _reviewReadRepository.GetAllAsync(true);
        }

        public async Task<Review> GetByIdAsync(int id)
        {
            Review catagory = await _reviewReadRepository.GetByIdAsync(id, false);
            if (catagory is null)
            {
                throw new Exception("Bu Id-e uygun deyer tapilmadi");
            }
            return catagory;
        }

        //PAGINATION REVIEW
        public async Task<PagedResult<Review>> GetPaginatedAsync(PaginationParams @params, int? productId = null)
        {
            var allReviews = await _reviewReadRepository.GetAllAsync(false);

            if (productId != null)
            {
                allReviews = allReviews
                    .Where(r => r.ProductId == productId)
                    .ToList();
            }

            var filtered = allReviews
                .OrderByDescending(r => r.CreateAt)
                .Skip((@params.PageNumber - 1) * @params.PageSize)
                .Take(@params.PageSize)
                .ToList();

            int totalCount = allReviews.Count;

            return new PagedResult<Review>(filtered, totalCount, @params.PageNumber, @params.PageSize);
        }


        public async Task<Review> HardDeleteAsync(int id)
        {
            Review catagory = await _reviewReadRepository.GetByIdAsync(id, true);
            if (catagory is null)
            {
                throw new Exception("Bu Id ye uygun deyer tapilmadi");
            }
            var res = _reviewWriteRepository.HardDelete(catagory);
            await _reviewWriteRepository.SaveChangeAsync();
            return res;
        }

        public async Task<Review> RestoreAsync(int id)
        {
            Review catagory = await _reviewReadRepository.GetByIdAsync(id, true);
            if (catagory is null)
            {
                throw new Exception("Bu Id ye uygun deyer tapilmadi");
            }
            var res = _reviewWriteRepository.Restore(catagory);
            await _reviewWriteRepository.SaveChangeAsync();
            return res;
        }

        public async Task<Review> SoftDeleteAsync(int id)
        {
            Review catagory = await _reviewReadRepository.GetByIdAsync(id, true);
            if (catagory is null)
            {
                throw new Exception("Bu Id ye uygun deyer tapilmadi");
            }
            var res = _reviewWriteRepository.SoftDelete(catagory);
            await _reviewWriteRepository.SaveChangeAsync();
            return res;
        }

        public async Task<Review> UpdateAsync(int id, ReviewDTO reviewDTO)
        {
            Review catagory = await _reviewReadRepository.GetByIdAsync(id, false);
            if (catagory is null)
            {
                throw new Exception("Bu Id ye uygun deyer tapilmadi");
            }
            Review updateCatagory = _mapper.Map<Review>(reviewDTO);
            updateCatagory.Id = id;
            updateCatagory.CreateAt = catagory.CreateAt;
            updateCatagory.UpdateAt = DateTime.UtcNow.AddHours(4);
            var res = _reviewWriteRepository.Update(updateCatagory);
            await _reviewWriteRepository.SaveChangeAsync();
            return res;
        }
    }
}
