using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Template
{
    /// <summary>
    /// 应用程序全局配置类
    /// 仅供模板调用
    /// </summary>
    public class WebConfigInfo
    {
        private string _webName;
        private string _webLogo;
        private int _templateId;
        private string _templatePath;
        private string _suffix;
        private bool _bogusStatic;
        private bool _isDomain;
        private string _webURL;
        private string _passwordKey;
        private bool _dateType;
        private string registerMode = "";   //注册模式


        //new
        private string _WebMoneyName = "";
        private string _UploadImageTypes = "";
        private int _UploadImageSize;
        private int _IssueInfoAddWebMoney = 0;
        private int _RefreshInfoAddWebMoney = 0;
        private int _DefaultWebMoney = 0;
        private int _LoginAddScore = 0;
        private int _LoginAddWebMondy = 0;
        private string _WebMasterEmail = "";

        
        /// <summary>
        /// 网站名称
        /// </summary>
        public string WebName
        {
            get { return _webName; }
            set { _webName = value; }
        }

        /// <summary>
        /// 网站Logo地址
        /// </summary>
        public string WebLogo
        {
            get { return _webLogo; }
            set { _webLogo = value; }
        }

        /// <summary>
        /// 当前模板Id
        /// </summary>
        public int TemplateId
        {
            get { return _templateId; }
            set { _templateId = value; }
        }

        /// <summary>
        /// 当前模板路径(名称)
        /// </summary>
        public string TemplatePath
        {
            get { return _templatePath; }
            set { _templatePath = value; }
        }

        /// <summary>
        /// 页面后缀名称
        /// </summary>
        public string Suffix
        {
            get { return _suffix; }
            set { _suffix = value; }
        }

        /// <summary>
        /// 是否启用伪静态
        /// </summary>
        public bool BogusStatic
        {
            get { return _bogusStatic; }
            set { _bogusStatic = value; }
        }

        /// <summary>
        /// 是否启用二级域名
        /// </summary>
        public bool IsDomain
        {
            get { return _isDomain; }
            set { _isDomain = value; }
        }

        /// <summary>
        /// 网站地址URL
        /// </summary>
        public string WebURL
        {
            get { return _webURL; }
            set { _webURL = value; }
        }

        /// <summary>
        /// 密钥
        /// </summary>
        public string PasswordKey
        {
            get { return _passwordKey; }
            set { _passwordKey = value; }
        }

        /// <summary>
        /// 信息有效日期输入类型
        /// </summary>
        public bool DateType
        {
            get { return _dateType; }
            set { _dateType = value; }
        }

        /// <summary>
        /// 注册模式
        /// </summary>
        public string RegMode
        {
            set { registerMode = value; }
            get { return registerMode; }
        }

        /// <summary>
        /// 虚拟币名称
        /// </summary>
        public string WebMoneyName
        {
            get { return _WebMoneyName; }
            set { _WebMoneyName = value; }
        }

        /// <summary>
        /// 允许上传文件的类型
        /// </summary>
        public string UploadImageTypes
        {
            get { return _UploadImageTypes; }
            set { _UploadImageTypes = value; }
        }

        /// <summary>
        /// 允许上传文件的大小
        /// </summary>
        public int UploadImageSize
        {
            get { return _UploadImageSize; }
            set { _UploadImageSize = value; }
        }

        /// <summary>
        /// 发布信息奖励虚拟币个数
        /// </summary>
        public int IssueInfoAddWebMoney
        {
            get { return _IssueInfoAddWebMoney; }
            set { _IssueInfoAddWebMoney = value; }
        }

        /// <summary>
        /// 刷新信息奖励虚拟币个数
        /// </summary>
        public int RefreshInfoAddWebMoney
        {
            get { return _RefreshInfoAddWebMoney; }
            set { _RefreshInfoAddWebMoney = value; }
        }

        /// <summary>
        /// 注册成功默认虚拟币个数
        /// </summary>
        public int DefaultWebMoney
        {
            get { return _DefaultWebMoney; }
            set { _DefaultWebMoney = value; }
        }

        /// <summary>
        /// 登录奖励积分
        /// </summary>
        public int LoginAddScore
        {
            get { return _LoginAddScore; }
            set { _LoginAddScore = value; }
        }

        /// <summary>
        /// 登录奖励虚拟币个数
        /// </summary>
        public int LoginAddWebMondy
        {
            get { return _LoginAddWebMondy; }
            set { _LoginAddWebMondy = value; }
        }

        /// <summary>
        /// 站长邮件
        /// </summary>
        public string WebMasterEmail
        {
            get { return _WebMasterEmail; }
            set { _WebMasterEmail = value; }
        }

        private int _CanChooseTradeNumber;
        /// <summary>
        /// 允许选择的行业个数
        /// </summary>
        public int CanChooseTradeNumber
        {
            get { return _CanChooseTradeNumber; }
            set { _CanChooseTradeNumber = value; }
        }

        //属性名小写，仅供模板读取
        public string webname { get { return _webName; } }
        public string weblogo { get { return _webLogo; } }
        public int templateid { get { return _templateId; } }
        public string templatepath { get { return _templatePath; } }
        public string suffix { get { return _suffix; } }
        public bool bogusstatic { get { return _bogusStatic; } }
        public bool isdomain { get { return _isDomain; } }
        public string weburl { get { return _webURL; } }
        public string passwordkey { get { return _passwordKey; } }
        public bool datetype { get { return _dateType; } }
        public string regmode { get { return registerMode; } }
        public string webmoneyname { get { return _WebMoneyName; } }
        public string uploadimagetypes{get { return _UploadImageTypes; } }
        public int uploadimagesize { get { return _UploadImageSize; } }
        public int issueinfoaddwebmoney {get { return _IssueInfoAddWebMoney; }}
        public int refreshinfoaddwebmoney{ get { return _RefreshInfoAddWebMoney; }}       
        public int defaultwebmoney{get { return _DefaultWebMoney; }}
        public int loginaddscore{get { return _LoginAddScore; }}
        public int loginaddwebmondy {get { return _LoginAddWebMondy; }}
        public string webmasteremail { get { return _WebMasterEmail; }}
        public int canchoosetradenumber{ get { return _CanChooseTradeNumber; }}


        /// <summary>
        /// 是否启用验证码
        /// </summary>
        /// <param name="flag">验证码标识</param>
        /// <returns></returns>
        public bool IsEnabledVCode(string flag)
        {
            flag = flag.Trim().ToLower();

            XYECOM.Configuration.ValidateCodeItem item = XYECOM.Configuration.ValidateCodeItem.Register;

            if (flag.Equals("register")) item = XYECOM.Configuration.ValidateCodeItem.Register;

            if (flag.Equals("login")) item = XYECOM.Configuration.ValidateCodeItem.Login;

            if (flag.Equals("comment")) item = XYECOM.Configuration.ValidateCodeItem.Comment;

            if (flag.Equals("message")) item = XYECOM.Configuration.ValidateCodeItem.Message;

            if (flag.Equals("order")) item = XYECOM.Configuration.ValidateCodeItem.MakeTheOrder;

            if (flag.Equals("quickpost")) item = XYECOM.Configuration.ValidateCodeItem.QuickPost;

            return XYECOM.Configuration.Security.Instance.IsEnabledValidateCode(item);
        }

        /// <summary>
        /// 获取自定义配置字段值
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public string Get(string key)
        {
            return XYECOM.Configuration.CustomConfigField.Instance.Get(key);
        }

        public string GetJs(string key) 
        {
            return XYECOM.Configuration.JsInterface.Instance.GetJs(key);
        }
    }
}
