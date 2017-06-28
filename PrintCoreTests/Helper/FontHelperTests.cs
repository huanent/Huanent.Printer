using Microsoft.VisualStudio.TestTools.UnitTesting;
using PrintCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PrintCore.Tests
{
    [TestClass()]
    public class FontHelperTests
    {
        [TestMethod()]
        public void GetFontFamiliesTest()
        {
            var ff = FontHelper.GetFontFamilies();
            Assert.IsNotNull(ff);
        }

        [TestMethod()]
        public void GetFontTtest()
        {
            var font = FontHelper.GetFont("黑体",12);
            Assert.IsNotNull(font);
        }
    }
}