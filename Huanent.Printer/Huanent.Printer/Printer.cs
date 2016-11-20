using System;
using System.Collections.Generic;
using System.Linq;
using System.Printing;
using System.Text;
using System.Threading.Tasks;

namespace Huanent.Printer
{
    class Printer : IPrinter
    {
        int _paperWidth;
        PrintQueue _printer;
        int heigthOffset=0;
        internal Printer(int paperWidth, PrintQueue printer)
        {
            _paperWidth = paperWidth;
            _printer = printer;
        }

        public void FeedLine(int n)
        {
            throw new NotImplementedException();
        }

        public void Print()
        {
            throw new NotImplementedException();
        }

        public void PrintCenterText(string content, int size = 10)
        {
            throw new NotImplementedException();
        }

        public void PrintLine(char c)
        {
            throw new NotImplementedException();
        }

        public void PrintOffsetText(string content, int size = 10, int Offset = 0)
        {
            throw new NotImplementedException();
        }

        public void PrintRightOffsetText(string content, int size = 10, int offset = 0)
        {
            throw new NotImplementedException();
        }

        public void PrintRightText(string content, int size = 10)
        {
            throw new NotImplementedException();
        }

        public void PrintText(string content, int size = 10)
        {
            throw new NotImplementedException();
        }
    }
}
