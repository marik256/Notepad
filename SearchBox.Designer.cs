namespace Notepad
{
    partial class SearchBox
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
            this.searchTextBox = new System.Windows.Forms.TextBox();
            this.registerCheckBox = new System.Windows.Forms.CheckBox();
            this.fullWordCheckBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // searchStringTextBox
            // 
            this.searchTextBox.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.searchTextBox.Location = new System.Drawing.Point(12, 31);
            this.searchTextBox.Name = "searchStringTextBox";
            this.searchTextBox.Size = new System.Drawing.Size(365, 30);
            this.searchTextBox.TabIndex = 0;
            // 
            // registerCheckBox
            // 
            this.registerCheckBox.AutoSize = true;
            this.registerCheckBox.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.registerCheckBox.Location = new System.Drawing.Point(12, 76);
            this.registerCheckBox.Name = "registerCheckBox";
            this.registerCheckBox.Size = new System.Drawing.Size(216, 27);
            this.registerCheckBox.TabIndex = 3;
            this.registerCheckBox.Text = "З урахуванням регістру";
            this.registerCheckBox.UseVisualStyleBackColor = true;
            // 
            // fullWordCheckBox
            // 
            this.fullWordCheckBox.AutoSize = true;
            this.fullWordCheckBox.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.fullWordCheckBox.Location = new System.Drawing.Point(265, 76);
            this.fullWordCheckBox.Name = "fullWordCheckBox";
            this.fullWordCheckBox.Size = new System.Drawing.Size(112, 27);
            this.fullWordCheckBox.TabIndex = 4;
            this.fullWordCheckBox.Text = "Цілі слова";
            this.fullWordCheckBox.UseVisualStyleBackColor = true;
            // 
            // SearchBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(390, 125);
            this.Controls.Add(this.fullWordCheckBox);
            this.Controls.Add(this.registerCheckBox);
            this.Controls.Add(this.searchTextBox);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(408, 167);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(408, 167);
            this.Name = "SearchBox";
            this.Text = "Пошук в: ";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox searchTextBox;
        private System.Windows.Forms.CheckBox registerCheckBox;
        private System.Windows.Forms.CheckBox fullWordCheckBox;
    }
}