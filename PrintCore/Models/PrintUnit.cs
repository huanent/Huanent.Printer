using PrintCore.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintCore
{
    public class PrintUnit
    {
        /// <summary>
        /// UnitType为图片类型时传图片的路径
        /// </summary>
        public string Content { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        /// <summary>
        /// 表示内容单元的宽度,通常用来进行字符串的对齐StringAlignment
        /// </summary>
        public int UnitWidth { get; set; }
        public Font Font { get; set; }
        public StringAlignment Alignment { get; set; }
        public UnitType UnitType { get; set; }
    }
}
