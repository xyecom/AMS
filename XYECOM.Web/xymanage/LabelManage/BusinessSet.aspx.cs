using System;
using System.Data;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using XYECOM.Core;

public partial class xymanage_LabelManage_BusinessSet : XYECOM.Web.BasePage.LabelBasePage
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
            this.Button1.Attributes.Add("onclick", "javascript:return labelvalidate(3);");
            this.ddlorderColumuName.Items.Add(new ListItem("自动编号", "IBI_ID"));
            this.ddlorderColumuName.Items.Add(new ListItem("发布时间", "IBI_PublishDate"));
            this.ddlorderColumuName.Items.Add(new ListItem("点击次数", "IBI_ClickNum"));

            this.ddlpageorder.Items.Add(new ListItem("自动编号", "IBI_ID"));
            this.ddlpageorder.Items.Add(new ListItem("发布时间", "IBI_PublishDate"));
            this.ddlpageorder.Items.Add(new ListItem("点击次数", "IBI_ClickNum"));

            BindModuleItemInfo("investment");

            BindRankList();

            this.moduleflag.Value = "investment";
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

    #region 基本列表
    protected void Button1_Click(object sender, EventArgs e)
    {
        string str = "";
        String typeID = this.hidTypeID.Value.Trim();
        if(typeID.Equals("")){
            typeID = "0";
        }
        
        string byUserGradeOrder = "1";
        if (!chkUserGradeOrder.Checked) byUserGradeOrder = "0";

        str += XYECOM.Core.Utils.LableSet(Function.LabelPrefix.Remove(Function.LabelPrefix.Length - 1, 1), "BusinessList").Substring(1);
        str += XYECOM.Core.Utils.LableSet("信息类别", moduleflag.Value + ":" + typeID);
        str += XYECOM.Core.Utils.LableSet("调用数量", tbnum.Text.Trim());
        str += XYECOM.Core.Utils.LableSet("标题字数", tbtitlenum.Text.Trim());
        str += XYECOM.Core.Utils.LableSet("点击次数", tbclicknum.Text.Trim());
        str += XYECOM.Core.Utils.LableSet("排序字段", ddlorderColumuName.SelectedValue);
        str += XYECOM.Core.Utils.LableSet("排序方式", ddlorder.SelectedValue);
        str += XYECOM.Core.Utils.LableSet("优先以会员等级排序", byUserGradeOrder);
        str += XYECOM.Core.Utils.LableSet("日期格式", ddldatetype.SelectedValue);;
        str += XYECOM.Core.Utils.LableSet("信息描述显示字数", tbinfonum.Text.Trim());
        str += XYECOM.Core.Utils.LableSet("公司名称字数", tbcorporationNum.Text.Trim());
        str += XYECOM.Core.Utils.LableSet("是否推荐", this.ddlCommend.SelectedValue);
        str += XYECOM.Core.Utils.LableSet("是否显示缩略图", this.ddlimg.SelectedValue);
        str += XYECOM.Core.Utils.LableSet("信息类型", this.ddltype.SelectedValue);
        this.ClientScript.RegisterClientScriptBlock(GetType(), "", "<script type=\"text/javascript\">parent.setLabelValue(\"" + str + "\");//window.returnValue=\"" + str + "\"; window.close();</" + "" + "script>");
    }
    #endregion

    #region 分页列表
    protected void Button3_Click(object sender, EventArgs e)
    {
        string str = "";

        str += XYECOM.Core.Utils.LableSet(Function.LabelPrefix.Remove(Function.LabelPrefix.Length - 1, 1), "BusinessPageList").Substring(1);
        str += XYECOM.Core.Utils.LableSet("调用数量", tbpagenum.Text.Trim());
        str += XYECOM.Core.Utils.LableSet("标题字数", tbpagetitlenum.Text.Trim());
        str += XYECOM.Core.Utils.LableSet("排序字段", ddlpageorder.SelectedValue);
        str += XYECOM.Core.Utils.LableSet("排序方式", ddlpagedesc.SelectedValue);
        str += XYECOM.Core.Utils.LableSet("日期格式", ddlpagedatetype.SelectedValue);
        str += XYECOM.Core.Utils.LableSet("信息描述字数", tbpageproductnum.Text.Trim());
        str += XYECOM.Core.Utils.LableSet("公司名称字数", tbpagecorporationnum.Text.Trim());

        this.ClientScript.RegisterClientScriptBlock(GetType(), "", "<script type=\"text/javascript\">parent.setLabelValue(\"" + str + "\");//window.returnValue=\"" + str + "\"; window.close();</" + "" + "script>");
    }
    #endregion
    #region 关键词竞价列表
    protected void Button5_Click(object sender, EventArgs e)
    {
        string str = "";
        str += XYECOM.Core.Utils.LableSet(Function.LabelPrefix.Remove(Function.LabelPrefix.Length - 1, 1), "InvestmentKeyPageList").Substring(1);
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
        DataTable table = moduleConfig.GetItem("investment").ToTables;
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
        if ("BusinessList".ToLower() == type)
        {   
            string s = table["信息类别"];
            string[] arr = s.Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
            if (arr.Length == 2) 
            {
                this.moduleflag.Value = arr[0];
                this.hidTypeID.Value = arr[1];
            }

            tbnum.Text = table["调用数量"];
            tbtitlenum.Text = table["标题字数"];
            tbclicknum.Text = table["点击次数"];
            ddlorderColumuName.SelectedValue = table["排序字段"];
            ddlorder.SelectedValue = table["排序方式"];

            chkUserGradeOrder.Checked = (table["优先以会员等级排序"] == "1");

            ddldatetype.SelectedValue = table["日期格式"];
            tbinfonum.Text = table["信息描述显示字数"];
            tbcorporationNum.Text = table["公司名称字数"];
            this.ddlCommend.SelectedValue = table["是否推荐"];
            this.ddlimg.SelectedValue = table["是否显示缩略图"];
            this.ddltype.SelectedValue = table["信息类型"];
            ClientScript.RegisterStartupScript(GetType(), "base", "myclick(\"li_base\",\"click\");", true);
        }
        if ("BusinessPageList".ToLower() == type)
        {
            tbpagenum.Text = table["调用数量"];
            tbpagetitlenum.Text = table["标题字数"];
            ddlpageorder.SelectedValue = table["排序字段"];
            ddlpagedesc.SelectedValue = table["排序方式"];
            ddlpagedatetype.SelectedValue = table["日期格式"];
            tbpageproductnum.Text = table["信息描述字数"];
            tbpagecorporationnum.Text = table["公司名称字数"];
            ClientScript.RegisterStartupScript(GetType(), "base", "myclick(\"li_page\",\"click\");", true);
        }
        if ("InvestmentKeyPageList".ToLower() == type)
        {
            ddlRankList.SelectedValue = table["显示名次"];
            tbkeytitlenum.Text = table["标题字数"];
            ddlkeydatetype.SelectedValue = table["日期格式"];
            tbkeycontentnum.Text = table["信息描述字数"];
            tbkeycompanynum.Text = table["公司名称字数"];
            ClientScript.RegisterStartupScript(GetType(), "base", "myclick(\"li_key\",\"click\");", true);
        }
    }

}
