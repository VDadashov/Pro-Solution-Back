using AutoMapper;
using ProSolution.BL.DTOs.BLogDTOs;
using ProSolution.BL.DTOs.CatagoryDTOs;
using ProSolution.BL.DTOs.ProductDTOs;
using ProSolution.BL.Services.ExternalServices;
using ProSolution.BL.Services.InternalServices.Abstractions;
using ProSolution.Core.Entities;
using ProSolution.Core.Enums;
using ProSolution.DAL.Repositories.Abstractions;
using ProSolution.DAL.Repositories.Abstractions.Product;
using ProSolution.DAL.Repositories.Implementations;

namespace ProSolution.BL.Services.InternalServices.Implementations
{
    public class ProductService : IProductService
    {
        private readonly IProductReadRepository _productReadRepository;
        private readonly IProductWriteRepository _productWriteRepository;
        private readonly IMapper _mapper;

        public ProductService(IMapper mapper, IProductWriteRepository productWriteRepository, IProductReadRepository productReadRepository)
        {
            _mapper = mapper;
            _productWriteRepository = productWriteRepository;
            _productReadRepository = productReadRepository;
        }


        public async Task<ICollection<ProductReadDTO>> GetAllDiscountProductAsync()
        {
            var currentDate = DateTime.UtcNow;

            var discountedProducts = await _productReadRepository
                .GetAllAsync(false, "Catagory");

            var filteredProducts = discountedProducts
                .Where(p =>
                    p.Dicount.HasValue &&
                    p.DiscountEndDate.HasValue &&
                    p.DiscountEndDate > currentDate
                )
                .ToList();

            var result = _mapper.Map<List<ProductReadDTO>>(filteredProducts);

            foreach (var item in result)
            {
                item.NewPrice = item.Price - (item.Price * (decimal)item.Dicount.Value / 100);
            }

            return result;
        }



        public async Task<Product> CreateAsync(ProductCreateDTO productCreateDto)
        {
            if (productCreateDto.Images == null || !productCreateDto.Images.Any())
            {
                throw new Exception("No images uploaded.");
            }

            foreach (var imageDto in productCreateDto.Images)
            {
                if (!imageDto.File.IsValidFile())
                {
                    throw new Exception("One or more files have invalid type or size.");
                }
            }

            Product product = _mapper.Map<Product>(productCreateDto);
            product.CreateAt = DateTime.UtcNow.AddHours(4);
            product.ProductImages = new List<ProductImage>();

            foreach (var imageDto in productCreateDto.Images)
            {
                string savedPath = await imageDto.File.SaveAsync("Products");
                product.ProductImages.Add(new ProductImage
                {
                    ImagePath = savedPath,
                    IsMain = imageDto.IsMain,
                    AltText = imageDto.AltText ?? productCreateDto.Title
                });
            }

            var res = await _productWriteRepository.CreateAsync(product);
            await _productWriteRepository.SaveChangeAsync();
            return res;
        }


        public async Task<Product> UpdateAsync(int id, ProductUpdateDTO productUpdateDTO)
        {
            Product oldProduct = await _productReadRepository.GetByIdAsync(id, false, ["ProductImages", "Catagory"]);
            if (oldProduct == null)
            {
                throw new Exception("Bu Id-e uygun mehsul tapilmadi.");
            }

            _mapper.Map(productUpdateDTO, oldProduct);
            oldProduct.UpdateAt = DateTime.UtcNow.AddHours(4);

            if (productUpdateDTO.Images != null && productUpdateDTO.Images.Any())
            {
                foreach (var oldImage in oldProduct.ProductImages)
                {
                    string oldImagePath = Path.Combine(Path.GetFullPath("Resource"), "ImageUpload", "Products", oldImage.ImagePath);
                    if (File.Exists(oldImagePath))
                    {
                        File.Delete(oldImagePath);
                    }
                }
                oldProduct.ProductImages.Clear();

                foreach (var imageDto in productUpdateDTO.Images)
                {
                    if (!imageDto.File.IsValidFile())
                    {
                        throw new Exception("One or more files have invalid type or size.");
                    }

                    string savedPath = await imageDto.File.SaveAsync("Products");
                    oldProduct.ProductImages.Add(new ProductImage
                    {
                        ImagePath = savedPath,
                        IsMain = imageDto.IsMain,
                        AltText = imageDto.AltText ?? productUpdateDTO.Title
                    });
                }
            }
            Product updatedProduct = _productWriteRepository.Update(oldProduct);
            await _productWriteRepository.SaveChangeAsync();
            return updatedProduct;
        }
        public async Task<ICollection<ProductReadDTO>> GetAllAsync()
        {
            var products = await _productReadRepository.GetAllAsync(false, ["Catagory" , "ProductImages"]);
            var result = _mapper.Map<ICollection<ProductReadDTO>>(products);
            return result;

        }
        public async Task<PagedResult<ProductReadDTO>> GetPaginatedAsync(PaginationParams @params)
        {
            ICollection<Product> allCategories = await _productReadRepository.GetAllAsync(false, ["Catagory", "ProductImages"]);
            ICollection<ProductReadDTO> blogDtos = _mapper.Map<ICollection<ProductReadDTO>>(allCategories);

            var filtered = blogDtos
                //.OrderByDescending(c => c.CreateAt)
                .Skip((@params.PageNumber - 1) * @params.PageSize)
                .Take(@params.PageSize)
                .ToList();
            int totalCount = allCategories.Count;
            var test = new PagedResult<ProductReadDTO>(filtered, totalCount, @params.PageNumber, @params.PageSize);
            return test;
        }

        public async Task<ICollection<ProductReadDTO>> GetFilteredPrice(int minPrice, int maxPrice)
        {
            var products = await _productReadRepository.GetAllAsync(false, "Catagory");
            var filteredProducts = products
                .Where(p => p.Price >= minPrice && p.Price <= maxPrice)
                .ToList();
            var result = _mapper.Map<ICollection<ProductReadDTO>>(filteredProducts);
            return result;
        }


        public async Task<ICollection<ProductReadDTO>> GetMostSoldProductAsync()
        {
            var products = await _productReadRepository.GetAllAsync(false, "Catagory");

            var topSoldProducts = products
                .OrderByDescending(p => p.SoldCount)
                .Take(10)
                .ToList();

            var result = _mapper.Map<ICollection<ProductReadDTO>>(topSoldProducts);

            return result;
        }
        public async Task<ICollection<ProductReadDTO>> GetNewestProductsAsync()
        {
            var products = await _productReadRepository.GetAllAsync(false, "Catagory");

            var newestProducts = products
                .OrderByDescending(p => p.CreateAt)
                .Take(10)
                .ToList();

            var result = _mapper.Map<ICollection<ProductReadDTO>>(newestProducts);

            return result;
        }

        public async Task<ICollection<ProductReadDTO>> GetNewestDiscountedProductsAsync()
        {
            var products = await _productReadRepository.GetAllAsync(false, "Catagory");

            var discountedProducts = products
                .Where(p => p.Dicount != null)
                .OrderByDescending(p => p.CreateAt)
                .Take(10)
                .ToList();

            var result = _mapper.Map<ICollection<ProductReadDTO>>(discountedProducts);

            return result;
        }


        public async Task<ICollection<ProductReadDTO>> GetAllDeletedAsync()
        {
            var products = await _productReadRepository.GetAllAsync(true, "Catagory");
            var result = _mapper.Map<ICollection<ProductReadDTO>>(products);
            return result;
        }

        public async Task<ProductReadDTO> GetByIdAsync(int id)
        {
            Product product = await _productReadRepository.GetByIdAsync(id, true, "Catagory");
            if (product is null)
            {
                throw new Exception("Bu Id-e uygun deyer tapilmadi");
            }
            ProductReadDTO result = _mapper.Map<ProductReadDTO>(product);
            return result;
        }

        public async Task<Product> HardDeleteAsync(int id)
        {
            Product product = await _productReadRepository.GetByIdAsync(id, true);
            if (product is null)
            {
                throw new Exception("Bu Id ye uygun deyer tapilmadi");
            }
            var res = _productWriteRepository.HardDelete(product);
            await _productWriteRepository.SaveChangeAsync();
            //File.Delete(Path.Combine(Path.GetFullPath("Resource"), "ImageUpload", "Products" ,res.ImagePath));
            return res;
        }

        public async Task<Product> RestoreAsync(int id)
        {
            Product product = await _productReadRepository.GetByIdAsync(id, true);
            if (product is null)
            {
                throw new Exception("Bu Id ye uygun deyer tapilmadi");
            }
            var res = _productWriteRepository.Restore(product);
            await _productWriteRepository.SaveChangeAsync();
            return res;
        }

        public async Task<ICollection<ProductReadDTO>> SearchProductsAsync(string search)
        {
            var query = await _productReadRepository.GetAllAsync(false, "Catagory");

            if (!string.IsNullOrEmpty(search))
            {
                query = query
                    .Where(p => p.Title.Contains(search, StringComparison.OrdinalIgnoreCase) ||
                                p.Description.Contains(search, StringComparison.OrdinalIgnoreCase))
                    .ToList();
            }
            var result = _mapper.Map<ICollection<ProductReadDTO>>(query);
            return result;
        }

        public async Task<Product> SoftDeleteAsync(int id)
        {
            Product product = await _productReadRepository.GetByIdAsync(id, true);
            if (product is null)
            {
                throw new Exception("Bu Id ye uygun deyer tapilmadi");
            }
            var res = _productWriteRepository.SoftDelete(product);
            await _productWriteRepository.SaveChangeAsync();
            return res;
        }

       
    }
}
