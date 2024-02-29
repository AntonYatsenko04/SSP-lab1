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
            try
            {
                if (readerModel.CurrentPageNumber >= readerModel.PagesCount)
                    return;
                readerModel.CurrentPageNumber++;
            }
            catch
            {
                throw new AppException("Возникла внутренняя ошибка. Невозможно увеличить номер страницы");
            }
        }

        public override void GoToPreviousPage()
        {
            try
            {
                if (readerModel.CurrentPageNumber <= 1)
                    return;
                readerModel.CurrentPageNumber--; 
            }
            catch
            {
                throw new AppException("Возникла внутренняя ошибка. Невозможно уменьшить номер страницы");
            }
            
        }

        public override void SetFileByPath(string path)
        {
            try
            {

                using (var fs = File.Open(path, FileMode.Open, FileAccess.Read))
                using (var bs = new BufferedStream(fs))
                using (var sr = new StreamReader(stream: bs, encoding: Encoding.GetEncoding("windows-1251")))
                {
                    Console.WriteLine(bs.Length);
                    if (bs.Length > 524288000)
                    {
                        throw new AppException("Размер файла не должен превышать 500 мб");
                    }

                    string line;
                    var lines = new List<string>();
                    while ((line = sr.ReadLine()) != null) lines.Add(line);
                    readerModel.SetAllLines(lines);
                    readerModel.Enabled = true;
                }
            }
            catch (AppException exception)
            {
                throw;
            }
            catch
            {
                throw new AppException("Возникла внутренняя ошибка. Невозможно прочитать данный файл");
            }
        }

        public override void SetLinesCountPerPage(int count)
        {
            try
            {
                readerModel.LinesCount = count;
            }
            catch
            {
                throw new AppException("Возникла внутренняя ошибка. Невозможно установить новое значение количества строк"); 
            }
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