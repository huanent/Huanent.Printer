using Huanent.Printer.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Text;
using System.Linq;

namespace PrintCore
{
    public class Printer : IPrinter
    {

        #region fields
        PrintDocument _printDoc = new PrintDocument();

        /// <summary>
        /// 打印对象打印宽度(根据英寸换算而来,paperWidth * 3.937)
        /// </summary>
        readonly int _paperWidth;
        const float _charProportion = 0.7352f;
        const float _lineHeightProportion = 1.6f;
        const string _fontName = "SimHei";

        IList<Action<Graphics>> _printActions = new List<Action<Graphics>>();

        /// <summary>
        /// 当前的打印高度，当调用换行或者图片打印时会增加此字段值
        /// </summary>
        float _currentheight = 0;

        float NewLineOffset { get; set; } = (int)FontSize.Normal * _lineHeightProportion;

        #endregion

        #region ctor

        /// <summary>
        /// 初始化机打印对象
        /// </summary>
        /// <param name="PrinterName">打印机名称</param>
        /// <param name="paperWidth">打印纸宽度</param>
        /// <param name="paperHight">打印纸高度</param>
        internal Printer(string PrinterName, double paperWidth, int paperHight)
        {
            //3.937为一个打印单位(打印单位:80(实际宽度72.1),58（实际宽度48）)
            _paperWidth = Convert.ToInt32(Math.Ceiling(paperWidth * 3.937));
            _printDoc.PrinterSettings.PrinterName = PrinterName;
            _printDoc.PrintPage += PrintPageDetails;
            _printDoc.DefaultPageSettings.PaperSize = new PaperSize("", _paperWidth, paperHight);
            _printDoc.PrintController = new StandardPrintController();
        }


        #endregion

        #region eventHandler
        void PrintPageDetails(object sender, PrintPageEventArgs e)
        {
            foreach (var item in _printActions)
            {
                item(e.Graphics);
            }
        }
        #endregion

        #region IPrinterImplement
        public void NewRow()
        {
            _printActions.Add((g) =>
            {
                _currentheight += NewLineOffset;
                NewLineOffset = (int)FontSize.Normal * _lineHeightProportion;
            });
        }

        public void PrintText(string content, FontSize fontSize = FontSize.Normal, StringAlignment stringAlignment = StringAlignment.Near, float width = 1, float offset = 0)
        {
            _printActions.Add((g) =>
            {
                float contentWidth = width == 1 ? _paperWidth * (1 - offset) : width * _paperWidth;
                string newContent = ContentWarp(content, fontSize, contentWidth, out var rowNum);
                var font = new Font(_fontName, (int)fontSize, FontStyle.Regular);
                var point = new PointF(offset * _paperWidth, _currentheight);
                var size = new SizeF(contentWidth, (int)fontSize * _lineHeightProportion * rowNum);
                var layoutRectangle = new RectangleF(point, size);
                var format = new StringFormat
                {
                    Alignment = stringAlignment,
                    FormatFlags = StringFormatFlags.NoWrap
                };
                g.DrawString(newContent, font, Brushes.Black, layoutRectangle, format);
                float thisHeightOffset = rowNum * (int)fontSize * _lineHeightProportion;
                if (thisHeightOffset > NewLineOffset) NewLineOffset = thisHeightOffset;
            });
        }

        public void Finish()
        {
            _printDoc.Print();
            _printDoc.Dispose();
            _printDoc = new PrintDocument();
        }

        public void PrintImage(Image image, StringAlignment stringAlignment = StringAlignment.Near)
        {
            _printActions.Add((g) =>
            {
                int x = 0;
                switch (stringAlignment)
                {
                    case StringAlignment.Near:
                        break;
                    case StringAlignment.Center:
                        x = (_paperWidth - image.Width) / 2;
                        break;
                    case StringAlignment.Far:
                        x = _paperWidth - image.Width;
                        break;
                    default:
                        break;
                }
                var point = new Point(x, Convert.ToInt32(_currentheight));
                var size = new Size(image.Width, image.Height);
                var rectangle = new Rectangle(point, size);
                g.DrawImage(image, rectangle);
                NewLineOffset = image.Height;
            });
        }

        public void PrintLine(FontSize fontSize = FontSize.Normal)
        {
            int charNum = (int)(_paperWidth / ((int)fontSize * _charProportion));
            var builder = new StringBuilder();
            for (int i = 0; i < charNum; i++)
            {
                builder.Append('-');
            }
            PrintText(builder.ToString(), fontSize, StringAlignment.Center);
        }
        #endregion

        #region methods
        /// <summary>
        /// 对内容进行分行，并返回行数
        /// </summary>
        /// <param name="content">内容</param>
        /// <param name="fontSize">文字大小</param>
        /// <param name="width">内容区宽度</param>
        /// <returns>行数</returns>
        static string ContentWarp(string content, FontSize fontSize, float width, out int row)
        {
            content = content.Replace(Environment.NewLine, string.Empty);

            //0.7282 字符比例
            var builder = new StringBuilder();
            float nowWidth = 0;
            row = 1;
            foreach (char item in content)
            {
                int code = Convert.ToInt32(item);
                float charWidth = code < 128 ? _charProportion * (int)fontSize : _charProportion * (int)fontSize * 2;
                nowWidth += charWidth;
                if (nowWidth > width)
                {
                    builder.Append(Environment.NewLine);
                    nowWidth = charWidth;
                    row++;
                }
                builder.Append(item);
            }
            return builder.ToString();
        }

        #endregion
    }

}
