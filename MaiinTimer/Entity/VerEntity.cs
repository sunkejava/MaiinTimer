using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BridImage.Entity
{
    public  class VerEntity
    {
        private string ver;
        private string content;
        private string downloadUrl;

        public string Ver
        {
            get { return ver; }
            set { ver = value; }
        }
        public string Content
        {
            get { return content; }
            set { content = value; }
        }

        public string DownloadUrl
        {
            get { return downloadUrl; }
            set { downloadUrl = value; }
        }
    }
}
