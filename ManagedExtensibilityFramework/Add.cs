using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagedExtensibilityFramework
{
    [Export(typeof(IOperation))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    [ExportMetadata("Symbol",'+')]
    class Add : IOperation, IPartImportsSatisfiedNotification
    {
        public Add()
        {

        }
        public void OnImportsSatisfied()
        {
            Console.WriteLine("Imports satisfied: Add");
        }

        public int Operate(int a, int b)
        {
            return a + b;
        }
    }
}
