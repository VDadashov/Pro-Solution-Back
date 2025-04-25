using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProSolution.BL.DTOs.BadgeDTOs
{
    public class BadgeCreateDTO
    {
        public string? Description { get; set; }
        public IFormFile? Image { get; set; }
        public bool IsSertificate { get; set; }
    }
}
