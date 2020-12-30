using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Management;
using OpenHardwareMonitor.Hardware;

namespace magnumOpus
{
    
namespace Common.Diagnostics.SystemInfo
    {        
        class CpuInfo
        {
            public string outInfo = "";
            public bool active = false;
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(@"root\WMI", "SELECT * FROM MSAcpi_ThermalZoneTemperature");
            ManagementObjectSearcher cpuInformation = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_Processor");
           
            public CpuInfo()
            {
                findValueIndex();
            }


            public string CpuTemp()
            {
                Double temp = 0;
                
                foreach (ManagementObject obj in searcher.Get())
                {
                    temp = Convert.ToDouble(obj["CurrentTemperature"].ToString());
                    temp = (temp - 2732) / 10.0;
                    break;
                }
                return temp + "°C";
            }

            public void CpuUsage()
            {
                while (true)
                {
                    if (active == true)
                    {
                       GetSystemInfo();
                    } 
                    //foreach (ManagementObject queryObj in cpuInformation.Get())
                    //{
                    //    //outInfo = ManagementObject.cpuInformation["LoadPercentage"];
                    //    outInfo = queryObj["LoadPercentage"] + "%"; break;
                    //    //outInfo += queryObj["ExtClock"].ToString();
                    //}
                    
                    Thread.Sleep(300);
                }
            }

            public string CpuVoltage()
            {
                ManagementObjectSearcher cpuInformation = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_Processor");
               
                foreach (ManagementObject queryObj in cpuInformation.Get())
                {
                    outInfo = (Math.Round(System.Convert.ToDouble(queryObj["CurrentVoltage"]) /*/ 10, 2*/)).ToString();
                }
                return outInfo;
            }

            public string[] moreCpuInfo()
            {                
                string[] outInfo = new string[10];

                foreach (ManagementObject queryObj in cpuInformation.Get())
                {                    
                   outInfo[0] = queryObj["Name"].ToString();
                   outInfo[1] = queryObj["CurrentClockSpeed"].ToString();                 
                    outInfo[2] = queryObj["NumberOfCores"].ToString();
                    outInfo[3] = queryObj["ProcessorId"].ToString();
                    outInfo[4] = queryObj["ExtClock"].ToString();
                    outInfo[5] = queryObj["Family"].ToString();
                    outInfo[6] = queryObj["Manufacturer"].ToString();
                    outInfo[7] = queryObj["Description"].ToString();
                    outInfo[8] = queryObj["L2CacheSize"].ToString() + " Кб.";
                    outInfo[9] = queryObj["L3CacheSize"].ToString() + " Кб.";
                }
                return outInfo;
            }

            Computer myComputer = new Computer();
            public string[] ClokVoltage = new string[2];

            int cpuIndex = 0, cpuTotalInd = 0, cpuClockInd = 0; 
            public void findValueIndex()
            {
                myComputer.Open();
                myComputer.CPUEnabled = true;
                //myComputer.GPUEnabled = true;
                //myComputer.MainboardEnabled = true;
                //myComputer.RAMEnabled = true;
                //myComputer.FanControllerEnabled = true;
                //myComputer.HDDEnabled = true;

                for (int i = 0; i < myComputer.Hardware[cpuIndex].Sensors.Count(); i++) //myComputer.Hardware[15].Sensors.Count()
                {
                    if (myComputer.Hardware[cpuIndex].Sensors[i].Name == "CPU Total")
                    {
                        cpuTotalInd = i;
                    }
                    else if (myComputer.Hardware[cpuIndex].Sensors[i].Name == "CPU Core #1")
                    {
                        cpuClockInd = i;
                    }
                }
                myComputer.Close();
            }

            
            

            public void GetSystemInfo()
            {
                
                myComputer.Open();
                myComputer.CPUEnabled = true;
                //myComputer.GPUEnabled = true;
                //myComputer.MainboardEnabled = true;
                //myComputer.RAMEnabled = true;
                //myComputer.FanControllerEnabled = true;
                //myComputer.HDDEnabled = true;

                //if (ClokVoltage[1] == null)
                //{ ClokVoltage[1] = "0"; }

                //for (int i = 0; i < myComputer.Hardware.Count(); i++) //myComputer.Hardware[15].Sensors.Count()
                //{
                //    outInfo = myComputer.Hardware[i].Name;
                //}

                ClokVoltage[0] = myComputer.Hardware[cpuIndex].Sensors[cpuTotalInd].Value.ToString();
                ClokVoltage[1] = myComputer.Hardware[cpuIndex].Sensors[cpuClockInd].Value.ToString();

                myComputer.Hardware[cpuIndex].Update();
                myComputer.Hardware[cpuIndex].GetReport();

                //    foreach (var hardwareItem in myComputer.Hardware)
                //    {
                //        hardwareItem.Update();
                //        hardwareItem.GetReport();


                //        foreach (var sensor in hardwareItem.Sensors)
                //        {
                //            if (sensor.SensorType == SensorType.Voltage) 
                //            {
                //                ClokVoltage[0] = sensor.Value.ToString(); 
                //            }

                //            else if (sensor.SensorType == SensorType.Load && sensor.Name == "CPU Total")
                //            {   
                //                ClokVoltage[2] = sensor.Value.ToString(); continue;
                //            }

                //            else if(sensor.SensorType == SensorType.Clock && sensor.Name == "CPU Core #1")
                //            {
                //                ClokVoltage[1] = sensor.Value.ToString();                            
                //            }
                //        }

                //    }
                    myComputer.Close();               
            }

        }

    }


}
