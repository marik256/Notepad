using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Notepad
{
    public partial class Menu : Form
    {
        private readonly List<ToolStripMenuItem> _allItemsRelatedToBlank;
        private readonly List<ToolStripButton> _allButtonsRelatedToBlank;
        private readonly List<ToolStripMenuItem> _allItemsRelatedToSaveBlank;
        private readonly List<ToolStripButton> _allButtonsRelatedToSaveBlank;

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

            _allButtonsRelatedToBlank = new List<ToolStripButton>
            {
                saveToolStripButton,
                cutToolStripButton,
                copyToolStripButton,
                pasteToolStripButton
            };

            _allItemsRelatedToSaveBlank = new List<ToolStripMenuItem>
            {
                saveToolStripMenuItem
            };

            _allButtonsRelatedToSaveBlank = new List<ToolStripButton>
            {
                saveToolStripButton
            };
        }

        internal void DisableAllControlsRelatedToBlank()
        {
            foreach (var stripItem in _allItemsRelatedToBlank)
            {
                stripItem.Enabled = false;
            }

            foreach (var stripButton in _allButtonsRelatedToBlank)
            {
                stripButton.Enabled = false;
            }
        }

        internal void DisableControlsBeforeSaveBlank()
        {
            foreach (var stripItem in _allItemsRelatedToSaveBlank)
            {
                stripItem.Enabled = false;
            }

            foreach (var stripButton in _allButtonsRelatedToSaveBlank)
            {
                stripButton.Enabled = false;
            }
        }

        private void EnableAllControlsRelatedToBlank()
        {
            foreach (var stripItem in _allItemsRelatedToBlank)
            {
                stripItem.Enabled = true;
            }

            foreach (var stripButton in _allButtonsRelatedToBlank)
            {
                stripButton.Enabled = true;
            }
        }

        internal void EnableControlsAfterSaveBlank()
        {
            foreach (var stripItem in _allItemsRelatedToSaveBlank)
            {
                stripItem.Enabled = true;
            }

            foreach (var stripButton in _allButtonsRelatedToSaveBlank)
            {
                stripButton.Enabled = true;
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
            EnableAllControlsRelatedToBlank();
            DisableControlsBeforeSaveBlank();
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
                EnableAllControlsRelatedToBlank();
            }
        }

        internal void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ActiveMdiChild.GetType() != typeof(Blank))
            {
                return;
            }

            Blank blank = (Blank)ActiveMdiChild;
            blank.Save();
        }

        internal void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ActiveMdiChild.GetType() != typeof(Blank))
            {
                return;
            }

            Blank blank = (Blank)ActiveMdiChild;
            blank.SaveAs();
            EnableControlsAfterSaveBlank();
        }
        
        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            DisableAllControlsRelatedToBlank();
        }

        private void Menu_Click(object sender, EventArgs e)
        {
            DisableAllControlsRelatedToBlank();
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

            Blank _blank = (Blank)ActiveMdiChild;
            if (_blank.SearchBox == null)
            {
                new SearchBox(this, (Blank)ActiveMdiChild);
            }
        }

        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About about = new About(this);
            about.Show();
        }

        private void CreateToolStripButton_Click(object sender, EventArgs e)
        {
            Blank blank = new Blank(this);
            blank.Show();
            EnableAllControlsRelatedToBlank();
            DisableControlsBeforeSaveBlank();
        }

        private void OpenToolStripButton_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                Blank blank = new Blank(this);
                blank.Open(openFileDialog.FileName);
                EnableAllControlsRelatedToBlank();
            }
        }

        private void SaveToolStripButton_Click(object sender, EventArgs e)
        {
            if (ActiveMdiChild.GetType() != typeof(Blank))
            {
                return;
            }

            Blank blank = (Blank)ActiveMdiChild;
            blank.Save();
        }

        private void CutToolStripButton_Click(object sender, EventArgs e)
        {
            Blank blank = (Blank)ActiveMdiChild;
            blank.Cut();
        }

        private void CopyToolStripButton_Click(object sender, EventArgs e)
        {
            Blank blank = (Blank)ActiveMdiChild;
            blank.Copy();
        }

        private void PasteToolStripButton_Click(object sender, EventArgs e)
        {
            Blank blank = (Blank)ActiveMdiChild;
            blank.Paste();
        }

        private void AboutToolStripButton_Click(object sender, EventArgs e)
        {
            About about = new About(this);
            about.Show();
        }
    }
}
