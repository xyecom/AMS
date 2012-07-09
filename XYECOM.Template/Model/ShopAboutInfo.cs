using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Template
{
    /// <summary>
    /// ����ģ�����Ȩ�޷�ʽö��
    /// </summary>
    public enum ShopTemplateAccess
    {
        /// <summary>
        /// ����ģ��
        /// </summary>
        Public,
        /// <summary>
        /// ˽��ģ��
        /// </summary>
        Private
    }

    /// <summary>
    /// ����ģ�������Ϣʵ����
    /// </summary>
    public class ShopAboutInfo:ShopTemplateInfo
    {
        private string _name;
        private string _cname;
        private string _author;
        private string _createdate;
        private string _ver;
        private string _copyright;
        private string _image;

        public ShopAboutInfo(string name, string cname,string access,string user, string author, string createdate, string ver, string copyright,string image)
        {
            _name = name;
            _cname = cname;
            _author = author;
            _createdate = createdate;
            _ver = ver;
            _copyright = copyright;
            _image = image;

            base.AccessStr = access;
            base.User = user;
        }

        /// <summary>
        /// ģ������
        /// </summary>
        public string Name
        {
            get { return _name; }
        }

        /// <summary>
        /// ģ����������
        /// </summary>
        public string CName
        {
            get { return _cname; }
        }

        /// <summary>
        /// ģ������
        /// </summary>
        public string Author
        {
            get { return _author; }
        }

        /// <summary>
        /// ģ�崴��ʱ��
        /// </summary>
        public string CreateDate
        {
            get { return _createdate; }
        }

        /// <summary>
        /// ģ��֧�ְ汾
        /// </summary>
        public string Ver
        {
            get { return _ver; }
        }

        /// <summary>
        /// ģ���Ȩ
        /// </summary>
        public string Copyright
        {
            get { return _copyright; }
        }

        /// <summary>
        /// ����ͼƬ
        /// </summary>
        public string Image
        {
            set { _image = value; }
            get { return _image; }
        }
    }
}
