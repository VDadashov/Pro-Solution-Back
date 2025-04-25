using AutoMapper;
using ProSolution.BL.DTOs.BadgeDTOs;
using ProSolution.BL.Services.ExternalServices;
using ProSolution.BL.Services.InternalServices.Abstractions;
using ProSolution.Core.Entities;
using ProSolution.DAL.Repositories.Abstractions.IBadgeRepo;
using ProSolution.DAL.Repositories.Abstractions.Service;
using ProSolution.DAL.Repositories.Implementations.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProSolution.BL.Services.InternalServices.Implementations
{
    public class BadgeService(IBadgeReadRepository _badgeReadRepository, IBadgeWriteRepository _badgeWriteRepository, IMapper _mapper) : IBadgeService
    {
        public async Task<Badge> CreateAsync(BadgeCreateDTO createDTO)
        {
            if (createDTO.Image == null)
            {
                throw new Exception("nott null");
            }
            if (!createDTO.Image.IsValidFile())
            {
                throw new Exception("invalid file type or size");
            }
            Badge badge = _mapper.Map<Badge>(createDTO);
            badge.ImageUrl = await createDTO.Image.SaveAsync("badgeImg");
           
            badge.CreateAt = DateTime.UtcNow.AddHours(4);
            var our = await _badgeWriteRepository.CreateAsync(badge);
            await _badgeWriteRepository.SaveChangeAsync();
            return our;
        }

        public async Task<ICollection<BadgeListItemDTO>> GetAllAsync()
        {
            var badges = await _badgeReadRepository.GetAllAsync(false); 
            return _mapper.Map<ICollection<BadgeListItemDTO>>(badges);
        }

        public async Task<ICollection<BadgeListItemDTO>> GetAllDeletedAsync()
        {
            var badges = await _badgeReadRepository.GetAllAsync(true);
            return _mapper.Map<ICollection<BadgeListItemDTO>>(badges);
        }

        public async Task<Badge> HardDeleteAsync(int id)
        {
            var service = await _badgeReadRepository.GetByIdAsync(id, true);
            if (service == null)
                throw new Exception("Service tapilmadi");

            _badgeWriteRepository.HardDelete(service);
            await _badgeWriteRepository.SaveChangeAsync();
            return service;
        }

        public async Task<Badge> RestoreAsync(int id)
        {
            var service = await _badgeReadRepository.GetByIdAsync(id, true);
            if (service == null)
                throw new Exception("Service tapilmadi");

            service.IsDeleted = false;
            await _badgeWriteRepository.SaveChangeAsync();
            return service;
        }

        public async Task<Badge> SoftDeleteAsync(int id)
        {
            var service = await _badgeReadRepository.GetByIdAsync(id, true);
            if (service == null)
                throw new Exception("Service tapilmadi");

            service.IsDeleted = true;
            await _badgeWriteRepository.SaveChangeAsync();
            return service;
        }

        public async Task<Badge> UpdateAsync(int id, BadgeUpdateDTO updateDTO)
        {
            var service = await _badgeReadRepository.GetByIdAsync(id, true);
            if (service == null)
                throw new Exception("Service tapilmadi");

            _mapper.Map(updateDTO, service);

            if (updateDTO.Image is not null)
            {
                service.ImageUrl = await updateDTO.Image.SaveAsync("badgeImg");
            }

          

            await _badgeWriteRepository.SaveChangeAsync();
            return service;
        }
    }
}
