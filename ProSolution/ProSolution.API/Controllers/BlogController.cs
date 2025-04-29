using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProSolution.BL.DTOs.BLogDTOs;
using ProSolution.BL.DTOs.PartnerDTO;
using ProSolution.BL.DTOs.PartnerDTOs;
using ProSolution.BL.Services.InternalServices.Abstractions;
using ProSolution.BL.Services.InternalServices.Implementations;
using ProSolution.Core.Entities;
using ProSolution.Core.Enums;

namespace ProSolution.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly IBlogService _blogService;

        public BlogController(IBlogService blogService)
        {
            _blogService = blogService;
        }

        [HttpGet]
        public async Task<ICollection<BlogReadDTO>> GetAll()
        {
            return await _blogService.GetAllAsync();
        }
        [HttpGet("Deleted")]
        public async Task<ICollection<Blog>> GetAllDeleted()
        {
            return await _blogService.GetAllDeletedAsync();
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] BlogCreateDTO catagoryDto)
        {
            try
            {
                return StatusCode(StatusCodes.Status201Created, await _blogService.CreateAsync(catagoryDto));

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);

            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                return StatusCode(StatusCodes.Status200OK, await _blogService.GetByIdAsync(id));

            }

            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }
        }
        [HttpDelete("{id}Soft")]
        public async Task<IActionResult> SoftDelete(int id)
        {
            try
            {
                return StatusCode(StatusCodes.Status200OK, await _blogService.SoftDeleteAsync(id));

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
                return StatusCode(StatusCodes.Status200OK, await _blogService.HardDeleteAsync(id));
            }

            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, BlogUpdateDTO catagoryDto)
        {
            try
            {
                return StatusCode(StatusCodes.Status200OK, await _blogService.UpdateAsync(id, catagoryDto));
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
                return StatusCode(StatusCodes.Status200OK, await _blogService.RestoreAsync(id));
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
            var result = await _blogService.GetPaginatedAsync(@params);
            return Ok(result);
        }

    }
}
