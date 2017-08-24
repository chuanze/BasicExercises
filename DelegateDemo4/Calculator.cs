using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DelegateDemo4
{
    public class Calculator
    {
        public int Add(int x,int y)
        {
            if (Thread.CurrentThread.IsThreadPoolThread)
            {
                Thread.CurrentThread.Name = "Pool Thread";
            }
            Console.WriteLine("Method invoked");
            //执行某些事情，模拟需要执行2秒钟
            for(int i=1;i<=2; i++)
            {
                Thread.Sleep(TimeSpan.FromSeconds(i));
                Console.WriteLine("{0}:Add executed{1} second(s)", Thread.CurrentThread.Name, i);
            }
            Console.WriteLine("Method complete!");
            return x + y;
        }
    }
}
