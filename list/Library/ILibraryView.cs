using System.Collections.Generic;

namespace list
{
    public interface ILibraryView
    {
        void ClearLibraryList();

        void FillLibraryList(List<LibraryItemEntity> libraryItemEntities);

        void ShowErrorDialog(string message);
    }
}