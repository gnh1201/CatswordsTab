using System;
using System.Threading;
using NetMQ;
using NetMQ.Sockets;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using CatswordsTab.Server.Response;
using System.Globalization;

namespace CatswordsTab.Server
{
    public class Program
    {
        private static List<string> flags = new List<string>();
        private static string locale = "en";
        private static bool isExit = false;
        private static Dictionary<string, string> analyzed;

        private static string GetResponseString(string message)
        {
            string response = "";

            switch(message)
            {
                case "SetLocale":
                    flags.Add("SetLocale");
                    break;
                
                case "CatswordsTab.Shell.SheetExtensionPage.OnLoad_SheetExtensionPage":
                    break;

                case "CatswordsTab.Shell.SheetExtensionPage.OnClick_btnAdd":
                    break;

                case "CatswordsTab.Shell.SheetExtensionPage.OnPropertyPageInitialised":
                    flags.Add("Initalized");
                    break;

                case "CatswordsTab.Shell.SheetExtensionPage.OnPropertySheetApply":
                    isExit = true;
                    response = "Exit";
                    break;

                case "CatswordsTab.Shell.SheetExtensionPage.OnPropertySheetOK":
                    isExit = true;
                    response = "Exit";
                    break;

                case "CatswordsTab.Shell.Winform.Auth.OnClick_btnLogin":
                    flags.Add("DoLogin");
                    break;

                case "CatswordsTab.Shell.Winform.Writer.OnClick_btnSend":
                    flags.Add("DoComment");
                    break;
                
                case "CatswordsTab.Shell.Winform.Writer.OnClick_btnDonate":
                    System.Diagnostics.Process.Start("https://www.patreon.com/posts/catswordstab-25295231");
                    break;

                case "CatswordsTab.Shell.ContextMenuExtension.OnClick":
                    flags.Add("ClickedContextMenu");
                    break;

                case "Exception":
                    flags.Add("Exception");
                    break;
                    
                default:
                    response = DoFlags(message);
                    break;
            }
            
            return response;
        }

        private static string DoFlags(string message)
        {
            string response = "";
            List<int> flagIndexes = new List<int>();

            // process flags
            foreach (string flagName in flags)
            {
                int flagIndex = flags.IndexOf(flagName);

                if (message == "Commit")
                {
                    flagIndexes.Add(flagIndex);
                }
                else
                {
                    switch (flagName)
                    {
                        case "SetLocale":
                            locale = message;
                            break;

                        case "Initalized":
                            response = GetResponse(message);
                            break;

                        case "ClickedContextMenu":
                            Console.WriteLine("Clicked ContextMenu: {0}", message);
                            break;

                        case "DoLogin":
                            // todo
                            break;
                        
                        case "DoComment":
                            // todo
                            break;

                        case "Exception":
                            Console.WriteLine(message);
                            break;

                        default:
                            flagIndexes.Add(flagIndex);
                            break;
                    }
                }
            }

            // clear flags when commit
            foreach(int flagIndex in flagIndexes)
            {
                flags.RemoveAt(flagIndex);
            }

            return response;
        }

        private static void Exit()
        {
            Environment.Exit(0);
        }

        private static string GetResponse(string message)
        {
            string response = "";

            Analyze analyze = new Analyze(message);
            analyzed = analyze.GetAnalyzed();
            string jsonText = new JObject
            {
                { "hash_md5",        analyzed["md5"] },
                { "hash_sha1",       analyzed["sha1"] },
                { "hash_crc32",      analyzed["crc32"] },
                { "hash_sha256",     analyzed["sha256"] },
                { "hash_head32",     analyzed["head32"] },
                { "extension",       analyzed["extension"] },
                { "language",        GetLanguage() },
            }.ToString();

            response = Communicate.RequestPost("/portal/?route=tab", jsonText);
            Console.WriteLine("Response: {0}", response);

            foreach (KeyValuePair<string, string> entry in analyzed)
            {
                Console.WriteLine(entry.Key);
                Console.WriteLine(entry.Value);
            }

            return response;
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

        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome. We're CatswordsTab.");
            Console.WriteLine("Create your own community on the Windows Explorer.");
            Console.WriteLine("Start...!");

            using (ResponseSocket server = new ResponseSocket("@tcp://localhost:26112"))
            {
                while (true)
                {
                    string received = server.ReceiveFrameString();
                    Console.WriteLine("Received: {0}", received);

                    string response = GetResponseString(received);
                    server.SendFrame(response);

                    Thread.Sleep(0);
                }
            }
        }
    }
}
