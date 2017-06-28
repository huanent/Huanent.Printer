using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PrintCore
{
    public interface IPrinter
    {
        int PaperWidth { get; }
        void Print(IEnumerable<PrintUnit> printUnits);
    }
}
