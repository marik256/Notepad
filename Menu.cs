using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Notepad
{
    public partial class Menu : Form
    {
        private readonly List<ToolStripMenuItem> _allItemsRelatedToBlank;
        private readonly List<ToolStripMenuItem> _allItemsRelatedToSaveBlank;

        internal int NumberOfSearhBoxInstance { get; set; } = 0;

        internal Menu()
        {
            InitializeComponent();

            _allItemsRelatedToBlank = new List<ToolStripMenuItem>
            {
                saveToolStripMenuItem,
                saveAsToolStripMenuItem,
                printToolStripMenuItem,
                previewToolStripMenuItem,
                undoToolStripMenuItem,
                redoToolStripMenuItem,
                cutToolStripMenuItem,
                copyToolStripMenuItem,
                pasteToolStripMenuItem,
                selectAllToolStripMenuItem,
                deleteToolStripMenuItem,
                fontToolStripMenuItem,
                fontColorStripMenuItem,
                searchToolStripMenuItem
            };

            _allItemsRelatedToSaveBlank = new List<ToolStripMenuItem>
            {
                saveToolStripMenuItem
            };
        }

        internal void DisableAllItemsRelatedToBlank()
        {
            foreach (var stripItem in _allItemsRelatedToBlank)
            {
                stripItem.Enabled = false;
            }
        }

        internal void DisableItemsBeforeSaveBlank()
        {
            foreach (var stripItem in _allItemsRelatedToSaveBlank)
            {
                stripItem.Enabled = false;
            }
        }

        private void EnableAllItemsRelatedToBlank()
        {
            foreach (var stripItem in _allItemsRelatedToBlank)
            {
                stripItem.Enabled = true;
            }
        }

        internal void EnableItemsAfterSaveBlank()
        {
            foreach (var stripItem in _allItemsRelatedToSaveBlank)
            {
                stripItem.Enabled = true;
            }
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
            DisableItemsBeforeSaveBlank();
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
                EnableAllItemsRelatedToBlank();
            }
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
            EnableItemsAfterSaveBlank();
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

        private void FontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Blank blank = (Blank)ActiveMdiChild;
            blank.ChangeFont();
        }

        private void FontColorStripMenuItem_Click(object sender, EventArgs e)
        {
            Blank blank = (Blank)ActiveMdiChild;
            blank.ChangeColor();
        }

        private void SearchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ActiveMdiChild.GetType() != typeof(Blank))
            {
                return;
            }

            new SearchBox(this, (Blank)ActiveMdiChild);
        }
    }
}
