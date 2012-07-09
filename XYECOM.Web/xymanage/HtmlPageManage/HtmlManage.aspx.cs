using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;

namespace XYECOM.Web.xymanage.HtmlPageManage
{
    public partial class HtmlManage : XYECOM.Web.BasePage.ManagePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CheckRole("htmlpage");
            if (!IsPostBack)
            {
                PageInit();
            }
        }

        private void PageInit()
        {
            DefaultPage.DataSource = GetDefaultPageList();
            DefaultPage.DataBind();

            InfoPage.DataSource = GetInfoPageList();
            InfoPage.DataBind();
        }

        private DataTable GetDefaultPageList()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("PageName"));
            dt.Columns.Add(new DataColumn("PageModuleName"));
            dt.Columns.Add(new DataColumn("PageHttpURL"));
            dt.Columns.Add(new DataColumn("CreateTime"));

            AddDefaultPage(dt, "��վ��ҳ", "", "index." + webInfo.WebSuffix);
            AddDefaultPage(dt, "��ҵ��ҳ", "company", "company/index." + webInfo.WebSuffix);
            AddDefaultPage(dt, "��Ѷ��ҳ", "news", "news/index." + webInfo.WebSuffix);
            AddDefaultPage(dt, "�˲���ҳ", "job", "job/index." + webInfo.WebSuffix);
            AddDefaultPage(dt, "Ʒ����ҳ", "brand", "brand/index." + webInfo.WebSuffix);
            AddDefaultPage(dt, "չ����ҳ", "exhibition", "exhibition/index." + webInfo.WebSuffix);

            foreach (XYECOM.Configuration.ModuleInfo info in XYECOM.Configuration.Module.Instance.ModuleItems)
            {
                AddDefaultPage(dt, info.CName + "��ҳ", info.SEName, info.SEName + "/index." + webInfo.WebSuffix);
            }
            return dt;
        }

        private void AddDefaultPage(DataTable dt, string pageName, string pageModuleName, string pageHttpURL)
        {
            DataRow dr = dt.NewRow();
            dr["PageModuleName"] = pageModuleName;
            dr["PageName"] = pageName;
            dr["PageHttpURL"] = pageHttpURL;
            string ServerPath = Server.MapPath("/" + ("" == pageModuleName ? "" : pageModuleName + "/") + "index." + webInfo.StaticPageSuffix);
            if (XYECOM.Core.Utils.FileExists(ServerPath))
            {
                FileInfo fi = new FileInfo(ServerPath);
                dr["CreateTime"] = fi.LastWriteTime.ToString("yyyy-MM-dd") + " <a href=\"" + "/" + ("" == pageModuleName ? "index." + webInfo.StaticPageSuffix : pageModuleName + "/index." + webInfo.StaticPageSuffix) + "\" target=\"_blank\">Ԥ��</a>";
            }
            dt.Rows.Add(dr);
        }

        private DataTable GetInfoPageList()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("PageType"));
            dt.Columns.Add(new DataColumn("PageModuleName"));
            dt.Columns.Add(new DataColumn("PagePModuleName"));
            dt.Columns.Add(new DataColumn("PageName"));

            foreach (XYECOM.Configuration.ModuleInfo info in XYECOM.Configuration.Module.Instance.ModuleItems)
            {
                AddInfoPage(dt, "module", info.EName, info.PEName, info.CName + "����ҳ");
            }
            AddInfoPage(dt, "othermodule", "brand", "", "Ʒ����Ϣ����ҳ");
            AddInfoPage(dt, "othermodule", "job", "", "��Ƹ��Ϣ����ҳ");
            AddInfoPage(dt, "othermodule", "resume", "", "������Ϣ����ҳ");
            AddInfoPage(dt, "news", "news", "", "��Ѷ������ϸҳ");
            AddInfoPage(dt, "newstitle", "newstitle", "", "��Ѷ��Ŀ����ҳ");
            AddInfoPage(dt, "othermodule", "exhibition", "", "չ������ҳ");

            return dt;
        }

        private void AddInfoPage(DataTable dt, string pageType, string pageModuleName, string pagePModuleName, string pageName)
        {
            DataRow dr = dt.NewRow();
            dr["PageType"] = pageType;
            dr["PageModuleName"] = pageModuleName;
            dr["PagePModuleName"] = pagePModuleName;
            dr["PageName"] = pageName;
            dt.Rows.Add(dr);
        }

        protected void InfoPage_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {

            Literal cls = (Literal)e.Item.FindControl("ClassShow");
            HtmlInputHidden hidmoduleflag = (HtmlInputHidden)e.Item.FindControl("moduleflag");
            HtmlInputHidden hidClassID = (HtmlInputHidden)e.Item.FindControl("hidClassID");
            HtmlInputText tbbegintime = (HtmlInputText)e.Item.FindControl("tbBeginTime");
            HtmlInputText tbendtime = (HtmlInputText)e.Item.FindControl("tbEndTime");
            DataRowView dr = (DataRowView)e.Item.DataItem;

            tbbegintime.Attributes.Add("readonly", "readonly");
            tbendtime.Attributes.Add("readonly", "readonly");
            if ("newstitle" == dr["PageType"].ToString())
            {
                tbbegintime.Visible = false;
                tbendtime.Visible = false;
                Literal litspac = (Literal)e.Item.FindControl("litspac");
                litspac.Text = "";
                HtmlInputCheckBox cbnewonly = (HtmlInputCheckBox)e.Item.FindControl("newOnly");
                cbnewonly.Visible = false;
            }

            string modulename = dr["PagePModuleName"].ToString();
            if ("" == modulename)
            {
                modulename = dr["PageModuleName"].ToString();
            }

            if (!dr["PageModuleName"].ToString().Equals("resume"))
            {
                cls.Text = "<div id=\"classType" + e.Item.ItemIndex + "\" class=\"xy_select\"></div>\n";
                cls.Text += "<script type=\"text/javascript\">\n";
                cls.Text += "var cla" + e.Item.ItemIndex + " = new ClassType('cla" + e.Item.ItemIndex + "','" + hidmoduleflag.ClientID + "','classType" + e.Item.ItemIndex + "','" + hidClassID.ClientID + "')\n";
                cls.Text += "cla" + e.Item.ItemIndex + ".Init();\n";
                cls.Text += "</script>";
            }
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            SetHtmlList(false);
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            SetHtmlList(true);
        }

        private void SetHtmlList(bool isdel)
        {
            HtmlInputCheckBox cbSel;
            System.Web.UI.WebControls.Label lb;
            foreach (DataListItem item in DefaultPage.Items)
            {
                cbSel = (HtmlInputCheckBox)item.FindControl("cbSel");
                if (cbSel.Checked)
                {
                    XYECOM.Web.Html.HtmlInfo info = new XYECOM.Web.Html.HtmlInfo();
                    info.PageHttpURL = cbSel.Value.Trim();
                    lb = (System.Web.UI.WebControls.Label)item.FindControl("lbPageModule");
                    info.PageModule = lb.Text.Trim();
                    lb = (System.Web.UI.WebControls.Label)item.FindControl("lbPageName");
                    info.PageName = lb.Text.Trim();
                    info.PageType = "default";
                    info.IsDel = isdel;
                    XYECOM.Web.Html.HtmlManage.TaskList.Add(info);
                }
            }

            HtmlInputHidden hid;
            HtmlInputText txt;
            foreach (RepeaterItem item in InfoPage.Items)
            {
                cbSel = (HtmlInputCheckBox)item.FindControl("cbSel");
                if (cbSel.Checked)
                {
                    XYECOM.Web.Html.HtmlInfo info = new XYECOM.Web.Html.HtmlInfo();
                    info.PageType = cbSel.Value.Trim();

                    lb = (System.Web.UI.WebControls.Label)item.FindControl("lbPageName");
                    info.PageName = lb.Text.Trim();

                    hid = (HtmlInputHidden)item.FindControl("moduleflag");
                    info.PageModule = hid.Value.Trim();

                    hid = (HtmlInputHidden)item.FindControl("hidClassID");
                    info.PageClassID = hid.Value.Trim();

                    txt = (HtmlInputText)item.FindControl("tbBeginTime");
                    info.PageBeginTime = txt.Value.Trim();

                    txt = (HtmlInputText)item.FindControl("tbEndTime");
                    info.PageEndTime = txt.Value.Trim();

                    cbSel = (HtmlInputCheckBox)item.FindControl("newOnly");
                    info.NewOnly = cbSel.Checked;

                    info.IsDel = isdel;
                    XYECOM.Web.Html.HtmlManage.TaskList.Add(info);
                }
            }
            XYECOM.Web.Html.HtmlManage.Start();
            Response.Redirect("HtmlState.aspx");
        }
    }
}
