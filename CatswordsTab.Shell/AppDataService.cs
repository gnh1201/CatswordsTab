using System;
using System.IO;

namespace CatswordsTab.Shell
{
    class AppDataService
    {
        public static string GetFilePath(string filename)
        {
            return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), filename);
        }
    }
}
