using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace list
{
    internal class FileReaderImpl : IFileReader
    {
        private byte[] _fileHash;
        private int buffersize = 8192;
        private string path;
        private long fileLength;
        

        private long _currentStreamPosition => buffersize * (readerModel.CurrentPageNumber - 1);

        

        public override void readPage()
        {
            try
            {
                if (path == null)
                {
                    throw new AppException("Указанный файл не удалось открыть");
                }
                using (var fs = File.Open(path, FileMode.Open, FileAccess.Read))
                {
                    fileLength = fs.Length;
                    readerModel.PagesCount = (int)fileLength / buffersize + 1;
                    using (var bs = new BufferedStream(fs))
                    using (var sr = new StreamReader(stream: bs, encoding: Encoding.GetEncoding("windows-1251")))
                    {
                        bs.Position = _currentStreamPosition;
                        string line;
                        int symbolNumber;
                        List<string> lines = new List<string>();
                        var stringBuilder = new StringBuilder();
                        // while ((symbolNumber = sr.Read()) != -1 && bs.Position <= _currentStreamPosition + buffersize)
                        // {
                        //     Encoding windows1251 = Encoding.GetEncoding("windows-1251");
                        //
                        //     // Преобразуем значение типа int в байтовый массив
                        //     byte[] bytes = BitConverter.GetBytes(symbolNumber);
                        //
                        //     string symbol = windows1251.GetString(bytes);
                        //     stringBuilder.Append(symbol);
                        // }
                        //readerModel.LinesToRead=(stringBuilder.ToString());
                        bool isFirstLine = true;
                        while ((line = sr.ReadLine()) != null && bs.Position <= _currentStreamPosition + buffersize)
                        {
                            if (isFirstLine)
                            {
                                isFirstLine = false;
                                continue;
                            }
                            lines.Add(line);
                        }
                             
                        _SetLinesToRead(lines);
                        
                    }
                }
            }
            catch (AppException e)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new AppException("Не получилось открыть файл");
            }
        }

        public override void InitialiseFileReader(string path)
        {
            try
            {
                var file  = File.Open(path, FileMode.Open, FileAccess.Read);
                fileLength = file.Length;
                this.path = path;
                readerModel.PagesCount = (int)fileLength / buffersize + 1;
                readerModel.CurrentPageNumber = 1;
                file.Close();
                readPage();
            }
            catch (AppException exception)
            {
                throw;
            }
            catch (Exception e)
            {
                e.ToString();
                throw new AppException("Возникла внутренняя ошибка. Невозможно прочитать данный файл");
            }

            

        }

        public override void SetBufferSize(int size)
        {
            try
            {
                buffersize = size;
                SetPageNumber(1);
                readPage();
            }
            catch
            {
                throw new AppException("Возникла внутренняя ошибка. Невозможно установить новое значение размера"); 
            }
        }

        
        private void _SetLinesToRead(List<string> lines)
        {
            var stringBuilder = new StringBuilder();
            foreach (string line in lines)
            {
                stringBuilder.AppendLine(line);
            }
            readerModel.LinesToRead = stringBuilder.ToString();
        }
        
        public override void SetPageNumber(int pageNumber)
        {
            try
            {
                if (pageNumber > readerModel.PagesCount || pageNumber < 1)
                {
                    throw new AppException(message: "Неправильно выбран номер страницы");
                }

                readerModel.CurrentPageNumber = pageNumber;
                // readPage();
            }
            catch
            {
                throw new AppException("Невозможно установить номер страницы");
            }
        }
        public override void GoToNextPage()
        {
            try
            {
                if (readerModel.CurrentPageNumber >= readerModel.PagesCount)
                    return;
                readerModel.CurrentPageNumber++;
                // readPage();
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
                // readPage();
            }
            catch
            {
                throw new AppException("Возникла внутренняя ошибка. Невозможно уменьшить номер страницы");
            }
            
        }
    }
}