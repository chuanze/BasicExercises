using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeleGateDemo
{
    /// <summary>
    /// 警报器
    /// </summary>
    public class Alarm
    {
        public void MakeAlert(int param)
        {
            Console.WriteLine("Alarm:嘀嘀嘀,水已经{0}度了：", param);
        }
        /// <summary>
        /// 符合c#语言规范得写法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void MakeAlert(Object sender,Heater.BoiledEventArgs e)
        {
            Heater heater = (Heater)sender;//这里是不是很熟悉
            Console.WriteLine("Alarm:{0}-{1}:", heater.area, heater.type);
            Console.WriteLine("Alarm:嘀嘀嘀，水已经{0}度了：", e.temperature);
            Console.WriteLine();
        }

    }
}
