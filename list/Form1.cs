using System;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace list
{
    public partial class Form1 : Form
    {
        private readonly IFileReader fileReader = new FileReaderImpl();
        private readonly string fileSystemErrorMsg = "Проблемы файловой системы";
        private int currentPage = 1;
        private FileReader fReader;
        private bool isDisabled = true;
        private int maxPages = 1;
        private bool pageButtonsDisabled = false;

        public Form1()
        {
            InitializeComponent();
            InitializeBindings();
            openFileDialog1.Filter = "Text files(*.txt)|*.txt";
            MinimumSize = new Size(800, 600);
            //this.MaximumSize = new Size(1200, 900);
        }

        private void InitializeBindings()
        {
            var pageCountToLabel = new Binding(propertyName: "Text", dataSource: fileReader.readerModel,
                dataMember: "PagesCount", dataSourceUpdateMode: DataSourceUpdateMode.OnPropertyChanged,
                formattingEnabled: false);
            var currentPageNumber = new Binding(propertyName: "Text", dataSource: fileReader.readerModel,
                dataMember: "CurrentPageNumber", dataSourceUpdateMode: DataSourceUpdateMode.OnPropertyChanged,
                formattingEnabled: false);
            var currentText = new Binding(propertyName: "Text", dataSource: fileReader.readerModel,
                dataMember: "LinesToRead", dataSourceUpdateMode: DataSourceUpdateMode.OnPropertyChanged,
                formattingEnabled: false);

            pageNumberTextBox.DataBindings.Add(currentPageNumber);
            AllPagesCountLabel.DataBindings.Add(pageCountToLabel);
            mainTextWindow.DataBindings.Add(currentText);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel) return;

            // получаем выбранный файл
            var filename = openFileDialog1.FileName;
            if (ReadFromEndUntilDot(filename) != "txt")
            {
                MessageBox.Show("Неправильно выбран файл");
                return;
            }

            Console.Write(filename);
            fileReader.SetFileByPath(filename);
            updateForm();
            //fReader = new FileReader(filename);
            isDisabled = false;
            // читаем файл в строку

            // mainTextWindow.Text = fileText;
        }

        public static string ReadFromEndUntilDot(string input)
        {
            var dotIndex = input.LastIndexOf('.');
            if (dotIndex != -1)
            {
                var result = input.Substring(dotIndex + 1);
                return result;
            }

            return string.Empty;
        }

        private void IncreaseFontSizeButton_Click(object sender, EventArgs e)
        {
            if (mainTextWindow.Font.Size < 50)
                mainTextWindow.Font = new Font(mainTextWindow.Font.FontFamily, mainTextWindow.Font.Size + 1);
        }

        private void decreaseFontSizeToolStripButton_Click(object sender, EventArgs e)
        {
            if (mainTextWindow.Font.Size > 5)
                mainTextWindow.Font = new Font(mainTextWindow.Font.FontFamily, mainTextWindow.Font.Size - 1);
        }

        private void previousPageButton_Click(object sender, EventArgs e)
        {
            try
            {
                fileReader.GoToPreviousPage();
            }
            catch
            {
                handleException(fileSystemErrorMsg);
            }
        }

        private void nextPageButton_Click(object sender, EventArgs e)
        {
            try
            {
                fileReader.GoToNextPage();
            }
            catch
            {
                handleException(fileSystemErrorMsg);
            }
        }
        

        private void pageNumberTextBox_TextChanged(object sender, EventArgs e)
        {
            var oldTextBoxText = pageNumberTextBox.Text;
            var isNumber = Regex.IsMatch(textBoxText, @"^\d+$");
            if (!isNumber)
            {
                return;
            }
            int maxCurrentPagesCount;
            try
            {
               fileReader.SetPageNumber();
            }
            catch
            {
                handleException(fileSystemErrorMsg);
                return;
            }

            
        }

        private void pageNumberTextBox_Leave(object sender, EventArgs e)
        {
            try
            {
                fReader.setCurrentPageNumber(int.Parse(pageNumberTextBox.Text));
                mainTextWindow.Text = fReader.getThisPage();
            }
            catch
            {
                handleException(fileSystemErrorMsg);
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
                fReader.setLineIncrement(int.Parse(stringNumComboBox.SelectedItem.ToString()));
                pageNumberTextBox.Text = fReader.getCurrentPageNumber().ToString();
                mainTextWindow.Text = fReader.getThisPage();
            }
            catch
            {
                handleException(fileSystemErrorMsg);
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
            // try
            // {
            //     pageNumberTextBox.Text = fReader.getCurrentPageNumber().ToString();
            //     AllPagesCountLabel.Text = fReader.getPagesCount().ToString();
            // }
            // catch
            // {
            //     handleException(fileSystemErrorMsg);
            // }
        }

        private void resetForm(string errorMessage)
        {
            // if (!isDisabled)
            // {
            //     MessageBox.Show(errorMessage);
            //     fReader = null;
            //     NextPageButton.Enabled = false;
            //     PreviousPageButton.Enabled = false;
            //     pageNumberTextBox.Enabled = false;
            //     IncreaseFontSizeToolStripButton.Enabled = false;
            //     decreaseFontSizeToolTipButton.Enabled = false;
            //     linesNumberDropDown.Enabled = false;
            //     pageNumberTextBox.Text = "1";
            //     AllPagesCountLabel.Text = "1";
            //     mainTextWindow.Text = "";
            // }
        }

        private void handleException(string errorMessage)
        {
            //resetForm(errorMessage);
            //      MessageBox.Show(
            // "Произошла ошибка",
            // "Сообщение",
            // MessageBoxButtons.OK,
            // MessageBoxIcon.Information,
            // MessageBoxDefaultButton.Button1,
            // MessageBoxOptions.DefaultDesktopOnly);
        }

        private void mainTextWindow_TextChanged(object sender, EventArgs e)
        {
        }

        private void AllPagesCountLabel_Click(object sender, EventArgs e)
        {
        }
    }
}