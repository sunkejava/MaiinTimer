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
            //加载需要的dll文件
            Utils.LoadResourceDll.RegistDLL();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new BackForm());
        }
    }
}
