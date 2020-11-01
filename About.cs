using System;
using System.Windows.Forms;

namespace Notepad
{
    public partial class About : Form
    {
        private readonly string link = "https://github.com/marslaw/Notepad";

        public About(Menu menu)
        {
            InitializeComponent();
            MdiParent = menu;
        }

        private void AboutLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenLink();
        }

        internal void OpenLink()
        {
            githubLinkLabel.LinkVisited = true;
            System.Diagnostics.Process.Start(link);
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
