using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Threading;

namespace WordpressDesktopClient
{
    public partial class Dashboard : Form
    {

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        private const int CS_DROPSHADOW = 0x20000;

        private BlogEntry selected;
        private DataManager manager;
        private EntryPresenter displayed;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        public Dashboard()
        {
            InitializeComponent();
            manager = new DataManager();
        }



        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ClassStyle |= CS_DROPSHADOW;
                return cp;
            }
        }

        private void moveWindow(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void minimizeButton_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            loadTagTreeView();
            SplashScreen.CloseSplash();
        }

        private void handlePanelSelection(object sender, EventArgs e)
        {
            if (infoLabel.Visible)
            {
                infoLabel.Hide();
                actionButton.Show();
            }
            foreach (var node in collect(treeViewCategories.Nodes))
            {
                node.Checked = false;
            }
            Control control = sender as Control;
            while (control.GetType() != typeof(EntryPresenter))
            {
                control = control.Parent;
            }
            if (control.GetType() == typeof(EntryPresenter))
            {
                displayed = control as EntryPresenter;
                selected = displayed.DisplayedEntry;
            }
                
            pictureBoxThumbnail.Image = displayed.GetImage();
            textBoxTitle.Text = selected.Title;
            textBoxDescription.Text = selected.Description;
            numberLabel.Text = selected.Number.ToString();

            if (selected.IsPosted)
            {
                actionButton.Enabled = false;
                foreach (Tag node in collect(treeViewCategories.Nodes))
                {
                    foreach(int tagID in selected.TagIds)
                    {
                        if (node.TagID == tagID) node.Checked = true;
                    }
                }
            }
            else
            {
                actionButton.Enabled = true;
            }
        }

        private IEnumerable<TreeNode> collect(TreeNodeCollection nodes)
        {
            foreach (TreeNode node in nodes)
            {
                yield return node;

                foreach (var child in collect(node.Nodes))
                    yield return child;
            }
        }

        private void actionButton_Click(object sender, EventArgs e)
        {
            foreach (Tag node in collect(treeViewCategories.Nodes))
            {
                if(node.Checked) selected.TagIds.Add(node.TagID);
            }
            if (selected.TagIds.Count == 0)
            {
                MessageBox.Show("Nie wybrano kategorii.","Błąd");
                return;
            }
            manager.publish(selected);
            actionButton.Enabled = false;
            displayed.Invalidate();
        }

        private void TextBoxChanged(object sender, EventArgs e)
        {
            if(sender!=null)
            {
                if(sender.GetType().Name == "RichTextBox")
                {
                    RichTextBox current = sender as RichTextBox;
                    if(current.Text!=selected.Title)
                        selected.Description = current.Text;
                }
                else if (sender.GetType().Name == "TextBox")
                {
                    TextBox current = sender as TextBox;
                    if (current.Text != selected.Description)
                        selected.Title = current.Text;
                }
            }
        }

        private void loadTagTreeView()
        {
            List<Tag> tags = manager.GetTags();

            foreach (var t1 in tags)
            {
                if (t1.ParentID == 0)
                {
                    treeViewCategories.Nodes.Add(t1);
                    foreach (var t2 in tags)
                    {
                        if (t2.ParentID == t1.TagID)
                        {
                            t1.Nodes.Add(t2);
                            t1.Expand();
                        }
                    }
                }
            }
        }
    }
}
