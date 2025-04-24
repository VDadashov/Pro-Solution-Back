using AutoMapper;
using ProSolution.BL.DTOs.SliderDTO;
using ProSolution.BL.Services.ExternalServices;
using ProSolution.BL.Services.InternalServices.Abstractions;
using ProSolution.Core.Entities;
using ProSolution.DAL.Repositories.Abstractions.Slider;

namespace ProSolution.BL.Services.InternalServices.Implementations
{
    public class SliderService : ISliderService
    {
        private readonly ISliderReadRepository _sliderReadRepository;
        private readonly ISliderWriteRepository _sliderWriteRepository;
        private readonly IMapper _mapper;

        public SliderService(IMapper mapper, ISliderWriteRepository sliderWriteRepository, ISliderReadRepository sliderReadRepository)
        {
            _mapper = mapper;
            _sliderWriteRepository = sliderWriteRepository;
            _sliderReadRepository = sliderReadRepository;
        }

        public async Task<Slider> CreateAsync(SliderCreateDTO sliderCreateDTO)
        {

            if (sliderCreateDTO.ImagePath == null || !sliderCreateDTO.ImagePath.IsValidFile())
            {
                throw new Exception("Invalid file type or size");
            }
            Slider slider = _mapper.Map<Slider>(sliderCreateDTO);
            slider.ImagePath = await sliderCreateDTO.ImagePath.SaveAsync("Sliders");
            slider.CreateAt = DateTime.UtcNow.AddHours(4);
            var res = await _sliderWriteRepository.CreateAsync(slider);
            await _sliderWriteRepository.SaveChangeAsync();
            return res;
        }

        public async Task<ICollection<Slider>> GetAllAsync()
        {
            return await _sliderReadRepository.GetAllAsync(false);

        }

        public async Task<ICollection<Slider>> GetAllDeletedAsync()
        {
            return await _sliderReadRepository.GetAllAsync(true);
        }

        public async Task<Slider> GetByIdAsync(int id)
        {
            Slider slider = await _sliderReadRepository.GetByIdAsync(id, false);
            if (slider is null)
            {
                throw new Exception("Bu Id ye uygun deyer tapilmadi");
            }
            return slider;
        }

        public async Task<Slider> HardDeleteAsync(int id)
        {
            Slider catagory = await _sliderReadRepository.GetByIdAsync(id, true);
            if (catagory is null)
            {
                throw new Exception("Bu Id-e uygun deyer tapilmadi");
            }
            var res = _sliderWriteRepository.HardDelete(catagory);
            await _sliderWriteRepository.SaveChangeAsync();
            return res;
        }

        public async Task<Slider> RestoreAsync(int id)
        {
            Slider catagory = await _sliderReadRepository.GetByIdAsync(id, true);
            if (catagory is null)
            {
                throw new Exception("Bu Id ye uygun deyer tapilmadi");
            }
            var res = _sliderWriteRepository.Restore(catagory);
            await _sliderWriteRepository.SaveChangeAsync();
            return res;
        }

        public async Task<Slider> SoftDeleteAsync(int id)
        {
            Slider catagory = await _sliderReadRepository.GetByIdAsync(id, true);
            if (catagory is null)
            {
                throw new Exception("Bu Id ye uygun deyer tapilmadi");
            }
            var res = _sliderWriteRepository.SoftDelete(catagory);
            await _sliderWriteRepository.SaveChangeAsync();
            return res;
        }

        public async Task<Slider> UpdateAsync(int id, SliderCreateDTO sliderCreateDTO)
        {
            Slider oldProduct = await _sliderReadRepository.GetByIdAsync(id, true);
            if (oldProduct == null)
            {
                throw new Exception("Bu Id-e uygun mehsul tapilmadi.");
            }
            Slider product = _mapper.Map(sliderCreateDTO, oldProduct);
            product.UpdateAt = DateTime.UtcNow.AddHours(4);
            product.Id = oldProduct.Id;
            product.CreateAt = oldProduct.CreateAt;

            if (sliderCreateDTO.ImagePath != null)
            {
                product.ImagePath = await sliderCreateDTO.ImagePath.SaveAsync("Sliders");
            }
            else
            {
                product.ImagePath = oldProduct.ImagePath;
            }
            Slider product1 = _sliderWriteRepository.Update(product);
            if (sliderCreateDTO.ImagePath != null)
            {
                File.Delete(Path.Combine(Path.GetFullPath("Resource"), "ImageUpload", "Sliders", oldProduct.ImagePath));
            }
            await _sliderWriteRepository.SaveChangeAsync();
            return product1;
        }
    }
}

