using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using LayeredSkin.Forms;
using LayeredSkin.Controls;
using LayeredSkin.DirectUI;
using LayeredSkin.Animations;
using MaiinTimer.Controls;

namespace MaiinTimer
{
    public partial class MainForm : LayeredForm
    {
        Color defaultColor = Color.FromArgb(255, 92, 138);
        DuiLabel dlbnowTime = new DuiLabel();//当前时间
        Cursor defaultCursor = Cursors.Hand;
        CircularProgressBarEx cbr = new CircularProgressBarEx();
        Timer timer = new Timer();
        #region 窗体事件
        [DllImport("user32.dll", EntryPoint = "SendMessageA")]
        private static extern int SendMessage(int hwnd, int wMsg, int wParam, int lParam);

        [DllImport("user32.dll")]
        private static extern int ReleaseCapture();
        private const int WM_NCLBUTTONDOWN = 0XA1;   //.定义鼠標左鍵按下
        private const int HTCAPTION = 2;

        public MainForm()
        {
            InitializeComponent();
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            layeredPanel_top.BackColor = defaultColor;
            baseControl_main.BackColor = defaultColor;
            timer.Interval = 100;
            timer.Tick += Timer_Tick;
            timer.Enabled = true;
            addBaseControl();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (cbr.Value < 100)
            {
                cbr.Value++;
            }
            //else
            //{
            //    cbr.Value = 0;
            //}
        }
        #endregion

        #region 控件事件
        private void layeredButton1_Click(object sender, EventArgs e)
        {
            BackForm sForm = new BackForm();
            sForm.Show();
        }

        private void layeredPanel_top_MouseDown(object sender, MouseEventArgs e)
        {
            //为当前的应用程序释放鼠标捕获
            ReleaseCapture();
            //发送消息﹐让系統误以为在标题栏上按下鼠标
            SendMessage((int)this.Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
        }

        private void btn_min_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_skin_MouseHover(object sender, EventArgs e)
        {
            LayeredButton thisButton = sender as LayeredButton;
            switch (thisButton.Name)
            {
                case "btn_skin":
                    layeredPanel_skin.BackColor = Color.FromArgb(100, 234, 234, 234);
                    break;
                case "btn_min":
                    layeredPanel_min.BackColor = Color.FromArgb(100, 234, 234, 234);
                    break;
                default:
                    layeredPanel_close.BackColor = Color.FromArgb(255, 88, 88);
                    break;
            }

        }

        private void btn_skin_MouseLeave(object sender, EventArgs e)
        {
            LayeredButton thisButton = sender as LayeredButton;
            thisButton.BackColor = Color.Transparent;
            layeredPanel_min.BackColor = thisButton.BackColor;
            layeredPanel_close.BackColor = thisButton.BackColor;
            layeredPanel_skin.BackColor = thisButton.BackColor;
        }

        private void btn_skin_MouseDown(object sender, MouseEventArgs e)
        {
            LayeredButton thisButton = sender as LayeredButton;
            thisButton.BackColor = Color.FromArgb(255, 92, 125);
        }
        /// <summary>
        /// CheckBox选择事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Dcb_CheckedChanged(object sender, EventArgs e)
        {
            DuiCheckBox cb = sender as DuiCheckBox;
            if (cb != null)
            {
                if (cb.Text == "定点计划")
                {

                }
                else
                {

                }
            }
            
        }

        private void timer_time_Tick(object sender, EventArgs e)
        {
            dlbnowTime.Text = "当前时间：" + DateTime.Now.ToString("HH:mm:ss");
        }

        private void DbSet_MouseClick(object sender, DuiMouseEventArgs e)
        {
            DuiButton dbSet = sender as DuiButton;
            if (cbr.Value < 100)
            {
                cbr.Value++;
            }
            else
            {
                cbr.Value = 0;
            }
            //if (LayeredSkin.NativeMethods.AnimateWindow(dbSet.Handle, 300, LayeredSkin.WindowMessages.AW_BLEND | LayeredSkin.WindowMessages.AW_HIDE))
            //{
            //    LayeredSkin.NativeMethods.AnimateWindow(dbSet.Handle, 300, LayeredSkin.WindowMessages.AW_BLEND | LayeredSkin.WindowMessages.AW_ACTIVATE);
            //}
            //Utils.AnimationControl.ShowControl(dbSet,true, AnchorStyles.Bottom);
        }
        #endregion

        #region 自定义事件
        private void addBaseControl()
        {

            DuiLabel dlb = new DuiLabel();
            dlb.Text = "计时类型：";
            dlb.Font = new Font("微软雅黑", 9F, FontStyle.Regular);
            dlb.Size = new Size(20 * dlb.Text.Length,15);
            dlb.TextAlign = ContentAlignment.MiddleCenter;
            dlb.Location = new Point(55,8);

            DuiCheckBox dcb = new DuiCheckBox();
            dcb.Font = new Font("微软雅黑", 9F, FontStyle.Regular);
            dcb.Text = "定点计划";
            dcb.Cursor = defaultCursor;
            dcb.Size = new Size(20 * dcb.Text.Length,10);
            dcb.Location = new Point(20 * dlb.Text.Length + 40,5);
            dcb.CheckAlign = ContentAlignment.MiddleRight;
            dcb.CheckedChanged += Dcb_CheckedChanged;

            DuiCheckBox dcba = new DuiCheckBox();
            dcba.Font = new Font("微软雅黑", 9F, FontStyle.Regular);
            dcba.Text = "定时计划";
            dcba.Cursor = defaultCursor;
            dcba.Size = new Size(20 * dcb.Text.Length, 10);
            dcba.Location = new Point(20 * dlb.Text.Length + 20 * dcb.Text.Length + 40, 5);
            dcba.CheckAlign = ContentAlignment.MiddleRight;
            dcba.CheckedChanged += Dcb_CheckedChanged;

            ///nowTime
            dlbnowTime.Text = "当前时间："+DateTime.Now.ToString("HH:mm:ss");
            dlbnowTime.Font = new Font("微软雅黑", 13, FontStyle.Regular);
            dlbnowTime.Size = new Size(35 * dlb.Text.Length, 20);
            dlbnowTime.TextAlign = ContentAlignment.MiddleCenter;
            dlbnowTime.Location = new Point(25, 35);

            //定时信息
            DuiBaseControl dbTimerControl = new DuiBaseControl();
            dbTimerControl.Size = new Size(340,120);
            dbTimerControl.Location = new Point(50,36);

            DuiLabel dlblx = new DuiLabel();
            dlblx.Text = "当 ";
            dlblx.Font = new Font("微软雅黑", 13, FontStyle.Regular);
            dlblx.Size = new Size(35 * dlb.Text.Length, 20);
            dlblx.TextAlign = ContentAlignment.MiddleCenter;
            dlblx.Location = new Point(25, 35);

            DuiButton dbSet = new DuiButton();
            dbSet.Size = new Size(100, 25);
            dbSet.Radius = 20;
            dbSet.Name = "setTime";
            dbSet.Text = "设置定时";
            dbSet.Location = new Point(50,35);
            dbSet.AdaptImage = false;
            dbSet.NormalImage = Properties.Resources.my_new_login_btn;
            dbSet.MouseClick += DbSet_MouseClick;
            dbSet.MouseMove += DbSet_MouseMove;
            dbSet.MouseLeave += DbSet_MouseLeave;

            DuiButton dbSeting = new DuiButton();
            dbSeting.Size = new Size(40, 40);
            dbSeting.Radius = 40;
            dbSeting.Name = "dbSeting";
            dbSeting.Text = "";
            dbSeting.Location = new Point(200, 20);
            dbSeting.AdaptImage = false;
            dbSeting.BaseColor = Color.FromArgb(10,0,0,0);
            dbSeting.IsPureColor = false;
            dbSeting.BackgroundImage = Properties.Resources.download;
            dbSeting.BackgroundImageLayout = ImageLayout.Center;

            Borders baseBorder = new Borders(dbSet);
            baseBorder.BottomWidth = 2;
            baseBorder.TopWidth = 2;
            baseBorder.LeftWidth = 2;
            baseBorder.RightWidth = 2;
            baseBorder.LeftColor = Color.White;
            baseBorder.RightColor = Color.White;
            baseBorder.TopColor = Color.White;
            baseBorder.BottomColor = Color.White;

            //dbSeting.Borders = baseBorder;
            //dbSeting.BorderPath.AddArc(new RectangleF(0, 0, 40, 40),0, 360);
            DuiBaseControl dbtest = new DuiBaseControl();
            dbtest.Name = "Test_DuiBaseControl";
            dbtest.Size = new Size(150, 30);
            dbtest.Location = new Point(150, 80);
            dbtest.BackColor = Color.White;
            

            DuiLabel dllod = new DuiLabel();
            dllod.Text = "正在加载中";
            dllod.Location = new Point(10, 5);
            dllod.Size = new Size(130, 20);
            dllod.TextAlign = ContentAlignment.MiddleCenter;

            dbtest.Controls.Add(dllod);
            //添加进度条
            cbr.Size = new Size(120, 150);
            cbr.Value = 35;
            cbr.BackColor = Color.Transparent;
            cbr.DoingText = "进度条";
            cbr.CompleteText = "已完成";
            cbr.Color = Color.HotPink;
            cbr.Location = new Point(10,98);

            dbTimerControl.Controls.AddRange(new DuiBaseControl[] { dlblx, dbSet, dbSeting,dbtest });
            baseControl_main.DUIControls.AddRange(new DuiBaseControl[] { dlb, dcb, dcba, dlbnowTime,dbTimerControl, cbr });
        }

        private void DbSet_MouseLeave(object sender, EventArgs e)
        {
            DuiButton db = sender as DuiButton;
            DuiBaseControl pd = db.Parent as DuiBaseControl;
            foreach (var item in pd.FindControl("Test_DuiBaseControl"))
            {
                if (item is DuiBaseControl)
                {
                    DuiBaseControl ds = item as DuiBaseControl;
                    //Utils.AnimationDuiBaseControl.ShowControl(ds, false, AnchorStyles.Bottom);
                }
            }
            this.Refresh();
        }

        private void DbSet_MouseMove(object sender, DuiMouseEventArgs e)
        {
            DuiButton db = sender as DuiButton;
            DuiBaseControl pd = db.Parent as DuiBaseControl;
            foreach (var item in pd.FindControl("Test_DuiBaseControl"))
            {
                if (item is DuiBaseControl)
                {
                    DuiBaseControl ds = item as DuiBaseControl;
                    //Utils.AnimationDuiBaseControl.ShowControl(ds, true, AnchorStyles.Bottom);
                }
            }
            this.Refresh();
        }

        #endregion

    }
}
