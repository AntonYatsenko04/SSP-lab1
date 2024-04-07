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
           openFileDialog1.Filter = "Text files(*.txt)|*.txt";
           this.MinimumSize = new Size(800, 600);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void OpenFileButton_Click1(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel) return;
            
            var fileName = openFileDialog1.FileName;
            _fileReaderPresenter.OpenFile(fileName);
        }


        private void previousPageButton_Click(object sender, EventArgs e)
        {
            _fileReaderPresenter.GoToPreviousPage();
        }

        private void nextPageButton_Click(object sender, EventArgs e)
        {
            _fileReaderPresenter.GoToNextPage();
        }


        private void pageNumberTextBox_TextChanged(object sender, EventArgs e)
        {
            _fileReaderPresenter.GoToPage(_pageNumberTextBox.Text);
        }
    


        private void stringNumComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            _fileReaderPresenter.SetBufferSize(int.Parse(stringNumComboBox.Text));
        }

        private void updateForm()
        {
            
           
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
            resetForm();
            MessageBox.Show(
                text: message,
                caption: "Произошла ошибка",
                buttons: MessageBoxButtons.OK,
                icon: MessageBoxIcon.Error,
                defaultButton: MessageBoxDefaultButton.Button1,
                options: MessageBoxOptions.DefaultDesktopOnly);
        }

        public void SetPagesCount(int pagesCount)
        {
            _allPagesCountLabel.Text = pagesCount.ToString();
        }

        public void SetFormActive()
        {
            NextPageButton.Enabled = true;
            PreviousPageButton.Enabled = true;
            _pageNumberTextBox.Enabled = true;
            IncreaseFontSizeToolStripButton.Enabled = true;
            decreaseFontSizeToolTipButton.Enabled = true;
            linesNumberDropDown.Enabled = true;
        }
    }
}