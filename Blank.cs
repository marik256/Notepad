using System;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Notepad
{
    internal partial class Blank : Form
    {
        private bool _isSaved;
        private bool _isBlocked = false;
        private string _pagePath = "";
        private string _pageName = "";
        private string _pageFormat = ".txt";
        private readonly int _pageNumber;
        private readonly Menu _menu;
        private readonly string _numberOfCharactersLable;
        private readonly string _formatLable;

        internal SearchBox SearchBox { get; set; }

        internal string PageName => _pageName;

        internal Blank(Menu menu)
        {
            InitializeComponent();

            _menu = menu;
            MdiParent = menu;
            _pageNumber = menu.GetNumberOfMdiChildren() - menu.NumberOfSearhBoxInstance;

            _pageName = "Сторінка " + _pageNumber;
            Text = _pageName;
            _isSaved = false;
            
            richTextBox.Modified = false;

            _numberOfCharactersLable = "Кількість символів: ";
            _formatLable = "Формат: ";

            amountToolStripStatusLabel.Text = _numberOfCharactersLable + 
                                              richTextBox.Text.Length.ToString();
            formatToolStripStatusLabel.Text = _formatLable + _pageFormat;
        }

        internal void Cut()
        {
            if (!string.IsNullOrEmpty(richTextBox.SelectedText))
            {
                Clipboard.SetDataObject(richTextBox.SelectedText);
                richTextBox.SelectedText = "";
            }
        }

        internal void Copy()
        {
            if (!string.IsNullOrEmpty(richTextBox.SelectedText))
            {
                Clipboard.SetDataObject(richTextBox.SelectedText);
            }
        }

        internal void Paste()
        {
            IDataObject dataObject = Clipboard.GetDataObject();
            if (dataObject.GetDataPresent(DataFormats.Text))
            {
                richTextBox.SelectedText = (string)dataObject.GetData(DataFormats.Text);
            }
            else
            {
                return;
            }
        }

        internal void SelectAll()
        {
            richTextBox.SelectAll();
        }

        internal void Delete()
        {
            richTextBox.SelectedText = "";
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
            _pagePath = pagePath;
            _pageFormat = Path.GetExtension(pagePath);
            formatToolStripStatusLabel.Text = _formatLable + _pageFormat;
            _pageName = _pagePath;
            Text = _pageName;
            ReadFromFileToRichTextBox();
            _isBlocked = true;
            Show();
            richTextBox.Modified = false;
            _isBlocked = false;
        }

        private void WriteToRTF()
        {
            richTextBox.SaveFile(_pagePath, RichTextBoxStreamType.RichText);
            richTextBox.Modified = false;
        }
        
        private void WriteToTXT()
        {
            richTextBox.SaveFile(_pagePath, RichTextBoxStreamType.PlainText);
            richTextBox.Modified = false;
        }

        private void WriteToFileFromRichTextBox()
        {
            if (Path.GetExtension(_pagePath) == ".rtf")
            {
                WriteToRTF();
            }

            if (Path.GetExtension(_pagePath) == ".txt")
            {
                WriteToTXT();
            }
        }

        private void ReadFromRTF()
        {
            _isBlocked = true;
            richTextBox.LoadFile(_pagePath, RichTextBoxStreamType.RichText);
            richTextBox.Modified = false;
            _isBlocked = false;
        }

        private void ReadFromTXT()
        {
            _isBlocked = true;
            richTextBox.LoadFile(_pagePath, RichTextBoxStreamType.PlainText);
            richTextBox.Modified = false;
            _isBlocked = false;
        }

        private void ReadFromFileToRichTextBox()
        {
            if (Path.GetExtension(_pagePath) == ".rtf")
            {
                ReadFromRTF();
            }

            if (Path.GetExtension(_pagePath) == ".txt")
            {
                ReadFromTXT();
            }
        }

        internal void Save()
        {
            if (!_isSaved)
            {
                WriteToFileFromRichTextBox();
                UnmarkPage();
                _isSaved = true;
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

        internal void ChangeColor()
        {
            if (string.IsNullOrEmpty(richTextBox.SelectedText))
            {
                if (colorDialog.ShowDialog() == DialogResult.OK)
                {
                    richTextBox.ForeColor = colorDialog.Color;
                }
            }
            else
            {
                colorDialog.Color = richTextBox.SelectionColor;
                if (colorDialog.ShowDialog() == DialogResult.OK)
                {
                    richTextBox.SelectionColor = colorDialog.Color;
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
            if (Text[0] != '*')
            {
                Text = _pageName.Insert(0, "*");
            }
        }

        internal void UnmarkPage()
        {
            if (Text[0] == '*')
            {
                Text = Text.Remove(0, 1);
            }
        }

        private void RichTextBox_ModifiedChanged(object sender, EventArgs e)
        {
            if (richTextBox.Modified == false || _isBlocked)
            {
                return;
            }

            MarkPage();
            _isSaved = false;
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

        private void Blank_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (SearchBox != null)
            {
                SearchBox.Close();
            }
        }

        private void Blank_Activated(object sender, EventArgs e)
        {
            if (_isSaved)
                _menu.EnableItemsAfterSaveBlank();
            else
                _menu.DisableItemsBeforeSaveBlank();
        }

        private void FontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeFont();
        }

        private void FontColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeColor();
        }

        private void RichTextBox_TextChanged(object sender, EventArgs e)
        {
            amountToolStripStatusLabel.Text = _numberOfCharactersLable +
                                              " " + 
                                              richTextBox.Text.Length.ToString();
        }

        private void SearchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SearchBox == null)
            {
                new SearchBox(_menu, this);
            }
        }

        internal Match SearchInRichTextBox(Regex regex, int initialIndex)
        {
            return regex.Match(richTextBox.Text, initialIndex);
        }

        internal void ClearHighlight()
        {
            _isBlocked = true;
            richTextBox.SelectAll();
            richTextBox.SelectionBackColor = Color.White;
            richTextBox.DeselectAll();
            richTextBox.Modified = false;
            _isBlocked = false;
        }

        internal void HighlightSearchString(int initialIndex, int lenght)
        {
            _isBlocked = true;
            richTextBox.Select(initialIndex, lenght);
            richTextBox.SelectionBackColor = Color.Yellow;
            richTextBox.Modified = false;
            _isBlocked = false;
        }

        internal void SetIsSaved()
        {
            if(string.IsNullOrEmpty(_pagePath))
            {
                _isSaved = true;
            }
        }
    }
}
