﻿using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace list
{
    public class FileReaderPresenter
    {
        private readonly IFileReaderView _fileReaderView;

        private readonly FileReaderModel _fileReaderModel;

        private string _filePath;

        private int _currentPageNumber = 1;

        private int _bufferSize = 8192;

        public FileReaderPresenter(IFileReaderView fileReaderView, FileReaderModel fileReaderModel)
        {
            _fileReaderView = fileReaderView ?? throw new ArgumentNullException(nameof(fileReaderView));
            _fileReaderModel = fileReaderModel ?? throw new ArgumentNullException(nameof(fileReaderModel));
        }

        public void OpenFile(string filePath)
        {
            try
            {
                FileStream fileStream = _fileReaderModel.OpenFile(filePath);

                _currentPageNumber = 1;
                int pagesCount = GetPagesCount(fileStream);

                ReadPage(fileStream);

                _filePath = filePath;
                _fileReaderView.SetPageNumber(_currentPageNumber);
                _fileReaderView.SetPagesCount(pagesCount);
                _fileReaderView.SetFormActive();
            }
            catch (Exception e)
            {
                _fileReaderView.ShowErrorDialog(ErrorMessages.ImpossibleToReadFile);
            }
        }

        public void ReadPage(FileStream fileStream)
        {
            try
            {
                using (fileStream)
                {
                    using (var bufferedStream = new BufferedStream(fileStream))
                    using (var streamReader = new StreamReader(stream: bufferedStream,
                               encoding: Encoding.GetEncoding("windows-1251")))
                    {
                        int startStreamPosition = _bufferSize * (_currentPageNumber - 1);
                        bufferedStream.Position = startStreamPosition;

                        string line;
                        bool isFirstLine = true;
                        List<string> lines = new List<string>();

                        while ((line = streamReader.ReadLine()) != null &&
                               bufferedStream.Position <= startStreamPosition + _bufferSize)
                        {
                            if (isFirstLine)
                            {
                                isFirstLine = false;
                                continue;
                            }

                            lines.Add(line);
                        }

                        _fileReaderView.SetReaderContent(string.Join(Environment.NewLine, lines));
                    }
                }
            }
            catch (Exception e)
            {
                _fileReaderView.ShowErrorDialog(ErrorMessages.ImpossibleToSetPageNumber);
            }
        }

        public void GoToNextPage()
        {
            try
            {
                FileStream fileStream = _fileReaderModel.OpenFile(_filePath);
                int pagesCount = GetPagesCount(fileStream);

                if (_currentPageNumber < pagesCount && _currentPageNumber > 0)
                {
                    _currentPageNumber++;
                    ReadPage(fileStream);
                }

                _fileReaderView.SetPageNumber(_currentPageNumber);
            }
            catch (Exception e)
            {
                _fileReaderView.ShowErrorDialog(ErrorMessages.ImpossibleToIncreasePageNumber);
            }
        }

        public void GoToPreviousPage()
        {
            try
            {
                FileStream fileStream = _fileReaderModel.OpenFile(_filePath);
                int pagesCount = GetPagesCount(fileStream);

                if (_currentPageNumber <= pagesCount && _currentPageNumber >1 )
                {
                    _currentPageNumber--;
                    ReadPage(fileStream);
                }

                _fileReaderView.SetPageNumber(_currentPageNumber);
            }
            catch (Exception e)
            {
                _fileReaderView.ShowErrorDialog(ErrorMessages.ImpossibleToDecreasePageNumber);
            }
        }

        public void GoToPage(string pageNumberString)
        {
            if (!Regex.IsMatch(pageNumberString, @"^\d+$"))
            {
                _fileReaderView.SetPageNumber(_currentPageNumber);
                return;
            }
            try
            {
                int pageNumber = int.Parse(pageNumberString);
                FileStream fileStream = _fileReaderModel.OpenFile(_filePath);
                int pagesCount = GetPagesCount(fileStream);

                if (pageNumber <= pagesCount && pageNumber > 0)
                {
                    _currentPageNumber = pageNumber;
                    ReadPage(fileStream);
                }

                _fileReaderView.SetPageNumber(_currentPageNumber);
            }
            catch (Exception e)
            {
                _fileReaderView.ShowErrorDialog(ErrorMessages.ImpossibleToSetPageNumber);
            }
        }

        public int GetPagesCount(FileStream fileStream)
        {
            int pagesCount = (int)fileStream.Length / _bufferSize + 1;
            return pagesCount;
        }

        public void SetBufferSize(int bufferSize)
        {
            int oldBufferSize = _bufferSize;
            _bufferSize = bufferSize;
            int newPageNumber = oldBufferSize * _currentPageNumber / _bufferSize;
            GoToPage(newPageNumber.ToString());
        }
    }
}