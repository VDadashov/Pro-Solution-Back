using ProSolution.Core.Entities;
using ProSolution.DAL.Contexts;
using ProSolution.DAL.Repositories.Abstractions.Slider;

namespace ProSolution.DAL.Repositories.Implementations
{
    public class SliderWriteRepository : WriteRepository<Slider>, ISliderWriteRepository
    {
        public SliderWriteRepository(AppDbContext context) : base(context)
        {
        }
    }
}
