using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Notepad
{
    internal partial class Blank : Form
    {
        private bool _isSaved;
        private string _pagePath = "";
        private string _pageName = "";
        private string _pageFormat = ".txt";
        private readonly int _pageNumber;
        private readonly Menu _menu;
        private readonly string _numberOfCharactersLable;
        private readonly string _formatLable;

        internal bool IsBlocked { get; private set; } = false;

        internal SearchBox SearchBox { get; private set; }

        internal Blank(Menu menu)
        {
            InitializeComponent();

            _menu = menu;
            MdiParent = menu;
            _pageNumber = menu.GetNumberOfBlanks();

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

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cut();
        }

        internal void Copy()
        {
            if (!string.IsNullOrEmpty(richTextBox.SelectedText))
            {
                Clipboard.SetDataObject(richTextBox.SelectedText);
            }
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Copy();
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

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Paste();
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

            IsBlocked = true;
            Show();
            richTextBox.Modified = false;
            IsBlocked = false;
        }

        internal void ShowSearch()
        {
            if (SearchBox != null)
            {
                return;
            }
            
            SearchBox = new SearchBox(_pageName)
            {
                MdiParent = _menu
            };
            SearchBox.FormClosing += SearchBoxClosing;
            SearchBox.FormClosed += SearchBoxClosed;
            SearchBox.SearchTextBox.TextChanged += SearchTextBoxTextChanged;
            SearchBox.RegisterCheckBox.CheckedChanged += RegisterCheckBoxCheckedChanged;
            SearchBox.FullWordCheckBox.CheckedChanged += FullWordCheckBoxCheckedChanged;

            SearchBox.Show();

            void SearchBoxClosing(object sender, FormClosingEventArgs e)
            {
                ClearHighlight();
                SearchBox.FormClosing -= SearchBoxClosing;
                SearchBox.SearchTextBox.TextChanged -= SearchTextBoxTextChanged;
                SearchBox.RegisterCheckBox.CheckedChanged -= RegisterCheckBoxCheckedChanged;
                SearchBox.FullWordCheckBox.CheckedChanged -= FullWordCheckBoxCheckedChanged;
            }

            void SearchBoxClosed(object sender, FormClosedEventArgs e)
            {
                SearchBox.FormClosed -= SearchBoxClosed;
                SearchBox = null;
            }

            void SearchTextBoxTextChanged(object sender, EventArgs e)
            {
                SearchInRichTextBox();
            }

            void RegisterCheckBoxCheckedChanged(object sender, EventArgs e)
            {
                SearchInRichTextBox();
            }

            void FullWordCheckBoxCheckedChanged(object sender, EventArgs e)
            {
                SearchInRichTextBox();
            }
        }

        private RichTextBoxStreamType? GetCurrentRichTextBoxStreamFileType()
        {
            switch (Path.GetExtension(_pagePath))
            {
                case ".rtf":
                    return RichTextBoxStreamType.RichText;
                case ".txt":
                    return RichTextBoxStreamType.PlainText;
                default:
                    return null;
            }
        }

        private void ProcessRichTextBoxContent(Action<RichTextBoxStreamType> processContent)
        {
            var currentStreamType = GetCurrentRichTextBoxStreamFileType();
            if (currentStreamType != null)
            {
                processContent(currentStreamType.Value);
            }
        }

        private void ReadFromFileToRichTextBox()
        {
            ProcessRichTextBoxContent(fileType =>
            {
                IsBlocked = true;
                richTextBox.LoadFile(_pagePath, fileType);
                richTextBox.Modified = false;
                IsBlocked = false;
            });
        }

        private void WriteToFileFromRichTextBox()
        {
            ProcessRichTextBoxContent(fileType =>
            {
                IsBlocked = true;
                richTextBox.SaveFile(_pagePath, fileType);
                richTextBox.Modified = false;
                IsBlocked = false;
            });
        }

        internal void UnmarkPage()
        {
            if (Text[0] == '*')
            {
                Text = Text.Remove(0, 1);
            }
        }

        private void MarkPage()
        {
            if (Text[0] != '*')
            {
                Text = _pageName.Insert(0, "*");
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

        private Font PeekFont(Font currentFont)
        {
            fontDialog.Font = currentFont;
            DialogResult result = fontDialog.ShowDialog();
            return result == DialogResult.OK ? fontDialog.Font : currentFont;
        }

        internal void ChangeFont()
        {
            if (string.IsNullOrEmpty(richTextBox.SelectedText))
            {
                richTextBox.Font = PeekFont(richTextBox.Font);
            }
            else
            {
                richTextBox.SelectionFont = PeekFont(richTextBox.SelectionFont);
            }
        }

        private void FontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeFont();
        }

        private Color PeekColor(Color currentColor)
        {
            colorDialog.Color = currentColor;
            DialogResult result = colorDialog.ShowDialog();
            return result == DialogResult.OK ? colorDialog.Color : currentColor;
        }

        internal void ChangeColor()
        {
            if (string.IsNullOrEmpty(richTextBox.SelectedText))
            {
                richTextBox.ForeColor = PeekColor(richTextBox.ForeColor);
            }
            else
            {
                richTextBox.SelectionColor = PeekColor(richTextBox.SelectionColor);
            }
        }

        private void FontColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeColor();
        }

        private void RichTextBox_ModifiedChanged(object sender, EventArgs e)
        {
            if (richTextBox.Modified == false || IsBlocked)
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

            if (_menu.GetNumberOfBlanks() == 1)
            {
                _menu.DisableAllControlsRelatedToBlank();
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
            if (IsBlocked)
            {
                return;
            }

            if (_isSaved)
                _menu.EnableControlsAfterSaveBlank();
            else
                _menu.DisableControlsBeforeSaveBlank();
        }

        private void RichTextBox_TextChanged(object sender, EventArgs e)
        {
            amountToolStripStatusLabel.Text = _numberOfCharactersLable +
                                              " " + 
                                              richTextBox.Text.Length.ToString();
        }

        private void SearchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SearchBox is null)
            {
                ShowSearch();
            }
        }

        private void ClearHighlight()
        {
            IsBlocked = true;
            richTextBox.SelectAll();
            richTextBox.SelectionBackColor = Color.White;
            richTextBox.DeselectAll();
            richTextBox.Modified = false;
            IsBlocked = false;
        }

        private void HighlightSearchString(int initialIndex, int lenght)
        {
            IsBlocked = true;
            richTextBox.Select(initialIndex, lenght);
            richTextBox.SelectionBackColor = Color.Yellow;
            richTextBox.DeselectAll();
            richTextBox.Modified = false;
            IsBlocked = false;
        }

        private void SearchInRichTextBox()
        {
            ClearHighlight();

            foreach(var search in SearchBox.Search(richTextBox.Text))
            {
                HighlightSearchString(search.Index, search.Length);
            }
        }
    }
}
