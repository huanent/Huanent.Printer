##  window下的80,58小票打印工具
### 使用方法
```
string printName = "Microsoft XPS Document Writer";
var print = PrinterFactory.GetPrinter(printName, PrintWidth.Print80mm);
print.Print(new PrintUnit[] {
    new PrintUnit{
        Alignment =StringAlignment.Center,
        Content ="测试文本",
        Y =10,
        Font =new Font("黑体",12)
    }
});
```
##### printName可使用PrintQueueHelper.GetPrintQueueName();获取电脑所有打印机列表选择