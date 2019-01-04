using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using LayeredSkin.Controls;
using LayeredSkin.DirectUI;
using LayeredSkin.Forms;
using MaiinTimer.Controls;
using MaiinTimer.Utils;

namespace MaiinTimer
{
    public partial class BackForm : LayeredForm
    {
        #region 模拟窗体移动变量
        [DllImport("user32.dll", EntryPoint = "SendMessageA")]
        private static extern int SendMessage(int hwnd, int wMsg, int wParam, int lParam);

        [DllImport("user32.dll")]
        private static extern int ReleaseCapture();
        private const int WM_NCLBUTTONDOWN = 0XA1;   //.定义鼠標左鍵按下
        private const int HTCAPTION = 2;
        #endregion

        /// <summary>
        /// 滚轮用参数
        /// </summary>
        private bool scorlling = false;
        private int mousetop = 0;
        BridImg bimg = new BridImg();
        DuiBaseControl typeControl = new DuiBaseControl();
        string labelId = "";//选择的标签与类型ID
        string startNo = "0";//开始序号

        #region 窗体控件事件
        public BackForm()
        {
            InitializeComponent();
            layeredPanel_top.BackColor = Color.FromArgb(255, 92, 138);
            scorllbar.BackColor = Color.FromArgb(100, 255, 92, 138);
            Panel_Bottom.BackColor = Color.FromArgb(255, 92, 138);
        }

        private void BackForm_Load(object sender, EventArgs e)
        {
            foreach (var item in BaseControl_Search.DUIControls)
            {
                if (item is DuiButton)
                {
                    DuiButton btn_search = item as DuiButton;
                    if (btn_search.Name == "btn_search")
                    {
                        btn_search.MouseClick += Btn_search_MouseClick;
                    }
                    if (btn_search.Name == "btn_searchtext")
                    {
                        foreach (var citem in btn_search.Controls)
                        {
                            if (citem is DuiTextBox)
                            {
                                DuiTextBox searchText = citem as DuiTextBox;
                                searchText.FocusedChanged += SearchText_FocusedChanged;
                            }
                        }
                    }
                }
            }
            addBackImg();
        }
        /// <summary>
        /// 搜索框获取焦点后事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SearchText_FocusedChanged(object sender, EventArgs e)
        {
            DuiTextBox searchText = sender as DuiTextBox;
            if (searchText != null)
            {
                if (searchText.Text == "输入关键字进行搜索")
                {
                    searchText.Text = "";
                    searchText.ForeColor = Color.White;
                }
                else
                {
                    if (string.IsNullOrEmpty(searchText.Text))
                    {
                        searchText.Text = "输入关键字进行搜索";
                        searchText.ForeColor = Color.FromArgb(255, 171, 171, 171);
                    }
                }
            }
        }

        /// <summary>
        /// 搜索按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_search_MouseClick(object sender, DuiMouseEventArgs e)
        {
            foreach (var item in BaseControl_Search.DUIControls)
            {
                if (item is DuiButton)
                {
                    DuiButton btn_search = item as DuiButton;
                    foreach (var citem in btn_search.Controls)
                    {
                        if (citem is DuiTextBox)
                        {
                            DuiTextBox searchText = citem as DuiTextBox;
                            if (!string.IsNullOrEmpty(searchText.Text) && searchText.Text != "输入关键字进行搜索")
                            {
                                MessageBox.Show("搜索" + searchText.Text);
                            }
                            else
                            {
                                MessageBox.Show("请输入关键字进行搜索");
                            }
                        }
                    }

                }
            }
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_min_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btn_min_MouseDown(object sender, MouseEventArgs e)
        {
            LayeredButton thisButton = sender as LayeredButton;
            thisButton.BackColor = Color.FromArgb(255, 92, 125);
        }

        private void btn_min_MouseHover(object sender, EventArgs e)
        {
            LayeredButton thisButton = sender as LayeredButton;
            switch (thisButton.Name)
            {
                case "btn_min":
                    layeredPanel_min.BackColor = Color.FromArgb(100,234, 234, 234);
                    break;
                default:
                    layeredPanel_close.BackColor = Color.FromArgb(255, 88, 88);
                    break;
            }
        }

        private void btn_min_MouseLeave(object sender, EventArgs e)
        {
            LayeredButton thisButton = sender as LayeredButton;
            thisButton.BackColor = Color.Transparent;
            layeredPanel_min.BackColor = thisButton.BackColor;
            layeredPanel_close.BackColor = thisButton.BackColor;
        }

        private void skinLine_MouseEnter(object sender, EventArgs e)
        {
            skinLine_Update();
            DuiLabel btn = sender as DuiLabel;
            DuiBaseControl bControl = btn.Parent as DuiBaseControl;
            if (btn.Name.Contains("ImageTypeName_"))
            {
                btn.ForeColor = System.Drawing.Color.FromArgb(255, 92, 138);
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
                DuiBaseControl newpm = new DuiBaseControl();
                if (item is DuiBaseControl)
                {
                    newpm = item;
                    newpm.Visible = true;
                    Panel_TypeMess.DUIControls.Add(newpm);
                    Panel_TypeMess.Size = item.Size;
                    Panel_TypeMess.Location = new Point(item.Location.X, layeredPanel_top.Height+item.Location.Y);
                    newpm.Location = new Point(0, 0);
                    newpm.Dock = DockStyle.Fill;
                    Panel_TypeMess.Visible = true;
                }
            }

            //NowNum = int.Parse(btn.Tag.ToString());
            //LoadSliderImg(NowNum);
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
                foreach (var item in List_Main.Items)
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
                    List_Main.Items.Remove(item);
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
                        List_Main.addImgList(imgInfos);
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
                    Panel_TypeMess.DUIControls.Remove(item);
                    Panel_TypeMess.Visible = false;
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
            typeControl.Name = "typeControl";
            //循环增加分类
            for (int i = 0; i < imgJsons.data.Count; i++)
            {
                DuiLabel dlbe = new DuiLabel();
                dlbe.Size = new Size(60, 20);
                dlbe.Text = imgJsons.data[i].name;
                dlbe.Name = "ImageTypeName_" + imgJsons.data[i].id.ToString();
                dlbe.Location = new Point(61 * i, 5);
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
                dLabel1.Location = new Point(61 * i, 30);
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
                        ltypeControl.Size = new Size(124, tagsList.Count * 24 / 2);
                        ltypeControl.Name = "ImageTypeGrid_" + item.tagId;
                        ltypeControl.Location = new Point(60 * i, 25);
                        ltypeControl.Visible = false;
                        ltypeControl.BackColor = Color.White;
                        int rowi = 1;
                        int coli = 1;
                        int ti = 1;
                        foreach (BridImg.tagItem citem in tagsList)
                        {
                            coli = (ti % 2 == 0 ? 2 : 1);
                            rowi = (int)Math.Ceiling(((double)ti / 2));
                            DuiLabel dlbea = new DuiLabel();
                            dlbea.Size = new Size(60, 20);
                            dlbea.Text = citem.tagName;
                            dlbea.Name = "ImageTypeNameOther_" + citem.tagName;
                            dlbea.Location = new Point(60 * (coli - 1), 21 * (rowi - 1));
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
            typeControl.Size = new Size(this.Width, 35);
            typeControl.Dock = DockStyle.Fill;
            Panel_TypeMess.BringToFront();
            Panel_Type.DUIControls.Add(typeControl);
            return true;
        }


        private Boolean addBackImg()
        {
            var result = new Utils.Response<BridImg.ImageJson>();
            var rType = new Utils.Response<BridImg.ImgJson>();
            try
            {
                rType.Result = bimg.getImageType();
                //添加分类控件
                addImgType(rType.Result);
                //添加详细信息
                List<BridImg.ImageInfo> imgInfos = new List<BridImg.ImageInfo>();
                result.Result = bimg.getNewImageInfos("0", "9");
                for (int i = 0; i < result.Result.data.Count; i++)
                {
                    int zi = i + 1;
                    imgInfos.Add(result.Result.data[i]);
                    if (zi % 3 == 0)
                    {
                        List_Main.addImgList(imgInfos);
                        imgInfos.Clear();
                    }
                }
            }
            catch (Exception ex)
            {
                result.Code = 500;
                result.Message = ex.Message;
                throw;
            }
            return true;
        }

        #endregion

        #region 滚动条事件
        private void layeredPanel_top_MouseDown(object sender, MouseEventArgs e)
        {
            //为当前的应用程序释放鼠标捕获
            ReleaseCapture();
            //发送消息﹐让系統误以为在标题栏上按下鼠标
            SendMessage((int)this.Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
        }

        private void scorllbar_Move(object sender, EventArgs e)
        {
            if (scorlling)
            {
                List_Main.Value = (double)(scorllbar.Top - List_Main.Top) / (double)(List_Main.Height - scorllbar.Height);
            }
        }

        private void scorllbar_MouseDown(object sender, MouseEventArgs e)
        {
            mousetop = scorllbar.PointToClient(MousePosition).Y;
            scorlling = true;
            scorllbar.BackColor = Color.FromArgb(80, 215, 92, 95);
        }

        private void scorllbar_MouseEnter(object sender, EventArgs e)
        {
            if (scorllbar.Top < List_Main.Top)
                scorllbar.Top = List_Main.Top + 2;
            if (scorllbar.Top > (List_Main.Top + List_Main.Height - scorllbar.Height))
                scorllbar.Top = (List_Main.Top + List_Main.Height - scorllbar.Height);
            scorllbar.BackColor = Color.FromArgb(100, 255, 92, 58);
        }

        private void scorllbar_MouseLeave(object sender, EventArgs e)
        {
            scorllbar.BackColor = Color.FromArgb(100, 255, 92, 138);
        }

        private void scorllbar_MouseMove(object sender, MouseEventArgs e)
        {
            if (scorlling)
            {
                if (scorllbar.Top >= List_Main.Top && scorllbar.Top <= (List_Main.Top + List_Main.Height - scorllbar.Height))
                    scorllbar.Top = PointToClient(MousePosition).Y - mousetop;
            }
        }

        private void scorllbar_MouseUp(object sender, MouseEventArgs e)
        {
            mousetop = e.Y; scorlling = false;
            scorllbar.BackColor = Color.FromArgb(100, 255, 92, 138);
        }

        private void List_Main_RefreshListed(object sender, EventArgs e)
        {
            int allheight = 0;
            for (int i = 0; i < List_Main.Items.Count; i++)
            {
                if (List_Main.Items[i].Visible)
                    allheight = allheight + List_Main.Items[i].Height;
            }
            double pre = (double)List_Main.Height / (double)allheight;
            if (pre < 1)
            {
                if (List_Main.Visible)
                    scorllbar.Show();

                scorllbar.Height = (int)(pre * (double)List_Main.Height);
                scorllbar.Top = (int)(List_Main.Value * (List_Main.Height - scorllbar.Height)) + List_Main.Top;
            }
            else
            {
                scorllbar.Hide();
            }
        }
        #endregion

    }
}
