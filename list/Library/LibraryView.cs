using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace list
{
    public partial class LibraryView : Form, ILibraryView
    {
        private readonly LibraryPresenter _libraryPresenter;
        public LibraryView()
        {
            InitializeComponent();
        }
        
        public void ClearLibraryList()
        {
            throw new NotImplementedException();
        }

        public void FillLibraryList(List<LibraryItemEntity> libraryItemEntities)
        {
            throw new NotImplementedException();
        }

        public void ShowErrorDialog(string message)
        {
            throw new NotImplementedException();
        }
    }
}