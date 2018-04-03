using System;
using System.Diagnostics;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AsyncDemoProject
{
    [TestClass]
    public class Test_Thread
    {
        [TestMethod]
        public void TestMethod1()
        {
            Debug.WriteLine("Starting test method");
            Debug.WriteLine(Thread.CurrentThread.ManagedThreadId.ToString());
            Thread thread = new Thread(new ThreadStart(DoWork));
            thread.Start();
            Debug.WriteLine("Ending test method");
        }

        private void DoWork()
        {
            Debug.WriteLine("Doing works");
            Debug.WriteLine(Thread.CurrentThread.ManagedThreadId.ToString());
            Thread.Sleep(1000);
        }
    }
}
