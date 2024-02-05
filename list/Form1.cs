using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;

namespace list
{
    public partial class Form1 : Form
    {
        FileReader fileReader=null;
        bool pageButtonsDisabled=false;
        int currentPage = 1;
        int maxPages = 1;
        public Form1()
        {
            InitializeComponent();
            openFileDialog1.Filter = "Text files(*.txt)|*.txt";
            this.MinimumSize = new Size(800, 600);
            this.MaximumSize = new Size(1200, 900);
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }
                
            // получаем выбранный файл
            string filename = openFileDialog1.FileName;
            fileReader = new FileReader(filename);
            NextPageButton.Enabled=true;
            PreviousPageButton.Enabled = true;
            // читаем файл в строку
            string fileText = fileReader.getThisPage();
            textBox1.Text = fileText;
            MessageBox.Show("Файл открыт");
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void IncreaseFontSizeButton_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {

        }

        private void previousPageButton_Click(object sender, EventArgs e)
        {
            string fileText = fileReader.getPreviousPage();
            textBox1.Text = fileText;
        }

        private void nextPageButton_Click(object sender, EventArgs e)
        {
     
            string fileText = fileReader.getNextPage();
            textBox1.Text = fileText;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            bool isNumber = Regex.IsMatch(pageNumberTextBox.Text, @"^\d+$");
            if (!isNumber)
            {
                pageNumberTextBox.Text = "";
            }
        }
        private void selectPage()
        {

        }
    }    
}
