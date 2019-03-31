using System;
using System.Threading;
using NetMQ;
using NetMQ.Sockets;
using CatswordsTab.Server.Winform;
using System.Threading.Tasks;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using CatswordsTab.Server.Response;

namespace CatswordsTab.Server
{
    public class Program
    {
        private static Writer writerForm;
        private static List<string> flags = new List<string>();
        private static int flag = -1;

        private static string fileMd5;
        private static string fileSha1;
        private static string fileCrc32;
        private static string fileHead32;
        private static string fileSha256;
        private static string fileExtension;
        private static string locale = "en";
        private static bool isExit = false;

        private static string GetResponseString(string message)
        {
            string response = "";

            switch(message)
            {
                case "SetLocale":
                    flags.Add("SetLocale");
                    break;

                case "GetMessage":
                    response = MessageService.Pull();
                    break;

                case "CatswordsTab.Shell.SheetExtensionPage.OnLoad_SheetExtensionPage":
                    break;

                case "CatswordsTab.Shell.SheetExtensionPage.OnClick_btnAdd":
                    Task taskA = new Task(() => ShowWriterForm());
                    taskA.Start();
                    break;

                case "CatswordsTab.Shell.SheetExtensionPage.OnPropertyPageInitialised":
                    flags.Add("OnPropertyPageInitialised");
                    break;

                case "CatswordsTab.Shell.SheetExtensionPage.OnPropertySheetApply":
                    isExit = true;
                    break;

                case "CatswordsTab.Shell.SheetExtensionPage.OnPropertySheetOK":
                    isExit = true;
                    break;

                case "CatswordsTab.Shell.ContextMenuExtension.OnClick":
                    flags.Add("ContextMenuExtension.OnClick");
                    break;

                case "Exception":
                    flags.Add("Exception");
                    break;

                default:
                    // Get Response
                    flag = flags.IndexOf("OnPropertyPageInitialised");
                    if(flag > -1)
                    {
                        response = GetResponse(message);
                        ResetFlag(flag);
                    }

                    // Set Language
                    flag = flags.IndexOf("SetLocale");
                    if(flag > -1)
                    {
                        locale = message;
                        ResetFlag(flag);
                    }

                    // If ContextMenuExtension
                    flag = flags.IndexOf("ContextMenuExtension.OnClick");
                    if(flag >= -1)
                    {
                        if (message == "return")
                        {
                            ResetFlag(flag);
                        }
                        else
                        {
                            Console.WriteLine("Clicked: {0}",  message);
                        }
                    }

                    // When Exception
                    flag = flags.IndexOf("Exception");
                    if (flag > -1)
                    {
                        ResetFlag(flag);
                    }

                    break;
            }
            
            return response;
        }

        private static void ShowWriterForm()
        {
            writerForm = new Writer();
            writerForm.ShowDialog();
        }

        private static void Exit()
        {
            Environment.Exit(0);
        }

        private static void ResetFlag(int flag)
        {
            flags.RemoveAt(flag);
            flag = -1;
        }

        private static string GetResponse(string message)
        {
            string response = "";

            Analyze analyzer = new Analyze();
            fileMd5 = analyzer.GetMD5(message);
            fileSha1 = analyzer.GetSHA1(message);
            fileCrc32 = analyzer.GetCRC32(message);
            fileSha256 = analyzer.GetSHA256(message);
            fileHead32 = analyzer.GetHEAD32(message);
            fileExtension = analyzer.GetExtension(message);

            JObject obj = new JObject
            {
                { "hash_md5", fileMd5 },
                { "hash_sha1", fileSha1 },
                { "hash_crc32", fileCrc32 },
                { "hash_sha256", fileSha256 },
                { "hash_head32", fileHead32 },
                { "extension", fileExtension },
                { "language", locale }
            };
            response = Communicate.RequestPost("/portal/?route=tab", obj.ToString());

            Console.WriteLine("Response: {0}", response);

            return response;
        }

        public static void Main(string[] args)
        {
            Console.WriteLine("Start...!");
            using (var server = new ResponseSocket("@tcp://localhost:26112")) // bind
            {
                while (true)
                {
                    string received = server.ReceiveFrameString();
                    Console.WriteLine("Received: {0}", received);

                    string response = GetResponseString(received);
                    server.SendFrame((response ?? "").ToString());
                    
                    if(isExit)
                    {
                        Exit();
                    }

                    Thread.Sleep(0);
                }
            }
        }
    }
}
