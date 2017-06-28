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
        public string Content { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public Font Font { get; set; }
        public StringAlignment Alignment { get; set; }
    }
}
