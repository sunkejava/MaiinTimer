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
        private string messageStr = "";
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
                layeredLabel1.Size = new Size();
                layeredLabel2.Visible = false;
            }
            this.BackColor = Color.FromArgb(120,0,0,0);
            btn_close.Cursor = Cursors.Hand;
            layeredLabel2.Cursor = Cursors.Hand;
        }

        private void layeredLabel2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("explorer.exe", AppDomain.CurrentDomain.BaseDirectory + @"ImageWallpaper\");
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
