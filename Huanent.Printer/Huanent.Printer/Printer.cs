using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Printing;
using System.Text;
using System.Threading.Tasks;

namespace Huanent.Printer
{
    class Printer : IPrinter
    {
        int _paperWidth;
        PrintDocument _printer;
        int _heigthOffset = 0;
        Action _doPrint;
        List<Action<PrintPageEventArgs>> _doPrintList = new List<Action<PrintPageEventArgs>>();
        /// <summary>
        /// 打印机对象
        /// </summary>
        /// <param name="paperWidth"></param>
        /// <param name="printer"></param>
        internal Printer(int paperWidth, PrintDocument printer)
        {
            _paperWidth = paperWidth;
            _printer = printer;
            _doPrint = printer.Print;
            printer.PrintPage += (s, e) =>
            {
                foreach (var item in _doPrintList)
                {
                    item?.Invoke(e);
                }
            };
        }

        public void FeedLine(int n)
        {
            throw new NotImplementedException();
        }

        public void Print()
        {
            _doPrint();
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
