
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProSolution.Core.Entities
{
    public class SeoData : BaseEntity
    {
        public string? AltText { get; set; }
        public string? AnchorText { get; set; }

      
    }
    public class SeoUrl : BaseEntity
    {

        public string? Url { get; set; }
        public string? RedirectUrl { get; set; }
     
      
      
    }
    public class SeoMeta : BaseEntity
    {
        public string? MetaDescription { get; set; }
        public string? MetaTitle { get; set; }
        public string? MetaTags { get; set; }

       
    }

}
