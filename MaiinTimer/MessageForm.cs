using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LayeredSkin.Forms;

namespace MaiinTimer
{
    public partial class MessageForm : LayeredForm
    {
        public  string messageStr = "";
        public MessageForm()
        {
            InitializeComponent();
            getDefaultControl();
        }
        private void getDefaultControl()
        {
            if (!string.IsNullOrEmpty(messageStr))
            {
                layeredLabel1.Text = messageStr;
                int zHeight = 15;
                if ((Width - 4) / 11 < messageStr.Length)
                {
                    zHeight = (int)Math.Ceiling((decimal)(messageStr.Length / ((Width - 4) / 11)));
                }
                layeredLabel1.Size = new Size(11 * messageStr.Length, zHeight);
                layeredLabel1.Location = new Point(2, 55);
                layeredLabel2.Visible = false;
            }
            else
            {
                layeredLabel2.Cursor = Cursors.Hand;
            }
            this.BackColor = Color.FromArgb(120,0,0,0);
            btn_close.Cursor = Cursors.Hand;
            
        }

        private void layeredLabel2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("explorer.exe", AppDomain.CurrentDomain.BaseDirectory + @"ImageWallpaper\");
            this.Close();
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
