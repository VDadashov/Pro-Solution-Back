using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProSolution.BL.DTOs.PartnerDTO;
using ProSolution.BL.DTOs.SliderDTO;
using ProSolution.BL.Services.InternalServices.Abstractions;
using ProSolution.Core.Entities;

namespace ProSolution.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PartnerController : ControllerBase
    {
        private readonly IPartnerService _partnerService;

        public PartnerController(IPartnerService partnerService)
        {
            _partnerService = partnerService;
        }

        [HttpGet]
        public async Task<ICollection<Partner>> GetAll()
        {
            return await _partnerService.GetAllAsync();
        }
        [HttpGet("Deleted")]
        public async Task<ICollection<Partner>> GetAllDeleted()
        {
            return await _partnerService.GetAllDeletedAsync();
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] PartnerDTO catagoryDto)
        {
            try
            {
                return StatusCode(StatusCodes.Status201Created, await _partnerService.CreateAsync(catagoryDto));

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
                return StatusCode(StatusCodes.Status200OK, await _partnerService.GetByIdAsync(id));

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
                return StatusCode(StatusCodes.Status200OK, await _partnerService.SoftDeleteAsync(id));

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
                return StatusCode(StatusCodes.Status200OK, await _partnerService.HardDeleteAsync(id));
            }

            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, PartnerDTO catagoryDto)
        {
            try
            {
                return StatusCode(StatusCodes.Status200OK, await _partnerService.UpdateAsync(id, catagoryDto));
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
                return StatusCode(StatusCodes.Status200OK, await _partnerService.RestoreAsync(id));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }
        }
    }
}
