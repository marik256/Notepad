namespace Notepad
{
    partial class RandNumGen
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.richTextBox = new System.Windows.Forms.RichTextBox();
            this.numberTextBox = new System.Windows.Forms.TextBox();
            this.valueTextBox = new System.Windows.Forms.TextBox();
            this.calcButton = new System.Windows.Forms.Button();
            this.minRadioButton = new System.Windows.Forms.RadioButton();
            this.maxRadioButton = new System.Windows.Forms.RadioButton();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.closeButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // richTextBox
            // 
            this.richTextBox.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.richTextBox.Location = new System.Drawing.Point(12, 12);
            this.richTextBox.Name = "richTextBox";
            this.richTextBox.Size = new System.Drawing.Size(176, 326);
            this.richTextBox.TabIndex = 0;
            this.richTextBox.Text = "";
            // 
            // numberTextBox
            // 
            this.numberTextBox.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.numberTextBox.Location = new System.Drawing.Point(206, 33);
            this.numberTextBox.Name = "numberTextBox";
            this.numberTextBox.Size = new System.Drawing.Size(100, 27);
            this.numberTextBox.TabIndex = 1;
            // 
            // valueTextBox
            // 
            this.valueTextBox.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.valueTextBox.Location = new System.Drawing.Point(206, 232);
            this.valueTextBox.Name = "valueTextBox";
            this.valueTextBox.Size = new System.Drawing.Size(100, 27);
            this.valueTextBox.TabIndex = 2;
            // 
            // calcButton
            // 
            this.calcButton.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.calcButton.Location = new System.Drawing.Point(206, 165);
            this.calcButton.Name = "calcButton";
            this.calcButton.Size = new System.Drawing.Size(100, 29);
            this.calcButton.TabIndex = 4;
            this.calcButton.Text = "Обчислити";
            this.calcButton.UseVisualStyleBackColor = true;
            this.calcButton.Click += new System.EventHandler(this.CalcButton_Click);
            // 
            // minRadioButton
            // 
            this.minRadioButton.AutoSize = true;
            this.minRadioButton.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.minRadioButton.Location = new System.Drawing.Point(206, 99);
            this.minRadioButton.Name = "minRadioButton";
            this.minRadioButton.Size = new System.Drawing.Size(55, 24);
            this.minRadioButton.TabIndex = 6;
            this.minRadioButton.TabStop = true;
            this.minRadioButton.Text = "Min";
            this.minRadioButton.UseVisualStyleBackColor = true;
            // 
            // maxRadioButton
            // 
            this.maxRadioButton.AutoSize = true;
            this.maxRadioButton.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.maxRadioButton.Location = new System.Drawing.Point(206, 129);
            this.maxRadioButton.Name = "maxRadioButton";
            this.maxRadioButton.Size = new System.Drawing.Size(58, 24);
            this.maxRadioButton.TabIndex = 7;
            this.maxRadioButton.TabStop = true;
            this.maxRadioButton.Text = "Max";
            this.maxRadioButton.UseVisualStyleBackColor = true;
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(12, 358);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(294, 23);
            this.progressBar.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label1.Location = new System.Drawing.Point(202, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 20);
            this.label1.TabIndex = 9;
            this.label1.Text = "К-сть ел.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label2.Location = new System.Drawing.Point(202, 209);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 20);
            this.label2.TabIndex = 10;
            this.label2.Text = "Значення";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label4.Location = new System.Drawing.Point(202, 76);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 20);
            this.label4.TabIndex = 12;
            this.label4.Text = "Знайти";
            // 
            // closeButton
            // 
            this.closeButton.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.closeButton.Location = new System.Drawing.Point(206, 309);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(100, 29);
            this.closeButton.TabIndex = 13;
            this.closeButton.Text = "Закрити";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // RandNumGen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(318, 396);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.maxRadioButton);
            this.Controls.Add(this.minRadioButton);
            this.Controls.Add(this.calcButton);
            this.Controls.Add(this.valueTextBox);
            this.Controls.Add(this.numberTextBox);
            this.Controls.Add(this.richTextBox);
            this.MaximumSize = new System.Drawing.Size(336, 438);
            this.MinimumSize = new System.Drawing.Size(336, 438);
            this.Name = "RandNumGen";
            this.Text = "Генератор випадкових чисел";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox;
        private System.Windows.Forms.TextBox numberTextBox;
        private System.Windows.Forms.TextBox valueTextBox;
        private System.Windows.Forms.Button calcButton;
        private System.Windows.Forms.RadioButton minRadioButton;
        private System.Windows.Forms.RadioButton maxRadioButton;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button closeButton;
    }
}