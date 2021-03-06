﻿using System;
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
        bool dialoga = false;
        public colorSkin(BackForm pes)
        {
            InitializeComponent();
            cpes = pes;
            Init();
        }

        public void Init()
        {
            //int[,] colorArray = { { 253, 177, 174 }, { 212, 170, 224 }, { 253, 208, 234 }, { 253, 202, 178 }, { 233, 122, 124 }, { 254, 178, 195 }, { 251, 180, 121 }, { 216, 194, 236 }, { 236, 218, 235 }, { 178, 216, 252 }, { 184, 242, 140 }, { 139, 226, 217 }, { 215, 225, 230 }, { 212, 156, 185 }, { 235, 170, 182 }, { 177, 196, 252 }, { 243, 113, 171 }, { 35, 212, 254 }, { 60, 242, 177 }, { 252, 163, 113 }, { 49, 108, 156 }, { 202, 228, 231 }, { 101, 224, 222 }, { 65, 225, 211 } };
            Color[] colorArray = { Color.FromArgb(30,30,30),Color.Crimson,Color.OrangeRed,Color.FromArgb(236,109,113),Color.DarkOrange,Color.FromArgb(44, 169, 225),Color.FromArgb(0, 123, 180),Color.LightSeaGreen,Color.MediumSeaGreen,Color.Chartreuse,Color.GreenYellow, Color.YellowGreen,Color.Gold, Color.FromArgb(224, 224, 224),Color.FromArgb(231, 96, 158),Color.FromArgb(170, 76, 143),Color.DarkOrchid,Color.SlateBlue,Color.SteelBlue,Color.Teal,Color.MediumAquamarine,Color.FromArgb(56, 180, 139),Color.ForestGreen,Color.DarkGreen };
            for (int i = 1; i <= 24; i++)
            {
                DuiLabel dlc = new DuiLabel();
                //dlc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(colorArray[i - 1, 0])))), ((int)(((byte)(colorArray[i - 1, 1])))), ((int)(((byte)(colorArray[i - 1, 2])))));
                dlc.BackColor = colorArray[i - 1];
                dlc.Width = (Width - 44) / 12;
                dlc.Height = (base_main.Height - 14) / 2;
                dlc.Name = "color" + i.ToString();
                //根据循环数判断当前行及列
                int ColorColNum = (i % 12 == 0 ? 12 : i % 12);
                int ColorRowNum = (i - i % 12) / 12 + (i % 12 == 0 ? 0 : 1);
                dlc.Location = new Point(13 + ((ColorColNum - 1) * dlc.Width)+ColorColNum*2, 4 * (ColorRowNum) + ((ColorRowNum - 1) * dlc.Height));
                dlc.MouseClick += Dlc_MouseClick;
                base_main.DUIControls.Add(dlc);
            }
            tkb_skin.Value = Double.Parse(cpes.pes.Opacity);
            lb_skintr.Text = (tkb_skin.Value * 100).ToString("0") + "%";
            string[] imgsUrl = new Utils.PropertsUtils().BackImgsUrl;
            pictureBox1.Image = Image.FromFile(Utils.PicDeal.DownloaImage(imgsUrl[0]));
            pictureBox2.Image = Image.FromFile(Utils.PicDeal.DownloaImage(imgsUrl[1]));
            pictureBox3.Image = Image.FromFile(Utils.PicDeal.DownloaImage(imgsUrl[2]));
            pictureBox4.Image = Image.FromFile(Utils.PicDeal.DownloaImage(imgsUrl[3]));
            pictureBox5.Image = Image.FromFile(Utils.PicDeal.DownloaImage(imgsUrl[4]));
            pictureBox7.Image = Image.FromFile(Utils.PicDeal.DownloaImage(imgsUrl[5]));
            pictureBox8.Image = Image.FromFile(Utils.PicDeal.DownloaImage(imgsUrl[6]));
            pictureBox9.Image = Image.FromFile(Utils.PicDeal.DownloaImage(imgsUrl[7]));
        }

        private void Dlc_MouseClick(object sender, DuiMouseEventArgs e)
        {
            DuiLabel dlc = sender as DuiLabel;
            cpes.BackGroundSkin = null;
            cpes.pes.BackImg = "";
            cpes.pes.BackColor = Color.FromArgb((int)(255 * (tkb_skin.Value)), dlc.BackColor);
            cpes.pes.Opacity = tkb_skin.Value.ToString();
            cpes.setSkinStyle();
        }

        private void colorSkin_Deactivate(object sender, EventArgs e)
        {
            if (!dialoga)
            {
                if (cpes.pes.BackColor == Color.FromArgb(0, 255, 255, 255) || cpes.pes.BackColor == Color.Transparent)
                {
                    cpes.pes.BackColor = Color.FromArgb((int)(255 * (tkb_skin.Value)), 255, 92, 138);
                }
                cpes.pes.saveConfig();
                Close();
            }
        }

        private void btn_skinclose_Click(object sender, EventArgs e)
        {
            if (cpes.pes.BackColor == Color.FromArgb(0,255,255,255) || cpes.pes.BackColor == Color.Transparent)
            {
                cpes.pes.BackColor = Color.FromArgb((int)(255 * (tkb_skin.Value)), 255, 92, 138);
            }
            cpes.pes.saveConfig();
            Close();
        }

        private void tkb_skin_MouseUp(object sender, MouseEventArgs e)
        {
            lb_skintr.Text = (tkb_skin.Value * 100).ToString("0") + "%";
            if (cpes.BackGroundSkin != null)
            {
                cpes.pes.BackColor = Color.Transparent;
            }
            else
            {
                cpes.pes.BackColor = Color.FromArgb((int)(255 * (tkb_skin.Value)), cpes.pes.BackColor);
            }
            cpes.pes.Opacity = tkb_skin.Value.ToString();
            cpes.setSkinStyle();
        }

        private void tkb_skin_ValueChanged(object sender, EventArgs e)
        {
            lb_skintr.Text = (tkb_skin.Value * 100).ToString("0") + "%";
            if (cpes.BackGroundSkin != null)
            {
                cpes.pes.BackColor = Color.FromArgb((int)(255 * (tkb_skin.Value)), 255, 92, 138);
            }
            else
            {
                cpes.pes.BackColor = Color.FromArgb((int)(255 * (tkb_skin.Value)), cpes.pes.BackColor);
            }
            cpes.pes.Opacity = tkb_skin.Value.ToString();
            cpes.setSkinStyle();
        }

        private void panel1_Click(object sender, EventArgs e)
        {
            PictureBox pc = sender as PictureBox;
            cpes.pes.BackImg = pc.Name;
            cpes.pes.BackColor = Color.FromArgb((int)(255 * (tkb_skin.Value)), 255, 92, 138);
            cpes.setSkinStyle();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            dialoga = true;
            OpenFileDialog op = new OpenFileDialog();
            op.Filter = "图片文件|*.png;*.jpg;*.bmp";
            op.Title = "打开图片";
            if (op.ShowDialog() == DialogResult.OK)
            {
                cpes.BackGroundSkin = Image.FromFile(op.FileName);
                cpes.pes.BackImg = op.FileName;
                cpes.pes.BackColor = Color.FromArgb((int)(255 * (tkb_skin.Value)), 255, 92, 138);
                cpes.setSkinStyle();
                dialoga = false;
            }
        }
        private void pictureBox17_Click(object sender, EventArgs e)
        {
            dialoga = true;
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                cpes.pes.BackColor = Color.FromArgb((int)(255 * (tkb_skin.Value)), colorDialog1.Color);
                cpes.pes.BackImg = "";
                cpes.pes.Opacity = tkb_skin.Value.ToString();
                cpes.setSkinStyle();
                dialoga = false;
            }
        }
    }
}
