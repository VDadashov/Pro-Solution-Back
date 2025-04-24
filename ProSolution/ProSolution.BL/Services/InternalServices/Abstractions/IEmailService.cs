using ProSolution.BL.DTOs.ContactMessageDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProSolution.BL.Services.InternalServices.Abstractions
{
    public interface IEmailService
    {
        Task SendContactMessageAsync(ContactMessageDTO contactDto);


    }
}
