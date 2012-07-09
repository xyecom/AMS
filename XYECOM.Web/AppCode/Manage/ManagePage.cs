using System;
using System.Data;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Security.Permissions;
using System.IO;
using XYECOM.Business;

namespace XYECOM.Web.BasePage
{
    public abstract class ManagePage : XYECOM.Page.BasePage
    {
        log4net.ILog log = log4net.LogManager.GetLogger("ManageError");

        string errWebURL = XYECOM.Configuration.WebInfo.Instance.WebDomain + XYECOM.Configuration.WebInfo.Instance.AdminFolder + "/Err.aspx";

        /// <summary>
        /// 根据审核ID 获取中文标示
        /// </summary>
        /// <param name="stateId"></param>
        /// <returns></returns>
        protected virtual string GetAuditingState(int stateId)
        {
            Model.AuditingState sta = (Model.AuditingState)stateId;
            string name = "";
            switch (sta)
            {
                case XYECOM.Model.AuditingState.Null:
                    name = "未审核";
                    break;
                case XYECOM.Model.AuditingState.NoPass:
                    name = "审核不通过";
                    break;
                case XYECOM.Model.AuditingState.Passed:
                    name = "审核通过";
                    break;
                case XYECOM.Model.AuditingState.EditNoPass:
                    name = "编辑未通过";
                    break;
            }
            return name;
        }
        /// <summary>
        /// 模板全局配置类
        /// </summary>
        protected XYECOM.Configuration.Template template = XYECOM.Configuration.Template.Instance;

        #region 系统常量

        /// <summary>
        /// 以选定的图片 如 推荐 审核 启用
        /// </summary>
        protected const string CHECK_IMG_URL = "<img src=\"../images/checked.gif\" />";
        /// <summary>
        /// 未选定的图片 如 不推荐 未审核 禁用
        /// </summary>
        protected const string UNCHECK_IMG_URL = "<img src=\"../images/unchecked.gif\" />";
        /// <summary>
        /// 已通过审核
        /// </summary>
        protected const string CHECK_TOOLTIP = "已通过审核";
        /// <summary>
        /// 未通过审核
        /// </summary>
        protected const string UNCHECK_TOOLTIP = "未审核";
        /// <summary>
        /// 推荐
        /// </summary>
        protected const string COMMEND_TOOLTIP = "推荐";
        /// <summary>
        /// 不推荐
        /// </summary>
        protected const string UNCOMMEND_TOOLTIP = "不推荐";
        /// <summary>
        /// 启用
        /// </summary>
        protected const string USE_TOOLTIP = "启用";
        /// <summary>
        /// 禁用
        /// </summary>
        protected const string UNUSE_TOOLTIP = "禁用";
        /// <summary>
        /// 显示
        /// </summary>
        protected const string DISPLAY_TOOLTIP = "显示";
        /// <summary>
        /// 不显示
        /// </summary>
        protected const string UNDISPLAY_TOOLTIP = "不显示";

        #endregion

        /// <summary>
        /// 系统返回列表页时的状态参数(进行url编码后的)
        /// </summary>
        protected string backURL = "";

        #region 异常及错误处理
        /// <summary>
        /// 页面异常处理
        /// </summary>
        /// <param name="e"></param>
        protected override void OnError(EventArgs e)
        {
            Exception ex = Server.GetLastError();

            log.Error("", Server.GetLastError());
            Response.Redirect(errWebURL + "?msg=" + System.Text.RegularExpressions.Regex.Replace(ex.Message, @"\s", ""));

            base.OnError(e);
        }

        /// <summary>
        /// 自定义异常记录
        /// </summary>
        /// <param name="message">消息</param>
        /// <param name="ex">异常对象</param>
        protected override void WriteLog(string message, Exception ex)
        {
            log.Error(message, ex);

            Response.Redirect(errWebURL + "?msg=" + message);
        }

        #endregion

        #region 其他方法
        /// <summary>
        /// 重新载入该页面
        /// </summary>
        protected void Reload()
        {
            Response.Redirect(Request.RawUrl, true);
        }

        #endregion

        #region 验证用户状态及权限

        /// <summary>
        /// 验证角色权限
        /// </summary>
        /// <param name="moduleName">模块名称</param>
        /// <returns></returns>
        protected void CheckRole(string moduleName)
        {
            XYECOM.Business.UserPopedom upd = new XYECOM.Business.UserPopedom();

            if (!upd.IsUser(moduleName, Convert.ToInt64(AdminId)) == true)
            {
                string url = "../err.aspx?key=001";
                this.Response.Redirect(url, true);
            }
        }

        #endregion

        #region 生成静态页面
        protected void CreateHTML(string idList, string pageType, string moduleName)
        {
            XYECOM.Web.Html.HtmlInfo info = new XYECOM.Web.Html.HtmlInfo();

            info.InfoIdList = idList;
            info.PageType = pageType;
            info.PageModule = moduleName;
            info.IsDel = false;

            XYECOM.Web.Html.HtmlManage.TaskList.Add(info);

            XYECOM.Web.Html.HtmlManage.Start();
        }

        protected void DeleteHTML(string idList, string pageType, string moduleName)
        {
            XYECOM.Web.Html.HtmlInfo info = new XYECOM.Web.Html.HtmlInfo();

            info.InfoIdList = idList;
            info.PageType = pageType;
            info.PageModule = moduleName;
            info.IsDel = true;

            XYECOM.Web.Html.HtmlManage.TaskList.Add(info);

            XYECOM.Web.Html.HtmlManage.Start();
        }
        #endregion

        #region 列表页选项卡相关
        /// <summary>
        /// 水平选项卡
        /// </summary>
        /// <param name="currentModuleName"></param>
        /// <param name="parentModuleName"></param>
        /// <returns></returns>
        protected string GetModuleListHTMLByTabs(string currentModuleName, string parentModuleName)
        {
            String tabHTML = "";

            DataRowCollection rows = null;

            if (!parentModuleName.Equals(""))
                rows = moduleConfig.GetItem(parentModuleName).ToTables.Rows;
            else
                rows = moduleConfig.GetDataTable.Rows;

            int i = 0;
            foreach (DataRow row in rows)
            {
                if (currentModuleName.Equals(row["EName"].ToString()))
                    tabHTML += "<li  class=\"current\"><a href='#'><span>" + row["CName"].ToString() + "</span></a></li>";
                //                    tabHTML += "<li  class=\"hover\"><a href='?ename=" + row["EName"].ToString() + "' onclick=\"setCurTab(0," + i + ");\">" + row["CName"].ToString() + "</a></li>";
                else
                    tabHTML += "<li ><a href='?ename=" + row["EName"].ToString() + "' onclick=\"setCurTab(0," + i + ");\"><span>" + row["CName"].ToString() + "</span></a></li>";

                i++;
            }

            return tabHTML;
        }

        /// <summary>
        /// 纵向选选项卡
        /// 选项卡内容仅为所有商业信息模块
        /// </summary>
        /// <param name="currentModuleName"></param>
        /// <param name="parentModuleName"></param>
        /// <returns></returns>
        protected virtual string GetModuleListHTMLByYTabs(string currentModuleName, string parentModuleName)
        {
            String tabHTML = "";

            DataRowCollection rows = null;

            if (!parentModuleName.Equals(""))
                rows = moduleConfig.GetItem(parentModuleName).ToTables.Rows;
            else
                rows = moduleConfig.GetDataTable.Rows;

            int i = 0;
            foreach (DataRow row in rows)
            {
                if (currentModuleName.Equals(row["EName"].ToString()))
                    tabHTML += "<div  class=\"Yhover\">" + row["CName"].ToString() + "</div>";
                else
                    tabHTML += "<div id=\"menuItem_" + row["EName"].ToString() + "\"><a href='?ename=" + row["EName"].ToString() + "' onclick=\"setYCurTab(" + row["EName"].ToString() + ");\">" + row["CName"].ToString() + "</a></div>";

                i++;
            }

            return tabHTML;
        }
        #endregion

        #region 创建指定栏目的导航页面
        /// <summary>
        /// 创建指定栏目的导航页面
        /// </summary>
        /// <param name="path">虚拟路径</param>
        /// <returns></returns>
        protected bool CreateIndexPage(string path)
        {
            bool result = false;

            try
            {
                string dir = System.Web.HttpContext.Current.Server.MapPath(path);

                if (!Directory.Exists(dir)) Directory.CreateDirectory(dir);

                string fileFullPath = System.IO.Path.Combine(dir, "index." + webInfo.WebSuffix);

                if (File.Exists(fileFullPath)) return true;

                string fileBody = "<%@ Page %>";

                Byte[] info = System.Text.Encoding.Default.GetBytes(fileBody);

                System.IO.FileStream fs = new FileStream(fileFullPath, FileMode.Create, FileAccess.Write);

                fs.Write(info, 0, info.Length);

                fs.Flush();

                fs.Close();

                result = true;
            }
            catch { }

            return result;
        }
        #endregion

        #region 模块相关

        /// <summary>
        /// 获取所有模块（固定模块 + 商业信息模块）
        /// </summary>
        /// <param name="isIncludeFixModules">是否包含固定模块</param>
        /// <returns></returns>
        protected List<ListItem> GetAllModules(bool isIncludeFixModules)
        {
            List<ListItem> items = new List<ListItem>();

            foreach (XYECOM.Configuration.ModuleInfo info in moduleConfig.ModuleItems)
            {
                items.Add(new ListItem(info.CName, info.EName));
            }

            if (isIncludeFixModules)
            {
                items.Add(new ListItem("行业展会", "exhibition"));
                items.Add(new ListItem("行业资讯", "news"));
                items.Add(new ListItem("人才招聘", "job"));
                items.Add(new ListItem("企业导航", "company"));
                items.Add(new ListItem("百科分类", "baike"));
            }

            return items;
        }

        /// <summary>
        /// 以Hashtable数据结构返回所有商业信息模块信息（不包含已关闭模块）
        /// </summary>
        /// <returns></returns>
        protected System.Collections.Specialized.ListDictionary GetAllInfoModules()
        {
            System.Collections.Specialized.ListDictionary list = new System.Collections.Specialized.ListDictionary();

            foreach (XYECOM.Configuration.ModuleInfo info in moduleConfig.ModuleItems)
            {
                if (info.State == false) continue;
                list.Add(info.EName, info.CName);
            }

            return list;
        }

        /// <summary>
        /// 获取模块中文名称
        /// </summary>
        /// <param name="name">英文名称</param>
        /// <returns></returns>
        protected override string GetModuleCNName(string name)
        {
            if (name.Equals("exhibition")) return "行业展会";

            if (name.Equals("news")) return "行业资讯";

            if (name.Equals("job")) return "人才招聘";

            if (name.Equals("company")) return "企业导航";

            Configuration.ModuleInfo info = moduleConfig.GetItem(name);

            if (info != null) return info.CName;

            return "";
        }
        #endregion

        #region 设置控件的初始值

        protected virtual void SetValueByquery(ref string var, string query)
        {
            if (XYECOM.Core.XYRequest.GetQueryString(query) != "")
                var = XYECOM.Core.XYRequest.GetQueryString(query);
        }

        protected virtual void SetValueByquery(xymanage_UserControl_page control, string query)
        {
            if (XYECOM.Core.XYRequest.GetQueryInt(query, 0) > 0)
                control.CurPage = XYECOM.Core.XYRequest.GetQueryInt(query, 0);
        }

        protected virtual void SetValueByquery(TextBox control, string query)
        {
            if (XYECOM.Core.XYRequest.GetQueryString(query) != "")
                control.Text = XYECOM.Core.XYRequest.GetQueryString(query);
        }

        protected virtual void SetValueByquery(RadioButtonList control, string query)
        {
            if (XYECOM.Core.XYRequest.GetQueryString(query) != "")
                control.Text = XYECOM.Core.XYRequest.GetQueryString(query);
        }

        protected virtual void SetValueByquery(HtmlInputHidden control, string query)
        {
            if (XYECOM.Core.XYRequest.GetQueryString(query) != "")
                control.Value = XYECOM.Core.XYRequest.GetQueryString(query);
        }

        protected virtual void SetValueByquery(HtmlSelect control, string query)
        {
            if (XYECOM.Core.XYRequest.GetQueryString(query) != "")
                control.Value = XYECOM.Core.XYRequest.GetQueryString(query);
        }

        protected virtual void SetValueByquery(HtmlInputText control, string query)
        {
            if (XYECOM.Core.XYRequest.GetQueryString(query) != "")
                control.Value = XYECOM.Core.XYRequest.GetQueryString(query);
        }

        protected virtual void SetValueByquery(DropDownList control, string query)
        {
            if (XYECOM.Core.XYRequest.GetQueryString(query) != "")
                control.Text = XYECOM.Core.XYRequest.GetQueryString(query);
        }

        protected virtual void SetValueByquery(CheckBoxList control, string query)
        {
            if (XYECOM.Core.XYRequest.GetQueryString(query) != "")
                control.Text = XYECOM.Core.XYRequest.GetQueryString(query);
        }

        protected virtual void SetValueByquery(ListBox control, string query)
        {
            if (XYECOM.Core.XYRequest.GetQueryString(query) != "")
                control.Text = XYECOM.Core.XYRequest.GetQueryString(query);
        }

        protected virtual void SetValueByquery(CheckBox control, string query, string checkedstate)
        {
            if (checkedstate == "1")
            {
                if (XYECOM.Core.XYRequest.GetQueryString(query) != "true" && XYECOM.Core.XYRequest.GetQueryString(query) != "")
                    control.Checked = false;
                else
                    control.Checked = true;
            }
            else
            {
                if (XYECOM.Core.XYRequest.GetQueryString(query) != "true")
                    control.Checked = false;
                else
                    control.Checked = true;
            }

        }

        #endregion

        /// <summary>
        /// 拒绝通过审核
        /// </summary>
        /// <param name="descTabName">内容标识</param>
        /// <param name="infoId">信息Id</param>
        /// <param name="reason">原因</param>
        /// <param name="advice">建议</param>
        protected int NotPassAudit(string descTabName, long infoId, string reason, string advice)
        {
            XYECOM.Business.Auditing audBLL = new XYECOM.Business.Auditing();
            XYECOM.Model.AuditingInfo audInfo = new XYECOM.Model.AuditingInfo();

            //修改审核状态
            int i = audBLL.UpdatesAuditing(infoId, descTabName, XYECOM.Model.AuditingState.NoPass);

            audInfo = audBLL.GetItem(infoId + "", descTabName);

            if (audInfo == null)
            {
                audInfo = new XYECOM.Model.AuditingInfo();
                audInfo.DescTabName = descTabName;
                audInfo.DescTabID = infoId;
            }

            audInfo.A_Advice = reason;
            audInfo.A_Reason = advice;

            audBLL.Update(audInfo);

            return i;
        }

        /// <summary>
        /// 绑定关键词排名名次列表
        /// </summary>
        /// <param name="obj"></param>
        protected void BindRankList(DropDownList obj)
        {
            int total = XYECOM.Configuration.Ranking.Instance.Total;

            for (int i = 1; i <= total; i++)
            {
                obj.Items.Add(new ListItem("第" + i + "名", i + ""));
            }
        }


        /// <summary>
        /// 绑定转移类型的下拉列表
        /// </summary>
        /// <param name="parentID"></param>
        /// <param name="splitStr"></param>
        /// <returns></returns>
        protected List<ListItem> _BindData(string typename, long parentID, string splitStr)
        {
            XYECOM.Business.XYClass BLL = new XYClass();

            List<ListItem> listItems = new List<ListItem>();
            List<XYECOM.Model.XYClassInfo> infos = XYECOM.Business.XYClass.GetSubItems(typename, parentID);

            foreach (XYECOM.Model.XYClassInfo info in infos)
            {
                listItems.Add(new ListItem(splitStr + info.ClassName, info.ClassId.ToString()));

                if (XYECOM.Business.XYClass.IsHasSubClass(typename, info.ClassId))
                    listItems.AddRange(_BindData(typename, info.ClassId, "　" + splitStr));
            }

            return listItems;
        }

        /// <summary>
        /// 通过企业Id获取企业名称（主要用于列表数据绑定）
        /// </summary>
        /// <param name="_userId"></param>
        /// <returns></returns>
        protected string GetCompanyName(object _userId)
        {
            long userId = XYECOM.Core.MyConvert.GetInt64(_userId.ToString());

            if (userId <= 0) return "";

            Model.UserInfo userInfo = new Business.UserInfo().GetItem(userId);

            if (userInfo == null) return "";

            return userInfo.Name;
        }

        /// <summary>
        /// 获取信息的默认图片
        /// </summary>
        /// <param name="descTabName">目标表名称</param>
        /// <param name="infoId">用户企业信息编号</param>
        /// <returns>默认图片</returns>
        protected override string GetInfoImgHref(string descTabName, long infoId)
        {
            XYECOM.Model.AttachmentItem item = Business.Attachment.GetAttachmentItem(descTabName);

            return Business.Attachment.GetInfoDefaultImgHref(item, infoId);
        }

        /// <summary>
        /// 获取信息的完整分类（如果信息属于第三级，则以 “三级分类_二级分类_一级分类 ” 形式返回，主要用于SEO）
        /// </summary>
        /// <param name="moduleName">模块名称</param>
        /// <param name="classId">分类ID</param>
        /// <returns></returns>
        protected string GetAllClassNameForSEO(string moduleName, long classId)
        {
            string className = "";

            if (classId > 0)
            {
                List<Model.XYClassInfo> infos = Business.XYClass.GetParentClassInfos(moduleName, classId);

                foreach (Model.XYClassInfo info in infos)
                {
                    if (className.Equals(""))
                        className = info.ClassName;
                    else
                        //className += "<br>" + info.ClassName;
                        //className = className + "<br>" + info.ClassName;
                        className = info.ClassName + ">>" + className;
                }

            }

            return className;
        }


        #region 审核商业信息失败给用户留言
        protected virtual void SendMessage(long U_ID, string url, string reason, string advice, string infoName)
        {
            if (webInfo.IsAuditingInfoMessage)
            {
                XYECOM.Model.MessageInfo em = new XYECOM.Model.MessageInfo();
                XYECOM.Business.Message m = new Message();
                em.M_Adress = "";
                em.M_CompanyName = "";
                em.M_Email = "";
                em.M_FHM = "";
                em.M_HasReply = false;
                em.M_Moblie = "";
                em.M_PHMa = "";
                em.M_RecverType = "administrator";
                em.M_Restore = false;
                em.M_SenderType = "user";
                em.M_Title = "【" + infoName + "】审核未功过";

                em.M_Content = string.Format("{0}<br />原因:{1}<br />建议:{2}<br /><a href=\"{3}\">点击进入修改页面</a>", webInfo.AuditingUserMessageContent, reason, advice, url);

                em.M_UserName = "";
                em.M_UserType = false;
                em.U_ID = -1;
                em.UR_ID = U_ID;
                m.Insert(em);
            }
        }
        #endregion

        protected virtual string GetInfoUrl(string staticPage, string infoId)
        {
            return webInfo.WebDomain;
        }

        protected int AdminId
        {
            get
            {
                return Convert.ToInt32(Session["UM_ID"].ToString());
            }
        }

        protected override void OnInit(EventArgs e)
        {
            if (!Business.CheckUser.CheckManageSessionState())
            {
                Response.Redirect(string.Format("/{0}/login.aspx", webInfo.AdminFolder));
                return;
            }

            base.OnInit(e);
        }
    }
}
