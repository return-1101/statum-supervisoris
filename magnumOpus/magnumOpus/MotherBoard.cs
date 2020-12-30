using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenHardwareMonitor.Hardware;

namespace magnumOpus
{
    class MotherBoard
    {
        public MotherBoard()
        {
            // findValueIndex();// немає датчиків на платі
            
        }
        public string[] motherBoardInfo()
        {
            RegistryInf reg = new RegistryInf();
            string[] outInfo = new string[5];

            outInfo[0] = reg.boardManufacturer;
            outInfo[1] = reg.boardVersion;
            outInfo[2] = reg.BIOSvendor;
            outInfo[3] = reg.BiosVersion;
            outInfo[4] = reg.BIOSreliseDate;

            return outInfo;
        }

        //Computer myComputer = new Computer();
        //public string[] ClokVoltage = new string[2];

        //int boardIndex = 0, cpuTotalInd = 0, cpuClockInd = 0;
        //public void findValueIndex()
        //{
        //    myComputer.Open();
        //    //myComputer.CPUEnabled = true;
        //    //myComputer.GPUEnabled = true;
        //    //myComputer.MainboardEnabled = true;
        //    //myComputer.RAMEnabled = true;
        //    //myComputer.FanControllerEnabled = true;
        //    //myComputer.HDDEnabled = true;
            
        //    myComputer.Hardware[0].Update();
        //    myComputer.Hardware[0].GetReport();

        //    for (int i = 0; i < myComputer.Hardware[boardIndex].Sensors.Count(); i++) //myComputer.Hardware[15].Sensors.Count()
        //    {
        //        if (myComputer.Hardware[boardIndex].Sensors[i].Name == "CPU Total")
        //        {
        //            cpuTotalInd = i;
        //        }
        //        else if (myComputer.Hardware[boardIndex].Sensors[i].Name == "CPU Core #1")
        //        {
        //            cpuClockInd = i;
        //        }
        //    }
        //    myComputer.Close();
        //}
    }
}
