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
        private bool isInit { get; set; } = false;

        public Form1()
        { 
           InitializeComponent();
           InitializeBindings();
           openFileDialog1.Filter = "Text files(*.txt)|*.txt";
           this.MinimumSize = new Size(800, 600);
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

        private void OpenFileButton_Click1(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel) return;

            // получаем выбранный файл
            var filename = openFileDialog1.FileName;
            if (ReadFromEndUntilDot(filename) != "txt")
            {
                handleException("Неправильно выбран тип файла");
                return;
            }

            try
            {
                fileReader.InitialiseFileReader(filename);
                Console.Write(filename);
                updateForm();
                isDisabled = false;
            }
            catch (AppException exception)
            {
                handleException(exception.message);
            }
        }


        private void previousPageButton_Click(object sender, EventArgs e)
        {
            try
            {
                fileReader.GoToPreviousPage();
                fileReader.readPage();
            }
            catch (AppException exception)
            {
                handleException(exception.message);
            }
        }

        private void nextPageButton_Click(object sender, EventArgs e)
        {
            try
            {
                fileReader.GoToNextPage();
                fileReader.readPage();
            }
            catch (AppException exception)
            {
                handleException(exception.message);
            }
        }


        private void pageNumberTextBox_TextChanged(object sender, EventArgs e)
        {
            int prevPageNumber = fileReader.readerModel.CurrentPageNumber;
            
            try
            {
                
            
                if (isInit)
                {
            
                    if (!Regex.IsMatch(pageNumberTextBox.Text, @"^\d+$"))
                    {
            
                        pageNumberTextBox.Text = fileReader.readerModel.CurrentPageNumber.ToString();
                    }
                    else
                    {
                        if (fileReader.hasAccessToFile())
                        {
                            fileReader.SetPageNumber(int.Parse(pageNumberTextBox.Text));
                            fileReader.readPage();
                        }
                        else
                        {
                            throw new AppException();
                        }
                        
                    }
                }
                else
                {
                    isInit = true;
                }
            }
            catch (AppException exception)
            {
                pageNumberTextBox.Text = prevPageNumber.ToString();
            }
            
        }
    


    private void stringNumComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int newLinesCount = int.Parse(stringNumComboBox.SelectedItem.ToString());
                fileReader.SetBufferSize(newLinesCount);
            }
            catch (AppException exception)
            {
                handleException(exception.message);
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
           
        }

        private void resetForm()
        {
            NextPageButton.Enabled = false;
            PreviousPageButton.Enabled = false;
            pageNumberTextBox.Enabled = false;
            IncreaseFontSizeToolStripButton.Enabled = false;
            decreaseFontSizeToolTipButton.Enabled = false;
            linesNumberDropDown.Enabled = false;
            
        }

        private void handleException(string errorMessage)
        {
            resetForm();
            MessageBox.Show(
                text: errorMessage,
                caption: "Произошла ошибка",
                buttons: MessageBoxButtons.OK,
                icon: MessageBoxIcon.Error,
                defaultButton: MessageBoxDefaultButton.Button1,
                options: MessageBoxOptions.DefaultDesktopOnly);
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