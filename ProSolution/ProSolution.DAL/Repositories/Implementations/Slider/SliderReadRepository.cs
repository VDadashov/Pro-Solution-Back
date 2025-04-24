using ProSolution.Core.Entities;
using ProSolution.DAL.Contexts;
using ProSolution.DAL.Repositories.Abstractions.Slider;

namespace ProSolution.DAL.Repositories.Implementations
{
    public class SliderReadRepository :  ReadRepository<Slider> , ISliderReadRepository
    {
        public SliderReadRepository(AppDbContext context) : base(context)
        {
        }
    }
    
}
