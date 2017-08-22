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

            Console.WriteLine("Observer设计模式");
            Heater heater = new Heater();
            Alarm alarm = new Alarm();
            heater.BoilEvent += alarm.MakeAlert;//注册方法
            heater.BoilEvent += (new Alarm()).MakeAlert;//为匿名对象注册方法
            heater.BoilEvent += Display.ShowMsg;//注册静态方法
            heater.BoilWater();
            Console.WriteLine("End...");
            Console.ReadKey();

            Console.WriteLine(".NET Framework 编码规范");
            Heater ht1 = new Heater();
            Alarm am = new Alarm();
            ht1.Boiled += am.MakeAlert;//注册方法
            ht1.Boiled += (new Alarm()).MakeAlert;//为匿名对象注册方法
            ht1.Boiled += new Heater.BoildedEventHandler(alarm.MakeAlert);//也可以这么注册
            ht1.Boiled += Display.ShowMsg;//注册静态方法
            heater.BoilWater();

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
