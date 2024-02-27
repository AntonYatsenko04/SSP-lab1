using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;

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
            using (var sr = new StreamReader(stream: bs,encoding:Encoding.GetEncoding("windows-1251")))
            {
                string line;
                var lines = new List<string>();
                while ((line = sr.ReadLine()) != null) lines.Add(line);
                readerModel.SetAllLines(lines);
            }
        }

        public override void SetLinesCountPerPage(int count)
        {
            readerModel.LinesCount = count;
        }

        public override void SetPageNumber(int pageNumber)
        {
            if (pageNumber > readerModel.PagesCount||pageNumber<1)
            {
                throw new AppException(message:"Неправильно выбран номер страницы");
            }
            readerModel.CurrentPageNumber = pageNumber;
        }
    }
}