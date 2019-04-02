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

namespace CatswordsTab.Server.Response
{
    class Analyze : ResponseBase
    {
        private Dictionary<string, string> analyzed;

        public Analyze(string filePath)
        {
            analyzed = new Dictionary<string, string>
            {
                { "extension", GetExtension(filePath) },
                { "md5", GetMD5(filePath) },
                { "sha1", GetSHA1(filePath) },
                { "head32", GetSHA1(filePath) },
                { "crc32", GetCRC32(filePath) },
                { "sha256", GetSHA256(filePath) },
                { "language", GetLanguage() },
                { "pe", GetAnalyzedPE(filePath) },
                { "elf", GetAnalyzedELF(filePath) }
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

            using (var hasher = MD5.Create())
            {
                using (var stream = File.OpenRead(filename))
                {
                    var hash = hasher.ComputeHash(stream);
                    checksum = BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
                }
            }

            return checksum;
        }

        public string GetSHA1(string filename)
        {
            string checksum = "";

            using (var hasher = SHA1.Create())
            {
                using (var stream = File.OpenRead(filename))
                {
                    var hash = hasher.ComputeHash(stream);
                    checksum = BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
                }
            }

            return checksum;
        }

        public string GetCRC32(string filename)
        {
            string checksum = "";

            using (var stream = File.OpenRead(filename))
            {
                checksum = String.Format("{0:x}", Crc32Algorithm.Compute(stream));
            }

            return checksum;
        }

        public string GetSHA256(string filename)
        {
            string checksum = "";

            using (var hasher = SHA256.Create())
            {
                using (var stream = File.OpenRead(filename))
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

                foreach (ISection header in elf.Sections)
                {
                    text += header.ToString() + "\r\n";
                }

                var functions = ((ISymbolTable)elf.GetSection(".symtab")).Entries.Where(
                    x => x.Type == SymbolType.Function
                );
                foreach (ISymbolEntry f in functions)
                {
                    text += f.Name + "\r\n";
                }
            } catch(Exception e)
            {
                text = e.Message;
            }

            return text;
        }
    }
}
