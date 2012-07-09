using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Model
{
    /// <summary>
    /// 定义广告条实体类
    /// </summary>
    public class AdInfo
    {

        private int _ad_id;
        private long _ap_id;
        private string _ad_name;
        private string _ad_linkurl;
        private short _ad_type;
        private bool _ad_opentype;
        private string _ad_notetext;
        private string _ad_picurl;
        private string _ad_alt;
        private int _ad_width;
        private int _ad_high;
        private string _ad_letter;
        private string _ad_font; 
        private int _ad_size;
        private string _ad_color;
        private string _ad_jsname;
        private string _ad_codecontent;
        private DateTime _ad_StartDate;
        private DateTime _ad_EndDate;
        private int _ad_Traffic;

        public int Ad_Traffic
        {
            get { return _ad_Traffic; }
            set { _ad_Traffic = value; }
        }
        
        

        public AdInfo()
        {
            _ad_id = 0;
            _ap_id = 0;
            _ad_name = "";
            _ad_linkurl = "";
            _ad_type = 0;
            _ad_opentype = false;
            _ad_notetext = "";
            _ad_picurl = "";
            _ad_alt = "";
            _ad_width = 0;
            _ad_high = 0;
            _ad_letter = "";
            _ad_font = "";
            _ad_size = 0;
            _ad_color = "";
            _ad_jsname = "";
            _ad_codecontent = "";
            _ad_StartDate = DateTime.Now;

        }

        /// <summary>
        /// 广告条编号
        /// </summary>
        public int AD_ID
        {
            set { _ad_id = value; }
            get { return _ad_id; }
        }
        /// <summary>
        /// 广告条名称
        /// </summary>
        public string AD_Name
        {
            set { _ad_name = value; }
            get { return _ad_name; }
        }
        public long AP_ID
        {
            set { _ap_id = value; }
            get { return _ap_id; }
        }
        /// <summary>
        /// 广告条链接地址
        /// </summary>
        public string AD_LinkURL
        {
            set { _ad_linkurl = value; }
            get { return _ad_linkurl; }
        }
        /// <summary>
        /// 广告条类型
        /// </summary>
        public short AD_Type
        {
            set { _ad_type = value; }
            get { return _ad_type; }
        }
        /// <summary>
        /// 广告条打开方式
        /// </summary>
        public bool AD_OpenType
        {
            set { _ad_opentype = value; }
            get { return _ad_opentype; }
        }
        /// <summary>
        /// 文字广告内容
        /// </summary>
        public string AD_NoteText
        {
            set { _ad_notetext = value; }
            get { return _ad_notetext; }
        }
        /// <summary>
        /// 图片/动画广告URL
        /// </summary>
        public string AD_PicURL
        {
            set { _ad_picurl = value; }
            get { return _ad_picurl; }
        }
        /// <summary>
        /// 广告条注释
        /// </summary>
        public string AD_Alt
        {
            set { _ad_alt = value; }
            get { return _ad_alt; }
        }
        /// <summary>
        /// 图片flash 宽度
        /// </summary>
        public int AD_Width
        {
            set { _ad_width = value; }
            get { return _ad_width; }
        }
        /// <summary>
        /// 图片flash 的高度
        /// </summary>
        public int AD_High
        {
            set { _ad_high = value; }
            get { return _ad_high; }
        }
        /// <summary>
        /// 图片广告的 替换文字
        /// </summary>
        public string AD_Letter
        {
            set { _ad_letter = value; }
            get { return _ad_letter; }

        }
        /// <summary>
        /// 文字广告的字体格式1宋体2楷书3黑体4默认
        /// </summary>
        public string AD_Font
        {
            set { _ad_font = value; }
            get { return _ad_font; }
        }
        /// <summary>
        /// 文字广告的字体大小
        /// </summary>
        public int AD_Size
        {
            set { _ad_size = value; }
            get { return _ad_size; }
        }
        /// <summary>
        /// 文字广告颜色
        /// </summary>
        public string AD_Color
        {
            set { _ad_color = value; }
            get { return _ad_color; }
        }
        /// <summary>
        /// JS文件名称
        /// </summary>
        public string AD_JSname
        {
            set { _ad_jsname = value; }
            get { return _ad_jsname; }
        }

        /// <summary>
        /// 代码广告内容
        /// </summary>
        public string AD_CodeContent
        {
            set { _ad_codecontent = value; }
            get { return _ad_codecontent; }
        }



        /// <summary>
        /// 广告开始时间
        /// </summary>
        public DateTime Ad_StartDate
        {
            get { return _ad_StartDate; }
            set { _ad_StartDate = value; }
        }

        /// <summary>
        /// 广告结束时间
        /// </summary>
        public DateTime Ad_EndDate
        {
            get { return _ad_EndDate; }
            set { _ad_EndDate = value; }
        }

    }
}