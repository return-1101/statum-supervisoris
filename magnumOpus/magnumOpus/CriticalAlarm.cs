using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace magnumOpus
{
    
        public class CriticalAlarm
        {
            bool timer = false;
            bool cheak = false;
            public int Time = 0;
            public string name;
            public int crittcalValue = 0;

            public double value = 0;
                        
            CpuInfo cpu = new CpuInfo();
            Ram ram = new Ram();

            public CriticalAlarm(string n, int crit, int time, bool t, bool ch)
            {
                timer = t;
                cheak = ch;
                Time = time;

                name = n;
                crittcalValue = crit;
            }

            public CriticalAlarm() { }



            public void getValue()
            {
                switch (name)
                {
                    case "завантаження процесора":
                        value = Convert.ToDouble(cpu.GetSystemInfo()[0]);
                        break;
                    case "частота процесора":
                        value = Convert.ToDouble(cpu.GetSystemInfo()[1]);
                        break;
                    case "температура процесора":
                        value = Convert.ToDouble(cpu.CpuTemp());
                        break;

                    case "завантаження оперативної пам'яті":
                        value = Convert.ToDouble(ram.getRamInfo()[0]);
                        break;
                    case "зайнятий простір оперативної пам'яті":
                        value = Convert.ToDouble(ram.getRamInfo()[1]);
                        break;
                    case "вільний простір оперативної пам'яті":
                        value = Convert.ToDouble(ram.getRamInfo()[2]);
                        break;
                }
            }

        }
    
}
