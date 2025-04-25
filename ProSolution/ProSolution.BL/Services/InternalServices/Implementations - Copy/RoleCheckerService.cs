using ProSolution.BL.Services.InternalServices.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ProSolution.BL.Services.InternalServices.Implementations
{
    public class RoleCheckerService : IRoleCheckerService
    {
        public bool IsInRole(ClaimsPrincipal user, string role)
        {
            return user.IsInRole(role);
        }

        public bool HasAnyRole(ClaimsPrincipal user, params string[] roles)
        {
            return roles.Any(role => user.IsInRole(role));
        }
    }
}
