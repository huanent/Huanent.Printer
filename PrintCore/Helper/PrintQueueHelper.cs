using System;
using System.Collections.Generic;
using System.Linq;
using System.Printing;
using System.Text;
using System.Threading.Tasks;

namespace PrintCore
{
    public static class PrintQueueHelper
    {
        public static IEnumerable<PrintQueue> GetPrintQueue()
        {
            var localPrintServer = new LocalPrintServer();
            var printQueues = localPrintServer.GetPrintQueues().GetEnumerator();
            while (printQueues.MoveNext())
            {
                yield return printQueues.Current;
            }

        }

        public static IEnumerable<string> GetPrintQueueName()
        {
            return GetPrintQueue().Select(s => s.Name);
        }
    }
}
