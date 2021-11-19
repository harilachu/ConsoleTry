using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryManagement
{
    public class ClassWithStaticAnalysisErrors
    {
        public void CreateResourceStreamLeak()
        {
            FileStream fileStream = new FileStream(@"C:\ExampleFile.txt", FileMode.OpenOrCreate);
            StreamReader sr = new StreamReader("whatever.txt");
            //Leave without closing the stream
        }

        private Object ReturnNullReference()
        {
            ByteArrayManagement byteArrayManagement = new ByteArrayManagement();
            return null;
        }

        public void UseNullReturningMethod()
        {
            Object nullObject = ReturnNullReference();
            Console.Write(nullObject.GetHashCode());
        }

        private readonly object lockObject = new object();
        private int intValue = 1;

        public int GetIntValue()
        {
            return intValue;
        }

        public void SetIntValue()
        {
            lock (lockObject)
            {
                intValue = 2;
            }
        }


        public StreamWriter AllocatedStreamWriter()
        {
            FileStream fs = File.Create("everwhat.txt");
            return new StreamWriter(fs);
        }

        public void ResourceLeakBad()
        {
            StreamWriter stream = AllocatedStreamWriter();
            // FIXME: should close the StreamWriter by calling stream.Close() if stream is not null.
        }

        

    }

    //@ToDo: Enable below for checking code analysis errors from Infer#
    //public static class MainClass
    //{
    //    public static void Main()
    //    {
    //        ClassWithStaticAnalysisErrors classToBeAnalyzed = new ClassWithStaticAnalysisErrors();
    //        classToBeAnalyzed.CreateResourceStreamLeak();
    //        classToBeAnalyzed.ResourceLeakBad();
    //    }
    //}

    
}
