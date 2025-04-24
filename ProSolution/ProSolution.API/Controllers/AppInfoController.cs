using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProSolution.BL.Services.InternalServices.Abstractions;

namespace ProSolution.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppInfoController(IAppInfoService _appInfoService) : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAppInfo()
        {
            try
            {
             
                return Ok(new
                {
                    IconPath = _appInfoService.GetIconPath(),
                    LogoPath = _appInfoService.GetLogoPath(),
                    BackGroundPath = _appInfoService.GetBackGroundPath(),
                    Name = _appInfoService.GetName(),
                    Phone = _appInfoService.GetPhone(),
                    Email = _appInfoService.GetEmail(),
                    Address = _appInfoService.GetAddress(),
                    WorKingHours = _appInfoService.GetWorKingHours(),
                    FBLink = _appInfoService.GetFBLink(),
                    IGLink = _appInfoService.GetIGLink(),
                    INLink = _appInfoService.GetINLink()
                });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
