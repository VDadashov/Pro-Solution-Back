using ProSolution.BL.DTOs.AuthDTOs;
using ProSolution.BL.DTOs.AuthDTOs.ProSolution.BL.DTOs.AuthDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ProSolution.BL.Services.InternalServices.Abstractions
{
    public interface IAuthService
    {
        Task RegisterAsync(RegisterDTO dto);
        Task<LoginResponseDTO> LoginAsync(LoginDTO dto); 
        Task DeleteCurrentUserAsync(ClaimsPrincipal userClaims);
        Task LogoutAsync(ClaimsPrincipal userClaims);
        Task SendResetPasswordEmailAsync(string email);
        Task ResetPasswordAsync(ResetPasswordDTO dto);

    }
}
