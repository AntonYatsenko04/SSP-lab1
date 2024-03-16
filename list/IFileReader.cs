using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace list
{
    abstract class IFileReader
    {
        public readonly ReaderModel readerModel = new ReaderModel();
        public abstract void InitialiseFileReader(string path);
        public abstract void SetBufferSize(int size);
        public abstract void SetPageNumber(int pageNumber);
        public abstract void GoToNextPage();
        public abstract void GoToPreviousPage();

        public abstract void readPage();
    }
}
