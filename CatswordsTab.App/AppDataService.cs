using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatswordsTab.App
{
    class AppDataService
    {
        public static string GetAppDataFolder()
        {
            return Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        }

        public static string GetFilePath(string filename)
        {
            return Path.Combine(GetAppDataFolder(), filename);
        }
    }
}
