
namespace Notepad
{
    partial class Translator
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
            this.components = new System.ComponentModel.Container();
            this.sourceLangRichTextBox = new System.Windows.Forms.RichTextBox();
            this.sourceContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.copyFromSourceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cutFromSourceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToSourceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.targetLangRichTextBox = new System.Windows.Forms.RichTextBox();
            this.targetContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.copyFromTargetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cutFromTargetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToTargetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sourceLangComboBox = new System.Windows.Forms.ComboBox();
            this.targetLangComboBox = new System.Windows.Forms.ComboBox();
            this.translateButton = new System.Windows.Forms.Button();
            this.exportButton = new System.Windows.Forms.Button();
            this.listView = new System.Windows.Forms.ListView();
            this.sourceLang = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.targetLang = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addButton = new System.Windows.Forms.Button();
            this.sourceContextMenuStrip.SuspendLayout();
            this.targetContextMenuStrip.SuspendLayout();
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // sourceLangRichTextBox
            // 
            this.sourceLangRichTextBox.ContextMenuStrip = this.sourceContextMenuStrip;
            this.sourceLangRichTextBox.Location = new System.Drawing.Point(12, 43);
            this.sourceLangRichTextBox.Name = "sourceLangRichTextBox";
            this.sourceLangRichTextBox.Size = new System.Drawing.Size(500, 150);
            this.sourceLangRichTextBox.TabIndex = 0;
            this.sourceLangRichTextBox.Text = "";
            // 
            // sourceContextMenuStrip
            // 
            this.sourceContextMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.sourceContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyFromSourceToolStripMenuItem,
            this.cutFromSourceToolStripMenuItem,
            this.pasteToSourceToolStripMenuItem});
            this.sourceContextMenuStrip.Name = "contextRtbMenuStrip";
            this.sourceContextMenuStrip.Size = new System.Drawing.Size(144, 76);
            // 
            // copyFromSourceToolStripMenuItem
            // 
            this.copyFromSourceToolStripMenuItem.Name = "copyFromSourceToolStripMenuItem";
            this.copyFromSourceToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.copyFromSourceToolStripMenuItem.ShowShortcutKeys = false;
            this.copyFromSourceToolStripMenuItem.Size = new System.Drawing.Size(143, 24);
            this.copyFromSourceToolStripMenuItem.Text = "Копіювати";
            this.copyFromSourceToolStripMenuItem.Click += new System.EventHandler(this.CopyFromSourceToolStripMenuItem_Click);
            // 
            // cutFromSourceToolStripMenuItem
            // 
            this.cutFromSourceToolStripMenuItem.Name = "cutFromSourceToolStripMenuItem";
            this.cutFromSourceToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.cutFromSourceToolStripMenuItem.ShowShortcutKeys = false;
            this.cutFromSourceToolStripMenuItem.Size = new System.Drawing.Size(143, 24);
            this.cutFromSourceToolStripMenuItem.Text = "Вирізати";
            this.cutFromSourceToolStripMenuItem.Click += new System.EventHandler(this.CutFromSourceToolStripMenuItem_Click);
            // 
            // pasteToSourceToolStripMenuItem
            // 
            this.pasteToSourceToolStripMenuItem.Name = "pasteToSourceToolStripMenuItem";
            this.pasteToSourceToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.pasteToSourceToolStripMenuItem.ShowShortcutKeys = false;
            this.pasteToSourceToolStripMenuItem.Size = new System.Drawing.Size(143, 24);
            this.pasteToSourceToolStripMenuItem.Text = "Вставити";
            this.pasteToSourceToolStripMenuItem.Click += new System.EventHandler(this.PasteToSourceToolStripMenuItem_Click);
            // 
            // targetLangRichTextBox
            // 
            this.targetLangRichTextBox.ContextMenuStrip = this.targetContextMenuStrip;
            this.targetLangRichTextBox.Location = new System.Drawing.Point(12, 199);
            this.targetLangRichTextBox.Name = "targetLangRichTextBox";
            this.targetLangRichTextBox.Size = new System.Drawing.Size(500, 150);
            this.targetLangRichTextBox.TabIndex = 1;
            this.targetLangRichTextBox.Text = "";
            // 
            // targetContextMenuStrip
            // 
            this.targetContextMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.targetContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyFromTargetToolStripMenuItem,
            this.cutFromTargetToolStripMenuItem,
            this.pasteToTargetToolStripMenuItem});
            this.targetContextMenuStrip.Name = "contextRtbMenuStrip";
            this.targetContextMenuStrip.Size = new System.Drawing.Size(144, 76);
            // 
            // copyFromTargetToolStripMenuItem
            // 
            this.copyFromTargetToolStripMenuItem.Name = "copyFromTargetToolStripMenuItem";
            this.copyFromTargetToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.copyFromTargetToolStripMenuItem.ShowShortcutKeys = false;
            this.copyFromTargetToolStripMenuItem.Size = new System.Drawing.Size(143, 24);
            this.copyFromTargetToolStripMenuItem.Text = "Копіювати";
            this.copyFromTargetToolStripMenuItem.Click += new System.EventHandler(this.CopyFromTargetToolStripMenuItem_Click);
            // 
            // cutFromTargetToolStripMenuItem
            // 
            this.cutFromTargetToolStripMenuItem.Name = "cutFromTargetToolStripMenuItem";
            this.cutFromTargetToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.cutFromTargetToolStripMenuItem.ShowShortcutKeys = false;
            this.cutFromTargetToolStripMenuItem.Size = new System.Drawing.Size(143, 24);
            this.cutFromTargetToolStripMenuItem.Text = "Вирізати";
            this.cutFromTargetToolStripMenuItem.Click += new System.EventHandler(this.CutFromTargetToolStripMenuItem_Click);
            // 
            // pasteToTargetToolStripMenuItem
            // 
            this.pasteToTargetToolStripMenuItem.Name = "pasteToTargetToolStripMenuItem";
            this.pasteToTargetToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.pasteToTargetToolStripMenuItem.ShowShortcutKeys = false;
            this.pasteToTargetToolStripMenuItem.Size = new System.Drawing.Size(143, 24);
            this.pasteToTargetToolStripMenuItem.Text = "Вставити";
            this.pasteToTargetToolStripMenuItem.Click += new System.EventHandler(this.PasteToTargetToolStripMenuItem_Click);
            // 
            // sourceLangComboBox
            // 
            this.sourceLangComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.sourceLangComboBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.sourceLangComboBox.FormattingEnabled = true;
            this.sourceLangComboBox.Items.AddRange(new object[] {
            "українська",
            "російська",
            "англійська",
            "іспанська",
            "німецька",
            "французька",
            "польська"});
            this.sourceLangComboBox.Location = new System.Drawing.Point(12, 13);
            this.sourceLangComboBox.Name = "sourceLangComboBox";
            this.sourceLangComboBox.Size = new System.Drawing.Size(177, 24);
            this.sourceLangComboBox.TabIndex = 2;
            // 
            // targetLangComboBox
            // 
            this.targetLangComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.targetLangComboBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.targetLangComboBox.FormattingEnabled = true;
            this.targetLangComboBox.Items.AddRange(new object[] {
            "українська",
            "російська",
            "англійська",
            "іспанська",
            "німецька",
            "французька",
            "польська"});
            this.targetLangComboBox.Location = new System.Drawing.Point(214, 13);
            this.targetLangComboBox.Name = "targetLangComboBox";
            this.targetLangComboBox.Size = new System.Drawing.Size(173, 24);
            this.targetLangComboBox.TabIndex = 3;
            // 
            // translateButton
            // 
            this.translateButton.Location = new System.Drawing.Point(416, 12);
            this.translateButton.Name = "translateButton";
            this.translateButton.Size = new System.Drawing.Size(96, 25);
            this.translateButton.TabIndex = 4;
            this.translateButton.Text = "Перекласти";
            this.translateButton.UseVisualStyleBackColor = true;
            this.translateButton.Click += new System.EventHandler(this.TranslateButton_Click);
            // 
            // exportButton
            // 
            this.exportButton.Location = new System.Drawing.Point(704, 12);
            this.exportButton.Name = "exportButton";
            this.exportButton.Size = new System.Drawing.Size(84, 25);
            this.exportButton.TabIndex = 5;
            this.exportButton.Text = "Експорт";
            this.exportButton.UseVisualStyleBackColor = true;
            this.exportButton.Click += new System.EventHandler(this.ExportButton_Click);
            // 
            // listView
            // 
            this.listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.sourceLang,
            this.targetLang});
            this.listView.ContextMenuStrip = this.contextMenuStrip;
            this.listView.FullRowSelect = true;
            this.listView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listView.HideSelection = false;
            this.listView.Location = new System.Drawing.Point(518, 43);
            this.listView.Name = "listView";
            this.listView.Size = new System.Drawing.Size(270, 306);
            this.listView.TabIndex = 6;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.View = System.Windows.Forms.View.Details;
            // 
            // sourceLang
            // 
            this.sourceLang.Text = "Термін";
            this.sourceLang.Width = 133;
            // 
            // targetLang
            // 
            this.targetLang.Text = "Визначення";
            this.targetLang.Width = 133;
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteToolStripMenuItem,
            this.clearAllToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(171, 52);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(170, 24);
            this.deleteToolStripMenuItem.Text = "Видалити";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.DeleteToolStripMenuItem_Click);
            // 
            // clearAllToolStripMenuItem
            // 
            this.clearAllToolStripMenuItem.Name = "clearAllToolStripMenuItem";
            this.clearAllToolStripMenuItem.Size = new System.Drawing.Size(170, 24);
            this.clearAllToolStripMenuItem.Text = "Очистити все";
            this.clearAllToolStripMenuItem.Click += new System.EventHandler(this.ClearAllToolStripMenuItem_Click);
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(614, 12);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(84, 25);
            this.addButton.TabIndex = 7;
            this.addButton.Text = "Додати";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // Translator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 359);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.listView);
            this.Controls.Add(this.exportButton);
            this.Controls.Add(this.translateButton);
            this.Controls.Add(this.targetLangComboBox);
            this.Controls.Add(this.sourceLangComboBox);
            this.Controls.Add(this.targetLangRichTextBox);
            this.Controls.Add(this.sourceLangRichTextBox);
            this.Name = "Translator";
            this.Text = "Перекладач";
            this.sourceContextMenuStrip.ResumeLayout(false);
            this.targetContextMenuStrip.ResumeLayout(false);
            this.contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox sourceLangRichTextBox;
        private System.Windows.Forms.RichTextBox targetLangRichTextBox;
        private System.Windows.Forms.ComboBox sourceLangComboBox;
        private System.Windows.Forms.ComboBox targetLangComboBox;
        private System.Windows.Forms.Button translateButton;
        private System.Windows.Forms.Button exportButton;
        private System.Windows.Forms.ListView listView;
        private System.Windows.Forms.ColumnHeader sourceLang;
        private System.Windows.Forms.ColumnHeader targetLang;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearAllToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip sourceContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem copyFromSourceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cutFromSourceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteToSourceToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip targetContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem copyFromTargetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cutFromTargetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteToTargetToolStripMenuItem;
    }
}