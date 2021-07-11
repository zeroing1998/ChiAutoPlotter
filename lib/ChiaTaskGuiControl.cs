using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;

namespace ChiAutoPlotter.lib
{
    public class ChiaTaskGuiControl
    {
        public Form1 control_form;

        

        public Thread control_thread;
        public List<ChiaCmd> task_list = new List<ChiaCmd>();//任务列表

        private string save_disk;
        private int max_ram; //单个任务最大内存使用量
        private int single_thread;//单个任务的线程数
        private int start_interval;//每个任务的启动间隔
        private int tasks;//同时运行的任务数
        private int last_id = 0;//最大的id
        private int disk_index = 0;//模式2下的硬盘切换索引
        private bool agent;
        private string fpk = ""; //农民公钥
        private string ppk = ""; //矿池公钥
        private string[] temp_disks;//暂存盘
        private string[] save_disks;//存储盘
        private int shift_id_temp_disk = 0;//缓存盘切换id
        private int shift_id_save_disk = 0;//存储盘切换id
        private int plot_file_size = 0;
       


        private String[] save_disk_list;


        public void start(bool update)
        {


            if (control_thread != null&&control_thread.IsAlive) {
                gui_log("已经启动");
                return;
            }



            //载入参数
            if (control_form.textBox_save_disk.Text.IndexOf(":") != -1)
            {
                if (Global.can_remote_control)
                {
                    gui_log("存储盘符格式错误，请填写盘符，用/隔开，如 C/D/E，如果只有1个盘，只填写1个盘符字母即可");
                    return;
                }
                MessageBox.Show("存储盘符格式错误，请填写盘符，用/隔开，如 C/D/E，如果只有1个盘，只填写1个盘符字母即可");
                return;
            }

            if (control_form.textBox_temp_disk.Text.IndexOf(":") != -1)
            {
                if (Global.can_remote_control)
                {
                    gui_log("临时盘符格式错误，请填写盘符，用/隔开，如 C/D/E，如果只有1个盘，只填写1个盘符字母即可");
                    return;
                }
                MessageBox.Show("临时盘符格式错误，请填写盘符，用/隔开，如 C/D/E，如果只有1个盘，只填写1个盘符字母即可");
                return;
            }




            if (control_form.textBox_temp_disk.Text.IndexOf("/") != -1)
            {
                temp_disks = control_form.textBox_temp_disk.Text.Split('/');
            }
            else
            {
                temp_disks = new string[] { control_form.textBox_temp_disk.Text };
            }

            if (control_form.textBox_save_disk.Text.IndexOf("/") != -1)
            {
                save_disks = control_form.textBox_save_disk.Text.Split('/');
            }
            else
            {
                save_disks = new string[] { control_form.textBox_save_disk.Text };
            }


            try
            {
                if (int.Parse(control_form.textBox_time_out.Text) < 3)
                {
                    if (Global.can_remote_control)
                    {
                        gui_log("请填写适当的任务超时时间！");
                        return;
                    }
                    MessageBox.Show("请填写适当的任务超时时间！");
                    return;
                }
            }catch(Exception e)
            {
                if (Global.can_remote_control)
                {
                    gui_log("请不要在超时时间中设置非数字参数！");
                    return;
                }
                MessageBox.Show("请不要在超时时间中设置非数字参数！");
                return;
            }

            try
            {
                if (int.Parse(control_form.textBox_plot_size.Text) <31)
                {
                    if (Global.can_remote_control)
                    {
                        gui_log("请填写适当的k值！");
                        return;
                    }
                    MessageBox.Show("请填写适当的k值！");
                    return;
                }
            }
            catch (Exception e)
            {
                if (Global.can_remote_control)
                {
                    gui_log("请不要在k值中设置非数字参数！");
                    return;
                }
                MessageBox.Show("请不要在k值中设置非数字参数！");
                return;
            }



            Global.time_out = int.Parse(control_form.textBox_time_out.Text) * 60 * 60;
            Global.plot_size = control_form.textBox_plot_size.Text;
            if (Global.plot_size == "32")
            {
                plot_file_size = 102;
            }
            if (Global.plot_size == "33")
            {
                plot_file_size = 209;
            }
            if (Global.plot_size == "34")
            {
                plot_file_size = 430;
            }






            save_disk = control_form.textBox_save_disk.Text;
            max_ram = int.Parse(control_form.textBox_max_ram.Text);
            single_thread = int.Parse(control_form.textBox_single_thread.Text);
            start_interval = int.Parse(control_form.textBox_start_interval.Text);
            tasks = int.Parse(control_form.textBox_tasks.Text);
            fpk = control_form.textBox_fpk.Text.Replace("0x","").Replace("0X","");
            ppk = control_form.textBox_ppk.Text.Replace("0x", "").Replace("0X", "");





            if (fpk.Length < 3)
            {
                if (Global.can_remote_control)
                {
                    gui_log("请填写Farmer public key");
                    return;
                }
                MessageBox.Show("请填写Farmer public key");
                return;
            }

            if (ppk.IndexOf("xch")!=0)
            {
                if (Global.can_remote_control)
                {
                    gui_log("请填写正确的 合作社合约地址(pool_contract_address)NFT地址");
                    return;
                }
                MessageBox.Show("请填写正确的 合作社合约地址(pool_contract_address)NFT地址");
                return;
            }
            








            if (temp_disks.Length < 1)
            {
                if (Global.can_remote_control)
                {
                    gui_log("请填写缓存盘路径");
                    return;
                }
                MessageBox.Show("请填写缓存盘路径");
                return;
            }
            if (save_disk.Length < 1)
            {
                if (Global.can_remote_control)
                {
                    gui_log("请填写存储盘路径");
                    return;
                }
                MessageBox.Show("请填写存储盘路径");
                return;
            }
            if (max_ram < 1)
            {
                if (Global.can_remote_control)
                {
                    gui_log("请填写内存使用量");
                    return;
                }
                MessageBox.Show("请填写内存使用量");
                return;
            }
            if (single_thread < 1)
            {
                if (Global.can_remote_control)
                {
                    gui_log("请填写任务线程数");
                    return;
                }
                MessageBox.Show("请填写任务线程数");
                return;
            }

            if (tasks < 1)
            {
                if (Global.can_remote_control)
                {
                    gui_log("请填写同时运行的任务数量");
                    return;
                }
                MessageBox.Show("请填写同时运行的任务数量");
                return;
            }
            if (update)
            {
                gui_log("已更新参数");
                return;
            }
            control_form.button_start.Enabled = false;
            control_form.button_stop.Enabled = true;
            control_form.button_stop_add_new_task.Enabled = true;
            control_form.button_update_args.Enabled = true;
            control_form.button_stop.Enabled = true;
            control_thread = new Thread(_start);
            control_thread.Start();
            if (Global.can_remote_control)
            {
                Global.http_service.task_list = task_list;
            }



        }
        private void _start()
        {
            int p_full_disks = 0;
            
            gui_log("开始启动P盘任务");
            while (true)
            {
                try
                {
                    

                    //遍历运行的任务数量

                    if (get_run_task_count() >= tasks)
                    {
                        gui_log("任务队列已满,稍后尝试添加新p图任务");
                        Thread.Sleep(15000);
                        continue;
                    }

                    //存储盘，轮切
                    save_disk = save_disks[(shift_id_save_disk) % save_disks.Length];
                    save_disk+=":\\";


                    //判断剩余任务完成后的剩余空间
                    if ((get_able_save_space(save_disk) + 1) * plot_file_size > Tool.GetHardDiskLeftSpace(save_disk) || Tool.GetHardDiskLeftSpace(save_disk) < plot_file_size)
                    {
                        shift_id_save_disk += 1;//盘满，存储盘轮换到另一个
                        gui_log("硬盘:"+ save_disk+"P满了,此盘将被跳过!");
                        Thread.Sleep(15000);
                        p_full_disks += 1;
                        if (p_full_disks >= save_disks.Length)
                        {
                            gui_log("所有存储盘都满了，自动化过程已中止!");
                            break;
                        }
                        continue;
                    }
                    p_full_disks = 0;//重置

                    ChiaCmd task = new ChiaCmd();
                    task.b = max_ram;
                    task.chia_root_path = Global.chia_root_path;

                    
                    task.t = temp_disks[(shift_id_temp_disk) % temp_disks.Length]+":\\";//暂存盘，轮切模式
                    task.d = save_disk;
                    task.id = last_id;
                    task.control = this;
                    task.agent = true;
                    task.r = single_thread;
                    task.p = ppk;
                    task.f = fpk;
                    Global.current_save_disk = save_disk.Split(':')[0];
                    task.run();
                    lock (Global.list_lock)
                    {
                        task_list.Add(task);
                    }
                    shift_id_temp_disk += 1;//缓存盘轮换
                    shift_id_save_disk += 1;//存储盘轮换
                    last_id += 1;//任务序号
                    gui_log("任务:[" + last_id.ToString() + "]开始运行...");
                    Thread.Sleep(start_interval * 1000);

                }
                catch(ThreadAbortException e)
                {
                    break;
                }
                catch(Exception e)
                {
                    gui_log("错误内容:" + e.Message);
                    gui_log("错误详情:" + e.StackTrace);
                    Thread.Sleep(2000);
                }
            }
        }
        public int get_able_save_space(string save_disk)
        {
            int run_count = 0;
            for (int i = 0; i < task_list.Count; i++)
            {
                if (task_list[i].status == "任务运行中..." && task_list[i].d.IndexOf(save_disk) != -1)
                {
                    run_count += 1;
                }

                if (task_list[i].status == "文件移动中..." && task_list[i].d.IndexOf(save_disk) != -1 && Global.start_befor_end == false)
                {
                    run_count += 1;
                }
            }
            return run_count;
        }

        public int get_run_task_count()
        {
            int run_count = 0;
            for(int i = 0;i< task_list.Count; i++)
            {
                if(task_list[i].status == "任务运行中...")
                {
                    run_count += 1;
                }

                if (task_list[i].status == "文件移动中..."&& Global.start_befor_end == false)
                {
                    run_count += 1;
                }
            }
            return run_count;
        }

        public void gui_log(string msg)
        {
            try
            {
                control_form.BeginInvoke(new Action(() =>
                {
                    control_form.textBox_log.AppendText(DateTime.Now.ToString() + ">" + msg + "\r\n");
                    control_form.listView1.VirtualListSize = task_list.Count;
                }));
            }catch(Exception e)
            {

            }
        }

        private void _print_task()
        {
            while (true)
            {
                control_form.listView1.VirtualListSize = task_list.Count;

            }
        }
        //获取某个盘符下，可添加的剩余任务数
        private void get_able_add_task_disk()
        {

        }

        //停止所有并停止添加新任务
        public void stop()
        {
            new Thread(_stop).Start();
        }
        public void _stop()
        {
            
            foreach (ChiaCmd task in task_list)
            {
                if (task.status == "任务运行中..." || task.status == "文件移动中...")
                {
                    task.self_kill("手动中止");
                    gui_log("任务[" + task.id.ToString() + "]手动停止!");
                    if (control_thread.IsAlive)
                    {
                        control_thread.Abort();
                    }
                }
            }
            control_form.BeginInvoke(new Action(() =>
            {
                control_form.button_start.Enabled = true;
            }));
        }
       
    }
}
