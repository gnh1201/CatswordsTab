using SharpShell.Attributes;
using SharpShell.SharpPropertySheet;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace CatswordsTab.Shell
{
    [ComVisible(true)]
    [COMServerAssociation(AssociationType.AllFiles)]
    public class TabPropertySheet : SharpPropertySheet
    {
        protected override bool CanShowSheet()
        {
            //  We will only show the resources pages if we have ONE file selected.
            return SelectedItemPaths.Count() == 1;
        }

        protected override IEnumerable<SharpPropertyPage> CreatePages()
        {
            //  Create the property sheet page.
            var page = new TabPropertyPage();

            //  Return the pages we've created.
            return new[] { page };
        }
    }
}