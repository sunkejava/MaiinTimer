﻿using LayeredSkin.DirectUI;
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
        BridImg bimg = new BridImg();
        string labelId = "";//选择的标签与类型ID
        string startNo = "0";//开始序号
        #region 控件事件

        private void skinLine_MouseEnter(object sender, EventArgs e)
        {
            skinLine_Update();
            DuiLabel btn = sender as DuiLabel;
            DuiBaseControl bControl = btn.Parent as DuiBaseControl;
            if (btn.Name.Contains("ImageTypeName_"))
            {
                btn.ForeColor = System.Drawing.Color.FromArgb(255,92,138);
                foreach (var item in bControl.FindControl("ImageTypeLine_" + btn.Tag.ToString()))
                {
                    if (item is DuiLabel)
                    {
                        item.BackColor = System.Drawing.Color.FromArgb(255, 92, 138);
                    }
                }
            }
            else
            {
                btn.BackColor = System.Drawing.Color.FromArgb(255, 92, 138);
                foreach (var item in bControl.FindControl("ImageTypeName_" + btn.Tag.ToString()))
                {
                    if (item is DuiLabel)
                    {
                        item.ForeColor = System.Drawing.Color.FromArgb(255, 92, 138);
                    }
                }
            }
            foreach (var item in bControl.FindControl("ImageTypeGrid_" + btn.Tag.ToString()))
            {
                if (item is DuiBaseControl)
                {
                    item.Visible = true;
                }
            }

            //NowNum = int.Parse(btn.Tag.ToString());
            //LoadSliderImg(NowNum);
        }
        /// <summary>
        /// 图片列表失去焦点后的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Dp_MouseLeave(object sender, EventArgs e)
        {
            DuiBaseControl dp = null;
            string strId = "";
            if (sender is DuiBaseControl)
            {
                dp = sender as DuiBaseControl;
            }
            if (sender is DuiButton)
            {
                dp = (sender as DuiButton).Parent as DuiBaseControl;
                strId = (sender as DuiButton).Name.Replace("btn_Download_", "").Replace("btn_Setting_", "");
            }
            if (sender is DuiPictureBox)
            {
                strId = (sender as DuiPictureBox).Name.Replace("back_", "");
                dp = (sender as DuiPictureBox).Parent as DuiBaseControl;
            }
            //显示说明
            if (dp.FindControl("imgTag_" + strId).Count > 0)
            {
                DuiLabel dl = (DuiLabel)dp.FindControl("imgTag_" + strId)[0];
                //dl.Visible = true;
                dl.Location = new Point(2, dp.Height - 22);
            }
            //隐藏下载与设置按钮
            if (dp.FindControl("btn_Download_" + strId).Count > 0)
            {
                DuiButton ldl = (DuiButton)dp.FindControl("btn_Download_" + strId)[0];
                ldl.Visible = false;
            }
            if (dp.FindControl("btn_Setting_" + strId).Count > 0)
            {
                DuiButton ldb = (DuiButton)dp.FindControl("btn_Setting_" + strId)[0];
                ldb.Visible = false;
            }
        }
        /// <summary>
        /// 图片列表获取焦点后的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Dp_MouseEnter(object sender, EventArgs e)
        {
            DuiBaseControl dp = null;
            string strId = "";
            if (sender is DuiBaseControl)
            {
                dp = sender as DuiBaseControl;
            }
            if (sender is DuiButton)
            {
                dp = (sender as DuiButton).Parent as DuiBaseControl;
                strId = (sender as DuiButton).Name.Replace("btn_Download_", "").Replace("btn_Setting_", "");
            }
            if (sender is DuiPictureBox)
            {
                strId = (sender as DuiPictureBox).Name.Replace("back_", "");
                dp = (sender as DuiPictureBox).Parent as DuiBaseControl;   
            }
            //隐藏说明
            if (dp.FindControl("imgTag_" + strId).Count > 0)
            {
                DuiLabel dl = (DuiLabel)dp.FindControl("imgTag_" + strId)[0];
                //dl.Visible = false;
                dl.Location = new Point(2, 2);
            }
            //显示下载与设置按钮
            if (dp.FindControl("btn_Download_" + strId).Count > 0)
            {
                DuiButton ldl = (DuiButton)dp.FindControl("btn_Download_" + strId)[0];
                ldl.Visible = true;
            }
            if (dp.FindControl("btn_Setting_" + strId).Count > 0)
            {
                DuiButton ldb = (DuiButton)dp.FindControl("btn_Setting_" + strId)[0];
                ldb.Visible = true;
            }
        }
        /// <summary>
        /// 设置按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Setting_MouseClick(object sender, DuiMouseEventArgs e)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 下载按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Download_MouseClick(object sender, DuiMouseEventArgs e)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 图片类型点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Dlbe_MouseClick(object sender, DuiMouseEventArgs e)
        {
            if (!string.IsNullOrEmpty((sender as DuiLabel).Tag.ToString()))
            {
                labelId = (sender as DuiLabel).Tag.ToString();
                List<DuiBaseControl> cItems = new List<DuiBaseControl>();
                foreach (var item in Items)
                {
                    if (item is DuiBaseControl)
                    {
                        if ((item as DuiBaseControl).Name.Contains("imgListBaseControl_"))
                        {
                            cItems.Add((item as DuiBaseControl));
                        }
                    }
                }
                foreach (var item in cItems)
                {
                    Items.Remove(item);
                }
                cItems.Clear();
                var result = new Utils.Response<BridImg.ImageJson>();
                List<BridImg.ImageInfo> imgInfos = new List<BridImg.ImageInfo>();
                result.Result = bimg.getImageInfos((sender as DuiLabel).Tag.ToString(), "0", "9");
                for (int i = 0; i < result.Result.data.Count; i++)
                {
                    int zi = i + 1;
                    imgInfos.Add(result.Result.data[i]);
                    if (zi % 3 == 0)
                    {
                        addImgList(imgInfos);
                        imgInfos.Clear();
                    }
                }
            }
        }
        private void Dlbe_MouseLeave(object sender, EventArgs e)
        {
            skinLine_Update();
            DuiLabel btn = sender as DuiLabel;
            DuiBaseControl bControl = btn.Parent as DuiBaseControl;
            foreach (var item in bControl.FindControl("ImageTypeGrid_" + btn.Tag.ToString()))
            {
                if (item is DuiBaseControl)
                {
                    item.Visible = false;
                }
            }
        }

        #endregion

        #region 自定义事件
        private void skinLine_Update()
        {
            foreach (var itemControl in typeControl.Controls)
            {
                if (itemControl is DuiLabel)
                {
                    if ((itemControl as DuiLabel).Name.Contains("ImageTypeLine_") && (itemControl as DuiLabel).Tag.ToString() != labelId)
                    {
                        (itemControl as DuiLabel).BackColor = System.Drawing.Color.Silver;
                    }
                    if ((itemControl as DuiLabel).Name.Contains("ImageTypeName_") && (itemControl as DuiLabel).Tag.ToString() != labelId)
                    {
                        (itemControl as DuiLabel).ForeColor = System.Drawing.Color.Black;
                    }
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
            //获取热门标签
            BridImg.ImageTags imgTags = bimg.getImageHotTags();
            List<BridImg.TagStringId> tagStrId = new List<BridImg.TagStringId>();
            List<BridImg.tagItem> tagsList = new List<BridImg.tagItem>();
            tagStrId.Add(new BridImg.TagStringId("5", "gameImg"));
            tagStrId.Add(new BridImg.TagStringId("6", "mnmtImg"));
            tagStrId.Add(new BridImg.TagStringId("7", "ysjzImg"));
            tagStrId.Add(new BridImg.TagStringId("9", "fjdpImg"));
            tagStrId.Add(new BridImg.TagStringId("10", "kxssImg"));
            tagStrId.Add(new BridImg.TagStringId("11", "mxfsImg"));
            tagStrId.Add(new BridImg.TagStringId("12", "qctxImg"));
            tagStrId.Add(new BridImg.TagStringId("14", "mcdwImg"));
            tagStrId.Add(new BridImg.TagStringId("15", "xqxImg"));
            tagStrId.Add(new BridImg.TagStringId("16", "jbtyImg"));
            tagStrId.Add(new BridImg.TagStringId("22", "jstdImg"));
            tagStrId.Add(new BridImg.TagStringId("26", "dmktImg"));
            tagStrId.Add(new BridImg.TagStringId("30", "aqmtImg"));
            typeControl.Size = new Size(this.Width, 35);
            typeControl.Name = "typeControl";
            //循环增加分类
            for (int i = 0; i < imgJsons.data.Count; i++)
            {
                DuiLabel dlbe = new DuiLabel();
                dlbe.Size = new Size(60, 20);
                dlbe.Text = imgJsons.data[i].name;
                dlbe.Name = "ImageTypeName_" + imgJsons.data[i].id.ToString();
                dlbe.Location = new Point(60 * i, 5);
                dlbe.Cursor = System.Windows.Forms.Cursors.Hand;
                dlbe.MouseEnter += skinLine_MouseEnter;
                dlbe.MouseLeave += Dlbe_MouseLeave;
                dlbe.TextAlign = ContentAlignment.MiddleCenter;
                dlbe.Tag = imgJsons.data[i].id;
                dlbe.MouseClick += Dlbe_MouseClick;

                DuiLabel dLabel1 = new DuiLabel();
                dLabel1.Name = "ImageTypeLine_" + imgJsons.data[i].id.ToString();
                dLabel1.Cursor = dlbe.Cursor;
                dLabel1.Size = new Size(60, 2);
                dLabel1.BackColor = System.Drawing.Color.Silver;
                dLabel1.Height = 2;
                dLabel1.MouseEnter += skinLine_MouseEnter;
                dLabel1.MouseLeave += Dlbe_MouseLeave;
                dLabel1.Tag = imgJsons.data[i].id;
                dLabel1.Location = new Point(60 * i, 30);
                dLabel1.MouseClick += Dlbe_MouseClick;

                typeControl.Controls.Add(dlbe);
                typeControl.Controls.Add(dLabel1);
                //是否增加下签
                foreach (BridImg.TagStringId item in tagStrId)
                {
                    switch (item.tagString)
                    {
                        case "gameImg":
                            tagsList = imgTags.gameImg;
                            break;
                        case "aqmtImg":
                            tagsList = imgTags.aqmtImg;
                            break;
                        case "dmktImg":
                            tagsList = imgTags.dmktImg;
                            break;
                        case "fjdpImg":
                            tagsList = imgTags.fjdpImg;
                            break;
                        case "jbtyImg":
                            tagsList = imgTags.jbtyImg;
                            break;
                        case "jstdImg":
                            tagsList = imgTags.jstdImg;
                            break;
                        case "kxssImg":
                            tagsList = imgTags.kxssImg;
                            break;
                        case "mcdwImg":
                            tagsList = imgTags.mcdwImg;
                            break;
                        case "mnmtImg":
                            tagsList = imgTags.mnmtImg;
                            break;
                        case "mxfsImg":
                            tagsList = imgTags.mxfsImg;
                            break;
                        case "qctxImg":
                            tagsList = imgTags.qctxImg;
                            break;
                        case "xqxImg":
                            tagsList = imgTags.xqxImg;
                            break;
                        default:
                            tagsList = imgTags.ysjzImg;
                            break;
                    }
                    if (item.tagId == imgJsons.data[i].id.ToString())
                    {
                        DuiBaseControl ltypeControl = new DuiBaseControl();
                        ltypeControl.Size = new Size(124,tagsList.Count*24/2);
                        ltypeControl.Name = "ImageTypeGrid_"+item.tagId;
                        ltypeControl.Location = new Point(60*i,25);
                        ltypeControl.Visible = false;
                        ltypeControl.BackColor = Color.White;
                        int rowi = 1;
                        int coli = 1;
                        int ti = 1;
                        foreach (BridImg.tagItem citem in tagsList)
                        {
                            coli = (ti % 2 == 0 ? 2 : 1);
                            rowi = (int)Math.Ceiling(((double)ti/2));
                            DuiLabel dlbea = new DuiLabel();
                            dlbea.Size = new Size(60, 20);
                            dlbea.Text = citem.tagName;
                            dlbea.Name = "ImageTypeNameOther_" + citem.tagName;
                            dlbea.Location = new Point(60 * (coli-1), 21*(rowi-1));
                            dlbea.Cursor = System.Windows.Forms.Cursors.Hand;
                            //dlbea.MouseEnter += skinLine_MouseEnter;
                            //dlbea.MouseLeave += Dlbe_MouseLeave;
                            dlbea.TextAlign = ContentAlignment.MiddleCenter;
                            dlbea.Tag = citem.tagName;
                            //dlbea.MouseClick += Dlbe_MouseClick;
                            ltypeControl.Controls.Add(dlbea);
                            ti++;
                        }
                        typeControl.Controls.Add(ltypeControl);
                    }
                }
                typeControl.BackColor = Color.White;
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
            int zWidth = (int)(thisWidth / 3);
            int zHeight = (int)(thisWidth / 3 * 0.65);
            DuiBaseControl baseControl = new DuiBaseControl();
            baseControl.Size = new Size(thisWidth, zHeight);
            baseControl.BackColor = Color.FromArgb(245, 245, 247);
            int i = 0;
            foreach (var imgInfo in imgInfos)
            {
                DuiBaseControl abaseControl = new DuiBaseControl();
                abaseControl.Size = new Size(zWidth, zHeight);
                abaseControl.Location = new Point(i * zWidth, 0);
                abaseControl.Name = "back_" + imgInfo.id.ToString();
                //背景图
                DuiPictureBox dp = new DuiPictureBox();
                dp.Size = new Size(zWidth - 4, zHeight - 4);
                dp.BackgroundImage = GetImageByUrl(imgInfo.img_1024_768);
                dp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                dp.Name = "back_" + imgInfo.id.ToString();
                dp.Location = new Point(2, 2);
                dp.Cursor = System.Windows.Forms.Cursors.Hand;
                dp.MouseEnter += Dp_MouseEnter;
                dp.MouseLeave += Dp_MouseLeave;
                //图片说明
                DuiLabel imgTag = new DuiLabel();
                imgTag.TextRenderMode = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
                imgTag.Size = new Size(zWidth - 4, 20);
                imgTag.Font = new Font("微软雅黑", 9F, FontStyle.Regular);
                imgTag.ForeColor = Color.White;
                imgTag.TextAlign = ContentAlignment.MiddleCenter;
                imgTag.BackColor = Color.FromArgb(100, 0, 0, 0);
                imgTag.Text = imgInfo.utag;
                imgTag.Name = "imgTag_" + imgInfo.id.ToString();
                imgTag.Location = new Point(2, zHeight - 22);
                imgTag.Cursor = System.Windows.Forms.Cursors.Hand;
                //下载按钮
                DuiButton btn_Download = new DuiButton();
                btn_Download.Location = new Point(zWidth - 4 - 60, zHeight - 4 - 20);
                btn_Download.Size = new Size(20, 20);
                btn_Download.Cursor = System.Windows.Forms.Cursors.Hand;
                btn_Download.NormalImage = Properties.Resources.download;
                btn_Download.AdaptImage = false;
                btn_Download.Name = "btn_Download_"+imgInfo.id.ToString();
                btn_Download.BackColor = Color.Transparent;
                btn_Download.ShowBorder = false;
                btn_Download.MouseEnter += Dp_MouseEnter;
                btn_Download.MouseLeave += Dp_MouseLeave;
                btn_Download.MouseClick += Btn_Download_MouseClick;
                btn_Download.Visible = false;
                //设置按钮
                DuiButton btn_Setting = new DuiButton();
                btn_Setting.Location = new Point(zWidth - 4 - 20, zHeight - 4 - 20);
                btn_Setting.Size = new Size(20, 20);
                btn_Setting.Cursor = System.Windows.Forms.Cursors.Hand;
                btn_Setting.NormalImage = Properties.Resources.seting;
                btn_Setting.AdaptImage = false;
                btn_Setting.Name = "btn_Setting_" + imgInfo.id.ToString();
                btn_Setting.BackColor = Color.Transparent;
                btn_Setting.ShowBorder = false;
                btn_Setting.MouseEnter += Dp_MouseEnter;
                btn_Setting.MouseLeave += Dp_MouseLeave;
                btn_Setting.MouseClick += Btn_Setting_MouseClick;
                btn_Setting.Visible = false;

                Borders baseBorder = new Borders(baseControl);
                baseBorder.BottomWidth = 2;
                baseBorder.TopWidth = 2;
                baseBorder.LeftWidth = 2;
                baseBorder.RightWidth = 2;

                abaseControl.Borders = baseBorder;
                abaseControl.Controls.Add(dp);
                abaseControl.Controls.Add(imgTag);
                abaseControl.Controls.Add(btn_Download);
                abaseControl.Controls.Add(btn_Setting);
                baseControl.Controls.Add(abaseControl);
                i++;
            }
            baseControl.Name = "imgListBaseControl_" + imgInfos[0].id.ToString();
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
