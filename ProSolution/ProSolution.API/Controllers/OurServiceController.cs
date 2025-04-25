using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProSolution.BL.DTOs;
using ProSolution.BL.DTOs.ServiceDTOs;
using ProSolution.BL.Services.InternalServices.Abstractions;
using ProSolution.BL.Services.InternalServices.Implementations;
using ProSolution.Core.Enums;

namespace ProSolution.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OurServiceController(IOurServiceService _ourServiceService) : ControllerBase
    {
        [HttpGet]
        public async Task<ICollection<OurServiceListItemDTO>> GetAll()
        {
            return await _ourServiceService.GetAllAsync();
        }
        [HttpGet("Deleted")]
        public async Task<ICollection<OurServiceListItemDTO>> GetAllDeleted()
        {
            return await _ourServiceService.GetAllDeletedAsync();
        }   

              
        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            try
            {
                return StatusCode(StatusCodes.Status200OK, await _ourServiceService.GetByIdAsync(id));
            }

            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }

        }
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] OurServiceCreateDTO CreateDTO)
        {
            try
            {
                return StatusCode(StatusCodes.Status201Created, await _ourServiceService.CreateAsync(CreateDTO));

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);

            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromForm] OurServiceUpdateDTO updateDTO)
        {
            try
            {
                return Ok(await _ourServiceService.UpdateAsync(id, updateDTO));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPatch("soft-delete/{id}")]
        public async Task<IActionResult> SoftDelete(int id)
        {
            try
            {
                return Ok(await _ourServiceService.SoftDeleteAsync(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPatch("restore/{id}")]
        public async Task<IActionResult> Restore(int id)
        {
            try
            {
                return Ok(await _ourServiceService.RestoreAsync(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> HardDelete(int id)
        {
            try
            {
                return Ok(await _ourServiceService.HardDeleteAsync(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("Search")]
        public async Task<IActionResult> Search(string searchword)
        {
            try
            {
                return StatusCode(StatusCodes.Status200OK, await _ourServiceService.SearchServicestsAsync(searchword));

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
            var result = await _ourServiceService.GetPaginatedAsync(@params);
            return Ok(result);
        }


    }
}
