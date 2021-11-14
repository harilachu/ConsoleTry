using System;

namespace MemoryManagement
{
    class Program
    {
       

        static void Main(string[] args)
        {
            ByteArrayManagement arrayManagement = new ByteArrayManagement();
            Console.WriteLine("Byte Array Simulation started...");
            arrayManagement.SimulateCreationOfByteArrays(255,1000000);
            Console.WriteLine("Byte Array Simulation ended...");
            Console.ReadLine();

            Console.WriteLine("Byte Array Pool Simulation started...");
            arrayManagement.SimulateCreationOfByteArrayPool(255, 1000000);
            Console.WriteLine("Byte Array Pool Simulation ended...");
            Console.ReadLine();

            Console.WriteLine("Byte Array Simulation started...");
            arrayManagement.SimulateCreationOfByteArrays(255, 1000000);
            Console.WriteLine("Byte Array Simulation ended...");
            Console.ReadLine();

            Console.WriteLine("Byte Array Pool Simulation started...");
            arrayManagement.SimulateCreationOfByteArrayPool(255, 1000000);
            Console.WriteLine("Byte Array Pool Simulation ended...");
            Console.ReadLine();
        }

        
    }
}
