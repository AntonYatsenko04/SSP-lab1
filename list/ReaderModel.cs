using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace list
{
    public class ReaderModel : INotifyPropertyChanged
    {
        private string _linesToRead;
        private int _pagesCount = 1;
        private int _currentPageNumber = 1;

        public string LinesToRead
        {
            get { return _linesToRead; }
            set
            {
                _linesToRead = value;
                OnPropertyChanged();
            }
        }

        public int PagesCount
        {
            get => _pagesCount;
             set
            {
                if (value == _pagesCount) return;
                _pagesCount = value;
                OnPropertyChanged();
            }
        }

        public int CurrentPageNumber
        {
            get => _currentPageNumber;
            set
            {
                _currentPageNumber = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}