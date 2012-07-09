using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Net;

namespace XYECOM.Web.xymanage.Global
{
    public partial class AttachmentManage : XYECOM.Web.BasePage.ManagePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CheckRole("attachment");

            if (!IsPostBack)
            {
                this.btnDelete.Attributes.Add("onclick", "javascript:return del();");

                BindImageFormat();
                BindFileFormat();

                SetValueByquery(Page1, "page");
                SetValueByquery(selInfoType, "DescTabName");
                SetValueByquery(rdolstImgFormat, "imgFormat");
                SetValueByquery(rdolstImgFormat, "fileFormat");
                SetValueByquery(txtStartTime, "beginDate");
                SetValueByquery(txtEndTime, "endDate");

                if (XYECOM.Core.XYRequest.GetQueryString("attBody") != "")
                {
                    string attBody = XYECOM.Core.XYRequest.GetQueryString("attBody");

                    if (attBody.Equals("file"))
                        this.rdoBodyFile.Checked = true;
                    else
                        this.rdoBodyImage.Checked = true;
                }

                if (XYECOM.Core.XYRequest.GetQueryString("isIncludeSmallImg") != "")
                {
                    string isIncludeSmallImg = XYECOM.Core.XYRequest.GetQueryString("isIncludeSmallImg");

                    if (isIncludeSmallImg.Equals("yes"))
                        rdoIsIncludeSmallImgYes.Checked = true;
                    else if (isIncludeSmallImg.Equals("no"))
                        rdoIsIncludeSmallImgNo.Checked = true;
                    else
                        rdoIsIncludeSmallImgAll.Checked = true;
                }

                if (XYECOM.Core.XYRequest.GetQueryString("isValid") != "")
                {
                    string isValid = XYECOM.Core.XYRequest.GetQueryString("isValid");

                    if (isValid.Equals("yes"))
                        rdoIsValidYes.Checked = true;
                    else if (isValid.Equals("no"))
                        rdoIsValidNo.Checked = true;
                    else
                        rdoIsValidAll.Checked = true;
                }

                this.Page1.PageSize = 50;

            }
        }

        private void BindImageFormat()
        {
            string[] imgs = webInfo.UploadFileType.Split(';');

            this.rdolstImgFormat.Items.Clear();
            foreach (string s in imgs)
            {
                this.rdolstImgFormat.Items.Add(new ListItem(s, s));
            }

            rdolstImgFormat.Items.Insert(0, new ListItem("全部", "all"));

            rdolstImgFormat.Items[0].Selected = true;
        }

        private void BindFileFormat()
        {
            string[] files = webInfo.UploadAdjunctType.Split(';');

            this.rdolstFileFormat.Items.Clear();
            foreach (string s in files)
            {
                this.rdolstFileFormat.Items.Add(new ListItem(s, s));
            }

            rdolstFileFormat.Items.Insert(0, new ListItem("全部", "all"));

            rdolstFileFormat.Items[0].Selected = true;
        }

        protected override void BindData()
        {
            if (System.Web.HttpContext.Current.Request.Url.Query.Equals(""))
            {
                return;
            }
            string attBody = "image";

            if (rdoBodyFile.Checked) attBody = "file";

            string isIncludeSmallImg = "";

            if (attBody.Equals("image"))
            {
                isIncludeSmallImg = "all";

                if (rdoIsIncludeSmallImgYes.Checked) isIncludeSmallImg = "yes";

                if (rdoIsIncludeSmallImgNo.Checked) isIncludeSmallImg = "no";
            }
            string isValid = "all";

            if (rdoIsValidYes.Checked) isValid = "yes";

            if (rdoIsValidNo.Checked) isValid = "no";

            backURL = XYECOM.Core.Utils.JSEscape("../Global/AttachmentManage.aspx?page=" + Page1.CurPage.ToString() +
                "&DescTabName=" + selInfoType.Value +
                "&isIncludeSmallImg=" + isIncludeSmallImg +
                "&imgFormat=" + rdolstImgFormat.SelectedValue +
                "&fileFormat=" + rdolstFileFormat.SelectedValue +
                "&attBody=" + attBody +
                "&isValid=" + isValid +
                "&beginDate=" + txtStartTime.Value +
                "&endDate=" + txtEndTime.Value
                );

            string strWhere = "1=1 ";

            if (!selInfoType.Value.Equals("all"))
                strWhere += "and DescTabName='" + selInfoType.Value + "' ";

            if (rdoIsIncludeSmallImgYes.Checked)
                strWhere += "and at_index =1 ";

            if (rdoIsIncludeSmallImgNo.Checked)
                strWhere += "and at_index  <> 1 ";

            if (attBody.Equals("image"))
            {
                if (!rdolstImgFormat.SelectedValue.Equals("all"))
                    strWhere += "and at_fileformat = '" + rdolstImgFormat.SelectedValue + "' ";
                else
                    strWhere += "and at_filetype = 'image' ";
            }
            else
            {
                if (!rdolstFileFormat.SelectedValue.Equals("all"))
                    strWhere += "and at_fileformat = '" + rdolstFileFormat.SelectedValue + "' ";
                else
                    strWhere += "and at_filetype = 'file' ";
            }

            if (!txtStartTime.Value.Equals(""))
                strWhere += "and at_pulishdate>='" + txtStartTime.Value + "' ";

            if (!txtEndTime.Value.Equals(""))
                strWhere += "and at_pulishdate<='" + txtEndTime.Value + "' ";

            if (rdoIsValidYes.Checked)
                strWhere += "and desctabid>0 ";

            if (rdoIsValidNo.Checked)
                strWhere += "and desctabid <=0 ";

            int totalRecord = 0;

            DataTable dt = XYECOM.Business.Utils.GetPaginationData("xyv_Attachment", "at_id", "*", "at_id desc", strWhere, this.Page1.PageSize, this.Page1.CurPage, out totalRecord);

            this.Page1.RecTotal = totalRecord;

            if (dt.Rows.Count > 0)
            {
                this.gvList.DataSource = dt;
                this.gvList.DataBind();
                this.lblMessage.Text = "";
            }
            else
            {
                this.gvList.DataBind();
                this.lblMessage.Text = "没有相关记录";
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindData();
        }

        #region 绑定序号
        protected void gvlist_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //判断是否数据行
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes.Add("onmouseover", "javascript:__XY_GV_Row_MouseOver(this)");
                e.Row.Attributes.Add("onmouseout", "javascript:__XY_GV_Row_MouseOut(this);");
            }
        }
        #endregion

        protected string IsValidate(string flag, string serverUrl, string atPath)
        {
            if (flag.Equals("-1") || flag.Equals("0")) return "<span style='color:#ff0000;'><b>×</b> </span>";

            if (GetUrlError(serverUrl + atPath) != 200) return "<span style='color:#f60;'><b>?</b> </span>";

            return "<span style='color:#669900;'><b>√<b></span>";
        }

        protected override string GetInfoUrl(string descTabName, string descTabId)
        {
            if (descTabId.Equals("0") || descTabId.Equals("-1")) return "--";

            if (descTabName.ToLower().Equals("b_friendlink")) return "--";

            descTabName = descTabName.Trim().ToLower();

            DataTable table = null;
            DataRow row = null;
            string url = "";

            string dataSourceName = GetDataSourceName(descTabName); ;

            if (dataSourceName.Equals("")) return "--";

            if (descTabName.Equals("i_supply") || descTabName.Equals("i_demand"))
            {
                table = XYECOM.Business.Utils.ExecuteTable(dataSourceName, "sd_flag,sd_title,moduleName", "sd_id=" + descTabId);

                if (table.Rows.Count <= 0) return "";

                row = table.Rows[0];

                url = GetInfoUrl(row["modulename"].ToString(), Core.MyConvert.GetInt64(descTabId), Core.MyConvert.GetInt32(row["sd_flag"].ToString()));

                return "<a href='" + url + "' target='_blank'>" + row["sd_title"].ToString() + "</a>";
            }

            if (descTabName.Equals("i_invitebusinessmaninfo"))
            {
                table = XYECOM.Business.Utils.ExecuteTable(dataSourceName, "ibi_sign,ibi_title,moduleName", "ibi_id=" + descTabId);

                if (table.Rows.Count <= 0) return "";

                row = table.Rows[0];

                url = GetInfoUrl(row["modulename"].ToString(), Core.MyConvert.GetInt64(descTabId), Core.MyConvert.GetInt32(row["ibi_sign"].ToString()));

                return "<a href='" + url + "' target='_blank'>" + row["ibi_title"].ToString() + "</a>";
            }

            if (descTabName.Equals("i_serviceinfo"))
            {
                table = XYECOM.Business.Utils.ExecuteTable(dataSourceName, "s_flag,s_title,moduleName", "s_id=" + descTabId);

                if (table.Rows.Count <= 0) return "";

                row = table.Rows[0];

                url = GetInfoUrl(row["modulename"].ToString(), Core.MyConvert.GetInt64(descTabId), Core.MyConvert.GetInt32(row["s_flag"].ToString()));

                return "<a href='" + url + "' target='_blank'>" + row["s_title"].ToString() + "</a>";
            }

            if (descTabName.Equals("i_showinfo"))
            {
                table = XYECOM.Business.Utils.ExecuteTable(dataSourceName, "infotitle", "id=" + descTabId);

                if (table.Rows.Count <= 0) return "";

                row = table.Rows[0];

                url = GetInfoUrl("exhibition", Core.MyConvert.GetInt64(descTabId), 0);

                return "<a href='" + url + "' target='_blank'>" + row["infotitle"].ToString() + "</a>";
            }

            if (descTabName.Equals("n_news"))
            {
                table = XYECOM.Business.Utils.ExecuteTable(dataSourceName, "ns_newsname", "ns_id=" + descTabId);

                if (table.Rows.Count <= 0) return "";

                row = table.Rows[0];

                url = GetInfoUrl("news", Core.MyConvert.GetInt64(descTabId), 0);

                return "<a href='" + url + "' target='_blank'>" + row["ns_newsname"].ToString() + "</a>";
            }

            if (descTabName.Equals("u_user"))
            {
                table = XYECOM.Business.Utils.ExecuteTable(dataSourceName, "ui_name,u_name", "u_id=" + descTabId);

                if (table.Rows.Count <= 0) return "";

                row = table.Rows[0];

                url = GetInfoUrl("user", Core.MyConvert.GetInt64(descTabId), 0);

                string linkText = row["ui_name"].ToString().Trim().Equals("") ? row["u_name"].ToString() : row["ui_name"].ToString();

                return "<a href='" + url + "&backUrl=" + backURL + "'>" + linkText + "</a>";
            }

            if (descTabName.Equals("u_individual"))
            {
                table = XYECOM.Business.Utils.ExecuteTable(dataSourceName, "ui_name,u_name", "u_id=" + descTabId);

                if (table.Rows.Count <= 0) return "";

                row = table.Rows[0];

                url = GetInfoUrl("individual", Core.MyConvert.GetInt64(descTabId), 0);

                string linkText = row["ui_name"].ToString().Trim().Equals("") ? row["u_name"].ToString() : row["ui_name"].ToString();

                return "<a href='" + url + "&backUrl=" + backURL + "'>" + linkText + "</a>";
            }

            if (descTabName.Equals("xy_topic"))
            {
                table = XYECOM.Business.Utils.ExecuteTable(dataSourceName, "cname", "id=" + descTabId);

                if (table.Rows.Count <= 0) return "";

                row = table.Rows[0];

                url = GetInfoUrl("topic", Core.MyConvert.GetInt64(descTabId), 0);

                return "<a href='" + url + "&backUrl=" + backURL + "'>" + row["cname"].ToString() + "</a>";
            }

            return "#";
        }

        private string GetInfoUrl(string moduleName, long infoId, int infoTypeId)
        {
            string url = webInfo.WebDomain + "search/{0}.aspx?flag={1}&infoid={2}";
            string bogusStaticUrl = webInfo.WebDomain + "search/{0}-{1}-{2}." + webInfo.WebSuffix;

            string exhUrl = webInfo.WebDomain + "exhibition/info." + webInfo.WebSuffix + "?infoid={0}";
            string bogusStaticExhUrl = webInfo.WebDomain + "exhibition/info-{0}." + webInfo.WebSuffix;

            string brandUrl = webInfo.WebDomain + "brand/info." + webInfo.WebSuffix + "?infoid={0}";
            string bogusStaticBrandUrl = webInfo.WebDomain + "brand/info-{0}." + webInfo.WebSuffix;

            string newsUrl = webInfo.WebDomain + "news/content." + webInfo.WebSuffix + "?ns_id={0}";
            string bogusStaticNewsUrl = webInfo.WebDomain + "news/content-{0}." + webInfo.WebSuffix;

            string userUrl = "../UserManage/UserInfo.aspx?U_ID={0}";

            string individualUrl = "../UserManage/IndividualInfo.aspx?U_ID={0}";

            string topicUrl = "../TopicManage/TopicInfo.aspx?id={0}";

            string strInfoType = "sell";

            XYECOM.Configuration.ModuleInfo module = moduleConfig.GetItem(moduleName);

            if (module != null)
            {
                List<XYECOM.Configuration.ModuleItemInfo> list = moduleConfig.GetItem(moduleName).Item;

                foreach (XYECOM.Configuration.ModuleItemInfo info in list)
                {
                    if (info.ID == infoTypeId)
                    {
                        if (info.InfoType == XYECOM.Configuration.InfoType.Sell)
                            strInfoType = "sell";
                        else
                            strInfoType = "buy";

                        break;
                    }
                }

                if (webInfo.IsBogusStatic)
                    return string.Format(bogusStaticUrl, strInfoType, moduleName, infoId);

                return string.Format(url, strInfoType, moduleName, infoId);
            }
            else
            {
                if (moduleName.Equals("exhibition"))
                {
                    if (webInfo.IsBogusStatic)
                        return string.Format(bogusStaticExhUrl, infoId);

                    return string.Format(exhUrl, infoId);
                }

                if (moduleName.Equals("brand"))
                {
                    if (webInfo.IsBogusStatic)
                        return string.Format(bogusStaticBrandUrl, infoId);

                    return string.Format(brandUrl, infoId);
                }

                if (moduleName.Equals("news"))
                {
                    if (webInfo.IsBogusStatic)
                        return string.Format(bogusStaticNewsUrl, infoId);

                    return string.Format(newsUrl, infoId);
                }

                if (moduleName.Equals("user"))
                {
                    return string.Format(userUrl, infoId);
                }

                if (moduleName.Equals("individual"))
                {
                    return string.Format(individualUrl, infoId);
                }

                if (moduleName.Equals("topic"))
                {
                    return string.Format(topicUrl, infoId);
                }
            }

            return "#";
        }

        private string GetDataSourceName(string descTabName)
        {
            descTabName = descTabName.Trim().ToLower();

            if (descTabName.Equals("i_supply")) return "xyv_supply";

            if (descTabName.Equals("i_demand")) return "xyv_demand";

            if (descTabName.Equals("i_invitebusinessmaninfo")) return "xyv_invitebusinessmaninfo";

            if (descTabName.Equals("i_serviceinfo")) return "xyv_ServiceInfo";

            if (descTabName.Equals("i_showinfo")) return "xyv_showinfo";

            if (descTabName.Equals("n_news")) return "xyv_News";

            if (descTabName.Equals("xy_topic")) return "xy_Topic";

            if (descTabName.Equals("u_user")) return "xyv_userinfo";

            if (descTabName.Equals("u_individual")) return "xyv_userinfo";

            return "";
        }

        #region 分页相关代码
        override protected void OnInit(EventArgs e)
        {
            this.Load += new System.EventHandler(this.Page_Load);
            this.Page1.PageChanged += new xymanage_UserControl_page.EventHandler(Page1_PageChanged);
            base.OnInit(e);
        }

        private void Page1_PageChanged(object sender, System.EventArgs e)
        {
            this.BindData();
        }
        #endregion

        protected void btnDeleteAllTemp_Click(object sender, EventArgs e)
        {
            Business.Attachment bll = new XYECOM.Business.Attachment();

            int result = bll.DeleteAllTemp();

            if (result > 0)
                Alert("共删除垃圾附件" + result + "条", "", true);
            else
                Alert("无垃圾附件", "", true);

            DataBind();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            XYECOM.Business.Attachment bll = new XYECOM.Business.Attachment();

            string ids = "";

            foreach (GridViewRow GR in this.gvList.Rows)
            {
                if (((CheckBox)(GR.FindControl("chkExport"))).Checked == true)
                {
                    ids += "," + this.gvList.DataKeys[GR.DataItemIndex].Value.ToString();
                }
            }

            if (ids.IndexOf(",") == 0)
            {
                ids = ids.Substring(1);
                int i = bll.Delete(ids);
                if (i >= 0)
                {
                    BindData();
                }
                else
                {
                    this.ClientScript.RegisterClientScriptBlock(GetType(), "01", "<script>sAlert(\"删除失败！\")</script>");
                }
            }
        }

        private int GetUrlError(string curl)
        {
            int num = 200;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(new Uri(curl));
            ServicePointManager.Expect100Continue = false;
            try
            {
                ((HttpWebResponse)request.GetResponse()).Close();
            }
            catch (WebException exception)
            {
                if (exception.Status != WebExceptionStatus.ProtocolError)
                {
                    return num;
                }
                if (exception.Message.IndexOf("500 ") > 0)
                {
                    return 500;
                }
                if (exception.Message.IndexOf("401 ") > 0)
                {
                    return 401;
                }
                if (exception.Message.IndexOf("404") > 0)
                {
                    num = 404;
                }
            }
            return num;
        }
    }
}
