﻿namespace MaiinTimer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BackForm));
            LayeredSkin.DirectUI.DuiTextBox duiTextBox1 = new LayeredSkin.DirectUI.DuiTextBox();
            this.layeredPanel_top = new LayeredSkin.Controls.LayeredPanel();
            this.layeredPictureBox2 = new LayeredSkin.Controls.LayeredPictureBox();
            this.layeredPictureBox1 = new LayeredSkin.Controls.LayeredPictureBox();
            this.btn_close = new LayeredSkin.Controls.LayeredButton();
            this.btn_min = new LayeredSkin.Controls.LayeredButton();
            this.scorllbar = new LayeredSkin.Controls.LayeredBaseControl();
            this.Panel_Bottom = new LayeredSkin.Controls.LayeredPanel();
            this.List_Main = new MaiinTimer.Controls.ImageListControl();
            this.layeredBaseControl1 = new LayeredSkin.Controls.LayeredBaseControl();
            this.layeredPanel_top.SuspendLayout();
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
            this.layeredPanel_top.Controls.Add(this.layeredBaseControl1);
            this.layeredPanel_top.Controls.Add(this.layeredPictureBox2);
            this.layeredPanel_top.Controls.Add(this.layeredPictureBox1);
            this.layeredPanel_top.Controls.Add(this.btn_close);
            this.layeredPanel_top.Controls.Add(this.btn_min);
            this.layeredPanel_top.Dock = System.Windows.Forms.DockStyle.Top;
            this.layeredPanel_top.Location = new System.Drawing.Point(0, 0);
            this.layeredPanel_top.Name = "layeredPanel_top";
            this.layeredPanel_top.Size = new System.Drawing.Size(914, 41);
            this.layeredPanel_top.TabIndex = 0;
            this.layeredPanel_top.MouseDown += new System.Windows.Forms.MouseEventHandler(this.layeredPanel_top_MouseDown);
            // 
            // layeredPictureBox2
            // 
            this.layeredPictureBox2.BackgroundImage = global::MaiinTimer.Properties.Resources.xlbz_w;
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
            this.layeredPictureBox1.BackgroundImage = global::MaiinTimer.Properties.Resources.logo;
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
            this.btn_close.HoverImage = global::MaiinTimer.Properties.Resources.close1;
            this.btn_close.IsPureColor = true;
            this.btn_close.Location = new System.Drawing.Point(886, 12);
            this.btn_close.Name = "btn_close";
            this.btn_close.NormalImage = global::MaiinTimer.Properties.Resources.close0;
            this.btn_close.PressedImage = global::MaiinTimer.Properties.Resources.close1;
            this.btn_close.Radius = 10;
            this.btn_close.ShowBorder = false;
            this.btn_close.Size = new System.Drawing.Size(16, 16);
            this.btn_close.TabIndex = 1;
            this.btn_close.TextLocationOffset = new System.Drawing.Point(0, 0);
            this.btn_close.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            this.btn_close.TextShowMode = LayeredSkin.TextShowModes.Halo;
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            this.btn_close.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_min_MouseDown);
            this.btn_close.MouseLeave += new System.EventHandler(this.btn_min_MouseLeave);
            this.btn_close.MouseHover += new System.EventHandler(this.btn_min_MouseHover);
            // 
            // btn_min
            // 
            this.btn_min.AdaptImage = true;
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
            this.btn_min.HoverImage = global::MaiinTimer.Properties.Resources.min1;
            this.btn_min.IsPureColor = true;
            this.btn_min.Location = new System.Drawing.Point(858, 12);
            this.btn_min.Name = "btn_min";
            this.btn_min.NormalImage = global::MaiinTimer.Properties.Resources.min0;
            this.btn_min.PressedImage = global::MaiinTimer.Properties.Resources.min1;
            this.btn_min.Radius = 10;
            this.btn_min.ShowBorder = false;
            this.btn_min.Size = new System.Drawing.Size(16, 16);
            this.btn_min.TabIndex = 0;
            this.btn_min.TextLocationOffset = new System.Drawing.Point(0, 0);
            this.btn_min.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            this.btn_min.TextShowMode = LayeredSkin.TextShowModes.Halo;
            this.btn_min.Click += new System.EventHandler(this.btn_min_Click);
            this.btn_min.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_min_MouseDown);
            this.btn_min.MouseLeave += new System.EventHandler(this.btn_min_MouseLeave);
            this.btn_min.MouseHover += new System.EventHandler(this.btn_min_MouseHover);
            // 
            // scorllbar
            // 
            this.scorllbar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
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
            this.scorllbar.Location = new System.Drawing.Point(909, 41);
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
            this.Panel_Bottom.Location = new System.Drawing.Point(0, 616);
            this.Panel_Bottom.Name = "Panel_Bottom";
            this.Panel_Bottom.Size = new System.Drawing.Size(914, 30);
            this.Panel_Bottom.TabIndex = 5;
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
            this.List_Main.Location = new System.Drawing.Point(0, 41);
            this.List_Main.Name = "List_Main";
            this.List_Main.Orientation = LayeredSkin.Controls.ListOrientation.Vertical;
            this.List_Main.RollSize = 20;
            this.List_Main.ScrollBarBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.List_Main.ScrollBarColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.List_Main.ScrollBarHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.List_Main.ScrollBarWidth = 10;
            this.List_Main.ShowScrollBar = false;
            this.List_Main.Size = new System.Drawing.Size(914, 575);
            this.List_Main.SmoothScroll = false;
            this.List_Main.TabIndex = 4;
            this.List_Main.Text = "imageListControl1";
            this.List_Main.Ulmul = false;
            this.List_Main.Value = 0D;
            this.List_Main.RefreshListed += new System.EventHandler(this.List_Main_RefreshListed);
            // 
            // layeredBaseControl1
            // 
            this.layeredBaseControl1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.layeredBaseControl1.Borders.BottomColor = System.Drawing.Color.Empty;
            this.layeredBaseControl1.Borders.BottomWidth = 1;
            this.layeredBaseControl1.Borders.LeftColor = System.Drawing.Color.Empty;
            this.layeredBaseControl1.Borders.LeftWidth = 1;
            this.layeredBaseControl1.Borders.RightColor = System.Drawing.Color.Empty;
            this.layeredBaseControl1.Borders.RightWidth = 1;
            this.layeredBaseControl1.Borders.TopColor = System.Drawing.Color.Empty;
            this.layeredBaseControl1.Borders.TopWidth = 1;
            this.layeredBaseControl1.Canvas = ((System.Drawing.Bitmap)(resources.GetObject("layeredBaseControl1.Canvas")));
            duiTextBox1.AutoHeight = false;
            duiTextBox1.AutoSize = false;
            duiTextBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            duiTextBox1.BackgroundImage = null;
            duiTextBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            duiTextBox1.BackgroundRender = null;
            duiTextBox1.BitmapCache = false;
            duiTextBox1.BorderPath = null;
            duiTextBox1.BorderRender = null;
            duiTextBox1.Borders.BottomColor = System.Drawing.Color.Empty;
            duiTextBox1.Borders.BottomWidth = 1;
            duiTextBox1.Borders.LeftColor = System.Drawing.Color.Empty;
            duiTextBox1.Borders.LeftWidth = 1;
            duiTextBox1.Borders.RightColor = System.Drawing.Color.Empty;
            duiTextBox1.Borders.RightWidth = 1;
            duiTextBox1.Borders.TopColor = System.Drawing.Color.Empty;
            duiTextBox1.Borders.TopWidth = 1;
            duiTextBox1.CanFocus = true;
            duiTextBox1.CaretColor = System.Drawing.SystemColors.ControlText;
            duiTextBox1.CaretIndex = 0;
            duiTextBox1.ClientRectangle = new System.Drawing.Rectangle(0, 0, 165, 19);
            duiTextBox1.CurrentCursor = System.Windows.Forms.Cursors.Default;
            duiTextBox1.Cursor = System.Windows.Forms.Cursors.IBeam;
            duiTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            duiTextBox1.Enabled = true;
            duiTextBox1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            duiTextBox1.ForeColor = System.Drawing.SystemColors.ControlText;
            duiTextBox1.Height = 19;
            duiTextBox1.IsInsert = true;
            duiTextBox1.IsMoveParentPaint = true;
            duiTextBox1.Left = 0;
            duiTextBox1.Location = new System.Drawing.Point(0, 0);
            duiTextBox1.Margin = new System.Windows.Forms.Padding(0);
            duiTextBox1.Multiline = false;
            duiTextBox1.Name = "search_Text";
            duiTextBox1.ParentInvalidate = true;
            duiTextBox1.ReadOnly = false;
            duiTextBox1.RollSize = 12;
            duiTextBox1.ScrollBarBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            duiTextBox1.ScrollBarHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(158)))), ((int)(((byte)(158)))));
            duiTextBox1.ScrollBarNormalColor = System.Drawing.Color.Gray;
            duiTextBox1.ScrollBarPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            duiTextBox1.SelectionBackColor = System.Drawing.Color.Gray;
            duiTextBox1.SelectionColor = System.Drawing.Color.Salmon;
            duiTextBox1.SelectionLength = 0;
            duiTextBox1.SelectionStart = 0;
            duiTextBox1.ShowBorder = true;
            duiTextBox1.ShowScrollBar = false;
            duiTextBox1.Size = new System.Drawing.Size(165, 19);
            duiTextBox1.SuspendInvalidate = false;
            duiTextBox1.Tag = null;
            duiTextBox1.Text = "杨幂";
            duiTextBox1.TextRenderMode = System.Drawing.Text.TextRenderingHint.SystemDefault;
            duiTextBox1.Top = 0;
            duiTextBox1.Visible = true;
            duiTextBox1.Width = 165;
            this.layeredBaseControl1.DUIControls.AddRange(new LayeredSkin.DirectUI.DuiBaseControl[] {
            duiTextBox1});
            this.layeredBaseControl1.Location = new System.Drawing.Point(188, 9);
            this.layeredBaseControl1.Name = "layeredBaseControl1";
            this.layeredBaseControl1.Size = new System.Drawing.Size(165, 19);
            this.layeredBaseControl1.TabIndex = 4;
            // 
            // BackForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.ClientSize = new System.Drawing.Size(914, 646);
            this.Controls.Add(this.Panel_Bottom);
            this.Controls.Add(this.scorllbar);
            this.Controls.Add(this.layeredPanel_top);
            this.Controls.Add(this.List_Main);
            this.Name = "BackForm";
            this.Radius = 15;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "";
            this.Load += new System.EventHandler(this.BackForm_Load);
            this.layeredPanel_top.ResumeLayout(false);
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
        private LayeredSkin.Controls.LayeredBaseControl layeredBaseControl1;
    }
}