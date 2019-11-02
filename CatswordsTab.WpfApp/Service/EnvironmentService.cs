using CatswordsTab.WpfApp.Model;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.IO;

namespace CatswordsTab.WpfApp.Service
{
    public static class EnvironmentService
    {
        public static string FontFolder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Fonts);

        public static List<FontModel> GetInstalledFonts()
        {
            List<FontModel> fonts = new List<FontModel>();
            FileInfo[] files = FileService.GetFiles(FontFolder);

            foreach(FileInfo file in files)
            {
                fonts.Add(new FontModel
                {
                    Name = file.Name,
                    FamilyName = file.Name,
                    InstallDate = "",
                    Organization = ""
                });
            }

            return fonts;
        }
    }
}
