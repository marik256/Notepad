using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Notepad
{
    internal partial class SearchBox : Form
    {
        public SearchBox(string pageName)
        {
            InitializeComponent();
            Text += pageName;
        }

        internal TextBox SearchTextBox => searchTextBox;
        internal CheckBox RegisterCheckBox => registerCheckBox;
        internal CheckBox FullWordCheckBox => fullWordCheckBox;

        public sealed class SearchResult
        {
            public int Index { get; }
            public int Length { get; }

            public SearchResult(int index, int length)
            {
                Index = index;
                Length = length;
            }
        }

        internal IEnumerable<SearchResult> Search(string content)
        {
            if (string.IsNullOrEmpty(searchTextBox.Text))
            {
                yield break;
            }

            string pattern = searchTextBox.Text;
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
            Match match = regex.Match(content, 0);
            while (match.Success)
            {
                yield return new SearchResult(match.Index, match.Length);
                match = regex.Match(content, match.Index + match.Length);
            }
        }
    }
}
