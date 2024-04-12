using System.Collections.Generic;

namespace list
{
    public interface IFileReaderView
    {
        void SetReaderContent(string content);

        void SetPageNumber(int pageNumber);

        void ShowErrorDialog(string message,bool disableForm = true);

        void SetPagesCount(int pagesCount);
        void SetBufferSize(int pagesCount);
        void SetFormActive();

        void SetLibrary(List<LibraryItemEntity> libraryItemEntities);

        void SetFontSize(float fontSize);
        
        
    }
}