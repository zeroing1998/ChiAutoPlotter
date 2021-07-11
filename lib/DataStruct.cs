using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChiAutoPlotter.lib
{
    public class Msg
    {
        public bool error = false;
        public string msg = "";
    }
    public class StatesInfo:Msg
    {
        public string name;
        public string ip;
        public string cpu;
        public string ram;
        public string client_log;
        public string state;

        public List<DiskInfo> disks = new List<DiskInfo>();
    }

    public class DiskInfo
    {
        public string name;
        public string size; // mb
        public string left_size;
    }
    public class Args:Msg
    {
        //主界面参数
        public string temp_disk;
        public string save_disk;
        public string fingerprint;
        public string max_ram;
        public string single_thread;
        public string start_interval;
        public string tasks;
        //高级设置
        public bool start_before_end;
        public string time_out;
        public string plot_size;
        public bool agent;
        public string ppk;
        public string fpk;
    }
    public class TaskList : Msg
    {
        public List<ChiaCmd> task_list;
    }
    public class TaskLog : Msg
    {
        public string raw_log ;
    }

}
