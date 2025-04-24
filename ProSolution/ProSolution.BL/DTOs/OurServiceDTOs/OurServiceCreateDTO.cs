using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProSolution.BL.DTOs.ServiceDTOs
{
    public class OurServiceCreateDTO
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public IFormFile Image { get; set; }

        public string ContentTitle { get; set; }
        public string ContentDescription { get; set; }

        public IFormFile ContentImage { get; set; }
    }
}
