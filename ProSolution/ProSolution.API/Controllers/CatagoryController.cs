using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProSolution.BL.DTOs.CatagoryDTOs;
using ProSolution.BL.Services.InternalServices.Abstractions;
using ProSolution.Core.Entities;
using ProSolution.Core.Enums;

namespace ProSolution.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatagoryController : ControllerBase
    {
        private readonly ICatagoryService _catagoryService;

        public CatagoryController(ICatagoryService catagoryService)
        {
            _catagoryService = catagoryService;
        }

        [HttpGet]
        public async Task<ICollection<Catagory>> GetAll()
        {
            return await _catagoryService.GetAllAsync();
        }
        //PAGINATION
        [HttpGet("Paginated")]
        public async Task<IActionResult> GetPaginated([FromQuery] PaginationParams @params)
        {
            var result = await _catagoryService.GetPaginatedAsync(@params);
            return Ok(result);
        }


        [HttpGet("Deleted")]
        public async Task<ICollection<Catagory>> GetAllDeleted()
        {
            return await _catagoryService.GetAllDeletedAsync();
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CatagoryDTO catagoryDto)
        {
            try
            {
                return StatusCode(StatusCodes.Status201Created, await _catagoryService.CreateAsync(catagoryDto));

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
                return StatusCode(StatusCodes.Status200OK, await _catagoryService.GetByIdAsync(id));

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
                return StatusCode(StatusCodes.Status200OK, await _catagoryService.SoftDeleteAsync(id));

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
                return StatusCode(StatusCodes.Status200OK, await _catagoryService.HardDeleteAsync(id));
            }

            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, CatagoryDTO catagoryDto)
        {
            try
            {
                return StatusCode(StatusCodes.Status200OK, await _catagoryService.UpdateAsync(id, catagoryDto));
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
                return StatusCode(StatusCodes.Status200OK, await _catagoryService.RestoreAsync(id));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }
        }
    }
}
