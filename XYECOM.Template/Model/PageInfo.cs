using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Template
{
    /// <summary>
    /// 页面信息类(模板中可以调用)
    /// </summary>
    public class PageInfo
    {
        #region 系统功能性信息
        /// <summary>
        /// 用户当前的登录状态
        /// </summary>
        public string LoginStatus = "<script>UserStatus();</script>";

        #endregion

        /// <summary>
        /// 当前模块标识（父模块标识）
        /// </summary>
        public string ModuleFlag = "";

        /// <summary>
        /// 模块名称(模块名称/子模块名称)
        /// </summary>
        public string ModuleName = "";

        public bool IsGet;
        public bool IsPost;

        public string Meta = "";
        /// <summary>
        /// 页面状态，一般用于表示页面运行结果的多种状态
        /// </summary>
        public string PageState = "";

        public string MsgboxText = "";
        public string MsgboxURL = "";
        public int NewTopicMinute;

        public int PageError;
        public string PageTitle = "";

        public string TabName = "";

        #region ***************翻页使用**********************

        public int PageIndex = 0;
        public string FirstPage = "";
        public string NextPage = "";
        public string LastPage = "";
        public string PreviousPage = "";
        public int PageCount = 0;
        /// <summary>
        /// 标签中指定的每页信息条数
        /// </summary>
        public int PageSize = 0;
        /// <summary>
        /// 用户浏览是自定义的每页信息条数
        /// </summary>
        public int CustomPageSize = 0;
        public string NumPage = "";
        public int TotalRecord = 0;
        #endregion ******************************************


        /// <summary>
        /// 关键词竞价记录条数
        /// </summary>
        public int KeyCount = 0;

        public string PageURL = "";
        public string BarFlag = "";
        public bool Activation = false;

        /// <summary>
        /// 页面加载事件
        /// </summary>
        public string OnLoadEvents = "";


        #region 搜索页面使用

        public string SearchKey = "";           //搜索关键字
        public string StrSearchWhere = "";      //搜索条件
        public string StrKeySearchWhere = "";   //关键词竞价搜索条件
        public string StrPageSeachWhere = "";   //分页搜索条件
        public bool isplatform = true;


        //导航
        public string Navigation = "";

        #endregion

        public string DomainHost = "";         // 二级域名主机头

        /// <summary>
        /// 是否去除版权
        /// </summary>
        public bool IsCopyright = false;

        /// <summary>
        /// 排名关键词Id
        /// </summary>
        public long RankKeyId = -1;

        /// <summary>
        /// 相关产品信息
        /// </summary>
        public string AboutInfo = "";


        /// <summary>
        /// 会员中心信息管理菜单列表
        /// </summary>
        public string InfoManageMenu = "";

        /// <summary>
        /// 会员中心统计信息
        /// </summary>
        public string StatInfo = "";
        /// <summary>
        /// 会员中心控制面板快发列表
        /// </summary>
        public string UserCenterModule = "";
        /// <summary>
        /// 网店信息列表链接
        /// </summary>
        public string InfoListLink = "";

        /// <summary>
        /// 是否启用在线支付
        /// </summary>
        public bool IsOnlinePayment = false;

        #region 标签外部参数

        /// <summary>
        /// 地区Id（标签外部参数）
        /// </summary>
        public int OuterAreaId = 0;

        /// <summary>
        /// 行业Id(即企业分类Id)
        /// </summary>
        public int OuterTradeId = 0;

        /// <summary>
        /// 标签外部指定排序规则(不带Order by)
        /// </summary>
        public string OuterOrderStr = "";

        /// <summary>
        /// 产品分类Id(产品频道首页传递)
        /// </summary>
        public long OuterProTypeId = 0;

        #endregion


        /// <summary>
        /// 获取验证码文本框及验证码图片HTML
        /// </summary>
        /// <returns></returns>
        public string GetValidateCodeHTML()
        {
            string src = XYECOM.Configuration.WebInfo.Instance.WebDomain + "common/ValidateCode.ashx?";

            int length = XYECOM.Configuration.Security.Instance.VCodeLength;

            string js = "<script language=\"javascript\">";
            js += "function  _XY_ShowCode(){document.getElementById(\"vCodeImg\").style.display=\"\"; document.getElementById(\"vCodeImg\").src='" + src + "='+Math.random();}";
            js += "</script>";

            string vcode = "<input type=\"text\" name=\"vcode\" id=\"vcode\" onkeydown =\"try{LoginKeyPress();}catch(e){}\" maxlength=\"" + length + "\" size=\"" + (length + 2) + "\" onfocus=\"_XY_ShowCode();\"/><img  src=\"/common/images/ajax-loading-circle.gif\" id=\"vCodeImg\" style=\"cursor:pointer;display:none;vertical-align:middle;\"/>";

            return js + vcode;
        }

        /// <summary>
        /// 获取验证码文本框及验证码图片HTML（针对一个页面存在一个以上验证码的情况，防止重名）
        /// </summary>
        /// <param name="code">验证码文本框的Id</param>
        /// <param name="imgid">验证码图片的Id</param>
        /// <returns></returns>
        public string GetValidateCodeHTML(string code, string imgid)
        {
            string src = XYECOM.Configuration.WebInfo.Instance.WebDomain + "common/ValidateCode.ashx?";

            int length = XYECOM.Configuration.Security.Instance.VCodeLength;

            string js = "<script language=\"javascript\">";
            js += "function  _XY_ShowCode" + code + "(){document.getElementById(\"" + imgid + "\").style.display=\"\"; document.getElementById(\"" + imgid + "\").src='" + src + "='+Math.random();}";
            js += "</script>";

            string vcode = "<input type=\"text\" name=\"" + code + "\" id=\"" + code + "\" onkeydown =\"try{LoginKeyPress();}catch(e){}\" maxlength=\"" + length + "\" size=\"" + (length + 2) + "\" onfocus=\"_XY_ShowCode" + code + "();\"/><img  src=\"/common/images/ajax-loading-circle.gif\" id=\"" + imgid + "\" style=\"cursor:pointer;display:none;vertical-align:middle;\" />";

            return js + vcode;
        }
    }
}
