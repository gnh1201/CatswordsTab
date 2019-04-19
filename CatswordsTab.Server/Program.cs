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
        private static Dictionary<string, string> kvdata;
        private static Dictionary<string, string> analyzed;
        private static string host = "localhost";
        private static int port = 26112;
        private static string oslLink = "https://www.patreon.com/posts/catswordstab-25295231";

        private static string GetResponseString(string message)
        {
            string response = "";

            switch(message)
            {
                case "Ping":
                    flags.Add("Ping");
                    break;

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
                    break;

                case "CatswordsTab.Shell.SheetExtensionPage.OnPropertySheetOK":
                    isExit = true;
                    break;

                case "CatswordsTab.Shell.Winform.Auth.OnClick_btnLogin":
                    flags.Add("Login");
                    break;

                case "CatswordsTab.Shell.Winform.Writer.OnClick_btnSend":
                    flags.Add("Comment");
                    break;
                
                case "CatswordsTab.Shell.Winform.Writer.OnClick_btnDonate":
                    System.Diagnostics.Process.Start(oslLink);
                    break;

                case "CatswordsTab.Shell.Winform.Expert.OnClick_btnSubmit":
                    flags.Add("Submit");
                    break;

                case "Exception":
                    flags.Add("Exception");
                    break;

                case "Commit":
                    response = ExecFlags(message);
                    flags = new List<string>(); // Reset all flags
                    break;

                default:
                    response = ExecFlags(message);
                    break;
            }
            
            return response;
        }

        private static string ExecFlags(string message)
        {
            string response = "";
            Dictionary<string, string> parsed_kv = ParseMessage(message);

            foreach (string flag in flags)
            {
                switch (flag)
                {
                    case "Ping":
                        response = "Pong";
                        break;

                    case "SetLocale":
                        locale = "Accept. " + message;
                        break;

                    case "Initalized":
                        response = GetResponse(message);
                        break;

                    case "Login":
                    case "Comment":
                    case "Submit":
                        if (parsed_kv["key"].Equals(""))
                        {
                            kvdata.Add(parsed_kv["key"], parsed_kv["value"]);

                            Console.WriteLine("key: " + parsed_kv["key"]);
                            Console.WriteLine("value: " + parsed_kv["value"]);
                        }
                        break;

                    case "Exception":
                        Console.WriteLine(message);
                        break;

                    default:
                        break;
                }
            }

            return response;
        }

        public static Dictionary<string, string> ParseMessage(string message)
        {
            Dictionary<string, string> data = new Dictionary<string, string>();
            int pos = message.IndexOf(':');

            if (pos > 0)
            {
                data["key"] = message.Substring(0, pos + 1).Trim();
                data["value"] = message.Substring(pos).Trim();
            }
            else
            {
                data["key"] = "";
                data["value"] = message;
            }
            
            return data;
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

            using (ResponseSocket server = new ResponseSocket(string.Format("@tcp://{0}:{1}", host, port)))
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
