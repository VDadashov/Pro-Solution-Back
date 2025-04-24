using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProSolution.BL.DTOs.BadgeDTOs;
using ProSolution.BL.DTOs.ServiceDTOs;
using ProSolution.BL.Services.InternalServices.Abstractions;
using ProSolution.BL.Services.InternalServices.Implementations;

namespace ProSolution.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BadgeController(IBadgeService _badgeService ) : ControllerBase
    {
        [HttpGet]
        public async Task<ICollection<BadgeListItemDTO>> GetAll()
        {
            return await _badgeService.GetAllAsync();
        }
        [HttpGet("Deleted")]
        public async Task<ICollection<BadgeListItemDTO>> GetAllDeleted()
        {
            return await _badgeService.GetAllDeletedAsync();
        }


       
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] BadgeCreateDTO CreateDTO)
        {
            try
            {
                return StatusCode(StatusCodes.Status201Created, await _badgeService.CreateAsync(CreateDTO));

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);

            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromForm] BadgeUpdateDTO updateDTO)
        {
            try
            {
                return Ok(await _badgeService.UpdateAsync(id, updateDTO));
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
                return Ok(await _badgeService.SoftDeleteAsync(id));
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
                return Ok(await _badgeService.RestoreAsync(id));
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
                return Ok(await _badgeService.HardDeleteAsync(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
