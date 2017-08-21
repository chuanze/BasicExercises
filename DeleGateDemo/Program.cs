using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeleGateDemo
{
    public delegate void GreetingDelegate(string name);
    public class GreetingManager
    {
        public GreetingDelegate delegate1;
        public void GreetPeople(string name,GreetingDelegate MakeGreetimg)
        {
            
            MakeGreetimg(name);
        }
        public void GreetPeople(string name)
        {
            if(delegate1 != null)
            {
                delegate1(name);
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            //方法作为参数
            //GreetingDelegate delegate1, delegate2;
            //delegate1 = EnglishGreeing;
            //delegate2 = ChineseGreeing;
            //GreetPeople("Jimmy Zhang", delegate1);
            //GreetPeople("张子阳", delegate2);
            //Console.ReadKey();
            //绕过Greepeople和EnglishGreeeing方法和ChineseGreeing方法
            GreetingDelegate delegate1;
            delegate1 = EnglishGreeing;
            delegate1 += ChineseGreeing;
            //先后调用EnglishGreeeing方法和ChineseGreeing方法
            delegate1("Jimmy Zhang");
            

            //GreetingDelegate gd = new GreetingDelegate();//会报错误，缺少参数

            Heater ht = new Heater();
            ht.BoilWater();

            Console.ReadKey();

        }
        public static void GreetPeople(string name,GreetingDelegate MakeGreeing)
        {
            MakeGreeing(name);
        }
        public static void EnglishGreeing(string name)
        {
            Console.WriteLine("Moring," + name);
        }
        public static void ChineseGreeing(string name)
        {
            Console.WriteLine("早上好," + name);
        }
    }
}
