﻿using LayeredSkin.DirectUI;
using MaiinTimer.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;

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
        BridImg bimg = new BridImg();
        ToolTip toolTip1 = new ToolTip();
        int x, y;//记录鼠标进入控件时的位置
        Color defaultColor = Color.FromArgb(125, 255, 92, 138);
        int cheight = 0;
        EllipseControl ctEnd = null;
        public delegate Image getImageByUIrlDelegate(string url, int zWidth, int zHeight);
        #region 控件事件

        /// <summary>
        /// 图片列表失去焦点后的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Dp_MouseLeave(object sender, EventArgs e)
        {
            Point ms = Control.MousePosition;
            if (ms.Y != y || (ms.X != x))
            {
                DuiBaseControl dp = null;
                string strId = "";
                if (sender is DuiBaseControl)
                {
                    dp = sender as DuiBaseControl;
                    if (dp.Name.Contains("btnBaseControl_"))
                    {
                        strId = (dp != null ? dp.Name.Replace("btnBaseControl_", "") : "");
                    }
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
                //隐藏按钮
                if (dp.FindControl("btnBaseControl_" + strId).Count > 0)
                {
                    DuiBaseControl ldl = dp.FindControl("btnBaseControl_" + strId)[0];
                    if (!ldl.IsMouseEnter)
                    {
                        ldl.Visible = false;
                        //显示说明
                        if (dp.FindControl("imgTag_" + strId).Count > 0)
                        {
                            DuiLabel dl = (DuiLabel)dp.FindControl("imgTag_" + strId)[0];
                            dl.Visible = true;
                        }
                    }
                }
            }
        }
        /// <summary>
        /// 图片列表获取焦点后的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Dp_MouseEnter(object sender, EventArgs e)
        {
            Point ms = Control.MousePosition;
            x = ms.X;
            y = ms.Y;
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
                dl.Visible = false;
                //dl.Location = new Point(2, 2);
            }
            //显示按钮
            if (dp.FindControl("btnBaseControl_" + strId).Count > 0)
            {
                DuiBaseControl ldl = dp.FindControl("btnBaseControl_" + strId)[0];
                ldl.Visible = true;
            }
        }
        /// <summary>
        /// 设置按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Setting_MouseClick(object sender, DuiMouseEventArgs e)
        {
            Btn_Download_MouseClick(sender, e);
        }
        /// <summary>
        /// 下载按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Download_MouseClick(object sender, DuiMouseEventArgs e)
        {
            //下载文件
            DuiButton dbn = sender as DuiButton;
            string url = dbn.Tag.ToString().Split('|')[1].ToString();
            string fileName = AppDomain.CurrentDomain.BaseDirectory + @"ImageWallpaper\";
            if (!Directory.Exists(fileName))
            {
                Directory.CreateDirectory(fileName);
            }
            fileName = fileName + new Uri(url).Segments[new Uri(url).Segments.Length - 1];
            Thread thread = new Thread(() => DownloaImage(fileName,url,dbn.Name));
            thread.Start();
        }

        private void Btn_Download_MouseLeave(object sender, EventArgs e)
        {
            toolTip1.Hide(this);
        }

        private void Btn_Download_MouseEnter(object sender, EventArgs e)
        {
            toolTip1.Show(((DuiButton)sender).Tag.ToString().Split('|')[0].ToString() + (((DuiButton)sender).Tag.ToString().Split('|')[0].ToString().Contains("取消") ? "" : "壁纸"), this, PointToClient(MousePosition).X, PointToClient(MousePosition).Y + 15, 2000);
        }


        /// <summary>
        /// 收藏按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Sc_MouseClick(object sender, DuiMouseEventArgs e)
        {
            DuiButton btn = sender as DuiButton;
            if (btn.Tag.ToString().Split('|')[0].ToString() == "收藏")
            {
                btn.BackgroundImage = Properties.Resources.sc1;
                btn.Tag = "取消收藏|" +btn.Tag.ToString().Split('|')[1].ToString();
            }
            else
            {
                btn.BackgroundImage = Properties.Resources.sc0;
                btn.Tag = "收藏|" + btn.Tag.ToString().Split('|')[1].ToString();
            }
        }
        /// <summary>
        /// 图片点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Dp_MouseClick(object sender, DuiMouseEventArgs e)
        {
            DuiPictureBox dp = sender as DuiPictureBox;
            string ImageSavePath = AppDomain.CurrentDomain.BaseDirectory + @"\ImageWallpaper";
            //设置墙纸
            try
            {
                Bitmap bmpWallpaper;
                WebRequest webreq = WebRequest.Create(dp.Tag.ToString());
                WebResponse webres = webreq.GetResponse();
                Stream stream = webres.GetResponseStream();
                if (!Directory.Exists(ImageSavePath))
                {
                    Directory.CreateDirectory(ImageSavePath);
                }
                bmpWallpaper = (Bitmap)Image.FromStream(stream);
                ImageSavePath = ImageSavePath + "\\" + new Uri(dp.Tag.ToString()).Segments[new Uri(dp.Tag.ToString()).Segments.Length-1];
                bmpWallpaper.Save(ImageSavePath, ImageFormat.Jpeg);
                stream.Close();
                setWallpaperApi(ImageSavePath);
            }
            catch (Exception ex)
            {
                throw new Exception("下载图片失败，原因为：" + ex.Message);
            }
        }

        private void BtnBaseControl_MouseMove(object sender, DuiMouseEventArgs e)
        {
            Point ms = Control.MousePosition;
            x = ms.X;
            y = ms.Y;
        }
        #endregion

        #region 自定义事件
        /// <summary>
        /// 添加图片列表
        /// </summary>
        /// <param name="imgInfos"></param>
        /// <returns></returns>
        public Boolean AddImgList(List<BridImg.ImageInfo> imgInfos)
        {
                if (imgInfos.Count == 0)
                {
                    return false;
                }
                int thisWidth = this.Width - 5;//减去滚动条宽度
                int zWidth = (int)(thisWidth / 3);
                int zHeight = (int)(thisWidth / 3 * 0.57);
                DuiBaseControl baseControl = new DuiBaseControl();
                baseControl.Size = new Size(thisWidth, zHeight);
                baseControl.BackColor = Color.FromArgb(245, 245, 247);
                int i = 0;
                string baseID = "0";
                foreach (var imgInfo in imgInfos)
                {
                    baseID = imgInfo.id.ToString();
                    DuiBaseControl abaseControl = new DuiBaseControl();
                    abaseControl.Size = new Size(zWidth, zHeight);
                    abaseControl.Location = new Point(i * zWidth, 0);
                    abaseControl.Name = "back_" + imgInfo.id.ToString();
                    //背景图
                    DuiPictureBox dp = new DuiPictureBox();
                    dp.Size = new Size(zWidth - 4, zHeight - 4);
                    int thisWidthScreen = Screen.PrimaryScreen.Bounds.Width;
                    int thisHeiightScreen = Screen.PrimaryScreen.Bounds.Height;
                    dp.Tag = imgInfo.img_1280_1024;
                    getImageByUIrlDelegate newg = new getImageByUIrlDelegate(GetImageByUrlDrawLetter);
                    dp.BackgroundImage = newg(imgInfo.url.Replace("__85", "300_161_100"), zWidth - 4, zHeight - 4);
                    dp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                    dp.Name = "back_" + imgInfo.id.ToString();
                    dp.Location = new Point(2, 2);
                    //dp.Cursor = System.Windows.Forms.Cursors.Hand;
                    dp.MouseEnter += Dp_MouseEnter;
                    dp.MouseLeave += Dp_MouseLeave;
                    //dp.MouseClick += Dp_MouseClick;
                    //图片说明
                    DuiLabel imgTag = new DuiLabel();
                    imgTag.TextRenderMode = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
                    string ingTxt = (string.IsNullOrEmpty(imgInfo.utag) ? "" : imgInfo.utag);
                    if (ingTxt.Length * 9 > zWidth)
                    {
                        imgTag.Size = new Size(zWidth-4, 10*4);
                        imgTag.Location = new Point(2, zHeight - 43);
                    }
                    else
                    {
                        imgTag.Size = new Size(zWidth-4, 10*2);
                        imgTag.Location = new Point(2, zHeight - 23);
                    }
                    imgTag.Font = new Font("微软雅黑", 9F, FontStyle.Regular);
                    imgTag.ForeColor = Color.White;
                    imgTag.TextAlign = ContentAlignment.MiddleCenter;
                    //imgTag.BackColor = Color.FromArgb(100, 0, 0, 0);
                    imgTag.BackgroundImage = Properties.Resources.mask_shadow;
                    imgTag.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                    imgTag.Text = imgInfo.utag;
                    imgTag.Name = "imgTag_" + imgInfo.id.ToString();
                    imgTag.MouseLeave += Dp_MouseLeave;

                    imgTag.Cursor = System.Windows.Forms.Cursors.Hand;
                    //下载按钮
                    DuiButton btn_Download = new DuiButton();
                    btn_Download.Size = new Size(35, 35);
                    btn_Download.Radius = 35;
                    btn_Download.Name = "btn_Download_" + imgInfo.id.ToString();
                    btn_Download.Text = "";
                    btn_Download.Location = new Point(0, 0);
                    btn_Download.Cursor = System.Windows.Forms.Cursors.Hand;
                    btn_Download.AdaptImage = false;
                    btn_Download.IsPureColor = true;
                    btn_Download.BaseColor = Color.Transparent;
                    btn_Download.BackgroundImage = Properties.Resources.dl;
                    btn_Download.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
                    btn_Download.ShowBorder = false;
                    btn_Download.MouseClick += Btn_Download_MouseClick;
                    btn_Download.Tag = "保存|"+imgInfo.url_thumb;
                    btn_Download.MouseEnter += Btn_Download_MouseEnter;
                    btn_Download.MouseLeave += Btn_Download_MouseLeave;
                    //收藏按钮
                    DuiButton btn_sc = new DuiButton();
                    btn_sc.Location = new Point(35, 0);
                    btn_sc.Size = new Size(35, 35);
                    btn_sc.Text = "";
                    btn_sc.Cursor = System.Windows.Forms.Cursors.Hand;
                    btn_sc.AdaptImage = false;
                    btn_sc.Name = "btn_Sc_" + imgInfo.id.ToString();
                    btn_sc.BaseColor = Color.Transparent;//Color.FromArgb(100, 0, 0, 0);
                    btn_sc.Radius = 35;
                    btn_sc.ShowBorder = false;
                    btn_sc.BackgroundImage = Properties.Resources.sc0;
                    btn_sc.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
                    btn_sc.MouseClick += Btn_Sc_MouseClick;
                    btn_sc.IsPureColor = true;
                    btn_sc.Tag = "收藏|" + imgInfo.url_thumb;
                    btn_sc.MouseEnter += Btn_Download_MouseEnter;
                    btn_sc.MouseLeave += Btn_Download_MouseLeave;
                    //设置按钮
                    DuiButton btn_Setting = new DuiButton();
                    btn_Setting.Location = new Point(70, 0);
                    btn_Setting.Size = new Size(35, 35);
                    btn_Setting.Text = "";
                    btn_Setting.Cursor = System.Windows.Forms.Cursors.Hand;
                    btn_Setting.AdaptImage = false;
                    btn_Setting.Name = "btn_Setting_" + imgInfo.id.ToString();
                    btn_Setting.BaseColor = Color.Transparent;//Color.FromArgb(100, 0, 0, 0);
                    btn_Setting.Radius = 35;
                    btn_Setting.Tag = "设置|" + imgInfo.url_thumb;
                    btn_Setting.ShowBorder = false;
                    btn_Setting.BackgroundImage = Properties.Resources.set;
                    btn_Setting.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
                    btn_Setting.MouseClick += Btn_Setting_MouseClick;
                    btn_Setting.IsPureColor = true;
                    btn_Setting.MouseEnter += Btn_Download_MouseEnter;
                    btn_Setting.MouseLeave += Btn_Download_MouseLeave;
                    //按钮底层控件
                    DuiBaseControl btnBaseControl = new DuiBaseControl();
                    btnBaseControl.Size = new Size(zWidth/3,35);
                    btnBaseControl.Cursor = System.Windows.Forms.Cursors.Hand;
                    btnBaseControl.Location = new Point(zWidth / 3 * 2 - 12,zHeight - 52);
                    btnBaseControl.BackColor = Color.Transparent;
                    //btnBaseControl.MouseEnter += Dp_MouseEnter;
                    btnBaseControl.MouseLeave += Dp_MouseLeave;
                    btnBaseControl.MouseMove += BtnBaseControl_MouseMove;
                    btnBaseControl.Controls.Add(btn_Download);
                    btnBaseControl.Controls.Add(btn_sc);
                    btnBaseControl.Controls.Add(btn_Setting);
                    btnBaseControl.Name = "btnBaseControl_"+ imgInfo.id.ToString();
                    btnBaseControl.Visible = false;

                    Borders baseBorder = new Borders(baseControl);
                    baseBorder.BottomWidth = 2;
                    baseBorder.TopWidth = 2;
                    baseBorder.LeftWidth = 2;
                    baseBorder.RightWidth = 2;

                    abaseControl.Borders = baseBorder;
                    abaseControl.Controls.Add(dp);
                    abaseControl.Controls.Add(imgTag);
                    abaseControl.Controls.Add(btnBaseControl);
                    baseControl.Controls.Add(abaseControl);
                    i++;
                }
                baseControl.Name = "imgListBaseControl_" + baseID;
                Items.Add(baseControl);
                //更新列表
                RefreshList();
                GC.Collect();
                return true;
        }
        /// <summary>
        /// 添加底线控件
        /// </summary>
        /// <returns></returns>
        public bool addIsEndLine()
        {
            try
            {
                //待实现动态底线显示，提示已加载至尾部
                //DuiBaseControl abaseControl = new DuiBaseControl();
                //abaseControl.Size = new Size(this.Width-5, 40);
                //abaseControl.Location = new Point(0, 0);
                //abaseControl.Name = "imgListBaseControl_backup";

                //DuiLabel dt = new DuiLabel();
                //dt.Size = new Size(350,35);
                //dt.Text = "啊哦，已经是最后一页了！";
                //dt.Location = new Point((this.Width - 5 - 350) / 2,2);
                //dt.Font = new Font("微软雅黑", 15F, FontStyle.Regular);
                //dt.ForeColor = Color.DarkCyan;
                //this.BackColor = Color.White;
                int zHeight = 80;
                //abaseControl.Controls.Add(dt);
                ctEnd = new EllipseControl();
                ctEnd.Size = new Size(this.Width-5, zHeight);
                ctEnd.Location = new Point(0, 0);
                ctEnd.Name = "backControlC";//"imgListBaseControl_backup";
                ctEnd.StrValue = "啊哦，已经是最后一页了！";
                
                cheight = zHeight-15;
                System.Windows.Forms.Timer ctm = new System.Windows.Forms.Timer();
                ctm.Interval = 50;
                ctm.Enabled = true;
                ctm.Tick += Ctm_Tick;
                //Items.Add(ctEnd);
                //更新列表
                RefreshList();
                GC.Collect();
                return true;
            }
            catch (Exception e)
            {
                throw new Exception("底线绘制失败，原因为：" + e.Message);
            }
        }

        private void Ctm_Tick(object sender, EventArgs e)
        {
            if (cheight >= 10)
            {
                ctEnd.Visible = true;
                ctEnd.CenterPotion = new Point(ctEnd.CenterPotion.X, cheight);
                cheight = cheight - 5;
                //ctEnd.Refresh();
            }
            else
            {
                System.Windows.Forms.Timer tm = sender as System.Windows.Forms.Timer;
                tm.Enabled = false;
                cheight = ctEnd.Height;
                ctEnd.Visible = false;
                //ctEnd.Refresh();
            }
        }

        public bool addIsNull()
        {
            try
            {
                this.BackColor = Color.White;
                DuiBaseControl abaseControl = new DuiBaseControl();
                abaseControl.Size = new Size(this.Width - 5, this.Height);
                abaseControl.Location = new Point(0, 0);
                abaseControl.Name = "imgListBaseControl_backnull";
                Items.Add(abaseControl);
                //更新列表
                RefreshList();
                GC.Collect();
                //背景图
                DuiPictureBox dp = new DuiPictureBox();
                dp.Size = new Size(510, 109);
                dp.BackgroundImage = Properties.Resources.bnull;
                dp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                dp.Name = "back_pnull";
                dp.Location = new Point((this.Width - 5 - 510)/2, (this.Height - 2 - 109) / 2);
                abaseControl.Controls.Add(dp);
                
                Items.Add(abaseControl);
                //更新列表
                RefreshList();
                GC.Collect();
                return true;
            }
            catch (Exception e)
            {

                throw new Exception("未搜索到内容，原因为：" + e.Message);
            }
        }
        #region 利用系统接口设置壁纸
        [DllImport("user32.dll", EntryPoint = "SystemParametersInfo")]
        public static extern int SystemParametersInfo(
                int uAction,
                int uParam,
                string lpvParam,
                int fuWinIni
                );
        public static void setWallpaperApi(string strSavePath)
        {
            SystemParametersInfo(20, 1, strSavePath, 1);
        }
        #endregion

        /// <summary>
        /// 获取图片并添加水印
        /// </summary>
        /// <param name="url">图片地址</param>
        /// <param name="zWidth">宽</param>
        /// <param name="zHeight">高</param>
        /// <returns></returns>
        private Image GetImageByUrlDrawLetter(string url, int zWidth, int zHeight)
        {
            //去除添加水印操作，部分索引格式像素图片报错
            //string letter = "@sunkejava";
            //int fontSize = 8;
            System.Drawing.Image image = null;
            try
            {
                System.Net.WebRequest webreq = System.Net.WebRequest.Create(url);
                System.Net.WebResponse webres = webreq.GetResponse();
                using (System.IO.Stream stream = webres.GetResponseStream())
                {
                    image = Image.FromStream(stream);
                    //Graphics gs = Graphics.FromImage(image);
                    //Font font = new Font("宋体", fontSize);
                    //Brush br = new SolidBrush(Color.White);
                    //gs.DrawString(letter, font, br, zWidth - (fontSize * letter.Length), zHeight - fontSize - 5);
                    //gs.Dispose();
                    return image;
                }
            }
            catch (Exception ex)
            {

                throw new Exception("获取图片失败，原因为：" + ex.Message);
            }
            finally
            {
                //image.Dispose();
            }
        }
        private Image GetImageByUrl(string url,int zWidth,int zHeight)
        {
            System.Drawing.Image image = null;
            HttpWebRequest req;
            HttpWebResponse res = null;
            try
            {
                System.Uri httpUrl = new System.Uri(url);
                string saveUrl = System.AppDomain.CurrentDomain.BaseDirectory + "\\picTemp\\";
                if (!Directory.Exists(saveUrl))
                {
                    Directory.CreateDirectory(saveUrl);
                }
                string rImgPath = System.AppDomain.CurrentDomain.BaseDirectory + "\\picMixTemp\\";
                if (!Directory.Exists(rImgPath))
                {
                    Directory.CreateDirectory(rImgPath);
                }
                saveUrl = saveUrl + httpUrl.Segments[httpUrl.Segments.Length - 1];
                rImgPath = rImgPath + httpUrl.Segments[httpUrl.Segments.Length - 1];
                //下载原图
                req = (HttpWebRequest)(WebRequest.Create(httpUrl));
                req.Timeout = 10000; //设置超时值10秒
                req.UserAgent = "Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/71.0.3578.98 Safari/537.36";
                req.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8";
                req.Method = "GET";
                res = (HttpWebResponse)(req.GetResponse());
                image = new Bitmap(res.GetResponseStream());//获取图片流                 
                image.Save(saveUrl);
                //缩小图片并加水印
                PicDeal.MakeThumbnail(saveUrl, rImgPath, zWidth, zHeight, "Cut");
                PicDeal.LetterWatermark(rImgPath, 8, "@sunkejava", Color.White, "");
                if (image != null)
                {
                    image.Dispose();
                }
                image = System.Drawing.Image.FromFile(rImgPath);
            }
            catch (Exception ex)
            {
                throw new Exception("获取图片失败，原因为：" + ex.Message);
            }
            finally
            {
                res.Close();
            }
            return image;
        }

        public void DownloaImage(string fileName,string url,string btnName)
        {
            try
            {
                WebRequest webreq = WebRequest.Create(url);
                WebResponse webres = webreq.GetResponse();
                Stream stream = webres.GetResponseStream();
                Stream fileStream = new FileStream(fileName, FileMode.Create);
                byte[] bArray = new byte[1024];
                int size;
                do
                {
                    size = stream.Read(bArray, 0, (int)bArray.Length);
                    fileStream.Write(bArray, 0, size);
                } while (size > 0);
                fileStream.Close();
                stream.Close();
                if (btnName.Contains("btn_Setting_"))
                {
                    Thread thread = new Thread(() => setWallpaperApi(fileName));
                    thread.Start();
                }
                else
                {
                    MethodInvoker methInvo = new MethodInvoker(showMessageForm);
                    BeginInvoke(methInvo);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("下载图片失败，原因为：" + ex.Message);
            }
        }
        private void showMessageForm()
        {
            MessageForm mfm = new MessageForm();
            mfm.Show(this);
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
        #endregion

        #region 委托事件
        /// <summary>
        /// 刷新列表事件
        /// </summary>
        [Description("列表刷新事件"), Category("自定义事件")]
        public event EventHandler RefreshListed;


        #endregion

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // ImageListControl
            // 
            this.Borders.BottomColor = System.Drawing.Color.Empty;
            this.Borders.BottomWidth = 1;
            this.Borders.LeftColor = System.Drawing.Color.Empty;
            this.Borders.LeftWidth = 1;
            this.Borders.RightColor = System.Drawing.Color.Empty;
            this.Borders.RightWidth = 1;
            this.Borders.TopColor = System.Drawing.Color.Empty;
            this.Borders.TopWidth = 1;
            this.ResumeLayout(false);

        }
    }
}
