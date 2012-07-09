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
        /// �������ID ��ȡ���ı�ʾ
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
                    name = "δ���";
                    break;
                case XYECOM.Model.AuditingState.NoPass:
                    name = "��˲�ͨ��";
                    break;
                case XYECOM.Model.AuditingState.Passed:
                    name = "���ͨ��";
                    break;
                case XYECOM.Model.AuditingState.EditNoPass:
                    name = "�༭δͨ��";
                    break;
            }
            return name;
        }
        /// <summary>
        /// ģ��ȫ��������
        /// </summary>
        protected XYECOM.Configuration.Template template = XYECOM.Configuration.Template.Instance;

        #region ϵͳ����

        /// <summary>
        /// ��ѡ����ͼƬ �� �Ƽ� ��� ����
        /// </summary>
        protected const string CHECK_IMG_URL = "<img src=\"../images/checked.gif\" />";
        /// <summary>
        /// δѡ����ͼƬ �� ���Ƽ� δ��� ����
        /// </summary>
        protected const string UNCHECK_IMG_URL = "<img src=\"../images/unchecked.gif\" />";
        /// <summary>
        /// ��ͨ�����
        /// </summary>
        protected const string CHECK_TOOLTIP = "��ͨ�����";
        /// <summary>
        /// δͨ�����
        /// </summary>
        protected const string UNCHECK_TOOLTIP = "δ���";
        /// <summary>
        /// �Ƽ�
        /// </summary>
        protected const string COMMEND_TOOLTIP = "�Ƽ�";
        /// <summary>
        /// ���Ƽ�
        /// </summary>
        protected const string UNCOMMEND_TOOLTIP = "���Ƽ�";
        /// <summary>
        /// ����
        /// </summary>
        protected const string USE_TOOLTIP = "����";
        /// <summary>
        /// ����
        /// </summary>
        protected const string UNUSE_TOOLTIP = "����";
        /// <summary>
        /// ��ʾ
        /// </summary>
        protected const string DISPLAY_TOOLTIP = "��ʾ";
        /// <summary>
        /// ����ʾ
        /// </summary>
        protected const string UNDISPLAY_TOOLTIP = "����ʾ";

        #endregion

        /// <summary>
        /// ϵͳ�����б�ҳʱ��״̬����(����url������)
        /// </summary>
        protected string backURL = "";

        #region �쳣��������
        /// <summary>
        /// ҳ���쳣����
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
        /// �Զ����쳣��¼
        /// </summary>
        /// <param name="message">��Ϣ</param>
        /// <param name="ex">�쳣����</param>
        protected override void WriteLog(string message, Exception ex)
        {
            log.Error(message, ex);

            Response.Redirect(errWebURL + "?msg=" + message);
        }

        #endregion

        #region ��������
        /// <summary>
        /// ���������ҳ��
        /// </summary>
        protected void Reload()
        {
            Response.Redirect(Request.RawUrl, true);
        }

        #endregion

        #region ��֤�û�״̬��Ȩ��

        /// <summary>
        /// ��֤��ɫȨ��
        /// </summary>
        /// <param name="moduleName">ģ������</param>
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

        #region ���ɾ�̬ҳ��
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

        #region �б�ҳѡ����
        /// <summary>
        /// ˮƽѡ�
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
        /// ����ѡѡ�
        /// ѡ����ݽ�Ϊ������ҵ��Ϣģ��
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

        #region ����ָ����Ŀ�ĵ���ҳ��
        /// <summary>
        /// ����ָ����Ŀ�ĵ���ҳ��
        /// </summary>
        /// <param name="path">����·��</param>
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

        #region ģ�����

        /// <summary>
        /// ��ȡ����ģ�飨�̶�ģ�� + ��ҵ��Ϣģ�飩
        /// </summary>
        /// <param name="isIncludeFixModules">�Ƿ�����̶�ģ��</param>
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
                items.Add(new ListItem("��ҵչ��", "exhibition"));
                items.Add(new ListItem("��ҵ��Ѷ", "news"));
                items.Add(new ListItem("�˲���Ƹ", "job"));
                items.Add(new ListItem("��ҵ����", "company"));
                items.Add(new ListItem("�ٿƷ���", "baike"));
            }

            return items;
        }

        /// <summary>
        /// ��Hashtable���ݽṹ����������ҵ��Ϣģ����Ϣ���������ѹر�ģ�飩
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
        /// ��ȡģ����������
        /// </summary>
        /// <param name="name">Ӣ������</param>
        /// <returns></returns>
        protected override string GetModuleCNName(string name)
        {
            if (name.Equals("exhibition")) return "��ҵչ��";

            if (name.Equals("news")) return "��ҵ��Ѷ";

            if (name.Equals("job")) return "�˲���Ƹ";

            if (name.Equals("company")) return "��ҵ����";

            Configuration.ModuleInfo info = moduleConfig.GetItem(name);

            if (info != null) return info.CName;

            return "";
        }
        #endregion

        #region ���ÿؼ��ĳ�ʼֵ

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
        /// �ܾ�ͨ�����
        /// </summary>
        /// <param name="descTabName">���ݱ�ʶ</param>
        /// <param name="infoId">��ϢId</param>
        /// <param name="reason">ԭ��</param>
        /// <param name="advice">����</param>
        protected int NotPassAudit(string descTabName, long infoId, string reason, string advice)
        {
            XYECOM.Business.Auditing audBLL = new XYECOM.Business.Auditing();
            XYECOM.Model.AuditingInfo audInfo = new XYECOM.Model.AuditingInfo();

            //�޸����״̬
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
        /// �󶨹ؼ������������б�
        /// </summary>
        /// <param name="obj"></param>
        protected void BindRankList(DropDownList obj)
        {
            int total = XYECOM.Configuration.Ranking.Instance.Total;

            for (int i = 1; i <= total; i++)
            {
                obj.Items.Add(new ListItem("��" + i + "��", i + ""));
            }
        }


        /// <summary>
        /// ��ת�����͵������б�
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
                    listItems.AddRange(_BindData(typename, info.ClassId, "��" + splitStr));
            }

            return listItems;
        }

        /// <summary>
        /// ͨ����ҵId��ȡ��ҵ���ƣ���Ҫ�����б����ݰ󶨣�
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
        /// ��ȡ��Ϣ��Ĭ��ͼƬ
        /// </summary>
        /// <param name="descTabName">Ŀ�������</param>
        /// <param name="infoId">�û���ҵ��Ϣ���</param>
        /// <returns>Ĭ��ͼƬ</returns>
        protected override string GetInfoImgHref(string descTabName, long infoId)
        {
            XYECOM.Model.AttachmentItem item = Business.Attachment.GetAttachmentItem(descTabName);

            return Business.Attachment.GetInfoDefaultImgHref(item, infoId);
        }

        /// <summary>
        /// ��ȡ��Ϣ���������ࣨ�����Ϣ���ڵ����������� ����������_��������_һ������ �� ��ʽ���أ���Ҫ����SEO��
        /// </summary>
        /// <param name="moduleName">ģ������</param>
        /// <param name="classId">����ID</param>
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


        #region �����ҵ��Ϣʧ�ܸ��û�����
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
                em.M_Title = "��" + infoName + "�����δ����";

                em.M_Content = string.Format("{0}<br />ԭ��:{1}<br />����:{2}<br /><a href=\"{3}\">��������޸�ҳ��</a>", webInfo.AuditingUserMessageContent, reason, advice, url);

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
