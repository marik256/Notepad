using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Notepad
{
    public partial class RandNumGen : Form
    {
        private double[] randNum;
        private int number;
        private int numberOfRows;
        private int numberOfColumns;
        private int counter = 1;
        private string[] row;
        private readonly Random random = new Random();

        public RandNumGen()
        {
            InitializeComponent();
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

        private int GetNumber(TextBox textBox)
        {
            if (int.TryParse(textBox.Text, out int number))
            {
                return number;
            }
            else
            {
                return 0;
            }
        }

        private void WriteToRichTextBox()
        {
            foreach (double number in randNum)
            {
                richTextBox.Text += number.ToString(CultureInfo.CurrentCulture) + "\n";
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
            valueTextBox.Text = GetMaxOrMin().ToString(CultureInfo.CurrentCulture);
        }

        private void GetValuesOfRandNumbers()
        {
            number = GetNumber(numberTextBox);
            if (number <= 0)
            {
                MessageBox.Show("Ви ввели некоректну кількість елементів масиву!",
                                "Помилка",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return;
            }
            SetInitialValues();

            if (number <= 0)
            {
                MessageBox.Show("Ви ввели некоректну кількість чисел, які хочете згенерувати.",
                                "Помилка",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return;
            }

            randNum = new double[number];

            for (int i = 0; i < number; i++)
            {
                randNum[i] = Math.Round(random.NextDouble(), 5);
                progressBar.PerformStep();
            }
        }

        private void CalcButton_Click(object sender, EventArgs e)
        {
            if (minRadioButton.Checked || maxRadioButton.Checked)
            {
                if (string.IsNullOrEmpty(numberTextBox.Text))
                {
                    if (string.IsNullOrEmpty(richTextBox.Text))
                    {
                        MessageBox.Show("Ви не ввели кількість чисел, які хочете згенерувати.",
                               "Помилка",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Error);
                        return;
                    }
                    WriteMinOrMaxValueToTextBox();
                }
                else
                {
                    GetValuesOfRandNumbers();
                    WriteToRichTextBox();
                    WriteMinOrMaxValueToTextBox();
                }
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

        private void Tabulate()
        {
            if (randNum == null)
            {
                MessageBox.Show("Ви не створили масив випадкових чисел.",
                                "Помилка",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(numOfRowsTextBox.Text))
            {
                MessageBox.Show("Ви не ввели кількість рядків, які хочете згенерувати.",
                                "Помилка",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(numOfColumnsTextBox.Text))
            {
                MessageBox.Show("Ви не ввели кількість стовпців, які хочете згенерувати.",
                                "Помилка",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return;
            }

            numberOfRows = GetNumber(numOfRowsTextBox);
            if (numberOfRows <= 0)
            {
                MessageBox.Show("Ви ввели некоректну кількість рядків!",
                                "Помилка",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return;
            }
            numberOfColumns = GetNumber(numOfColumnsTextBox);
            if (numberOfColumns <= 0)
            {
                MessageBox.Show("Ви ввели некоректну кількість стовпців!",
                                "Помилка",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return;
            }
            if((double)randNum.Length / numberOfColumns < 1.0)
            {
                MessageBox.Show("Ви ввели завелику кількість стовпців!",
                                "Помилка",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return;
            }

            if (randNum.Length == 0)
            {
                MessageBox.Show("Ви не створили масив випадкових чисел!",
                                "Помилка",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return;
            }

            while (numberOfColumns + 1 > dataGridView.ColumnCount)
            {
                dataGridView.Columns.Add("", $"Ст. {counter}");
                counter++;
            }

            for (int i = 0; i < Math.Ceiling((double)randNum.Length / numberOfColumns); i++)
            {
                if (i >= numberOfRows)
                {
                    break;
                }

                row = new string[numberOfColumns + 1];
                
                row[0] = (i + 1).ToString(CultureInfo.CurrentCulture);
                for (int j = 1; j < numberOfColumns + 1; j++)
                {
                    if(i * numberOfColumns + (j - 1) >= randNum.Length)
                    {
                        continue;
                    }
                    row[j] = randNum[i * numberOfColumns + (j - 1)].ToString(CultureInfo.CurrentCulture);
                }

                dataGridView.Rows.Add(row);
            }

            for (int i = 0; i < numberOfColumns + 1; i++)
            {
                row[i] = "***";
            }

            dataGridView.Rows.Add(row);
        }

        private void TabulateButton_Click(object sender, EventArgs e)
        {
            Tabulate();
        }

        private void ReadFromFile()
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                using (StreamReader sr = new StreamReader(openFileDialog.FileName))
                {
                    List<double> rows = new List<double>();
                    string context = "";
                    while((context = sr.ReadLine()) != null)
                    {
                        if (Double.TryParse(context, out double result))
                        {
                            rows.Add(result);
                        }
                        else continue;
                    }

                    if (rows.Count == 0)
                    {
                        MessageBox.Show("Жоден рядок файлу не може бути застосованим.",
                                "Помилка",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        randNum = new double[rows.Count];
                        richTextBox.Clear();
                        for (int i = 0; i < rows.Count; i++)
                        {
                            randNum[i] = rows[i];
                            richTextBox.Text += rows[i].ToString(CultureInfo.CurrentCulture) + '\n';
                        }
                    }
                }
            }
        }
        
        private void FromFileButton_Click(object sender, EventArgs e)
        {
            ReadFromFile();
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            richTextBox.Clear();
        }
    }
}
