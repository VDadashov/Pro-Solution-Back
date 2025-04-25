using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ProSolution.BL.DTOs.AuthDTOs;
using ProSolution.BL.Services.InternalServices.Abstractions;
using ProSolution.Core.Entities;
using System.Text;
using ProSolution.BL.Helpers;
using System.Security.Cryptography;
using ProSolution.BL.DTOs.AuthDTOs.ProSolution.BL.DTOs.AuthDTOs;
using System.Net.Mail;
using System.Net;
using ProSolution.BL.Settings;
using Microsoft.Extensions.Options;

namespace ProSolution.BL.Services.InternalServices.Implementations
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _configuration;
        private readonly SmtpSettings _smtpSettings;


        public AuthService(UserManager<User> userManager, IConfiguration configuration, IOptions<SmtpSettings> smtpOptions)
        {
            _userManager = userManager;
            _configuration = configuration;
            _smtpSettings = smtpOptions.Value;
        }

        public async Task RegisterAsync(RegisterDTO dto)
        {
            var user = new User
            {
                UserName = dto.UserName,
                Email = dto.Email,
                FirstName = dto.FirstName,
                LastName = dto.LastName

            };

            var result = await _userManager.CreateAsync(user, dto.Password);

            if (!result.Succeeded)
            {
                var errors = string.Join(", ", result.Errors.Select(e => e.Description));
                throw new Exception($"Registration failed: {errors}");
            }

            await _userManager.AddToRoleAsync(user, "User");
        }

        public async Task<LoginResponseDTO> LoginAsync(LoginDTO dto)
        {
            try
            {
                var user = await _userManager.FindByNameAsync(dto.UserName);
                if (user == null)
                    throw new Exception("User not found");

                var isPasswordValid = await _userManager.CheckPasswordAsync(user, dto.Password);
                if (!isPasswordValid)
                    throw new Exception("Invalid credentials");

                var role = (await _userManager.GetRolesAsync(user)).FirstOrDefault();

                user.RefreshToken = GenerateRefreshToken();
                user.RefreshTokenExpireAt = DateTime.UtcNow.AddDays(7);

                var result = await _userManager.UpdateAsync(user);
                if (!result.Succeeded)
                {
                    var errors = string.Join(", ", result.Errors.Select(e => e.Description));
                    throw new Exception($"Update failed: {errors}");
                }

                var accessToken = JwtTokenGenerator.GenerateToken(user, role, _configuration);

                return new LoginResponseDTO
                {
                    AccessToken = accessToken,
                    RefreshToken = user.RefreshToken,
                    RefreshTokenExpireAt = user.RefreshTokenExpireAt.Value
                };
            }
            catch (Exception ex)
            {
                throw new Exception($"Login failed: {ex.Message} | {ex.InnerException?.Message}");
            }
        }

        public async Task<string?> GetUserRoleAsync(User user)
        {
            var roles = await _userManager.GetRolesAsync(user);
            return roles.FirstOrDefault();
        }



        public async Task DeleteCurrentUserAsync(ClaimsPrincipal userClaims)
        {
            var userId = userClaims.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userId))
                throw new Exception("User ID not found in token");

            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
                throw new Exception("User not found");

            var result = await _userManager.DeleteAsync(user);
            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(e => e.Description);
                throw new Exception($"Failed to delete user: {string.Join(", ", errors)}");
            }
        }

        public async Task LogoutAsync(ClaimsPrincipal userClaims)
        {
            var userId = userClaims.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var user = await _userManager.FindByIdAsync(userId);

            if (user == null)
                throw new Exception("User not found");

            user.RefreshToken = null;
            user.RefreshTokenExpireAt = null;

            await _userManager.UpdateAsync(user);
        }

        private string GenerateRefreshToken()
        {
            var randomBytes = new byte[64];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomBytes);
                return Convert.ToBase64String(randomBytes);
            }
        }

        public async Task SendResetPasswordEmailAsync(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
                throw new Exception("User not found");

            var token = await _userManager.GeneratePasswordResetTokenAsync(user);

            var resetLink = $"https://your-frontend-site.com/reset-password?token={Uri.EscapeDataString(token)}&email={Uri.EscapeDataString(email)}";

            var subject = "Reset password";
            var body = $@"
You can update your password by clicking on the link below:
{resetLink}

If the link doesn't work, copy this token manually and paste it in the reset form:

TOKEN: 
{token}
";

            using var smtp = new SmtpClient(_smtpSettings.Host, _smtpSettings.Port)
            {
                Credentials = new NetworkCredential(_smtpSettings.Username, _smtpSettings.Password),
                EnableSsl = _smtpSettings.EnableSSL
            };

            var message = new MailMessage(_smtpSettings.Username, email, subject, body);
            message.IsBodyHtml = false; // Plain text mesaj olaraq qalsın

            await smtp.SendMailAsync(message);
        }


        public async Task ResetPasswordAsync(ResetPasswordDTO dto)
        {
            if (dto.NewPassword != dto.ConfirmPassword)
                throw new Exception("Passwords do not match");

            var user = await _userManager.FindByEmailAsync(dto.Email);
            if (user == null)
                throw new Exception("User not found");

            var result = await _userManager.ResetPasswordAsync(user, dto.Token, dto.NewPassword);
            if (!result.Succeeded)
            {
                var errors = string.Join(", ", result.Errors.Select(e => e.Description));
                throw new Exception($"Password reset failed: {errors}");
            }
        }
    }
}

