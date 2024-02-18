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
        private int _lineIncrement = 10;
        private string _filePath;
        private int _offsetIncrement = 1024;
        private int _currentPageNumber=1;
        private List<string> _lines = new List<string>();
        

        public FileReader(string filePath)
        {
            _filePath = filePath ?? throw new ArgumentNullException(nameof(filePath));
        }

        public string getThisPage()
        {
            List<string> lines = new List<string>();
            try
            {
                using (StreamReader streamReader = new StreamReader(_filePath, Encoding.GetEncoding(1251)))
                {
                    int firstLineNumber = _currentPageNumber * _lineIncrement - _lineIncrement;
                    int lastLineNumber = firstLineNumber + _lineIncrement;

                    string line;
                    for (int counter = 0; (line = streamReader.ReadLine()) != null && counter <= lastLineNumber; counter++)
                    {

                        if (counter < firstLineNumber)
                        {
                            continue;
                        }


                        lines.Add(line);
                    }
                }
            }catch (Exception e)
            {
                throw new Exception("No file found");
            }
            
            return string.Join(Environment.NewLine, lines).Trim();
        }

        public void setCurrentPageNumber(int pageNumber)
        {
            if (pageNumber > this.getPagesCount())
            {
                _currentPageNumber = this.getPagesCount();
            }else if(pageNumber < 1)
            {
                _currentPageNumber = 1;
            }
            else
            {
                _currentPageNumber = pageNumber;
            }
        }

        public string getNextPage()
        {
            if(_currentPageNumber< this.getPagesCount())
            {
                _currentPageNumber++;
            }
            return getThisPage();
        }

        public string getPreviousPage()
        {
            if (_currentPageNumber > 1)
            {
                _currentPageNumber--;
            }
            return getThisPage();
        }
        public int getCurrentPageNumber()
        {
            return _currentPageNumber;
        }
        public int getPagesCount()
        {
            double counter = 0;
            try
            {
                using (StreamReader streamReader = new StreamReader(_filePath, Encoding.GetEncoding(1251)))
                {
                    while ((streamReader.ReadLine()) != null)
                    {
                        counter++;
                    }
                }
                double pagesCount = (counter / _lineIncrement);

                return (int)Math.Ceiling(pagesCount)==0?1: (int)Math.Ceiling(pagesCount);

            }
            catch (Exception e)
            {
                throw new Exception("No file found");
            }
            
        } 
        public void setLineIncrement(double newIncrement)
        {
            Console.WriteLine("line incr");
            Console.WriteLine(_currentPageNumber);
            Console.WriteLine(newIncrement);
            Console.WriteLine(_lineIncrement);
            setCurrentPageNumber((int)Math.Floor(_currentPageNumber / newIncrement * _lineIncrement));
            Console.WriteLine(_currentPageNumber);
            _lineIncrement = (int)Math.Ceiling(newIncrement);
            
        }
    }
}
