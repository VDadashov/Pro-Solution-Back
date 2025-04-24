using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProSolution.BL.DTOs.ContactMessageDTOs;
using ProSolution.BL.Services.InternalServices.Abstractions;
using ProSolution.BL.Services.InternalServices.Implementations;

namespace ProSolution.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactUsController(IEmailService _emailService) : ControllerBase
    {

        [HttpPost("contact")]
        public async Task<IActionResult> SendContactMessage([FromBody] ContactMessageDTO dto)
        {
            try
            {
                await _emailService.SendContactMessageAsync(dto);
                return Ok("Mesaj uğurla göndərildi.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
