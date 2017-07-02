using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintCore
{
    public class Printer : IPrinter
    {

        PrintDocument printDoc = new PrintDocument();

        /// <summary>
        /// 打印单元
        /// </summary>
        IEnumerable<PrintUnit> _printUnits;

        /// <summary>
        /// 打印对象打印宽度(根据英寸换算而来,paperWidth * 3.937)
        /// </summary>
        public int PaperWidth { get; }

        /// <summary>
        /// 初始化机打印对象
        /// </summary>
        /// <param name="PrinterName">打印机名称</param>
        /// <param name="paperWidth">打印纸宽度,一般为80,58,76</param>
        /// <param name="paperHight">打印纸高度</param>
        internal Printer(string PrinterName, double paperWidth, int? paperHight = null)
        {
            //3.937为一个打印单位(打印单位:80,58)
            PaperWidth = Decimal.ToInt32(Math.Ceiling(new decimal(paperWidth * 3.937)));
            printDoc.PrinterSettings.PrinterName = PrinterName;
            printDoc.PrintPage += PrintPageDetails;
            printDoc.DefaultPageSettings.PaperSize = new PaperSize("", PaperWidth, paperHight ?? 10000);
        }

        void PrintPageDetails(object sender, PrintPageEventArgs e)
        {
            if (_printUnits != null)
            {
                foreach (var item in _printUnits)
                {
                    int unitWidth = item.UnitWidth == 0 ? PaperWidth : item.UnitWidth;
                    switch (item.UnitType)
                    {
                        case Models.UnitType.Text:
                            var f = new RectangleF(item.X, item.Y, unitWidth, item.Font.Size * 2);
                            var stringFormat = StringFormat.GenericDefault;
                            stringFormat.Alignment = item.Alignment;
                            e.Graphics.DrawString(item.Content, item.Font, Brushes.Black, f, stringFormat);
                            break;
                        case Models.UnitType.Image:
                            var img = new Bitmap(item.Content);
                            e.Graphics.DrawImage(img, item.X, item.Y);
                            break;
                        default:
                            break;
                    }

                }
            }
        }

        public void Print(IEnumerable<PrintUnit> printUnits)
        {
            _printUnits = printUnits;
            printDoc.Print();
        }
    }
}
