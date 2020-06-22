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
    public partial class EntryPresenter : UserControl
    {
        private static int counter = 0;
        private Color defaultBackColor;
        private static Color highlighted = Color.MediumSlateBlue;
        private static EntryPresenter Selected;
        public event EventHandler OnSeletion;
 
        public BlogEntry DisplayedEntry { get; set; }

        public EntryPresenter(BlogEntry entry)
        {
            OnSeletion = new EventHandler(EntryPresenter_Click);
            DisplayedEntry = entry;
            InitializeComponent();
            TitleLabel.Text = entry.Title;
            ThumbnailPictureBox.Load(getImageLink(entry));
            groupBox.Text = $"[{entry.Number}]";
            setDefaultBackColor();
            BackColor = defaultBackColor;
            counter++;
        }

        private string getImageLink(YoutubeEntry entry)
        {
            return $"http://i3.ytimg.com/vi/{entry.VideoID}/mqdefault.jpg";
        }

        private void setDefaultBackColor()
        {
            defaultBackColor = counter % 2 == 0 ? SystemColors.Control : SystemColors.ControlLight;
        }

        public void EntryPresenter_Click(object sender, EventArgs e)
        {
            if (this != Selected)
            {
                BackColor = Color.LightSteelBlue;
                if (Selected != null) Selected.BackColor = Selected.defaultBackColor;
                Selected = this;
            }
        }

        private void EntryPresenter_Load(object sender, EventArgs e)
        {
            Click += OnSeletion;
            RegisterMouseEvents(Controls);
        }

        private void RegisterMouseEvents(ControlCollection controls)
        {
            foreach (Control control in controls)
            {
                control.Click += OnSeletion;
                if (control.HasChildren) RegisterMouseEvents(control.Controls);
            }
        }

        public Image GetImage()
        {
            return ThumbnailPictureBox.Image;
        }

        private void EntryPresenter_Paint(object sender, PaintEventArgs e)
        {
            StatusBar.BackColor = DisplayedEntry.IsPosted ? Color.Lime : Color.Red;
        }
    }
}
