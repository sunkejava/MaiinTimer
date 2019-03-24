namespace BridImage
{
    partial class BackForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BackForm));
            LayeredSkin.DirectUI.DuiButton duiButton5 = new LayeredSkin.DirectUI.DuiButton();
            LayeredSkin.DirectUI.DuiTextBox duiTextBox3 = new LayeredSkin.DirectUI.DuiTextBox();
            System.Drawing.StringFormat stringFormat7 = new System.Drawing.StringFormat();
            LayeredSkin.DirectUI.DuiButton duiButton6 = new LayeredSkin.DirectUI.DuiButton();
            System.Drawing.StringFormat stringFormat8 = new System.Drawing.StringFormat();
            LayeredSkin.DirectUI.DuiPictureBox duiPictureBox3 = new LayeredSkin.DirectUI.DuiPictureBox();
            LayeredSkin.DirectUI.DuiLabel duiLabel3 = new LayeredSkin.DirectUI.DuiLabel();
            System.Drawing.StringFormat stringFormat9 = new System.Drawing.StringFormat();
            this.layeredPanel_top = new LayeredSkin.Controls.LayeredPanel();
            this.layeredPanel_skin = new LayeredSkin.Controls.LayeredPanel();
            this.btn_skin = new LayeredSkin.Controls.LayeredButton();
            this.layeredPanel_Set = new LayeredSkin.Controls.LayeredPanel();
            this.btn_set = new LayeredSkin.Controls.LayeredButton();
            this.BaseControl_Search = new LayeredSkin.Controls.LayeredBaseControl();
            this.layeredPictureBox2 = new LayeredSkin.Controls.LayeredPictureBox();
            this.layeredPictureBox1 = new LayeredSkin.Controls.LayeredPictureBox();
            this.btn_close = new LayeredSkin.Controls.LayeredButton();
            this.btn_min = new LayeredSkin.Controls.LayeredButton();
            this.layeredPanel_close = new LayeredSkin.Controls.LayeredPanel();
            this.layeredPanel_min = new LayeredSkin.Controls.LayeredPanel();
            this.scorllbar = new LayeredSkin.Controls.LayeredBaseControl();
            this.Panel_Bottom = new LayeredSkin.Controls.LayeredPanel();
            this.Panel_Type = new LayeredSkin.Controls.LayeredPanel();
            this.Panel_TypeMess = new LayeredSkin.Controls.LayeredPanel();
            this.Panel_load = new LayeredSkin.Controls.LayeredPanel();
            this.panel_ctEndLine = new LayeredSkin.Controls.LayeredPanel();
            this.List_Main = new BridImage.Controls.ImageListControl();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.layeredPanel_top.SuspendLayout();
            this.layeredPanel_skin.SuspendLayout();
            this.layeredPanel_Set.SuspendLayout();
            this.SuspendLayout();
            // 
            // layeredPanel_top
            // 
            this.layeredPanel_top.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.layeredPanel_top.Borders.BottomColor = System.Drawing.Color.Empty;
            this.layeredPanel_top.Borders.BottomWidth = 1;
            this.layeredPanel_top.Borders.LeftColor = System.Drawing.Color.Empty;
            this.layeredPanel_top.Borders.LeftWidth = 1;
            this.layeredPanel_top.Borders.RightColor = System.Drawing.Color.Empty;
            this.layeredPanel_top.Borders.RightWidth = 1;
            this.layeredPanel_top.Borders.TopColor = System.Drawing.Color.Empty;
            this.layeredPanel_top.Borders.TopWidth = 1;
            this.layeredPanel_top.Canvas = ((System.Drawing.Bitmap)(resources.GetObject("layeredPanel_top.Canvas")));
            this.layeredPanel_top.Controls.Add(this.layeredPanel_skin);
            this.layeredPanel_top.Controls.Add(this.layeredPanel_Set);
            this.layeredPanel_top.Controls.Add(this.BaseControl_Search);
            this.layeredPanel_top.Controls.Add(this.layeredPictureBox2);
            this.layeredPanel_top.Controls.Add(this.layeredPictureBox1);
            this.layeredPanel_top.Controls.Add(this.btn_close);
            this.layeredPanel_top.Controls.Add(this.btn_min);
            this.layeredPanel_top.Controls.Add(this.layeredPanel_close);
            this.layeredPanel_top.Controls.Add(this.layeredPanel_min);
            this.layeredPanel_top.Dock = System.Windows.Forms.DockStyle.Top;
            this.layeredPanel_top.Location = new System.Drawing.Point(0, 0);
            this.layeredPanel_top.Name = "layeredPanel_top";
            this.layeredPanel_top.Size = new System.Drawing.Size(975, 41);
            this.layeredPanel_top.TabIndex = 0;
            this.layeredPanel_top.MouseDown += new System.Windows.Forms.MouseEventHandler(this.layeredPanel_top_MouseDown);
            // 
            // layeredPanel_skin
            // 
            this.layeredPanel_skin.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.layeredPanel_skin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.layeredPanel_skin.Borders.BottomColor = System.Drawing.Color.Empty;
            this.layeredPanel_skin.Borders.BottomWidth = 1;
            this.layeredPanel_skin.Borders.LeftColor = System.Drawing.Color.Empty;
            this.layeredPanel_skin.Borders.LeftWidth = 1;
            this.layeredPanel_skin.Borders.RightColor = System.Drawing.Color.Empty;
            this.layeredPanel_skin.Borders.RightWidth = 1;
            this.layeredPanel_skin.Borders.TopColor = System.Drawing.Color.Empty;
            this.layeredPanel_skin.Borders.TopWidth = 1;
            this.layeredPanel_skin.Canvas = ((System.Drawing.Bitmap)(resources.GetObject("layeredPanel_skin.Canvas")));
            this.layeredPanel_skin.Controls.Add(this.btn_skin);
            this.layeredPanel_skin.Location = new System.Drawing.Point(849, 0);
            this.layeredPanel_skin.Name = "layeredPanel_skin";
            this.layeredPanel_skin.Size = new System.Drawing.Size(32, 29);
            this.layeredPanel_skin.TabIndex = 8;
            this.layeredPanel_skin.Click += new System.EventHandler(this.btn_skin_Click);
            this.layeredPanel_skin.MouseEnter += new System.EventHandler(this.btn_min_MouseHover);
            this.layeredPanel_skin.MouseLeave += new System.EventHandler(this.btn_min_MouseLeave);
            // 
            // btn_skin
            // 
            this.btn_skin.AdaptImage = true;
            this.btn_skin.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_skin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btn_skin.BaseColor = System.Drawing.Color.Transparent;
            this.btn_skin.Borders.BottomColor = System.Drawing.Color.Empty;
            this.btn_skin.Borders.BottomWidth = 1;
            this.btn_skin.Borders.LeftColor = System.Drawing.Color.Empty;
            this.btn_skin.Borders.LeftWidth = 1;
            this.btn_skin.Borders.RightColor = System.Drawing.Color.Empty;
            this.btn_skin.Borders.RightWidth = 1;
            this.btn_skin.Borders.TopColor = System.Drawing.Color.Empty;
            this.btn_skin.Borders.TopWidth = 1;
            this.btn_skin.Canvas = ((System.Drawing.Bitmap)(resources.GetObject("btn_skin.Canvas")));
            this.btn_skin.ControlState = LayeredSkin.Controls.ControlStates.Normal;
            this.btn_skin.HaloColor = System.Drawing.Color.Transparent;
            this.btn_skin.HaloSize = 5;
            this.btn_skin.HoverImage = global::BridImage.Properties.Resources.skin1;
            this.btn_skin.IsPureColor = true;
            this.btn_skin.Location = new System.Drawing.Point(8, 6);
            this.btn_skin.Name = "btn_skin";
            this.btn_skin.NormalImage = global::BridImage.Properties.Resources.skin0;
            this.btn_skin.PressedImage = global::BridImage.Properties.Resources.skin1;
            this.btn_skin.Radius = 10;
            this.btn_skin.ShowBorder = false;
            this.btn_skin.Size = new System.Drawing.Size(16, 16);
            this.btn_skin.TabIndex = 1;
            this.btn_skin.TextLocationOffset = new System.Drawing.Point(0, 0);
            this.btn_skin.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            this.btn_skin.TextShowMode = LayeredSkin.TextShowModes.Halo;
            this.btn_skin.Click += new System.EventHandler(this.btn_skin_Click);
            this.btn_skin.MouseEnter += new System.EventHandler(this.btn_skin_MouseEnter);
            // 
            // layeredPanel_Set
            // 
            this.layeredPanel_Set.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.layeredPanel_Set.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.layeredPanel_Set.Borders.BottomColor = System.Drawing.Color.Empty;
            this.layeredPanel_Set.Borders.BottomWidth = 1;
            this.layeredPanel_Set.Borders.LeftColor = System.Drawing.Color.Empty;
            this.layeredPanel_Set.Borders.LeftWidth = 1;
            this.layeredPanel_Set.Borders.RightColor = System.Drawing.Color.Empty;
            this.layeredPanel_Set.Borders.RightWidth = 1;
            this.layeredPanel_Set.Borders.TopColor = System.Drawing.Color.Empty;
            this.layeredPanel_Set.Borders.TopWidth = 1;
            this.layeredPanel_Set.Canvas = ((System.Drawing.Bitmap)(resources.GetObject("layeredPanel_Set.Canvas")));
            this.layeredPanel_Set.Controls.Add(this.btn_set);
            this.layeredPanel_Set.Location = new System.Drawing.Point(879, 0);
            this.layeredPanel_Set.Name = "layeredPanel_Set";
            this.layeredPanel_Set.Size = new System.Drawing.Size(32, 29);
            this.layeredPanel_Set.TabIndex = 7;
            this.layeredPanel_Set.Click += new System.EventHandler(this.btn_set_Click);
            this.layeredPanel_Set.MouseEnter += new System.EventHandler(this.btn_min_MouseHover);
            this.layeredPanel_Set.MouseLeave += new System.EventHandler(this.btn_min_MouseLeave);
            // 
            // btn_set
            // 
            this.btn_set.AdaptImage = true;
            this.btn_set.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_set.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btn_set.BaseColor = System.Drawing.Color.Transparent;
            this.btn_set.Borders.BottomColor = System.Drawing.Color.Empty;
            this.btn_set.Borders.BottomWidth = 1;
            this.btn_set.Borders.LeftColor = System.Drawing.Color.Empty;
            this.btn_set.Borders.LeftWidth = 1;
            this.btn_set.Borders.RightColor = System.Drawing.Color.Empty;
            this.btn_set.Borders.RightWidth = 1;
            this.btn_set.Borders.TopColor = System.Drawing.Color.Empty;
            this.btn_set.Borders.TopWidth = 1;
            this.btn_set.Canvas = ((System.Drawing.Bitmap)(resources.GetObject("btn_set.Canvas")));
            this.btn_set.ControlState = LayeredSkin.Controls.ControlStates.Normal;
            this.btn_set.HaloColor = System.Drawing.Color.Transparent;
            this.btn_set.HaloSize = 5;
            this.btn_set.HoverImage = ((System.Drawing.Image)(resources.GetObject("btn_set.HoverImage")));
            this.btn_set.IsPureColor = true;
            this.btn_set.Location = new System.Drawing.Point(8, 6);
            this.btn_set.Name = "btn_set";
            this.btn_set.NormalImage = ((System.Drawing.Image)(resources.GetObject("btn_set.NormalImage")));
            this.btn_set.PressedImage = ((System.Drawing.Image)(resources.GetObject("btn_set.PressedImage")));
            this.btn_set.Radius = 10;
            this.btn_set.ShowBorder = false;
            this.btn_set.Size = new System.Drawing.Size(16, 16);
            this.btn_set.TabIndex = 1;
            this.btn_set.TextLocationOffset = new System.Drawing.Point(0, 0);
            this.btn_set.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            this.btn_set.TextShowMode = LayeredSkin.TextShowModes.Halo;
            this.btn_set.Click += new System.EventHandler(this.btn_set_Click);
            this.btn_set.MouseEnter += new System.EventHandler(this.btn_skin_MouseEnter);
            // 
            // BaseControl_Search
            // 
            this.BaseControl_Search.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BaseControl_Search.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.BaseControl_Search.Borders.BottomColor = System.Drawing.Color.Empty;
            this.BaseControl_Search.Borders.BottomWidth = 1;
            this.BaseControl_Search.Borders.LeftColor = System.Drawing.Color.Empty;
            this.BaseControl_Search.Borders.LeftWidth = 1;
            this.BaseControl_Search.Borders.RightColor = System.Drawing.Color.Empty;
            this.BaseControl_Search.Borders.RightWidth = 1;
            this.BaseControl_Search.Borders.TopColor = System.Drawing.Color.Empty;
            this.BaseControl_Search.Borders.TopWidth = 1;
            this.BaseControl_Search.Canvas = ((System.Drawing.Bitmap)(resources.GetObject("BaseControl_Search.Canvas")));
            duiButton5.AdaptImage = true;
            duiButton5.AutoSize = false;
            duiButton5.BackColor = System.Drawing.Color.Transparent;
            duiButton5.BackgroundImage = null;
            duiButton5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            duiButton5.BackgroundRender = null;
            duiButton5.BaseColor = System.Drawing.Color.Transparent;
            duiButton5.BitmapCache = false;
            duiButton5.BorderPath = null;
            duiButton5.BorderRender = null;
            duiButton5.Borders.BottomColor = System.Drawing.Color.Empty;
            duiButton5.Borders.BottomWidth = 1;
            duiButton5.Borders.LeftColor = System.Drawing.Color.Empty;
            duiButton5.Borders.LeftWidth = 1;
            duiButton5.Borders.RightColor = System.Drawing.Color.Empty;
            duiButton5.Borders.RightWidth = 1;
            duiButton5.Borders.TopColor = System.Drawing.Color.Empty;
            duiButton5.Borders.TopWidth = 1;
            duiButton5.CanFocus = true;
            duiButton5.ClientRectangle = new System.Drawing.Rectangle(0, 0, 240, 26);
            duiTextBox3.AutoHeight = false;
            duiTextBox3.AutoSize = false;
            duiTextBox3.BackColor = System.Drawing.Color.Transparent;
            duiTextBox3.BackgroundImage = null;
            duiTextBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            duiTextBox3.BackgroundRender = null;
            duiTextBox3.BitmapCache = false;
            duiTextBox3.BorderPath = null;
            duiTextBox3.BorderRender = null;
            duiTextBox3.Borders.BottomColor = System.Drawing.Color.Empty;
            duiTextBox3.Borders.BottomWidth = 1;
            duiTextBox3.Borders.LeftColor = System.Drawing.Color.Empty;
            duiTextBox3.Borders.LeftWidth = 1;
            duiTextBox3.Borders.RightColor = System.Drawing.Color.Empty;
            duiTextBox3.Borders.RightWidth = 1;
            duiTextBox3.Borders.TopColor = System.Drawing.Color.Empty;
            duiTextBox3.Borders.TopWidth = 1;
            duiTextBox3.CanFocus = true;
            duiTextBox3.CaretColor = System.Drawing.SystemColors.ControlText;
            duiTextBox3.CaretIndex = 0;
            duiTextBox3.ClientRectangle = new System.Drawing.Rectangle(5, 5, 230, 16);
            duiTextBox3.CurrentCursor = System.Windows.Forms.Cursors.Default;
            duiTextBox3.Cursor = System.Windows.Forms.Cursors.IBeam;
            duiTextBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            duiTextBox3.Enabled = true;
            duiTextBox3.Font = new System.Drawing.Font("宋体", 11F);
            duiTextBox3.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            duiTextBox3.Height = 16;
            duiTextBox3.IsInsert = true;
            duiTextBox3.IsMoveParentPaint = true;
            duiTextBox3.Left = 5;
            duiTextBox3.Location = new System.Drawing.Point(5, 5);
            duiTextBox3.Margin = new System.Windows.Forms.Padding(5);
            duiTextBox3.Multiline = false;
            duiTextBox3.Name = "search_text";
            duiTextBox3.ParentInvalidate = true;
            duiTextBox3.ReadOnly = false;
            duiTextBox3.RollSize = 12;
            duiTextBox3.ScrollBarBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            duiTextBox3.ScrollBarHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(158)))), ((int)(((byte)(158)))));
            duiTextBox3.ScrollBarNormalColor = System.Drawing.Color.Gray;
            duiTextBox3.ScrollBarPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            duiTextBox3.SelectionBackColor = System.Drawing.Color.Gray;
            duiTextBox3.SelectionColor = System.Drawing.Color.DarkSalmon;
            duiTextBox3.SelectionLength = 0;
            duiTextBox3.SelectionStart = 0;
            duiTextBox3.ShowBorder = false;
            duiTextBox3.ShowScrollBar = false;
            duiTextBox3.Size = new System.Drawing.Size(230, 16);
            duiTextBox3.SuspendInvalidate = false;
            duiTextBox3.Tag = null;
            duiTextBox3.Text = "输入关键字进行搜索";
            duiTextBox3.TextRenderMode = System.Drawing.Text.TextRenderingHint.SystemDefault;
            duiTextBox3.Top = 5;
            duiTextBox3.Visible = true;
            duiTextBox3.Width = 230;
            duiButton5.Controls.AddRange(new LayeredSkin.DirectUI.DuiBaseControl[] {
            duiTextBox3});
            duiButton5.ControlState = LayeredSkin.DirectUI.ControlStates.Normal;
            duiButton5.CurrentCursor = System.Windows.Forms.Cursors.Default;
            duiButton5.Cursor = System.Windows.Forms.Cursors.Default;
            duiButton5.Dock = System.Windows.Forms.DockStyle.Fill;
            duiButton5.Enabled = true;
            duiButton5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            duiButton5.ForeColor = System.Drawing.SystemColors.ControlText;
            duiButton5.Height = 26;
            duiButton5.HoverImage = null;
            duiButton5.IsMoveParentPaint = true;
            duiButton5.IsPureColor = false;
            duiButton5.Left = 0;
            duiButton5.Location = new System.Drawing.Point(0, 0);
            duiButton5.Margin = new System.Windows.Forms.Padding(0);
            duiButton5.Name = "btn_searchtext";
            duiButton5.NormalImage = null;
            duiButton5.ParentInvalidate = true;
            duiButton5.PressedImage = null;
            duiButton5.Radius = 20;
            duiButton5.ShowBorder = false;
            duiButton5.Size = new System.Drawing.Size(240, 26);
            stringFormat7.Alignment = System.Drawing.StringAlignment.Center;
            stringFormat7.HotkeyPrefix = System.Drawing.Text.HotkeyPrefix.None;
            stringFormat7.LineAlignment = System.Drawing.StringAlignment.Center;
            stringFormat7.Trimming = System.Drawing.StringTrimming.Character;
            duiButton5.StringFormat = stringFormat7;
            duiButton5.SuspendInvalidate = false;
            duiButton5.Tag = null;
            duiButton5.Text = null;
            duiButton5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            duiButton5.TextPadding = 0;
            duiButton5.Top = 0;
            duiButton5.Visible = true;
            duiButton5.Width = 240;
            duiButton6.AdaptImage = false;
            duiButton6.AutoSize = false;
            duiButton6.BackColor = System.Drawing.Color.Transparent;
            duiButton6.BackgroundImage = null;
            duiButton6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            duiButton6.BackgroundRender = null;
            duiButton6.BaseColor = System.Drawing.Color.Transparent;
            duiButton6.BitmapCache = false;
            duiButton6.BorderPath = null;
            duiButton6.BorderRender = null;
            duiButton6.Borders.BottomColor = System.Drawing.Color.Empty;
            duiButton6.Borders.BottomWidth = 1;
            duiButton6.Borders.LeftColor = System.Drawing.Color.Empty;
            duiButton6.Borders.LeftWidth = 1;
            duiButton6.Borders.RightColor = System.Drawing.Color.Empty;
            duiButton6.Borders.RightWidth = 1;
            duiButton6.Borders.TopColor = System.Drawing.Color.Empty;
            duiButton6.Borders.TopWidth = 1;
            duiButton6.CanFocus = true;
            duiButton6.ClientRectangle = new System.Drawing.Rectangle(218, 3, 20, 20);
            duiButton6.ControlState = LayeredSkin.DirectUI.ControlStates.Normal;
            duiButton6.CurrentCursor = System.Windows.Forms.Cursors.Default;
            duiButton6.Cursor = System.Windows.Forms.Cursors.Default;
            duiButton6.Dock = System.Windows.Forms.DockStyle.None;
            duiButton6.Enabled = true;
            duiButton6.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            duiButton6.ForeColor = System.Drawing.SystemColors.ControlText;
            duiButton6.Height = 20;
            duiButton6.HoverImage = global::BridImage.Properties.Resources.search1;
            duiButton6.IsMoveParentPaint = true;
            duiButton6.IsPureColor = false;
            duiButton6.Left = 218;
            duiButton6.Location = new System.Drawing.Point(218, 3);
            duiButton6.Margin = new System.Windows.Forms.Padding(0);
            duiButton6.Name = "btn_search";
            duiButton6.NormalImage = global::BridImage.Properties.Resources.search0;
            duiButton6.ParentInvalidate = true;
            duiButton6.PressedImage = global::BridImage.Properties.Resources.search1;
            duiButton6.Radius = 10;
            duiButton6.ShowBorder = true;
            duiButton6.Size = new System.Drawing.Size(20, 20);
            stringFormat8.Alignment = System.Drawing.StringAlignment.Center;
            stringFormat8.HotkeyPrefix = System.Drawing.Text.HotkeyPrefix.None;
            stringFormat8.LineAlignment = System.Drawing.StringAlignment.Center;
            stringFormat8.Trimming = System.Drawing.StringTrimming.Character;
            duiButton6.StringFormat = stringFormat8;
            duiButton6.SuspendInvalidate = false;
            duiButton6.Tag = null;
            duiButton6.Text = null;
            duiButton6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            duiButton6.TextPadding = 0;
            duiButton6.Top = 3;
            duiButton6.Visible = true;
            duiButton6.Width = 20;
            this.BaseControl_Search.DUIControls.AddRange(new LayeredSkin.DirectUI.DuiBaseControl[] {
            duiButton5,
            duiButton6});
            this.BaseControl_Search.Location = new System.Drawing.Point(408, 8);
            this.BaseControl_Search.Name = "BaseControl_Search";
            this.BaseControl_Search.Size = new System.Drawing.Size(240, 26);
            this.BaseControl_Search.TabIndex = 4;
            // 
            // layeredPictureBox2
            // 
            this.layeredPictureBox2.BackgroundImage = global::BridImage.Properties.Resources.xlbz_w;
            this.layeredPictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.layeredPictureBox2.Borders.BottomColor = System.Drawing.Color.Empty;
            this.layeredPictureBox2.Borders.BottomWidth = 1;
            this.layeredPictureBox2.Borders.LeftColor = System.Drawing.Color.Empty;
            this.layeredPictureBox2.Borders.LeftWidth = 1;
            this.layeredPictureBox2.Borders.RightColor = System.Drawing.Color.Empty;
            this.layeredPictureBox2.Borders.RightWidth = 1;
            this.layeredPictureBox2.Borders.TopColor = System.Drawing.Color.Empty;
            this.layeredPictureBox2.Borders.TopWidth = 1;
            this.layeredPictureBox2.Canvas = ((System.Drawing.Bitmap)(resources.GetObject("layeredPictureBox2.Canvas")));
            this.layeredPictureBox2.Image = null;
            this.layeredPictureBox2.Images = null;
            this.layeredPictureBox2.Interval = 100;
            this.layeredPictureBox2.Location = new System.Drawing.Point(60, 9);
            this.layeredPictureBox2.MultiImageAnimation = false;
            this.layeredPictureBox2.Name = "layeredPictureBox2";
            this.layeredPictureBox2.Size = new System.Drawing.Size(90, 19);
            this.layeredPictureBox2.TabIndex = 3;
            this.layeredPictureBox2.Text = "layeredPictureBox2";
            // 
            // layeredPictureBox1
            // 
            this.layeredPictureBox1.BackgroundImage = global::BridImage.Properties.Resources.logo;
            this.layeredPictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.layeredPictureBox1.Borders.BottomColor = System.Drawing.Color.Empty;
            this.layeredPictureBox1.Borders.BottomWidth = 1;
            this.layeredPictureBox1.Borders.LeftColor = System.Drawing.Color.Empty;
            this.layeredPictureBox1.Borders.LeftWidth = 1;
            this.layeredPictureBox1.Borders.RightColor = System.Drawing.Color.Empty;
            this.layeredPictureBox1.Borders.RightWidth = 1;
            this.layeredPictureBox1.Borders.TopColor = System.Drawing.Color.Empty;
            this.layeredPictureBox1.Borders.TopWidth = 1;
            this.layeredPictureBox1.Canvas = ((System.Drawing.Bitmap)(resources.GetObject("layeredPictureBox1.Canvas")));
            this.layeredPictureBox1.Image = null;
            this.layeredPictureBox1.Images = null;
            this.layeredPictureBox1.Interval = 100;
            this.layeredPictureBox1.Location = new System.Drawing.Point(15, 3);
            this.layeredPictureBox1.MultiImageAnimation = false;
            this.layeredPictureBox1.Name = "layeredPictureBox1";
            this.layeredPictureBox1.Size = new System.Drawing.Size(41, 32);
            this.layeredPictureBox1.TabIndex = 2;
            this.layeredPictureBox1.Text = "layeredPictureBox1";
            // 
            // btn_close
            // 
            this.btn_close.AdaptImage = true;
            this.btn_close.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_close.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btn_close.BaseColor = System.Drawing.Color.Transparent;
            this.btn_close.Borders.BottomColor = System.Drawing.Color.Empty;
            this.btn_close.Borders.BottomWidth = 1;
            this.btn_close.Borders.LeftColor = System.Drawing.Color.Empty;
            this.btn_close.Borders.LeftWidth = 1;
            this.btn_close.Borders.RightColor = System.Drawing.Color.Empty;
            this.btn_close.Borders.RightWidth = 1;
            this.btn_close.Borders.TopColor = System.Drawing.Color.Empty;
            this.btn_close.Borders.TopWidth = 1;
            this.btn_close.Canvas = ((System.Drawing.Bitmap)(resources.GetObject("btn_close.Canvas")));
            this.btn_close.ControlState = LayeredSkin.Controls.ControlStates.Normal;
            this.btn_close.HaloColor = System.Drawing.Color.Transparent;
            this.btn_close.HaloSize = 5;
            this.btn_close.HoverImage = global::BridImage.Properties.Resources.close1;
            this.btn_close.IsPureColor = true;
            this.btn_close.Location = new System.Drawing.Point(951, 7);
            this.btn_close.Name = "btn_close";
            this.btn_close.NormalImage = global::BridImage.Properties.Resources.close0;
            this.btn_close.PressedImage = global::BridImage.Properties.Resources.close1;
            this.btn_close.Radius = 10;
            this.btn_close.ShowBorder = false;
            this.btn_close.Size = new System.Drawing.Size(16, 16);
            this.btn_close.TabIndex = 1;
            this.btn_close.TextLocationOffset = new System.Drawing.Point(0, 0);
            this.btn_close.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            this.btn_close.TextShowMode = LayeredSkin.TextShowModes.Halo;
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            this.btn_close.MouseEnter += new System.EventHandler(this.btn_skin_MouseEnter);
            // 
            // btn_min
            // 
            this.btn_min.AdaptImage = true;
            this.btn_min.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_min.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btn_min.BaseColor = System.Drawing.Color.Transparent;
            this.btn_min.Borders.BottomColor = System.Drawing.Color.Empty;
            this.btn_min.Borders.BottomWidth = 1;
            this.btn_min.Borders.LeftColor = System.Drawing.Color.Empty;
            this.btn_min.Borders.LeftWidth = 1;
            this.btn_min.Borders.RightColor = System.Drawing.Color.Empty;
            this.btn_min.Borders.RightWidth = 1;
            this.btn_min.Borders.TopColor = System.Drawing.Color.Empty;
            this.btn_min.Borders.TopWidth = 1;
            this.btn_min.Canvas = ((System.Drawing.Bitmap)(resources.GetObject("btn_min.Canvas")));
            this.btn_min.ControlState = LayeredSkin.Controls.ControlStates.Normal;
            this.btn_min.HaloColor = System.Drawing.Color.Transparent;
            this.btn_min.HaloSize = 5;
            this.btn_min.HoverImage = global::BridImage.Properties.Resources.min1;
            this.btn_min.IsPureColor = true;
            this.btn_min.Location = new System.Drawing.Point(919, 7);
            this.btn_min.Name = "btn_min";
            this.btn_min.NormalImage = global::BridImage.Properties.Resources.min0;
            this.btn_min.PressedImage = global::BridImage.Properties.Resources.min1;
            this.btn_min.Radius = 10;
            this.btn_min.ShowBorder = false;
            this.btn_min.Size = new System.Drawing.Size(16, 16);
            this.btn_min.TabIndex = 0;
            this.btn_min.TextLocationOffset = new System.Drawing.Point(0, 0);
            this.btn_min.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            this.btn_min.TextShowMode = LayeredSkin.TextShowModes.Halo;
            this.btn_min.Click += new System.EventHandler(this.btn_min_Click);
            this.btn_min.MouseEnter += new System.EventHandler(this.btn_skin_MouseEnter);
            // 
            // layeredPanel_close
            // 
            this.layeredPanel_close.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.layeredPanel_close.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.layeredPanel_close.Borders.BottomColor = System.Drawing.Color.Empty;
            this.layeredPanel_close.Borders.BottomWidth = 1;
            this.layeredPanel_close.Borders.LeftColor = System.Drawing.Color.Empty;
            this.layeredPanel_close.Borders.LeftWidth = 1;
            this.layeredPanel_close.Borders.RightColor = System.Drawing.Color.Empty;
            this.layeredPanel_close.Borders.RightWidth = 1;
            this.layeredPanel_close.Borders.TopColor = System.Drawing.Color.Empty;
            this.layeredPanel_close.Borders.TopWidth = 1;
            this.layeredPanel_close.Canvas = ((System.Drawing.Bitmap)(resources.GetObject("layeredPanel_close.Canvas")));
            this.layeredPanel_close.Location = new System.Drawing.Point(943, 0);
            this.layeredPanel_close.Name = "layeredPanel_close";
            this.layeredPanel_close.Size = new System.Drawing.Size(32, 29);
            this.layeredPanel_close.TabIndex = 5;
            this.layeredPanel_close.Click += new System.EventHandler(this.btn_close_Click);
            this.layeredPanel_close.MouseEnter += new System.EventHandler(this.btn_min_MouseHover);
            this.layeredPanel_close.MouseLeave += new System.EventHandler(this.btn_min_MouseLeave);
            // 
            // layeredPanel_min
            // 
            this.layeredPanel_min.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.layeredPanel_min.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.layeredPanel_min.Borders.BottomColor = System.Drawing.Color.Empty;
            this.layeredPanel_min.Borders.BottomWidth = 1;
            this.layeredPanel_min.Borders.LeftColor = System.Drawing.Color.Empty;
            this.layeredPanel_min.Borders.LeftWidth = 1;
            this.layeredPanel_min.Borders.RightColor = System.Drawing.Color.Empty;
            this.layeredPanel_min.Borders.RightWidth = 1;
            this.layeredPanel_min.Borders.TopColor = System.Drawing.Color.Empty;
            this.layeredPanel_min.Borders.TopWidth = 1;
            this.layeredPanel_min.Canvas = ((System.Drawing.Bitmap)(resources.GetObject("layeredPanel_min.Canvas")));
            this.layeredPanel_min.Location = new System.Drawing.Point(911, 0);
            this.layeredPanel_min.Name = "layeredPanel_min";
            this.layeredPanel_min.Size = new System.Drawing.Size(32, 29);
            this.layeredPanel_min.TabIndex = 6;
            this.layeredPanel_min.Click += new System.EventHandler(this.btn_min_Click);
            this.layeredPanel_min.MouseEnter += new System.EventHandler(this.btn_min_MouseHover);
            this.layeredPanel_min.MouseLeave += new System.EventHandler(this.btn_min_MouseLeave);
            // 
            // scorllbar
            // 
            this.scorllbar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.scorllbar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.scorllbar.Borders.BottomColor = System.Drawing.Color.Empty;
            this.scorllbar.Borders.BottomWidth = 1;
            this.scorllbar.Borders.LeftColor = System.Drawing.Color.Empty;
            this.scorllbar.Borders.LeftWidth = 1;
            this.scorllbar.Borders.RightColor = System.Drawing.Color.Empty;
            this.scorllbar.Borders.RightWidth = 1;
            this.scorllbar.Borders.TopColor = System.Drawing.Color.Empty;
            this.scorllbar.Borders.TopWidth = 1;
            this.scorllbar.Canvas = ((System.Drawing.Bitmap)(resources.GetObject("scorllbar.Canvas")));
            this.scorllbar.Location = new System.Drawing.Point(970, 41);
            this.scorllbar.Name = "scorllbar";
            this.scorllbar.Size = new System.Drawing.Size(5, 50);
            this.scorllbar.TabIndex = 3;
            this.scorllbar.Visible = false;
            this.scorllbar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.scorllbar_MouseDown);
            this.scorllbar.MouseEnter += new System.EventHandler(this.scorllbar_MouseEnter);
            this.scorllbar.MouseLeave += new System.EventHandler(this.scorllbar_MouseLeave);
            this.scorllbar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.scorllbar_MouseMove);
            this.scorllbar.MouseUp += new System.Windows.Forms.MouseEventHandler(this.scorllbar_MouseUp);
            this.scorllbar.Move += new System.EventHandler(this.scorllbar_Move);
            // 
            // Panel_Bottom
            // 
            this.Panel_Bottom.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Panel_Bottom.Borders.BottomColor = System.Drawing.Color.Empty;
            this.Panel_Bottom.Borders.BottomWidth = 1;
            this.Panel_Bottom.Borders.LeftColor = System.Drawing.Color.Empty;
            this.Panel_Bottom.Borders.LeftWidth = 1;
            this.Panel_Bottom.Borders.RightColor = System.Drawing.Color.Empty;
            this.Panel_Bottom.Borders.RightWidth = 1;
            this.Panel_Bottom.Borders.TopColor = System.Drawing.Color.Empty;
            this.Panel_Bottom.Borders.TopWidth = 1;
            this.Panel_Bottom.Canvas = ((System.Drawing.Bitmap)(resources.GetObject("Panel_Bottom.Canvas")));
            this.Panel_Bottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Panel_Bottom.Location = new System.Drawing.Point(0, 634);
            this.Panel_Bottom.Name = "Panel_Bottom";
            this.Panel_Bottom.Size = new System.Drawing.Size(975, 10);
            this.Panel_Bottom.TabIndex = 5;
            // 
            // Panel_Type
            // 
            this.Panel_Type.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Panel_Type.Borders.BottomColor = System.Drawing.Color.Empty;
            this.Panel_Type.Borders.BottomWidth = 1;
            this.Panel_Type.Borders.LeftColor = System.Drawing.Color.Empty;
            this.Panel_Type.Borders.LeftWidth = 1;
            this.Panel_Type.Borders.RightColor = System.Drawing.Color.Empty;
            this.Panel_Type.Borders.RightWidth = 1;
            this.Panel_Type.Borders.TopColor = System.Drawing.Color.Empty;
            this.Panel_Type.Borders.TopWidth = 1;
            this.Panel_Type.Canvas = ((System.Drawing.Bitmap)(resources.GetObject("Panel_Type.Canvas")));
            this.Panel_Type.Dock = System.Windows.Forms.DockStyle.Top;
            this.Panel_Type.Location = new System.Drawing.Point(0, 41);
            this.Panel_Type.Name = "Panel_Type";
            this.Panel_Type.Size = new System.Drawing.Size(975, 36);
            this.Panel_Type.TabIndex = 6;
            // 
            // Panel_TypeMess
            // 
            this.Panel_TypeMess.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Panel_TypeMess.Borders.BottomColor = System.Drawing.Color.Empty;
            this.Panel_TypeMess.Borders.BottomWidth = 1;
            this.Panel_TypeMess.Borders.LeftColor = System.Drawing.Color.Empty;
            this.Panel_TypeMess.Borders.LeftWidth = 1;
            this.Panel_TypeMess.Borders.RightColor = System.Drawing.Color.Empty;
            this.Panel_TypeMess.Borders.RightWidth = 1;
            this.Panel_TypeMess.Borders.TopColor = System.Drawing.Color.Empty;
            this.Panel_TypeMess.Borders.TopWidth = 1;
            this.Panel_TypeMess.Canvas = ((System.Drawing.Bitmap)(resources.GetObject("Panel_TypeMess.Canvas")));
            this.Panel_TypeMess.Location = new System.Drawing.Point(0, 76);
            this.Panel_TypeMess.Name = "Panel_TypeMess";
            this.Panel_TypeMess.Size = new System.Drawing.Size(74, 100);
            this.Panel_TypeMess.TabIndex = 0;
            this.Panel_TypeMess.Visible = false;
            this.Panel_TypeMess.MouseEnter += new System.EventHandler(this.TypeControl_MouseEnter);
            this.Panel_TypeMess.MouseLeave += new System.EventHandler(this.TypeControl_MouseLeave);
            // 
            // Panel_load
            // 
            this.Panel_load.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Panel_load.Borders.BottomColor = System.Drawing.Color.Empty;
            this.Panel_load.Borders.BottomWidth = 1;
            this.Panel_load.Borders.LeftColor = System.Drawing.Color.Empty;
            this.Panel_load.Borders.LeftWidth = 1;
            this.Panel_load.Borders.RightColor = System.Drawing.Color.Empty;
            this.Panel_load.Borders.RightWidth = 1;
            this.Panel_load.Borders.TopColor = System.Drawing.Color.Empty;
            this.Panel_load.Borders.TopWidth = 1;
            this.Panel_load.Canvas = ((System.Drawing.Bitmap)(resources.GetObject("Panel_load.Canvas")));
            this.Panel_load.Dock = System.Windows.Forms.DockStyle.Fill;
            duiPictureBox3.AutoPlay = true;
            duiPictureBox3.AutoSize = false;
            duiPictureBox3.BackColor = System.Drawing.Color.Transparent;
            duiPictureBox3.BackgroundImage = null;
            duiPictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            duiPictureBox3.BackgroundRender = null;
            duiPictureBox3.BitmapCache = false;
            duiPictureBox3.BorderPath = null;
            duiPictureBox3.BorderRender = null;
            duiPictureBox3.Borders.BottomColor = System.Drawing.Color.Empty;
            duiPictureBox3.Borders.BottomWidth = 1;
            duiPictureBox3.Borders.LeftColor = System.Drawing.Color.Empty;
            duiPictureBox3.Borders.LeftWidth = 1;
            duiPictureBox3.Borders.RightColor = System.Drawing.Color.Empty;
            duiPictureBox3.Borders.RightWidth = 1;
            duiPictureBox3.Borders.TopColor = System.Drawing.Color.Empty;
            duiPictureBox3.Borders.TopWidth = 1;
            duiPictureBox3.CanFocus = true;
            duiPictureBox3.ClientRectangle = new System.Drawing.Rectangle(437, 200, 100, 100);
            duiPictureBox3.CurrentCursor = System.Windows.Forms.Cursors.Default;
            duiPictureBox3.Cursor = System.Windows.Forms.Cursors.Default;
            duiPictureBox3.Dock = System.Windows.Forms.DockStyle.None;
            duiPictureBox3.Enabled = true;
            duiPictureBox3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            duiPictureBox3.ForeColor = System.Drawing.SystemColors.ControlText;
            duiPictureBox3.Height = 100;
            duiPictureBox3.Image = null;
            duiPictureBox3.Images = null;
            duiPictureBox3.Interval = 130;
            duiPictureBox3.IsMoveParentPaint = true;
            duiPictureBox3.Left = 437;
            duiPictureBox3.Location = new System.Drawing.Point(437, 200);
            duiPictureBox3.Margin = new System.Windows.Forms.Padding(0);
            duiPictureBox3.MultiImageAnimation = false;
            duiPictureBox3.Name = "load_imgs";
            duiPictureBox3.ParentInvalidate = true;
            duiPictureBox3.ShowBorder = true;
            duiPictureBox3.Size = new System.Drawing.Size(100, 100);
            duiPictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal;
            duiPictureBox3.SuspendInvalidate = false;
            duiPictureBox3.Tag = null;
            duiPictureBox3.Top = 200;
            duiPictureBox3.Visible = true;
            duiPictureBox3.Width = 100;
            duiLabel3.AutoSize = false;
            duiLabel3.BackColor = System.Drawing.Color.Transparent;
            duiLabel3.BackgroundImage = null;
            duiLabel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            duiLabel3.BackgroundRender = null;
            duiLabel3.BitmapCache = false;
            duiLabel3.BorderPath = null;
            duiLabel3.BorderRender = null;
            duiLabel3.Borders.BottomColor = System.Drawing.Color.Empty;
            duiLabel3.Borders.BottomWidth = 1;
            duiLabel3.Borders.LeftColor = System.Drawing.Color.Empty;
            duiLabel3.Borders.LeftWidth = 1;
            duiLabel3.Borders.RightColor = System.Drawing.Color.Empty;
            duiLabel3.Borders.RightWidth = 1;
            duiLabel3.Borders.TopColor = System.Drawing.Color.Empty;
            duiLabel3.Borders.TopWidth = 1;
            duiLabel3.CanFocus = true;
            duiLabel3.ClientRectangle = new System.Drawing.Rectangle(238, 300, 500, 50);
            duiLabel3.CurrentCursor = System.Windows.Forms.Cursors.Default;
            duiLabel3.Cursor = System.Windows.Forms.Cursors.Default;
            duiLabel3.Dock = System.Windows.Forms.DockStyle.None;
            duiLabel3.Enabled = true;
            duiLabel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            duiLabel3.ForeColor = System.Drawing.SystemColors.HighlightText;
            duiLabel3.Height = 50;
            duiLabel3.IsMoveParentPaint = true;
            duiLabel3.Left = 238;
            duiLabel3.Location = new System.Drawing.Point(238, 300);
            duiLabel3.Margin = new System.Windows.Forms.Padding(0);
            duiLabel3.Name = "load_text";
            duiLabel3.ParentInvalidate = true;
            duiLabel3.ShowBorder = true;
            duiLabel3.Size = new System.Drawing.Size(500, 50);
            stringFormat9.Alignment = System.Drawing.StringAlignment.Center;
            stringFormat9.HotkeyPrefix = System.Drawing.Text.HotkeyPrefix.None;
            stringFormat9.LineAlignment = System.Drawing.StringAlignment.Center;
            stringFormat9.Trimming = System.Drawing.StringTrimming.Character;
            duiLabel3.StringFormat = stringFormat9;
            duiLabel3.SuspendInvalidate = false;
            duiLabel3.Tag = null;
            duiLabel3.Text = "正在加载中......";
            duiLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            duiLabel3.TextPadding = 0;
            duiLabel3.Top = 300;
            duiLabel3.Visible = true;
            duiLabel3.Width = 500;
            this.Panel_load.DUIControls.AddRange(new LayeredSkin.DirectUI.DuiBaseControl[] {
            duiPictureBox3,
            duiLabel3});
            this.Panel_load.Location = new System.Drawing.Point(0, 77);
            this.Panel_load.Name = "Panel_load";
            this.Panel_load.Size = new System.Drawing.Size(975, 557);
            this.Panel_load.TabIndex = 7;
            this.Panel_load.Visible = false;
            // 
            // panel_ctEndLine
            // 
            this.panel_ctEndLine.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panel_ctEndLine.Borders.BottomColor = System.Drawing.Color.Empty;
            this.panel_ctEndLine.Borders.BottomWidth = 1;
            this.panel_ctEndLine.Borders.LeftColor = System.Drawing.Color.Empty;
            this.panel_ctEndLine.Borders.LeftWidth = 1;
            this.panel_ctEndLine.Borders.RightColor = System.Drawing.Color.Empty;
            this.panel_ctEndLine.Borders.RightWidth = 1;
            this.panel_ctEndLine.Borders.TopColor = System.Drawing.Color.Empty;
            this.panel_ctEndLine.Borders.TopWidth = 1;
            this.panel_ctEndLine.Canvas = ((System.Drawing.Bitmap)(resources.GetObject("panel_ctEndLine.Canvas")));
            this.panel_ctEndLine.Location = new System.Drawing.Point(12, 448);
            this.panel_ctEndLine.Name = "panel_ctEndLine";
            this.panel_ctEndLine.Size = new System.Drawing.Size(897, 30);
            this.panel_ctEndLine.TabIndex = 1;
            // 
            // List_Main
            // 
            this.List_Main.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.List_Main.AutoFocus = false;
            this.List_Main.BackColor = System.Drawing.Color.Transparent;
            this.List_Main.Borders.BottomColor = System.Drawing.Color.Empty;
            this.List_Main.Borders.BottomWidth = 1;
            this.List_Main.Borders.LeftColor = System.Drawing.Color.Empty;
            this.List_Main.Borders.LeftWidth = 1;
            this.List_Main.Borders.RightColor = System.Drawing.Color.Empty;
            this.List_Main.Borders.RightWidth = 1;
            this.List_Main.Borders.TopColor = System.Drawing.Color.Empty;
            this.List_Main.Borders.TopWidth = 1;
            this.List_Main.Canvas = ((System.Drawing.Bitmap)(resources.GetObject("List_Main.Canvas")));
            this.List_Main.EnabledMouseWheel = true;
            this.List_Main.ItemSize = new System.Drawing.Size(100, 100);
            this.List_Main.ListTop = 0;
            this.List_Main.Location = new System.Drawing.Point(0, 78);
            this.List_Main.Name = "List_Main";
            this.List_Main.Orientation = LayeredSkin.Controls.ListOrientation.Vertical;
            this.List_Main.RollSize = 20;
            this.List_Main.ScrollBarBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.List_Main.ScrollBarColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.List_Main.ScrollBarHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.List_Main.ScrollBarWidth = 10;
            this.List_Main.ShowScrollBar = false;
            this.List_Main.Size = new System.Drawing.Size(975, 556);
            this.List_Main.SmoothScroll = false;
            this.List_Main.TabIndex = 4;
            this.List_Main.Text = "imageListControl1";
            this.List_Main.Ulmul = false;
            this.List_Main.Value = 0D;
            this.List_Main.RefreshListed += new System.EventHandler(this.List_Main_RefreshListed);
            this.List_Main.ValueChanged += new System.EventHandler(this.List_Main_ValueChanged);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "小鸟壁纸";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseClick);
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // BackForm
            // 
            this.AnimationType = LayeredSkin.Forms.AnimationTypes.ThreeDTurn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(975, 644);
            this.Controls.Add(this.Panel_load);
            this.Controls.Add(this.panel_ctEndLine);
            this.Controls.Add(this.Panel_TypeMess);
            this.Controls.Add(this.Panel_Type);
            this.Controls.Add(this.Panel_Bottom);
            this.Controls.Add(this.scorllbar);
            this.Controls.Add(this.layeredPanel_top);
            this.Controls.Add(this.List_Main);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "BackForm";
            this.Radius = 15;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "";
            this.Load += new System.EventHandler(this.BackForm_Load);
            this.layeredPanel_top.ResumeLayout(false);
            this.layeredPanel_skin.ResumeLayout(false);
            this.layeredPanel_Set.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private LayeredSkin.Controls.LayeredPanel layeredPanel_top;
        private LayeredSkin.Controls.LayeredButton btn_min;
        private LayeredSkin.Controls.LayeredButton btn_close;
        private LayeredSkin.Controls.LayeredBaseControl scorllbar;
        private Controls.ImageListControl List_Main;
        private LayeredSkin.Controls.LayeredPanel Panel_Bottom;
        private LayeredSkin.Controls.LayeredPictureBox layeredPictureBox1;
        private LayeredSkin.Controls.LayeredPictureBox layeredPictureBox2;
        private LayeredSkin.Controls.LayeredBaseControl BaseControl_Search;
        private LayeredSkin.Controls.LayeredPanel layeredPanel_close;
        private LayeredSkin.Controls.LayeredPanel layeredPanel_min;
        private LayeredSkin.Controls.LayeredPanel Panel_Type;
        private LayeredSkin.Controls.LayeredPanel Panel_TypeMess;
        private LayeredSkin.Controls.LayeredPanel Panel_load;
        private LayeredSkin.Controls.LayeredPanel panel_ctEndLine;
        private LayeredSkin.Controls.LayeredPanel layeredPanel_Set;
        private LayeredSkin.Controls.LayeredButton btn_set;
        private LayeredSkin.Controls.LayeredPanel layeredPanel_skin;
        private LayeredSkin.Controls.LayeredButton btn_skin;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
    }
}