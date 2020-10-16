using System;
using System.Windows.Forms;

namespace Notepad
{
    internal partial class Menu : Form
    {
        internal Menu()
        {
            InitializeComponent();
        }

        internal void DisableAllItemsRelatedToBlank()
        {
            saveToolStripMenuItem.Enabled = false;
            saveAsToolStripMenuItem.Enabled = false;
            printToolStripMenuItem.Enabled = false;
            previewToolStripMenuItem.Enabled = false;
            undoToolStripMenuItem.Enabled = false;
            redoToolStripMenuItem1.Enabled = false;
            cutToolStripMenuItem.Enabled = false;
            copyToolStripMenuItem.Enabled = false;
            pasteToolStripMenuItem.Enabled = false;
            selectAllToolStripMenuItem.Enabled = false;
            deleteToolStripMenuItem.Enabled = false;
        }

        internal void DisableItemsBeforeSavePage()
        {
            saveToolStripMenuItem.Enabled = false;
        }

        private void EnableAllItemsRelatedToBlank()
        {
            saveToolStripMenuItem.Enabled = true;
            saveAsToolStripMenuItem.Enabled = true;
            printToolStripMenuItem.Enabled = true;
            previewToolStripMenuItem.Enabled = true;
            undoToolStripMenuItem.Enabled = true;
            redoToolStripMenuItem1.Enabled = true;
            cutToolStripMenuItem.Enabled = true;
            copyToolStripMenuItem.Enabled = true;
            pasteToolStripMenuItem.Enabled = true;
            selectAllToolStripMenuItem.Enabled = true;
            deleteToolStripMenuItem.Enabled = true;
        }

        internal void EnableItemsAfterSavePage()
        {
            saveToolStripMenuItem.Enabled = true;
        }

        internal int GetNumberOfMdiChildren()
        {
            return MdiChildren.Length;
        }

        private void CreateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Blank blank = new Blank(this);
            blank.Show();
            EnableAllItemsRelatedToBlank();
            DisableItemsBeforeSavePage();
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void HorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void VerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void UndoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Blank blank = (Blank)ActiveMdiChild;
            blank.Undo();
        }

        private void RedoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Blank blank = (Blank)ActiveMdiChild;
            blank.Redo();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Blank blank = (Blank)ActiveMdiChild;
            blank.Cut();
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Blank blank = (Blank)ActiveMdiChild;
            blank.Copy();
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Blank blank = (Blank)ActiveMdiChild;
            blank.Paste();
        }

        private void SelectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Blank blank = (Blank)ActiveMdiChild;
            blank.SelectAll();
        }

        private void DeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Blank blank = (Blank)ActiveMdiChild;
            blank.Delete();
        }

        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                Blank blank = new Blank(this);
                blank.Open(openFileDialog.FileName);
            }
            EnableAllItemsRelatedToBlank();
        }

        internal void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Blank blank = (Blank)ActiveMdiChild;
            blank.Save();
        }

        internal void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Blank blank = (Blank)ActiveMdiChild;
            blank.SaveAs();
            EnableItemsAfterSavePage();
        }
        
        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            DisableAllItemsRelatedToBlank();
        }

        private void Menu_Click(object sender, EventArgs e)
        {
            DisableAllItemsRelatedToBlank();
        }
    }
}
