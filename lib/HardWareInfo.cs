using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic.Devices;
namespace ChiAutoPlotter.lib
{
    public static class HardWareInfo
    {
        public static string get_cpu_name()
        {

            string CPUName = "";
            ManagementObjectSearcher mos = new ManagementObjectSearcher("Select * from Win32_Processor");//Win32_Processor  CPU处理器
            foreach (ManagementObject mo in mos.Get())
            {
                CPUName = mo["Name"].ToString();
            }
            return CPUName;
        }
        public static string get_ip()
        {
            return Dns.GetHostAddresses(Dns.GetHostName()).GetValue(0).ToString();
        }
        public static string get_ram()
        {
            return (new ComputerInfo().TotalPhysicalMemory / 1024 / 1024).ToString() + " MB";
        }
    }
}
