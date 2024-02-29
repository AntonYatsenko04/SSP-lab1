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

        public bool Enabled
        {
            get => _enabled;
            set => _enabled = value;
        }

        public int LinesCount
        {
            get => _linesCount;
            set
            {
                int currentStartLineNumber = (CurrentPageNumber - 1) * LinesCount;
                int newPageNumber = currentStartLineNumber / value;
                _linesCount = value;
                OnPropertyChanged();
                CurrentPageNumber = newPageNumber;
                _CountPages();
                _setLinesToRead();
                OnPropertyChanged();
            }
        }

        private string _linesToRead;
        private  int _pagesCount = 1;
        private int _currentPageNumber = 1;
        private int _linesCount = 10;
        private bool _enabled;

        public string LinesToRead
        {
            get
            {
                return _linesToRead;
            }
            set
            {
                //if (value == _linesToRead) return;
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
                if (value > PagesCount||value<1)
                {
                    return;
                }
                _currentPageNumber = value;
                _setLinesToRead();
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
            OnPropertyChanged();
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
            int endLineNumber = startLineNumber + LinesCount;
            var stringBuilder = new StringBuilder();
            for (int i = startLineNumber; i < endLineNumber; i++)
            {
                stringBuilder.AppendLine(_allLines[i]);
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