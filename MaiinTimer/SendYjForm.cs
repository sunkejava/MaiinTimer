using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using BridImage.Utils;
using LayeredSkin.DirectUI;
using LayeredSkin.Forms;

namespace BridImage
{
    public partial class SendYjForm : LayeredForm
    {
        ///控件
        DuiRadioButton dr_fklx = null;
        DuiTextBox tb_fkyj = null;
        DuiTextBox tb_lxfs = null;
        PropertsUtils pes = null;
        DuiLabel dl_yjlen = null;
        //相关信息
        string msgTitle = "";

        public SendYjForm(PropertsUtils cps)
        {
            pes = cps;
            InitializeComponent();
        }

        private void layeredPanel_close_MouseEnter(object sender, EventArgs e)
        {
            layeredPanel_close.BackColor = Color.FromArgb(255, 88, 88);
        }

        private void layeredPanel_close_MouseLeave(object sender, EventArgs e)
        {
            layeredPanel_close.BackColor = Color.Transparent;
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SendYjForm_Load(object sender, EventArgs e)
        {
            this.BackColor = pes.BackColor;
            btn_send.BaseColor = pes.BackColor;
            foreach (DuiBaseControl item in panel_main.DUIControls)
            {
                switch (item.Name)
                {
                    case "rb_cpjy":
                    case "rb_bugfk":
                        dr_fklx = item as DuiRadioButton;
                        dr_fklx.CheckRectColor = pes.BackColor;
                        dr_fklx.CheckFlagColor = pes.BackColor;
                        dr_fklx.CheckedChanged += Dr_fklx_CheckedChanged;
                        break;
                    case "tb_fkyj":
                        tb_fkyj = item as DuiTextBox;
                        tb_fkyj.Invalidated += Tb_fkyj_Invalidated;
                        break;
                    case "tb_lxfs":
                        tb_lxfs = item as DuiTextBox;
                        tb_lxfs.FocusedChanged += Tb_lxfs_FocusedChanged;
                        break;
                    case "lb_yjlen":
                        dl_yjlen = item as DuiLabel;
                        break;
                    default:
                        break;
                }
            }
        }

        private void Tb_fkyj_Invalidated(object sender, System.Windows.Forms.InvalidateEventArgs e)
        {
            DuiTextBox dtb = sender as DuiTextBox;
            dl_yjlen.Text = (1000 - (dtb.Text.Length)).ToString();
        }

        private void Tb_lxfs_FocusedChanged(object sender, EventArgs e)
        {
            DuiTextBox searchText = sender as DuiTextBox;
            if (searchText != null)
            {
                if (searchText.Text == "你的联系方式(QQ/邮箱/手机),可不填")
                {
                    searchText.Text = "";
                    searchText.ForeColor = Color.White;
                }
                else
                {
                    if (string.IsNullOrEmpty(searchText.Text))
                    {
                        searchText.Text = "你的联系方式(QQ/邮箱/手机),可不填";
                        searchText.ForeColor = Color.FromArgb(255, 171, 171, 171);
                    }
                }
            }
        }

        private void Dr_fklx_CheckedChanged(object sender, EventArgs e)
        {
            DuiRadioButton drb = sender as DuiRadioButton;
            msgTitle = "小鸟壁纸【"+drb.Text+"】";
        }

        private void btn_send_Click(object sender, EventArgs e)
        {
            EmailEntity email = new EmailEntity();
            email.mailFrom = "352148748@qq.com";
            email.mailPwd = "sunkejava123";
            email.mailSubject = msgTitle;//邮件主题
            email.mailBody = tb_fkyj.Text;//邮件内容
            email.isbodyHtml = false;    //是否是HTML
            email.host = "smtp.qq.com";//如果是QQ邮箱则：smtp:qq.com,依次类推
            email.mailToArray = new string[] { "1577972070@qq.com" };//接收者邮件集合
            email.mailCcArray = new string[] { "1577972070@qq.com" };//抄送者邮件集合
            email.Send().ToString();
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
