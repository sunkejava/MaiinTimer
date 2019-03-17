using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using BridImage.Utils;
using LayeredSkin.Controls;
using LayeredSkin.DirectUI;
using LayeredSkin.Forms;
namespace BridImage
{
    public partial class UpdateForm : LayeredForm
    {

        public PropertsUtils pes = new PropertsUtils();
        Controls.CustomHxjdtControl customHxjdt = new Controls.CustomHxjdtControl();
        public UpdateForm(PropertsUtils cps)
        {
            pes = cps;
            InitializeComponent();
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Dispose();
            this.Close();
        }

        private void btn_close_MouseEnter(object sender, EventArgs e)
        {
           layeredPanel_close.BackColor = Color.FromArgb(255, 88, 88);
        }

        private void layeredPanel_close_MouseLeave(object sender, EventArgs e)
        {
            layeredPanel_close.BackColor = Color.Transparent;
        }

        private void UpdateForm_Load(object sender, EventArgs e)
        {
            customHxjdt.Size = new Size(250, 250);
            customHxjdt.Location = new Point(50, 0);
            customHxjdt.Value = 0;
            customHxjdt.Lcp = System.Drawing.Drawing2D.LineCap.Round;
            customHxjdt.CircularWidth = 25;
            customHxjdt.BackColor = Color.Transparent;
            customHxjdt.MainColor = pes.BackColor;
            lbc.DUIControls.Add(customHxjdt);
            this.BackColor = Color.FromArgb(185, pes.BackColor);
            foreach (DuiBaseControl item in lbc.DUIControls)
            {
                if (item is DuiTextBox)
                {
                    DuiTextBox gxnr = item as DuiTextBox;
                    gxnr.Text = pes.VerNo+"\r\n"+pes.UpdateContent.Replace("---","\r\n");
                }
            }
            HttpDldFile fileDownload = new HttpDldFile();
            Thread thread = new Thread(() => fileDownload.Download(pes.DownloadUrl, pes.DownloadPath + @"\newVersion.zip", customHxjdt));
            thread.Start();
        }
    }
}
