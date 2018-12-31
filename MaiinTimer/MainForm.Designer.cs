namespace MaiinTimer
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
            this.layeredButton1 = new LayeredSkin.Controls.LayeredButton();
            this.layeredPanel_top = new LayeredSkin.Controls.LayeredPanel();
            this.btn_close = new LayeredSkin.Controls.LayeredButton();
            this.btn_min = new LayeredSkin.Controls.LayeredButton();
            this.layeredPanel_top.SuspendLayout();
            this.SuspendLayout();
            // 
            // layeredButton1
            // 
            this.layeredButton1.AdaptImage = true;
            this.layeredButton1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.layeredButton1.BaseColor = System.Drawing.Color.Wheat;
            this.layeredButton1.Borders.BottomColor = System.Drawing.Color.Empty;
            this.layeredButton1.Borders.BottomWidth = 1;
            this.layeredButton1.Borders.LeftColor = System.Drawing.Color.Empty;
            this.layeredButton1.Borders.LeftWidth = 1;
            this.layeredButton1.Borders.RightColor = System.Drawing.Color.Empty;
            this.layeredButton1.Borders.RightWidth = 1;
            this.layeredButton1.Borders.TopColor = System.Drawing.Color.Empty;
            this.layeredButton1.Borders.TopWidth = 1;
            this.layeredButton1.Canvas = ((System.Drawing.Bitmap)(resources.GetObject("layeredButton1.Canvas")));
            this.layeredButton1.ControlState = LayeredSkin.Controls.ControlStates.Normal;
            this.layeredButton1.HaloColor = System.Drawing.Color.White;
            this.layeredButton1.HaloSize = 5;
            this.layeredButton1.HoverImage = null;
            this.layeredButton1.IsPureColor = false;
            this.layeredButton1.Location = new System.Drawing.Point(145, 93);
            this.layeredButton1.Name = "layeredButton1";
            this.layeredButton1.NormalImage = null;
            this.layeredButton1.PressedImage = null;
            this.layeredButton1.Radius = 10;
            this.layeredButton1.ShowBorder = true;
            this.layeredButton1.Size = new System.Drawing.Size(163, 100);
            this.layeredButton1.TabIndex = 0;
            this.layeredButton1.Text = "layeredButton1";
            this.layeredButton1.TextLocationOffset = new System.Drawing.Point(0, 0);
            this.layeredButton1.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            this.layeredButton1.TextShowMode = LayeredSkin.TextShowModes.Halo;
            this.layeredButton1.Click += new System.EventHandler(this.layeredButton1_Click);
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
            this.layeredPanel_top.Controls.Add(this.btn_close);
            this.layeredPanel_top.Controls.Add(this.btn_min);
            this.layeredPanel_top.Dock = System.Windows.Forms.DockStyle.Top;
            this.layeredPanel_top.Location = new System.Drawing.Point(0, 0);
            this.layeredPanel_top.Name = "layeredPanel_top";
            this.layeredPanel_top.Size = new System.Drawing.Size(439, 41);
            this.layeredPanel_top.TabIndex = 1;
            this.layeredPanel_top.MouseDown += new System.Windows.Forms.MouseEventHandler(this.layeredPanel_top_MouseDown);
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
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(439, 281);
            this.Controls.Add(this.layeredPanel_top);
            this.Controls.Add(this.layeredButton1);
            this.Name = "MainForm";
            this.Radius = 15;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "定时器";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.layeredPanel_top.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private LayeredSkin.Controls.LayeredButton layeredButton1;
        private LayeredSkin.Controls.LayeredPanel layeredPanel_top;
        private LayeredSkin.Controls.LayeredButton btn_close;
        private LayeredSkin.Controls.LayeredButton btn_min;
    }
}

