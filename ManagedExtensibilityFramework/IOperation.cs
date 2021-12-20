using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagedExtensibilityFramework
{
    public interface IOperation
    {
        int Operate(int a, int b);
    }

    public interface IOperationData
    {
        char Symbol { get; }
    }
}
