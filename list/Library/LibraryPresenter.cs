using System;

namespace list
{
    public class LibraryPresenter
    {
        private readonly ILibraryView _libraryView;
        private readonly LibraryModel _libraryModel;


        public LibraryPresenter(ILibraryView libraryView, LibraryModel libraryModel)
        {
            _libraryView = libraryView ?? throw new ArgumentNullException(nameof(libraryView));
            _libraryModel = libraryModel ?? throw new ArgumentNullException(nameof(libraryModel));
        }
        
        
    }
}