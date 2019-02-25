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
            foreach (DuiBaseControl item in layeredPanel_cg.DUIControls)
            {
                switch (item.Name)
                {
                    case "ck_qd":
                        DuiCheckBox dc = item as DuiCheckBox;
                        dc.CheckRectColor = defaultColor;
                        break;
                    case "rd_min":
                    case "rd_close":
                        DuiRadioButton drb = item as DuiRadioButton;
                        drb.CheckRectColor = defaultColor;
                        break;
                    case "":

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
