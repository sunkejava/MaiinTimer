using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LayeredSkin.Forms;
using LayeredSkin.DirectUI;

namespace BridImage
{
    public partial class colorSkin : LayeredForm
    {
        BackForm cpes = null;
        public colorSkin(BackForm pes)
        {
            InitializeComponent();
            cpes = pes;
            Init();
        }

        public void Init()
        {
            int[,] colorArray = { { 253, 177, 174 }, { 212, 170, 224 }, { 253, 208, 234 }, { 253, 202, 178 }, { 233, 122, 124 }, { 254, 178, 195 }, { 251, 180, 121 }, { 216, 194, 236 }, { 236, 218, 235 }, { 178, 216, 252 }, { 184, 242, 140 }, { 139, 226, 217 }, { 215, 225, 230 }, { 212, 156, 185 }, { 235, 170, 182 }, { 177, 196, 252 }, { 243, 113, 171 }, { 35, 212, 254 }, { 60, 242, 177 }, { 252, 163, 113 }, { 49, 108, 156 }, { 202, 228, 231 }, { 101, 224, 222 }, { 65, 225, 211 } };
            for (int i = 1; i <= 24; i++)
            {
                DuiLabel dlc = new DuiLabel();
                dlc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(colorArray[i - 1, 0])))), ((int)(((byte)(colorArray[i - 1, 1])))), ((int)(((byte)(colorArray[i - 1, 2])))));
                dlc.Width = (Width - 18) / 12;
                dlc.Height = (base_main.Height - 8) / 2;
                dlc.Name = "color" + i.ToString();
                //根据循环数判断当前行及列
                int ColorColNum = (i % 12 == 0 ? 12 : i % 12);
                int ColorRowNum = (i - i % 12) / 12 + (i % 12 == 0 ? 0 : 1);
                dlc.Location = new Point(13 + ((ColorColNum - 1) * dlc.Width), 2 * (ColorRowNum) + ((ColorRowNum - 1) * dlc.Height));
                dlc.MouseClick += Dlc_MouseClick;
                base_main.DUIControls.Add(dlc);
            }
        }

        private void Dlc_MouseClick(object sender, DuiMouseEventArgs e)
        {
            DuiLabel dlc = sender as DuiLabel;
            cpes.defaultColor = dlc.BackColor;
            cpes.pes.BackColor = dlc.BackColor;
            cpes.setSkinStyle();
        }
    }
}
