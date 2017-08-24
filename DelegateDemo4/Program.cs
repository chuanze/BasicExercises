using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DelegateDemo4
{
    class Program
    {
        public delegate int AddDelegate(int x, int y);
        static void Main(string[] args)
        {
            #region Program7
            /*
            Console.WriteLine("Client application started!\n");
            Thread.CurrentThread.Name = "Main Thread";
            Calculator cal = new Calculator();
            int result = cal.Add(2, 5);
            Console.WriteLine("Result:{0}\n", result);
            //做某些其他得事情，模拟需要执行3秒钟
            for(int i=1;i<=3;i++)
            {
                Thread.Sleep(TimeSpan.FromSeconds(i));
                Console.WriteLine("{0}:Client executed{1} second(s).", Thread.CurrentThread.Name, i);
            }
            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
            */
            #endregion

            #region Program8
            /*
            Console.WriteLine("Client application started!\n");
            Thread.CurrentThread.Name = "Main Thread";
            Calculator cal = new Calculator();
            AddDelegate del = cal.Add;
            IAsyncResult asyncResult = del.BeginInvoke(2, 5, null, null);//
            //做某些其他得事情，模拟需要执行3秒钟
            for (int i = 1; i <= 3; i++)
            {
                Thread.Sleep(TimeSpan.FromSeconds(i));
                Console.WriteLine("{0}:Client executed{1} second(s).", Thread.CurrentThread.Name, i);
            }
            int rtn = del.EndInvoke(asyncResult);
            Console.WriteLine("Result:{0}\n", rtn);
            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
            */
            #endregion

            #region Program9
            Console.WriteLine("Client application started!\n");
            Thread.CurrentThread.Name = "Main Thread";
            Calculator cal = new Calculator();
            AddDelegate del = cal.Add;
            string data = "Any data you want to pass.";
            AsyncCallback callBack = new AsyncCallback(OnAddComplete);
            del.BeginInvoke(2, 5, callBack, data);
            //做某些其他得事情，模拟需要执行3秒钟
            for (int i = 1; i <= 3; i++)
            {
                Thread.Sleep(TimeSpan.FromSeconds(i));
                Console.WriteLine("{0}:Client executed{1} second(s).", Thread.CurrentThread.Name, i);
            }
            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
            #endregion


        }
        static void OnAddComplete(IAsyncResult asyncResult)
        {
            AsyncResult result = (AsyncResult)asyncResult;
            AddDelegate del = (AddDelegate)result.AsyncDelegate;
            string data = (string)asyncResult.AsyncState;
            int rtn = del.EndInvoke(asyncResult);//执行EndInvoke时可能会抛出异常。需要放到try中执行
            Console.WriteLine("{0}:Result,{1};Data:{2}\n", Thread.CurrentThread.Name, rtn, data);
        }

    }
}
