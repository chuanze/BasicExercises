using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateDemo3
{
    class Program
    {
        static void Main(string[] args)
        {
            Publisher ps = new Publisher();
            Subscriber1 sb1 = new Subscriber1();
            Subscriber2 sb2 = new Subscriber2();
            Subscriber3 sb3 = new Subscriber3();
            ps.MyEvent += sb1.OnEvent;
            ps.MyEvent += sb2.OnEvent;
            ps.MyEvent += sb3.OnEvent;
            Console.WriteLine("一般的处理方法--begin--");
            ps.DoSomething();
            Console.WriteLine("一般的处理方法--end--");
            Console.WriteLine();
            Console.WriteLine("遍历链表方法--begin--");
            ps.DoSomething2();
            Console.WriteLine("遍历链表方法--end--");
            Console.WriteLine("--begin--");
            ps.DoSomething3();
            Console.WriteLine("--end--");
            Console.ReadKey();
        }

    }
    public delegate void eventEventHandler(Object sender, EventArgs e);
    public class Publisher
    {
        public eventEventHandler MyEvent;
        public void DoSomething()//如果要是2发生异常，3就不会执行下去
        {
            if(MyEvent!=null)
            {
                try
                {
                    MyEvent(this, EventArgs.Empty);
                }
                catch(Exception e)
                {
                    Console.WriteLine("Exception:{0}", e.Message);
                }
            }
        }
        //使用链表方式，解决不能执行3得问题
        public void DoSomething2()
        {
            if (MyEvent != null)
            {
                Delegate[] delArray = MyEvent.GetInvocationList();
                foreach(Delegate del in delArray)
                {
                    eventEventHandler method = (eventEventHandler)del;//可以通过DynamicInvoke方法替换
                    try
                    {
                        method(this, EventArgs.Empty);
                        //del.DynamicInvoke(this, EventArgs.Empty);//
                    }
                    catch(Exception e)
                    {
                        Console.WriteLine("Exception:{0}", e.Message);
                    }
                }
            }
        }
        public void DoSomething3()
        {
            object[] objs=FireEvent(MyEvent, this, EventArgs.Empty);
        }
        public static object[]FireEvent(Delegate del,params object[] args)
        {
            List<object> objList = new List<object>();
            if (del != null)
            {
                Delegate[] delArray = del.GetInvocationList();
                foreach(Delegate method in delArray)
                {
                    try
                    {
                        //使用DynamicInvoke方法触发事件
                        object obj = method.DynamicInvoke(args);
                        if (obj != null)
                            objList.Add(obj);

                    }
                    catch(Exception e)
                    {
                       
                    }
                }

            }
            return objList.ToArray();
        }
    }
    public class Subscriber1
    {
        public void OnEvent(Object sender,EventArgs e)
        {
            Console.WriteLine("Subscriber1 Invoked!");
        }
    }
    public class Subscriber2
    {
        public void OnEvent(Object sender, EventArgs e)
        {
            Console.WriteLine("Subscriber2 Invoked!");
            throw new Exception("Subscriber2 Failed");
        }
    }

    public class Subscriber3
    {
        public void OnEvent(Object sender, EventArgs e)
        {
            Console.WriteLine("Subscriber3 Invoked!");
        }
    }
}
