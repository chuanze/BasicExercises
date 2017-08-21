using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Publishser pub = new Publishser();
            Subscriber sub = new Subscriber();
            pub.NumberChanged += new NumberChangedEventHandler(sub.OnNumberChanged);
            pub.DoSomething();
            //pub.NumberChanged(100);//直接通过委托变量来触发事件
            Console.ReadKey();
        }
    }
    //定义委托
    public delegate void NumberChangedEventHandler(int count);
    //定义事件发布者
    public class Publishser
    {
        private int count;
        //public NumberChangedEventHandler NumberChanged;//声明委托变量
        public event NumberChangedEventHandler NumberChanged;//声明一个事件
        public void DoSomething()
        {
            if(NumberChanged!=null)
            {
                count++;
                NumberChanged(count);//定义为事件，只能在此触发
            }
        }
    }
    //定义事件订阅者
    public class Subscriber
    {
        public void OnNumberChanged(int count)
        {
            Console.WriteLine("Subscriber notified:count={0}", count);
        }
    }
}
