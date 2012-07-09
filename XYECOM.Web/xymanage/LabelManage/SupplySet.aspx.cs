using System;
using System.Data;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using XYECOM.Core;

public partial class xymanage_LabelManage_SupplySet : XYECOM.Web.BasePage.LabelBasePage
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

            this.Button1.Attributes.Add("onclick", "javascript:return labelvalidate(1);");

            this.ddlorderColumuName.Items.Add(new ListItem("自动编号", "SD_ID"));
            this.ddlorderColumuName.Items.Add(new ListItem("发布时间", "SD_PublishDate"));
            this.ddlorderColumuName.Items.Add(new ListItem("点击次数", "SD_ClickNum"));

            this.ddlpageorder.Items.Add(new ListItem("自动编号", "SD_ID"));
            this.ddlpageorder.Items.Add(new ListItem("发布时间", "SD_PublishDate"));
            this.ddlpageorder.Items.Add(new ListItem("点击次数", "SD_ClickNum"));


            BindModuleItemInfo("offer");

            BindRankList();
            this.customType.Visible = (LabelUserId > 0);
            this.moduleflag.Value = "offer";
        }
    }

    void xymanage_LabelManage_SupplySet_MyText(object sender, EventArgs e)
    {

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

    private void BindRankList()
    {
        BindRankList(ddlRankList);
    }

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

    #region 绑定下拉控件数据
    protected void ddlBind()
    {
        DataTable table = moduleConfig.GetItem("offer").ToTables;
        foreach (DataRow row in table.Rows)
        {
            ddlmodul.Items.Add(new ListItem(row["CName"].ToString(), row["EName"].ToString()));
        }
    }
    #endregion

    #region 分页类表
    protected void Button3_Click(object sender, EventArgs e)
    {
        string str = "";
        str += XYECOM.Core.Utils.LableSet(Function.LabelPrefix.Remove(Function.LabelPrefix.Length - 1, 1), "SupplyPageList").Substring(1);
        str += XYECOM.Core.Utils.LableSet("调用数量", tbpagenum.Text.Trim());
        str += XYECOM.Core.Utils.LableSet("标题字数", tbpagetitlenum.Text.Trim());
        str += XYECOM.Core.Utils.LableSet("排序字段", ddlpageorder.SelectedValue);
        str += XYECOM.Core.Utils.LableSet("排序方式", ddlpagedesc.SelectedValue);
        str += XYECOM.Core.Utils.LableSet("日期格式", ddlpagedatetype.SelectedValue);
        str += XYECOM.Core.Utils.LableSet("信息描述字数", tbpageproductnum.Text.Trim());
        str += XYECOM.Core.Utils.LableSet("公司名称字数", tbpagecorporationnum.Text.Trim());
        str += XYECOM.Core.Utils.LableSet("是否参与合同保障", this.ddlIsContractPage.SelectedValue);
        str += XYECOM.Core.Utils.LableSet("是否参与产品保障", this.ddlIsPayBailPage.SelectedValue);

        this.ClientScript.RegisterClientScriptBlock(GetType(), "", "<script type=\"text/javascript\">parent.setLabelValue(\"" + str + "\");//window.returnValue=\"" + str + "\"; window.close();</" + "" + "script>");
    }
    #endregion

    #region 关键字竞价列表
    protected void Button5_Click(object sender, EventArgs e)
    {
        string str = "";
        str += XYECOM.Core.Utils.LableSet(Function.LabelPrefix.Remove(Function.LabelPrefix.Length - 1, 1), "SupplyKeyPageList").Substring(1);
        str += XYECOM.Core.Utils.LableSet("显示名次", ddlRankList.SelectedValue);
        str += XYECOM.Core.Utils.LableSet("标题字数", tbkeytitlenum.Text.Trim());
        str += XYECOM.Core.Utils.LableSet("日期格式", ddlkeydatetype.SelectedValue);
        str += XYECOM.Core.Utils.LableSet("信息描述字数", tbkeycontentnum.Text.Trim());
        str += XYECOM.Core.Utils.LableSet("公司名称字数", tbkeycompanynum.Text.Trim());
        str += XYECOM.Core.Utils.LableSet("是否参与合同保障", this.ddlIsContractKey.SelectedValue);
        str += XYECOM.Core.Utils.LableSet("是否参与产品保障", this.ddlIsPayBailKey.SelectedValue);

        this.ClientScript.RegisterClientScriptBlock(GetType(), "", "<script type=\"text/javascript\">parent.setLabelValue(\"" + str + "\");//window.returnValue=\"" + str + "\"; window.close();</" + "" + "script>");
    }
    #endregion

    #region 基本列表
    protected void Button1_Click(object sender, EventArgs e)
    {
        string str = "";

        string typeId = hidTypeID.Value.Trim();
        if (typeId.Equals("")) typeId = "0";

        string companytypeid = this.ctid.Value.Trim();
        if ("".Equals(companytypeid)) companytypeid = "0";

        string byUserGradeOrder = "1";
        if (!chkUserGradeOrder.Checked) byUserGradeOrder = "0";

        str += XYECOM.Core.Utils.LableSet(Function.LabelPrefix.Remove(Function.LabelPrefix.Length - 1, 1), "SupplyList").Substring(1);
        str += XYECOM.Core.Utils.LableSet("信息类别", moduleflag.Value.Trim() + ":" + typeId);
        str += XYECOM.Core.Utils.LableSet("用户自定义分类编号", companytypeid);
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
        str += XYECOM.Core.Utils.LableSet("是否参与合同保障", this.ddlIsContract.SelectedValue);
        str += XYECOM.Core.Utils.LableSet("是否参与产品保障", this.ddlIsPayBail.SelectedValue);
        str += XYECOM.Core.Utils.LableSet("信息类型", this.ddltype.SelectedValue);
        this.ClientScript.RegisterClientScriptBlock(GetType(), "", "<script type=\"text/javascript\">parent.setLabelValue(\"" + str + "\");//window.returnValue=\"" + str + "\"; window.close();</" + "" + "script>");
    }
    #endregion

    protected override void InitPageValue(XYECOM.Web.BasePage.MyDictionary table)
    {
        string type = table["XY"].ToLower();
        #region 分页
        if ("SupplyPageList".ToLower() == type)
        {
            this.tbpagenum.Text = table["调用数量"];
            this.tbpagetitlenum.Text = table["标题字数"];
            this.ddlpageorder.SelectedValue = table["排序字段"];
            this.ddlpagedesc.SelectedValue = table["排序方式"];
            this.ddlpagedatetype.SelectedValue = table["日期格式"];
            this.tbpageproductnum.Text = table["信息描述字数"];
            this.tbpagecorporationnum.Text = table["公司名称字数"];
            this.ddlIsContractPage.SelectedValue = table["是否参与合同保障"];
            this.ddlIsPayBailPage.SelectedValue = table["是否参与产品保障"];

            ClientScript.RegisterStartupScript(GetType(), "page", "myclick(\"li_page\",\"click\");", true);
        }
        #endregion
        #region 基本
        if ("SupplyList".ToLower() == type)
        {
            string[] arrs = table["信息类别"].Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
            if (arrs.Length == 2)
            {
                this.moduleflag.Value = arrs[0];
                this.hidTypeID.Value = arrs[1];
            }
            this.tbnum.Text = table["调用数量"];
            this.tbtitlenum.Text = table["标题字数"];
            this.tbclicknum.Text = table["点击次数"];
            this.ddlorderColumuName.SelectedValue = table["排序字段"];
            this.ddlorder.SelectedValue = table["排序方式"];
            this.chkUserGradeOrder.Checked = (table["优先以会员等级排序"] == "1");
            this.ddldatetype.SelectedValue = table["日期格式"];
            this.tbinfonum.Text = table["信息描述字数"];
            this.tbcorporationNum.Text = table["公司名称字数"];
            this.ddlCommend.SelectedValue = table["是否推荐"];
            this.ddlimg.SelectedValue = table["是否显示缩略图"];
            this.ddlIsContract.SelectedValue = table["是否参与合同保障"];
            this.ddlIsPayBail.SelectedValue = table["是否参与产品保障"];
            this.ddltype.SelectedValue = table["信息类型"];

            ClientScript.RegisterStartupScript(GetType(), "page", "myclick(\"li_base\",\"click\");", true);
        }
        #endregion
        #region 关键字竞价
        if ("SupplyKeyPageList".ToLower() == type)
        {
            this.ddlRankList.SelectedValue = table["显示名次"];
            this.tbkeytitlenum.Text = table["标题字数"];
            this.ddlkeydatetype.SelectedValue = table["日期格式"];
            this.tbkeycontentnum.Text = table["信息描述字数"];
            this.tbkeycompanynum.Text = table["公司名称字数"];
            this.ddlIsContractKey.SelectedValue = table["是否参与合同保障"];
            this.ddlIsPayBailKey.SelectedValue = table["是否参与产品保障"];
            ClientScript.RegisterStartupScript(GetType(), "page", "myclick(\"li_key\",\"click\");", true);
        }
        #endregion
    }
}
