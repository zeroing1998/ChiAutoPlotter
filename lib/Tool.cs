using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
namespace ChiAutoPlotter.lib
{
    static class Tool
    {
        public static string log(string msg)
        {
            return DateTime.Now.ToString()+">"+msg+"\r\n";
        }
        public static long GetHardDiskSpace(string str_HardDiskName)
        {
            long totalSize = new long();
            str_HardDiskName = str_HardDiskName.Split(':')[0] + ":\\";
            System.IO.DriveInfo[] drives = System.IO.DriveInfo.GetDrives();
            foreach (System.IO.DriveInfo drive in drives)
            {
                if (drive.Name == str_HardDiskName)
                {
                    totalSize = drive.TotalSize/1024/1024/1024;
                }
            }
            return totalSize;
        }
        public static long GetHardDiskLeftSpace(string str_HardDiskName)
        {
            long totalSize = new long();
            str_HardDiskName = str_HardDiskName.Split(':')[0]+":\\";
            System.IO.DriveInfo[] drives = System.IO.DriveInfo.GetDrives();
            foreach (System.IO.DriveInfo drive in drives)
            {
                if (drive.Name == str_HardDiskName)
                {
                    totalSize = drive.AvailableFreeSpace/1024/1024/1024;
                }
            }
            return totalSize;
        }
        public static void run_cmd(string cmd)
        {
            var proc = new Process();
            proc.StartInfo.FileName = "cmd.exe ";
            proc.StartInfo.Arguments = cmd;
            proc.StartInfo.UseShellExecute = false;
            proc.StartInfo.RedirectStandardInput = true;
            proc.Start();
            proc.StandardInput.WriteLine(cmd);
            Thread.Sleep(3000);
            proc.Kill();
        }
        public static void RunCmd(string cmd)
        {
            var proc = new Process();
            proc.StartInfo.FileName = "cmd.exe ";
            proc.StartInfo.Arguments = cmd;
            proc.StartInfo.UseShellExecute = false;
            proc.StartInfo.RedirectStandardInput = true;
            proc.Start();
            proc.StandardInput.WriteLine(cmd);
        }
    }
}
