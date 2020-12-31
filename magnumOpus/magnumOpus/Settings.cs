using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace magnumOpus
{
    
        public class Settings
        {
            public bool cpuLoad = true; public bool cpuLoadTimer = true;
            public bool cpuTemperature = false; public bool cpuTemperatureTimer = false;
            public bool cpuFrequency = false; public bool cpuFrequencyTimer = false;

            public int informCpuLoad = 0;
            public int informCpuTemperature = 0;
            public int informCpuFrequency = 0;

            public bool ramLoad = true; public bool ramLoadTimer = true;
            public bool ramUsed = false; public bool ramUsedTimer = false;
            public bool ramFree = false; public bool ramFreeTimer = false;

            public int informRamLoad = 0;
            public int informRamUsed = 0;
            public int informRamFree = 0;

            public Settings() { }

            public CriticalAlarm[] insertIntoAlarmList()
            {
                CriticalAlarm[] alarms = {new CriticalAlarm("завантаження процесора", informCpuLoad, 0, cpuLoadTimer, cpuLoad),
                                     new CriticalAlarm("температура процесора", informCpuTemperature, 0, cpuTemperatureTimer, cpuTemperature),
                                     new CriticalAlarm("частота процесора", informCpuFrequency, 0, cpuFrequencyTimer, cpuFrequency),
                                     new CriticalAlarm("завантаження оперативної пам'яті", informRamLoad, 0, ramLoadTimer, ramLoad),
                                     new CriticalAlarm("зайнятий простір оперативної пам'яті", informRamUsed, 0, ramUsedTimer, ramUsed),
                                     new CriticalAlarm("вільний простір оперативної пам'яті", informRamFree, 0, ramFreeTimer, ramFree)
                                     };
                return alarms;
            }

        }
    
}
