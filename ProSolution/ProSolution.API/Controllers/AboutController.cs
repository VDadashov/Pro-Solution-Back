using Microsoft.AspNetCore.Mvc;
using ProSolution.BL.DTOs.AboutDTOs;
using ProSolution.BL.Services.InternalServices.Abstractions;
using ProSolution.BL.Services.InternalServices.Implementations;
using System.Threading.Tasks;

namespace ProSolution.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutController(IAboutService _aboutService ) : ControllerBase
    {
       

        // GET: api/About
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var about = await _aboutService.GetAsync();
            return Ok(about);
        }

        // PUT: api/About
        [HttpPut]
        public async Task<IActionResult> Update([FromForm] AboutUpdateDTO updateDTO)
        {
            var updated = await _aboutService.UpdateAsync(updateDTO);
            return Ok(updated);
        }
    }
}
