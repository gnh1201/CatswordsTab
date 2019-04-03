using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using ELFSharp.ELF;
using ELFSharp.ELF.Sections;
using PeNet;
using Force.Crc32;
using System.Collections.Generic;
using ExifLibrary;
using CatswordsTab.Server.Helper;
using Iteedee.ApkReader;

namespace CatswordsTab.Server.Response
{
    class Analyze : ResponseBase
    {
        private Dictionary<string, string> analyzed;

        public Analyze(string filePath)
        {
            string extension = GetExtension(filePath);

            analyzed = new Dictionary<string, string>
            {
                { "extension", extension },
                { "md5",       GetMD5(filePath) },
                { "sha1",      GetSHA1(filePath) },
                { "head32",    GetSHA1(filePath) },
                { "crc32",     GetCRC32(filePath) },
                { "sha256",    GetSHA256(filePath) },
                { "language",  GetLanguage() },
                { "pe",        GetAnalyzedPE(filePath) },
                { "elf",       GetAnalyzedELF(filePath) },
                { "exif",      GetAnalyzedEXIF(filePath) },
                { "apk",       GetAnalyzedAPK(filePath, extension) }
            };
        }

        public Dictionary<string, string> GetAnalyzed()
        {
            return analyzed;
        }

        public string GetExtension(string filename)
        {
            return Path.GetExtension(filename).Substring(1).ToUpper();
        }

        public string GetMD5(string filename)
        {
            string checksum = "";

            using (MD5 hasher = MD5.Create())
            {
                using (FileStream stream = File.OpenRead(filename))
                {
                    byte[] hash = hasher.ComputeHash(stream);
                    checksum = BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
                }
            }

            return checksum;
        }

        public string GetSHA1(string filename)
        {
            string checksum = "";

            using (SHA1 hasher = SHA1.Create())
            {
                using (FileStream stream = File.OpenRead(filename))
                {
                    byte[] hash = hasher.ComputeHash(stream);
                    checksum = BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
                }
            }

            return checksum;
        }

        public string GetCRC32(string filename)
        {
            string checksum = "";

            using (FileStream stream = File.OpenRead(filename))
            {
                checksum = string.Format("{0:x}", Crc32Algorithm.Compute(stream));
            }

            return checksum;
        }

        public string GetSHA256(string filename)
        {
            string checksum = "";

            using (SHA256 hasher = SHA256.Create())
            {
                using (FileStream stream = File.OpenRead(filename))
                {
                    var hash = hasher.ComputeHash(stream);
                    checksum = BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
                }
            }

            return checksum;
        }

        public static string GetLanguage()
        {
            string language = "en";
            string locale = CultureInfo.CurrentUICulture.Name;
            string[] terms = locale.Split('-');

            if (terms.Length > 0)
            {
                language = terms[0];
            }

            return language;
        }

        public string GetAnalyzedPE(string filename)
        {
            string text = "";

            try
            {
                PeFile pe = new PeNet.PeFile(filename);
                text = pe.ToString();
            } catch (Exception e)
            {
                text = e.Message;
            }

            return text;
        }

        public string GetAnalyzedELF(string filename)
        {
            string text = "";

            try
            {
                IELF elf = ELFReader.Load(filename);

                text += "Sections:\r\n";
                foreach (ISection header in elf.Sections)
                {
                    text += string.Format("   {0}\r\n", header.ToString());
                }

                text += "Functions:\r\n";
                var functions = ((ISymbolTable)elf.GetSection(".symtab")).Entries.Where(
                    x => x.Type == SymbolType.Function
                );
                foreach (ISymbolEntry f in functions)
                {
                    text += string.Format("   {0}\r\n", f.Name);
                }
            } catch (Exception e)
            {
                text += string.Format("{0}\r\n", e.Message);
            }

            return text;
        }

        public string GetAnalyzedEXIF(string filename)
        {
            string text = "";

            try
            {
                text += "Properties:\r\n";
                ImageFile data = ImageFile.FromFile(filename);
                foreach (ExifProperty item in data.Properties)
                {
                    text += string.Format("   {0}\r\n", item.ToString());
                }
            } catch (Exception e)
            {
                text += string.Format("{0}\r\n", e.Message);
            }

            return text;
        }

       public string GetAnalyzedAPK(string filename, string extension = "apk")
        {
            string text = "";

            if (extension.ToLower() != "apk")
            {
                return text;
            }

            try {
                AndroidMetadata apk = new AndroidMetadata(filename);
                ApkReader apkReader = new ApkReader();
                ApkInfo info = apkReader.extractInfo(apk.GetManifestData(), apk.GetResourcesData());

                text += string.Format("Package Name: {0}\r\n", info.packageName);
                text += string.Format("Version Name: {0}\r\n", info.versionName);
                text += string.Format("Version Code: {0}\r\n", info.versionCode);
                text += string.Format("App Has Icon: {0}\r\n", info.hasIcon);
                if (info.iconFileName.Count > 0) {
                    text += string.Format("App Icon: {0}\r\n", info.iconFileName[0]);
                }
                text += string.Format("Min SDK Version: {0}\r\n", info.minSdkVersion);
                text += string.Format("Target SDK Version: {0}\r\n", info.targetSdkVersion);

                if (info.Permissions != null && info.Permissions.Count > 0)
                {
                    text += "Permissions:\r\n";
                    info.Permissions.ForEach(f =>
                    {
                        text += string.Format("   {0}\r\n", f);
                    });
                }
                else
                {
                    text += "No Permissions Found\r\n";
                }

                text += string.Format("Supports Any Density: {0}\r\n", info.supportAnyDensity);
                text += string.Format("Supports Large Screens: {0}\r\n", info.supportLargeScreens);
                text += string.Format("Supports Normal Screens: {0}\r\n", info.supportNormalScreens);
                text += string.Format("Supports Small Screens: {0}\r\n", info.supportSmallScreens);
            } catch (Exception e)
            {
                text += string.Format("{0}\r\n", e.Message);
            }


            return text;
        }
    }
}
