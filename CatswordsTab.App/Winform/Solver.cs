using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Windows.Forms;
using System.Xml;

namespace CatswordsTab.App.Winform
{
    public partial class Solver : Form
    {
        public Solver()
        {
            InitializeComponent();

            Text = T._(Text);
            labelTitle.Text = T._(labelTitle.Text);
            labelManifest.Text = T._(labelManifest.Text);
            labelExport.Text = T._(labelExport.Text);
            labelManifest.Text = T._(labelManifest.Text);
            btnSolve.Text = T._(btnSolve.Text);
            btnOpenManifest.Text = T._(btnOpenManifest.Text);
            btnOpenExport.Text = T._(btnOpenExport.Text);
            linkLabel1.Text = T._(linkLabel1.Text);
        }

        private string ChooseOpenFile()
        {
            string filename = null;
            OpenFileDialog fd = new OpenFileDialog
            {
                Title = T._("Choose your file...")
            };

            if (fd.ShowDialog() == DialogResult.OK)
            {
                filename = fd.FileName;
            }

            return filename;
        }

        private string ChooseSaveFile()
        {
            string filename = null;
            SaveFileDialog fd = new SaveFileDialog
            {
                Title = T._("Choose your file...")
            };

            if (fd.ShowDialog() == DialogResult.OK)
            {
                filename = fd.FileName;
            }

            return filename;
        }

        private void OnClick_btnOpenManifest(object sender, EventArgs e)
        {
            string filename = ChooseOpenFile();
            txtManifestFilename.Text = filename;
        }

        private void OnClick_txtManifestFilename(object sender, EventArgs e)
        {
            OnClick_btnOpenManifest(sender, e);
        }

        private void OnClick_btnOpenExport(object sender, EventArgs e)
        {
            string filename = ChooseSaveFile();
            txtExportFilename.Text = filename;
        }

        private void OnClick_txtExportFilename(object sender, EventArgs e)
        {
            OnClick_btnOpenExport(sender, e);
        }

        private void OnClick_BtnSolve(object sender, EventArgs e)
        {
            string zipFile = @txtManifestFilename.Text;
            string extractPath = AppDataService.GetAppDataFolder();

            try
            {
                ZipFile.ExtractToDirectory(zipFile, extractPath);
            }
            catch (Exception) {
                // pass
            }

            XmlDocument xdoc = new XmlDocument();
            xdoc.LoadXml(File.ReadAllText(AppDataService.GetFilePath("manifest.xml")));

            XmlNodeList nodes;

            // get variables
            Dictionary<string, string> variables = new Dictionary<string, string>();
            nodes = xdoc.GetElementsByTagName("variables");
            foreach(XmlNode node in nodes)
            {
                foreach(XmlNode _node in node.SelectNodes("variable"))
                {
                    if (_node.Attributes["type"].Value != "argument")
                    {
                        variables.Add(_node.Attributes["name"].Value, _node.Attributes["value"].Value);
                    }
                    else if(_node.Attributes["name"].Value == "input") {
                        variables.Add("input", WinformService.GetMainWindow().GetPath());
                    }
                    else if(_node.Attributes["name"].Value == "output")
                    {
                        variables.Add("output", txtExportFilename.Text);
                    }
                }
            }

            // get repositories
            Dictionary<string, string> repositories = new Dictionary<string, string>();
            nodes = xdoc.GetElementsByTagName("repositories");
            foreach (XmlNode node in nodes)
            {
                foreach (XmlNode _node in node.SelectNodes("repository"))
                {
                    repositories.Add(_node.Attributes["name"].Value, _node.Attributes["source"].Value);
                }
            }

            // do steps
            nodes = xdoc.GetElementsByTagName("steps");
            foreach(XmlNode node in nodes)
            {
                foreach (XmlNode _node in node.SelectNodes("step"))
                {
                    string repositoryName = _node.Attributes["repository"].Value;
                    string filename = AppDataService.GetFilePath(repositories[repositoryName]);
                    string argument = _node.Attributes["argument"].Value;
                    foreach(KeyValuePair<string, string> v in variables)
                    {
                        argument = argument.Replace(@"${" + v.Key + "}", "\"" + v.Value + "\"");
                    }

                    // execute process
                    System.Diagnostics.Process process = new System.Diagnostics.Process();
                    System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
                    startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                    startInfo.FileName = filename;
                    startInfo.Arguments = argument;
                    process.StartInfo = startInfo;
                    process.Start();
                }
            }

            // Done
            MessageBox.Show(T._("Done"));
        }

        private void OnClick_LinkLabel1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/catswords/CatswordsTab");
        }
    }
}
