using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Printing;
using System.Text;
using System.Threading.Tasks;

namespace Huanent.Printer
{
    public static class PrinterFactory
    {
        /// <summary>
        /// 获取打印机实例
        /// </summary>
        /// <param name="printerName">打印机名称</param>
        /// <param name="paperWidth">纸张宽度</param>
        /// <returns></returns>
        public static IPrinter GetPrinter(string printerName, int paperWidth)
        {
            if (paperWidth <= 0) throw new Exception("打印纸张必须大于0");
            LocalPrintServer printServer = new LocalPrintServer();
            var printer = printServer.GetPrintQueue(printerName);
            if (printer == null) throw new Exception("未找到此名称的打印机，请检查windows打印机设置");
            PrintDocument printDoc = new PrintDocument();
            printDoc.PrinterSettings.PrinterName = printerName;
            return new Printer(paperWidth, printDoc);
        }
    }
}
