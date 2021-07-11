using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using ChiAutoPlotter.lib;
using System.Diagnostics;
namespace ChiAutoPlotter
{
    public partial class Form1 : Form
    {
        public string wallet_path = "";
        public ChiaTaskGuiControl chia_task_gui_control;

        public Form1()
        {
            
            InitializeComponent();
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void button_start_Click(object sender, EventArgs e)
        {
            chia_task_gui_control.start(false);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Global.list_lock = new object();
            chia_task_gui_control = new ChiaTaskGuiControl();
            chia_task_gui_control.control_form = this;
            Global.main_form = this;
            Global.chia_root_path = Directory.GetCurrentDirectory() + @"\daemon\chia.exe";
            if (!File.Exists(Global.chia_root_path))
            {
                MessageBox.Show("程序文件不完整!缺少关键文件:"+ Global.chia_root_path);
                Process.GetCurrentProcess().Kill();
            }
            if (File.Exists("default.ini"))
            {
                var ini = new IniFile();
                textBox_max_ram.Text = ini.readIni("max_ram");
                textBox_save_disk.Text = ini.readIni("save_disk");
                textBox_single_thread.Text = ini.readIni("single_thread");
                textBox_start_interval.Text = ini.readIni("start_interval");
                textBox_tasks.Text = ini.readIni("tasks");
                textBox_temp_disk.Text = ini.readIni("temp_disk");
                textBox_ppk.Text = ini.readIni("ppk");
                textBox_fpk.Text = ini.readIni("fpk");
                textBox_time_out.Text = ini.readIni("time_out");
                textBox_plot_size.Text = ini.readIni("plot_size");
                textBox_name.Text = ini.readIni("client_name");
                textBox_password.Text = ini.readIni("password");
                if (ini.readIni("start_before_end") == "true")
                {
                    checkBox_start_before_end.Checked = true;
                }
                if (ini.readIni("remote_control") == "true")
                {
                    checkBox_can_remote_control.Checked = true;
                    Global.can_remote_control = true;
                }
            }
            textBox_log.AppendText(Tool.log("程序启动"));
        }

        private void button_choose_temp_disk_Click(object sender, EventArgs e)
        {


            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox_temp_disk.Text = folderBrowserDialog1.SelectedPath;
            }

        }

        private void button_choose_save_disk_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox_save_disk.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        public void button_stop_Click(object sender, EventArgs e)
        {

            if (!Global.can_remote_control)
            {
                if (MessageBox.Show("此操作将中止所有正在进行的任务,你确定要停止吗?\r\n包括官方客户端的p图任务", "提示", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    return;
                }
            }
            button_stop_add_new_task.Enabled = false;
            button_stop.Enabled = false;
            button_update_args.Enabled = false;
            chia_task_gui_control.stop();
                

            
        }

        private void listView1_VirtualItemsSelectionRangeChanged(object sender, ListViewVirtualItemsSelectionRangeChangedEventArgs e)
        {

        }

        private void listView1_RetrieveVirtualItem(object sender, RetrieveVirtualItemEventArgs e)
        {
            if (chia_task_gui_control != null)
            {
                ListViewItem temp;
                int spend_time;
                lock (Global.list_lock)
                {
                    temp = new ListViewItem(chia_task_gui_control.task_list[e.ItemIndex].id.ToString());
                    temp.SubItems.Add(chia_task_gui_control.task_list[e.ItemIndex].start_time);
                    temp.SubItems.Add(chia_task_gui_control.task_list[e.ItemIndex].t);
                    temp.SubItems.Add(chia_task_gui_control.task_list[e.ItemIndex].d);
                    temp.SubItems.Add((chia_task_gui_control.task_list[e.ItemIndex].plotter_progress).ToString() + "%");
                    temp.SubItems.Add(chia_task_gui_control.task_list[e.ItemIndex].status);
                    spend_time = chia_task_gui_control.task_list[e.ItemIndex].run_time;
                }

                int h = (spend_time - (spend_time % 3600)) / 3600;//小时
                int m = spend_time % 3600/60;//分钟
                int s = spend_time % 60; //秒
                string spend_time_str = h.ToString() + "小时" + m.ToString() + "分钟" + s.ToString() + "秒";
                temp.SubItems.Add(spend_time_str);
                e.Item = temp;
            }



        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {

            if (MessageBox.Show("确定要关闭程序吗，关闭后所有任务将消失，包括官方客户端的p图任务","提示", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                save_adn_exit();
            }
            else
            {
                e.Cancel = true;
            }





        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            listView1.Refresh();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            new LogBox().ShowDialog();

        }

        private void listView1_Click(object sender, EventArgs e)
        {
            
        }

        private void listView1_ItemActivate(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void listView1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
        }

        private void listView1_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {

        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            var logform = new LogBox();
            logform.textBox1.Text = chia_task_gui_control.task_list[listView1.SelectedIndices[0]].rawlogs;
            logform.ShowDialog();
            
        }

        private void label10_Click_1(object sender, EventArgs e)
        {

        }

        private void textBox_public_fingerprint_TextChanged(object sender, EventArgs e)
        {

        }








        private void checkBox_start_before_CheckedChanged(object sender, EventArgs e)
        {
            Global.start_befor_end = checkBox_start_before_end.Checked;
            if (!Global.can_remote_control)
            {
                MessageBox.Show("在此模式下，新任务将在（旧任务最终把p好的文件移动至机械硬盘这个阶段）提前启动，需要您的缓存盘有足够的剩余空间,启动延迟不能太低！\r\n否则新任务的文件可能会在旧任务的文件还未转移至机械盘的情况下占满空间而导致新任务出错！");
            }
        }

        private void button_stop_select_task_Click(object sender, EventArgs e)
        {
            var selected = listView1.SelectedIndices;
            if (selected.Count > 0)
            {
                chia_task_gui_control.task_list[selected[0]].self_kill("手动中止");
            }
        }

        private void save_adn_exit()
        {
            var ini = new IniFile();
            ini.writeIni("max_ram", textBox_max_ram.Text);
            ini.writeIni("save_disk", textBox_save_disk.Text);
            ini.writeIni("single_thread", textBox_single_thread.Text);
            ini.writeIni("start_interval", textBox_start_interval.Text);
            ini.writeIni("tasks", textBox_tasks.Text);
            ini.writeIni("temp_disk", textBox_temp_disk.Text);
            ini.writeIni("ppk", textBox_ppk.Text);
            ini.writeIni("fpk", textBox_fpk.Text);
            ini.writeIni("time_out",textBox_time_out.Text);
            ini.writeIni("plot_size", textBox_plot_size.Text);
            ini.writeIni("chia_root_path", Global.chia_root_path);
            ini.writeIni("client_name", textBox_name.Text);
            ini.writeIni("password", textBox_password.Text);


            if (checkBox_start_before_end.Checked)
            {
                ini.writeIni("start_before_end", "true");
            }
            else
            {
                ini.writeIni("start_before_end", "false");
            }
            if (checkBox_can_remote_control.Checked)
            {
                ini.writeIni("remote_control", "true");
            }
            else
            {
                ini.writeIni("remote_control", "false");
            }


            //结束所有任务
            if (chia_task_gui_control != null)
            {
                foreach (ChiaCmd plot_task in chia_task_gui_control.task_list)
                {
                    plot_task.self_kill("程序结束");

                }
            }









            Tool.RunCmd("taskkill -f -im chia*");
            Tool.RunCmd("taskkill -f -im start_full_node*");
            Tool.RunCmd("taskkill -f -im start_wallet*");
            Tool.RunCmd("taskkill -f -im start_farmer*");
            Thread.Sleep(5000);
            Process.GetCurrentProcess().Kill();
        }

        private void button_stop_add_new_task_Click(object sender, EventArgs e)
        {
            if (!Global.can_remote_control)
            {
                if (MessageBox.Show("此操作会停止添加后续任务，您确定吗？", "提示", MessageBoxButtons.OKCancel) != DialogResult.OK)
                {
                    return;
                }
            }

            if (chia_task_gui_control == null)
            {

                chia_task_gui_control.gui_log("此功能仅在自动p图开始后可以使用!");
            }
            else
            {
                try
                {
                    chia_task_gui_control.control_thread.Abort();
                    chia_task_gui_control.gui_log("停止添加后续任务");
                    button_stop_add_new_task.Enabled = false;
                    button_update_args.Enabled = false;
                    button_start.Enabled = true;

                }
                catch(Exception err)
                {
                    chia_task_gui_control.gui_log("停止添加后续任务失败，可能任务已经执行完毕");
                }
                
            }
        }

        private void button_update_args_Click(object sender, EventArgs e)
        {
            if (chia_task_gui_control == null)
            {
                MessageBox.Show("此功能仅在自动p图开始后方便更新参数!");
            }
            else
            {
                if (MessageBox.Show("此操作会更新任务的参数，您确定吗？", "提示", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    chia_task_gui_control.start(true);
                }
            }
        }

        private void checkBox_can_remote_control_CheckedChanged(object sender, EventArgs e)
        {
            Global.client_name = textBox_name.Text;
            
            if (Global.http_service == null)
            {
                Global.http_service = new HttpService();
                Global.http_service.chia_task_gui_control = chia_task_gui_control;
            }
            Global.http_service.states_info.name = Global.client_name;
            Global.password = textBox_password.Text;

            Global.can_remote_control = checkBox_can_remote_control.Checked;
            if (Global.http_service.start()&& Global.can_remote_control)
            {
                textBox_log.AppendText(Tool.log("群控启动成功"));
            }
            else
            {
                textBox_log.AppendText(Tool.log("群控关闭成功"));
            }

        }

        private void button_init_Click(object sender, EventArgs e)
        {
            Tool.run_cmd(Global.chia_root_path + " init");

        }
    }
}
