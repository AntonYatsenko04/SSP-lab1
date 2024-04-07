namespace list
{
    public class FileInfoEntity
    {
        public readonly int PagesCount;
        public readonly int CurrentPageNumber;
        
        public FileInfoEntity(int pagesCount, int currentPageNumber)
        {
            PagesCount = pagesCount;
            CurrentPageNumber = currentPageNumber;
        }
    }
}