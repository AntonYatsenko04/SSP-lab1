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
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.button1 = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.IncreaseFontSizeToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.decreaseFontSizeToolTipButton = new System.Windows.Forms.ToolStripButton();
            this.NextPageButton = new System.Windows.Forms.Button();
            this.PreviousPageButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pageNumberTextBox = new System.Windows.Forms.TextBox();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(686, 28);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(102, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Открыть файл";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 72);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(776, 366);
            this.textBox1.TabIndex = 1;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.IncreaseFontSizeToolStripButton,
            this.decreaseFontSizeToolTipButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(800, 25);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // IncreaseFontSizeToolStripButton
            // 
            this.IncreaseFontSizeToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.IncreaseFontSizeToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("IncreaseFontSizeToolStripButton.Image")));
            this.IncreaseFontSizeToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.IncreaseFontSizeToolStripButton.Name = "IncreaseFontSizeToolStripButton";
            this.IncreaseFontSizeToolStripButton.Size = new System.Drawing.Size(111, 22);
            this.IncreaseFontSizeToolStripButton.Text = "Увеличить шрифт";
            this.IncreaseFontSizeToolStripButton.Click += new System.EventHandler(this.IncreaseFontSizeButton_Click);
            // 
            // decreaseFontSizeToolTipButton
            // 
            this.decreaseFontSizeToolTipButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.decreaseFontSizeToolTipButton.Image = ((System.Drawing.Image)(resources.GetObject("decreaseFontSizeToolTipButton.Image")));
            this.decreaseFontSizeToolTipButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.decreaseFontSizeToolTipButton.Name = "decreaseFontSizeToolTipButton";
            this.decreaseFontSizeToolTipButton.Size = new System.Drawing.Size(117, 22);
            this.decreaseFontSizeToolTipButton.Text = "Уменьшить шрифт";
            this.decreaseFontSizeToolTipButton.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // NextPageButton
            // 
            this.NextPageButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.NextPageButton.AutoSize = true;
            this.NextPageButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.NextPageButton.Enabled = false;
            this.NextPageButton.Location = new System.Drawing.Point(648, 460);
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
            this.PreviousPageButton.Location = new System.Drawing.Point(12, 460);
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
            this.label1.Location = new System.Drawing.Point(219, 465);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Текущая страница:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(436, 465);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(19, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "из";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(461, 465);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(13, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "0";
            // 
            // pageNumberTextBox
            // 
            this.pageNumberTextBox.Location = new System.Drawing.Point(330, 460);
            this.pageNumberTextBox.Name = "pageNumberTextBox";
            this.pageNumberTextBox.Size = new System.Drawing.Size(100, 20);
            this.pageNumberTextBox.TabIndex = 9;
            this.pageNumberTextBox.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 495);
            this.Controls.Add(this.pageNumberTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.PreviousPageButton);
            this.Controls.Add(this.NextPageButton);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton IncreaseFontSizeToolStripButton;
        private System.Windows.Forms.ToolStripButton decreaseFontSizeToolTipButton;
        private System.Windows.Forms.Button NextPageButton;
        private System.Windows.Forms.Button PreviousPageButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox pageNumberTextBox;
    }
}

