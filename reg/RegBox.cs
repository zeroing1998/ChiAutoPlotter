using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
namespace ChiAutoPlotter.reg
{
    public partial class RegBox : Form
    {
        public RegBox()
        {
            InitializeComponent();
        }

        private void RegBox_Load(object sender, EventArgs e)
        {
            textBox1.Text = Reg.get_m_code();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            File.WriteAllText("reg.key",textBox2.Text);
            MessageBox.Show("请重新打开软件查看是否注册成功，如本框消失，便是注册成功了!");
            Process.GetCurrentProcess().Kill();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Process.GetCurrentProcess().Kill();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Clipboard.SetDataObject(textBox1.Text);
            MessageBox.Show("复制成功，请把机器码发送给群主!");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            IDataObject iData = Clipboard.GetDataObject();
            textBox2.Text = (String)iData.GetData(DataFormats.Text);
        }
    }
}
