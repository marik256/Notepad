using System;
using System.IO;
using System.Windows.Forms;

namespace Notepad
{
    internal partial class Blank : Form
    {
        private bool _isSaved;
        private string _bufferText = "";
        private string _pagePath = "";
        private string _pageName = "";
        private readonly int _pageNumber;
        private readonly Menu _menu;

        internal Blank(Menu menu)
        {
            InitializeComponent();
            this._menu = menu;
            MdiParent = menu;
            _pageNumber = menu.GetNumberOfMdiChildren();
            _pageName = "Сторінка " + _pageNumber;
            Text = _pageName;
            _isSaved = false;
            richTextBox.Modified = false;
        }

        internal void Cut()
        {
            if (!string.IsNullOrEmpty(richTextBox.SelectedText))
            {
                _bufferText = richTextBox.SelectedText;
                richTextBox.SelectedText = "";
            }
        }

        internal void Copy()
        {
            if (!string.IsNullOrEmpty(richTextBox.SelectedText))
            {
                _bufferText = richTextBox.SelectedText;
            }
        }

        internal void Paste()
        {
            richTextBox.SelectedText = _bufferText;
        }

        internal void SelectAll()
        {
            richTextBox.SelectAll();
        }

        internal void Delete()
        {
            richTextBox.SelectedText = "";
            _bufferText = "";
        }

        internal void Undo()
        {
            richTextBox.Undo();
        }

        internal void Redo()
        {
            richTextBox.Redo();
        }

        internal void Open(string pagePath)
        {
            _isSaved = true;
            this._pagePath = pagePath;
            _pageName = this._pagePath;
            Text = _pageName;
            ReadFromFileToRichTextBox();
            Show();
        }

        private void WriteToFileFromRichTextBox()
        {
            using (StreamWriter writer = new StreamWriter(_pagePath, false))
            {
                writer.WriteLine(richTextBox.Text);
            }
            richTextBox.Modified = false;
        }

        private void ReadFromFileToRichTextBox()
        {
            using (StreamReader reader = new StreamReader(_pagePath))
            {
                richTextBox.Text = reader.ReadToEnd();
            }
        }

        internal void Save()
        {
            if (!_isSaved)
            {
                WriteToFileFromRichTextBox();
                UnmarkPage();
            }
        }

        internal void SaveAs()
        {
            if(saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                _isSaved = true;
                _pagePath = saveFileDialog.FileName;
                _pageName = _pagePath;
                Text = _pageName;
                WriteToFileFromRichTextBox();
            }
        }

        internal void ChangeFont()
        {
            if (string.IsNullOrEmpty(richTextBox.SelectedText))
            {
                if (fontDialog.ShowDialog() == DialogResult.OK)
                {
                    richTextBox.Font = fontDialog.Font;
                }
            }
            else
            {
                fontDialog.Font = richTextBox.SelectionFont;
                if (fontDialog.ShowDialog() == DialogResult.OK)
                {
                    richTextBox.SelectionFont = fontDialog.Font;
                }
            }
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cut();
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Copy();
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Paste();
        }

        private void MarkPage()
        {
            _pageName = _pageName.Insert(0, "*");
            Text = _pageName;
            _isSaved = false;
        }

        private void UnmarkPage()
        {
            _pageName = _pageName.Remove(0, 1);
            Text = _pageName;
            _isSaved = true;
        }

        private void RichTextBox_ModifiedChanged(object sender, EventArgs e)
        {
            if (richTextBox.Modified == false)
            {
                return;
            }

            MarkPage();
        }

        private void Blank_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!_isSaved)
            {
                DialogResult result = MessageBox.Show(
                    "Зберегти внесені зміни до файлу?", 
                    "Notepad", 
                    MessageBoxButtons.YesNoCancel, 
                    MessageBoxIcon.Exclamation);

                if (result == DialogResult.Yes)
                {
                    if (String.IsNullOrEmpty(_pagePath))
                        SaveAs();
                    else
                        Save();
                }

                if (result == DialogResult.Cancel)
                {
                    e.Cancel = true;
                }
            }

            if (_menu.GetNumberOfMdiChildren() == 1)
            {
                _menu.DisableAllItemsRelatedToBlank();
            }
        }

        private void Blank_Activated(object sender, EventArgs e)
        {
            if (_isSaved)
                _menu.EnableItemsAfterSavePage();
            else
                _menu.DisableItemsBeforeSavePage();
        }

        private void FontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeFont();
        }
    }
}
