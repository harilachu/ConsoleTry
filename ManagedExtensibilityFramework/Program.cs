using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Context;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;

namespace ManagedExtensibilityFramework
{
    public class Program
    {
        private static CompositionContainer compositionContainer;

        [Import("SimpleCalculator")]
        public ICalculator Calculator;

        [Import("MyAnotherCalculator")]
        public ICalculator AnotherCalculator;

        [Import]
        public Func<int, string> DoSomething;

        public Program()
        {
           
        }

        static void Main(string[] args)
        {
            var p = new Program();
            try
            {
                AggregateCatalog catalog = new AggregateCatalog();
                catalog.Catalogs.Add(new AssemblyCatalog(typeof(Program).Assembly));
                compositionContainer = new CompositionContainer(catalog);
                compositionContainer.ComposeParts(p);
            }
            catch (CompositionException compositionException)
            {
                Console.WriteLine(compositionException);
            }

        
            Console.WriteLine("Enter program: ");
            Console.WriteLine(p.DoSomething(123));
            while (true)
            {
                var returnVal = p.Calculator.Calculate(Console.ReadLine());
                Console.WriteLine($"Display Output: {returnVal}");
                var anotherVal = p.AnotherCalculator.Calculate(Console.ReadLine());
                Console.WriteLine($"Display Output: {anotherVal}");
            }
        }
    }
}
