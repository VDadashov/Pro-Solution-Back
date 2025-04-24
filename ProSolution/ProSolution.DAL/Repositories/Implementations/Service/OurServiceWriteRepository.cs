using ProSolution.Core.Entities;
using ProSolution.DAL.Contexts;
using ProSolution.DAL.Repositories.Abstractions;
using ProSolution.DAL.Repositories.Abstractions.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProSolution.DAL.Repositories.Implementations.Service
{
    public class OurServiceWriteRepository : WriteRepository<OurService>, IOurServiceWriteRepository
    {
        public OurServiceWriteRepository(AppDbContext context) : base(context)
        {
        }
       
    }
 
    
}
