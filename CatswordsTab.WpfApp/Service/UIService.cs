using CatswordsTab.WpfApp.Controls;
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

        public static void CreateTabPage(object Content, string Title = "Untitled", string Name = null)
        {
            ClosableTab ti = new ClosableTab
            {
                Title = Title,
                Name = Name,
                Content = Content
            };
            TabControlInstance.Items.Add(ti);
            ti.Focus();
        }
    }
}
