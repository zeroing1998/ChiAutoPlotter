using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChiAutoPlotter.lib
{
    static class Global
    {

        public static Form1 main_form;

        public static string chia_root_path = "";
        public static int mode = 1;//1=普通模式，2=换盘模式
        public static bool agent = false;
        public static bool start_befor_end = false;
        public static string current_save_disk = null;//当前运行的存储盘
        public static int time_out = 86400;//运行超时
        public static string plot_size = "32";//plot文件大小 32=102 33=209 34=430

        public static object list_lock;




        //群控相关
        public static HttpService http_service = null;
        public static int http_port = 8866;
        public static bool can_remote_control = false;
        public static string client_name = "未命名";
        public static string password = "123456";

    }
}
