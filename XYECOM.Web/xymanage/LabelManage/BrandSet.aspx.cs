﻿using System;
using System.Web.UI.WebControls;
using XYECOM.Core;

public partial class xymanage_LabelManage_BrandSet : XYECOM.Web.BasePage.LabelBasePage
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
            
            //this.Button1.Attributes.Add("onclick", "javascript:return labelvalidate(1);");
            this.ddlorderColumuName.Items.Add(new ListItem("自动编号", "B_ID"));
            this.ddlorderColumuName.Items.Add(new ListItem("发布时间", "addtime"));
            this.ddlorderColumuName.Items.Add(new ListItem("点击次数", "B_ClickNum"));

            this.ddlpageorder.Items.Add(new ListItem("自动编号", "B_ID"));
            this.ddlpageorder.Items.Add(new ListItem("发布时间", "addtime"));
            this.ddlpageorder.Items.Add(new ListItem("点击次数", "B_ClickNum"));

            this.hidweburl.Value = webInfo.WebDomain;
            this.hidsuffix.Value = webInfo.WebSuffix;
            this.moduleflag.Value = "brand";
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        string str = "";

        string byUserGradeOrder = "1";
        if (!chkUserGradeOrder.Checked) byUserGradeOrder = "0";

        str += XYECOM.Core.Utils.LableSet(Function.LabelPrefix.Remove(Function.LabelPrefix.Length - 1, 1), "BrandList").Substring(1);
        str += XYECOM.Core.Utils.LableSet("信息类别", hidptid.Value.Trim());
        str += XYECOM.Core.Utils.LableSet("调用数量", tbnum.Text.Trim());
        str += XYECOM.Core.Utils.LableSet("标题字数", tbtitlenum.Text.Trim());
        str += XYECOM.Core.Utils.LableSet("点击次数", tbclicknum.Text.Trim());
        str += XYECOM.Core.Utils.LableSet("排序字段", ddlorderColumuName.SelectedValue);
        str += XYECOM.Core.Utils.LableSet("排序方式", ddlorder.SelectedValue);
        str += XYECOM.Core.Utils.LableSet("优先以会员等级排序", byUserGradeOrder);
        str += XYECOM.Core.Utils.LableSet("日期格式", ddldatetype.SelectedValue);
        str += XYECOM.Core.Utils.LableSet("品牌描述显示字数", tbinfonum.Text.Trim());
        str += XYECOM.Core.Utils.LableSet("公司名称字数", tbcorporationNum.Text.Trim());
        str += XYECOM.Core.Utils.LableSet("是否推荐", this.ddlCommend.SelectedValue);
        str += XYECOM.Core.Utils.LableSet("是否显示缩略图", this.ddlimg.SelectedValue);
        this.ClientScript.RegisterClientScriptBlock(GetType(), "", "<script type=\"text/javascript\">parent.setLabelValue(\"" + str + "\");//window.returnValue=\"" + str + "\"; window.close();</" + "" + "script>");
    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        string str = "";

        str += XYECOM.Core.Utils.LableSet(Function.LabelPrefix.Remove(Function.LabelPrefix.Length - 1, 1), "BrandPageList").Substring(1);
        str += XYECOM.Core.Utils.LableSet("调用数量", tbpagenum.Text.Trim());
        str += XYECOM.Core.Utils.LableSet("标题字数", tbpagetitlenum.Text.Trim());
        str += XYECOM.Core.Utils.LableSet("排序字段", ddlpageorder.SelectedValue);
        str += XYECOM.Core.Utils.LableSet("排序方式", ddlpagedesc.SelectedValue);
        str += XYECOM.Core.Utils.LableSet("日期格式", ddlpagedatetype.SelectedValue);
        str += XYECOM.Core.Utils.LableSet("品牌描述显示字数", tbpageproductnum.Text.Trim());
        str += XYECOM.Core.Utils.LableSet("公司名称字数", tbpagecorporationnum.Text.Trim());

        this.ClientScript.RegisterClientScriptBlock(GetType(), "", "<script type=\"text/javascript\">parent.setLabelValue(\"" + str + "\");//window.returnValue=\"" + str + "\"; window.close();</" + "" + "script>");
    }

    protected override void InitPageValue(XYECOM.Web.BasePage.MyDictionary table)
    {
        string type = table["XY"].ToLower();
        if ("BrandPageList".ToLower() == type)
        {
            this.tbpagenum.Text = table["调用数量"];
            this.tbpagetitlenum.Text = table["标题字数"];
            this.ddlpageorder.SelectedValue = table["排序字段"];
            this.ddlpagedesc.SelectedValue = table["排序方式"];
            this.ddlpagedatetype.SelectedValue = table["日期格式"];
            this.tbpageproductnum.Text = table["品牌描述显示字数"];
            this.tbpagecorporationnum.Text = table["公司名称字数"];

            ClientScript.RegisterStartupScript(GetType(), "page", "myclick(\"li_page\",\"click\");", true);
        }
        if ("BrandList".ToLower() == type)
        {
            this.hidptid.Value = table["信息类别"];
            this.tbnum.Text = table["调用数量"];
            this.tbtitlenum.Text = table["标题字数"];
            this.tbclicknum.Text = table["点击次数"];
            this.ddlorderColumuName.SelectedValue = table["排序字段"];
            this.ddlorder.SelectedValue = table["排序方式"];            
            this.chkUserGradeOrder.Checked = (table["优先以会员等级排序"] == "1");
            this.ddldatetype.SelectedValue = table["日期格式"];            
            this.tbinfonum.Text = table["品牌描述显示字数"];            
            this.tbcorporationNum.Text = table["公司名称字数"];            
            this.ddlCommend.SelectedValue = table["是否推荐"];            
            this.ddlimg.SelectedValue = table["是否显示缩略图"];
            
            ClientScript.RegisterStartupScript(GetType(), "page", "myclick(\"li_base\",\"click\");", true);
        }
    }
}
