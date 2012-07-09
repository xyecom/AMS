using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Model
{
    /// <summary>
    /// ����ͼʵ����
    /// </summary>
    public class ThumbnailImg
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

        /// <summary>
        /// ͼƬ������·��
        /// </summary>
        public string SURL
        {
            get { return sURL; }
            set { sURL = value; }
        }

        private string defaultFilePath = "";
        /// <summary>
        /// Ĭ�ϵĴ�ͼƬ��ַ
        /// </summary>
        public string DefaultFilePath
        {
            get { return defaultFilePath; }
            set { defaultFilePath = value; }
        }

        /// <summary>
        /// ��������ͼ
        /// </summary>
        /// <param name="index">ͼƬ���� [1~3] </param>
        /// <returns></returns>
        public string this[int index]
        {
            get
            {
                if (images.Length <= 0)
                {
                    if (DefaultFilePath != "")
                        return DefaultFilePath;

                    return DEFAULTIMG;
                }

                if (index < 0) index = 0;

                if (index >= images.Length) index = images.Length - 1;

                if (images[index].Trim().Equals(""))
                {
                    if (DefaultFilePath != "")
                        return DefaultFilePath;

                    return DEFAULTIMG;
                }

                return sURL + images[index];
            }
        }
    }
}
