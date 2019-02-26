using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Linq;
using System.Text;

namespace BridImage.Utils
{
    /// <summary>
    /// 类    名: PropertsUtils.cs
    /// CLR 版本: 4.0.30319.42000
    /// 作    者: sunkejava 
    /// 邮    箱：declineaberdeen@foxmail.com
    /// 创建时间: 2019/02/25 22:23:22
    /// 说    明：配置文件使用说明
    /// </summary>
    public class PropertsUtils
    {
        private bool autoStart = false;
        private string closeMode = "isMin";
        private string picSize = "default";
        private string downloadPath = "";
        private string cachePath = "";
        private bool isSwitchWallpaper = true;
        private int interValTime = 30;
        private ArrayList switchWallpaperTypes = new ArrayList();
        private Color backColor = Color.FromArgb(255, 92, 138);
        private string opacity = "1";
        public PropertsUtils()
        {
            this.autoStart = Boolean.Parse(GetAppConfig("autoStart"));
            this.closeMode = GetAppConfig("closeMode");
            this.picSize = GetAppConfig("picSize");
            this.downloadPath = GetAppConfig("downloadPath");
            this.cachePath = GetAppConfig("cachePath");
            this.isSwitchWallpaper = Boolean.Parse(GetAppConfig("isSwitchWallpaper"));
            this.interValTime = int.Parse(GetAppConfig("interValTime"));
            this.switchWallpaperTypes = new ArrayList(GetAppConfig("switchWallpaperTypes").Split(','));
            this.backColor = Color.FromArgb(int.Parse(GetAppConfig("backColor")));
            this.opacity = GetAppConfig("opacity");
        }
        /// <summary>
        /// 是否开机自动启动
        /// </summary>
        public bool AutoStart
        {
            get { return autoStart; }
            set { autoStart = value; }
        }
        /// <summary>
        /// 面板关闭方式(isMin：表示最小化到系统托盘；isClose:表示退出程序)-->
        /// </summary>
        public string CloseMode
        {
            get { return closeMode; }
            set { closeMode = value; }
        }
        /// <summary>
        /// 图片壁纸大小（分辨率）
        /// </summary>
        public string PicSize
        {
            get { return picSize; }
            set { picSize = value; }
        }
        /// <summary>
        /// 图片下载目录
        /// </summary>
        public string DownloadPath
        {
            get { return downloadPath; }
            set { downloadPath = value; }
        }
        /// <summary>
        /// 图片缓存目录
        /// </summary>
        public string CachePath
        {
            get { return cachePath; }
            set { cachePath = value; }
        }
        /// <summary>
        /// 是否自动切换壁纸
        /// </summary>
        public bool IsSwitchWallpaper
        {
            get { return isSwitchWallpaper; }
            set { isSwitchWallpaper = value; }
        }
        /// <summary>
        /// 壁纸切换间隔时间（单位：秒）
        /// </summary>
        public int InterValTime
        {
            get { return interValTime; }
            set { interValTime = value; }
        }
        /// <summary>
        /// 壁纸切换类型集合
        /// </summary>
        public ArrayList SwitchWallpaperTypes
        {
            get { return switchWallpaperTypes; }
            set { switchWallpaperTypes = value; }
        }
        /// <summary>
        /// 系统背景色
        /// </summary>
        public Color BackColor
        {
            get { return backColor; }
            set { backColor = value; }
        }
        /// <summary>
        /// 透明度
        /// </summary>
        public string Opacity1
        {
            get { return opacity; }
            set { opacity = value; }
        }
        /// <summary>
        /// 根据Key值获取value值
        /// </summary>
        /// <param name="strKey"></param>
        /// <returns></returns>
        private static string GetAppConfig(string strKey)
        {
            string file = System.Windows.Forms.Application.ExecutablePath;
            Configuration config = ConfigurationManager.OpenExeConfiguration(file);
            foreach (string key in config.AppSettings.Settings.AllKeys)
            {
                if (key == strKey)
                {
                    return config.AppSettings.Settings[strKey].Value.ToString();
                }
            }
            return null;
        }
        /// <summary>
        /// 更新key,values
        /// </summary>
        /// <param name="Key">键</param>
        /// <param name="Value">值</param>
        private static void UpdateAppConfig(string newKey, string newValue)
        {
            string file = System.Windows.Forms.Application.ExecutablePath;
            Configuration config = ConfigurationManager.OpenExeConfiguration(file);
            bool exist = false;
            foreach (string key in config.AppSettings.Settings.AllKeys)
            {
                if (key == newKey)
                {
                    exist = true;
                }
            }
            if (exist)
            {
                config.AppSettings.Settings.Remove(newKey);
            }
            config.AppSettings.Settings.Add(newKey, newValue);
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
        }
        /// <summary>
        /// 保存配置文件
        /// </summary>
        public void saveConfig()
        {
            UpdateAppConfig("autoStart", autoStart.ToString());
            UpdateAppConfig("closeMode", closeMode);
            UpdateAppConfig("picSize", picSize);
            UpdateAppConfig("downloadPath", downloadPath);
            UpdateAppConfig("cachePath", cachePath);
            UpdateAppConfig("isSwitchWallpaper", isSwitchWallpaper.ToString());
            UpdateAppConfig("interValTime", interValTime.ToString());
            UpdateAppConfig("switchWallpaperTypes", string.Join(",", (string[])switchWallpaperTypes.ToArray(typeof(string))));
            UpdateAppConfig("backColor", backColor.ToArgb().ToString());
            UpdateAppConfig("opacity", opacity.ToString());
        }
    }
}
