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
        public abstract void SetFileByPath(string path);
        public abstract void SetLinesCountPerPage(int count);
        public abstract void SetPageNumber();
        public abstract void GoToNextPage();
        public abstract void GoToPreviousPage();
    }
}
