using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using LayeredSkin.DirectUI;
using LayeredSkin.Forms;
using MaiinTimer.Controls;
using MaiinTimer.Utils;

namespace MaiinTimer
{
    public partial class BackForm : LayeredForm
    {
        #region 模拟窗体移动变量
        [DllImport("user32.dll", EntryPoint = "SendMessageA")]
        private static extern int SendMessage(int hwnd, int wMsg, int wParam, int lParam);

        [DllImport("user32.dll")]
        private static extern int ReleaseCapture();
        private const int WM_NCLBUTTONDOWN = 0XA1;   //.定义鼠標左鍵按下
        private const int HTCAPTION = 2;
        #endregion

        /// <summary>
        /// 滚轮用参数
        /// </summary>
        private bool scorlling = false;
        private int mousetop = 0;
        BridImg bimg = new BridImg();

        #region 窗体控件事件
        public BackForm()
        {
            InitializeComponent();
        }

        private void BackForm_Load(object sender, EventArgs e)
        {
            layeredPanel_top.BackColor = Color.FromArgb(255, 92, 138);
            addBackImg();
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_min_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        #endregion

        #region 自定义事件
        private Boolean addBackImg()
        {
            var result = new Utils.Response<BridImg.ImageJson>();
            var rType = new Utils.Response<BridImg.ImgJson>();
            try
            {
                rType.Result = bimg.getImageType();
                //添加分类控件
                List_Main.addImgType(rType.Result);
                //添加详细信息
                List<BridImg.ImageInfo> imgInfos = new List<BridImg.ImageInfo>();
                result.Result = bimg.getNewImageInfos("0", "50");
                for (int i = 0; i < result.Result.data.Count; i++)
                {
                    int zi = i + 1;
                    imgInfos.Add(result.Result.data[i]);
                    if (zi % 3 == 0)
                    {
                        List_Main.addImgList(imgInfos);
                        imgInfos.Clear();
                    }
                }
            }
            catch (Exception ex)
            {
                result.Code = 500;
                result.Message = ex.Message;
                throw;
            }
            return true;
        }

        #endregion

        #region 滚动条事件
        private void layeredPanel_top_MouseDown(object sender, MouseEventArgs e)
        {
            //为当前的应用程序释放鼠标捕获
            ReleaseCapture();
            //发送消息﹐让系統误以为在标题栏上按下鼠标
            SendMessage((int)this.Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
        }

        private void scorllbar_Move(object sender, EventArgs e)
        {
            if (scorlling)
            {
                List_Main.Value = (double)(scorllbar.Top - List_Main.Top) / (double)(List_Main.Height - scorllbar.Height);
            }
        }

        private void scorllbar_MouseDown(object sender, MouseEventArgs e)
        {
            mousetop = scorllbar.PointToClient(MousePosition).Y;
            scorlling = true;
            scorllbar.BackColor = Color.FromArgb(80, 55, 55, 55);
        }

        private void scorllbar_MouseEnter(object sender, EventArgs e)
        {
            if (scorllbar.Top < List_Main.Top)
                scorllbar.Top = List_Main.Top + 2;
            if (scorllbar.Top > (List_Main.Top + List_Main.Height - scorllbar.Height))
                scorllbar.Top = (List_Main.Top + List_Main.Height - scorllbar.Height);
            scorllbar.BackColor = Color.FromArgb(100, 55, 55, 55);
        }

        private void scorllbar_MouseLeave(object sender, EventArgs e)
        {
            scorllbar.BackColor = Color.FromArgb(100, 205, 205, 205);
        }

        private void scorllbar_MouseMove(object sender, MouseEventArgs e)
        {
            if (scorlling)
            {
                if (scorllbar.Top >= List_Main.Top && scorllbar.Top <= (List_Main.Top + List_Main.Height - scorllbar.Height))
                    scorllbar.Top = PointToClient(MousePosition).Y - mousetop;
            }
        }

        private void scorllbar_MouseUp(object sender, MouseEventArgs e)
        {
            mousetop = e.Y; scorlling = false;
            scorllbar.BackColor = Color.FromArgb(100, 205, 205, 205);
        }

        private void List_Main_RefreshListed(object sender, EventArgs e)
        {
            int allheight = 0;
            for (int i = 0; i < List_Main.Items.Count; i++)
            {
                if (List_Main.Items[i].Visible)
                    allheight = allheight + List_Main.Items[i].Height;
            }
            double pre = (double)List_Main.Height / (double)allheight;
            if (pre < 1)
            {
                if (List_Main.Visible)
                    scorllbar.Show();

                scorllbar.Height = (int)(pre * (double)List_Main.Height);
                scorllbar.Top = (int)(List_Main.Value * (List_Main.Height - scorllbar.Height)) + List_Main.Top;
            }
            else
            {
                scorllbar.Hide();
            }
        }
        #endregion

    }
}
