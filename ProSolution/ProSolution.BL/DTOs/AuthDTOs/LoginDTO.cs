using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProSolution.BL.DTOs.AuthDTOs
{
    public class LoginDTO
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }

    namespace ProSolution.BL.DTOs.AuthDTOs
    {
        public class LoginResponseDTO
        {
            public string AccessToken { get; set; }
            public string RefreshToken { get; set; }
            public DateTime RefreshTokenExpireAt { get; set; }
        }
    }


}
