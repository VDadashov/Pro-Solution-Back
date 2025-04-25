using AutoMapper;
using ProSolution.BL.DTOs.AboutDTOs;
using ProSolution.BL.DTOs.BadgeDTOs;
using ProSolution.BL.DTOs.ServiceDTOs;
using ProSolution.BL.Services.ExternalServices;
using ProSolution.BL.Services.InternalServices.Abstractions;
using ProSolution.Core.Entities;
using ProSolution.DAL.Repositories.Abstractions.IAbourRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ProSolution.BL.Services.InternalServices.Implementations
{
    public class AboutService(IAboutReadRepository _aboutReadRepository, IAboutWriteRepository _aboutWriteRepository,IMapper _mapper) : IAboutService
    {


        public async Task<AboutDetailDTO> GetAsync()
        {
            var about = await _aboutReadRepository.GetAllAsync(false);
            var single = about.FirstOrDefault();

            if (single == null)
                throw new Exception("Haqqında məlumat tapılmadı.");

            return _mapper.Map<AboutDetailDTO>(single);
        }

        public async Task<About> UpdateAsync(AboutUpdateDTO updateDTO)
        {
          
            var about = (await _aboutReadRepository.GetAllAsync(false)).FirstOrDefault();

            if (about == null)
                throw new Exception("Haqqında məlumat tapılmadı.");

            _mapper.Map(updateDTO, about);

            if (updateDTO.Image is not null)
            {
                about.ImagePath = await updateDTO.Image.SaveAsync("AboutImg");
            }

            await _aboutWriteRepository.SaveChangeAsync();
            return about;
        }
    }

}
