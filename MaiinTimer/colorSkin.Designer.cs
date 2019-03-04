namespace BridImage
{
    partial class colorSkin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(colorSkin));
            this.base_main = new LayeredSkin.Controls.LayeredBaseControl();
            this.SuspendLayout();
            // 
            // base_main
            // 
            this.base_main.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.base_main.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.base_main.Borders.BottomColor = System.Drawing.Color.Empty;
            this.base_main.Borders.BottomWidth = 1;
            this.base_main.Borders.LeftColor = System.Drawing.Color.Empty;
            this.base_main.Borders.LeftWidth = 1;
            this.base_main.Borders.RightColor = System.Drawing.Color.Empty;
            this.base_main.Borders.RightWidth = 1;
            this.base_main.Borders.TopColor = System.Drawing.Color.Empty;
            this.base_main.Borders.TopWidth = 1;
            this.base_main.Canvas = ((System.Drawing.Bitmap)(resources.GetObject("base_main.Canvas")));
            this.base_main.Location = new System.Drawing.Point(0, 30);
            this.base_main.Name = "base_main";
            this.base_main.Size = new System.Drawing.Size(553, 134);
            this.base_main.TabIndex = 0;
            this.base_main.Text = "layeredBaseControl1";
            // 
            // colorSkin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.BackgroundImage = global::BridImage.Properties.Resources.BackgroundImage;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(553, 208);
            this.Controls.Add(this.base_main);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "colorSkin";
            this.Radius = 15;
            this.Text = "";
            this.ResumeLayout(false);

        }

        #endregion

        private LayeredSkin.Controls.LayeredBaseControl base_main;
    }
}