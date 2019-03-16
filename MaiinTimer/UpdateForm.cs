using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
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

        private void layeredPanel_close_MouseLeave(object sender, EventArgs e)
        {
            LayeredPanel thisButton = sender as LayeredPanel;
            thisButton.BackColor = Color.Transparent;
        }

        private void UpdateForm_Load(object sender, EventArgs e)
        {
            customHxjdt.BackColor = Color.Transparent;
            customHxjdt.MainColor = pes.BackColor;
            foreach (DuiBaseControl item in layeredBaseControl1.DUIControls)
            {
                if (item is DuiTextBox)
                {
                    DuiTextBox gxnr = item as DuiTextBox;
                    gxnr.Text = pes.UpdateContent.Replace("---","\r\n");
                }
            }
            HttpDldFile fileDownload = new HttpDldFile();
            fileDownload.Download(pes.DownloadUrl,pes.DownloadPath,customHxjdt);
        }
    }
}
