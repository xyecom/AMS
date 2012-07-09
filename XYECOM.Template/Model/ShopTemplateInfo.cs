using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Template
{
    /// <summary>
    /// 网店模板信息父类
    /// </summary>
    public abstract class ShopTemplateInfo
    {
        private string _access;
        private string _user;

        /// <summary>
        /// 访问权限(字符)
        /// </summary>
        public string AccessStr
        {
            get { return _access; }
            set { _access = value; }
        }

        /// <summary>
        /// 访问权限
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
        /// 用户/用户组ID
        /// </summary>
        public string User
        {
            get { return _user; }
            set { _user = value; }
        }
    }
}
