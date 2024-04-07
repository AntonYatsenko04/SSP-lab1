using System;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace list
{
    public partial class FileReaderView : Form, IFileReaderView
    {
        private readonly FileReaderPresenter _fileReaderPresenter;
        private readonly IFileReader fileReader = new FileReaderImpl();
        private readonly string fileSystemErrorMsg = "Проблемы файловой системы";
        private int currentPage = 1;
        private bool isDisabled = true;
        private int maxPages = 1;
        private bool pageButtonsDisabled = false;
        private bool isInit { get; set; } = false;

        public FileReaderView()
        {
            _fileReaderPresenter = new FileReaderPresenter(this, new FileReaderModel());
           InitializeComponent();
           //InitializeBindings();
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


            _pageNumberTextBox.DataBindings.Add(currentPageNumber);
            AllPagesCountLabel.DataBindings.Add(pageCountToLabel);
            _mainTextWindow.DataBindings.Add(currentText);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void OpenFileButton_Click1(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel) return;
            
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
                //handleException(exception.message);
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

                    if (!Regex.IsMatch(_pageNumberTextBox.Text, @"^\d+$"))
                    {
                        _pageNumberTextBox.Text = prevPageNumber.ToString();
                    }
                    else
                    {
                        
                        if (fileReader.hasAccessToFile())
                        {
                            try
                            {
                                fileReader.SetPageNumber(int.Parse(_pageNumberTextBox.Text));
                            }
                            catch (Exception exception)
                            {
                                _pageNumberTextBox.Text = prevPageNumber.ToString();
                            }
                            fileReader.readPage();
                        }
                        else
                        {
                            handleException(ErrorMessages.impossibleToReadFile);
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
                
                    handleException(ErrorMessages.impossibleToReadFile);
                
                
            }
            catch (Exception exception)
            {
                handleException(ErrorMessages.impossibleToReadFile);
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
            _pageNumberTextBox.Enabled = true;
            IncreaseFontSizeToolStripButton.Enabled = true;
            decreaseFontSizeToolTipButton.Enabled = true;
            linesNumberDropDown.Enabled = true;
           
        }

        private void resetForm()
        {
            NextPageButton.Enabled = false;
            PreviousPageButton.Enabled = false;
            _pageNumberTextBox.Enabled = false;
            IncreaseFontSizeToolStripButton.Enabled = false;
            decreaseFontSizeToolTipButton.Enabled = false;
            linesNumberDropDown.Enabled = false;
            isInit = false;
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
            if (_mainTextWindow.Font.Size < 50)
                _mainTextWindow.Font = new Font(_mainTextWindow.Font.FontFamily, _mainTextWindow.Font.Size + 1);
        }

        private void decreaseFontSizeToolStripButton_Click(object sender, EventArgs e)
        {
            if (_mainTextWindow.Font.Size > 5)
                _mainTextWindow.Font = new Font(_mainTextWindow.Font.FontFamily, _mainTextWindow.Font.Size - 1);
        }


        public void SetReaderContent(string content)
        {
            if (content != null)
            {
                _mainTextWindow.Text = content; 
            }
        }

        public void SetPageNumber(int pageNumber)
        {
            _pageNumberTextBox.Text = pageNumber.ToString();
        }

        public void ShowErrorDialog(string message)
        {
            throw new NotImplementedException();
        }

        public void SetPagesCount(int pagesCount)
        {
            throw new NotImplementedException();
        }
    }
}