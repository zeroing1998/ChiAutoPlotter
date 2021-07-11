using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace ChiAutoPlotter.reg
{
    static class Reg
    {

        //机器码和注册码
        public static string get_m_code()
        {
            string salt = "";

            for(int i = 365; i < 9999; i+=512)
            {
                salt += i.ToString("X2");
            }
            string strCpu = null;
            ManagementClass myCpu = new ManagementClass("win32_Processor");
            ManagementObjectCollection myCpuConnection = myCpu.GetInstances();
            foreach (ManagementObject myObject in myCpuConnection)
            {
                strCpu = myObject.Properties["Processorid"].Value.ToString();
                break;
            }
            var sha512 = SHA512.Create();
            var regcode = sha512.ComputeHash(Encoding.ASCII.GetBytes(strCpu+salt));
            var regcode_ = "";
            for(int i = 0; i < regcode.Length; i++)
            {
                regcode_ += regcode[i].ToString("X2");
            }


            return regcode_;
        }

        //取注册码
        public static string get_reg(string m_code)
        {
            string salt = "";

            for (int i = 555; i < 77733; i += 512)
            {
                salt += i.ToString("X2");
            }

            var sha512 = SHA512.Create();
            var regcode = sha512.ComputeHash(Encoding.ASCII.GetBytes(m_code + salt));
            var regcode_ = "";
            for (int i = 0; i < regcode.Length; i++)
            {
                regcode_ += regcode[i].ToString("X2");
            }
            Debug.WriteLine(regcode_);

            return regcode_;
        }

    }
}
