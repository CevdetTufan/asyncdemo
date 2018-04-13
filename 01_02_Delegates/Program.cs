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

            //IAsyncResult asyncResult = m.BeginInvoke(null, null);
            //Console.WriteLine(System.Threading.Thread.CurrentThread.ManagedThreadId);
            //Console.WriteLine("Main!");
            //m.EndInvoke(asyncResult);

            AsyncCallback callback = new AsyncCallback(TheCallBack);
            IAsyncResult asyncResult = m.BeginInvoke(callback, m);
            Console.WriteLine(System.Threading.Thread.CurrentThread.ManagedThreadId);
            Console.WriteLine("Main!");


            Console.ReadLine();
        }
        static void DoWork()
        {
            System.Threading.Thread.Sleep(10000);
            Console.WriteLine("DoWork!");
            Console.WriteLine(System.Threading.Thread.CurrentThread.ManagedThreadId);
        }

        static void TheCallBack(IAsyncResult asyncResult)
        {
            var m = asyncResult.AsyncState as DoWorkDelegate;
            Console.WriteLine("TheCallBack");
            m.EndInvoke(asyncResult);
        }
    }
}
