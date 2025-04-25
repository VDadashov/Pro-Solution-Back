using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProSolution.BL.DTOs.ProductDTOs;
using ProSolution.BL.Services.InternalServices.Abstractions;
using ProSolution.BL.Services.InternalServices.Implementations;
using ProSolution.Core.Entities;
using ProSolution.Core.Enums;

namespace ProSolution.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet]
        public async Task<ICollection<ProductReadDTO>> GetAll()
        {
            return await _productService.GetAllAsync();
        }
        [HttpGet("MostSoldProduct")]
        public async Task<ICollection<ProductReadDTO>> GetAllMostSold()
        {
            return await _productService.GetMostSoldProductAsync();
        }
        [HttpGet("NewestDiscountProduct")]
        public async Task<ICollection<ProductReadDTO>> GetAllNewestDiscountProduct()
        {
            return await _productService.GetNewestDiscountedProductsAsync();
        }
        [HttpGet("NewestProduct")]
        public async Task<ICollection<ProductReadDTO>> GetNewestProduct()
        {
            return await _productService.GetMostSoldProductAsync();
        }
        [HttpGet("DiscountProduct")]
        public async Task<ICollection<ProductReadDTO>> GetAllDiscountProduct()
        {
            return await _productService.GetAllDiscountProductAsync();
        }
        [HttpGet("FilterPriceProduct")]
        public async Task<ICollection<ProductReadDTO>> GetAllProductFilteredPrice(int minPrice, int maxPrice)
        {
            return await _productService.GetFilteredPrice(minPrice, maxPrice);
        }
        [HttpGet("Deleted")]
        public async Task<ICollection<ProductReadDTO>> GetAllDeleted()
        {
            return await _productService.GetAllDeletedAsync();
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] ProductCreateDTO productCreateDTO)
        {
            try
            {
                return StatusCode(StatusCodes.Status201Created, await _productService.CreateAsync(productCreateDTO));

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);

            }
        }
            [HttpPut("{id}")]
            public async Task<IActionResult> Update(int id, [FromForm]  ProductUpdateDTO productUpdateDTO)
            {
                try
                {
                    return StatusCode(StatusCodes.Status200OK, await _productService.UpdateAsync(id,productUpdateDTO));
                }
                catch (Exception ex)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
                }
            }
        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            try
            {
                return StatusCode(StatusCodes.Status200OK, await _productService.GetByIdAsync(id));
            }

            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }

        }
        [HttpGet("Search")]
        public async Task<IActionResult> Search(string searchword)
        {
            try
            {
                return StatusCode(StatusCodes.Status200OK, await _productService.SearchProductsAsync(searchword));

            }

            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }
        }
        //PAGINATION
        [HttpGet("Paginated")]
        public async Task<IActionResult> GetPaginated([FromQuery] PaginationParams @params)
        {
            var result = await _productService.GetPaginatedAsync(@params);
            return Ok(result);
        }


        [HttpDelete("{id}Soft")]
        public async Task<IActionResult> SoftDelete(int id)
        {
            try
            {
                return StatusCode(StatusCodes.Status200OK, await _productService.SoftDeleteAsync(id));

            }

            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }
        }
        [HttpPut("{id}Restore")]
        public async Task<IActionResult> Restore(int id)
        {
            try
            {
                return StatusCode(StatusCodes.Status200OK, await _productService.RestoreAsync(id));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }
        }
        [HttpDelete("{id}Hard")]
        public async Task<IActionResult> HardDelete(int id)
        {
            try
            {
                return StatusCode(StatusCodes.Status200OK, await _productService.HardDeleteAsync(id));
            }

            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }
        }
       


    }
}
