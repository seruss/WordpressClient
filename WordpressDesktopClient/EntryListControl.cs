using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WordpressDesktopClient
{
    public partial class EntryListControl : UserControl
    {
        private List<BlogEntry> blogEntries;

        private static DataManager manager = new DataManager();

        public event EventHandler OnPanelSelected;

        public EntryListControl()
        {
            InitializeComponent();
        }

        private void EntryListControl_Load(object sender, EventArgs e)
        {
            blogEntries = manager.getComparedEntries(5);

            foreach (var entry in blogEntries)
            {
                EntryPresenter ep = new EntryPresenter(entry);
                ep.OnSeletion += OnPanelSelected;
                flowLayoutPanel.Controls.Add(ep);
            }
        }
    }
}
