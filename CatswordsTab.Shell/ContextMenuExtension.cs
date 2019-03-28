using SharpShell.Attributes;
using SharpShell.SharpContextMenu;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace CatswordsTab.Shell
{
    [ComVisible(true)]
    [COMServerAssociation(AssociationType.AllFiles)]
    public class ContextMenuExtension : SharpContextMenu
    {
        protected override bool CanShowMenu()
        {
            return true;
        }
        
        protected override ContextMenuStrip CreateMenu()
        {
            var menu = new ContextMenuStrip();
            var language = MessageService.GetLocale();
            var menuText = Properties.Resources.menuText_en;

            if (language == "ko")
            {
                menuText = Properties.Resources.menuText_ko;
            }

            //  Create a 'count lines' item.
            var menuItem = new ToolStripMenuItem
            {
                Text = menuText,
                Image = Properties.Resources.icon_icons_retro_flower_fire_2_24692_16
            };

            //  When we click, we'll count the lines.
            menuItem.Click += (sender, args) => OnClick();

            //  Add the item to the context menu.
            menu.Items.Add(menuItem);

            //  Return the menu.
            return menu;
        }

        private void OnClick()
        {
            MessageService.Push("CatswordsTab.Shell.ContextMenuExtension.OnClick");
            foreach (string filePath in SelectedItemPaths)
            {
                MessageService.Push(filePath);
            }
            MessageService.Push("End");
            MessageService.Commit();
        }
    }
}
