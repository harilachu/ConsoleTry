using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagedExtensibilityFramework
{
    [Export(typeof(IOperation))]
    [ExportMetadata("Symbol", '-')]
    class Subtract : IOperation
    {
        public int Operate(int a, int b)
        {
            return a - b;
        }
    }
}
