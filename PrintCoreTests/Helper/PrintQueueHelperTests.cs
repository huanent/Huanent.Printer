using Microsoft.VisualStudio.TestTools.UnitTesting;
using PrintCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PrintCore.Tests
{
    [TestClass()]
    public class PrintQueueHelperTests
    {
        [TestMethod()]
        public void GetPrintQueueTest()
        {
            var queues = PrintQueueHelper.GetPrintQueue();
            Assert.IsNotNull(queues);
        }

        [TestMethod()]
        public void GetPrintQueueNameTest()
        {
            var queues = PrintQueueHelper.GetPrintQueueName();
            Assert.IsNotNull(queues);
        }
    }
}