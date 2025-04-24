using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProSolution.BL.DTOs.ServiceDTOs
{
    public class OurServiceDetailDTO
    {
        public int id { get; set; }
        public string ContentTitle { get; set; }
        public string ContentDescription { get; set; }

        public string ContentPath { get; set; }
    }
}
