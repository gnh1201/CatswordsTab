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
        /// <summary>
        /// Determines whether this instance can a shell
        /// context show menu, given the specified selected file list.
        /// </summary>
        /// <returns>
        /// <c>true</c> if this instance should show a shell context
        /// menu for the specified file list; otherwise, <c>false</c>.
        /// </returns>
        protected override bool CanShowMenu()
        {
            //  We always show the menu.
            return true;
        }

        /// <summary>
        /// Creates the context menu. This can be a single menu item or a tree of them.
        /// </summary>
        /// <returns>
        /// The context menu for the shell context menu.
        /// </returns>
        protected override ContextMenuStrip CreateMenu()
        {
            //  Create the menu strip.
            var menu = new ContextMenuStrip();

            //  Create a 'count lines' item.
            var menuItem = new ToolStripMenuItem
            {
                Text = "Open with Community...",
                Image = Properties.Resources.icon_icons_retro_flower_fire_2_24692_16
            };

            //  When we click, we'll count the lines.
            menuItem.Click += (sender, args) => DoAction();

            //  Add the item to the context menu.
            menu.Items.Add(menuItem);

            //  Return the menu.
            return menu;
        }

        /// <summary>
        /// Counts the lines in the selected files.
        /// </summary>
        private void DoAction()
        {
            //  Builder for the output.
            var builder = new StringBuilder();

            //  Go through each file.
            foreach (var filePath in SelectedItemPaths)
            {
                //  Count the lines.
                builder.AppendLine(string.Format("{0} - {1} Lines",
                  Path.GetFileName(filePath), File.ReadAllLines(filePath).Length));
            }

            //  Show the ouput.
            MessageBox.Show(builder.ToString());
        }
    }
}
