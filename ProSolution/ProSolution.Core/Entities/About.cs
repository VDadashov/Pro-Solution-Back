﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProSolution.Core.Entities
{
    public class About : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string? ImagePath { get; set; }
    }
}
