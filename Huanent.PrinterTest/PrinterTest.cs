using System;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PrintCore;

namespace Huanent.PrinterTest
{
    [TestClass]
    public class PrinterTest
    {
        [TestMethod]
        public void FinishTetst()
        {
            PrintQueueHelper.GetPrintQueueName();
            var printer = PrinterFactory.GetPrinter("Microsoft XPS Document Writer", PaperWidth.Paper80mm);
            printer.NewRow();
            printer.NewRow();
            printer.PrintText("永辉超市", Printer.Models.FontSize.Huge, StringAlignment.Center);
            printer.NewRow();
            printer.NewRow();
            printer.NewRow();
            printer.PrintText("操作员：张三");
            printer.PrintText(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), stringAlignment: StringAlignment.Far);
            printer.NewRow();
            printer.PrintLine();
            printer.NewRow();
            printer.PrintText("商品");
            printer.PrintText("单价", offset: 0.35f);
            printer.PrintText("数量", offset: 0.65f);
            printer.PrintText("总价", stringAlignment: StringAlignment.Far);
            printer.NewRow();
            printer.PrintLine();
            printer.NewRow();
            printer.PrintText("**长白山大萝卜,跳楼吐血大甩卖，不甜不要钱**", width: 0.35f);
            printer.PrintText("6.00", width: 0.2f, offset: 0.35f);
            printer.PrintText("2.00", width: 0.2f, offset: 0.65F);
            printer.PrintText("12.00", stringAlignment: StringAlignment.Far);
            printer.NewRow();
            printer.NewRow();
            printer.PrintText("大螃蟹", width: 0.35f);
            printer.PrintText("6.000000000001", width: 0.2f, offset: 0.35f);
            printer.PrintText("1", width: 0.2f, offset: 0.65F);
            printer.PrintText("6.000000000001", offset: 0.8f, width: 0.2f);
            printer.NewRow();
            printer.PrintLine();
            printer.NewRow();
            var bitmap = new Bitmap("qr.png");
            printer.PrintImage(bitmap, StringAlignment.Center);
            printer.PrintText("关注超市->");
            printer.NewRow();
            printer.PrintLine();
            printer.NewRow();
            printer.PrintText("感谢光临，欢迎下次再来！", stringAlignment: StringAlignment.Center);
            printer.NewRow();
            printer.Finish();
        }
    }
}
