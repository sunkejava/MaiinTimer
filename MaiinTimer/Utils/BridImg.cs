using System;
using System.Collections.Generic;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;
using System.Web.Script.Serialization;

namespace MaiinTimer.Utils
{
    /// <summary>
    /// 小鸟壁纸
    /// </summary>
    public class BridImg
    {
        HttpWebRequest req = null;

        /// <summary>
        /// 获取图片分类信息
        /// </summary>
        /// <returns>返回json类型的图片数组</returns>
        public ImgJson getImageType()
        {
            string curl = @"http://wallpaper.apc.360.cn/index.php?c=WallPaper&a=getAllCategoriesV2";
            //创建一个HttpWebRequest对象  
            req = (HttpWebRequest)HttpWebRequest.Create(curl);
            //设置它提交数据的方式GET  
            req.Method = "GET";
            StreamReader sr = new StreamReader(req.GetResponse().GetResponseStream());
            //获取返回的XML数据
            string Reader = Unicode2String(sr.ReadToEnd());
            JavaScriptSerializer jss = new JavaScriptSerializer();
            ImgJson it = jss.Deserialize<ImgJson>(Reader);
            return it;
        }
        /// <summary>
        /// ImgJson信息
        /// </summary>
        public class ImgJson
        {
            /// <summary>
            /// 错误号
            /// </summary>
            public int errno { get; set; }
            /// <summary>
            /// 错误信息
            /// </summary>
            public string errmsg { get; set; }
            /// <summary>
            /// 未知数
            /// </summary>
            public int consume { get; set; }
            /// <summary>
            /// 总数
            /// </summary>
            public int total { get; set; }
            /// <summary>
            /// 类型集合
            /// </summary>
            public List<ImageType> data { get; set; }


        }

        /// <summary>
        /// Image类型信息
        /// </summary>
        public class ImageType
        {
            /// <summary>
            /// id
            /// </summary>
            public int id { get; set; }
            /// <summary>
            /// 名称
            /// </summary>
            public string name { get; set; }
            /// <summary>
            /// 排序顺序
            /// </summary>
            public int order_num { get; set; }
            /// <summary>
            /// 创建时间
            /// </summary>
            public DateTime create_time { get; set; }
        }

        /// <summary>
        /// 获取热门标签
        /// </summary>
        /// <returns></returns>
        public ImageTags getImageHotTags()
        {
            string curl = @"http://static.apc.360.cn/cms/wallpaper/hot_tag.html";
            //创建一个HttpWebRequest对象
            req = (HttpWebRequest)HttpWebRequest.Create(curl);
            //设置它提交数据的方式GET  
            req.Method = "GET";
            StreamReader sr = new StreamReader(req.GetResponse().GetResponseStream());
            //获取返回的数据
            string Reader = Unicode2String(sr.ReadToEnd());
            Reader = Reader.Replace("16", "jbtyImg").Replace("22", "jstdImg").Replace("11", "mxfsImg").Replace("10", "kxssImg").Replace("30", "aqmtImg").Replace("26", "dmktImg").Replace("15", "xqxImg").Replace("12", "qctxImg").Replace("14", "mcdwImg").Replace("5", "gameImg").Replace("9", "fjdpImg").Replace("7", "ysjzImg").Replace("6", "mnmtImg");
            JavaScriptSerializer jss = new JavaScriptSerializer();
            ImageTags it = jss.Deserialize<ImageTags>(Reader);
            return it;
        }

        /// <summary>
        /// 获取最新图片信息
        /// </summary>
        /// <param name="startImgNumber">起始图片数</param>
        /// <param name="ImgCount">获取图片的数量</param>
        /// <returns></returns>
        public ImageJson getNewImageInfos(string startImgNumber, string ImgCount)
        {
            string curl = @"http://wallpaper.apc.360.cn/index.php?c=WallPaperAloneRelease&a=getAppsByRecommWithTopic&order=create_time&start=" + startImgNumber.ToString() + "&count=" + ImgCount.ToString();
            //创建一个HttpWebRequest对象  
            req = (HttpWebRequest)HttpWebRequest.Create(curl);
            //设置它提交数据的方式GET  
            req.Method = "GET";
            StreamReader sr = new StreamReader(req.GetResponse().GetResponseStream());
            //获取返回的XML数据
            string Reader = Unicode2String(sr.ReadToEnd());
            JavaScriptSerializer jss = new JavaScriptSerializer();
            ImageJson it = jss.Deserialize<ImageJson>(Reader);
            return it;
        }

        /// <summary>
        /// 根据类型获取图片信息
        /// </summary>
        /// <param name="imgTypeID">图片类型ID</param>
        /// <param name="startImgNumber">起始图片数</param>
        /// <param name="ImgCount">获取图片的数量</param>
        /// <returns></returns>
        public ImageJson getImageInfos(string imgTypeID, string startImgNumber, string ImgCount)
        {
            string curl = @"http://wallpaper.apc.360.cn/index.php?c=WallPaper&a=getAppsByCategory&cid=" + imgTypeID.ToString() + "&start=" + startImgNumber.ToString() + "&count=" + ImgCount.ToString();
            //创建一个HttpWebRequest对象  
            req = (HttpWebRequest)HttpWebRequest.Create(curl);
            //设置它提交数据的方式GET  
            req.Method = "GET";
            StreamReader sr = new StreamReader(req.GetResponse().GetResponseStream());
            //获取返回的XML数据
            string Reader = Unicode2String(sr.ReadToEnd());
            JavaScriptSerializer jss = new JavaScriptSerializer();
            ImageJson it = jss.Deserialize<ImageJson>(Reader);
            return it;
        }

        /// <summary>
        /// 根据类型及标签获取图片信息
        /// </summary>
        /// <param name="imgTypeID">图片类型ID</param>
        /// <param name="startImgNumber">起始图片数</param>
        /// <param name="ImgCount">获取图片的数量</param>
        /// <param name="tags">图片标签</param>
        /// <returns></returns>
        public ImageJson getImageInfos(string imgTypeID, string startImgNumber, string ImgCount, string tags)
        {
            //6&start=0&count=9&tags=%E6%B8%85%E7%BA%AF
            string curl = @"http://wallpaper.apc.360.cn/index.php?c=WallPaper&a=getAppsByTagsFromCategory&cids=" + imgTypeID.ToString() + "&start=" + startImgNumber.ToString() + "&count=" + ImgCount.ToString() + "&tags=" + tags.ToString();
            //创建一个HttpWebRequest对象  
            req = (HttpWebRequest)HttpWebRequest.Create(curl);
            //设置它提交数据的方式GET  
            req.Method = "GET";
            StreamReader sr = new StreamReader(req.GetResponse().GetResponseStream());
            //获取返回的XML数据
            string Reader = Unicode2String(sr.ReadToEnd());
            JavaScriptSerializer jss = new JavaScriptSerializer();
            ImageJson it = jss.Deserialize<ImageJson>(Reader);
            return it;
        }


        /// <summary>
        /// ImageJson信息
        /// </summary>
        public class ImageJson
        {
            /// <summary>
            /// 错误号
            /// </summary>
            public int errno { get; set; }
            /// <summary>
            /// 错误信息
            /// </summary>
            public string errmsg { get; set; }
            /// <summary>
            /// 未知数
            /// </summary>
            public int consume { get; set; }
            /// <summary>
            /// 总数
            /// </summary>
            public int total { get; set; }
            /// <summary>
            /// 图片信息集合
            /// </summary>
            public List<ImageInfo> data { get; set; }

        }

        /// <summary>
        /// ImageInfo
        /// </summary>
        public class ImageInfo
        {
            /// <summary>
            /// id
            /// </summary>
            public int id { get; set; }

            /// <summary>
            /// class_id
            /// </summary>
            public int class_id { get; set; }

            /// <summary>
            /// resolution(分辨率)
            /// </summary>
            public string resolution { get; set; }

            /// <summary>
            /// url_mobile(移动端图片地址)
            /// </summary>
            public string url_mobile { get; set; }

            /// <summary>
            /// 图片地址
            /// </summary>
            public string url { get; set; }

            /// <summary>
            /// 图片地址
            /// </summary>
            public string url_thumb { get; set; }

            /// <summary>
            /// 图片地址
            /// </summary>
            public string url_mid { get; set; }

            /// <summary>
            /// 创建时间
            /// </summary>
            public DateTime create_time { get; set; }

            /// <summary>
            /// 更新时间
            /// </summary>
            public DateTime update_time { get; set; }

            /// <summary>
            /// 图片标签
            /// </summary>
            public string utag { get; set; }

            /// <summary>
            /// 1600*900分辨率图片地址
            /// </summary>
            public string img_1600_900 { get; set; }

            /// <summary>
            /// 1440*900分辨率图片地址
            /// </summary>
            public string img_1440_900 { get; set; }

            /// <summary>
            /// 1366*768分辨率图片地址
            /// </summary>
            public string img_1366_768 { get; set; }

            /// <summary>
            /// 1280*800分辨率图片地址
            /// </summary>
            public string img_1280_800 { get; set; }

            /// <summary>
            /// 1280*1024分辨率图片地址
            /// </summary>
            public string img_1280_1024 { get; set; }

            /// <summary>
            /// 1024*768分辨率图片地址
            /// </summary>
            public string img_1024_768 { get; set; }

            /// <summary>
            /// 重写ToString方法
            /// </summary>
            /// <returns></returns>
            public override string ToString()
            {
                return "id=" + id.ToString() + ",class_id=" + class_id.ToString() + ",resolution=" + resolution.ToString() + ",url_mobile=" + url_mobile.ToString() + ",url=" + url.ToString() +
                    ",url_thumb=" + url_thumb.ToString() + ",url_mid=" + url_mid.ToString() + ",create_time=" + create_time.ToString() + ",update_time=" + update_time.ToString() + ",utag=" + utag.ToString();
            }
        }


        /// <summary>
        /// 热门标签实体
        /// </summary>
        public class ImageTags
        {
            /// <summary>
            /// 游戏壁纸：5
            /// </summary>
            public List<tagItem> gameImg { get; set; }
            /// <summary>
            /// 动漫卡通：26
            /// </summary>
            public List<tagItem> dmktImg { get; set; }

            /// <summary>
            /// 小清新：15
            /// </summary>
            public List<tagItem> xqxImg { get; set; }

            /// <summary>
            /// 风景大片：9
            /// </summary>
            public List<tagItem> fjdpImg { get; set; }

            /// <summary>
            /// 汽车天下：12
            /// </summary>
            public List<tagItem> qctxImg { get; set; }

            /// <summary>
            /// 影视剧照：7
            /// </summary>
            public List<tagItem> ysjzImg { get; set; }

            /// <summary>
            /// 萌宠动物：14
            /// </summary>
            public List<tagItem> mcdwImg { get; set; }

            /// <summary>
            /// 美女模特：6
            /// </summary>
            public List<tagItem> mnmtImg { get; set; }

            /// <summary>
            /// 劲爆体育：16
            /// </summary>
            public List<tagItem> jbtyImg { get; set; }

            /// <summary>
            /// 军事天地：22
            /// </summary>
            public List<tagItem> jstdImg { get; set; }

            /// <summary>
            /// 明星风尚：11
            /// </summary>
            public List<tagItem> mxfsImg { get; set; }

            /// <summary>
            /// 炫酷时尚：10
            /// </summary>
            public List<tagItem> kxssImg { get; set; }

            /// <summary>
            /// 爱情美图：30
            /// </summary>
            public List<tagItem> aqmtImg { get; set; }
            /// <summary>
            /// 错误码
            /// </summary>
            public string errno { get; set; }
        }

        /// <summary>
        /// 
        /// </summary>
        public class tagItem
        {
            /// <summary>
            /// 
            /// </summary>
            public string tagName { get; set; }
        }

        public class TagStringId
        {
            public string tagString { get; set; }

            public string tagId { get; set; }

            public TagStringId(string id, string value) {
                tagId = id;
                tagString = value;
            }
        }

        /// <summary>
        /// Unicode转字符串
        /// </summary>
        /// <param name="source">经过Unicode编码的字符串</param>
        /// <returns>正常字符串</returns>
        public static string Unicode2String(string source)
        {
            return new Regex(@"\\u([0-9A-F]{4})", RegexOptions.IgnoreCase | RegexOptions.Compiled).Replace(
                source, x => string.Empty + Convert.ToChar(Convert.ToUInt16(x.Result("$1"), 16)));
        }


    }
}
