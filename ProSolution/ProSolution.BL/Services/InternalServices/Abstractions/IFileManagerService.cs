using Microsoft.AspNetCore.Http;

namespace ProSolution.BL.Services.InternalServices.Abstractions
{
    public interface IFileManagerService
    {
        Task<string> UploadFileAsync(IFormFile file);
    }
}
