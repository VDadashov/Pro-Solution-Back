using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ProSolution.BL.DTOs.ServiceDTOs
{
    public class OurServiceUpdateDTO
    {
 
        public string Title { get; set; }
        public string Description { get; set; }
       
        public IFormFile? Image { get; set; }
        public string ContentTitle { get; set; }
        public string ContentDescription { get; set; }

       
        public DateTime? UpdateAt { get; set; }= DateTime.UtcNow;
        public IFormFile? ContentImage { get; set; }
    }
}
