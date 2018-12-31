using LayeredSkin.DirectUI;
using MaiinTimer.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace MaiinTimer.Controls
{
    /// <summary>
    /// 类    名: ImageListControl.cs
    /// CLR 版本: 4.0.30319.42000
    /// 作    者: sunkejava 
    /// 邮    箱：declineaberdeen@foxmail.com
    /// 创建时间: 2018/12/31 11:50:51
    /// 说    明：图片列表控件
    /// </summary>
    public class ImageListControl : LayeredSkin.Controls.LayeredListBox
    {
        DuiBaseControl typeControl = new DuiBaseControl();


       #region 控件事件

        private void skinLine_MouseEnter(object sender, EventArgs e)
        {
            skinLine_Update();
            DuiLabel btn = sender as DuiLabel;
            btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(92)))), ((int)(((byte)(138)))));
            //NowNum = int.Parse(btn.Tag.ToString());
            //LoadSliderImg(NowNum);
        }



        #endregion

        #region 自定义事件
        private void skinLine_Update()
        {
            if (typeControl.FindControl("ImageTypeLine_").Count > 0)
            {
                foreach (DuiBaseControl itemControl in typeControl.FindControl("ImageTypeLine_"))
                {
                    itemControl.BackColor = System.Drawing.Color.Silver;
                }
            }
        }
        /// <summary>
        /// 添加图片分类
        /// </summary>
        /// <param name="imgJsons"></param>
        /// <returns></returns>
        public bool addImgType(BridImg.ImgJson imgJsons)
        {

            typeControl.Size = new Size(this.Width, 50);
            for (int i = 0; i < imgJsons.data.Count; i++)
            {
                DuiLabel dlbe = new DuiLabel();
                dlbe.Size = new Size(60, 20);
                dlbe.Text = imgJsons.data[i].name;
                dlbe.Name = "ImageTypeName_" + imgJsons.data[i].id.ToString();
                dlbe.Location = new Point(60 * i, 0);
                dlbe.Cursor = System.Windows.Forms.Cursors.Hand;

                DuiLabel dLabel1 = new DuiLabel();
                dLabel1.Name = "ImageTypeLine_" + imgJsons.data[i].id.ToString();
                dLabel1.Cursor = dlbe.Cursor;
                dLabel1.Size = new Size(60, 2);
                dLabel1.BackColor = System.Drawing.Color.Silver;
                dLabel1.Height = 2;
                dLabel1.MouseEnter += new System.EventHandler(this.skinLine_MouseEnter);
                dLabel1.Tag = imgJsons.data[i].id;
                dLabel1.Location = new Point(60 * i, 25);

                typeControl.Controls.Add(dlbe);
                typeControl.Controls.Add(dLabel1);
            }
            Items.Add(typeControl);
            return true;
        }

        /// <summary>
        /// 添加图片列表
        /// </summary>
        /// <param name="imgInfos"></param>
        /// <returns></returns>
        public bool addImgList(List<BridImg.ImageInfo> imgInfos)
        {
            int thisWidth = this.Width - 5;//减去滚动条宽度
            DuiBaseControl baseControl = new DuiBaseControl();
            int zWidth = (int)(thisWidth / 3);
            int zHeight = (int)(thisWidth / 3 * 0.65);
            baseControl.Size = new Size(thisWidth, zHeight);
            baseControl.BackColor = Color.FromArgb(245, 245, 247);
            int i = 0;
            foreach (var imgInfo in imgInfos)
            {
                DuiBaseControl abaseControl = new DuiBaseControl();
                abaseControl.Size = new Size(zWidth, zHeight);
                abaseControl.Location = new Point(i * zWidth, 0);
                //背景图
                DuiPictureBox dp = new DuiPictureBox();
                dp.Size = new Size(zWidth - 4, zHeight - 4);
                dp.BackgroundImage = GetImageByUrl(imgInfo.img_1024_768);
                dp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                dp.Name = "back_" + imgInfo.id.ToString();
                dp.Location = new Point(2, 2);
                //图片说明
                DuiLabel imgTag = new DuiLabel();
                imgTag.TextRenderMode = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
                imgTag.Size = new Size(zWidth - 4, 20);
                imgTag.Font = new Font("微软雅黑", 9F, FontStyle.Regular);
                imgTag.ForeColor = Color.White;
                imgTag.TextAlign = ContentAlignment.MiddleCenter;
                imgTag.BackColor = Color.FromArgb(100, 0, 0, 0);
                imgTag.Text = imgInfo.utag;
                imgTag.Name = "tag" + imgInfo.id.ToString();
                imgTag.Location = new Point(2, zHeight - 22);

                Borders baseBorder = new Borders(baseControl);
                baseBorder.BottomWidth = 2;
                baseBorder.TopWidth = 2;
                baseBorder.LeftWidth = 2;
                baseBorder.RightWidth = 2;

                abaseControl.Borders = baseBorder;
                abaseControl.Controls.Add(dp);
                abaseControl.Controls.Add(imgTag);
                baseControl.Controls.Add(abaseControl);
                i++;
            }
            Items.Add(baseControl);
            //更新列表
            RefreshList();
            GC.Collect();
            return true;
        }

        #endregion



        private Image GetImageByUrl(string url)
        {
            System.Drawing.Image image = null;
            try
            {
                WebRequest webreq = WebRequest.Create(url);
                //红色部分为文件URL地址，这里是一张图片
                WebResponse webres = webreq.GetResponse();
                Stream stream = webres.GetResponseStream();
                image = System.Drawing.Image.FromStream(stream);
                stream.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return image;
        }

        /// <summary>
        /// 列表刷新
        /// </summary>
        public new void RefreshList()
        {
            if (RefreshListed != null)
                RefreshListed(this, new EventArgs());
            base.RefreshList();
        }

        #region 委托事件
        /// <summary>
        /// 刷新列表事件
        /// </summary>
        [Description("列表刷新事件"), Category("自定义事件")]
        public event EventHandler RefreshListed;
        [Description("列表点击事件"), Category("自定义事件")]
        public event EventHandler ImgListMouseDown;
        [Description("分类点击事件"), Category("自定义事件")]
        public event EventHandler ImgTypeMouseDown;

        #endregion


    }
}
