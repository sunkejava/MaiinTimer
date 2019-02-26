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

        //切换壁纸控件
        DuiCheckBox Ck_IsSwitchWallpaper = null;
        DuiTextBox TextBox_InterValTime = null;
        DuiComboBox ComboBox_InterValTimeUnit = null;
        DuiButton Button_SwitchWallpaperType = null;
        //下载设置控件
        //关于控件
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
                        DuiCheckBox dc = item as DuiCheckBox;
                        dc.CheckRectColor = pes.BackColor;
                        break;
                    case "rd_min":
                    case "rd_close":
                        DuiRadioButton drb = item as DuiRadioButton;
                        drb.CheckRectColor = pes.BackColor;
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
                        Ck_IsSwitchWallpaper.Checked = pes.IsSwitchWallpaper;
                        Ck_IsSwitchWallpaper.CheckedChanged += Ck_IsSwitchWallpaper_CheckedChanged;
                        break;
                    case "db_timedw":
                        ComboBox_InterValTimeUnit = item as DuiComboBox;
                        ComboBox_InterValTimeUnit.BackColor = pes.BackColor;
                        break;
                    case "tb_timeStr":
                        TextBox_InterValTime = item as DuiTextBox;
                        if (pes.InterValTime < 60)
                        {
                            TextBox_InterValTime.Text = pes.InterValTime.ToString();
                            ComboBox_InterValTimeUnit.Text = "秒";
                        } else if (pes.InterValTime < 3600)
                        {
                            TextBox_InterValTime.Text = (pes.InterValTime / 60 ).ToString();
                            ComboBox_InterValTimeUnit.Text = "分";
                        }
                        else
                        {
                            TextBox_InterValTime.Text = (pes.InterValTime / 60 / 60).ToString();
                            ComboBox_InterValTimeUnit.Text = "时";
                        }
                        TextBox_InterValTime.TextChanged += TextBox_InterValTime_TextChanged;
                        break;
                    default:
                        if (item is DuiButton && item.Name.Contains("btn_"))
                        {
                            Button_SwitchWallpaperType = item as DuiButton;
                            Button_SwitchWallpaperType.MouseClick += Button_SwitchWallpaperType_MouseClick;
                        }
                        break;
                }
            }
            //下载设置界面相关处理

        }

        private void Button_SwitchWallpaperType_MouseClick(object sender, DuiMouseEventArgs e)
        {
            DuiButton cdb = sender as DuiButton;
            if (cdb.BaseColor == pes.BackColor)
            {
                cdb.BaseColor = Color.Transparent;
                pes.SwitchWallpaperTypes.Remove(cdb.Tag);
            }
            else
            {
                cdb.BaseColor = pes.BackColor;
                pes.SwitchWallpaperTypes.Add(cdb.Tag);
            }
        }

        /// <summary>
        /// 切换时间间隔变化事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBox_InterValTime_TextChanged(object sender, EventArgs e)
        {
            int interVal = int.Parse(TextBox_InterValTime.Text);
            switch (ComboBox_InterValTimeUnit.Text)
            {
                case "秒":
                    pes.InterValTime = interVal;
                    break;
                case "分":
                    pes.InterValTime = interVal * 60;
                    break;
                default:
                    pes.InterValTime = interVal * 60 * 60;
                    break;
            }
        }

        /// <summary>
        /// 自动切换壁纸启动设置事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Ck_IsSwitchWallpaper_CheckedChanged(object sender, EventArgs e)
        {
            pes.IsSwitchWallpaper =  Ck_IsSwitchWallpaper.Checked;
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
