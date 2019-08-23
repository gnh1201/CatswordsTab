using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatswordsTab.App.Model
{
    class ApplicationModel
    {
        public string ResourceName { get; set; }
        public string Default { get; set; }
        public string InstallDate { get; set; }
        public string InstallLocation { get; set; }
        public string Publisher { get; set; }
        public string DisplayIcon { get; set; }
        public string DisplayName { get; set; }
        public string DisplayVersion { get; set; }
        public string HelpLink { get; set; }
        public string UninstallString { get; set; }
    }
}
