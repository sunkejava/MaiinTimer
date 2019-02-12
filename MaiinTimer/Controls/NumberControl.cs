using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using LayeredSkin.DirectUI;

namespace MaiinTimer.Controls
{
    public partial class NumberControl : DuiBaseControl
    {
        private int maxNumber = 12;
        private int minNumber = 0;
        private Size autoSize = new Size(100,20);
        [Description("最大值"), Category("自定义属性")]
        public int MaxNumber {
            get { return maxNumber; }
            set { maxNumber = value; }
        }
        [Description("最小值"), Category("自定义属性")]
        public int MinNumber
        {
            get { return minNumber; }
            set { minNumber = value; }
        }
        [Description("默认大小"), Category("自定义属性")]
        public  Size AutoCSize
        {
            get { return autoSize; }
            set { autoSize = value; }
        }
        public NumberControl()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.Size = autoSize;
            DuiTextBox Texts = new DuiTextBox();
            Texts.Size = this.Size;
            Texts.Location = new Point(0, 0);
            Texts.KeyPress += Texts_KeyPress;

            DuiButton btn_up = new DuiButton();
            btn_up.Size = new Size(26, 15);
            btn_up.Radius = 5;
            btn_up.Name = "btn_Up";
            btn_up.Text = "";
            btn_up.Location = new Point(this.Width-15, 0);
            btn_up.Cursor = System.Windows.Forms.Cursors.Hand;
            btn_up.AdaptImage = false;
            btn_up.IsPureColor = true;
            btn_up.BaseColor = Color.Transparent;
            btn_up.BackgroundImage = Properties.Resources.up;
            btn_up.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            btn_up.ShowBorder = false;
            btn_up.MouseClick += Btn_Up_MouseClick;

            DuiButton btn_down = new DuiButton();
            btn_down.Size = new Size(26, 15);
            btn_down.Radius = 5;
            btn_down.Name = "btn_down";
            btn_down.Text = "";
            btn_down.Location = new Point(this.Width - 15, 15);
            btn_down.Cursor = System.Windows.Forms.Cursors.Hand;
            btn_down.AdaptImage = false;
            btn_down.IsPureColor = true;
            btn_down.BaseColor = Color.Transparent;
            btn_down.BackgroundImage = Properties.Resources.down;
            btn_down.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            btn_down.ShowBorder = false;
            btn_down.MouseClick += Btn_Down_MouseClick;

            this.Controls.AddRange(new DuiBaseControl[] { Texts,btn_up,btn_down});
        }

        private void Btn_Down_MouseClick(object sender, DuiMouseEventArgs e)
        {
            DuiTextBox ds = sender as DuiTextBox;
            int value = (int.Parse(ds.Text)-1);
            if (value < minNumber)
            {
                value = maxNumber;
            }
            if (value > maxNumber)
            {
                value = minNumber;
            }
        }

        private void Btn_Up_MouseClick(object sender, DuiMouseEventArgs e)
        {
            DuiTextBox ds = sender as DuiTextBox;
            int value = (int.Parse(ds.Text) + 1);
            if (value < minNumber)
            {
                value = maxNumber;
            }
            if (value > maxNumber)
            {
                value = minNumber;
            }
        }

        /// <summary>
        /// 设置控件只允许输入数字
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Texts_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar != '\b')//这是允许输入退格键  
            {
                if ((e.KeyChar < Char.Parse(minNumber.ToString())) || (e.KeyChar > Char.Parse(maxNumber.ToString())))//这是允许输入0-9数字  
                {
                    e.Handled = true;
                }
            }
        }
    }
}
