using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LayeredSkin.Controls;
using LayeredSkin.DirectUI;

namespace BridImage.Controls
{
    public partial class ColorSkinControl : LayeredBaseControl
    {

        private int width = 300;
        private int height = 100;
        public ColorSkinControl()
        {
            init();   
        }

        private void init()
        {
            this.Size = new Size(newWidth,newHeight);
            this.BackColor = Color.White;
            int[,] colorArray = { { 253, 177, 174 }, { 212, 170, 224 }, { 253, 208, 234 }, { 253, 202, 178 }, { 233, 122, 124 }, { 254, 178, 195 }, { 251, 180, 121 }, { 216, 194, 236 }, { 236, 218, 235 }, { 178, 216, 252 }, { 184, 242, 140 }, { 139, 226, 217 }, { 215, 225, 230 }, { 212, 156, 185 }, { 235, 170, 182 }, { 177, 196, 252 }, { 243, 113, 171 }, { 35, 212, 254 }, { 60, 242, 177 }, { 252, 163, 113 }, { 49, 108, 156 }, { 202, 228, 231 }, { 101, 224, 222 }, { 65, 225, 211 } };
            for (int i = 1; i <= 24; i++)
            {
                DuiLabel dlc = new DuiLabel();
                dlc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(colorArray[i - 1, 0])))), ((int)(((byte)(colorArray[i - 1, 1])))), ((int)(((byte)(colorArray[i - 1, 2])))));
                dlc.Width = (newWidth - 2) / 8;
                dlc.Height = 10;
                dlc.Name = "color" + i.ToString();
                //根据循环数判断当前行及列
                int ColorColNum = (i % 8 == 0 ? 8 : i % 8);
                int ColorRowNum = (i - i % 8) / 8 + (i % 8 == 0 ? 0 : 1);
                dlc.Location = new Point(3 + ((ColorColNum - 1) * dlc.Width), 3 * (ColorRowNum) + ((ColorRowNum - 1) * 10));
                dlc.MouseClick += Dlc_MouseClick;
                this.DuiControl.Controls.Add(dlc);
            }
        }

        private void Dlc_MouseClick(object sender, DuiMouseEventArgs e)
        {
            throw new NotImplementedException();
        }

        public int newWidth
        {
            get { return width; }
            set { width = value; }
        }
        public int newHeight
        {
            get { return height; }
            set { height = value; }
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }
    }
}
