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

namespace BridImage
{
    public partial class SetForm : LayeredForm
    {
        private Color defaultColor = Color.OrangeRed;
        PropertsUtils pes = new PropertsUtils();
        #region 设置相关控件
        //常规控件
        DuiCheckBox Ck_AutoStart = null;
        DuiRadioButton RadioButton_CloseMode = null;
        //切换壁纸控件
        DuiCheckBox Ck_IsSwitchWallpaper = null;
        DuiTextBox TextBox_InterValTime = null;
        DuiComboBox ComboBox_InterValTimeUnit = null;
        DuiButton Button_SwitchWallpaperType = null;
        //下载设置控件
        DuiRadioButton RadioButton_picSize = null;
        DuiLabel lb_downloadPath = null;
        DuiButton btn_selectDownloadPath = null;
        DuiLabel lb_cachePath = null;
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
        #endregion
        public SetForm(Color bc)
        {
            InitializeComponent();
            defaultColor = bc;
            setDefaultStyle();
        }
        #region 控件事件
        private void btn_cg_Click(object sender, EventArgs e)
        {
            if (sender is LayeredLabel)
            {
                LayeredLabel lb = sender as LayeredLabel;
                recoverDefaultStyle(lb);
                lb.ForeColor = defaultColor;
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
            pes.saveConfig();
            this.Close();
        }

        private void btn_close_MouseDown(object sender, MouseEventArgs e)
        {
            LayeredButton thisButton = sender as LayeredButton;
            thisButton.BackColor = Color.FromArgb(255, 92, 125);
        }

        private void btn_close_MouseHover(object sender, EventArgs e)
        {
            layeredPanel_close.BackColor = Color.FromArgb(255, 88, 88);      
        }

        private void btn_close_MouseLeave(object sender, EventArgs e)
        {
            LayeredButton thisButton = sender as LayeredButton;
            thisButton.BackColor = Color.Transparent;
            layeredPanel_close.BackColor = thisButton.BackColor;
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
                pes.CloseMode = "isMin";
            }
            else if (cdr.Name == "rd_close" && cdr.Checked)
            {
                pes.CloseMode = "isClose";
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
            pes.AutoStart = Ck_AutoStart.Checked;
        }

        /// <summary>
        /// 壁纸切换类型按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_SwitchWallpaperType_MouseClick(object sender, DuiMouseEventArgs e)
        {
            DuiButton cdb = sender as DuiButton;
            if (cdb.BaseColor == pes.BackColor)
            {
                cdb.BaseColor = Color.Transparent;
                pes.SwitchWallpaperTypes.Remove(cdb.Name.Replace("btn_", ""));
            }
            else
            {
                cdb.BaseColor = pes.BackColor;
                if (pes.SwitchWallpaperTypes.Contains(""))
                {
                    pes.SwitchWallpaperTypes.Remove("");
                }
                pes.SwitchWallpaperTypes.Add(cdb.Name.Replace("btn_",""));
            }
        }

        /// <summary>
        /// 切换时间间隔变化事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBox_InterValTime_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(TextBox_InterValTime.Text))
            {
                int interVal = int.Parse(TextBox_InterValTime.Text);
                switch (ComboBox_InterValTimeUnit.SelectedIndex)
                {
                    case 0:
                        pes.InterValTime = interVal;
                        break;
                    case 1:
                        pes.InterValTime = interVal * 60;
                        break;
                    default:
                        pes.InterValTime = interVal * 60 * 60;
                        break;
                }
            }
        }

        /// <summary>
        /// 自动切换壁纸启动设置事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Ck_IsSwitchWallpaper_CheckedChanged(object sender, EventArgs e)
        {
            pes.IsSwitchWallpaper = Ck_IsSwitchWallpaper.Checked;
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
                    pes.InterValTime = interVal;
                }
                else if (ComboBox_InterValTimeUnit.SelectedIndex == 1)
                {
                    pes.InterValTime = interVal * 60;
                }
                else
                {
                    pes.InterValTime = interVal * 60 * 60;
                }
            }    
        }

        /// <summary>
        /// 下载路径变化事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Lb_downloadPath_Invalidated(object sender, InvalidateEventArgs e)
        {
            if (!string.IsNullOrEmpty(lb_downloadPath.Text))
            {
                pes.DownloadPath = lb_downloadPath.Text;
            }
        }
        /// <summary>
        /// 缓存路径变化事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Lb_cachePath_Invalidated(object sender, InvalidateEventArgs e)
        {
            if (!string.IsNullOrEmpty(lb_cachePath.Text))
            {
                pes.CachePath = lb_cachePath.Text;
            }
        }

        /// <summary>
        /// 清理缓存事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Lb_clearCache_MouseClick(object sender, DuiMouseEventArgs e)
        {

        }
        /// <summary>
        /// 选择下载目录事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_selectDownloadPath_MouseClick(object sender, DuiMouseEventArgs e)
        {
            System.Windows.Forms.FolderBrowserDialog dialog = new System.Windows.Forms.FolderBrowserDialog();
            dialog.Description = "请选择下载目录";
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
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
        /// <summary>
        /// 选择缓存目录事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_selectCachePath_MouseClick(object sender, DuiMouseEventArgs e)
        {
            System.Windows.Forms.FolderBrowserDialog dialog = new System.Windows.Forms.FolderBrowserDialog();
            dialog.Description = "请选择缓存目录";
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (string.IsNullOrEmpty(dialog.SelectedPath))
                {
                    lb_cachePath.Text = "请选择缓存保存目录";
                }
                else
                {
                    lb_cachePath.Text = dialog.SelectedPath;
                }
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
                        pes.PicSize = "default";
                        break;
                    case "rd_SizeFor1600900":
                        pes.PicSize = "1600900";
                        break;
                    case "rd_SizeFor1440900":
                        pes.PicSize = "1440900";
                        break;
                    case "rd_SizeFor12801024":
                        pes.PicSize = "12801024";
                        break;
                    case "rd_SizeFor1024768":
                        pes.PicSize = "1024768";
                        break;
                    case "rd_SizeFor1280800":
                        pes.PicSize = "1280800";
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
            if (!lb_ver.Text.Equals(cv.Ver))
            {
                //执行更新操作

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
            this.BackColor = defaultColor;
            btn_point.BackColor = defaultColor;
            btn_cg.ForeColor = defaultColor;
            layeredPanel_cg.BringToFront();
            //常规界面相关处理
            foreach (DuiBaseControl item in layeredPanel_cg.DUIControls)
            {
                switch (item.Name)
                {
                    case "ck_qd":
                        Ck_AutoStart = item as DuiCheckBox;
                        Ck_AutoStart.CheckRectColor = pes.BackColor;
                        Ck_AutoStart.CheckFlagColor = pes.BackColor;
                        Ck_AutoStart.CheckedChanged += Ck_AutoStart_CheckedChanged;
                        Ck_AutoStart.Checked = pes.AutoStart;
                        break;
                    case "rd_min":
                    case "rd_close":
                        RadioButton_CloseMode = item as DuiRadioButton;
                        RadioButton_CloseMode.CheckRectColor = pes.BackColor;
                        RadioButton_CloseMode.CheckFlagColor = pes.BackColor;
                        RadioButton_CloseMode.CheckedChanged += RadioButton_CloseMode_CheckedChanged;
                        if ((pes.CloseMode == "isClose") && RadioButton_CloseMode.Name == "rd_close")
                        {
                            (item as DuiRadioButton).Checked = true;
                        }
                        else if ((pes.CloseMode == "isMin") && RadioButton_CloseMode.Name == "rd_min")
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
                        Ck_IsSwitchWallpaper.CheckRectColor = pes.BackColor;
                        Ck_IsSwitchWallpaper.CheckFlagColor = pes.BackColor;
                        Ck_IsSwitchWallpaper.Checked = pes.IsSwitchWallpaper;
                        Ck_IsSwitchWallpaper.CheckedChanged += Ck_IsSwitchWallpaper_CheckedChanged;
                        break;
                    case "db_timedw":
                        ComboBox_InterValTimeUnit = item as DuiComboBox;
                        ComboBox_InterValTimeUnit.BackColor = pes.BackColor;
                        ComboBox_InterValTimeUnit.SelectedIndexChanged += ComboBox_InterValTimeUnit_SelectedIndexChanged;
                        if (pes.InterValTime < 60)
                        {
                            ComboBox_InterValTimeUnit.SelectedIndex = 0;
                        }
                        else if (pes.InterValTime < 3600)
                        {
                            ComboBox_InterValTimeUnit.SelectedIndex = 1;
                        }
                        else
                        {
                            ComboBox_InterValTimeUnit.SelectedIndex = 2;
                        }
                        break;
                    case "tb_timeStr":
                        TextBox_InterValTime = item as DuiTextBox;
                        TextBox_InterValTime.BackColor = pes.BackColor;
                        TextBox_InterValTime.AutoHeight = true;
                        TextBox_InterValTime.Invalidated += TextBox_InterValTime_TextChanged;
                        break;
                    default:
                        if (item is DuiButton && item.Name.Contains("btn_"))
                        {
                            Button_SwitchWallpaperType = item as DuiButton;
                            Button_SwitchWallpaperType.Cursor = System.Windows.Forms.Cursors.Hand;
                            Button_SwitchWallpaperType.MouseClick += Button_SwitchWallpaperType_MouseClick;
                            foreach (var WallpaperType in pes.SwitchWallpaperTypes)
                            {
                                if (item.Name.Replace("btn_", "") == WallpaperType.ToString())
                                {
                                    Button_SwitchWallpaperType.BaseColor = pes.BackColor;
                                }
                            }
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
                        RadioButton_picSize.CheckFlagColor = pes.BackColor;
                        RadioButton_picSize.CheckRectColor = pes.BackColor;
                        RadioButton_picSize.CheckedChanged += RadioButton_picSize_CheckedChanged;
                        if ("rd_SizeFor" + (pes.PicSize == "default" ? "Thumb" : pes.PicSize) == item.Name)
                        {
                            RadioButton_picSize.Checked = true;
                        }
                        else
                        {
                            RadioButton_picSize.Checked = false;
                        }
                        break;
                    case "lb_downloadPath":
                        lb_downloadPath = item as DuiLabel;
                        lb_downloadPath.BackColor = pes.BackColor;
                        lb_downloadPath.Text = pes.DownloadPath;
                        lb_downloadPath.TextAlign = ContentAlignment.MiddleLeft;
                        lb_downloadPath.Invalidated += Lb_downloadPath_Invalidated;
                        break;
                    case "btn_selectDownloadPath":
                        btn_selectDownloadPath = item as DuiButton;
                        btn_selectDownloadPath.Cursor = System.Windows.Forms.Cursors.Hand;
                        btn_selectDownloadPath.MouseClick += Btn_selectDownloadPath_MouseClick;
                        break;
                    case "lb_cachePath":
                        lb_cachePath = item as DuiLabel;
                        lb_cachePath.BackColor = pes.BackColor;
                        lb_cachePath.Text = pes.CachePath;
                        lb_cachePath.TextAlign = ContentAlignment.MiddleLeft;
                        lb_cachePath.Invalidated += Lb_cachePath_Invalidated;
                        break;
                    case "btn_selectCachePath":
                        btn_selectCachePath = item as DuiButton;
                        btn_selectCachePath.Cursor = System.Windows.Forms.Cursors.Hand;
                        btn_selectCachePath.MouseClick += Btn_selectCachePath_MouseClick;
                        break;
                    case "lb_nowCacheSize":
                        lb_nowCacheSize = item as DuiLabel;
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
                        lb_ver.Text = pes.VerNo;
                        break;
                    case "btn_update":
                        btn_update = item as DuiButton;
                        btn_update.Cursor = System.Windows.Forms.Cursors.Hand;
                        btn_update.BaseColor = pes.BackColor;
                        btn_update.MouseClick += Btn_update_MouseClick;
                        break;
                    case "btn_sendyj":
                        btn_sendyj = item as DuiButton;
                        btn_sendyj.Cursor = System.Windows.Forms.Cursors.Hand;
                        btn_sendyj.BaseColor = pes.BackColor;
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

        #endregion

    }
}
