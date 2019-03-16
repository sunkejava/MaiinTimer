namespace BridImage
{
    partial class UpdateForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UpdateForm));
            LayeredSkin.DirectUI.DuiTextBox duiTextBox3 = new LayeredSkin.DirectUI.DuiTextBox();
            this.layeredPanel_close = new LayeredSkin.Controls.LayeredPanel();
            this.btn_close = new LayeredSkin.Controls.LayeredButton();
            this.customHxjdt = new BridImage.Controls.CustomHxjdtControl();
            this.layeredBaseControl1 = new LayeredSkin.Controls.LayeredBaseControl();
            this.layeredPanel_close.SuspendLayout();
            this.SuspendLayout();
            // 
            // layeredPanel_close
            // 
            this.layeredPanel_close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
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
            this.layeredPanel_close.Controls.Add(this.btn_close);
            this.layeredPanel_close.Location = new System.Drawing.Point(363, -2);
            this.layeredPanel_close.Name = "layeredPanel_close";
            this.layeredPanel_close.Size = new System.Drawing.Size(32, 29);
            this.layeredPanel_close.TabIndex = 6;
            this.layeredPanel_close.MouseEnter += new System.EventHandler(this.btn_close_MouseEnter);
            this.layeredPanel_close.MouseLeave += new System.EventHandler(this.layeredPanel_close_MouseLeave);
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
            this.btn_close.Location = new System.Drawing.Point(8, 6);
            this.btn_close.Name = "btn_close";
            this.btn_close.NormalImage = global::BridImage.Properties.Resources.close0;
            this.btn_close.PressedImage = global::BridImage.Properties.Resources.close1;
            this.btn_close.Radius = 10;
            this.btn_close.ShowBorder = false;
            this.btn_close.Size = new System.Drawing.Size(16, 16);
            this.btn_close.TabIndex = 2;
            this.btn_close.TextLocationOffset = new System.Drawing.Point(0, 0);
            this.btn_close.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            this.btn_close.TextShowMode = LayeredSkin.TextShowModes.Halo;
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            this.btn_close.MouseEnter += new System.EventHandler(this.btn_close_MouseEnter);
            // 
            // customHxjdt
            // 
            this.customHxjdt.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.customHxjdt.Borders.BottomColor = System.Drawing.Color.Empty;
            this.customHxjdt.Borders.BottomWidth = 1;
            this.customHxjdt.Borders.LeftColor = System.Drawing.Color.Empty;
            this.customHxjdt.Borders.LeftWidth = 1;
            this.customHxjdt.Borders.RightColor = System.Drawing.Color.Empty;
            this.customHxjdt.Borders.RightWidth = 1;
            this.customHxjdt.Borders.TopColor = System.Drawing.Color.Empty;
            this.customHxjdt.Borders.TopWidth = 1;
            this.customHxjdt.Canvas = ((System.Drawing.Bitmap)(resources.GetObject("customHxjdt.Canvas")));
            this.customHxjdt.CircularWidth = 30;
            this.customHxjdt.Lcp = System.Drawing.Drawing2D.LineCap.Round;
            this.customHxjdt.Location = new System.Drawing.Point(73, 30);
            this.customHxjdt.MainColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(92)))), ((int)(((byte)(138)))));
            this.customHxjdt.Name = "customHxjdt";
            this.customHxjdt.Size = new System.Drawing.Size(250, 250);
            this.customHxjdt.TabIndex = 7;
            this.customHxjdt.Text = "customHxjdtControl1";
            this.customHxjdt.Value = 30;
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
            duiTextBox3.AutoHeight = false;
            duiTextBox3.AutoSize = false;
            duiTextBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
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
            duiTextBox3.ClientRectangle = new System.Drawing.Rectangle(0, 0, 100, 12);
            duiTextBox3.CurrentCursor = System.Windows.Forms.Cursors.Default;
            duiTextBox3.Cursor = System.Windows.Forms.Cursors.IBeam;
            duiTextBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            duiTextBox3.Enabled = true;
            duiTextBox3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            duiTextBox3.ForeColor = System.Drawing.SystemColors.ControlText;
            duiTextBox3.Height = 12;
            duiTextBox3.IsInsert = true;
            duiTextBox3.IsMoveParentPaint = true;
            duiTextBox3.Left = 0;
            duiTextBox3.Location = new System.Drawing.Point(0, 0);
            duiTextBox3.Margin = new System.Windows.Forms.Padding(0);
            duiTextBox3.Multiline = true;
            duiTextBox3.Name = "Text_Sjnr";
            duiTextBox3.ParentInvalidate = true;
            duiTextBox3.ReadOnly = true;
            duiTextBox3.RollSize = 12;
            duiTextBox3.ScrollBarBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            duiTextBox3.ScrollBarHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(158)))), ((int)(((byte)(158)))));
            duiTextBox3.ScrollBarNormalColor = System.Drawing.Color.Gray;
            duiTextBox3.ScrollBarPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            duiTextBox3.SelectionBackColor = System.Drawing.Color.Gray;
            duiTextBox3.SelectionColor = System.Drawing.Color.Red;
            duiTextBox3.SelectionLength = 0;
            duiTextBox3.SelectionStart = 0;
            duiTextBox3.ShowBorder = true;
            duiTextBox3.ShowScrollBar = true;
            duiTextBox3.Size = new System.Drawing.Size(100, 12);
            duiTextBox3.SuspendInvalidate = false;
            duiTextBox3.Tag = null;
            duiTextBox3.Text = "";
            duiTextBox3.TextRenderMode = System.Drawing.Text.TextRenderingHint.SystemDefault;
            duiTextBox3.Top = 0;
            duiTextBox3.Visible = true;
            duiTextBox3.Width = 100;
            this.layeredBaseControl1.DUIControls.AddRange(new LayeredSkin.DirectUI.DuiBaseControl[] {
            duiTextBox3});
            this.layeredBaseControl1.Location = new System.Drawing.Point(13, 294);
            this.layeredBaseControl1.Name = "layeredBaseControl1";
            this.layeredBaseControl1.Size = new System.Drawing.Size(371, 262);
            this.layeredBaseControl1.TabIndex = 8;
            this.layeredBaseControl1.Text = "layeredBaseControl1";
            // 
            // UpdateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(395, 568);
            this.Controls.Add(this.layeredBaseControl1);
            this.Controls.Add(this.customHxjdt);
            this.Controls.Add(this.layeredPanel_close);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "UpdateForm";
            this.Text = "程序更新";
            this.Load += new System.EventHandler(this.UpdateForm_Load);
            this.layeredPanel_close.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private LayeredSkin.Controls.LayeredPanel layeredPanel_close;
        private LayeredSkin.Controls.LayeredButton btn_close;
        private Controls.CustomHxjdtControl customHxjdt;
        private LayeredSkin.Controls.LayeredBaseControl layeredBaseControl1;
    }
}