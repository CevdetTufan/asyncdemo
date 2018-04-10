using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Signaling
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Current thread :{System.Threading.Thread.CurrentThread.ManagedThreadId}");
            ThreadPool.QueueUserWorkItem(DoWork);
            Console.WriteLine($"Background thread?? :{System.Threading.Thread.CurrentThread.IsBackground}");
        }
        private static void DoWork(object state)
        {
            Console.WriteLine($"Current thread :{System.Threading.Thread.CurrentThread.ManagedThreadId}");
            Console.WriteLine($"Background thread? :{System.Threading.Thread.CurrentThread.IsBackground}");
        }
    }
}
