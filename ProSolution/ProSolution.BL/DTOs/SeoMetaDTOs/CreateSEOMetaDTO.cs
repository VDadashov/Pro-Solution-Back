using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProSolution.Business.DTOs.SEODTOs
{
    public class CreateSEOMetaDTO
    {
        public string? MetaDescription { get; set; }
        public string? MetaTitle { get; set; }
        
        public string MetaTags { get; set; }
   
    }
}
