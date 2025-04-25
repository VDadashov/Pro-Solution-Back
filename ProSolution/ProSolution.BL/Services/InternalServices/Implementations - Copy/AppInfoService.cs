using Microsoft.Identity.Client;
using ProSolution.BL.Services.InternalServices.Abstractions;
using ProSolution.BL.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProSolution.BL.Services.InternalServices.Implementations
{
    public class AppInfoService(AppSettings _appSettings) : IAppInfoService
    {
        public string GetAddress()
       =>_appSettings.Address;

        public string GetBackGroundPath()
       => _appSettings.BackGroundPath;

        public string GetEmail()
       => _appSettings.Email;

        public string GetFBLink()
=> _appSettings.FBLink;

        public string GetIconPath()
        => _appSettings.IconPath;

        public string GetIGLink()
       => _appSettings.IGLink;

        public string GetINLink()
       => _appSettings.INLink;

        public string GetLogoPath()
        => _appSettings.LogoPath;

        public string GetName()
       => _appSettings.Name;

        public string GetPhone()
       => _appSettings.Phone;

        public string GetWorKingHours()
       => _appSettings.WorKingHours;
        
    }
}
