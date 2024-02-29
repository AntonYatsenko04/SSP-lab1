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
            this.MinimumSize = new Size(800, 600);
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

            var isEnabled = new Binding(propertyName: "Enabled", dataSource: fileReader.readerModel,
                dataMember: "Enabled", dataSourceUpdateMode: DataSourceUpdateMode.OnPropertyChanged,
                formattingEnabled: false);
            var isEnabled2 = new Binding(propertyName: "Enabled", dataSource: fileReader.readerModel,
                dataMember: "Enabled", dataSourceUpdateMode: DataSourceUpdateMode.OnPropertyChanged,
                formattingEnabled: false);
           
            var isEnabled4 = new Binding(propertyName: "Enabled", dataSource: fileReader.readerModel,
                dataMember: "Enabled", dataSourceUpdateMode: DataSourceUpdateMode.OnPropertyChanged,
                formattingEnabled: false);
            var isEnabled5 = new Binding(propertyName: "Enabled", dataSource: fileReader.readerModel,
                dataMember: "Enabled", dataSourceUpdateMode: DataSourceUpdateMode.OnPropertyChanged,
                formattingEnabled: false);
            pageNumberTextBox.DataBindings.Add(isEnabled);
            mainTextWindow.DataBindings.Add(isEnabled2);
            
            PreviousPageButton.DataBindings.Add(isEnabled4);
            NextPageButton.DataBindings.Add(isEnabled5);

            pageNumberTextBox.DataBindings.Add(currentPageNumber);
            AllPagesCountLabel.DataBindings.Add(pageCountToLabel);
            mainTextWindow.DataBindings.Add(currentText);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void OpenFileButton_Click1(object sender, EventArgs e)
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

        

        private void previousPageButton_Click(object sender, EventArgs e)
        {
            try
            {
                fileReader.GoToPreviousPage();
            }
            catch (AppException exception)
            {
                handleException(exception.Message);
            }
        }

        private void nextPageButton_Click(object sender, EventArgs e)
        {
            try
            {
                fileReader.GoToNextPage();
            }
            catch (AppException exception)
            {
                handleException(exception.Message);
            }
        }


        private void pageNumberTextBox_TextChanged(object sender, EventArgs e)
        {
            if (!Regex.IsMatch(pageNumberTextBox.Text, @"^\d+$"))
            {
                pageNumberTextBox.Text = fileReader.readerModel.CurrentPageNumber.ToString();
            }
        }


        private void stringNumComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try{
                int newLinesCount = int.Parse(stringNumComboBox.SelectedItem.ToString());
                fileReader.SetLinesCountPerPage(newLinesCount);
            }
                catch (AppException exception)
            {
                handleException(exception.Message);
            }
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

      
    }
}