using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;
namespace ChiAutoPlotter.lib
{
    static class AppTool
    {
        /**
         * 获取钱包路径
         */
        public static string get_chia_path()
        {
            if (File.Exists("default.ini"))
            {
                var ini = new IniFile();
                string path = ini.readIni("chia_root_path");
                if (Directory.Exists(path) == false)
                {
                    var process = Process.GetProcessesByName("Chia");
                    foreach (Process p in process)
                    {

                        if (p.MainModule.FileName.IndexOf("chia-blockchain") != -1)
                        {
                            return p.MainModule.FileName.Replace("Chia.exe", "");
                        }
                    }
                }
                else
                {
                    return path;
                }

            }
            else//配置文件不存在则读取进程路径
            {
                var process2 = Process.GetProcessesByName("Chia");
                foreach (Process p in process2)
                {

                    if (p.MainModule.FileName.IndexOf("chia-blockchain") != -1)
                    {
                        return p.MainModule.FileName.Replace("Chia.exe", "");
                    }
                }
            }
            return "未开启";


        }
    }
}
