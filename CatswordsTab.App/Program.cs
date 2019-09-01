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
            [Option('f', "filename", Required = false, HelpText = "Set File name or path.")]
            public string FileName { get; set; }

            [Option('c', "commandline", Required = false, HelpText = "Use command line.")]
            public int CommandLine { get; set; }
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
            File.WriteAllText("stdout.txt", text, Encoding.UTF8);
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
                            if (o.CommandLine == 1)
                            {
                                WriteLine(MainService.GetResult(o.FileName));
                            }
                            else
                            {
                                OpenWelcomeWindow(o.FileName);
                            }
                        }
                        else
                        {
                            if (o.CommandLine == 1)
                            {
                                WriteLine("File name is not specified.");
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
