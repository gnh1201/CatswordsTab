using System;
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
                { "head32",    GetHEAD32(filePath) },
                { "crc32",     GetCRC32(filePath) },
                { "sha256",    GetSHA256(filePath) },
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

        public static string GetHEAD32(string filename)
        {
            using (var stream = File.OpenRead(filename))
            {
                int count = 32;

                byte[] buffer = new byte[count];
                int offset = 0;
                while (offset < count)
                {
                    int read = stream.Read(buffer, offset, count - offset);
                    if (read == 0)
                        throw new System.IO.EndOfStreamException();
                    offset += read;
                }
                System.Diagnostics.Debug.Assert(offset == count);

                return Convert.ToBase64String(buffer);
            }
        }
        
        public string GetAnalyzedPE(string filename)
        {
            string text = "";

            try
            {
                PeFile pe = new PeNet.PeFile(filename);
                text += pe.ToString();
            } catch (Exception e)
            {
                text += string.Format("{0}\r\n", e.Message);
            }

            return text;
        }

        public string GetAnalyzedELF(string filename)
        {
            string text = "";

            try
            {
                IELF elf = ELFReader.Load(filename);

                text += _eol("Sections:");
                foreach (ISection header in elf.Sections)
                {
                    text += string.Format(_eol("   {0}"), header.ToString());
                }

                text += _eol("Functions:");
                var functions = ((ISymbolTable)elf.GetSection(".symtab")).Entries.Where(
                    x => x.Type == SymbolType.Function
                );
                foreach (ISymbolEntry f in functions)
                {
                    text += string.Format(_eol("   {0}"), f.Name);
                }
            } catch (Exception e)
            {
                text += string.Format(_eol("{0}"), e.Message);
            }

            return text;
        }

        public string GetAnalyzedEXIF(string filename)
        {
            string text = "";

            try
            {
                text += _eol("Properties:");
                ImageFile data = ImageFile.FromFile(filename);
                foreach (ExifProperty item in data.Properties)
                {
                    text += string.Format(_eol("   {0}"), item.ToString());
                }
            } catch (Exception e)
            {
                text += string.Format(_eol("{0}"), e.Message);
            }

            return text;
        }

       public string GetAnalyzedAPK(string filename, string extension = "apk")
        {
            string text = "";

            if (extension.ToLower() != "apk")
            {
                text += _eol("This is not a Android Application Package.");
                return text;
            }

            try {
                AndroidMetadata apk = new AndroidMetadata(filename);
                ApkReader apkReader = new ApkReader();
                ApkInfo info = apkReader.extractInfo(apk.GetManifestData(), apk.GetResourcesData());

                text += string.Format(_eol("Package Name: {0}"), info.packageName);
                text += string.Format(_eol("Version Name: {0}"), info.versionName);
                text += string.Format(_eol("Version Code: {0}"), info.versionCode);
                text += string.Format(_eol("App Has Icon: {0}"), info.hasIcon);
                if (info.iconFileName.Count > 0) {
                    text += string.Format(_eol("App Icon: {0}"), info.iconFileName[0]);
                }
                text += string.Format(_eol("Min SDK Version: {0}"), info.minSdkVersion);
                text += string.Format(_eol("Target SDK Version: {0}"), info.targetSdkVersion);

                if (info.Permissions != null && info.Permissions.Count > 0)
                {
                    text += _eol("Permissions:");
                    info.Permissions.ForEach(f =>
                    {
                        text += string.Format(_eol("   {0}"), f);
                    });
                }
                else
                {
                    text += _eol("No Permissions Found");
                }

                text += string.Format(_eol("Supports Any Density: {0}"), info.supportAnyDensity);
                text += string.Format(_eol("Supports Large Screens: {0}"), info.supportLargeScreens);
                text += string.Format(_eol("Supports Normal Screens: {0}"), info.supportNormalScreens);
                text += string.Format(_eol("Supports Small Screens: {0}"), info.supportSmallScreens);
            } catch (Exception e)
            {
                text += string.Format(_eol("{0}"), e.Message);
            }


            return text;
        }
    }
}
