using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ProSolution.BL.Services.InternalServices.Abstractions
{
    public interface IRoleCheckerService
    {
        bool IsInRole(ClaimsPrincipal user, string role);
        bool HasAnyRole(ClaimsPrincipal user, params string[] roles);
    }

}
