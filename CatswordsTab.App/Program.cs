using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using CatswordsTab.App.Winform;
using CommandLine;

namespace CatswordsTab.App
{
    static class Program
    {
        [DllImport("kernel32.dll")]
        static extern bool AttachConsole(int dwProcessId);
        private const int ATTACH_PARENT_PROCESS = -1;

        class Options
        {
            [Option('f', "filename", Required = false, HelpText = "Set file name or path")]
            public string FileName { get; set; }

            [Option('e', "export", Required = false, HelpText = "Export to file")]
            public string Export { get; set; }
        }

        static void OpenWelcomeWindow(string filename = null)
        {
            System.Windows.Forms.Application.EnableVisualStyles();
            System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);

            Welcome welcomeWindow = new Welcome();
            welcomeWindow.FileName = filename;
            System.Windows.Forms.Application.Run(welcomeWindow);
        }

        static void WriteLine(string text = "")
        {
            Console.WriteLine(text);
        }

        static void WriteFile(string path, string text = "")
        {
            File.WriteAllText(path, text, Encoding.UTF8);
        }

        /// <summary>
        /// 해당 응용 프로그램의 주 진입점입니다.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            AttachConsole(ATTACH_PARENT_PROCESS);

            ParserResult<Options> _ = Parser.Default.ParseArguments<Options>(args)
                .WithParsed<Options>(o =>
                    {
                        if (!string.IsNullOrEmpty(o.FileName)) {
                            if (!string.IsNullOrEmpty(o.Export))
                            {
                                WriteFile(o.Export, MainService.GetResult(o.FileName));
                                WriteLine("Exported file to " + o.Export);
                            }
                            else
                            {
                                OpenWelcomeWindow(o.FileName);
                            }
                        }
                        else
                        {
                            if (!string.IsNullOrEmpty(o.Export))
                            {
                                WriteLine("File name is not specified");
                            }
                            else
                            {
                                OpenWelcomeWindow();
                            }
                        }
                    }
                )
                .WithNotParsed<Options>(e =>
                    {
                        OpenWelcomeWindow();
                    }
                );
        }
    }
}
