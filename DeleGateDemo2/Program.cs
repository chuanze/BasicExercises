using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeleGateDemo2
{
    class Program
    {
        static void Main(string[] args)
        {
            Publisher ps = new Publisher();
            Subscriber1 sb1 = new Subscriber1();
            Subscriber2 sb2 = new Subscriber2();
            Subscriber3 sb3 = new Subscriber3();
            ps.NumberChange -= sb1.OnNumberChanged;//不会有任何反应
            ps.NumberChange += sb2.OnNumberChanged;//注册了sub2
            ps.NumberChange += sb1.OnNumberChanged;//sub1覆盖sub2
            ps.DoSomeing();
            Console.ReadKey();
        }
    }
    public delegate string GeneralEventHandler();
    public class Publisher
    {
        private GeneralEventHandler numberChanged;
        //定义事件访问器
        public event GeneralEventHandler NumberChange
        {
            add
            {
                numberChanged = value;
            }
            remove
            {
                numberChanged -= value;
            }
        }
        public void DoSomeing()
        {
            if(numberChanged!=null)
            {
                string rtn = numberChanged();
                Console.WriteLine("Return:{0} Invoked",rtn);//打印返回得字符串
            }
        }
        
    }
    public class Subscriber1
    {
        public string OnNumberChanged()
        {
            Console.WriteLine("Subscriber1 Invoked");
            return "Subscriber1";
        }
    }
    public class Subscriber2
    {
        public string OnNumberChanged()
        {
            Console.WriteLine("Subscriber2 Invoked");
            return "Subscriber2";
        }
    }
    public class Subscriber3
    {
        public string OnNumberChanged()
        {
            Console.WriteLine("Subscriber3 Invoked");
            return "Subscriber3";
        }
    }
}
