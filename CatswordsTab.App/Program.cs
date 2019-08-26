using System;
using System.Windows.Forms;
using CatswordsTab.App.Winform;
using CommandLine;

namespace CatswordsTab.App
{
    static class Program
    {
        class Options
        {
            [Option('f', "filename", Required = false, HelpText = "Set File name or path.")]
            public string FileName { get; set; }
        }

        /// <summary>
        /// 해당 응용 프로그램의 주 진입점입니다.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            System.Windows.Forms.Application.EnableVisualStyles();
            System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);

            ParserResult<Options> _ = Parser.Default.ParseArguments<Options>(args);
            _.WithParsed<Options>(o =>
                {
                    if (string.IsNullOrEmpty(o.FileName))
                    {
                        System.Windows.Forms.Application.Run(new Welcome());
                    }
                    else
                    {
                        System.Windows.Forms.Application.Run(new Main(o.FileName));
                    }
                }
            );
            _.WithNotParsed<Options>(e =>
                {
                    System.Windows.Forms.Application.Run(new Welcome());
                }
            );
        }
    }
}
