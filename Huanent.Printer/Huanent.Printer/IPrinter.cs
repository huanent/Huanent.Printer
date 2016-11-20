using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Huanent.Printer
{
    /// <summary>
    /// 打印接口
    /// </summary>
    public interface IPrinter
    {
        /// <summary>
        /// 打印文字
        /// </summary>
        /// <param name="content">内容</param>
        /// <param name="size">字体大小</param>
        void PrintText(string content,int size=10);
        /// <summary>
        /// 打印居中文字
        /// </summary>
        /// <param name="content">内容</param>
        /// <param name="size">字体大小</param>
        void PrintCenterText(string content, int size = 10);
        /// <summary>
        /// 打印居右文字
        /// </summary>
        /// <param name="content">内容</param>
        /// <param name="size">字体大小</param>
        void PrintRightText(string content, int size = 10);
        /// <summary>
        /// 打印居右偏移文字
        /// </summary>
        /// <param name="content">内容</param>
        /// <param name="size">字体大小</param>
        void PrintRightOffsetText(string content, int size = 10,int offset=0);
        /// <summary>
        /// 偏移打印文字
        /// </summary>
        /// <param name="content">内容</param>
        /// <param name="size">字体大小</param>
        /// <param name="Offset">偏移量</param>
        void PrintOffsetText(string content, int size = 10,int Offset=0);
        /// <summary>
        /// 打印分割线
        /// </summary>
        /// <param name="c">分割线字符</param>
        void PrintLine(char c);
        /// <summary>
        /// 换行
        /// </summary>
        /// <param name="n"></param>
        void FeedLine(int n);
        /// <summary>
        /// 开始打印
        /// </summary>
        void Print();

    }
}
