using System.Collections.Generic;
using System.Windows.Forms;

namespace Notepad
{
    public partial class Translator : Form
    {
        private List<string> terms = new List<string>();
        private List<string> definitions = new List<string>();

        internal Translator(Menu menu)
        {
            InitializeComponent();
            sourceLangComboBox.SelectedItem = "англійська";
            targetLangComboBox.SelectedItem = "українська";
            MdiParent = menu;
        }

        private string GetLanguageCode(string language)
        {
            switch (language)
            {
                case "українська":
                    return "uk";
                case "російська":
                    return "ru";
                case "англійська":
                    return "en";
                case "іспанська":
                    return "es";
                case "німецька":
                    return "de";
                case "французька":
                    return "fr";
                case "польська":
                    return "pl";
                default:
                    return null;
            }
        }

        private void TranslateButton_Click(object sender, System.EventArgs e)
        {
            if (sourceLangRichTextBox.Text == "")
                return;

            targetLangRichTextBox.Text = Translation.GetTranslatedText(
                sourceLangRichTextBox.Text,
                GetLanguageCode(sourceLangComboBox.SelectedItem.ToString()),
                GetLanguageCode(targetLangComboBox.SelectedItem.ToString())
            );
        }

        private void RefreshListView()
        {
            listView.Items.Clear();
            for (int i = 0; i < terms.Count; i++)
            {
                var item = new ListViewItem(terms[i]);
                item.SubItems.Add(definitions[i]);
                listView.Items.Add(item);
            }
        }

        private void AddButton_Click(object sender, System.EventArgs e)
        {
            if (sourceLangRichTextBox.Text == "" || targetLangRichTextBox.Text == "")
                return;

            terms.Add(sourceLangRichTextBox.Text);
            definitions.Add(targetLangRichTextBox.Text);
            RefreshListView();
        }

        private void ExportButton_Click(object sender, System.EventArgs e)
        {
            if(terms.Count == 0)
                return;

            string exportStr = "";
            for(int i = 0; i < terms.Count; i++)
            {
                exportStr += terms[i] + "\t" + definitions[i] + "\n";
            }
            Clipboard.SetText(exportStr.Remove(exportStr.Length - 1));
        }

        private void DeleteToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            if (listView.SelectedItems.Count == 0)
                return;

            int index = listView.SelectedIndices[0];
            terms.RemoveAt(index);
            definitions.RemoveAt(index);
            RefreshListView();
        }

        private void ClearAllToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            terms.Clear();
            definitions.Clear();
            RefreshListView();
        }

        private void CopyFromTargetToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            Clipboard.SetText(targetLangRichTextBox.SelectedText);
        }

        private void CutFromTargetToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            Clipboard.SetText(sourceLangRichTextBox.SelectedText);
            sourceLangRichTextBox.SelectedText = "";
        }

        private void PasteToTargetToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            sourceLangRichTextBox.SelectedText = "";
            targetLangRichTextBox.Text += Clipboard.GetText();
        }

        private void CopyFromSourceToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            Clipboard.SetText(sourceLangRichTextBox.SelectedText);
            sourceLangRichTextBox.SelectedText = "";
        }

        private void CutFromSourceToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            Clipboard.SetText(sourceLangRichTextBox.SelectedText);
            sourceLangRichTextBox.SelectedText = "";
        }

        private void PasteToSourceToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            sourceLangRichTextBox.SelectedText = "";
            sourceLangRichTextBox.Text += Clipboard.GetText();
        }
    }
}
