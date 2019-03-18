using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
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
        BackForm pes = null;
        DuiLabel dl_yjlen = null;
        public Image BackImg = null;
        //相关信息
        string msgTitle = "小鸟壁纸【产品建议】";
        string lxfs = "";

        public SendYjForm(BackForm cps)
        {
            pes = cps;
            InitializeComponent();
            btn_send.Cursor = Cursors.Hand;
            btn_back.Cursor = Cursors.Hand;
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
            this.BackColor = Color.FromArgb(185, pes.pes.BackColor);
            if (pes.BackGroundSkin != null)
            {
                BackGroundSkin = pes.BackGroundSkin;
            }
            btn_send.BaseColor = pes.pes.BackColor;
            foreach (DuiBaseControl item in panel_main.DUIControls)
            {
                switch (item.Name)
                {
                    case "rb_cpjy":
                    case "rb_bugfk":
                        dr_fklx = item as DuiRadioButton;
                        dr_fklx.CheckRectColor = pes.pes.BackColor;
                        dr_fklx.CheckFlagColor = pes.pes.BackColor;
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
                    searchText.ForeColor = Color.Black;
                }
                else
                {
                    if (string.IsNullOrEmpty(searchText.Text))
                    {
                        searchText.Text = "你的联系方式(QQ/邮箱/手机),可不填";
                        searchText.ForeColor = Color.FromArgb(255, 171, 171, 171);
                    }
                    else
                    {
                        lxfs = searchText.Text;
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
            try
            {
                EmailEntity email = new EmailEntity();
                email.mailFrom = "declineaberdeen@163.com";
                email.mailPwd = "testDECLINE123";
                email.mailSubject = msgTitle;//邮件主题
                email.mailBody = tb_fkyj.Text+"=======反馈人联系方式："+lxfs;//邮件内容
                email.isbodyHtml = false;    //是否是HTML
                email.host = "smtp.163.com";//如果是QQ邮箱则：smtp:qq.com,依次类推
                email.mailToArray = new string[] { "1577972070@qq.com" };//接收者邮件集合
                email.mailCcArray = new string[] { "1577972070@qq.com" };//抄送者邮件集合
                if (email.Send())
                {
                    MessageForm mf = new MessageForm("反馈已发送，小二会尽力满足需求并及时更新！");
                    mf.Show();
                }
            }
            catch (Exception ex)
            {
                MessageForm mf = new MessageForm("发送失败,原因为："+ex.Message);
                mf.Show();
            }
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
