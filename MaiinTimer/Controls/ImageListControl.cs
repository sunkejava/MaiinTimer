using LayeredSkin.DirectUI;
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
        public delegate Image getImageByUIrlDelegate(string url, int zWidth, int zHeight);
        #region 控件事件

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
            throw new NotImplementedException();
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
            string url = dbn.Tag.ToString();
            string fileName = @"D:\Program Files\ImageWallpaper" + new Uri(url).Segments[new Uri(url).Segments.Length - 1];
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
                if (dbn.Name.Contains("btn_Setting_"))
                {
                    setWallpaperApi(fileName);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("下载图片失败，原因为：" + ex.Message);
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
            string ImageSavePath = @"D:\Program Files\ImageWallpaper";
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
        #endregion

        #region 自定义事件
        /// <summary>
        /// 添加图片列表
        /// </summary>
        /// <param name="imgInfos"></param>
        /// <returns></returns>
        public bool addImgList(List<BridImg.ImageInfo> imgInfos)
        {
            int thisWidth = this.Width - 5;//减去滚动条宽度
            int zWidth = (int)(thisWidth / 3);
            int zHeight = (int)(thisWidth / 3 * 0.57);
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
                dp.Tag = imgInfo.img_1024_768;
                getImageByUIrlDelegate newg = new getImageByUIrlDelegate(GetImageByUrlDrawLetter);
                dp.BackgroundImage = newg(imgInfo.url.Replace("__85", "300_161_100"), zWidth - 4, zHeight - 4);
                dp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                dp.Name = "back_" + imgInfo.id.ToString();
                dp.Location = new Point(2, 2);
                dp.Cursor = System.Windows.Forms.Cursors.Hand;
                dp.MouseEnter += Dp_MouseEnter;
                dp.MouseLeave += Dp_MouseLeave;
                dp.MouseClick += Dp_MouseClick;
                //图片说明
                DuiLabel imgTag = new DuiLabel();
                imgTag.TextRenderMode = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
                if (imgInfo.utag.Length * 9 > zWidth)
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
                
                imgTag.Cursor = System.Windows.Forms.Cursors.Hand;
                //下载按钮
                DuiButton btn_Download = new DuiButton();
                btn_Download.Size = new Size(35, 35);
                btn_Download.Radius = 35;
                btn_Download.Name = "btn_Download_" + imgInfo.id.ToString();
                btn_Download.Text = "";
                btn_Download.Location = new Point(zWidth - 24 - 105, 2);
                btn_Download.Cursor = System.Windows.Forms.Cursors.Hand;
                btn_Download.AdaptImage = false;
                btn_Download.IsPureColor = true;
                btn_Download.BaseColor = Color.FromArgb(100, 0, 0, 0);
                btn_Download.BackgroundImage = Properties.Resources.download;
                btn_Download.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
                btn_Download.ShowBorder = false;
                btn_Download.MouseClick += Btn_Download_MouseClick;
                btn_Download.Tag = imgInfo.url;

                //收藏按钮
                DuiButton btn_sc = new DuiButton();
                btn_sc.Location = new Point(zWidth - 16 - 70, 2);
                btn_sc.Size = new Size(35, 35);
                btn_sc.Text = "";
                btn_sc.Cursor = System.Windows.Forms.Cursors.Hand;
                btn_sc.AdaptImage = false;
                btn_sc.Name = "btn_Sc_" + imgInfo.id.ToString();
                btn_sc.BaseColor = Color.FromArgb(100, 0, 0, 0);
                btn_sc.Radius = 35;
                btn_sc.ShowBorder = false;
                btn_sc.BackgroundImage = Properties.Resources.sc;
                btn_sc.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
                btn_sc.MouseClick += Btn_Download_MouseClick;
                btn_sc.IsPureColor = true;
                //设置按钮
                DuiButton btn_Setting = new DuiButton();
                btn_Setting.Location = new Point(zWidth - 8 - 35, 2);
                btn_Setting.Size = new Size(35, 35);
                btn_Setting.Text = "";
                btn_Setting.Cursor = System.Windows.Forms.Cursors.Hand;
                btn_Setting.AdaptImage = false;
                btn_Setting.Name = "btn_Setting_" + imgInfo.id.ToString();
                btn_Setting.BaseColor = Color.FromArgb(100, 0, 0, 0);
                btn_Setting.Radius = 35;
                btn_Setting.Tag = imgInfo.url;
                btn_Setting.ShowBorder = false;
                btn_Setting.BackgroundImage = Properties.Resources.seting;
                btn_Setting.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
                btn_Setting.MouseClick += Btn_Setting_MouseClick;
                btn_Setting.IsPureColor = true;
                //按钮底层控件
                DuiBaseControl btnBaseControl = new DuiBaseControl();
                btnBaseControl.Size = new Size(zWidth-12,40);
                btnBaseControl.Cursor = System.Windows.Forms.Cursors.Hand;
                btnBaseControl.Location = new Point(5,zHeight-48);
                btnBaseControl.BackColor = Color.Transparent;
                btnBaseControl.MouseEnter += Dp_MouseEnter;
                //btnBaseControl.MouseLeave += Dp_MouseLeave;
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
            baseControl.Name = "imgListBaseControl_" + imgInfos[0].id.ToString();
            Items.Add(baseControl);
            //更新列表
            RefreshList();
            GC.Collect();
            return true;
        }

        //利用系统的用户接口设置壁纸
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
        /// <summary>
        /// 获取图片并添加水印
        /// </summary>
        /// <param name="url">图片地址</param>
        /// <param name="zWidth">宽</param>
        /// <param name="zHeight">高</param>
        /// <returns></returns>
        private Image GetImageByUrlDrawLetter(string url, int zWidth, int zHeight)
        {
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
                    //gs.DrawString(letter, font, br, zWidth-(fontSize * letter.Length), zHeight-fontSize-5);
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


    }
}
