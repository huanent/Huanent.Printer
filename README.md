# 旧版本文档
[1.1版本文档](https://github.com/huanent/Huanent.Printer/blob/master/docs/1.1.md)

# 当前版本

huanent.printer2.0版本是对1.1版本的破坏性更新，两个版本不兼容，2.0版本提供了更好的打印控制，如自动换行，流式打印等。
## 基本使用教程

### 安装程序集
在nuget搜索[Huanent.Printer](https://www.nuget.org/packages/Huanent.Printer/)进行安装，考虑到市场上还存在xp系统的打印机，故最低支持到.net4.0版本
### 获取本机所有打印机列表
```
var list= PrintQueueHelper.GetPrintQueueName();
```
此方法获取到本机所有打印机驱动的名称，选择小票打印机的名字例如 xp58
### 获得打印机对象
```
var printer = PrinterFactory.GetPrinter("xp58", PaperWidth.Paper80mm);
```
进行打印
```
PrintQueueHelper.GetPrintQueueName();
var printer = PrinterFactory.GetPrinter("Microsoft XPS Document Writer", PaperWidth.Paper80mm);
printer.NewRow();
printer.NewRow();
printer.PrintText("永辉超市", FontSize.Huge, StringAlignment.Center);
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

```
最终成品为下图

![](https://github.com/huanent/Huanent.Printer/blob/master/docs/img/bill.png)

