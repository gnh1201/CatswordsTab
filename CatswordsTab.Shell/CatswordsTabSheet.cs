using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using SharpShell.Attributes;
using SharpShell.SharpPropertySheet;

namespace CatswordsTab.Shell
{
    [ComVisible(true)]
    [COMServerAssociation(AssociationType.AllFiles)]
    public class CatswordsTabSheet : SharpPropertySheet
    {
        protected override bool CanShowSheet()
        {
            //  We will only show the resources pages if we have ONE file selected.
            return SelectedItemPaths.Count() == 1;
        }

        protected override IEnumerable<SharpPropertyPage> CreatePages()
        {
            //  Create the property sheet page.
            var page = new CatswordsTabPage();

            //  Return the pages we've created.
            return new[] { page };
        }
    }
}
