using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace BridImage.Utils
{
    public class GetVersion
    {
        string aurl = "https://www.cnblogs.com/decline/p/decline-bridWallpaper.html";
        public Entity.VerEntity getVer()
        {
            Entity.VerEntity ver = new Entity.VerEntity();
            string vcode = GetWebClient(aurl);
            ver.Ver = Between2(vcode, "【--", "--】");
            vcode = vcode.Substring(vcode.IndexOf(ver.Ver)+ver.Ver.Length+3,vcode.Length-(vcode.IndexOf(ver.Ver) + ver.Ver.Length + 3));
            string content = "";
            for (int i = 0; i < 100; i++)
            {
                content = Between2(vcode, "【==", "==】");
                if (!string.IsNullOrEmpty(content))
                {
                    ver.Content = ver.Content + (string.IsNullOrEmpty(ver.Content) ? "" : "---") + content;
                    vcode = vcode.Substring(vcode.IndexOf(content) + content.Length + 3, vcode.Length - (vcode.IndexOf(content) + content.Length + 3));
                }
                else
                {
                    break;
                }
            }
            ver.DownloadUrl = Between2(vcode, "【**", "**】");
            return ver;
        }
        public static string Between2(string str, string strLeft, string strRight) //取文本中间
        {
            if (str == null || str.Length == 0) return "";
            if (strLeft != null)
            {
                int indexLeft = str.IndexOf(strLeft);//左边字符串位置
                if (indexLeft < 0) return "";
                indexLeft = indexLeft + strLeft.Length;//左边字符串长度
                if (strRight != null)
                {
                    int indexRight = str.IndexOf(strRight, indexLeft);//右边字符串位置
                    if (indexRight < 0) return "";
                    return str.Substring(indexLeft, indexRight - indexLeft);//indexRight - indexLeft是取中间字符串长度
                }
                else return str.Substring(indexLeft, str.Length - indexLeft);//取字符串右边
            }
            else//取字符串左边
            {
                if (strRight == null) return "";
                int indexRight = str.IndexOf(strRight);
                if (indexRight <= 0) return "";
                else return str.Substring(0, indexRight);
            }
        }
        public string GetWebClient(string url)
        {
            try
            {
                string strHTML = "";
                WebClient myWebClient = new WebClient();
                Stream myStream = myWebClient.OpenRead(url);
                StreamReader sr = new StreamReader(myStream, Encoding.UTF8);//注意编码
                strHTML = sr.ReadToEnd();
                myStream.Close();
                return strHTML;
            }
            catch (Exception)
            {
                return GetWebStringForWebRequest(url);
            }

        }

        public string GetWebStringForWebRequest(String url)
        {
            try
            {
                Uri uri = new Uri(url);
                WebRequest myReq = WebRequest.Create(uri);
                WebResponse result = myReq.GetResponse();
                Stream receviceStream = result.GetResponseStream();
                StreamReader readerOfStream = new StreamReader(receviceStream, Encoding.UTF8);
                string strHTML = readerOfStream.ReadToEnd();
                readerOfStream.Close();
                receviceStream.Close();
                result.Close();
                return strHTML;
            }
            catch (Exception)
            {
                return GetWebStringForHttpWebRequest(url);
            }
        }
        public string GetWebStringForHttpWebRequest(string url)
        {
            try
            {
                Uri uri = new Uri(url);
                HttpWebRequest myReq = (HttpWebRequest)WebRequest.Create(uri);
                myReq.UserAgent = "User-Agent:Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705";
                myReq.Accept = "*/*";
                myReq.KeepAlive = true;
                myReq.Headers.Add("Accept-Language", "zh-cn,en-us;q=0.5");
                HttpWebResponse result = (HttpWebResponse)myReq.GetResponse();
                Stream receviceStream = result.GetResponseStream();
                StreamReader readerOfStream = new StreamReader(receviceStream, Encoding.UTF8);
                string strHTML = readerOfStream.ReadToEnd();
                readerOfStream.Close();
                receviceStream.Close();
                result.Close();

                return strHTML;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
