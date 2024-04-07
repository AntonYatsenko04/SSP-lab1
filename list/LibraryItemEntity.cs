using System;

namespace list
{
    public class LibraryItemEntity
    {
        public readonly int PageNumber;
        public readonly int FontSize;
        public readonly int BufferSize;
        public readonly string FilePath;
        
        public LibraryItemEntity(int pageNumber, int fontSize, int bufferSize, string filePath)
        {
            PageNumber = pageNumber;
            FontSize = fontSize;
            BufferSize = bufferSize;
            FilePath = filePath ?? throw new ArgumentNullException(nameof(filePath));
        }
    }
}