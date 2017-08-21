using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeleGateDemo
{
    /// <summary>
    /// 热水器类型
    /// </summary>
    public class Heater
    {
        private int temperature;//水温
        //烧水
        public void BoilWater()
        {
            for(int i=0;i<100;i++)
            {
                temperature = i;
                MakeAlert(temperature);
                ShowMsg(temperature);
            }
        }
        //发出语音警报
        private void MakeAlert(int param)
        {
            Console.WriteLine("Alarm:嘀嘀嘀，水已经{0}度了：", param);
        }
        //显示水温
        private void ShowMsg(int param)
        {
            Console.WriteLine("Display：水快开了，当前温度：{0}度。", param);
        }
    }
}
