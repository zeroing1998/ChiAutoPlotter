using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
namespace ChiAutoPlotter
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {


            reg();

        }
        static void reg()
        {
            var aa = 49489;
            var cc = 544784;
            var qq = aa + cc;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            try
            {
                if (556 + 4848 == 5404 && qq == aa + cc && File.ReadAllText("reg.key") == ChiAutoPlotter.reg.Reg.get_reg(ChiAutoPlotter.reg.Reg.get_m_code()) && qq - aa == cc)
                {
                    var a = 1;
                    var b = 2;
                    var c = 3;
                    Application.Run(new Form1());
                }
                else
                {
                    new ChiAutoPlotter.reg.RegBox().ShowDialog();
                    Process.GetCurrentProcess().Kill();

                }
            }
            catch (Exception e)
            {
                new ChiAutoPlotter.reg.RegBox().ShowDialog();
                Process.GetCurrentProcess().Kill();

            }
        }
    }
}
