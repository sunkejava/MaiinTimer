using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace BridImage
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            bool createNew;
            using (System.Threading.Mutex m = new System.Threading.Mutex(true, Application.ProductName, out createNew))
            {
                if (createNew)
                {
                    //加载需要的dll文件
                    Utils.LoadResourceDll.RegistDLL();
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new BackForm());
                }
                else
                {
                    string messageStr ="小鸟壁纸已运行，不能多次启用！";
                    MessageForm mf = new MessageForm(messageStr);
                    mf.Show();
                }
            }
        }
    }
}
