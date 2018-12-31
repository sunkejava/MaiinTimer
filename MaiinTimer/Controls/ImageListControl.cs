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
        BridImg bimg = new BridImg();
        
        #region 控件事件

        private void skinLine_MouseEnter(object sender, EventArgs e)
        {
            skinLine_Update();
            DuiLabel btn = sender as DuiLabel;
            if (btn.Name.Contains("ImageTypeName_"))
            {
                btn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(92)))), ((int)(((byte)(138)))));
            }
            else
            {
                btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(92)))), ((int)(((byte)(138)))));
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
                result.Result = bimg.getImageInfos((sender as DuiLabel).Tag.ToString(), "0", "30");
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
        #endregion

        #region 自定义事件
        private void skinLine_Update()
        {
            foreach (var itemControl in typeControl.Controls)
            {
                if (itemControl is DuiLabel)
                {
                    if ((itemControl as DuiLabel).Name.Contains("ImageTypeLine_"))
                    {
                        (itemControl as DuiLabel).BackColor = System.Drawing.Color.Silver;
                    }
                    if ((itemControl as DuiLabel).Name.Contains("ImageTypeName_"))
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

            typeControl.Size = new Size(this.Width, 35);
            typeControl.Name = "typeControl";
            for (int i = 0; i < imgJsons.data.Count; i++)
            {
                DuiLabel dlbe = new DuiLabel();
                dlbe.Size = new Size(60, 20);
                dlbe.Text = imgJsons.data[i].name;
                dlbe.Name = "ImageTypeName_" + imgJsons.data[i].id.ToString();
                dlbe.Location = new Point(60 * i, 5);
                dlbe.Cursor = System.Windows.Forms.Cursors.Hand;
                dlbe.MouseEnter += skinLine_MouseEnter;
                dlbe.TextAlign = ContentAlignment.MiddleCenter;
                dlbe.Tag = imgJsons.data[i].id;
                dlbe.MouseClick += Dlbe_MouseClick;

                DuiLabel dLabel1 = new DuiLabel();
                dLabel1.Name = "ImageTypeLine_" + imgJsons.data[i].id.ToString();
                dLabel1.Cursor = dlbe.Cursor;
                dLabel1.Size = new Size(60, 2);
                dLabel1.BackColor = System.Drawing.Color.Silver;
                dLabel1.Height = 2;
                dLabel1.MouseEnter += new System.EventHandler(this.skinLine_MouseEnter);
                dLabel1.Tag = imgJsons.data[i].id;
                dLabel1.Location = new Point(60 * i, 30);
                dLabel1.MouseClick += Dlbe_MouseClick;

                typeControl.BackColor = Color.White;
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
