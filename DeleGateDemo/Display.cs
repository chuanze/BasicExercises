using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeleGateDemo
{
    public class Display
    {
        public static void ShowMsg(int param)
        {
            Console.WriteLine("Display:水已烧开，当温度：{0}度",param);
        }
        /// <summary>
        /// 符合c#语言规范写法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void ShowMsg(Object sender, Heater.BoiledEventArgs e)
        {
            Heater heater = (Heater)sender;
            Console.WriteLine("Display:{0}-{1}:", heater.area, heater.type);
            Console.WriteLine("Display:水烧开了，当前温度：{0}度", e.temperature);
        }
    }
}
