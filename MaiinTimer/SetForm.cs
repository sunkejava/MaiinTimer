using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LayeredSkin.Forms;
using LayeredSkin.Controls;
using LayeredSkin.DirectUI;
using BridImage.Utils;
using System.IO;
using System.Diagnostics;

namespace BridImage
{
    public partial class SetForm : LayeredForm
    {
        BackForm pes = null;
        #region 设置相关控件
        //常规控件
        DuiCheckBox Ck_AutoStart = null;
        DuiRadioButton RadioButton_CloseMode = null;
        //切换壁纸控件
        DuiCheckBox Ck_IsSwitchWallpaper = null;
        DuiTextBox TextBox_InterValTime = null;
        DuiComboBox ComboBox_InterValTimeUnit = null;
        //DuiButton Button_SwitchWallpaperType = null;
        //下载设置控件
        DuiRadioButton RadioButton_picSize = null;
        DuiTextBox lb_downloadPath = null;
        DuiButton btn_selectDownloadPath = null;
        DuiTextBox lb_cachePath = null;
        DuiButton btn_selectCachePath = null;
        DuiLabel lb_nowCacheSize = null;
        DuiLabel lb_clearCache = null;
        //关于控件
        DuiLabel lb_ver = null;
        DuiButton btn_update = null;
        DuiButton btn_sendyj = null;
        DuiLabel lb_mxnr1 = null;
        DuiLabel lb_mxnr2 = null;
        DuiLabel lb_zzemail = null;
        public Image BackImg = null;
        #endregion
        public SetForm(BackForm cps)
        {
            pes = cps;
            InitializeComponent();
            setDefaultStyle();
        }
        #region 控件事件
        private void btn_cg_Click(object sender, EventArgs e)
        {
            if (sender is LayeredLabel)
            {
                LayeredLabel lb = sender as LayeredLabel;
                recoverDefaultStyle(lb);
                lb.ForeColor = Color.FromArgb(155,pes.BackColor);
                switch (lb.Name)
                {
                    case "btn_cg":
                        btn_point.Location = new Point(btn_point.Location.X, btn_cg.Location.Y + 6);
                        layeredPanel_cg.Visible = true;
                        layeredPanel_cg.BringToFront();
                        break;
                    case "btn_xzsz":
                        btn_point.Location = new Point(btn_point.Location.X, btn_xzsz.Location.Y + 6);
                        layeredPanel_xzsz.Visible = true;
                        layeredPanel_xzsz.BringToFront();
                        break;
                    case "btn_qhbz":
                        btn_point.Location = new Point(btn_point.Location.X, btn_qhbz.Location.Y + 6);
                        layeredPanel_qhbz.Visible = true;
                        layeredPanel_qhbz.BringToFront();
                        break;
                    case "btn_gy":
                        btn_point.Location = new Point(btn_point.Location.X, btn_gy.Location.Y + 6);
                        layeredPanel_gy.Visible = true;
                        layeredPanel_gy.BringToFront();
                        break;
                    case "":
                        break;
                }
            }
            this.Refresh();
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            saveConfig();
            this.Close();
        }

        private void layeredPanel_close_MouseEnter(object sender, EventArgs e)
        {
            layeredPanel_close.BackColor = Color.FromArgb(255, 88, 88);
        }

        private void layeredPanel_close_MouseLeave(object sender, EventArgs e)
        {
            layeredPanel_close.BackColor = Color.Transparent;
        }

        /// <summary>
        /// 关闭模式选择事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RadioButton_CloseMode_CheckedChanged(object sender, EventArgs e)
        {
            DuiRadioButton cdr = sender as DuiRadioButton;
            if (cdr.Name == "rd_min" && cdr.Checked)
            {
                pes.pes.CloseMode = "isMin";
            }
            else if (cdr.Name == "rd_close" && cdr.Checked)
            {
                pes.pes.CloseMode = "isClose";
            }
            else
            {

            }
        }
        /// <summary>
        /// 是否选择开机启动事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Ck_AutoStart_CheckedChanged(object sender, EventArgs e)
        {
            pes.pes.AutoStart = Ck_AutoStart.Checked;
        }

        /// <summary>
        /// 壁纸切换类型按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_SwitchWallpaperType_MouseClick(object sender, DuiMouseEventArgs e)
        {
            DuiButton cdb = sender as DuiButton;
            if (bool.Parse(cdb.Tag.ToString()))
            {
                cdb.BaseColor = Color.Transparent;
                cdb.BackgroundImage = Properties.Resources.btn_n;
                cdb.Tag = false.ToString();
                pes.pes.SwitchWallpaperTypes.Remove(cdb.Name.Replace("btn_", ""));
            }
            else
            {
                //cdb.BaseColor = pes.BackColor;
                if (pes.pes.SwitchWallpaperTypes.Contains(""))
                {
                    pes.pes.SwitchWallpaperTypes.Remove("");
                }
                cdb.BackgroundImage = Properties.Resources.btn_select_n;
                cdb.Tag = true.ToString();
                pes.pes.SwitchWallpaperTypes.Add(cdb.Name.Replace("btn_", ""));
            }
            cdb.BackgroundImageLayout = ImageLayout.Stretch;
        }

        /// <summary>
        /// 切换时间间隔变化事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBox_InterValTime_TextChanged(object sender, EventArgs e)
        {
            //if (!string.IsNullOrEmpty(TextBox_InterValTime.Text))
            //{
            //    int interVal = int.Parse(TextBox_InterValTime.Text);
            //    switch (ComboBox_InterValTimeUnit.SelectedIndex)
            //    {
            //        case 0:
            //            pes.pes.InterValTime = interVal;
            //            break;
            //        case 1:
            //            pes.pes.InterValTime = interVal * 60;
            //            break;
            //        default:
            //            pes.pes.InterValTime = interVal * 60 * 60;
            //            break;
            //    }
            //}
        }

        /// <summary>
        /// 自动切换壁纸启动设置事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Ck_IsSwitchWallpaper_CheckedChanged(object sender, EventArgs e)
        {
            pes.pes.IsSwitchWallpaper = Ck_IsSwitchWallpaper.Checked;
        }

        /// <summary>
        /// 壁纸切换时间间隔单位事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ComboBox_InterValTimeUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(TextBox_InterValTime.Text))
            {
                int interVal = int.Parse(TextBox_InterValTime.Text);
                if (ComboBox_InterValTimeUnit.SelectedIndex == 0)
                {
                    pes.pes.InterValTime = interVal;
                }
                else if (ComboBox_InterValTimeUnit.SelectedIndex == 1)
                {
                    pes.pes.InterValTime = interVal * 60;
                }
                else
                {
                    pes.pes.InterValTime = interVal * 60 * 60;
                }
            }    
        }

        /// <summary>
        /// 清理缓存事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Lb_clearCache_MouseClick(object sender, DuiMouseEventArgs e)
        {
            if (Directory.Exists(lb_cachePath.Text))
            {
                DelectDir(lb_cachePath.Text);
                string messageStr = "已成功清理"+lb_nowCacheSize.Text.Replace("当前缓存：", "")+"MB缓存文件！";
                MessageForm mf = new MessageForm(messageStr);
                mf.Show();
                lb_nowCacheSize.Text = "当前缓存：" + GetDirectoryLength(lb_cachePath.Text) / (1024 * 1024) + "MB";
            }
        }

        public static void DelectDir(string srcPath)
        {
            try
            {
                DirectoryInfo dir = new DirectoryInfo(srcPath);
                FileSystemInfo[] fileinfo = dir.GetFileSystemInfos();  //返回目录中所有文件和子目录
                foreach (FileSystemInfo i in fileinfo)
                {
                    if (i is DirectoryInfo)            //判断是否文件夹
                    {
                        DirectoryInfo subdir = new DirectoryInfo(i.FullName);
                        subdir.Delete(true);          //删除子目录和文件
                    }
                    else
                    {
                        File.Delete(i.FullName);      //删除指定文件
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception("清理文件失败，原因为："+e.Message);
            }
        }


        /// <summary>
        /// 选择下载目录事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_selectDownloadPath_MouseClick(object sender, DuiMouseEventArgs e)
        {
            try
            {
                System.Windows.Forms.FolderBrowserDialog dialog = new System.Windows.Forms.FolderBrowserDialog();
                dialog.Description = "请选择下载目录";
                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    DuiTextBox bctb = getThisBaseControl(layeredPanel_xzsz, "text_downloadPath") as DuiTextBox;
                    if (string.IsNullOrEmpty(dialog.SelectedPath))
                    {
                        lb_downloadPath.Text = "请选择缓存保存目录";
                    }
                    else
                    {
                        lb_downloadPath.Text = dialog.SelectedPath;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 选择缓存目录事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_selectCachePath_MouseClick(object sender, DuiMouseEventArgs e)
        {
            try
            {
                System.Windows.Forms.FolderBrowserDialog dialog = new System.Windows.Forms.FolderBrowserDialog();
                dialog.Description = "请选择缓存目录";
                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    DuiTextBox actb = getThisBaseControl(layeredPanel_xzsz, "text_cachePath") as DuiTextBox;
                    if (string.IsNullOrEmpty(dialog.SelectedPath))
                    {
                        actb.Text = "请选择缓存保存目录";
                    }
                    else
                    {
                        actb.Text = dialog.SelectedPath;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 选择图片分辨率事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RadioButton_picSize_CheckedChanged(object sender, EventArgs e)
        {
            DuiRadioButton cdr = sender as DuiRadioButton;
            if (cdr.Checked)
            {
                switch (cdr.Name)
                {
                    case "rd_SizeForThumb":
                        pes.pes.PicSize = "default";
                        break;
                    case "rd_SizeFor1600900":
                        pes.pes.PicSize = "1600900";
                        break;
                    case "rd_SizeFor1440900":
                        pes.pes.PicSize = "1440900";
                        break;
                    case "rd_SizeFor12801024":
                        pes.pes.PicSize = "12801024";
                        break;
                    case "rd_SizeFor1024768":
                        pes.pes.PicSize = "1024768";
                        break;
                    case "rd_SizeFor1280800":
                        pes.pes.PicSize = "1280800";
                        break;
                    default:
                        break;
                }

            }
        }

        /// <summary>
        /// 邮箱点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Lb_zzemail_MouseClick(object sender, DuiMouseEventArgs e)
        {
            string sEmailMSG = "mailto:" + "declineaberdeen@foxmail.com" + "?subject=小鸟壁纸邮箱链接&body=请输入联系来意！";
            System.Diagnostics.Process.Start(sEmailMSG);
        }
        /// <summary>
        /// 鸣谢内容点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Lb_mxnr1_MouseClick(object sender, DuiMouseEventArgs e)
        {
            DuiLabel cdl = sender as DuiLabel;
            string wsite = "";
            if (cdl.Name == "lb_mxnr2")
            {
                wsite = "http://www.52pojie.cn";
            }
            else
            {
                wsite = "http://bbs.cskin.net";
            }
            System.Diagnostics.Process.Start(wsite);
        }
        /// <summary>
        /// 发送意见
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_sendyj_MouseClick(object sender, DuiMouseEventArgs e)
        {
            SendYjForm yjF = new SendYjForm(pes);
            yjF.Show();
        }

        /// <summary>
        /// 更新按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_update_MouseClick(object sender, DuiMouseEventArgs e)
        {
            GetVersion gv = new GetVersion();
            Entity.VerEntity cv = gv.getVer();
            pes.pes.UpdateContent = cv.Content;
            pes.pes.DownloadUrl = cv.DownloadUrl;
            if (!lb_ver.Text.Equals(cv.Ver))
            {
                UpdateProperts upConfig = new UpdateProperts();
                upConfig.VerNo = cv.Ver;
                upConfig.BackColor = pes.pes.BackColor;
                upConfig.BackImg = pes.pes.BackImg;
                upConfig.DownloadUrl = cv.DownloadUrl;
                upConfig.UpdateContent = cv.Content;
                upConfig.MainApplicationName = System.IO.Path.GetFileName(Application.ExecutablePath).Replace(".exe","");
                upConfig.saveConfig();
                //调用更新窗体
                Process myProcess = new Process();
                myProcess.StartInfo.UseShellExecute = false;
                myProcess.StartInfo.FileName = AppDomain.CurrentDomain.BaseDirectory + @"\AppUpdate.exe";
                myProcess.StartInfo.CreateNoWindow = true;
                myProcess.Start();
                //关闭程序
                Dispose();
                Close();
                System.Environment.Exit(0);
            }
            else
            {
                //提示不需要更新
                string messageStr = lb_ver.Text + "已是最新版本，无需更新！";
                MessageForm mf = new MessageForm(messageStr);
                mf.Show();
            }
        }
        #endregion

        #region 自定义事件
        private void setDefaultStyle()
        {
            this.BackColor = Color.FromArgb(185, pes.pes.BackColor);
            if (pes.BackGroundSkin != null)
            {
                BackGroundSkin = pes.BackGroundSkin;
                this.BackColor = Color.Transparent;
            }
            btn_point.BaseColor = Color.Red;
            btn_cg.ForeColor = Color.FromArgb(255, pes.pes.BackColor);
            layeredPanel_cg.BringToFront();
            //常规界面相关处理
            foreach (DuiBaseControl item in layeredPanel_cg.DUIControls)
            {
                switch (item.Name)
                {
                    case "ck_qd":
                        Ck_AutoStart = item as DuiCheckBox;
                        Ck_AutoStart.CheckRectColor = Color.FromArgb(155, pes.pes.BackColor);
                        Ck_AutoStart.CheckFlagColor = Color.FromArgb(155, pes.pes.BackColor);
                        Ck_AutoStart.CheckedChanged += Ck_AutoStart_CheckedChanged;
                        Ck_AutoStart.Checked = pes.pes.AutoStart;
                        break;
                    case "rd_min":
                    case "rd_close":
                        RadioButton_CloseMode = item as DuiRadioButton;
                        RadioButton_CloseMode.CheckRectColor = Color.FromArgb(155, pes.pes.BackColor);
                        RadioButton_CloseMode.CheckFlagColor = Color.FromArgb(155, pes.pes.BackColor);
                        RadioButton_CloseMode.CheckedChanged += RadioButton_CloseMode_CheckedChanged;
                        if ((pes.pes.CloseMode == "isClose") && RadioButton_CloseMode.Name == "rd_close")
                        {
                            (item as DuiRadioButton).Checked = true;
                        }
                        else if ((pes.pes.CloseMode == "isMin") && RadioButton_CloseMode.Name == "rd_min")
                        {
                            (item as DuiRadioButton).Checked = true;
                        }
                        else
                        {
                            (item as DuiRadioButton).Checked = false;
                        }
                        break;
                    case "":

                        break;
                    default:
                        break;
                }
            }
            //壁纸切换界面相关处理
            foreach (DuiBaseControl item in layeredPanel_qhbz.DUIControls)
            {
                switch (item.Name)
                {
                    case "ck_qd":
                        Ck_IsSwitchWallpaper = item as DuiCheckBox;
                        Ck_IsSwitchWallpaper.CheckRectColor = Color.FromArgb(155, pes.pes.BackColor);
                        Ck_IsSwitchWallpaper.CheckFlagColor = Color.FromArgb(155, pes.pes.BackColor);
                        Ck_IsSwitchWallpaper.Checked = pes.pes.IsSwitchWallpaper;
                        Ck_IsSwitchWallpaper.CheckedChanged += Ck_IsSwitchWallpaper_CheckedChanged;
                        break;
                    case "db_timedw":
                        ComboBox_InterValTimeUnit = item as DuiComboBox;
                        ComboBox_InterValTimeUnit.BackColor = Color.FromArgb(155, pes.pes.BackColor);
                        ComboBox_InterValTimeUnit.SelectedIndexChanged += ComboBox_InterValTimeUnit_SelectedIndexChanged;
                        if (pes.pes.InterValTime < 60)
                        {
                            ComboBox_InterValTimeUnit.SelectedIndex = 0;
                            TextBox_InterValTime.Text = pes.pes.InterValTime.ToString();
                        }
                        else if (pes.pes.InterValTime < 3600)
                        {
                            ComboBox_InterValTimeUnit.SelectedIndex = 1;
                            TextBox_InterValTime.Text = (pes.pes.InterValTime/60).ToString();
                        }
                        else
                        {
                            ComboBox_InterValTimeUnit.SelectedIndex = 2;
                            TextBox_InterValTime.Text = (pes.pes.InterValTime/3600).ToString();
                        }
                        break;
                    case "tb_timeStr":
                        TextBox_InterValTime = item as DuiTextBox;
                        TextBox_InterValTime.BackColor = Color.FromArgb(155, pes.pes.BackColor);
                        TextBox_InterValTime.AutoHeight = true;
                        TextBox_InterValTime.Invalidated += TextBox_InterValTime_TextChanged;
                        //TextBox_InterValTime.Text = pes.pes.InterValTime.ToString();
                        break;
                    default:
                        if (item is DuiButton && item.Name.Contains("btn_"))
                        {
                            DuiButton Button_SwitchWallpaperType = item as DuiButton;
                            Button_SwitchWallpaperType.Cursor = System.Windows.Forms.Cursors.Hand;
                            Button_SwitchWallpaperType.MouseClick += Button_SwitchWallpaperType_MouseClick;
                            Button_SwitchWallpaperType.BaseColor = Color.Transparent;
                            Button_SwitchWallpaperType.BackgroundImage = Properties.Resources.btn_n;
                            Button_SwitchWallpaperType.IsPureColor = false;
                            Button_SwitchWallpaperType.Tag = false.ToString();
                            foreach (var WallpaperType in pes.pes.SwitchWallpaperTypes)
                            {
                                if (item.Name.Replace("btn_", "") == WallpaperType.ToString())
                                {
                                    Button_SwitchWallpaperType.Tag = true.ToString();
                                    Button_SwitchWallpaperType.BackgroundImage = Properties.Resources.btn_select_n;
                                }
                            }
                            Button_SwitchWallpaperType.BackgroundImageLayout = ImageLayout.Stretch;
                        }
                        break;
                }
            }
            //下载设置界面相关处理
            foreach (DuiBaseControl item in layeredPanel_xzsz.DUIControls)
            {
                switch (item.Name)
                {
                    case "rd_SizeForThumb":
                    case "rd_SizeFor1600900":
                    case "rd_SizeFor1440900":
                    case "rd_SizeFor12801024":
                    case "rd_SizeFor1024768":
                    case "rd_SizeFor1280800":
                        RadioButton_picSize = item as DuiRadioButton;
                        RadioButton_picSize.CheckFlagColor = Color.FromArgb(155, pes.pes.BackColor);
                        RadioButton_picSize.CheckRectColor = Color.FromArgb(155, pes.pes.BackColor);
                        RadioButton_picSize.CheckedChanged += RadioButton_picSize_CheckedChanged;
                        if ("rd_SizeFor" + (pes.pes.PicSize == "default" ? "Thumb" : pes.pes.PicSize) == item.Name)
                        {
                            RadioButton_picSize.Checked = true;
                        }
                        else
                        {
                            RadioButton_picSize.Checked = false;
                        }
                        break;
                    case "text_downloadPath":
                        lb_downloadPath = item as DuiTextBox;
                        lb_downloadPath.BackColor = Color.FromArgb(155, pes.pes.BackColor);
                        lb_downloadPath.Text = (String.IsNullOrEmpty(pes.pes.DownloadPath) ? AppDomain.CurrentDomain.BaseDirectory + @"ImageWallpaper\" : pes.pes.DownloadPath);
                        break;
                    case "btn_selectDownloadPath":
                        btn_selectDownloadPath = item as DuiButton;
                        btn_selectDownloadPath.Cursor = System.Windows.Forms.Cursors.Hand;
                        btn_selectDownloadPath.MouseClick += Btn_selectDownloadPath_MouseClick;
                        break;
                    case "text_cachePath":
                        lb_cachePath = item as DuiTextBox;
                        lb_cachePath.BackColor = Color.FromArgb(155, pes.pes.BackColor);
                        lb_cachePath.Text = (String.IsNullOrEmpty(pes.pes.CachePath) ? AppDomain.CurrentDomain.BaseDirectory + @"CacheWallpaper\" : pes.pes.CachePath);
                        if (lb_nowCacheSize != null && lb_cachePath != null)
                        {
                            lb_nowCacheSize.Text = "当前缓存：" + GetDirectoryLength(lb_cachePath.Text) / (1024 * 1024) + "MB";
                        }

                        break;
                    case "btn_selectCachePath":
                        btn_selectCachePath = item as DuiButton;
                        btn_selectCachePath.Cursor = System.Windows.Forms.Cursors.Hand;
                        btn_selectCachePath.MouseClick += Btn_selectCachePath_MouseClick;
                        break;
                    case "lb_nowCacheSize":
                        lb_nowCacheSize = item as DuiLabel;
                        if (lb_cachePath != null && lb_nowCacheSize != null)
                        {
                            lb_nowCacheSize.Text = "当前缓存：" + GetDirectoryLength(lb_cachePath.Text) / (1024 * 1024) + "MB";
                        }
                        break;
                    case "lb_clearCache":
                        lb_clearCache = item as DuiLabel;
                        lb_clearCache.Cursor = System.Windows.Forms.Cursors.Hand;
                        lb_clearCache.MouseClick += Lb_clearCache_MouseClick;
                        break;
                    default:
                        break;
                }
            }
            //关于界面相关处理
            foreach (DuiBaseControl item in layeredPanel_gy.DUIControls)
            {
                switch (item.Name)
                {
                    case "lb_ver":
                        lb_ver = item as DuiLabel;
                        lb_ver.Text = pes.pes.VerNo;
                        break;
                    case "btn_update":
                        btn_update = item as DuiButton;
                        btn_update.Cursor = System.Windows.Forms.Cursors.Hand;
                        btn_update.BaseColor = Color.FromArgb(155, pes.pes.BackColor);
                        btn_update.MouseClick += Btn_update_MouseClick;
                        break;
                    case "btn_sendyj":
                        btn_sendyj = item as DuiButton;
                        btn_sendyj.Cursor = System.Windows.Forms.Cursors.Hand;
                        btn_sendyj.BaseColor = Color.FromArgb(155, pes.pes.BackColor);
                        btn_sendyj.MouseClick += Btn_sendyj_MouseClick;
                        break;
                    case "lb_mxnr1":
                        lb_mxnr1 = item as DuiLabel;
                        lb_mxnr1.Cursor = System.Windows.Forms.Cursors.Hand;
                        lb_mxnr1.MouseClick += Lb_mxnr1_MouseClick;
                        break;
                    case "lb_mxnr2":
                        lb_mxnr2 = item as DuiLabel;
                        lb_mxnr2.Cursor = System.Windows.Forms.Cursors.Hand;
                        lb_mxnr2.MouseClick += Lb_mxnr1_MouseClick;
                        break;
                    case "lb_zzemail":
                        lb_zzemail = item as DuiLabel;
                        lb_zzemail.Cursor = System.Windows.Forms.Cursors.Hand;
                        lb_zzemail.MouseClick += Lb_zzemail_MouseClick;
                        break;
                    default:
                        break;
                }
            }
        }
        /// <summary>
        /// 获取指定文件目录的大小
        /// </summary>
        /// <param name="dirPath">文件夹地址</param>
        /// <returns></returns>
        public static long GetDirectoryLength(string dirPath)
        {
            //判断给定的路径是否存在,如果不存在则退出
            if (!Directory.Exists(dirPath))
                return 0;
            long len = 0;

            //定义一个DirectoryInfo对象
            DirectoryInfo di = new DirectoryInfo(dirPath);

            //通过GetFiles方法,获取di目录中的所有文件的大小
            foreach (FileInfo fi in di.GetFiles())
            {
                len += fi.Length;
            }

            //获取di中所有的文件夹,并存到一个新的对象数组中,以进行递归
            DirectoryInfo[] dis = di.GetDirectories();
            if (dis.Length > 0)
            {
                for (int i = 0; i < dis.Length; i++)
                {
                    len += GetDirectoryLength(dis[i].FullName);
                }
            }
            return len;
        }

        public Image BackGroundSkin
        {
            get { return BackImg; }
            set
            {
                BackImg = value;
                if (value != null)
                {
                    Rectangle a = new Rectangle(new Point(), this.Size); this.BackgroundImage = BridImage.Utils.ImageVague.GaussianBlur(new Bitmap(BackImg), ref a, 20, false);
                }
                else
                {
                    this.BackgroundImage = null;
                }
                this.BackgroundImageLayout = ImageLayout.Stretch;
            }
        }
        private void recoverDefaultStyle(LayeredLabel dl)
        {
            switch (dl.Name)
            {
                case "btn_cg":
                    btn_xzsz.ForeColor = SystemColors.ControlText;
                    btn_qhbz.ForeColor = SystemColors.ControlText;
                    btn_gy.ForeColor = SystemColors.ControlText;
                    layeredPanel_xzsz.Visible = false;
                    layeredPanel_qhbz.Visible = false;
                    layeredPanel_gy.Visible = false;
                    break;
                case "btn_xzsz":
                    btn_cg.ForeColor = SystemColors.ControlText;
                    btn_qhbz.ForeColor = SystemColors.ControlText;
                    btn_gy.ForeColor = SystemColors.ControlText;
                    layeredPanel_cg.Visible = false;
                    layeredPanel_qhbz.Visible = false;
                    layeredPanel_gy.Visible = false;
                    break;
                case "btn_qhbz":
                    btn_cg.ForeColor = SystemColors.ControlText;
                    btn_xzsz.ForeColor = SystemColors.ControlText;
                    btn_gy.ForeColor = SystemColors.ControlText;
                    layeredPanel_cg.Visible = false;
                    layeredPanel_xzsz.Visible = false;
                    layeredPanel_gy.Visible = false;
                    break;
                case "btn_gy":
                    btn_cg.ForeColor = SystemColors.ControlText;
                    btn_xzsz.ForeColor = SystemColors.ControlText;
                    btn_qhbz.ForeColor = SystemColors.ControlText;
                    layeredPanel_cg.Visible = false;
                    layeredPanel_xzsz.Visible = false;
                    layeredPanel_qhbz.Visible = false;
                    break;
                default:
                    break;
            }
        }

        private DuiBaseControl getThisBaseControl(LayeredPanel lp, string controlName)
        {
            DuiBaseControl cb = null;
            foreach (DuiBaseControl item in lp.DUIControls)
            {
                if (item.Name == controlName)
                {
                    cb = item;
                }
            }
            return cb;
        }

        private void saveConfig()
        {
            pes.pes.AutoStart = Ck_AutoStart.Checked;
            pes.pes.DownloadPath = lb_downloadPath.Text;
            pes.pes.IsSwitchWallpaper = Ck_IsSwitchWallpaper.Checked;
            pes.pes.CachePath = lb_cachePath.Text;
            int interVal = int.Parse(TextBox_InterValTime.Text);
            switch (ComboBox_InterValTimeUnit.SelectedIndex)
            {
                case 0:
                    pes.pes.InterValTime = interVal;
                    break;
                case 1:
                    pes.pes.InterValTime = interVal * 60;
                    break;
                default:
                    pes.pes.InterValTime = interVal * 60 * 60;
                    break;
            }
            pes.pes.saveConfig();
        }
        #endregion
    }
}
