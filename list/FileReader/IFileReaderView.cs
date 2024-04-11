namespace list
{
    public interface IFileReaderView
    {
        void SetReaderContent(string content);

        void SetPageNumber(int pageNumber);

        void ShowErrorDialog(string message);

        void SetPagesCount(int pagesCount);
        void SetFormActive();
    }
}