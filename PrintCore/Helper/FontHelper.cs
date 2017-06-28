using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintCore
{
    public static class FontHelper
    {
        public static IEnumerable<FontFamily> GetFontFamilies()
        {
            var fontCollection = new InstalledFontCollection();
            foreach (var item in fontCollection.Families)
            {
                yield return item;
            }
        }
        public static Font GetFont(FontFamily family, int size)
        {
            return new Font(family, size);
        }
        public static Font GetFont(string fontFamilyName, int size)
        {
            return new Font(fontFamilyName, size);
        }
    }
}
