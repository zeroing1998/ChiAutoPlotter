
namespace ChiAutoPlotter
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button_update_args = new System.Windows.Forms.Button();
            this.button_stop_add_new_task = new System.Windows.Forms.Button();
            this.button_stop = new System.Windows.Forms.Button();
            this.button_start = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.a = new System.Windows.Forms.TabPage();
            this.textBox_log = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label10 = new System.Windows.Forms.Label();
            this.button_stop_select_task = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label19 = new System.Windows.Forms.Label();
            this.checkBox_can_remote_control = new System.Windows.Forms.CheckBox();
            this.textBox_password = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.textBox_name = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.textBox_start_interval = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox_tasks = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox_single_thread = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_save_disk = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_temp_disk = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.textBox_ppk = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.textBox_fpk = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.label18 = new System.Windows.Forms.Label();
            this.textBox_max_ram = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.textBox_plot_size = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox_time_out = new System.Windows.Forms.TextBox();
            this.checkBox_start_before_end = new System.Windows.Forms.CheckBox();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label12 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.button_init = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.a.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button_update_args);
            this.groupBox2.Controls.Add(this.button_stop_add_new_task);
            this.groupBox2.Controls.Add(this.button_stop);
            this.groupBox2.Controls.Add(this.button_start);
            this.groupBox2.Location = new System.Drawing.Point(8, 11);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(210, 86);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "控制";
            // 
            // button_update_args
            // 
            this.button_update_args.Enabled = false;
            this.button_update_args.Location = new System.Drawing.Point(108, 47);
            this.button_update_args.Name = "button_update_args";
            this.button_update_args.Size = new System.Drawing.Size(90, 23);
            this.button_update_args.TabIndex = 11;
            this.button_update_args.Text = "更新参数";
            this.button_update_args.UseVisualStyleBackColor = true;
            this.button_update_args.Click += new System.EventHandler(this.button_update_args_Click);
            // 
            // button_stop_add_new_task
            // 
            this.button_stop_add_new_task.Enabled = false;
            this.button_stop_add_new_task.Location = new System.Drawing.Point(14, 47);
            this.button_stop_add_new_task.Name = "button_stop_add_new_task";
            this.button_stop_add_new_task.Size = new System.Drawing.Size(88, 23);
            this.button_stop_add_new_task.TabIndex = 11;
            this.button_stop_add_new_task.Text = "不追加新任务";
            this.button_stop_add_new_task.UseVisualStyleBackColor = true;
            this.button_stop_add_new_task.Click += new System.EventHandler(this.button_stop_add_new_task_Click);
            // 
            // button_stop
            // 
            this.button_stop.Enabled = false;
            this.button_stop.Location = new System.Drawing.Point(108, 18);
            this.button_stop.Name = "button_stop";
            this.button_stop.Size = new System.Drawing.Size(90, 23);
            this.button_stop.TabIndex = 0;
            this.button_stop.Text = "停止全部";
            this.button_stop.UseVisualStyleBackColor = true;
            this.button_stop.Click += new System.EventHandler(this.button_stop_Click);
            // 
            // button_start
            // 
            this.button_start.Location = new System.Drawing.Point(14, 18);
            this.button_start.Name = "button_start";
            this.button_start.Size = new System.Drawing.Size(88, 23);
            this.button_start.TabIndex = 0;
            this.button_start.Text = "开始";
            this.button_start.UseVisualStyleBackColor = true;
            this.button_start.Click += new System.EventHandler(this.button_start_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.a);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(220, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(605, 379);
            this.tabControl1.TabIndex = 10;
            // 
            // a
            // 
            this.a.Controls.Add(this.textBox_log);
            this.a.Location = new System.Drawing.Point(4, 22);
            this.a.Name = "a";
            this.a.Padding = new System.Windows.Forms.Padding(3);
            this.a.Size = new System.Drawing.Size(597, 353);
            this.a.TabIndex = 0;
            this.a.Text = "软件日志";
            this.a.UseVisualStyleBackColor = true;
            // 
            // textBox_log
            // 
            this.textBox_log.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_log.BackColor = System.Drawing.Color.Black;
            this.textBox_log.ForeColor = System.Drawing.Color.Lime;
            this.textBox_log.Location = new System.Drawing.Point(6, 6);
            this.textBox_log.Multiline = true;
            this.textBox_log.Name = "textBox_log";
            this.textBox_log.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox_log.Size = new System.Drawing.Size(585, 344);
            this.textBox_log.TabIndex = 9;
            this.textBox_log.WordWrap = false;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label10);
            this.tabPage2.Controls.Add(this.button_stop_select_task);
            this.tabPage2.Controls.Add(this.listView1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(597, 353);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "任务日志";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(99, 329);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(125, 12);
            this.label10.TabIndex = 2;
            this.label10.Text = "双击任务可以查看错误";
            // 
            // button_stop_select_task
            // 
            this.button_stop_select_task.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button_stop_select_task.Location = new System.Drawing.Point(18, 324);
            this.button_stop_select_task.Name = "button_stop_select_task";
            this.button_stop_select_task.Size = new System.Drawing.Size(75, 23);
            this.button_stop_select_task.TabIndex = 1;
            this.button_stop_select_task.Text = "中止选中任务";
            this.button_stop_select_task.UseVisualStyleBackColor = true;
            this.button_stop_select_task.Click += new System.EventHandler(this.button_stop_select_task_Click);
            // 
            // listView1
            // 
            this.listView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listView1.CheckBoxes = true;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader7,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6});
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(18, 12);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(573, 306);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.VirtualMode = true;
            this.listView1.ItemActivate += new System.EventHandler(this.listView1_ItemActivate);
            this.listView1.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.listView1_ItemCheck);
            this.listView1.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.listView1_ItemSelectionChanged);
            this.listView1.RetrieveVirtualItem += new System.Windows.Forms.RetrieveVirtualItemEventHandler(this.listView1_RetrieveVirtualItem);
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            this.listView1.VirtualItemsSelectionRangeChanged += new System.Windows.Forms.ListViewVirtualItemsSelectionRangeChangedEventHandler(this.listView1_VirtualItemsSelectionRangeChanged);
            this.listView1.Click += new System.EventHandler(this.listView1_Click);
            this.listView1.DoubleClick += new System.EventHandler(this.listView1_DoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "序号";
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "开始时间";
            this.columnHeader7.Width = 120;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "缓存盘";
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "目标盘";
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "进度";
            this.columnHeader4.Width = 120;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "状态";
            this.columnHeader5.Width = 120;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "用时";
            this.columnHeader6.Width = 120;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.groupBox1);
            this.tabPage4.Controls.Add(this.textBox_start_interval);
            this.tabPage4.Controls.Add(this.label8);
            this.tabPage4.Controls.Add(this.label6);
            this.tabPage4.Controls.Add(this.textBox_tasks);
            this.tabPage4.Controls.Add(this.label5);
            this.tabPage4.Controls.Add(this.textBox_single_thread);
            this.tabPage4.Controls.Add(this.label4);
            this.tabPage4.Controls.Add(this.textBox_save_disk);
            this.tabPage4.Controls.Add(this.label2);
            this.tabPage4.Controls.Add(this.textBox_temp_disk);
            this.tabPage4.Controls.Add(this.label1);
            this.tabPage4.Controls.Add(this.groupBox4);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(597, 353);
            this.tabPage4.TabIndex = 4;
            this.tabPage4.Text = "常规设置";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label19);
            this.groupBox1.Controls.Add(this.checkBox_can_remote_control);
            this.groupBox1.Controls.Add(this.textBox_password);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.textBox_name);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Location = new System.Drawing.Point(217, 11);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(369, 103);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "内网群控";
            // 
            // label19
            // 
            this.label19.Location = new System.Drawing.Point(166, 19);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(197, 66);
            this.label19.TabIndex = 3;
            this.label19.Text = "请使用管理员模式启动程序，才可以正常使用群控\r\n修改密码或名称，请重新勾选开启群控才会生效\r\n群控端与p图端需要在同一个内网下！\r\n";
            // 
            // checkBox_can_remote_control
            // 
            this.checkBox_can_remote_control.AutoSize = true;
            this.checkBox_can_remote_control.Location = new System.Drawing.Point(84, 73);
            this.checkBox_can_remote_control.Name = "checkBox_can_remote_control";
            this.checkBox_can_remote_control.Size = new System.Drawing.Size(72, 16);
            this.checkBox_can_remote_control.TabIndex = 2;
            this.checkBox_can_remote_control.Text = "开启群控";
            this.checkBox_can_remote_control.UseVisualStyleBackColor = true;
            this.checkBox_can_remote_control.CheckedChanged += new System.EventHandler(this.checkBox_can_remote_control_CheckedChanged);
            // 
            // textBox_password
            // 
            this.textBox_password.Location = new System.Drawing.Point(63, 46);
            this.textBox_password.Name = "textBox_password";
            this.textBox_password.Size = new System.Drawing.Size(93, 21);
            this.textBox_password.TabIndex = 1;
            this.textBox_password.Text = "123456";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(6, 51);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(59, 12);
            this.label15.TabIndex = 0;
            this.label15.Text = "访问密码:";
            // 
            // textBox_name
            // 
            this.textBox_name.Location = new System.Drawing.Point(63, 19);
            this.textBox_name.Name = "textBox_name";
            this.textBox_name.Size = new System.Drawing.Size(93, 21);
            this.textBox_name.TabIndex = 1;
            this.textBox_name.Text = "未命名";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(6, 24);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(59, 12);
            this.label14.TabIndex = 0;
            this.label14.Text = "机器名称:";
            // 
            // textBox_start_interval
            // 
            this.textBox_start_interval.Location = new System.Drawing.Point(74, 90);
            this.textBox_start_interval.Name = "textBox_start_interval";
            this.textBox_start_interval.Size = new System.Drawing.Size(31, 21);
            this.textBox_start_interval.TabIndex = 15;
            this.textBox_start_interval.Text = "300";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(111, 94);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(17, 12);
            this.label8.TabIndex = 8;
            this.label8.Text = "秒";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 94);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 12);
            this.label6.TabIndex = 9;
            this.label6.Text = "启动延迟:";
            // 
            // textBox_tasks
            // 
            this.textBox_tasks.Location = new System.Drawing.Point(188, 90);
            this.textBox_tasks.Name = "textBox_tasks";
            this.textBox_tasks.Size = new System.Drawing.Size(23, 21);
            this.textBox_tasks.TabIndex = 16;
            this.textBox_tasks.Text = "4";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(135, 94);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 12);
            this.label5.TabIndex = 10;
            this.label5.Text = "并发数:";
            // 
            // textBox_single_thread
            // 
            this.textBox_single_thread.Location = new System.Drawing.Point(188, 63);
            this.textBox_single_thread.Name = "textBox_single_thread";
            this.textBox_single_thread.Size = new System.Drawing.Size(23, 21);
            this.textBox_single_thread.TabIndex = 17;
            this.textBox_single_thread.Text = "8";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(87, 66);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 12);
            this.label4.TabIndex = 11;
            this.label4.Text = "每个任务线程数:";
            // 
            // textBox_save_disk
            // 
            this.textBox_save_disk.Location = new System.Drawing.Point(62, 36);
            this.textBox_save_disk.Name = "textBox_save_disk";
            this.textBox_save_disk.Size = new System.Drawing.Size(149, 21);
            this.textBox_save_disk.TabIndex = 19;
            this.textBox_save_disk.Text = "F/G/H";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 12);
            this.label2.TabIndex = 14;
            this.label2.Text = "存储盘:";
            // 
            // textBox_temp_disk
            // 
            this.textBox_temp_disk.Location = new System.Drawing.Point(62, 7);
            this.textBox_temp_disk.Name = "textBox_temp_disk";
            this.textBox_temp_disk.Size = new System.Drawing.Size(149, 21);
            this.textBox_temp_disk.TabIndex = 7;
            this.textBox_temp_disk.Text = "D/E/F";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 12);
            this.label1.TabIndex = 6;
            this.label1.Text = "缓存盘:";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.textBox_ppk);
            this.groupBox4.Controls.Add(this.label17);
            this.groupBox4.Controls.Add(this.textBox_fpk);
            this.groupBox4.Controls.Add(this.label16);
            this.groupBox4.Location = new System.Drawing.Point(3, 120);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(583, 135);
            this.groupBox4.TabIndex = 5;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "p图公钥设置";
            // 
            // textBox_ppk
            // 
            this.textBox_ppk.Location = new System.Drawing.Point(6, 98);
            this.textBox_ppk.Multiline = true;
            this.textBox_ppk.Name = "textBox_ppk";
            this.textBox_ppk.Size = new System.Drawing.Size(568, 28);
            this.textBox_ppk.TabIndex = 6;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(6, 80);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(269, 12);
            this.label17.TabIndex = 5;
            this.label17.Text = "合作社合约地址(pool_contract_address)NFT地址";
            // 
            // textBox_fpk
            // 
            this.textBox_fpk.Location = new System.Drawing.Point(6, 40);
            this.textBox_fpk.Multiline = true;
            this.textBox_fpk.Name = "textBox_fpk";
            this.textBox_fpk.Size = new System.Drawing.Size(568, 31);
            this.textBox_fpk.TabIndex = 6;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(6, 17);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(167, 12);
            this.label16.TabIndex = 5;
            this.label16.Text = "农民公钥(Farmer public key)";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.label18);
            this.tabPage3.Controls.Add(this.textBox_max_ram);
            this.tabPage3.Controls.Add(this.label7);
            this.tabPage3.Controls.Add(this.label3);
            this.tabPage3.Controls.Add(this.label13);
            this.tabPage3.Controls.Add(this.textBox_plot_size);
            this.tabPage3.Controls.Add(this.label11);
            this.tabPage3.Controls.Add(this.label9);
            this.tabPage3.Controls.Add(this.textBox_time_out);
            this.tabPage3.Controls.Add(this.checkBox_start_before_end);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(597, 353);
            this.tabPage3.TabIndex = 3;
            this.tabPage3.Text = "高级设置";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(139, 188);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(329, 12);
            this.label18.TabIndex = 22;
            this.label18.Text = "看起来很复杂是吧？这个页面的参数，默认就好，不要修改！";
            // 
            // textBox_max_ram
            // 
            this.textBox_max_ram.Location = new System.Drawing.Point(71, 77);
            this.textBox_max_ram.Name = "textBox_max_ram";
            this.textBox_max_ram.Size = new System.Drawing.Size(31, 21);
            this.textBox_max_ram.TabIndex = 21;
            this.textBox_max_ram.Text = "4000";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(108, 81);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(239, 12);
            this.label7.TabIndex = 19;
            this.label7.Text = "MB 如果不是魔改桶大小，请不要修改此参数";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 12);
            this.label3.TabIndex = 20;
            this.label3.Text = "最大内存:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(139, 60);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(305, 12);
            this.label13.TabIndex = 11;
            this.label13.Text = "此值不要随意修改，修改此选项会导致硬件资源要求翻倍";
            // 
            // textBox_plot_size
            // 
            this.textBox_plot_size.Location = new System.Drawing.Point(109, 55);
            this.textBox_plot_size.Name = "textBox_plot_size";
            this.textBox_plot_size.Size = new System.Drawing.Size(24, 21);
            this.textBox_plot_size.TabIndex = 10;
            this.textBox_plot_size.Text = "32";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(8, 59);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(95, 12);
            this.label11.TabIndex = 9;
            this.label11.Text = "plot文件大小,K=";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(37, 37);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(209, 12);
            this.label9.TabIndex = 8;
            this.label9.Text = "小时后，任务没有完成，则自动中止！";
            // 
            // textBox_time_out
            // 
            this.textBox_time_out.Location = new System.Drawing.Point(8, 33);
            this.textBox_time_out.Name = "textBox_time_out";
            this.textBox_time_out.Size = new System.Drawing.Size(23, 21);
            this.textBox_time_out.TabIndex = 7;
            this.textBox_time_out.Text = "16";
            // 
            // checkBox_start_before_end
            // 
            this.checkBox_start_before_end.AutoSize = true;
            this.checkBox_start_before_end.Location = new System.Drawing.Point(8, 11);
            this.checkBox_start_before_end.Name = "checkBox_start_before_end";
            this.checkBox_start_before_end.Size = new System.Drawing.Size(414, 16);
            this.checkBox_start_before_end.TabIndex = 5;
            this.checkBox_start_before_end.Text = "加速优化1(新任务在旧任务完成前，提前启动)，需要有多余的缓存盘空间";
            this.checkBox_start_before_end.UseVisualStyleBackColor = true;
            this.checkBox_start_before_end.CheckedChanged += new System.EventHandler(this.checkBox_start_before_CheckedChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label12);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(597, 353);
            this.tabPage1.TabIndex = 2;
            this.tabPage1.Text = "帮助";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label12.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label12.Location = new System.Drawing.Point(6, 7);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(585, 164);
            this.label12.TabIndex = 0;
            this.label12.Text = "双击任务查看日志,\r\n公共指纹是打开钱包显示的一串数字\r\n多个缓存盘格式:D/E/F/G。单个缓存盘只填盘符，不要填:\\\r\n多个存储盘格式:D/E/F/G。单个缓" +
    "存盘只填盘符，不要填:\\\r\n按钮“不追加新任务”，不在添加新的任务，方便当前任务完成后维护机器\r\n";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // button_init
            // 
            this.button_init.ForeColor = System.Drawing.Color.Red;
            this.button_init.Location = new System.Drawing.Point(31, 335);
            this.button_init.Name = "button_init";
            this.button_init.Size = new System.Drawing.Size(152, 37);
            this.button_init.TabIndex = 12;
            this.button_init.Text = "第一次部署程序时点击此按钮，初始化chia核心";
            this.button_init.UseVisualStyleBackColor = true;
            this.button_init.Click += new System.EventHandler(this.button_init_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(837, 403);
            this.Controls.Add(this.button_init);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.groupBox2);
            this.Name = "Form1";
            this.Text = "Chia自动P盘软件 0.8.1  官方QQ群1035703112";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox2.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.a.ResumeLayout(false);
            this.a.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage a;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        public System.Windows.Forms.TextBox textBox_log;
        public System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button button_stop_select_task;
        private System.Windows.Forms.Label label9;
        public System.Windows.Forms.TextBox textBox_time_out;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label13;
        public System.Windows.Forms.TextBox textBox_plot_size;
        public System.Windows.Forms.Button button_start;
        public System.Windows.Forms.Button button_stop;
        public System.Windows.Forms.Button button_stop_add_new_task;
        public System.Windows.Forms.Button button_update_args;
        public System.Windows.Forms.CheckBox checkBox_start_before_end;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.Button button_init;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox checkBox_can_remote_control;
        private System.Windows.Forms.TextBox textBox_password;
        private System.Windows.Forms.Label label15;
        public System.Windows.Forms.TextBox textBox_name;
        private System.Windows.Forms.Label label14;
        public System.Windows.Forms.TextBox textBox_start_interval;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.TextBox textBox_tasks;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.TextBox textBox_single_thread;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.TextBox textBox_save_disk;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox textBox_temp_disk;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox4;
        public System.Windows.Forms.TextBox textBox_ppk;
        private System.Windows.Forms.Label label17;
        public System.Windows.Forms.TextBox textBox_fpk;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label18;
        public System.Windows.Forms.TextBox textBox_max_ram;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label19;
    }
}

