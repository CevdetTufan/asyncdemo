using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_02_Delegates
{
    class Program
    {
        delegate void DoWorkDelegate();

        static void Main(string[] args)
        {
            Console.WriteLine(System.Threading.Thread.CurrentThread.ManagedThreadId);

            DoWorkDelegate m = new DoWorkDelegate(DoWork);
            //m.Invoke();

            IAsyncResult asyncResult = m.BeginInvoke(null, null);
            Console.WriteLine(System.Threading.Thread.CurrentThread.ManagedThreadId);
            m.EndInvoke(asyncResult);

        }
        static void DoWork()
        {
            Console.WriteLine("Hello World!");
            Console.WriteLine(System.Threading.Thread.CurrentThread.ManagedThreadId);
        }
    }
}
