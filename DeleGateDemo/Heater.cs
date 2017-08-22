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
        public string type = "RealFire 001";//添加型号作为演示
        public string area = "China Xian";//添加产地作为演示
        public delegate void BoilHandler(int param);//声明委托
        public event BoilHandler BoilEvent;//声明事件
        /// <summary>
        /// 声明委托，符合.NET Framework得写法
        /// </summary>
        /// <param name="sender">被监控对象</param>
        /// <param name="e">感兴趣得参数</param>
        public delegate void BoildedEventHandler(Object sender, BoiledEventArgs e);//声明委托(规范)
        public event BoildedEventHandler Boiled;//声明事件(规范)
        //定义BoiledEventArgs类,传递给Observer所感兴趣得信息
        public class BoiledEventArgs:EventArgs
        {
            public readonly int temperature;
            public BoiledEventArgs(int temperature)
            {
                this.temperature = temperature;
            }
        }
        //可以供继承自 Heater 的类重写，以便继承类拒绝其他对象对它的监视
        protected virtual void OnBoiled(BoiledEventArgs e)
        {
            if(Boiled!=null)
            {
                Boiled(this, e);
            }
        }
        //烧水
        public void BoilWater()
        {
            for(int i=0;i<100;i++)
            {
                temperature = i;
                //MakeAlert(temperature);
                //ShowMsg(temperature);
                if(temperature>95)
                {
                    //if(BoilEvent!=null)
                    //{
                    //    BoilEvent(temperature);
                    //}
                    //下面是符合规范的写法
                    BoiledEventArgs e = new BoiledEventArgs(temperature);
                    OnBoiled(e);
                }
            }
        }
        #region 一般处理方法
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
        #endregion
    }
}
