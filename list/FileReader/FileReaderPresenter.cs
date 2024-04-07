using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace list
{
    public class FileReaderPresenter
    {
        private readonly IFileReaderView _fileReaderView;

        private readonly FileReaderModel _fileReaderModel;

        private string _filePath;

        public FileReaderPresenter(IFileReaderView fileReaderView, FileReaderModel fileReaderModel)
        {
            _fileReaderView = fileReaderView ?? throw new ArgumentNullException(nameof(fileReaderView));
            _fileReaderModel = fileReaderModel ?? throw new ArgumentNullException(nameof(fileReaderModel));
        }

        public void OpenFile(string filePath, int bufferSize)
        {
            try
            {
                FileStream fileStream = _fileReaderModel.OpenFile(filePath);
                ReadPage(fileStream, bufferSize, 1);
                _filePath = filePath;
            }
            catch (Exception e)
            {
                _fileReaderView.ShowErrorDialog(ErrorMessages.impossibleToReadFile);
            }
        }

        public void ReadPage(FileStream fileStream, int bufferSize, int pageNumber)
        {
            try
            {
                using (fileStream)
                {
                    long fileLength = fileStream.Length;
                    int pagesCount = (int)fileLength / bufferSize + 1;
                    using (var bufferedStream = new BufferedStream(fileStream))
                    using (var streamReader = new StreamReader(stream: bufferedStream,
                               encoding: Encoding.GetEncoding("windows-1251")))
                    {
                        int startStreamPosition = bufferSize * (pageNumber - 1);
                        bufferedStream.Position = startStreamPosition;

                        string line;
                        bool isFirstLine = true;
                        List<string> lines = new List<string>();

                        while ((line = streamReader.ReadLine()) != null &&
                               bufferedStream.Position <= startStreamPosition + bufferSize)
                        {
                            if (isFirstLine)
                            {
                                isFirstLine = false;
                                continue;
                            }

                            lines.Add(line);
                        }

                        _fileReaderView.SetReaderContent(string.Join("\n", lines));
                        _fileReaderView.SetPagesCount(pagesCount);
                        _fileReaderView.SetPageNumber(pageNumber);
                    }
                }
            }
            catch (Exception e)
            {
                _fileReaderView.ShowErrorDialog(ErrorMessages.impossibleToSetPageNumber);
            }
        }
    }
}