using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;
using LayeredSkin.DirectUI;

namespace BridImage.Controls
{
    public class CircularProgressBarEx : DuiBaseControl
    {
        private CircularProgressBar circularProgressBar = new CircularProgressBar();
        private string completeText = "";
        private string doingText = "";

        [Description("进度"), Category("自定义属性")]
        public int Value
        {
            get { return this.circularProgressBar.Value; }
            set
            {
                this.circularProgressBar.Value = value;
                this.Invalidate();
            }
        }

        [Description("进度条背景色"), Category("自定义属性")]
        public Color Color
        {
            get { return this.circularProgressBar.MainColor; }
            set
            {
                this.circularProgressBar.MainColor = value;
                this.Invalidate();
            }
        }

        [LocalizableAttribute(true)]
        [Description("完成后提示文字"),Category("自定义属性")]
        public string CompleteText
        {
            get { return completeText; }
            set
            {
                completeText = value;
                this.Invalidate();
            }
        }

        [LocalizableAttribute(true)]
        [Description("进行中提示文字"), Category("自定义属性")]
        public string DoingText
        {
            get { return doingText; }
            set
            {
                doingText = value;
                this.Invalidate();
            }
        }

        public CircularProgressBarEx()
        {
            this.BackColor = Color.Transparent;
            circularProgressBar.Dock = DockStyle.Top;
            this.Controls.Add(circularProgressBar);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (this.Value == 100)
            {
                SizeF size = e.Graphics.MeasureString(this.completeText, new Font("微软雅黑", 12F));
                e.Graphics.DrawString(this.completeText, new Font("微软雅黑", 12F), new SolidBrush(Color.White), new Point(this.Width / 2 - (int)size.Width / 2 - 1, this.Height - (int)size.Height - 5));
            }
            else
            {
                SizeF size = e.Graphics.MeasureString(this.doingText, new Font("微软雅黑", 12F));
                e.Graphics.DrawString(this.doingText, new Font("微软雅黑", 12F), new SolidBrush(Color.White), new Point(this.Width / 2 - (int)size.Width / 2 - 1, this.Height - (int)size.Height - 5));
            }

        }
    }
}
