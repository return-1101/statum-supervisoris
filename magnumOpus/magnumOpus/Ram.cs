using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;
using OpenHardwareMonitor.Hardware;

namespace magnumOpus
{
    class Ram
    {
        public string manufaxturer;
        public string bank;
        public string capacity;
        public string speed;
        public string serialNumb;
        public string fizicalMemory;
        public Ram()
        {
            findValueIndex();

            ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_PhysicalMemory");

            foreach (ManagementObject queryObj in searcher.Get())
            {
                manufaxturer = queryObj["Manufacturer"].ToString();
                bank += queryObj["BankLabel"].ToString()+ " \t ";
                capacity += (Math.Round(System.Convert.ToDouble(queryObj["Capacity"]) / 1024 / 1024, 2)).ToString() + "   ";
                speed += queryObj["Speed"].ToString() + "   ";
                serialNumb += queryObj["SerialNumber"].ToString() + "   ";
            }

            fizicalMemory = getFizicalMemory();
        }

        Computer myComputer = new Computer();
        public string[] ClokVoltage = new string[2];

        int ramIndex = 0, availableMemory = 0, usedMemory = 0, load = 0;
        public void findValueIndex()
        {
            myComputer.Open();
            //myComputer.CPUEnabled = true;
            //myComputer.GPUEnabled = true;
            //myComputer.MainboardEnabled = true;
            myComputer.RAMEnabled = true;
            //myComputer.FanControllerEnabled = true;
            //myComputer.HDDEnabled = true;

            myComputer.Hardware[0].Update();
            myComputer.Hardware[0].GetReport();



            for (int i = 0; i < myComputer.Hardware[ramIndex].Sensors.Count(); i++) //myComputer.Hardware[15].Sensors.Count()
            {
                if (myComputer.Hardware[ramIndex].Sensors[i].Name == "Load")
                {
                    load = i;
                }
                else if (myComputer.Hardware[ramIndex].Sensors[i].Name == "Available Memory")
                {
                    availableMemory = i;
                }
                else if (myComputer.Hardware[ramIndex].Sensors[i].Name == "Used Memory")
                {
                    usedMemory = i;
                }
            }
            myComputer.Close();
        }

        string getFizicalMemory()
        {
            string outInfo;
            myComputer.Open();
            myComputer.RAMEnabled = true;

            myComputer.Hardware[0].Update();
            myComputer.Hardware[0].GetReport();

            
            outInfo = (myComputer.Hardware[ramIndex].Sensors[usedMemory].Value + myComputer.Hardware[ramIndex].Sensors[availableMemory].Value).ToString();


            myComputer.Close();
            return outInfo;
        }

        public string[] getRamInfo()
        {
            string[] outInfo = new string[3];
            myComputer.Open();            
            myComputer.RAMEnabled = true;
            
            myComputer.Hardware[0].Update();
            myComputer.Hardware[0].GetReport();

            outInfo[0] = myComputer.Hardware[ramIndex].Sensors[load].Value.ToString() + "%";
            outInfo[1] = myComputer.Hardware[ramIndex].Sensors[usedMemory].Value.ToString() + "Гб";
            outInfo[2] = myComputer.Hardware[ramIndex].Sensors[availableMemory].Value.ToString() + "Гб";

            myComputer.Close();
            return outInfo;
        }
    }
}
