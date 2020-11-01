using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Notepad
{
    public partial class RandNumGen : Form
    {
        private double[] randNum;
        private int number;
        private readonly Random random = new Random();

        public RandNumGen()
        {
            InitializeComponent();
        }

        private void GetNumber()
        {
            if (string.IsNullOrEmpty(numberTextBox.Text))
            {
                MessageBox.Show("Ви не ввели кількість чисел, які хочете згенерувати.",
                                "Поимилка",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return;
            }

            if (int.TryParse(numberTextBox.Text, out number) == false)
            {
                MessageBox.Show("Ви ввели некоректне значення!",
                                "Помилка",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        private void SetInitialValues()
        {
            richTextBox.Clear();
            valueTextBox.Clear();

            progressBar.Minimum = 0;
            progressBar.Maximum = number;
            progressBar.Step = 1;
            progressBar.Value = 0;
        }

        private void GetRandomNumbers()
        {
            SetInitialValues();
            GetNumber();

            if (number == 0)
            {
                return;
            }

            randNum = new double[number];

            for (int i = 0; i < number; i++)
            {
                randNum[i] = Math.Round(random.NextDouble(), 5);
                progressBar.PerformStep();
            }

            WriteToRichTextBox();
            WriteMinOrMaxValueToTextBox();
        }

        private void WriteToRichTextBox()
        {
            foreach (double number in randNum)
            {
                richTextBox.Text += number.ToString() + "\n";
            }
        }

        private double GetMaxOrMin()
        {
            if (minRadioButton.Checked)
            {
                return randNum.Min();
            }
            else
            {
                return randNum.Max();
            }
        }

        private void WriteMinOrMaxValueToTextBox()
        {
            valueTextBox.Text = GetMaxOrMin().ToString();
        }

        private void CalcButton_Click(object sender, EventArgs e)
        {
            if (minRadioButton.Checked || maxRadioButton.Checked)
            {
                GetRandomNumbers();
            }
            else
            {
                MessageBox.Show("Ви не обрали значення, яке хочете отримати (Max чи Min).",
                                "Помилка",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
