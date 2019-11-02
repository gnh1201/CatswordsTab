using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace CatswordsTab.WpfApp.Service
{
    public static class UIService
    {
        public static TabControl TabControlInstance { get; set; }

        public static void CreateTabPage(object Content, string Header = "Untitled", string Name = null)
        {
            TabItem ti = new TabItem
            {
                Header = Header,
                Name = Name,
                Content = Content
            };
            TabControlInstance.Items.Add(ti);
            ti.Focus();
        }
    }
}
