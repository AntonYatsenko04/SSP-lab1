namespace list
{
    partial class Form1
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
            this.mainTextWindow = new System.Windows.Forms.TextBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.IncreaseFontSizeToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.decreaseFontSizeToolTipButton = new System.Windows.Forms.ToolStripButton();
            this.linesNumberDropDown = new System.Windows.Forms.ToolStripDropDownButton();
            this.stringNumComboBox = new System.Windows.Forms.ToolStripComboBox();
            this.NextPageButton = new System.Windows.Forms.Button();
            this.PreviousPageButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.AllPagesCountLabel = new System.Windows.Forms.Label();
            this.pageNumberTextBox = new System.Windows.Forms.TextBox();
            this.toolStripComboBox1 = new System.Windows.Forms.ToolStripComboBox();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // OpenFileButton
            // 
            this.OpenFileButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.OpenFileButton.Location = new System.Drawing.Point(960, 33);
            this.OpenFileButton.Margin = new System.Windows.Forms.Padding(4);
            this.OpenFileButton.Name = "OpenFileButton";
            this.OpenFileButton.Size = new System.Drawing.Size(136, 28);
            this.OpenFileButton.TabIndex = 0;
            this.OpenFileButton.Text = "Открыть файл";
            this.OpenFileButton.UseVisualStyleBackColor = true;
            this.OpenFileButton.Click += new System.EventHandler(this.OpenFileButton_Click1);
            // 
            // mainTextWindow
            // 
            this.mainTextWindow.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.mainTextWindow.Location = new System.Drawing.Point(16, 69);
            this.mainTextWindow.Margin = new System.Windows.Forms.Padding(4);
            this.mainTextWindow.Multiline = true;
            this.mainTextWindow.Name = "mainTextWindow";
            this.mainTextWindow.ReadOnly = true;
            this.mainTextWindow.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.mainTextWindow.Size = new System.Drawing.Size(1079, 489);
            this.mainTextWindow.TabIndex = 1;
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { this.IncreaseFontSizeToolStripButton, this.decreaseFontSizeToolTipButton, this.linesNumberDropDown });
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1112, 27);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // IncreaseFontSizeToolStripButton
            // 
            this.IncreaseFontSizeToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.IncreaseFontSizeToolStripButton.Enabled = false;
            this.IncreaseFontSizeToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.IncreaseFontSizeToolStripButton.Name = "IncreaseFontSizeToolStripButton";
            this.IncreaseFontSizeToolStripButton.Size = new System.Drawing.Size(136, 24);
            this.IncreaseFontSizeToolStripButton.Text = "Увеличить шрифт";
            this.IncreaseFontSizeToolStripButton.Click += new System.EventHandler(this.IncreaseFontSizeButton_Click);
            // 
            // decreaseFontSizeToolTipButton
            // 
            this.decreaseFontSizeToolTipButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.decreaseFontSizeToolTipButton.Enabled = false;
            this.decreaseFontSizeToolTipButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.decreaseFontSizeToolTipButton.Name = "decreaseFontSizeToolTipButton";
            this.decreaseFontSizeToolTipButton.Size = new System.Drawing.Size(143, 24);
            this.decreaseFontSizeToolTipButton.Text = "Уменьшить шрифт";
            this.decreaseFontSizeToolTipButton.Click += new System.EventHandler(this.decreaseFontSizeToolStripButton_Click);
            // 
            // linesNumberDropDown
            // 
            this.linesNumberDropDown.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { this.stringNumComboBox });
            this.linesNumberDropDown.Enabled = false;
            this.linesNumberDropDown.Name = "linesNumberDropDown";
            this.linesNumberDropDown.Size = new System.Drawing.Size(193, 24);
            this.linesNumberDropDown.Text = "Выбрать размер буфера";
            // 
            // stringNumComboBox
            // 
            this.stringNumComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.stringNumComboBox.Items.AddRange(new object[] { "4096", "8192", "16384" });
            this.stringNumComboBox.Name = "stringNumComboBox";
            this.stringNumComboBox.Size = new System.Drawing.Size(121, 28);
            this.stringNumComboBox.SelectedIndexChanged += new System.EventHandler(this.stringNumComboBox_SelectedIndexChanged);
            // 
            // NextPageButton
            // 
            this.NextPageButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.NextPageButton.AutoSize = true;
            this.NextPageButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.NextPageButton.Enabled = false;
            this.NextPageButton.Location = new System.Drawing.Point(909, 566);
            this.NextPageButton.Margin = new System.Windows.Forms.Padding(4);
            this.NextPageButton.MaximumSize = new System.Drawing.Size(187, 28);
            this.NextPageButton.MinimumSize = new System.Drawing.Size(187, 28);
            this.NextPageButton.Name = "NextPageButton";
            this.NextPageButton.Size = new System.Drawing.Size(187, 28);
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
            this.PreviousPageButton.Location = new System.Drawing.Point(16, 567);
            this.PreviousPageButton.Margin = new System.Windows.Forms.Padding(4);
            this.PreviousPageButton.Name = "PreviousPageButton";
            this.PreviousPageButton.Size = new System.Drawing.Size(170, 27);
            this.PreviousPageButton.TabIndex = 4;
            this.PreviousPageButton.Text = "Предыдущая страница";
            this.PreviousPageButton.UseVisualStyleBackColor = true;
            this.PreviousPageButton.Click += new System.EventHandler(this.previousPageButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 39);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(136, 17);
            this.label1.TabIndex = 6;
            this.label1.Text = "Текущая страница:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(351, 39);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 17);
            this.label2.TabIndex = 7;
            this.label2.Text = "из";
            // 
            // AllPagesCountLabel
            // 
            this.AllPagesCountLabel.AutoSize = true;
            this.AllPagesCountLabel.Location = new System.Drawing.Point(384, 39);
            this.AllPagesCountLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.AllPagesCountLabel.Name = "AllPagesCountLabel";
            this.AllPagesCountLabel.Size = new System.Drawing.Size(16, 17);
            this.AllPagesCountLabel.TabIndex = 8;
            this.AllPagesCountLabel.Text = "0";
            // 
            // pageNumberTextBox
            // 
            this.pageNumberTextBox.Enabled = false;
            this.pageNumberTextBox.Location = new System.Drawing.Point(164, 36);
            this.pageNumberTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.pageNumberTextBox.Name = "pageNumberTextBox";
            this.pageNumberTextBox.Size = new System.Drawing.Size(177, 22);
            this.pageNumberTextBox.TabIndex = 9;
            this.pageNumberTextBox.TextChanged += new System.EventHandler(this.pageNumberTextBox_TextChanged);
            // 
            // toolStripComboBox1
            // 
            this.toolStripComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.toolStripComboBox1.Items.AddRange(new object[] { "10", "20", "30", "40", "50" });
            this.toolStripComboBox1.Name = "toolStripComboBox1";
            this.toolStripComboBox1.Size = new System.Drawing.Size(121, 23);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1112, 609);
            this.Controls.Add(this.pageNumberTextBox);
            this.Controls.Add(this.AllPagesCountLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.PreviousPageButton);
            this.Controls.Add(this.NextPageButton);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.mainTextWindow);
            this.Controls.Add(this.OpenFileButton);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Читатель";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button OpenFileButton;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox mainTextWindow;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton IncreaseFontSizeToolStripButton;
        private System.Windows.Forms.ToolStripButton decreaseFontSizeToolTipButton;
        private System.Windows.Forms.Button NextPageButton;
        private System.Windows.Forms.Button PreviousPageButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label AllPagesCountLabel;
        private System.Windows.Forms.TextBox pageNumberTextBox;
        private System.Windows.Forms.ToolStripDropDownButton linesNumberDropDown;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBox1;
        private System.Windows.Forms.ToolStripComboBox stringNumComboBox;
    }
}

