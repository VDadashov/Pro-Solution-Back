using AutoMapper;
using ProSolution.BL.DTOs.BLogDTOs;
using ProSolution.BL.DTOs.PartnerDTO;
using ProSolution.BL.Services.ExternalServices;
using ProSolution.BL.Services.InternalServices.Abstractions;
using ProSolution.Core.Entities;
using ProSolution.DAL.Repositories.Abstractions;
using ProSolution.DAL.Repositories.Abstractions.Blog;
using ProSolution.DAL.Repositories.Implementations;

namespace ProSolution.BL.Services.InternalServices.Implementations
{
    public class BlogService : IBlogService
    {
        private readonly IBlogReadRepository _blogReadRepository;
        private readonly IBlogWriteRepository _blogWriteRepository;
        private readonly IMapper _mapper;

        public BlogService(IMapper mapper, IBlogWriteRepository blogWriteRepository, IBlogReadRepository blogReadRepository)
        {
            _mapper = mapper;
            _blogWriteRepository = blogWriteRepository;
            _blogReadRepository = blogReadRepository;
        }

        public async Task<Blog> CreateAsync(BlogCreateDTO blogCreateDTO)
        {
            if (blogCreateDTO.ImagePath == null || !blogCreateDTO.ImagePath.IsValidFile())
            {
                throw new Exception("Invalid file type or size");
            }
            Blog blog = _mapper.Map<Blog>(blogCreateDTO);
            blog.ImagePath = await blogCreateDTO.ImagePath.SaveAsync("Blogs");
            blog.CreateAt = DateTime.UtcNow.AddHours(4);
            var res = await _blogWriteRepository.CreateAsync(blog);
            await _blogWriteRepository.SaveChangeAsync();
            return res;
        }

        public async Task<ICollection<Blog>> GetAllAsync()
        {
            return await _blogReadRepository.GetAllAsync(false);
        }

        public async Task<ICollection<Blog>> GetAllDeletedAsync()
        {
            return await _blogReadRepository.GetAllAsync(true);

        }

        public async Task<Blog> GetByIdAsync(int id)
        {
            Blog slider = await _blogReadRepository.GetByIdAsync(id, false);
            if (slider is null)
            {
                throw new Exception("Bu Id-e uygun deyer tapilmadi");
            }
            return slider;
        }

        public async Task<Blog> HardDeleteAsync(int id)
        {
            Blog catagory = await _blogReadRepository.GetByIdAsync(id, true);
            if (catagory is null)
            {
                throw new Exception("Bu Id-e uygun deyer tapilmadi");
            }
            var res = _blogWriteRepository.HardDelete(catagory);
            await _blogWriteRepository.SaveChangeAsync();
            return res;
        }

        public async Task<Blog> RestoreAsync(int id)
        {
            Blog catagory = await _blogReadRepository.GetByIdAsync(id, true);
            if (catagory is null)
            {
                throw new Exception("Bu Id-e uygun deyer tapilmadi");
            }
            var res = _blogWriteRepository.Restore(catagory);
            await _blogWriteRepository.SaveChangeAsync();
            return res;
        }

        public async Task<Blog> SoftDeleteAsync(int id)
        {
            Blog catagory = await _blogReadRepository.GetByIdAsync(id, true);
            if (catagory is null)
            {
                throw new Exception("Bu Id-e uygun deyer tapilmadi");
            }
            var res = _blogWriteRepository.SoftDelete(catagory);
            await _blogWriteRepository.SaveChangeAsync();
            return res;
        }

        public async Task<Blog> UpdateAsync(int id, BlogUpdateDTO blogUpdateDTO)
        {
            Blog oldProduct = await _blogReadRepository.GetByIdAsync(id, true);
            if (oldProduct == null)
            {
                throw new Exception("Bu Id-e uygun mehsul tapilmadi.");
            }
            string path = oldProduct.ImagePath;
            Blog product = _mapper.Map(blogUpdateDTO, oldProduct);
            product.UpdateAt = DateTime.UtcNow.AddHours(4);
            product.Id = oldProduct.Id;
            product.CreateAt = oldProduct.CreateAt;

            if (blogUpdateDTO.ImagePath != null)
            {
                product.ImagePath = await blogUpdateDTO.ImagePath.SaveAsync("Blogs");
            }
            else
            {
                product.ImagePath = path;
            }
            Blog product1 = _blogWriteRepository.Update(product);
            if (blogUpdateDTO.ImagePath != null)
            {
                File.Delete(Path.Combine(Path.GetFullPath("Resource"), "ImageUpload", "Partners", oldProduct.ImagePath));
            }
            await _blogWriteRepository.SaveChangeAsync();
            return product1;
        }
    }
}
