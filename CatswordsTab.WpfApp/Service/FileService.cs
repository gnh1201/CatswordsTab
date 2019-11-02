using CatswordsTab.WpfApp.Model;
using RestSharp;
using Shell32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace CatswordsTab.WpfApp.Service
{
    public static class FileService
    {
        public static string ChooseFile()
        {
            string filename = null;

            System.Windows.Forms.OpenFileDialog fd = new System.Windows.Forms.OpenFileDialog();
            fd.Title = "Choose your file...";
            if (fd.ShowDialog() == DialogResult.OK)
            {
                filename = fd.FileName;
            }

            return filename;
        }

        public static FileInfo[] GetFiles(string path)
        {
            DirectoryInfo d = new DirectoryInfo(path); // Assuming Test is your Folder
            return d.GetFiles(); // Getting Text files
        }

        public static string GetDetails(string path)
        {
            string result = "";

            List<string> arrHeaders = new List<string>();
            List<Tuple<int, string, string>> attributes = new List<Tuple<int, string, string>>();

            Shell32.Shell shell = new Shell32.Shell();
            Shell32.Folder objFolder = shell.NameSpace(System.IO.Path.GetDirectoryName(path));
            Shell32.FolderItem folderItem = objFolder.ParseName(System.IO.Path.GetFileName(path));
            if (folderItem != null)
            {
                for (int i = 0; i < short.MaxValue; i++)
                {
                    string header = objFolder.GetDetailsOf(null, i);
                    if (String.IsNullOrEmpty(header))
                        break;
                    arrHeaders.Add(header);
                }

                // The attributes list below will contain a tuple with attribute index, name and value
                // Once you know the index of the attribute you want to get, 
                // you can get it directly without looping, like this:
                var Authors = objFolder.GetDetailsOf(folderItem, 20);

                for (int i = 0; i < arrHeaders.Count; i++)
                {
                    var attrName = arrHeaders[i];
                    var attrValue = objFolder.GetDetailsOf(folderItem, i);
                    var attrIdx = i;

                    attributes.Add(new Tuple<int, string, string>(attrIdx, attrName, attrValue));

                    result += string.Format("{0}\t{1}: {2}", i, attrName, attrValue);
                }
            }
            else
            {
                result += "Could not open extended properties.";
            }

            return result;
        }

        public static string GetReport(string path)
        {
            string result = "";
            ComputationModel computed = ComputationService.Compute(path);

            RestClient client = new RestClient("https://catswords.re.kr/ep/?route=tab");
            RestRequest request = new RestRequest(Method.POST);
            request.RequestFormat = DataFormat.Json;
            request.AddParameter("hash_md5", computed.MD5);
            request.AddParameter("hash_sha1", computed.SHA1);
            request.AddParameter("hash_crc32", computed.CRC32);
            request.AddParameter("hash_sha256", computed.SHA256);
            request.AddParameter("extension", computed.Extension);
            request.AddParameter("infohash", computed.InfoHash);
            request.AddParameter("locale", computed.SystemLocale);

            IRestResponse response = client.Execute(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                result = response.Content;
            }

            return result;
        }
    }
}
