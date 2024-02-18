using System;
using System.Collections.Generic;

namespace list
{
    public class ReaderModel
    {
        private List<string> allLines = new List<string>();

        public int linesCount { get; set; } = 10;

        public List<string> linesToRead { get; set; } = new List<string>();

        public int PagesCount { get; set; } = 999;

        public int CurrentPageNumber { get; set; } = 999;

        private void _CountPages()
        {
            double allLinesCount = linesToRead.Count;
            var newPagesCount = (int)Math.Ceiling(allLinesCount / linesCount);
            if (newPagesCount > 0)
                PagesCount = newPagesCount;
            else
                PagesCount = 1;
        }

        public void UpdateModel()
        {
            _CountPages();
        }

        public void setAllLines(List<string> newLines)
        {
            allLines = newLines;
            UpdateModel();
        }
    }
}