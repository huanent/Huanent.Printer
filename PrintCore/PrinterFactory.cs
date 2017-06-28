using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintCore
{
    public static class PrinterFactory
    {
        /// <summary>
        /// 获取打印对象
        /// </summary>
        /// <param name="printName">打印机名称</param>
        /// <param name="printWidth">打印纸宽度80,58,76</param>
        /// <returns></returns>
        public static Printer GetPrinter(string printName, PrintWidth printWidth)
        {
            if(string.IsNullOrEmpty(printName)) throw new ArgumentException(nameof(printName));

            switch (printWidth)
            {
                case PrintWidth.Print80mm:
                    //80打印纸扣去两边内距实际可打的宽度为72.1
                    return new Printer(printName, 72.1);
                case PrintWidth.Print58mm:
                    //58打印纸扣去两边内距实际可打的宽度为48
                    return new Printer(printName, 48);
                default:
                    throw new ArgumentException(nameof(printWidth));
            }

        }
    }
}
