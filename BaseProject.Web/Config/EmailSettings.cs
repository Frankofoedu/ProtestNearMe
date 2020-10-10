using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseProject.Web.Config
{
    public class EmailSettings
    {
        public EmailSettings()
        {

        }
        public string FromEmail { get; set; }
        public string DisplayName { get; set; }
        public string Password { get; set; }
        public string HostName { get; set; }
        public string UserName { get; set; }
    }
}
