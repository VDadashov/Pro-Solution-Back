using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProSolution.BL.DTOs;
using ProSolution.BL.DTOs.AuthDTOs;
using ProSolution.BL.Services.InternalServices.Abstractions;
using ProSolution.Core.Entities;
using System.Security.Claims;

namespace ProSolution.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IRoleCheckerService _roleChecker;
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService, IRoleCheckerService roleChecker)
        {
            _authService = authService;
            _roleChecker = roleChecker;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                await _authService.RegisterAsync(dto);
                return Ok(new { message = "Registration successful" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var token = await _authService.LoginAsync(dto);
                return Ok(new { token });
            }
            catch (Exception ex)
            {
                return Unauthorized(new { error = ex.Message });
            }
        }

        [HttpGet("check-authorize")]
        [Authorize]
        public IActionResult IsAuthorized()
        {
            return Ok(new { message = "Your account successfully authorized." });
        }



        [HttpGet("check-role")]
        [Authorize]
        public IActionResult CheckUserRole()
        {
            if (_roleChecker.IsInRole(User, "Admin"))
                return Ok(new { message = "You are Admin!" });

            if (_roleChecker.IsInRole(User, "User"))
                return Ok(new { message = "You are just User" });

            if (_roleChecker.IsInRole(User, "SuperAdmin"))
                return Ok(new { message = "You are just SuperAdmin" });

            return StatusCode(403, new { message = "Role not recognized." });
        }


        [HttpDelete("delete")]
        [Authorize]
        public async Task<IActionResult> DeleteAccount()
        {
            try
            {
                await _authService.DeleteCurrentUserAsync(User);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpPost("forgot-password")]
        public async Task<IActionResult> ForgotPassword([FromBody] string email)
        {
            try
            {
                await _authService.SendResetPasswordEmailAsync(email);
                return Ok(new { message = "Password reset link sent." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPassword([FromForm] ResetPasswordDTO dto)
        {
            try
            {
                await _authService.ResetPasswordAsync(dto);
                return Ok(new { message = "Password succesfully updated" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }



    }

}


