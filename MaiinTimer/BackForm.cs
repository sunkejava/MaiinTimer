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
using System.Threading;
using System.Windows.Forms;
using LayeredSkin.Controls;
using LayeredSkin.DirectUI;
using LayeredSkin.Forms;
using BridImage.Controls;
using BridImage.Utils;
using System.Collections;

namespace BridImage
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
        private System.Windows.Forms.Timer amPic = null;
        BridImg bimg = new BridImg();
        DuiBaseControl typeControl = new DuiBaseControl();
        string labelId = "";//类型ID
        string startNo = "0";//开始序号
        string pageCount = "12";//每页或每次调用获取图片的总数
        string hotTagName = "";//热门标签
        bool isSearch = false;//是否搜索
        bool isEnd = false;//是否为页尾
        bool isLoadData = false;//是否正在加载数据
        ArrayList imgList = new ArrayList();
        int cheight = 0;
        EllipseControl ctEnd = new BridImage.Controls.EllipseControl();
        string nCount = "0";//当前类型可获取的图片总数
        public Color defaultColor = Color.FromArgb(255, 92, 138);
        delegate void AsynUpdateUI(bool isLoad);//委托更新加载控件显示
        delegate void AsynUpdateloadPageText(string nowPage, string countPage);
        delegate void AsynScrollUI(object sender, EventArgs e);//委托ListBox刷新事件
        delegate void AsynScrollUpdateUI(object sender, EventArgs e);//委托ListBoxValue更新事件
        public PropertsUtils pes = new PropertsUtils();
        public Image BackImg = null;
        string SwitchWallpaperStartNos = "0";
        int x, y;//记录鼠标进入控件时的位置
        #region 窗体控件事件
        public BackForm()
        {
            InitializeComponent();
            setSkinStyle();
        }
        public void setSkinStyle()
        {
            defaultColor = pes.BackColor;
            this.BackColor = Color.FromArgb(125, defaultColor.R, defaultColor.G, defaultColor.B);
            layeredPanel_top.BackColor = defaultColor;
            scorllbar.BackColor = defaultColor;
            Panel_Bottom.BackColor = defaultColor;
            Panel_load.BackColor = Color.FromArgb(125, defaultColor.R, defaultColor.G, defaultColor.B);
            string bkimg = pes.BackImg.Replace("comboboxpb", "pictureBox");
            switch (bkimg)
            {
                case "pictureBox1":
                    BackGroundSkin = Properties.Resources._0;
                    pes.BackImg = "comboboxpb1";
                    break;
                case "pictureBox2":
                    BackGroundSkin = Properties.Resources._5;
                    pes.BackImg = "comboboxpb2";
                    break;
                case "pictureBox3":
                    BackGroundSkin = Properties.Resources._4;
                    pes.BackImg = "comboboxpb3";
                    break;
                case "pictureBox4":
                    BackGroundSkin = Properties.Resources._3;
                    pes.BackImg = "comboboxpb4";
                    break;
                case "pictureBox5":
                    BackGroundSkin = Properties.Resources._21;
                    pes.BackImg = "comboboxpb5";
                    break;
                case "pictureBox7":
                    BackGroundSkin = Properties.Resources._1;
                    pes.BackImg = "comboboxpb7";
                    break;
                case "pictureBox8":
                    BackGroundSkin = Properties.Resources._2;
                    pes.BackImg = "comboboxpb8";
                    break;
                case "pictureBox9":
                    BackGroundSkin = Properties.Resources._6;
                    pes.BackImg = "comboboxpb9";
                    break;
                default:
                    if (!String.IsNullOrEmpty(bkimg))
                    {
                        BackGroundSkin = Image.FromFile(bkimg);
                        pes.BackImg = bkimg;
                    }
                    else {
                        BackGroundSkin = null;
                        pes.BackImg = "";
                    }
                    break;
            }
            //Thread thread = new Thread(() => setAutoBackPic());
            //thread.Start();
            setAutoBackPic();
            List_Main.RefreshList();
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
            //添加默认字段
            labelId = "0";
            startNo = "0";
            hotTagName = "";
            nCount = "0";
            isSearch = false;
            Thread thread = new Thread(() => addBackImg());
            thread.Start();
            //addBackImg();
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
                                isSearch = true;
                                startNo = "0";
                                labelId = searchText.Text;
                                Thread thread = new Thread(() => updateImgList(searchText.Text, startNo));
                                thread.Start();
                            }
                            else
                            {
                                MessageForm mf = new MessageForm("请输入关键字进行搜索");
                                mf.ShowDialog();
                            }
                        }
                    }

                }
            }
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            pes.saveConfig();  
            this.Close();
        }

        private void btn_min_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }


        private void btn_set_Click(object sender, EventArgs e)
        {
            SetForm sf = new SetForm(this);
            sf.Show();
        }

        private void btn_skin_Click(object sender, EventArgs e)
        {
            colorSkin cs = new colorSkin(this);
            cs.Show();
            cs.Location = new Point(Left + 500, 25 + Top);
        }

        private void btn_min_MouseHover(object sender, EventArgs e)
        {
            LayeredPanel thisButton = sender as LayeredPanel;
            switch (thisButton.Name)
            {
                case "layeredPanel_close":
                    thisButton.BackColor = Color.FromArgb(255, 88, 88);
                    break;
                default:
                    thisButton.BackColor = Color.FromArgb(100, 234, 234, 234);
                    break;
            }
        }
        private void btn_skin_MouseEnter(object sender, EventArgs e)
        {
            LayeredButton thisButton = sender as LayeredButton;
            switch (thisButton.Name)
            {
                case "btn_skin":
                    layeredPanel_skin.BackColor = Color.FromArgb(100, 234, 234, 234);
                    break;
                case "btn_set":
                    layeredPanel_Set.BackColor = Color.FromArgb(100, 234, 234, 234);
                    break;
                case "btn_min":
                    layeredPanel_min.BackColor = Color.FromArgb(100, 234, 234, 234);
                    break;
                default:
                    layeredPanel_close.BackColor = Color.FromArgb(255, 88, 88);
                    break;
            }
        }

        private void btn_min_MouseLeave(object sender, EventArgs e)
        {
            LayeredPanel thisButton = sender as LayeredPanel;
            thisButton.BackColor = Color.Transparent;
            layeredPanel_min.BackColor = thisButton.BackColor;
            layeredPanel_close.BackColor = thisButton.BackColor;
            layeredPanel_Set.BackColor = thisButton.BackColor;
            layeredPanel_skin.BackColor = thisButton.BackColor;
        }

        private void Dlbe_MouseEnter(object sender, DuiMouseEventArgs e)
        {
            skinLine_Update();
            DuiBaseControl lbbtn = sender as DuiBaseControl;
            string vtag = "";
            foreach (var vitem in lbbtn.Controls)
            {
                DuiLabel lb = vitem as DuiLabel;
                vtag = lb.Tag.ToString();
                if (lb.Name.Contains("ImageTypeName_"))
                {
                    lb.ForeColor = defaultColor;
                }
                else
                {
                    lb.BackColor = defaultColor;
                }
            }
            DuiBaseControl bControl = lbbtn.Parent as DuiBaseControl;
            foreach (var item in bControl.FindControl("ImageTypeGrid_" + vtag))
            {
                //深度复制过来使用部分事件失效
                //DuiBaseControl newpm = new DuiBaseControl();
                //if (item is DuiBaseControl && item.Controls.Count > 0)
                //{
                //    //深度复制对象
                //    newpm = Utils.CloneObject<DuiBaseControl,DuiBaseControl>.Trans(item);
                //    newpm.Visible = true;
                //    newpm.Location = new Point(0, 0);
                //    newpm.Dock = DockStyle.Fill;
                //    Panel_TypeMess.DUIControls.Add(newpm);
                //    Panel_TypeMess.Size = item.Size;
                //    Panel_TypeMess.Location = new Point(item.Location.X, layeredPanel_top.Height + Panel_Type.Height);                    
                //    Panel_TypeMess.Visible = true;
                //}
                if (item is DuiBaseControl && item.Controls.Count > 0 && Panel_TypeMess.DUIControls.Count <= 0)
                {
                    DuiBaseControl newpm = new DuiBaseControl();
                    newpm.Size = item.Size;
                    newpm.Visible = true;
                    newpm.Location = new Point(0, 0);
                    newpm.BackColor = item.BackColor;
                    newpm.Borders = item.Borders;
                    newpm.ShowBorder = item.ShowBorder;
                    foreach (var vitem in item.Controls)
                    {
                        if (vitem is DuiLabel)
                        {
                            DuiLabel dl = vitem as DuiLabel;
                            dl.Cursor = Cursors.Hand;
                            dl.MouseEnter += dlTag_MouseEnter;
                            dl.MouseLeave += dlTag_MouseLeave;
                            //dl.MouseClick += dlTag_MouseClick;
                            newpm.Controls.Add(dl);
                        }
                    }
                    newpm.Dock = DockStyle.Fill;
                    Panel_TypeMess.DUIControls.Add(newpm);
                    Panel_TypeMess.Size = item.Size;
                    Panel_TypeMess.Location = new Point(item.Location.X, layeredPanel_top.Height + Panel_Type.Height-5);
                    //Panel_TypeMess.Visible = true;
                    Utils.AnimationControl.ShowControl(Panel_TypeMess, true,AnchorStyles.Right);
                }
            }
            Point ms = Control.MousePosition;
            x = ms.X;
            y = ms.Y;
            //NowNum = int.Parse(btn.Tag.ToString());
            //LoadSliderImg(NowNum);
            Panel_Type.Refresh();
        }

        private void Dlbe_MouseMove(object sender, DuiMouseEventArgs e)
        {
            Point ms = Control.MousePosition;
            x = ms.X;
            y = ms.Y;
        }

        /// <summary>
        /// 图片类型点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Dlbe_MouseClick(object sender, DuiMouseEventArgs e)
        {
            //!string.IsNullOrEmpty((sender as DuiLabel).Tag.ToString()) &&
            if ((sender as DuiLabel).Tag.ToString() != "999" && (sender as DuiLabel).Tag.ToString() != labelId)
            {
                labelId = (sender as DuiLabel).Tag.ToString();
                startNo = "0";
                hotTagName = "";
                nCount = "0";
                isSearch = false;
                Thread thread = new Thread(() => updateImgList(labelId, startNo));
                thread.Start();
            }
        }
        private void Dlbe_MouseLeave(object sender, EventArgs e)
        {
            DuiBaseControl lbbtn = sender as DuiBaseControl;
            foreach (var vitem in lbbtn.Controls)
            {
                DuiLabel lb = vitem as DuiLabel;
                if (lb.Text == "4K专区")
                {
                    skinLine_Update();
                }
            }
            Point ms = Control.MousePosition;
            if ((ms.Y < y || (ms.Y >= y && ms.X != x)) && Panel_TypeMess.DUIControls.Count > 0)
            {
                skinLine_Update();
                Panel_TypeMess.DUIControls.Clear();
                //Panel_TypeMess.Visible = false;
                Utils.AnimationControl.ShowControl(Panel_TypeMess, false, AnchorStyles.Left);
                //Panel_TypeMess.Size = new Size(0, 0);
                //Panel_TypeMess.Refresh();
            }
            List_Main.Refresh();
        }

        private void dlTag_MouseEnter(object sender, EventArgs e)
        {
            DuiLabel dlb = sender as DuiLabel;
            dlb.ForeColor = defaultColor;
        }

        private void dlTag_MouseLeave(object sender, EventArgs e)
        {
            DuiLabel dlb = sender as DuiLabel;
            dlb.ForeColor = System.Drawing.Color.Black;
        }

        private void dlTag_MouseClick(object sender, DuiMouseEventArgs e)
        {
            DuiLabel dlb = sender as DuiLabel;
            string tidsStr = dlb.Tag.ToString();
            if (!String.IsNullOrEmpty(tidsStr))
            {
                if (tidsStr.Contains("-"))
                {
                    labelId = dlb.Tag.ToString().Split('-')[0];
                    hotTagName = dlb.Tag.ToString().Split('-')[1];
                    startNo = "0";
                    isSearch = false;
                    Thread thread = new Thread(() => updateImgList(labelId, startNo, hotTagName));
                    thread.Start();
                }
                else
                {
                    labelId = (sender as DuiLabel).Tag.ToString();
                    startNo = "0";
                    hotTagName = "";
                    isSearch = false;
                    Thread thread = new Thread(() => updateImgList(labelId, startNo));
                    thread.Start();
                }
            }
        }

        /// <summary>
        /// 热门标签底层控件离开事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TypeControl_MouseLeave(object sender, EventArgs e)
        {
            if (Panel_TypeMess.DUIControls.Count > 0)
            {
                skinLine_Update();
                Panel_TypeMess.DUIControls.Clear();
                Panel_TypeMess.Visible = false;
                Panel_TypeMess.Size = new Size(0, 0);
                Panel_TypeMess.Refresh();
            }
        }
        /// <summary>
        /// 热门标签底层控件进入事件
        /// </summary>
        private void TypeControl_MouseEnter(object sender, EventArgs e)
        {
            //Panel_TypeMess.Visible = true;
        }
        #endregion

        #region 自定义事件

        public Image BackGroundSkin
        {
            get { return BackImg; }
            set
            {
                BackImg = value;
                if (value != null)
                {
                    Rectangle a = new Rectangle(new Point(), BackImg.Size);
                    this.BackgroundImage = BridImage.Utils.ImageVague.GaussianBlur(new Bitmap(BackImg), ref a, 20, false);
                    layeredPanel_top.BackColor = Color.Transparent;
                    Panel_Bottom.BackColor = Color.Transparent;
                    List_Main.RefreshList();
                }
                else
                {
                    this.BackgroundImage = null;
                }
            }
        }

        /// <summary>
        /// 更新列表
        /// </summary>
        /// <param name="tagId">类型ID或搜索关键字</param>
        /// <param name="startNos">开始数</param>
        /// <returns></returns>
        private bool updateImgList(string tagId,string startNos)
        {
            return updateImgList(tagId,startNo,"");
        }

        private bool updateImgList(string tagId, string startNos,string tagName)
        {
            try
            {
                LoadingControl(true);
                startNos = (string.IsNullOrEmpty(startNos) ? "0" : startNos);
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
                if (isSearch)
                {
                    result.Result = bimg.getImageInfosBySearch(tagId, startNos, pageCount);
                }
                else
                {
                    if (string.IsNullOrEmpty(tagId) || tagId == "0")
                    {
                        result.Result = bimg.getNewImageInfos(startNos, pageCount);
                    }
                    else
                    {
                        if (string.IsNullOrEmpty(tagName))
                        {
                            result.Result = bimg.getImageInfos(tagId, startNos, pageCount);
                        }
                        else
                        {
                            result.Result = bimg.getImageInfos(tagId, startNos, pageCount, tagName);
                        }
                    }

                }
                nCount = result.Result.total.ToString();
                loadPageTextUpdate((Math.Floor((decimal.Parse(startNos) + decimal.Parse(pageCount)) / decimal.Parse(pageCount))).ToString(), (Math.Ceiling(decimal.Parse(nCount) / decimal.Parse(pageCount))).ToString());
                for (int i = 0; i < result.Result.data.Count; i++)
                {
                    int zi = i + 1;
                    imgInfos.Add(result.Result.data[i]);
                    if (zi % 3 == 0 || zi == result.Result.data.Count)
                    {
                        //Thread imgThread = new Thread(() => addImgListThread(imgInfos));
                        //imgThread.Start();
                        List_Main.AddImgList(imgInfos);
                        List_Main.RefreshList();
                        imgInfos.Clear();
                    }
                }
                if (result.Result.data.Count <= 0)
                {
                    List_Main.addIsNull();
                    imgInfos.Clear();
                    List_Main.RefreshList();
                }
                LoadingControl(false);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("加载图片失败,原因为："+ex.Message);
            }
            
        }
        /// <summary>
        /// 添加列表信息
        /// </summary>
        /// <param name="tagId"></param>
        /// <param name="startNos"></param>
        /// <returns></returns>
        private bool addImgListItem(string tagId, string startNos)
        {
            return addImgListItem(tagId, startNos,"");
        }

        private bool addImgListItem(string tagId, string startNos,string tagName)
        {
            LoadingControl(true);
            //准备加载下一页图片
            startNos = (string.IsNullOrEmpty(startNos) ? "0" : startNos);
            List<DuiBaseControl> cItems = new List<DuiBaseControl>();
            var result = new Utils.Response<BridImg.ImageJson>();
            List<BridImg.ImageInfo> imgInfos = new List<BridImg.ImageInfo>();
            if (isSearch)
            {
                result.Result = bimg.getImageInfosBySearch(tagId, startNos, pageCount);
            }
            else
            {
                if (string.IsNullOrEmpty(tagId) || tagId == "0")
                {
                    result.Result = bimg.getNewImageInfos(startNos, pageCount);
                }
                else
                {
                    if (string.IsNullOrEmpty(tagName))
                    {
                        result.Result = bimg.getImageInfos(tagId, startNos, pageCount);
                    }
                    else
                    {
                        result.Result = bimg.getImageInfos(tagId, startNos, pageCount,tagName);
                    }
                }

            }
            nCount = result.Result.total.ToString();
            loadPageTextUpdate((Math.Floor((decimal.Parse(startNos)+ decimal.Parse(pageCount)) / decimal.Parse(pageCount))).ToString(), (Math.Ceiling(decimal.Parse(nCount) / decimal.Parse(pageCount))).ToString());
            for (int i = 0; i < result.Result.data.Count; i++)
            {
                int zi = i + 1;
                imgInfos.Add(result.Result.data[i]);
                if (zi % 3 == 0 || zi== result.Result.data.Count)
                {
                    //Thread imgThread = new Thread(() => addImgListThread(imgInfos));
                    //imgThread.Start();
                    List_Main.AddImgList(imgInfos);
                    List_Main.RefreshList();
                    imgInfos.Clear();
                }
            }
            LoadingControl(false);
            isLoadData = false;
            return true;
        }
        private void addImgListThread(List<BridImg.ImageInfo> imgInfos)
        {
            List_Main.AddImgList(imgInfos);
            List_Main.RefreshList();
        }
        private void LoadingControl(bool isLoad)
        {
            if (this.Panel_load.InvokeRequired)
            {
                AsynUpdateUI au = new AsynUpdateUI(LoadingControl);
                this.Invoke(au, new object[] { isLoad });
            }
            else
            {
                Panel_load.Visible = isLoad;
                if (isLoad)
                {
                    DuiPictureBox dp = Panel_load.DUIControls[0] as DuiPictureBox;
                    dp.Images = new Image[] { BridImage.Properties.Resources.video_loading_01, BridImage.Properties.Resources.video_loading_02, BridImage.Properties.Resources.video_loading_03, BridImage.Properties.Resources.video_loading_04, BridImage.Properties.Resources.video_loading_05, BridImage.Properties.Resources.video_loading_06, BridImage.Properties.Resources.video_loading_07, BridImage.Properties.Resources.video_loading_08 };
                    Panel_load.BringToFront();
                }
                else
                {
                    Panel_load.SendToBack();
                }
            }
        }

        private void loadPageTextUpdate(string nowPage,string countPage)
        {
            if (this.Panel_load.InvokeRequired)
            {
                AsynUpdateloadPageText au = new AsynUpdateloadPageText(loadPageTextUpdate);
                this.Invoke(au, new object[] { nowPage, countPage });
            }
            else
            {
                DuiLabel dpText = Panel_load.DUIControls[1] as DuiLabel;
                dpText.Text = "正在加载第 " + nowPage + "/" + countPage + ", 请稍后......";
            }
        }
        private void skinLine_Update()
        {
            foreach (var itemControl in typeControl.Controls)
            {
                if (itemControl is DuiBaseControl)
                {
                    foreach (var vitem in (itemControl as DuiBaseControl).Controls)
                    {
                        if (vitem is DuiLabel)
                        {
                            if ((vitem as DuiLabel).Name.Contains("ImageTypeLine_") && (vitem as DuiLabel).Tag.ToString() != labelId)
                            {
                                (vitem as DuiLabel).BackColor = System.Drawing.Color.Silver;
                            }
                            if ((vitem as DuiLabel).Name.Contains("ImageTypeName_") && (vitem as DuiLabel).Tag.ToString() != labelId)
                            {
                                (vitem as DuiLabel).ForeColor = System.Drawing.Color.Black;
                            }
                        }
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
            List<BridImg.ImageType> typesList = new List<BridImg.ImageType>();
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
            //添加默认最新分类
            BridImg.ImageType defaultType = new BridImg.ImageType();
            defaultType.id = 0;
            defaultType.name = "最新上传";
            addTypeLable(defaultType);
            labelId = "0";
            typeControl.Controls.Add(addHotTagControl(new List<BridImg.tagItem>(), "0"));
            //循环增加分类
            for (int i = 0; i < imgJsons.data.Count; i++)
            {
                List<BridImg.tagItem> tagsList = new List<BridImg.tagItem>();
                //4K专区
                if (imgJsons.data[i].name == "4K专区")
                {
                    addTypeLable(imgJsons.data[i]);
                    typeControl.Controls.Add(addHotTagControl(tagsList, imgJsons.data[i].id.ToString()));
                }
                else
                {
                    //增加带热门标签的分类及热门标签
                    foreach (BridImg.TagStringId item in tagStrId)
                    {
                        //如果ID相同则取tag信息
                        if (item.tagId == imgJsons.data[i].id.ToString())
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
                            //含热门标签的分类
                            addTypeLable(imgJsons.data[i]);
                            //热门标签
                            typeControl.Controls.Add(addHotTagControl(tagsList, item.tagId));
                        }
                    }
                    if (tagsList.Count <= 0)
                    {
                        typesList.Add(imgJsons.data[i]);
                    }
                }
            }
            //其他不包含热门标签的分类
            BridImg.ImageType otherType = new BridImg.ImageType();
            otherType.id = 999;
            otherType.name = "更多";
            addTypeLable(otherType);
            typeControl.Controls.Add(addNoHotTagControl(typesList, "999"));
            typeControl.BackColor = Color.White;
            typeControl.Size = new Size(this.Width, 35);
            typeControl.Dock = DockStyle.Fill;

            //typeControl.MouseEnter += TypeControl_MouseEnter;
            //typeControl.MouseLeave += TypeControl_MouseLeave;

            Panel_TypeMess.BringToFront();
            Panel_Type.DUIControls.Add(typeControl);
            return true;
        }

        /// <summary>
        /// 添加分类
        /// </summary>
        /// <param name="imgType">类型</param>
        /// <returns></returns>
        private Boolean addTypeLable(BridImg.ImageType imgType)
        {
            int i = (typeControl.Controls.Count/2);
            DuiLabel dlbe = new DuiLabel();
            dlbe.Size = new Size(60, 20);
            dlbe.Text = imgType.name;
            dlbe.Name = "ImageTypeName_" + imgType.id.ToString();
            dlbe.Location = new Point(0, 5);
            dlbe.Cursor = System.Windows.Forms.Cursors.Hand;
            dlbe.MouseMove += Dlbe_MouseMove;
            dlbe.TextAlign = ContentAlignment.MiddleCenter;
            dlbe.Tag = imgType.id;
            dlbe.MouseClick += Dlbe_MouseClick;

            DuiLabel dLabel1 = new DuiLabel();
            dLabel1.Name = "ImageTypeLine_" + imgType.id.ToString();
            dLabel1.Cursor = dlbe.Cursor;
            dLabel1.Size = new Size(60, 2);
            dLabel1.BackColor = System.Drawing.Color.Silver;
            dLabel1.Height = 2;
            dLabel1.Tag = imgType.id;
            dLabel1.Location = new Point(0,30);
            dLabel1.MouseClick += Dlbe_MouseClick;

            DuiBaseControl dlbControl = new DuiBaseControl();
            dlbControl.Size = new Size(60,35);
            dlbControl.Location = new Point(61 * i, 0);
            dlbControl.MouseMove += Dlbe_MouseEnter;
            //dlbControl.MouseEnter += Dlbe_MouseEnter;
            dlbControl.MouseLeave += Dlbe_MouseLeave;
            dlbControl.Controls.AddRange(new DuiBaseControl[] { dlbe,dLabel1});
            if (imgType.id == 0)
            {
                dlbe.ForeColor = defaultColor;
                dLabel1.BackColor = defaultColor;
            }
            typeControl.Controls.Add(dlbControl);
            return true;
        }

        /// <summary>
        /// 添加热门标签
        /// </summary>
        /// <param name="tagsList">标签数组List</param>
        /// <param name="typeId">分类ID</param>
        /// <param name="index">当前顺序</param>
        /// <returns></returns>
        private DuiBaseControl addHotTagControl(List<BridImg.tagItem> tagsList,string typeId)
        {
            int index = ((typeControl.Controls.Count-1) / 2);
            DuiBaseControl ltypeControl = new DuiBaseControl();
            if (tagsList.Count > 0)
            {
                ltypeControl.Size = new Size(154, 15 + tagsList.Count * 27 / 2);
            }
            else
            {
                ltypeControl.Size = new Size(154, 0);
            }
            
            ltypeControl.Name = "ImageTypeGrid_" + typeId;
            ltypeControl.Location = new Point(60 * index, 25);
            ltypeControl.Visible = false;
            ltypeControl.BackColor = Color.White;//Color.FromArgb(defaultColor.R,defaultColor.G,defaultColor.B);
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
                dlbea.Location = new Point(70 * (coli - 1), 10 + 24 * (rowi - 1));
                dlbea.Cursor = System.Windows.Forms.Cursors.Hand;
                dlbea.TextAlign = ContentAlignment.MiddleCenter;
                dlbea.Tag = typeId + "-" + citem.tagName;
                dlbea.MouseClick += dlTag_MouseClick;
                ltypeControl.Controls.Add(dlbea);
                ti++;
            }
            return ltypeControl;
        }
        /// <summary>
        /// 添加没有热门标签的分类到统一的一个标签控件中
        /// </summary>
        /// <param name="typeList">分类集合</param>
        /// <param name="typeId">上级分类ID</param>
        /// <returns></returns>
        private DuiBaseControl addNoHotTagControl(List<BridImg.ImageType> typeList, string typeId)
        {
            int index = ((typeControl.Controls.Count-1) / 2);
            DuiBaseControl ltypeControl = new DuiBaseControl();
            ltypeControl.Size = new Size(124, typeList.Count * 32 / 2);
            ltypeControl.Name = "ImageTypeGrid_" + typeId;
            ltypeControl.Location = new Point(60 * (index-1), 25);
            ltypeControl.Visible = false;
            ltypeControl.BackColor = Color.White; //Color.FromArgb(defaultColor.R, defaultColor.G, defaultColor.B);
            int rowi = 1;
            int coli = 1;
            int ti = 1;
            foreach (BridImg.ImageType citem in typeList)
            {
                coli = (ti % 2 == 0 ? 2 : 1);
                rowi = (int)Math.Ceiling(((double)ti / 2));
                DuiLabel dlbea = new DuiLabel();
                dlbea.Size = new Size(60, 30);
                dlbea.Text = citem.name;
                dlbea.Name = "ImageTypeNameOther_" + citem.id;
                dlbea.Location = new Point(60 * (coli - 1), 32 * (rowi - 1));
                dlbea.Cursor = System.Windows.Forms.Cursors.Hand;
                //dlbea.MouseEnter += skinLine_MouseEnter;
                //dlbea.MouseLeave += Dlbe_MouseLeave;
                dlbea.TextAlign = ContentAlignment.MiddleCenter;
                dlbea.Tag = citem.id;
                dlbea.MouseClick += Dlbe_MouseClick;
                ltypeControl.Controls.Add(dlbea);
                ti++;
            }
            return ltypeControl;
        }
        private void addBackImg()
        {
            LoadingControl(true);
            var result = new Utils.Response<BridImg.ImageJson>();
            var rType = new Utils.Response<BridImg.ImgJson>();
            try
            {
                rType.Result = bimg.getImageType();
                //添加分类控件
                addImgType(rType.Result);
                //添加详细信息
                List<BridImg.ImageInfo> imgInfos = new List<BridImg.ImageInfo>();
                result.Result = bimg.getNewImageInfos(startNo, pageCount);
                nCount = result.Result.total.ToString();
                loadPageTextUpdate((Math.Floor((decimal.Parse(startNo) + decimal.Parse(pageCount)) / decimal.Parse(pageCount))).ToString(), (Math.Ceiling(decimal.Parse(nCount) / decimal.Parse(pageCount))).ToString());
                for (int i = 0; i < result.Result.data.Count; i++)
                {
                    int zi = i + 1;
                    imgInfos.Add(result.Result.data[i]);
                    if (zi % 3 == 0 || zi == result.Result.data.Count)
                    {
                        //Thread imgThread = new Thread(() => addImgListThread(imgInfos));
                        //imgThread.Start();
                        List_Main.AddImgList(imgInfos);
                        List_Main.RefreshList();
                        imgInfos.Clear();
                    }
                }
                LoadingControl(false);
            }
            catch (Exception ex)
            {
                result.Code = 500;
                result.Message = ex.Message;
                throw ex;
            }
        }

        /// <summary>
        /// 设置自动壁纸切换
        /// </summary>
        private void setAutoBackPic()
        {
            if (!pes.IsSwitchWallpaper)
            {
                return;
            }
            else
            {
                if (amPic != null)
                {
                    //amPic = null;
                    amPic.Dispose();
                }
                amPic = new System.Windows.Forms.Timer();
                amPic.Interval = pes.InterValTime * 1000;
                amPic.Enabled = true;
                amPic.Tick += AmPic_Tick;
            }
        }

        private void AmPic_Tick(object sender, EventArgs e)
        {
            imgList.TrimToSize();
            var result = new Utils.Response<BridImg.ImageJson>();
            
            if (imgList.Count > 0)
            {
                string imgUrl = imgList[0].ToString();
                setAutoBack(imgUrl);
                imgList.Remove(imgUrl);
            }
            else
            {
                foreach (var type in pes.SwitchWallpaperTypes)
                {
                    result.Result = bimg.getImageInfos(type.ToString(), SwitchWallpaperStartNos, "5");
                    //result.Result = bimg.getImageInfos(type.ToString(), SwitchWallpaperStartNos, "5", tagName);
                    foreach (BridImg.ImageInfo ci in result.Result.data)
                    {
                        switch (pes.PicSize)
                        {
                            case "default":
                                imgList.Add(ci.url_thumb);
                                break;
                            case "1600900":
                                imgList.Add(ci.img_1600_900);
                                break;
                            case "1440900":
                                imgList.Add(ci.img_1440_900);
                                break;
                            case "12801024":
                                imgList.Add(ci.img_1280_1024);
                                break;
                            case "1024768":
                                imgList.Add(ci.img_1024_768);
                                break;
                            case "1280800":
                                imgList.Add(ci.img_1280_800);
                                break;
                        }
                    }
                }
                SwitchWallpaperStartNos = (int.Parse(SwitchWallpaperStartNos) + 5).ToString();
                if (imgList.Count > 0)
                {
                    string imgUrl = imgList[0].ToString();
                    setAutoBack(imgUrl);
                    imgList.Remove(imgUrl);
                }
            }
        }


        private void setAutoBack(string imgUrl)
        {
            string fileName = "";
            if (string.IsNullOrEmpty(pes.CachePath))
            {
                fileName = AppDomain.CurrentDomain.BaseDirectory + @"CacheWallpaper\";
            }
            else
            {
                fileName = pes.CachePath.Replace("\\CacheWallpaper", "") + @"CacheWallpaper\";
            }
            if (!Directory.Exists(fileName))
            {
                Directory.CreateDirectory(fileName);
            }
            fileName = fileName + new Uri(imgUrl).Segments[new Uri(imgUrl).Segments.Length - 1];
            fileName = PicDeal.DownloaImage(fileName, imgUrl);
            PicDeal.setWallpaperApi(fileName);
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
            scorllbar.BackColor = defaultColor;
        }

        private void scorllbar_MouseEnter(object sender, EventArgs e)
        {
            if (scorllbar.Top < List_Main.Top)
                scorllbar.Top = List_Main.Top + 2;
            if (scorllbar.Top > (List_Main.Top + List_Main.Height - scorllbar.Height))
                scorllbar.Top = (List_Main.Top + List_Main.Height - scorllbar.Height);
            scorllbar.BackColor = defaultColor;
        }

        private void scorllbar_MouseLeave(object sender, EventArgs e)
        {
            scorllbar.BackColor = defaultColor;
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
            scorllbar.BackColor = defaultColor;
        }

        private void List_Main_RefreshListed(object sender, EventArgs e)
        {
            if (this.List_Main.InvokeRequired)
            {
                AsynScrollUI au = new AsynScrollUI(List_Main_RefreshListed);
                this.Invoke(au, new object[] { sender,e });
            }
            else
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
        }
        /// <summary>
        /// 鼠标滚轮滚动
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void List_Main_ValueChanged(object sender, EventArgs e)
        {
            if (this.List_Main.InvokeRequired)
            {
                AsynScrollUpdateUI au = new AsynScrollUpdateUI(List_Main_ValueChanged);
                this.Invoke(au, new object[] { sender, e });
            }
            else
            {
                if (!scorlling)
                {
                    scorllbar.Top = (int)(List_Main.Value * (List_Main.Height - scorllbar.Height)) + List_Main.Top;
                }
                if (List_Main.Value == 1 && !isLoadData)
                {
                    //如果为尾页则显示加载完毕
                    if ((int.Parse(startNo)+ int.Parse(pageCount)) >= int.Parse(nCount) && nCount != "0" && startNo != "0" && !isLoadData)
                    {
                        if (!isEnd)
                        {
                            int zHeight = 80;
                            if (!panel_ctEndLine.Controls.Contains(panel_ctEndLine))
                            {
                                panel_ctEndLine.Controls.Add(ctEnd);
                            }
                            ctEnd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
                            ctEnd.Borders.BottomColor = System.Drawing.Color.Empty;
                            ctEnd.Borders.BottomWidth = 1;
                            ctEnd.Borders.LeftColor = System.Drawing.Color.Empty;
                            ctEnd.Borders.LeftWidth = 1;
                            ctEnd.Borders.RightColor = System.Drawing.Color.Empty;
                            ctEnd.Borders.RightWidth = 1;
                            ctEnd.Borders.TopColor = System.Drawing.Color.Empty;
                            ctEnd.Borders.TopWidth = 1;
                            ctEnd.Canvas = ((System.Drawing.Bitmap)((new System.ComponentModel.ComponentResourceManager(typeof(BackForm))).GetObject("ellipseControl1.Canvas")));
                            ctEnd.CenterPotion = new System.Drawing.Point(448, 5);
                            ///ctEnd.Dock = System.Windows.Forms.DockStyle.Fill;
                            ctEnd.IsShowPotion = false;
                            ctEnd.LeftPotion = new System.Drawing.Point(0, 30);
                            ctEnd.Location = new System.Drawing.Point(0, 0);
                            ctEnd.Name = "backControlC";
                            ctEnd.RightPotion = new System.Drawing.Point(List_Main.Width - 5, zHeight /2);
                            ctEnd.Size = new System.Drawing.Size(List_Main.Width - 5, zHeight);
                            ctEnd.StrValue = "啊哦，已经是最后一页了！";
                            ctEnd.TabIndex = 1;
                            ctEnd.Text = "ellipseControl1";
                            ctEnd.Visible = true;

                            panel_ctEndLine.Size = ctEnd.Size;
                            panel_ctEndLine.Location = new Point(List_Main.Left, 77 + 557 - zHeight);
                            //panel_ctEndLine.BackColor = Color.White;
                            ctEnd.Location = new Point(0,0);
                            panel_ctEndLine.BringToFront();
                            panel_ctEndLine.Refresh();
                            panel_ctEndLine.Visible = true;
                            cheight = zHeight - 15;
                            System.Windows.Forms.Timer ctm = new System.Windows.Forms.Timer();
                            ctm.Interval = 50;
                            ctm.Enabled = true;
                            ctm.Tick += Ctm_Tick;
                            GC.Collect();
                            isEnd = true;
                        }
                    }
                    else
                    {
                        isLoadData = true;
                        startNo = (int.Parse(startNo) + int.Parse(pageCount)).ToString();
                        isEnd = false;
                        Thread thread = new Thread(() => addImgListItem(labelId, startNo, hotTagName));
                        thread.Start();
                    }
                }
            }
        }

        private void Ctm_Tick(object sender, EventArgs e)
        {
            if (cheight >= 10)
            {
                panel_ctEndLine.Visible = true;
                ctEnd.Visible = true;
                ctEnd.CenterPotion = new Point(ctEnd.CenterPotion.X, cheight);
                cheight = cheight - 5;
                ctEnd.Refresh();
                panel_ctEndLine.Refresh();
            }
            else
            {
                System.Windows.Forms.Timer tm = sender as System.Windows.Forms.Timer;
                tm.Enabled = false;
                cheight = ctEnd.Height;
                //ctEnd.Visible = false;
                isEnd = false;
                panel_ctEndLine.Visible = false;
                ctEnd.Refresh();
                panel_ctEndLine.Refresh();
            }
        }
        #endregion


    }
}
