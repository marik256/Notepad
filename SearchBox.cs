using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Notepad
{
    internal partial class SearchBox : Form
    {
        private readonly Menu _menu;
        private readonly Blank _blank;

        public SearchBox(Menu menu, Blank blank)
        {
            InitializeComponent();
            ++menu.NumberOfSearhBoxInstance;

            _menu = menu;
            MdiParent = _menu;

            _blank = blank;
            blank.SearchBox = this;
            Text += _blank.PageName;

            Show();
        }

        private void Search()
        {
            _blank.ClearHighlight();
            if (string.IsNullOrEmpty(searchStringTextBox.Text))
            {
                return;
            }

            string pattern = searchStringTextBox.Text;
            RegexOptions options = RegexOptions.IgnoreCase;

            if (registerCheckBox.Checked)
            {
                options = RegexOptions.None;
            }

            if (fullWordCheckBox.Checked)
            {
                pattern = $@"(^|\W){pattern}(\W|$)";
            }

            Regex regex = new Regex(pattern, options);
            Match match = _blank.SearchInRichTextBox(regex, 0);
            while (match.Success)
            {
                _blank.HighlightSearchString(match.Index, match.Length);
                match = _blank.SearchInRichTextBox(regex, match.Index + match.Length);
            }
        }

        private void SearchWordTextBox_TextChanged(object sender, EventArgs e)
        {
            Search();
        }

        private void SearchBox_FormClosing(object sender, FormClosingEventArgs e)
        {
            --_menu.NumberOfSearhBoxInstance;
            _blank.ClearHighlight();
            _blank.SearchBox = null;
            _blank.SetIsSaved();
        }

        private void RegisterCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Search();
        }

        private void FullWordCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Search();
        }
    }
}
