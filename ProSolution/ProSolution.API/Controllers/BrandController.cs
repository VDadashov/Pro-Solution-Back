using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProSolution.BL.DTOs.BrandDTO;
using ProSolution.BL.DTOs.BrandDTOs;
using ProSolution.BL.DTOs.CatagoryDTOs;
using ProSolution.BL.DTOs.PartnerDTO;
using ProSolution.BL.Services.InternalServices.Abstractions;
using ProSolution.BL.Services.InternalServices.Implementations;
using ProSolution.Core.Entities;

namespace ProSolution.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly IBrandService _brandService;

        public BrandController(IBrandService brandService)
        {
            _brandService = brandService;
        }

        [HttpGet]
        public async Task<ICollection<Brand>> GetAll()
        {
            return await _brandService.GetAllAsync();
        }
        [HttpGet("Deleted")]
        public async Task<ICollection<Brand>> GetAllDeleted()
        {
            return await _brandService.GetAllDeletedAsync();
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] BrandCreateDTO catagoryDto)
        {

            return StatusCode(StatusCodes.Status201Created, await _brandService.CreateAsync(catagoryDto));






        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {

            return StatusCode(StatusCodes.Status200OK, await _brandService.GetByIdAsync(id));




        }
        [HttpDelete("{id}Soft")]
        public async Task<IActionResult> SoftDelete(int id)
        {

            return StatusCode(StatusCodes.Status200OK, await _brandService.SoftDeleteAsync(id));




        }
        [HttpDelete("{id}Hard")]
        public async Task<IActionResult> HardDelete(int id)
        {

            return StatusCode(StatusCodes.Status200OK, await _brandService.HardDeleteAsync(id));



        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, BrandDTO catagoryDto)
        {

            try
            {
                return StatusCode(StatusCodes.Status200OK, await _brandService.UpdateAsync(id, catagoryDto));

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
                return StatusCode(StatusCodes.Status200OK, await _brandService.RestoreAsync(id));

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }
        }
    }
}