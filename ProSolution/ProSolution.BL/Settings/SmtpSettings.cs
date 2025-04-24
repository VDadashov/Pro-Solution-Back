using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProSolution.BL.Settings
{

        public class SmtpSettings
        {
            public string Host { get; set; }
            public int Port { get; set; }
            public bool EnableSSL { get; set; }
            public string Username { get; set; }
            public string Password { get; set; }
            public string AdminEmail { get; set; }
        }
    

}
