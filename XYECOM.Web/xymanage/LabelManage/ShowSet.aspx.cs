using System;
using XYECOM.Core;

public partial class xymanage_LabelManage_ShowSet : XYECOM.Web.BasePage.LabelBasePage
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
            this.Button1.Attributes.Add("onclick", "javascript:return labelvalidate(5);");

            this.hidweburl.Value = XYECOM.Configuration.WebInfo.Instance.WebDomain;
            this.hidsuffix.Value = XYECOM.Configuration.WebInfo.Instance.WebSuffix;
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        string str = "";
        String typeID = this.hidptid.Value.Trim();
        if(typeID.Equals("")){
            typeID = "0";
        }
        str += XYECOM.Core.Utils.LableSet(Function.LabelPrefix.Remove(Function.LabelPrefix.Length - 1, 1), "ShowList").Substring(1);
        str += XYECOM.Core.Utils.LableSet("信息类别", typeID);
        str += XYECOM.Core.Utils.LableSet("调用数量", tbnum.Text.Trim());
        str += XYECOM.Core.Utils.LableSet("标题字数", tbtitlenum.Text.Trim());
        str += XYECOM.Core.Utils.LableSet("排序字段", ddlOrderColumuName.SelectedValue);
        str += XYECOM.Core.Utils.LableSet("排序方式", ddlOrderType.SelectedValue);
        str += XYECOM.Core.Utils.LableSet("日期格式", ddldatetype.SelectedValue);
        str += XYECOM.Core.Utils.LableSet("信息描述字数", tbinfonum.Text.Trim());
        str += XYECOM.Core.Utils.LableSet("展会类型", ddlShowType.SelectedValue);
        str += XYECOM.Core.Utils.LableSet("是否推荐", this.ddlCommend.SelectedValue);
        str += XYECOM.Core.Utils.LableSet("是否包含图片", this.ddlimg.SelectedValue);
        this.ClientScript.RegisterClientScriptBlock(GetType(), "", "<script type=\"text/javascript\">parent.setLabelValue(\"" + str + "\");//window.returnValue=\"" + str + "\"; window.close();</" + "" + "script>");
    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        string str = "";
        str += XYECOM.Core.Utils.LableSet(Function.LabelPrefix.Remove(Function.LabelPrefix.Length - 1, 1), "ShowPageList").Substring(1);
        str += XYECOM.Core.Utils.LableSet("调用数量", tbpagenum.Text.Trim());
        str += XYECOM.Core.Utils.LableSet("标题字数", tbpagetitlenum.Text.Trim());
        str += XYECOM.Core.Utils.LableSet("排序字段", ddlPageOrderColumnName.SelectedValue);
        str += XYECOM.Core.Utils.LableSet("排序方式", ddlPageOrderType.SelectedValue);
        str += XYECOM.Core.Utils.LableSet("日期格式", ddlpagedatetype.SelectedValue);
        str += XYECOM.Core.Utils.LableSet("信息描述字数", tbpageproductnum.Text.Trim());

        this.ClientScript.RegisterClientScriptBlock(GetType(), "", "<script type=\"text/javascript\">parent.setLabelValue(\"" + str + "\");//window.returnValue=\"" + str + "\"; window.close();</" + "" + "script>");
    }
    protected override void InitPageValue(XYECOM.Web.BasePage.MyDictionary table)
    {
        string type = table["XY"].ToLower();
        if ("ShowList".ToLower() == type)
        {
            this.hidptid.Value = table["信息类别"];
            tbnum.Text = table["调用数量"];
            tbtitlenum.Text = table["标题字数"];
            ddlOrderColumuName.SelectedValue = table["排序字段"];
            ddlOrderType.SelectedValue = table["排序方式"];
            ddldatetype.SelectedValue = table["日期格式"];
            tbinfonum.Text = table["信息描述字数"];
            ddlShowType.SelectedValue = table["展会类型"];
            this.ddlCommend.SelectedValue = table["是否推荐"];
            this.ddlimg.SelectedValue = table["是否包含图片"];
            ClientScript.RegisterStartupScript(GetType(), "base", "myclick(\"li_base\",\"click\");", true);
        }
        if ("ShowPageList".ToLower() == type)
        {
            this.tbpagenum.Text = table["调用数量"];
            tbpagetitlenum.Text = table["标题字数"];
            ddlPageOrderColumnName.SelectedValue = table["排序字段"];
            ddlPageOrderType.SelectedValue = table["排序方式"];
            ddlpagedatetype.SelectedValue = table["日期格式"];
            tbpageproductnum.Text = table["信息描述字数"];
            ClientScript.RegisterStartupScript(GetType(), "page", "myclick(\"li_page\",\"click\");", true);

        }
    }
}
