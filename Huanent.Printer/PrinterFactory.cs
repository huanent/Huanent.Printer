using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintCore
{
    public static class PrinterFactory
    {
        public static Printer GetPrinter(string printerName, double paperWidth, int? pagerHeight = null)
        {
            if (string.IsNullOrEmpty(printerName)) throw new ArgumentException(nameof(printerName));
            return new Printer(printerName, paperWidth, pagerHeight ?? 10000);
        }

        public static Printer GetPrinter(string printerName, PaperWidth paperWidth, int? pagerHeight = null)
        {
            switch (paperWidth)
            {
                case PaperWidth.Paper80mm:
                    //80打印纸扣去两边内距实际可打的宽度为72.1
                    return GetPrinter(printerName, 72.1, pagerHeight);
                case PaperWidth.Paper76mm:
                    //76打印纸扣去两边内距实际可打的宽度为63.5
                    return GetPrinter(printerName, 63.5, pagerHeight);
                case PaperWidth.Paper58mm:
                    //58打印纸扣去两边内距实际可打的宽度为48
                    return GetPrinter(printerName, 48, pagerHeight);
                default:
                    throw new ArgumentException(nameof(paperWidth));
            }

        }
    }
}
