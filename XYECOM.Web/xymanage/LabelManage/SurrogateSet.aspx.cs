using System;
using System.Data;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using XYECOM.Core;

public partial class xymanage_LabelManage_SurrogateSet : XYECOM.Web.BasePage.LabelBasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //防止调用页面缓存
        Response.Buffer = true;
        Response.ExpiresAbsolute = System.DateTime.Now.AddSeconds(-1);
        Response.Expires = 0;
        Response.CacheControl = "no-cache";

        CheckRole("label");

        if (!IsPostBack)
        {
            ddlBind();
            this.Button1.Attributes.Add("onclick", "javascript:return labelvalidate(4);");

            this.ddlorderColumuName.Items.Add(new ListItem("自动编号", "S_ID"));
            this.ddlorderColumuName.Items.Add(new ListItem("发布时间", "S_AddTime"));
            this.ddlorderColumuName.Items.Add(new ListItem("点击次数", "S_ClickNum"));

            this.ddlpageorder.Items.Add(new ListItem("自动编号", "S_ID"));
            this.ddlpageorder.Items.Add(new ListItem("发布时间", "S_AddTime"));
            this.ddlpageorder.Items.Add(new ListItem("点击次数", "S_ClickNum"));

            BindModuleItemInfo("service");

            BindRankList();

            this.moduleflag.Value = "service";
        }
    }

    private void BindRankList()
    {
        BindRankList(ddlRankList);
    }

    private void BindModuleItemInfo(string moduleName)
    {
        List<XYECOM.Configuration.ModuleItemInfo> items = XYECOM.Configuration.Module.Instance.GetItem(moduleName).Item;

        this.ddltype.Items.Clear();
        foreach (XYECOM.Configuration.ModuleItemInfo info in items)
        {
            if (info.ID != 0)
                ddltype.Items.Add(new ListItem(info.Prefix + info.Postfix, info.ID.ToString()));
        }
        ddltype.Items.Insert(0, new ListItem("所有信息", "0"));
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        string str = "";
        String typeID = this.hidTypeID.Value.Trim();
        if (typeID.Equals(""))
        {
            typeID = "0";
        }

        string byUserGradeOrder = "1";
        if (!chkUserGradeOrder.Checked) byUserGradeOrder = "0";

        str += XYECOM.Core.Utils.LableSet(Function.LabelPrefix.Remove(Function.LabelPrefix.Length - 1, 1), "SurrogateList").Substring(1);
        str += XYECOM.Core.Utils.LableSet("信息类别", moduleflag.Value + ":" + typeID);
        str += XYECOM.Core.Utils.LableSet("调用数量", tbnum.Text.Trim());
        str += XYECOM.Core.Utils.LableSet("标题字数", tbtitlenum.Text.Trim());
        str += XYECOM.Core.Utils.LableSet("点击次数", tbclicknum.Text.Trim());
        str += XYECOM.Core.Utils.LableSet("排序字段", ddlorderColumuName.SelectedValue);
        str += XYECOM.Core.Utils.LableSet("排序方式", ddlorder.SelectedValue);
        str += XYECOM.Core.Utils.LableSet("优先以会员等级排序", byUserGradeOrder);
        str += XYECOM.Core.Utils.LableSet("日期格式", ddldatetype.SelectedValue);
        str += XYECOM.Core.Utils.LableSet("信息描述字数", tbinfonum.Text.Trim());
        str += XYECOM.Core.Utils.LableSet("公司名称字数", tbcorporationNum.Text.Trim());
        str += XYECOM.Core.Utils.LableSet("是否推荐", this.ddlCommend.SelectedValue);
        str += XYECOM.Core.Utils.LableSet("是否显示缩略图", this.ddlimg.SelectedValue);
        str += XYECOM.Core.Utils.LableSet("信息类型", this.ddltype.SelectedValue);
        this.ClientScript.RegisterClientScriptBlock(GetType(), "", "<script type=\"text/javascript\">parent.setLabelValue(\"" + str + "\");//window.returnValue=\"" + str + "\"; window.close();</" + "" + "script>");
    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        string str = "";
        str += XYECOM.Core.Utils.LableSet(Function.LabelPrefix.Remove(Function.LabelPrefix.Length - 1, 1), "SurrogatePageList").Substring(1);
        str += XYECOM.Core.Utils.LableSet("调用数量", tbpagenum.Text.Trim());
        str += XYECOM.Core.Utils.LableSet("标题字数", tbpagetitlenum.Text.Trim());
        str += XYECOM.Core.Utils.LableSet("排序字段", ddlpageorder.SelectedValue);
        str += XYECOM.Core.Utils.LableSet("排序方式", ddlpagedesc.SelectedValue);
        str += XYECOM.Core.Utils.LableSet("日期格式", ddlpagedatetype.SelectedValue);
        str += XYECOM.Core.Utils.LableSet("信息描述字数", tbpageproductnum.Text.Trim());
        str += XYECOM.Core.Utils.LableSet("公司名称字数", tbpagecorporationnum.Text.Trim());
        this.ClientScript.RegisterClientScriptBlock(GetType(), "", "<script type=\"text/javascript\">parent.setLabelValue(\"" + str + "\");//window.returnValue=\"" + str + "\"; window.close();</" + "" + "script>");
    }

    #region 关键词竞价列表
    protected void Button5_Click(object sender, EventArgs e)
    {
        string str = "";
        str += XYECOM.Core.Utils.LableSet(Function.LabelPrefix.Remove(Function.LabelPrefix.Length - 1, 1), "ServiceKeyPageList").Substring(1);
        str += XYECOM.Core.Utils.LableSet("显示名次", ddlRankList.SelectedValue);
        str += XYECOM.Core.Utils.LableSet("标题字数", tbkeytitlenum.Text.Trim());
        str += XYECOM.Core.Utils.LableSet("日期格式", ddlkeydatetype.SelectedValue);
        str += XYECOM.Core.Utils.LableSet("信息描述字数", tbkeycontentnum.Text.Trim());
        str += XYECOM.Core.Utils.LableSet("公司名称字数", tbkeycompanynum.Text.Trim());

        this.ClientScript.RegisterClientScriptBlock(GetType(), "", "<script type=\"text/javascript\">parent.setLabelValue(\"" + str + "\");//window.returnValue=\"" + str + "\"; window.close();</" + "" + "script>");
    }
    #endregion

    #region 绑定下拉控件数据
    protected void ddlBind()
    {
        DataTable table = moduleConfig.GetItem("service").ToTables;
        foreach (DataRow row in table.Rows)
        {
            ddlmodul.Items.Add(new ListItem(row["CName"].ToString(), row["EName"].ToString()));
        }

    }
    #endregion

    protected void ddlmodul_SelectedIndexChanged(object sender, EventArgs e)
    {
        string moduleName = this.ddlmodul.SelectedValue;
        if (!String.IsNullOrEmpty(moduleName) && !moduleName.Equals(""))
        {
            BindModuleItemInfo(moduleName);

            this.moduleflag.Value = moduleName;

            this.hidTypeID.Value = "0";
        }
    }

    protected override void InitPageValue(XYECOM.Web.BasePage.MyDictionary table)
    {
        string type = table["XY"].ToLower();
        if ("SurrogatePageList".ToLower() == type)
        {
            this.tbpagenum.Text = table["调用数量"];
            this.tbpagetitlenum.Text = table["标题字数"];
            this.ddlpageorder.SelectedValue = table["排序字段"];
            this.ddlpagedesc.SelectedValue = table["排序方式"];
            this.ddlpagedatetype.SelectedValue = table["日期格式"];
            this.tbpageproductnum.Text = table["信息描述字数"];
            this.tbpagecorporationnum.Text = table["公司名称字数"];

            ClientScript.RegisterStartupScript(GetType(), "page", "myclick(\"li_page\",\"click\");", true);
        }
        if ("SurrogateList".ToLower() == type)
        {
            string[] arrs = table["信息类别"].Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
            if (arrs.Length == 2)
            {
                this.moduleflag.Value = arrs[0];
                this.hidTypeID.Value = arrs[1];
            }
            this.chkUserGradeOrder.Checked = (table["优先以会员等级排序"] == "1");

            this.tbnum.Text = table["调用数量"];
            this.tbtitlenum.Text = table["标题字数"];
            this.tbclicknum.Text = table["点击次数"];
            this.ddlorderColumuName.SelectedValue = table["排序字段"];
            this.ddlorder.SelectedValue = table["排序方式"];

            this.ddldatetype.SelectedValue = table["日期格式"];
            this.tbinfonum.Text = table["信息描述字数"];
            this.tbcorporationNum.Text = table["公司名称字数"];
            this.ddlCommend.SelectedValue = table["是否推荐"];
            this.ddlimg.SelectedValue = table["是否显示缩略图"];
            this.ddltype.SelectedValue = table["信息类型"];

            ClientScript.RegisterStartupScript(GetType(), "page", "myclick(\"li_base\",\"click\");", true);
        }
        if ("ServiceKeyPageList".ToLower() == type)
        {
            this.ddlRankList.SelectedValue = table["显示名次"];
            this.tbkeytitlenum.Text = table["标题字数"];
            this.ddlkeydatetype.SelectedValue = table["日期格式"];
            this.tbkeycontentnum.Text = table["信息描述字数"];
            this.tbkeycompanynum.Text = table["公司名称字数"];

            ClientScript.RegisterStartupScript(GetType(), "page", "myclick(\"li_key\",\"click\");", true);
        }
    }
}
