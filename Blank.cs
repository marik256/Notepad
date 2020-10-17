using System;
using System.IO;
using System.Windows.Forms;

namespace Notepad
{
    internal partial class Blank : Form
    {
        private bool isSaved;
        private string bufferText = "";
        private string pagePath = "";
        private string pageName = "";
        private readonly int pageNumber;
        private readonly Menu menu;

        internal Blank(Menu menu)
        {
            InitializeComponent();
            this.menu = menu;
            MdiParent = menu;
            pageNumber = menu.GetNumberOfMdiChildren();
            pageName = "Сторінка " + pageNumber;
            Text = pageName;
            isSaved = false;
            richTextBox.Modified = false;
        }

        internal void Cut()
        {
            if (!string.IsNullOrEmpty(richTextBox.SelectedText))
            {
                bufferText = richTextBox.SelectedText;
                richTextBox.SelectedText = "";
            }
        }

        internal void Copy()
        {
            if (!string.IsNullOrEmpty(richTextBox.SelectedText))
            {
                bufferText = richTextBox.SelectedText;
            }
        }

        internal void Paste()
        {
            richTextBox.SelectedText = bufferText;
        }

        internal void SelectAll()
        {
            richTextBox.SelectAll();
        }

        internal void Delete()
        {
            richTextBox.SelectedText = "";
            bufferText = "";
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
            isSaved = true;
            this.pagePath = pagePath;
            pageName = this.pagePath;
            Text = pageName;
            ReadFromFileToRichTextBox();
            Show();
        }

        private void WriteToFileFromRichTextBox()
        {
            using (StreamWriter writer = new StreamWriter(pagePath, false))
            {
                writer.WriteLine(richTextBox.Text);
            }
            richTextBox.Modified = false;
        }

        private void ReadFromFileToRichTextBox()
        {
            using (StreamReader reader = new StreamReader(pagePath))
            {
                richTextBox.Text = reader.ReadToEnd();
            }
        }

        internal void Save()
        {
            if (!isSaved)
            {
                WriteToFileFromRichTextBox();
                UnmarkPage();
            }
        }

        internal void SaveAs()
        {
            if(saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                isSaved = true;
                pagePath = saveFileDialog.FileName;
                pageName = pagePath;
                Text = pageName;
                WriteToFileFromRichTextBox();
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
            pageName = pageName.Insert(0, "*");
            Text = pageName;
            isSaved = false;
        }

        private void UnmarkPage()
        {
            pageName = pageName.Remove(0, 1);
            Text = pageName;
            isSaved = true;
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
            if (!isSaved)
            {
                DialogResult result = MessageBox.Show(
                    "Зберегти внесені зміни до файлу?", 
                    "Notepad", 
                    MessageBoxButtons.YesNoCancel, 
                    MessageBoxIcon.Exclamation);

                if (result == DialogResult.Yes)
                {
                    if (String.IsNullOrEmpty(pagePath))
                        SaveAs();
                    else
                        Save();
                }

                if (result == DialogResult.Cancel)
                {
                    e.Cancel = true;
                }
            }

            if (menu.GetNumberOfMdiChildren() == 1)
            {
                menu.DisableAllItemsRelatedToBlank();
            }
        }

        private void Blank_Activated(object sender, EventArgs e)
        {
            if (isSaved)
                menu.EnableItemsAfterSavePage();
            else
                menu.DisableItemsBeforeSavePage();
        }
    }
}
