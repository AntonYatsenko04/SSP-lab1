using System;
using System.Collections.Generic;
using System.IO;

namespace list
{
    internal class FileReaderImpl : IFileReader
    {
        public override void GoToNextPage()
        {
            if (readerModel.CurrentPageNumber >= readerModel.PagesCount)
                return;
            readerModel.CurrentPageNumber++;
        }

        public override void GoToPreviousPage()
        {
            if (readerModel.CurrentPageNumber <= 1)
                return;
            readerModel.CurrentPageNumber--;
        }

        public override void SetFileByPath(string path)
        {
            using (var fs = File.Open(path, FileMode.Open, FileAccess.Read))
            using (var bs = new BufferedStream(fs))
            using (var sr = new StreamReader(bs))
            {
                string line;
                var lines = new List<string>();
                while ((line = sr.ReadLine()) != null) lines.Add(line);
                readerModel.SetAllLines(lines);
            }
        }

        public override void SetLinesCountPerPage(int count)
        {
            throw new NotImplementedException();
        }

        public override void SetPageNumber()
        {
            throw new NotImplementedException();
        }
    }
}