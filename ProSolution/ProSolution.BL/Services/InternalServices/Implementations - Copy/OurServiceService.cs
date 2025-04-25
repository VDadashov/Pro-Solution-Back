using AutoMapper;
using ProSolution.BL.DTOs;
using ProSolution.BL.DTOs.ServiceDTOs;
using ProSolution.BL.Services.ExternalServices;
using ProSolution.BL.Services.InternalServices.Abstractions;
using ProSolution.Core.Entities;
using ProSolution.DAL.Repositories.Abstractions.Service;


namespace ProSolution.BL.Services.InternalServices.Implementations
{
    public class OurServiceService(IOurServiceReadRepository _ourSeriviceReadRepository,IOurServiceWriteRepository _ourServiceWriteRepository,IMapper _mapper) : IOurServiceService
    {
        public async Task<ICollection<OurServiceListItemDTO>> GetAllAsync()
        {
            var services = await _ourSeriviceReadRepository.GetAllAsync(false);
            return _mapper.Map<ICollection<OurServiceListItemDTO>>(services);
        }
        public async Task<ICollection<OurServiceListItemDTO>> GetAllDeletedAsync()
        {
            var services = await _ourSeriviceReadRepository.GetAllAsync(true);
            return _mapper.Map<ICollection<OurServiceListItemDTO>>(services);
        }
        public async Task<OurServiceDetailDTO> GetByIdAsync(int id)
        {
            OurService ourService = await _ourSeriviceReadRepository.GetByIdAsync(id, false);
            if (ourService is null)
            {
                throw new Exception("Bu Id-e uygun deyer tapilmadi");
            }

            var dto = _mapper.Map<OurServiceDetailDTO>(ourService);
            return dto;
        }

        public async Task<OurService> CreateAsync(OurServiceCreateDTO createDTO)
        {
            if (createDTO.Image == null )
            {
                throw new Exception("nott null");
            }
            if ( !createDTO.Image.IsValidFile())
            {
                throw new Exception("invalid file type or size");
            }
            OurService ourService = _mapper.Map<OurService>(createDTO);
            ourService.ImagePath = await createDTO.Image.SaveAsync("OurServiceImages");
            ourService.ContentPath = await createDTO.ContentImage.SaveAsync("OurServiceImages");
            ourService.CreateAt = DateTime.UtcNow.AddHours(4);
            var our= await _ourServiceWriteRepository.CreateAsync(ourService);
            await _ourServiceWriteRepository.SaveChangeAsync();
            return our;
        }

        public async Task<OurService> HardDeleteAsync(int id)
        {
            var service = await _ourSeriviceReadRepository.GetByIdAsync(id, true);
            if (service == null)
                throw new Exception("Service tapilmadi");

            _ourServiceWriteRepository.HardDelete(service);
            await _ourServiceWriteRepository.SaveChangeAsync();
            return service;
        }


        public async Task<OurService> RestoreAsync(int id)
        {
            var service = await _ourSeriviceReadRepository.GetByIdAsync(id, true);
            if (service == null)
                throw new Exception("Service tapilmadi");

            service.IsDeleted = false;
            await _ourServiceWriteRepository.SaveChangeAsync();
            return service;
        }


        public async Task<OurService> SoftDeleteAsync(int id)
        {
            var service = await _ourSeriviceReadRepository.GetByIdAsync(id, true);
            if (service == null)
                throw new Exception("Service tapilmadi");

            service.IsDeleted = true;
            await _ourServiceWriteRepository.SaveChangeAsync();
            return service;
        }


        public async Task<OurService> UpdateAsync(int id, OurServiceUpdateDTO updateDTO)
        {
            var service = await _ourSeriviceReadRepository.GetByIdAsync(id, true);
            if (service == null)
                throw new Exception("Service tapilmadi");

            _mapper.Map(updateDTO, service);

            if (updateDTO.Image is not null)
            {
                service.ImagePath = await updateDTO.Image.SaveAsync("OurServiceImages");
            }

            if (updateDTO.ContentImage is not null)
            {
                service.ContentPath = await updateDTO.ContentImage.SaveAsync("OurServiceImages");
            }

            await _ourServiceWriteRepository.SaveChangeAsync();
            return service;
        }
        public async Task<ICollection<OurServiceListItemDTO>> SearchServicestsAsync(string search)
        {
            var query = await _ourSeriviceReadRepository.GetAllAsync(false);

            if (!string.IsNullOrEmpty(search))
            {
                query = query
                    .Where(p => p.Title.Contains(search, StringComparison.OrdinalIgnoreCase) ||
                                p.Description.Contains(search, StringComparison.OrdinalIgnoreCase) ||
                                p.ContentTitle.Contains(search, StringComparison.OrdinalIgnoreCase) ||
                                p.ContentDescription.Contains(search, StringComparison.OrdinalIgnoreCase) 
                                ) 
                                

                    .ToList();
            }
            var result = _mapper.Map<ICollection<OurServiceListItemDTO>>(query);
            return result;
        }

    }
}
