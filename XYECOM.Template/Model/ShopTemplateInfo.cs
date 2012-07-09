using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Template
{
    /// <summary>
    /// ����ģ����Ϣ����
    /// </summary>
    public abstract class ShopTemplateInfo
    {
        private string _access;
        private string _user;

        /// <summary>
        /// ����Ȩ��(�ַ�)
        /// </summary>
        public string AccessStr
        {
            get { return _access; }
            set { _access = value; }
        }

        /// <summary>
        /// ����Ȩ��
        /// </summary>
        public ShopTemplateAccess Access
        {
            get
            {
                if (_access.ToLower().Equals("private"))
                    return ShopTemplateAccess.Private;

                return ShopTemplateAccess.Public;
            }

            set
            {
                if (value == ShopTemplateAccess.Private)
                    _access = "private";
                else
                    _access = "public";
            }
        }

        /// <summary>
        /// �û�/�û���ID
        /// </summary>
        public string User
        {
            get { return _user; }
            set { _user = value; }
        }
    }
}
