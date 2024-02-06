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
            //this.MaximumSize = new Size(1200, 900);
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

            // читаем файл в строку
            string fileText = fileReader.getThisPage();
            mainTextWindow.Text = fileText;
            updateForm();
        }

        private void IncreaseFontSizeButton_Click(object sender, EventArgs e)
        {
            mainTextWindow.Font = new Font(mainTextWindow.Font.FontFamily, mainTextWindow.Font.Size+1);
        }

        private void decreaseFontSizeToolStripButton_Click(object sender, EventArgs e)
        {
            mainTextWindow.Font = new Font(mainTextWindow.Font.FontFamily, mainTextWindow.Font.Size - 1);
        }

        private void previousPageButton_Click(object sender, EventArgs e)
        {
            try
            {
                string fileText = fileReader.getPreviousPage();
                mainTextWindow.Text = fileText;
                pageNumberTextBox.Text = fileReader.getCurrentPageNumber().ToString();
            }catch
            {
                handleException();
            }

        }

        private void nextPageButton_Click(object sender, EventArgs e)
        {
            try
            {
                string fileText = fileReader.getNextPage();
                mainTextWindow.Text = fileText;
                pageNumberTextBox.Text = fileReader.getCurrentPageNumber().ToString();
            }
            catch
            {
                handleException();
            }

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pageNumberTextBox_TextChanged(object sender, EventArgs e)
        {
            string textBoxText = pageNumberTextBox.Text;
            bool isNumber = Regex.IsMatch(textBoxText, @"^\d+$");
            int maxCurrentPagesCount;
            try
            {
                maxCurrentPagesCount = fileReader.getPagesCount();
            }
            catch
            {
                handleException();
                return;
            }
            
            if (!isNumber)
            {
                pageNumberTextBox.Text = "1";
            }
            else if (int.Parse(textBoxText)>maxCurrentPagesCount)
            {
                try
                {
                    pageNumberTextBox.Text = fileReader.getPagesCount().ToString();
                }
                catch
                {
                    handleException();
                }
                
            }
        }

        private void pageNumberTextBox_Leave(object sender, EventArgs e)
        {
            try
            {
                fileReader.setCurrentPage(int.Parse(pageNumberTextBox.Text));
                mainTextWindow.Text = fileReader.getThisPage();
            }
            catch
            {
                handleException();
            }

        }

        private void linesNumberDropDown_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            Console.WriteLine("das");
        }

        private void toolStripComboBox1_Click(object sender, EventArgs e)
        {
            Console.WriteLine("das");

        }

        private void stringNumComboBox_DropDown(object sender, EventArgs e)
        {

        }

        private void stringNumComboBox_Click(object sender, EventArgs e)
        {
            Console.WriteLine("das");
        }

        private void stringNumComboBox_DropDownStyleChanged(object sender, EventArgs e)
        {
           
        }

        private void stringNumComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            { 
            fileReader.setLineIncrement(int.Parse(stringNumComboBox.SelectedItem.ToString()));
            mainTextWindow.Text = fileReader.getThisPage(); 
            }
            catch
            {
                handleException();
            }
            updateForm();
        }
        private void updateForm()
        {
            NextPageButton.Enabled = true;
            PreviousPageButton.Enabled = true;
            pageNumberTextBox.Enabled = true;
            IncreaseFontSizeToolStripButton.Enabled = true;
            decreaseFontSizeToolTipButton.Enabled = true;
            linesNumberDropDown.Enabled = true;
            try
            {
                pageNumberTextBox.Text = fileReader.getCurrentPageNumber().ToString();
                AllPagesCountLabel.Text = fileReader.getPagesCount().ToString();
            }
            catch
            {
                handleException();
            }
            
        }
        private void resetForm()
        {
            fileReader = null;
            NextPageButton.Enabled = false;
            PreviousPageButton.Enabled = false;
            pageNumberTextBox.Enabled = false;
            IncreaseFontSizeToolStripButton.Enabled = false;
            decreaseFontSizeToolTipButton.Enabled = false;
            linesNumberDropDown.Enabled = false;
            pageNumberTextBox.Text = "1";
            AllPagesCountLabel.Text = "1";
            mainTextWindow.Text="";
        }
        private void handleException()
        {
            resetForm();
      //      MessageBox.Show(
      // "Произошла ошибка",
      // "Сообщение",
      // MessageBoxButtons.OK,
      // MessageBoxIcon.Information,
      // MessageBoxDefaultButton.Button1,
      // MessageBoxOptions.DefaultDesktopOnly);
            
        }
    }    
}
