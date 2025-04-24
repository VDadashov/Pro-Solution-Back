using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProSolution.BL.Services.InternalServices.Abstractions
{
    public interface IAppInfoService
    {
        string GetIconPath();
        string GetLogoPath();
        string GetBackGroundPath();
        string GetName();
        string GetPhone();
        string GetEmail();
        string GetAddress();
        string GetWorKingHours();
        string GetFBLink();
        string GetIGLink();
        string GetINLink();

    }
}
