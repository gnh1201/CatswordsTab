using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using ELFSharp.ELF;
using ELFSharp.ELF.Sections;
using PeNet;

namespace CatswordsTab.Server.Response
{
    class Analyze : ResponseBase
    {
        private PeFile pe;
        private IELF elf;
        private string extension;
        private string hash_md5;
        private string hash_sha1;
        private string hash_crc32;
        private string hash_head32;
        private string hash_sha256;

        public string GetExtension(string FilePath)
        {
            extension = Path.GetExtension(FilePath).Substring(1).ToUpper();
            AppandResponseText(extension);

            return extension;
        }

        // https://stackoverflow.com/questions/10520048/calculate-md5-checksum-for-a-file
        public string GetMD5(string filename)
        {
            using (var md5 = MD5.Create())
            {
                using (var stream = File.OpenRead(filename))
                {
                    var hash = md5.ComputeHash(stream);
                    hash_md5 = BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();

                    AppandResponseText("## HASH MD5");
                    AppandResponseText(hash_md5);
                }
            }

            return hash_md5;
        }

        public string GetSHA1(string filename)
        {
            using (var sha1 = SHA1.Create())
            {
                using (var stream = File.OpenRead(filename))
                {
                    var hash = sha1.ComputeHash(stream);
                    hash_sha1 = BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();

                    AppandResponseText("## HASH SHA1");
                    AppandResponseText(hash_sha1);
                }
            }

            return hash_sha1;
        }
        
        // https://stackoverflow.com/questions/7514101/how-do-i-read-exactly-n-bytes-from-a-stream
        public string GetHEAD32(string filename)
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

                hash_head32 = Convert.ToBase64String(buffer);

                AppandResponseText("## HASH HEAD32");
                AppandResponseText(hash_head32);
            }

            return hash_head32;
        }

        public string GetCRC32(string filename)
        {
            hash_crc32 = "";
            return hash_crc32;
        }

        public string GetSHA256(string filename)
        {
            using (var sha256 = SHA256.Create())
            {
                using (var stream = File.OpenRead(filename))
                {
                    var hash = sha256.ComputeHash(stream);
                    hash_sha256 = BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();

                    AppandResponseText("## HASH HEAD256");
                    AppandResponseText(hash_sha256);
                }
            }

            return hash_sha256;
        }

        public void DoPE(string filename)
        {
            pe = new PeNet.PeFile(filename);

            AppandResponseText("## PE Header");
            AppandResponseText(pe.ToString());
        }

        public void DoELF(string filename)
        {
            elf = ELFReader.Load(filename);

            // ELF Section Header
            AppandResponseText("## ELF Section Header");
            foreach (ISection header in elf.Sections)
            {
                AppandResponseText(header.ToString());
            }

            // ELF Functions
            AppandResponseText("## ELF Function");
            var functions = ((ISymbolTable)elf.GetSection(".symtab")).Entries.Where(x => x.Type == SymbolType.Function);
            foreach (ISymbolEntry f in functions)
            {
                AppandResponseText(f.Name);
            }
        }
    }
}
