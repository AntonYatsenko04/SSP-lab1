using System.Text.Json;
namespace list
{
    public class FileInfoEntity
    {
        public  int PagesCount { get; set; }
        public  int CurrentPageNumber { get; set; }
        
        public FileInfoEntity(int pagesCount, int currentPageNumber)
        {
            PagesCount = pagesCount;
            CurrentPageNumber = currentPageNumber;
        }
    }
}