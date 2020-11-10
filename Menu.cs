using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;

namespace Notepad
{
    public partial class Menu : Form
    {
        private readonly List<ToolStripMenuItem> _allItemsRelatedToBlank;
        private readonly List<ToolStripButton> _allButtonsRelatedToBlank;
        private readonly List<ToolStripMenuItem> _allItemsRelatedToSaveBlank;
        private readonly List<ToolStripButton> _allButtonsRelatedToSaveBlank;

        private Blank ActiveBlank => ActiveMdiChild as Blank;

        internal Menu()
        {
            InitializeComponent();
            openIcoToolStripMenuItem.Enabled = false;

            _allItemsRelatedToBlank = new List<ToolStripMenuItem>
            {
                saveToolStripMenuItem,
                saveAsToolStripMenuItem,
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

        internal int GetNumberOfBlanks()
        {
            return MdiChildren.OfType<Blank>().Count();
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
            ActiveBlank?.Undo();
        }

        private void RedoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ActiveBlank?.Redo();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ActiveBlank?.Cut();
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ActiveBlank?.Copy();
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ActiveBlank?.Paste();
        }

        private void SelectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ActiveBlank?.SelectAll();
        }

        private void DeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ActiveBlank?.Delete();
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
            ActiveBlank?.Save();
        }

        internal void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ActiveBlank?.SaveAs();
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
            ActiveBlank?.ChangeFont();
        }

        private void FontColorStripMenuItem_Click(object sender, EventArgs e)
        {
            ActiveBlank?.ChangeColor();
        }

        private void SearchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ActiveBlank?.ShowSearch();
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
            ActiveBlank?.Save();
        }

        private void CutToolStripButton_Click(object sender, EventArgs e)
        {
            ActiveBlank?.Cut();
        }

        private void CopyToolStripButton_Click(object sender, EventArgs e)
        {
            ActiveBlank?.Copy();
        }

        private void PasteToolStripButton_Click(object sender, EventArgs e)
        {
            ActiveBlank?.Paste();
        }

        private void AboutToolStripButton_Click(object sender, EventArgs e)
        {
            About about = new About(this);
            about.Show();
        }

        private void PaintToolStripButton_Click(object sender, EventArgs e)
        {
            Process process = new Process();
            process.StartInfo.FileName = "C:\\Windows\\system32\\mspaint.exe";
            process.Start();
        }

        private void OpenIcoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Show();
            openIcoToolStripMenuItem.Enabled = false;
            hideIcoToolStripMenuItem.Enabled = true;
        }

        private void HideIcoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hide();
            openIcoToolStripMenuItem.Enabled = true;
            hideIcoToolStripMenuItem.Enabled = false;
        }

        private void RandNumGenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RandNumGen generator = new RandNumGen();
            generator.Show();
        }
    }
}
