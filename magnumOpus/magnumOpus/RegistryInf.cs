using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace magnumOpus
{
    class RegistryInf
    {
        public string boardManufacturer;
        public string boardVersion;
        public string BIOSreliseDate;
        public string BIOSvendor;
        public string BiosVersion;

        public string identifier;
        public string cpuName;
        public string cpuVendor;

        void biosInf()
        {
            RegistryKey hklm = Registry.LocalMachine;
            RegistryKey hkHardware = hklm.OpenSubKey("HARDWARE");
            RegistryKey hkDescription = hkHardware.OpenSubKey("DESCRIPTION");
            RegistryKey hkSystem = hkDescription.OpenSubKey("System");
            RegistryKey hkBios = hkSystem.OpenSubKey("BIOS");
            boardManufacturer = hkBios.GetValue("BaseBoardManufacturer").ToString();
            boardVersion = hkBios.GetValue("BaseBoardVersion").ToString();
            BIOSreliseDate = hkBios.GetValue("BIOSReleaseDate").ToString();
            BIOSvendor = hkBios.GetValue("BIOSVendor").ToString();
            BiosVersion = hkBios.GetValue("BIOSVersion").ToString();
        }

        void cpuInf()
        {
            RegistryKey hklm = Registry.LocalMachine;
            RegistryKey hkHardware = hklm.OpenSubKey("HARDWARE");
            RegistryKey hkDescription = hkHardware.OpenSubKey("DESCRIPTION");
            RegistryKey hkSystem = hkDescription.OpenSubKey("System");
            RegistryKey hkCPU = hkSystem.OpenSubKey("CentralProcessor");
            RegistryKey hk0 = hkCPU.OpenSubKey("0");
            identifier = hk0.GetValue("Identifier").ToString();
            cpuName = hk0.GetValue("ProcessorNameString").ToString();
            cpuVendor = hk0.GetValue("VendorIdentifier").ToString();
        }

        public RegistryInf()
        {
            cpuInf();
            biosInf();
        }
    }
}
