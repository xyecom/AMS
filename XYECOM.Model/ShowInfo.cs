using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Model
{
    /// <summary>
    /// չ����Ϣʵ����
    /// </summary>
    public class ShowInfo:Attachment
    {
        #region ��ʱ����
        /// <summary>
        /// չ����Ϣ���
        /// </summary>
        [Obsolete]
        public Int64 SHI_ID
        {
            get { return id; }
        }

        /// <summary>
        /// չ����Ϣ����
        /// </summary>
        [Obsolete]
        public string SHI_Title
        {
            get { return infotitle; }
        }

        /// <summary>
        /// չ����Ϣ����
        /// </summary>
        [Obsolete]
        public string SHI_Content
        {
            get { return contents; }
        }



        /// <summary>
        /// չ��ص�
        /// </summary>
        [Obsolete]
        public string SHI_Place
        {
            get { return district; }
        }

        /// <summary>
        /// չ�᳡��
        /// </summary>
        [Obsolete]
        public string SHI_Stadiums
        {
            get { return site; }
        }

        /// <summary>
        /// ���쵥λ
        /// </summary>
        [Obsolete]
        public string SHI_Sponsor
        {
            get { return sponsor; }
        }

        /// <summary>
        /// �а쵥λ
        /// </summary>
        [Obsolete]
        public string SHI_Undertake
        {
            get { return undertake; }
        }

        /// <summary>
        /// Э�쵥λ
        /// </summary>
        [Obsolete]
        public string SHI_Coorganizor
        {
            get { return coorganizor; }
        }

        /// <summary>
        /// ֧�ֵ�λ
        /// </summary>
        [Obsolete]
        public string SHI_Sustain
        {
            get { return sustain; }
        }

        /// <summary>
        /// չ������
        /// </summary>
        [Obsolete]
        public string SHI_ShowSycle
        {
            get { return sycle; }
        }

        /// <summary>
        /// չ������
        /// </summary>
        [Obsolete]
        public string SHI_ShowCharacter
        {
            get { return type; }
        }

        /// <summary>
        /// չ����ַ
        /// </summary>
        [Obsolete]
        public string SHI_ShowURL
        {
            get { return uRL; }
        }

        /// <summary>
        /// չ�������λ
        /// </summary>
        [Obsolete]
        public string SHI_Landmeasure
        {
            get { return area; }
        }

        /// <summary>
        /// ��λ�������
        /// </summary>
        [Obsolete]
        public int SHI_Unitprice
        {
            get { return unitPrice; }
        }

        /// <summary>
        /// ��С�������
        /// </summary>
        [Obsolete]
        public int SHI_Minration
        {
            get { return leastRation; }
        }

        /// <summary>
        /// �������
        /// </summary>
        [Obsolete]
        public int SHI_TotalArea
        {
            get { return areaTotal; }
        }

        /// <summary>
        /// չ����Ϣ�����
        /// </summary>
        [Obsolete]
        public Int64 SHT_ID
        {
            get { return typeid; }
        }

        /// <summary>
        /// �Ƿ��Ƽ�
        /// </summary>
        [Obsolete]
        public bool SHI_IsCommend
        {
            get { return isCommend; }
        }

        /// <summary>
        /// ��̬ҳ���ַ
        /// </summary>
        [Obsolete]
        public string SHI_HtmlPage
        {
            get { return htmlPage; }
        }
        #endregion

        #region ����������


        private int id;
        /// <summary>
        ///չ���� 
        /// </summary>
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private String infotitle;
        /// <summary>
        /// չ�����
        /// </summary>
        public String Infotitle
        {
            get { return infotitle; }
            set { infotitle = value; }
        }

                
        private int typeid;
        /// <summary>
        /// չ����Ϣ�����
        /// </summary>
        public int Typeid
        {
            get { return typeid; }
            set { typeid = value; }
        }


        private string contents;

        /// <summary>
        /// չ����ϸ��Ϣ
        /// </summary>
        public string Contents
        {
            get { return contents; }
            set { contents = value; }
        }


       
        private string beginTime;
        /// <summary>
        /// չ�ῪĻ����
        /// </summary>
        public string BeginTime
        {
            get { return Core.MyConvert.GetDateTime(beginTime).ToString("yyyy-MM-dd"); }
            set { beginTime = value; }
        }




        private string endTime;
        /// <summary>
        /// չ���Ļ����
        /// </summary>
        public string EndTime
        {
            get { return Core.MyConvert.GetDateTime(endTime).ToString("yyyy-MM-dd");}
            set { endTime = value; }
        }
        
        
        private string district;
        /// <summary>
        /// չ��ص�
        /// </summary>
        public string District
        {
            get { return district; }
            set { district = value; }
        }

        private string site;
        /// <summary>
        /// չ�᳡��
        /// </summary>
        public string Site
        {
            get { return site; }
            set { site = value; }
        }

        private string sponsor;
        /// <summary>
        /// ���쵥λ
        /// </summary>
        public string Sponsor
        {
            get { return sponsor; }
            set { sponsor = value; }
        }

        private string undertake;
        /// <summary>
        /// �а쵥λ
        /// </summary>
        public string Undertake
        {
            get { return undertake; }
            set { undertake = value; }
        }

        private string coorganizor;
        /// <summary>
        /// Э�쵥λ
        /// </summary>
        public string Coorganizor
        {
            get { return coorganizor; }
            set { coorganizor = value; }
        }

        private string sustain;
        /// <summary>
        /// ֧�ֵ�λ
        /// </summary>
        public string Sustain
        {
            get { return sustain; }
            set { sustain = value; }
        }

        private string sycle;
        /// <summary>
        /// չ������
        /// </summary>
        public string Sycle
        {
            get { return sycle; }
            set { sycle = value; }
        }

        private string type;
        /// <summary>
        /// չ������
        /// </summary>
        public string Type
        {
            get { return type; }
            set { type = value; }
        }

        private string uRL;
        /// <summary>
        /// չ����ַ
        /// </summary>
        public string URL
        {
            get { return uRL; }
            set { uRL = value; }
        }

        private string area;
        /// <summary>
        /// չ�������λ
        /// </summary>
        public string Area
        {
            get { return area; }
            set { area = value; }
        }

        private int unitPrice;
        /// <summary>
        /// ��λ�������
        /// </summary>
        public int UnitPrice
        {
            get { return unitPrice; }
            set { unitPrice = value; }
        }

        private int leastRation;
        /// <summary>
        /// ��С�������
        /// </summary>
        public int LeastRation
        {
            get { return leastRation; }
            set { leastRation = value; }
        }

        private int areaTotal;
        /// <summary>
        /// �������
        /// </summary>
        public int AreaTotal
        {
            get { return areaTotal; }
            set { areaTotal = value; }
        }

        
        private bool isCommend;
        /// <summary>
        /// �Ƿ��Ƽ�
        /// </summary>
        public bool IsCommend
        {
            get { return isCommend; }
            set { isCommend = value; }
        }

        
        private string addInfoTime;
        /// <summary>
        /// ���ʱ��
        /// </summary>
        public string AddInfoTime
        {
            get { return Core.MyConvert.GetDateTime(addInfoTime).ToString("yyyy-MM-dd");}
            set { addInfoTime = value; }
        }

      
        
        private string htmlPage;
        /// <summary>
        /// ��̬ҳ��
        /// </summary>
        public string HtmlPage
        {
            get { return htmlPage; }
            set { htmlPage = value; }
        }



        //ͼƬ
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
        /// �洢СͼƬ������
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
        /// ͼƬ������·��
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
        /// ͼƬ��·��
        /// </summary>
        public string FilePath
        {
            get { return filePath; }
            set { filePath = value; }
        }


        #endregion
    }
}
