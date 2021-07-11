using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Threading;
using System.Text.RegularExpressions;
/**
 * 此类用于构建chiaploter命令行
 */


namespace ChiAutoPlotter.lib
{
    public class ChiaCmd
    {
        private string exe_path = "resources\\app.asar.unpacked\\daemon/chia.exe";

        private string base_cmd = "plots create";

        private Process plotter_task;

        private Thread plotter_task_thread;

        private Thread timer;
        private Thread error;

        public int k = 32; //块大小

        public int n = 1; //未知

        public string t = ""; //临时盘1

        public string _2 = "";//临时盘2

        public string d = "";//目标盘

        public int b = 4000;//最大内存

        public int u = 128;//桶大小

        public int r = 8;//线程数

        public string a = "";//钱包

        public bool agent = false;

        public string p = "";//Pool public key

        public string f = "";//Farmer public key

        public string plot_id = null;//plot 文件特征id 用于清除缓存



        public int id = 0;//任务id

        public string chia_root_path = "";//钱包根目录

        public float plotter_progress = 0;//p图进程

        

        public string status = "";//运行状态
        [Newtonsoft.Json.JsonIgnore()]
        public string rawlogs = "";//原始日志
        public int run_time = 0;//耗费的时间
        public string start_time;

        [Newtonsoft.Json.JsonIgnore()]
        public ChiaTaskGuiControl control;





        public string getcmd()
        {
            t = t + "chiacache\\";
            _2 = t;
            string cmd = base_cmd +" -n"+n.ToString()+" -t"+t+" -2"+_2+" -d"+d+" -b"+b.ToString()+" -u"+u.ToString()+" -r"+r.ToString();

            cmd += " -k" + Global.plot_size;//plot大小


            if (agent)
            {
                cmd += " -c" + p;
                cmd += " -f" + f;
            }
            else
            {
                cmd += " -a" + a;
            }


            cmd += " -x";
            rawlogs = "启动命令:"+rawlogs+cmd + "\r\n";
            return cmd;
        }

        //运行一个任务线程
        public void run()
        {
            start_time = DateTime.Now.ToString();
            plotter_progress = 0;
            plotter_task_thread = new Thread(_run);
            plotter_task_thread.Start();

            //启动任务计时器
            timer = new Thread(_timer);
            timer.Start();
            //启动错误读取线程
            error = new Thread(_error);
            error.Start();

        }
        private void _run()
        {
            status = "任务运行中...";
            plotter_task = new Process();
            try
            {



                //plotter_task.StartInfo.FileName = chia_root_path + exe_path;
                plotter_task.StartInfo.FileName = Global.chia_root_path;
                plotter_task.StartInfo.Arguments = getcmd();
                plotter_task.StartInfo.RedirectStandardError = true;
                plotter_task.StartInfo.RedirectStandardOutput = true;
                plotter_task.StartInfo.RedirectStandardInput = true;
                plotter_task.StartInfo.UseShellExecute = false;
                plotter_task.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                plotter_task.StartInfo.CreateNoWindow = true;
                plotter_task.Start();
                while (true)
                {
                    var msg = plotter_task.StandardOutput.ReadLine();
                    if (msg == null)
                    {
                        continue;
                    }
                    rawlogs += msg + "\r\n";
                    //control.gui_log("来自任务[" + id.ToString() + "]的消息>>" + msg + "\r\n");
                    Debug.WriteLine(msg);

                    if (msg.IndexOf("uniform sort") != -1)//p图进展+1
                    {
                        plotter_progress += 0.04024f;
                        Debug.WriteLine(plotter_progress);
                    }

                    if(msg.IndexOf("Final File size") != -1)
                    {
                        status = "文件移动中...";
                        plotter_progress = 100f;
                    }

                    if (msg.IndexOf("Renamed final") != -1)//p图完成
                    {
                        status = "任务运行完成!";
                        break;
                    }
                    if (msg.IndexOf("error") != -1)//p图失败
                    {
                        status = "内核出错!";
                        break;
                    }
                    if (msg.IndexOf("Error") != -1)//p图失败
                    {
                        status = "内核出错!";
                        break;
                    }
                    if (msg.IndexOf("Traceback") != -1)//p图失败
                    {
                        status = "内核出错!";
                        break;
                    }
                }
                
            }
            catch(Exception e)
            {
                Debug.WriteLine(e.Message);
                rawlogs += e.Message + "\r\n";
                rawlogs += e.StackTrace + "\r\n";
                status = "任务运行失败!";
            }
            finally
            {
                self_kill(status);
            }
        }
        private void _error()
        {
            while (true)
            {
                try
                {
                    var msg = plotter_task.StandardError.ReadLine();
                    rawlogs += msg + "\r\n";
                    Debug.WriteLine("error>"+msg);
                }catch(Exception e)
                {
                    Debug.WriteLine("错误捕获失败");
                }
                finally
                {
                    Thread.Sleep(1000);
                }

            }
        }





        private void _timer()
        {
            while (true)
            {
                Thread.Sleep(999);
                run_time += 1;
                if (run_time > Global.time_out)
                {
                    self_kill("任务超时");
                }
                
            }
        }
        public void self_kill(string why)
        {
            try { timer.Abort(); } catch (Exception e) { }
            try { error.Abort(); } catch (Exception e) { }
            try { plotter_task.Kill(); } catch (Exception e) { }
            Thread.Sleep(2000);//删除缓存时稍微停顿一下，防止文件占用的情况发生
            string plot_id = "";
            try {
                //ID: ([a-z0-f]+)   先获取id
                var match = Regex.Match(rawlogs, "ID: ([a-z0-f]+)");
                if (match.Success)
                {
                    plot_id = match.Groups[1].Value;
                    var dir = new DirectoryInfo(t);
                    foreach (var file in dir.EnumerateFiles("*"+plot_id+"*"+".tmp"))
                    {
                        try
                        {
                            
                            file.Delete();
                            //control.gui_log("来自任务[" + id.ToString() + "]的消息>>" + file.Name + "缓存删除成功！\r\n");
                        }
                        catch(Exception e)
                        {
                            //control.gui_log("来自任务[" + id.ToString() + "]的消息>>" + "缓存文件删除失败原因:" + e.Message + "\r\n");
                        }
                    }

                }
                control.gui_log("任务[" + id.ToString() + "]缓存清理完毕！\r\n");
            }
            catch(Exception e) {
                control.gui_log("任务[" + id.ToString() + "]缓存文件删除失败原因:" +e.Message+ "\r\n");
            }
            



            status = why;
        }
    }
}
