using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CatswordsTab
{
    public partial class CatswordsTabExpert : Form
    {
        private CatswordsTabWriter catswordsTabWriter;

        public CatswordsTabExpert()
        {
            InitializeComponent();
        }

        public CatswordsTabExpert(CatswordsTabWriter catswordsTabWriter)
        {
            this.catswordsTabWriter = catswordsTabWriter;
        }
    }
}
