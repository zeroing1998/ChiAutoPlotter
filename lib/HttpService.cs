using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Diagnostics;
namespace ChiAutoPlotter.lib
{
    class HttpService
    {
        private HttpListener service;

        private Thread listener_loop;

        public ChiaTaskGuiControl chia_task_gui_control =null;


        public StatesInfo states_info = new StatesInfo();
        public List<ChiaCmd> task_list;


        /*
        public bool start()
        {
            try
            {
                service = new HttpListener();
                service.Prefixes.Add("http://+:"+Global.http_port+"/");
                service.Start();
                listener_loop = new Thread(_listener_loop);
                listener_loop.Start();
                return true;
            }
            catch(Exception e)
            {
                return false;
            }

        }
        */


        public bool start()
        {
            try
            {
                //重启群控
                if (Global.can_remote_control && service != null&&!service.IsListening)
                {
                    service.Start();
                    listener_loop = new Thread(_listener_loop);
                    listener_loop.Start();
                    return true;
                }
                //实例化群控并启动
                if (Global.can_remote_control && service == null)
                {
                    service = new HttpListener();
                    service.Prefixes.Add("http://+:" + Global.http_port + "/");
                    service.Start();
                    listener_loop = new Thread(_listener_loop);
                    listener_loop.Start();
                    init();
                    return true;
                }
                //关闭群控接受
                if(!Global.can_remote_control&& listener_loop.IsAlive)
                {
                    if (listener_loop.IsAlive)
                    {
                        listener_loop.Abort();
                    }
                    if (service.IsListening)
                    {
                        service.Stop();
                    }
                    return true;
                }
                return false;
            }catch(Exception e)
            {
                chia_task_gui_control.gui_log(e.Message);
                chia_task_gui_control.gui_log(e.StackTrace);
                return false;
            }
        }







        public void init()
        {
            states_info.name = Global.client_name;
            states_info.cpu = HardWareInfo.get_cpu_name();
            states_info.ram = HardWareInfo.get_ram();
        }
        public void _listener_loop()
        {



            while (true)
            {
                try
                {
                    HttpListenerContext user = service.GetContext();
                    user.Response.ContentType = "text/html; charset=utf-8";//设置utf8响应
                    if (user.Request.QueryString["pass"] != Global.password)
                    {
                        var outstream = new StreamWriter(user.Response.OutputStream);
                        outstream.Write(JsonConvert.SerializeObject(new Msg() { error = true, msg = "矿机密码错误" }));
                        outstream.Close();
                        continue;
                    }


                    if (user.Request.Url.LocalPath == "/get")
                    {
                        c_get(user);
                        continue;
                    }
                    if (user.Request.Url.LocalPath == "/ping")
                    {
                        c_ping(user);
                        continue;
                    }

                    if (user.Request.Url.LocalPath == "/start")
                    {
                        c_start(user);
                        continue;
                    }

                    if (user.Request.Url.LocalPath == "/stop")
                    {
                        c_stop(user);
                        continue;
                    }
                    if (user.Request.Url.LocalPath == "/stop_add")
                    {
                        c_stop_add(user);
                        continue;
                    }
                    if (user.Request.Url.LocalPath == "/get_args")
                    {
                        c_get_args(user);
                        continue;
                    }
                    if (user.Request.Url.LocalPath == "/set_args")
                    {
                        c_set_args(user);
                        continue;
                    }
                    if (user.Request.Url.LocalPath == "/get_task_list")
                    {
                        c_get_task_list(user);
                        continue;
                    }
                    if (user.Request.Url.LocalPath == "/get_task_log")
                    {
                        c_get_task_log(user);
                        continue;
                    }



                }
                catch(ThreadAbortException e)
                {
                    break;
                }
                catch(Exception e)
                {
                    chia_task_gui_control.gui_log("群控请求错误，错误原因:" + e.Message);
                    chia_task_gui_control.gui_log("群控请求错误，错误原因:" + e.StackTrace);
                }
            }
        }

        public void disk_list()
        {
            states_info.disks.Clear();
            string[] disks = new string[] {"A","B","C","D","E","F","G","H","I","J","K","L","M","N","O","P","Q","R","S","T","U","V","W","X","Y","Z"};
            foreach(string disk in disks)
            {
                states_info.disks.Add(new DiskInfo()
                {
                    name= disk,
                    size=Tool.GetHardDiskSpace(disk).ToString(),
                    left_size=Tool.GetHardDiskLeftSpace(disk).ToString()
                });;
            }
        }



        public void c_get(HttpListenerContext user)
        {


            //构造状态信息并填充
            states_info.ip = user.Request.UserHostAddress;
            states_info.client_log = Global.main_form.textBox_log.Text;
            disk_list();//更新硬盘信息


            if (chia_task_gui_control.control_thread == null)
            {
                states_info.state = "空闲中...";
            }
            else
            {
                if (chia_task_gui_control.control_thread.IsAlive)
                {
                    states_info.state = "运行中...";
                }
                else
                {
                    states_info.state = "空闲中...";
                }
            }







            //转换为json并输出
            var outstream = new StreamWriter(user.Response.OutputStream);
            outstream.Write(JsonConvert.SerializeObject(states_info, new JsonSerializerSettings() {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,

            }));
            outstream.Close();
        }

        public void c_ping(HttpListenerContext user)
        {
            var outstream = new StreamWriter(user.Response.OutputStream);
            outstream.Write(JsonConvert.SerializeObject(new Msg() { error=false,msg= "online"}));
            outstream.Close();
        }
        public void c_start(HttpListenerContext user)
        {
            var outstream = new StreamWriter(user.Response.OutputStream);
            

           Global.main_form.Invoke(new Action(() =>
           {
               chia_task_gui_control.start(false);
           }));
           outstream.Write(JsonConvert.SerializeObject(new Msg() { error = false, msg = "启动命令执行成功,详情请看日志" }));
            outstream.Close();
        }
        public void c_stop(HttpListenerContext user)
        {
            var outstream = new StreamWriter(user.Response.OutputStream);
            Global.main_form.Invoke(new Action(() =>
            {
                Global.main_form.button_stop.PerformClick();
            }));
            outstream.Write(JsonConvert.SerializeObject(new Msg() { error = false, msg = "停止命令执行成功,详情请看日志" }));
            outstream.Close();
        }

        public void c_stop_add(HttpListenerContext user)
        {
            var outstream = new StreamWriter(user.Response.OutputStream);
            Global.main_form.Invoke(new Action(() =>
            {
                Global.main_form.button_stop_add_new_task.PerformClick();
            }));
            outstream.Write(JsonConvert.SerializeObject(new Msg() { error = false, msg = "停止添加命令执行成功,详情请看日志" }));
            outstream.Close();
        }
        public void c_get_args(HttpListenerContext user)
        {


            var args = new Args();
            args.error = false;
            args.msg = "读取参数成功";
            //首页参数
            args.temp_disk = Global.main_form.textBox_temp_disk.Text;
            args.save_disk = Global.main_form.textBox_save_disk.Text;
            args.max_ram = Global.main_form.textBox_max_ram.Text;
            args.single_thread = Global.main_form.textBox_single_thread.Text;
            args.start_interval = Global.main_form.textBox_start_interval.Text;
            args.tasks = Global.main_form.textBox_tasks.Text;
            //高级参数
            args.start_before_end = Global.main_form.checkBox_start_before_end.Checked;
            args.time_out = Global.main_form.textBox_time_out.Text;
            args.plot_size = Global.main_form.textBox_plot_size.Text;
            args.fpk = Global.main_form.textBox_fpk.Text;
            args.ppk = Global.main_form.textBox_ppk.Text;
            var outstream = new StreamWriter(user.Response.OutputStream);
            outstream.Write(JsonConvert.SerializeObject(args));
            outstream.Close();
        }
        public void c_set_args(HttpListenerContext user)
        {
            var outstream = new StreamWriter(user.Response.OutputStream);
            try {
                if (user.Request.HttpMethod != "POST")
                {
                    outstream.Write(JsonConvert.SerializeObject(new Msg() { error = false, msg = "请使用POST模式提交设置参数" }));
                    outstream.Close();
                    return;
                }
                var input_stream = new StreamReader(user.Request.InputStream);

                var data = JsonConvert.DeserializeObject<Args>(input_stream.ReadToEnd());
                input_stream.Close();
                Global.main_form.BeginInvoke(new Action(() =>
                {
                    Global.main_form.textBox_temp_disk.Text = data.temp_disk;
                    Global.main_form.textBox_save_disk.Text = data.save_disk;
                    Global.main_form.textBox_max_ram.Text = data.max_ram;
                    Global.main_form.textBox_single_thread.Text = data.single_thread;
                    Global.main_form.textBox_start_interval.Text = data.start_interval;
                    Global.main_form.textBox_tasks.Text = data.tasks;
                    //高级参数
                    Global.main_form.checkBox_start_before_end.Checked = data.start_before_end;
                    Global.main_form.textBox_time_out.Text = data.time_out;
                    Global.main_form.textBox_plot_size.Text = data.plot_size;
                    Global.main_form.textBox_ppk.Text = data.ppk;
                    Global.main_form.textBox_fpk.Text = data.fpk;
                }));
                outstream.Write(JsonConvert.SerializeObject(new Msg() { error = false, msg = "参数更新成功" }));
                outstream.Close();
            }
            catch(Exception e)
            {
                chia_task_gui_control.gui_log("发送任务信息至群控系统失败，错误原因:" + e.Message);
                chia_task_gui_control.gui_log("发送任务信息至群控系统失败，错误位置:" + e.StackTrace);

            }
        }
        public void c_get_task_list(HttpListenerContext user)
        {
            try
            {
                var data = new TaskList() { task_list = chia_task_gui_control.task_list, error = false, msg = "读取成功" };
                var outstream = new StreamWriter(user.Response.OutputStream);
                outstream.Write(JsonConvert.SerializeObject(data));
                outstream.Close();
            }catch(Exception e)
            {
                chia_task_gui_control.gui_log("发送任务信息至群控系统失败，错误原因:"+e.Message);
                chia_task_gui_control.gui_log("发送任务信息至群控系统失败，错误位置:" + e.StackTrace);
            }
        }
        
        public void c_get_task_log(HttpListenerContext user)
        {
            var outstream = new StreamWriter(user.Response.OutputStream);
            if (user.Request.QueryString["index"] == null)
            {
                outstream.Write(JsonConvert.SerializeObject(new Msg() { error = true, msg = "参数不全，请提供index参数!" }));
                outstream.Close();
                return;
            }
            try
            {
                int index = int.Parse(user.Request.QueryString["index"]);

                if(index+1> chia_task_gui_control.task_list.Count)
                {
                    outstream.Write(JsonConvert.SerializeObject(new Msg() { error=true,msg="任务不存在!"}));
                    outstream.Close();
                    return;
                }
                else
                {
                    outstream.Write(JsonConvert.SerializeObject(new TaskLog() { error = false, msg = "读取成功",raw_log=chia_task_gui_control.task_list[index].rawlogs }));
                    outstream.Close();
                }


            }
            catch (Exception e)
            {
                chia_task_gui_control.gui_log("发送任务信息至群控系统失败，错误原因:" + e.Message);
                chia_task_gui_control.gui_log("发送任务信息至群控系统失败，错误位置:" + e.StackTrace);
            }

        }
    }
}
