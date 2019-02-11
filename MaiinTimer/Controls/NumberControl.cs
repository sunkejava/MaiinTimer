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
            this.Controls.Add(Texts);
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
