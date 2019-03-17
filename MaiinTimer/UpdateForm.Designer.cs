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
            LayeredSkin.DirectUI.DuiTextBox duiTextBox1 = new LayeredSkin.DirectUI.DuiTextBox();
            this.layeredPanel_close = new LayeredSkin.Controls.LayeredPanel();
            this.btn_close = new LayeredSkin.Controls.LayeredButton();
            this.lbc = new LayeredSkin.Controls.LayeredBaseControl();
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
            this.btn_close.MouseLeave += new System.EventHandler(this.layeredPanel_close_MouseLeave);
            // 
            // lbc
            // 
            this.lbc.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbc.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.lbc.Borders.BottomColor = System.Drawing.Color.Empty;
            this.lbc.Borders.BottomWidth = 1;
            this.lbc.Borders.LeftColor = System.Drawing.Color.Empty;
            this.lbc.Borders.LeftWidth = 1;
            this.lbc.Borders.RightColor = System.Drawing.Color.Empty;
            this.lbc.Borders.RightWidth = 1;
            this.lbc.Borders.TopColor = System.Drawing.Color.Empty;
            this.lbc.Borders.TopWidth = 1;
            this.lbc.Canvas = ((System.Drawing.Bitmap)(resources.GetObject("lbc.Canvas")));
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
            duiTextBox1.ClientRectangle = new System.Drawing.Rectangle(0, 250, 371, 200);
            duiTextBox1.CurrentCursor = System.Windows.Forms.Cursors.Default;
            duiTextBox1.Cursor = System.Windows.Forms.Cursors.IBeam;
            duiTextBox1.Dock = System.Windows.Forms.DockStyle.None;
            duiTextBox1.Enabled = true;
            duiTextBox1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            duiTextBox1.ForeColor = System.Drawing.SystemColors.ControlText;
            duiTextBox1.Height = 200;
            duiTextBox1.IsInsert = true;
            duiTextBox1.IsMoveParentPaint = true;
            duiTextBox1.Left = 0;
            duiTextBox1.Location = new System.Drawing.Point(0, 250);
            duiTextBox1.Margin = new System.Windows.Forms.Padding(0);
            duiTextBox1.Multiline = true;
            duiTextBox1.Name = "Text_Sjnr";
            duiTextBox1.ParentInvalidate = true;
            duiTextBox1.ReadOnly = true;
            duiTextBox1.RollSize = 12;
            duiTextBox1.ScrollBarBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            duiTextBox1.ScrollBarHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(158)))), ((int)(((byte)(158)))));
            duiTextBox1.ScrollBarNormalColor = System.Drawing.Color.Gray;
            duiTextBox1.ScrollBarPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            duiTextBox1.SelectionBackColor = System.Drawing.Color.Gray;
            duiTextBox1.SelectionColor = System.Drawing.Color.Red;
            duiTextBox1.SelectionLength = 0;
            duiTextBox1.SelectionStart = 0;
            duiTextBox1.ShowBorder = true;
            duiTextBox1.ShowScrollBar = true;
            duiTextBox1.Size = new System.Drawing.Size(371, 200);
            duiTextBox1.SuspendInvalidate = false;
            duiTextBox1.Tag = null;
            duiTextBox1.Text = "";
            duiTextBox1.TextRenderMode = System.Drawing.Text.TextRenderingHint.SystemDefault;
            duiTextBox1.Top = 250;
            duiTextBox1.Visible = true;
            duiTextBox1.Width = 371;
            this.lbc.DUIControls.AddRange(new LayeredSkin.DirectUI.DuiBaseControl[] {
            duiTextBox1});
            this.lbc.Location = new System.Drawing.Point(13, 29);
            this.lbc.Name = "lbc";
            this.lbc.Size = new System.Drawing.Size(371, 416);
            this.lbc.TabIndex = 8;
            this.lbc.Text = "layeredBaseControl1";
            // 
            // UpdateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(395, 457);
            this.Controls.Add(this.lbc);
            this.Controls.Add(this.layeredPanel_close);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "UpdateForm";
            this.Radius = 15;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "程序更新";
            this.Load += new System.EventHandler(this.UpdateForm_Load);
            this.layeredPanel_close.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private LayeredSkin.Controls.LayeredPanel layeredPanel_close;
        private LayeredSkin.Controls.LayeredButton btn_close;
        private LayeredSkin.Controls.LayeredBaseControl lbc;
    }
}