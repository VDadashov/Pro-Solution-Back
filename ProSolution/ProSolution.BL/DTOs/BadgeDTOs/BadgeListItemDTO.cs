using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProSolution.BL.DTOs.BadgeDTOs
{
    public class BadgeListItemDTO
    {
        public int Id { get; set; } 
        public string? Description { get; set; }
        public string ImageUrl { get; set; }
        public bool IsSertificate { get; set; }
    }
}
