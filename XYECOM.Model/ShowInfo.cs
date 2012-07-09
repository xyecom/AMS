using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Model
{
    /// <summary>
    /// 展会信息实体类
    /// </summary>
    public class ShowInfo:Attachment
    {
        #region 过时属性
        /// <summary>
        /// 展会信息编号
        /// </summary>
        [Obsolete]
        public Int64 SHI_ID
        {
            get { return id; }
        }

        /// <summary>
        /// 展会信息标题
        /// </summary>
        [Obsolete]
        public string SHI_Title
        {
            get { return infotitle; }
        }

        /// <summary>
        /// 展会信息内容
        /// </summary>
        [Obsolete]
        public string SHI_Content
        {
            get { return contents; }
        }



        /// <summary>
        /// 展会地点
        /// </summary>
        [Obsolete]
        public string SHI_Place
        {
            get { return district; }
        }

        /// <summary>
        /// 展会场馆
        /// </summary>
        [Obsolete]
        public string SHI_Stadiums
        {
            get { return site; }
        }

        /// <summary>
        /// 主办单位
        /// </summary>
        [Obsolete]
        public string SHI_Sponsor
        {
            get { return sponsor; }
        }

        /// <summary>
        /// 承办单位
        /// </summary>
        [Obsolete]
        public string SHI_Undertake
        {
            get { return undertake; }
        }

        /// <summary>
        /// 协办单位
        /// </summary>
        [Obsolete]
        public string SHI_Coorganizor
        {
            get { return coorganizor; }
        }

        /// <summary>
        /// 支持单位
        /// </summary>
        [Obsolete]
        public string SHI_Sustain
        {
            get { return sustain; }
        }

        /// <summary>
        /// 展会周期
        /// </summary>
        [Obsolete]
        public string SHI_ShowSycle
        {
            get { return sycle; }
        }

        /// <summary>
        /// 展会类型
        /// </summary>
        [Obsolete]
        public string SHI_ShowCharacter
        {
            get { return type; }
        }

        /// <summary>
        /// 展会网址
        /// </summary>
        [Obsolete]
        public string SHI_ShowURL
        {
            get { return uRL; }
        }

        /// <summary>
        /// 展会面积单位
        /// </summary>
        [Obsolete]
        public string SHI_Landmeasure
        {
            get { return area; }
        }

        /// <summary>
        /// 单位面积单价
        /// </summary>
        [Obsolete]
        public int SHI_Unitprice
        {
            get { return unitPrice; }
        }

        /// <summary>
        /// 最小面积起定量
        /// </summary>
        [Obsolete]
        public int SHI_Minration
        {
            get { return leastRation; }
        }

        /// <summary>
        /// 面积总量
        /// </summary>
        [Obsolete]
        public int SHI_TotalArea
        {
            get { return areaTotal; }
        }

        /// <summary>
        /// 展会信息类别编号
        /// </summary>
        [Obsolete]
        public Int64 SHT_ID
        {
            get { return typeid; }
        }

        /// <summary>
        /// 是否推荐
        /// </summary>
        [Obsolete]
        public bool SHI_IsCommend
        {
            get { return isCommend; }
        }

        /// <summary>
        /// 静态页面地址
        /// </summary>
        [Obsolete]
        public string SHI_HtmlPage
        {
            get { return htmlPage; }
        }
        #endregion

        #region 新增的属性


        private int id;
        /// <summary>
        ///展会编号 
        /// </summary>
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private String infotitle;
        /// <summary>
        /// 展会标题
        /// </summary>
        public String Infotitle
        {
            get { return infotitle; }
            set { infotitle = value; }
        }

                
        private int typeid;
        /// <summary>
        /// 展会信息类别编号
        /// </summary>
        public int Typeid
        {
            get { return typeid; }
            set { typeid = value; }
        }


        private string contents;

        /// <summary>
        /// 展会详细信息
        /// </summary>
        public string Contents
        {
            get { return contents; }
            set { contents = value; }
        }


       
        private string beginTime;
        /// <summary>
        /// 展会开幕日期
        /// </summary>
        public string BeginTime
        {
            get { return Core.MyConvert.GetDateTime(beginTime).ToString("yyyy-MM-dd"); }
            set { beginTime = value; }
        }




        private string endTime;
        /// <summary>
        /// 展会闭幕日期
        /// </summary>
        public string EndTime
        {
            get { return Core.MyConvert.GetDateTime(endTime).ToString("yyyy-MM-dd");}
            set { endTime = value; }
        }
        
        
        private string district;
        /// <summary>
        /// 展会地点
        /// </summary>
        public string District
        {
            get { return district; }
            set { district = value; }
        }

        private string site;
        /// <summary>
        /// 展会场馆
        /// </summary>
        public string Site
        {
            get { return site; }
            set { site = value; }
        }

        private string sponsor;
        /// <summary>
        /// 主办单位
        /// </summary>
        public string Sponsor
        {
            get { return sponsor; }
            set { sponsor = value; }
        }

        private string undertake;
        /// <summary>
        /// 承办单位
        /// </summary>
        public string Undertake
        {
            get { return undertake; }
            set { undertake = value; }
        }

        private string coorganizor;
        /// <summary>
        /// 协办单位
        /// </summary>
        public string Coorganizor
        {
            get { return coorganizor; }
            set { coorganizor = value; }
        }

        private string sustain;
        /// <summary>
        /// 支持单位
        /// </summary>
        public string Sustain
        {
            get { return sustain; }
            set { sustain = value; }
        }

        private string sycle;
        /// <summary>
        /// 展会周期
        /// </summary>
        public string Sycle
        {
            get { return sycle; }
            set { sycle = value; }
        }

        private string type;
        /// <summary>
        /// 展会类型
        /// </summary>
        public string Type
        {
            get { return type; }
            set { type = value; }
        }

        private string uRL;
        /// <summary>
        /// 展会网址
        /// </summary>
        public string URL
        {
            get { return uRL; }
            set { uRL = value; }
        }

        private string area;
        /// <summary>
        /// 展会面积单位
        /// </summary>
        public string Area
        {
            get { return area; }
            set { area = value; }
        }

        private int unitPrice;
        /// <summary>
        /// 单位面积单价
        /// </summary>
        public int UnitPrice
        {
            get { return unitPrice; }
            set { unitPrice = value; }
        }

        private int leastRation;
        /// <summary>
        /// 最小面积起定量
        /// </summary>
        public int LeastRation
        {
            get { return leastRation; }
            set { leastRation = value; }
        }

        private int areaTotal;
        /// <summary>
        /// 面积总量
        /// </summary>
        public int AreaTotal
        {
            get { return areaTotal; }
            set { areaTotal = value; }
        }

        
        private bool isCommend;
        /// <summary>
        /// 是否推荐
        /// </summary>
        public bool IsCommend
        {
            get { return isCommend; }
            set { isCommend = value; }
        }

        
        private string addInfoTime;
        /// <summary>
        /// 添加时间
        /// </summary>
        public string AddInfoTime
        {
            get { return Core.MyConvert.GetDateTime(addInfoTime).ToString("yyyy-MM-dd");}
            set { addInfoTime = value; }
        }

      
        
        private string htmlPage;
        /// <summary>
        /// 静态页面
        /// </summary>
        public string HtmlPage
        {
            get { return htmlPage; }
            set { htmlPage = value; }
        }



        //图片
        public class _SmallImg
        {
            private const string DEFAULTIMG = "/Common/Images/DefaultImg.gif";

            private string[] images = new string[0];

            public string[] Images
            {
                get
                {
                    return this.images;
                }
                set
                {
                    this.images = value;
                }
            }

            private string sURL = "";

            public string SURL
            {
                get { return sURL; }
                set { sURL = value; }
            }

            public string this[int index]
            {
                get
                {
                    if (images.Length <= 0) return DEFAULTIMG;

                    if (index < 0) index = 0;

                    if (index >= images.Length) index = images.Length - 1;

                    return sURL + images[index];
                }
            }
        }

        private _SmallImg smallImg = new _SmallImg();
        /// <summary>
        /// 存储小图片的数组
        /// </summary>
        public _SmallImg SmallImg
        {
            get { return smallImg; }
        }

        public string MorePicUrl
        {
            get
            {
                XYECOM.Configuration.WebInfo webInfo = XYECOM.Configuration.WebInfo.Instance;
                if (webInfo.IsBogusStatic)
                {
                    return webInfo.WebDomain + "search/picture-exhibition" + "-" + id + "." + webInfo.WebSuffix;
                }
                else
                {
                    return webInfo.WebDomain + "search/picture." + webInfo.WebSuffix + "?flag=exhibition" + "&id=" + id;
                }
            }
        }

        private string _s_url = "";



        /// <summary>
        /// 图片服务器路径
        /// </summary>
        public string S_URL
        {
            set
            {
                smallImg.SURL = value;
                _s_url = value;
            }
            get { return _s_url; }
        }

        private string filePath;
        /// <summary>
        /// 图片的路径
        /// </summary>
        public string FilePath
        {
            get { return filePath; }
            set { filePath = value; }
        }


        #endregion
    }
}
