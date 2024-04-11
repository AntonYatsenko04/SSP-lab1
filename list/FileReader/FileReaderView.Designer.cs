namespace list
{
    partial class FileReaderView
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.OpenFileButton = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this._mainTextWindow = new System.Windows.Forms.TextBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.IncreaseFontSizeToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.decreaseFontSizeToolTipButton = new System.Windows.Forms.ToolStripButton();
            this.linesNumberDropDown = new System.Windows.Forms.ToolStripDropDownButton();
            this.stringNumComboBox = new System.Windows.Forms.ToolStripComboBox();
            this.NextPageButton = new System.Windows.Forms.Button();
            this.PreviousPageButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this._allPagesCountLabel = new System.Windows.Forms.Label();
            this._pageNumberTextBox = new System.Windows.Forms.TextBox();
            this.toolStripComboBox1 = new System.Windows.Forms.ToolStripComboBox();
            this._libraryListBox = new System.Windows.Forms.ListBox();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // OpenFileButton
            // 
            this.OpenFileButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.OpenFileButton.Location = new System.Drawing.Point(646, 56);
            this.OpenFileButton.Name = "OpenFileButton";
            this.OpenFileButton.Size = new System.Drawing.Size(102, 23);
            this.OpenFileButton.TabIndex = 0;
            this.OpenFileButton.Text = "Открыть файл";
            this.OpenFileButton.UseVisualStyleBackColor = true;
            this.OpenFileButton.Click += new System.EventHandler(this.OpenFileButton_Click1);
            // 
            // _mainTextWindow
            // 
            this._mainTextWindow.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this._mainTextWindow.Location = new System.Drawing.Point(12, 85);
            this._mainTextWindow.Multiline = true;
            this._mainTextWindow.Name = "_mainTextWindow";
            this._mainTextWindow.ReadOnly = true;
            this._mainTextWindow.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this._mainTextWindow.Size = new System.Drawing.Size(736, 486);
            this._mainTextWindow.TabIndex = 1;
            this._mainTextWindow.Text = " = ";
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { this.IncreaseFontSizeToolStripButton, this.decreaseFontSizeToolTipButton, this.linesNumberDropDown });
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(760, 25);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // IncreaseFontSizeToolStripButton
            // 
            this.IncreaseFontSizeToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.IncreaseFontSizeToolStripButton.Enabled = false;
            this.IncreaseFontSizeToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.IncreaseFontSizeToolStripButton.Name = "IncreaseFontSizeToolStripButton";
            this.IncreaseFontSizeToolStripButton.Size = new System.Drawing.Size(111, 22);
            this.IncreaseFontSizeToolStripButton.Text = "Увеличить шрифт";
            this.IncreaseFontSizeToolStripButton.Click += new System.EventHandler(this.IncreaseFontSizeButton_Click);
            // 
            // decreaseFontSizeToolTipButton
            // 
            this.decreaseFontSizeToolTipButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.decreaseFontSizeToolTipButton.Enabled = false;
            this.decreaseFontSizeToolTipButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.decreaseFontSizeToolTipButton.Name = "decreaseFontSizeToolTipButton";
            this.decreaseFontSizeToolTipButton.Size = new System.Drawing.Size(117, 22);
            this.decreaseFontSizeToolTipButton.Text = "Уменьшить шрифт";
            this.decreaseFontSizeToolTipButton.Click += new System.EventHandler(this.decreaseFontSizeToolStripButton_Click);
            // 
            // linesNumberDropDown
            // 
            this.linesNumberDropDown.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { this.stringNumComboBox });
            this.linesNumberDropDown.Enabled = false;
            this.linesNumberDropDown.Name = "linesNumberDropDown";
            this.linesNumberDropDown.Size = new System.Drawing.Size(154, 22);
            this.linesNumberDropDown.Text = "Выбрать размер буфера";
            // 
            // stringNumComboBox
            // 
            this.stringNumComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.stringNumComboBox.Items.AddRange(new object[] { "4096", "8192", "16384" });
            this.stringNumComboBox.Name = "stringNumComboBox";
            this.stringNumComboBox.Size = new System.Drawing.Size(121, 23);
            this.stringNumComboBox.SelectedIndexChanged += new System.EventHandler(this.stringNumComboBox_SelectedIndexChanged);
            // 
            // NextPageButton
            // 
            this.NextPageButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.NextPageButton.AutoSize = true;
            this.NextPageButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.NextPageButton.Enabled = false;
            this.NextPageButton.Location = new System.Drawing.Point(608, 577);
            this.NextPageButton.MaximumSize = new System.Drawing.Size(140, 23);
            this.NextPageButton.MinimumSize = new System.Drawing.Size(140, 23);
            this.NextPageButton.Name = "NextPageButton";
            this.NextPageButton.Size = new System.Drawing.Size(140, 23);
            this.NextPageButton.TabIndex = 3;
            this.NextPageButton.Text = "Следующая страница";
            this.NextPageButton.UseVisualStyleBackColor = true;
            this.NextPageButton.Click += new System.EventHandler(this.nextPageButton_Click);
            // 
            // PreviousPageButton
            // 
            this.PreviousPageButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.PreviousPageButton.AutoSize = true;
            this.PreviousPageButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.PreviousPageButton.Enabled = false;
            this.PreviousPageButton.Location = new System.Drawing.Point(12, 577);
            this.PreviousPageButton.Name = "PreviousPageButton";
            this.PreviousPageButton.Size = new System.Drawing.Size(133, 23);
            this.PreviousPageButton.TabIndex = 4;
            this.PreviousPageButton.Text = "Предыдущая страница";
            this.PreviousPageButton.UseVisualStyleBackColor = true;
            this.PreviousPageButton.Click += new System.EventHandler(this.previousPageButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Текущая страница:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(263, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(19, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "из";
            // 
            // _allPagesCountLabel
            // 
            this._allPagesCountLabel.AutoSize = true;
            this._allPagesCountLabel.Location = new System.Drawing.Point(288, 32);
            this._allPagesCountLabel.Name = "_allPagesCountLabel";
            this._allPagesCountLabel.Size = new System.Drawing.Size(13, 13);
            this._allPagesCountLabel.TabIndex = 8;
            this._allPagesCountLabel.Text = "0";
            // 
            // _pageNumberTextBox
            // 
            this._pageNumberTextBox.Cursor = System.Windows.Forms.Cursors.Arrow;
            this._pageNumberTextBox.Enabled = false;
            this._pageNumberTextBox.Location = new System.Drawing.Point(123, 29);
            this._pageNumberTextBox.Name = "_pageNumberTextBox";
            this._pageNumberTextBox.Size = new System.Drawing.Size(134, 20);
            this._pageNumberTextBox.TabIndex = 9;
            this._pageNumberTextBox.TextChanged += new System.EventHandler(this.pageNumberTextBox_TextChanged);
            // 
            // toolStripComboBox1
            // 
            this.toolStripComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.toolStripComboBox1.Items.AddRange(new object[] { "10", "20", "30", "40", "50" });
            this.toolStripComboBox1.Name = "toolStripComboBox1";
            this.toolStripComboBox1.Size = new System.Drawing.Size(121, 23);
            // 
            // _libraryListBox
            // 
            this._libraryListBox.FormattingEnabled = true;
            this._libraryListBox.Location = new System.Drawing.Point(430, 13);
            this._libraryListBox.Name = "_libraryListBox";
            this._libraryListBox.Size = new System.Drawing.Size(176, 56);
            this._libraryListBox.TabIndex = 10;
            // 
            // FileReaderView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(760, 612);
            this.Controls.Add(this._libraryListBox);
            this.Controls.Add(this._pageNumberTextBox);
            this.Controls.Add(this._allPagesCountLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.PreviousPageButton);
            this.Controls.Add(this.NextPageButton);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this._mainTextWindow);
            this.Controls.Add(this.OpenFileButton);
            this.Name = "FileReaderView";
            this.Text = "Читатель";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.ListBox _libraryListBox;

        #endregion

        private System.Windows.Forms.Button OpenFileButton;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox _mainTextWindow;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton IncreaseFontSizeToolStripButton;
        private System.Windows.Forms.ToolStripButton decreaseFontSizeToolTipButton;
        private System.Windows.Forms.Button NextPageButton;
        private System.Windows.Forms.Button PreviousPageButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label _allPagesCountLabel;
        private System.Windows.Forms.TextBox _pageNumberTextBox;
        private System.Windows.Forms.ToolStripDropDownButton linesNumberDropDown;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBox1;
        private System.Windows.Forms.ToolStripComboBox stringNumComboBox;
    }
}

