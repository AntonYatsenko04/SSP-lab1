using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace list
{
    public class FileReader
    {
        private int _currentLinePosition = 0;
        private int _lineIncrement = 40;
        private string _filePath;
        private int _offsetIncrement = 1024;
        

        public FileReader(string filePath)
        {
            _filePath = filePath ?? throw new ArgumentNullException(nameof(filePath));
        }

        public string getThisPage()
        {
            List<string> lines = new List<string>();
            using (StreamReader streamReader = new StreamReader(_filePath, Encoding.GetEncoding(1251)))
            {

                int firstLineNumber = _currentLinePosition;
                int lastLineNumber = _currentLinePosition+_lineIncrement;                
                for (int counter = 0; (streamReader.ReadLine())!=null&&counter<= lastLineNumber; counter++)
                {
                    if (counter< firstLineNumber)
                    {
                        continue;
                    }
                    lines.Add(streamReader.ReadLine());
                }
            }
            return string.Join(Environment.NewLine, lines).TrimEnd();
        }

        public void setCurrentPage(uint pageNumber)
        {

        }

        public string getNextPage()
        {
            
            return getThisPage();
        }

        public string getPreviousPage()
        {
            
            return getThisPage();
        }
        public int getPagesCount()
        {
            uint counter = 0;
            using (StreamReader streamReader = new StreamReader(_filePath, Encoding.GetEncoding(1251)))
            {
                while ((streamReader.ReadLine()) != null)
                {
                    counter++;
                }
            }
            double pagesCount=(counter / _lineIncrement);
            return (int) Math.Ceiling(pagesCount);
        } 
    }
}
