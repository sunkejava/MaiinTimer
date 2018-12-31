﻿namespace MaiinTimer
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.layeredPanel_top = new LayeredSkin.Controls.LayeredPanel();
            this.btn_skin = new LayeredSkin.Controls.LayeredButton();
            this.btn_close = new LayeredSkin.Controls.LayeredButton();
            this.btn_min = new LayeredSkin.Controls.LayeredButton();
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
            this.layeredPanel_top.Controls.Add(this.btn_skin);
            this.layeredPanel_top.Controls.Add(this.btn_close);
            this.layeredPanel_top.Controls.Add(this.btn_min);
            this.layeredPanel_top.Dock = System.Windows.Forms.DockStyle.Top;
            this.layeredPanel_top.Location = new System.Drawing.Point(0, 0);
            this.layeredPanel_top.Name = "layeredPanel_top";
            this.layeredPanel_top.Size = new System.Drawing.Size(439, 41);
            this.layeredPanel_top.TabIndex = 1;
            this.layeredPanel_top.MouseDown += new System.Windows.Forms.MouseEventHandler(this.layeredPanel_top_MouseDown);
            // 
            // btn_skin
            // 
            this.btn_skin.AdaptImage = true;
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
            this.btn_skin.HoverImage = global::MaiinTimer.Properties.Resources.skin1;
            this.btn_skin.IsPureColor = true;
            this.btn_skin.Location = new System.Drawing.Point(366, 12);
            this.btn_skin.Name = "btn_skin";
            this.btn_skin.NormalImage = global::MaiinTimer.Properties.Resources.skin0;
            this.btn_skin.PressedImage = global::MaiinTimer.Properties.Resources.skin1;
            this.btn_skin.Radius = 10;
            this.btn_skin.ShowBorder = false;
            this.btn_skin.Size = new System.Drawing.Size(16, 16);
            this.btn_skin.TabIndex = 3;
            this.btn_skin.TextLocationOffset = new System.Drawing.Point(0, 0);
            this.btn_skin.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            this.btn_skin.TextShowMode = LayeredSkin.TextShowModes.Halo;
            this.btn_skin.Click += new System.EventHandler(this.layeredButton1_Click);
            this.btn_skin.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_skin_MouseDown);
            this.btn_skin.MouseLeave += new System.EventHandler(this.btn_skin_MouseLeave);
            this.btn_skin.MouseHover += new System.EventHandler(this.btn_skin_MouseHover);
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
            this.btn_close.Location = new System.Drawing.Point(415, 12);
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
            this.btn_close.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_skin_MouseDown);
            this.btn_close.MouseLeave += new System.EventHandler(this.btn_skin_MouseLeave);
            this.btn_close.MouseHover += new System.EventHandler(this.btn_skin_MouseHover);
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
            this.btn_min.Location = new System.Drawing.Point(388, 12);
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
            this.btn_min.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_skin_MouseDown);
            this.btn_min.MouseLeave += new System.EventHandler(this.btn_skin_MouseLeave);
            this.btn_min.MouseHover += new System.EventHandler(this.btn_skin_MouseHover);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(439, 281);
            this.Controls.Add(this.layeredPanel_top);
            this.Name = "MainForm";
            this.Radius = 15;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "定时器";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.layeredPanel_top.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private LayeredSkin.Controls.LayeredPanel layeredPanel_top;
        private LayeredSkin.Controls.LayeredButton btn_close;
        private LayeredSkin.Controls.LayeredButton btn_min;
        private LayeredSkin.Controls.LayeredButton btn_skin;
    }
}
