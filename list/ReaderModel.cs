using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace list
{
    public class ReaderModel : INotifyPropertyChanged
    {
        private List<string> _allLines = new List<string>();

        public int LinesCount { get; set; } = 10;

        private string _linesToRead;
        private  int _pagesCount = 1;
        private int _currentPageNumber = 1;

        public string LinesToRead
        {
            get
            {
                return _linesToRead;
            }
            set
            {
                if (value == _linesToRead) return;
                _linesToRead = value; 
                OnPropertyChanged();
            }
        }

        public int PagesCount
        {
            get => _pagesCount;
            private set
            {
                if (value == _pagesCount) return;
                _pagesCount = value;
                _CountPages();
                OnPropertyChanged();
            }
        }

        public int CurrentPageNumber
        {
            get => _currentPageNumber;
            set
            {
                if (value == _currentPageNumber) return;
                _currentPageNumber = value;
                OnPropertyChanged();
            }
        }

        private void _CountPages()
        {
            double allLinesCount = _allLines.Count;
            var newPagesCount = (int)Math.Ceiling(allLinesCount / LinesCount);
            if (newPagesCount > 0)
            {
                PagesCount = newPagesCount;
            }
            else
            {
                PagesCount = 1;
            }
        }

        private void UpdateModel()
        {
            CurrentPageNumber = 1;
            _CountPages();
            _setLinesToRead();
        }

        public void SetAllLines(List<string> newLines)
        {
            _allLines = newLines;
            UpdateModel();
        }

        private void _setLinesToRead()
        {
            int startLineNumber = LinesCount * (CurrentPageNumber - 1);
            PagesCount = 222;
            int endLineNumber = startLineNumber + LinesCount;
            var stringBuilder = new StringBuilder();
            for (int i = startLineNumber; i < endLineNumber; i++)
            {
                stringBuilder.Append(_allLines[i]);
            }
            LinesToRead = stringBuilder.ToString();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}