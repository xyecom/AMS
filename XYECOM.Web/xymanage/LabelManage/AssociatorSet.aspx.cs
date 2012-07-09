using System;
using System.Web.UI.WebControls;
using XYECOM.Core;

public partial class xymanage_LabelManage_AssociatorSet : XYECOM.Web.BasePage.LabelBasePage
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
            
            //this.Button1.Attributes.Add("onclick", "javascript:return labelvalidate(3);");
            this.ddlorderColumuName.Items.Add(new ListItem("自动编号", "U_ID"));
            this.ddlorderColumuName.Items.Add(new ListItem("发布时间", "U_RegDate"));
            //this.ddlorderColumuName.Items.Add(new ListItem("点击次数", "U_ClickNum"));

            this.ddlpageorder.Items.Add(new ListItem("自动编号", "U_ID"));
            this.ddlpageorder.Items.Add(new ListItem("发布时间", "U_RegDate"));
            //this.ddlpageorder.Items.Add(new ListItem("点击次数", "U_ClickNum"));

        }
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        string str = "";

        str += XYECOM.Core.Utils.LableSet(Function.LabelPrefix.Remove(Function.LabelPrefix.Length - 1, 1), "AssociatorPageList").Substring(1);
        str += XYECOM.Core.Utils.LableSet("调用数量", tbpagenum.Text.Trim());
        str += XYECOM.Core.Utils.LableSet("排序字段", ddlpageorder.SelectedValue);
        str += XYECOM.Core.Utils.LableSet("排序方式", ddlpagedesc.SelectedValue);
        str += XYECOM.Core.Utils.LableSet("日期格式", ddlpagedatetype.SelectedValue);
        this.ClientScript.RegisterClientScriptBlock(GetType(), "", "<script type=\"text/javascript\">parent.setLabelValue(\"" + str + "\");//window.returnValue=\"" + str + "\"; window.close();</" + "" + "script>");
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        string str = "";

        str += XYECOM.Core.Utils.LableSet(Function.LabelPrefix.Remove(Function.LabelPrefix.Length - 1, 1), "AssociatorList").Substring(1);
        str += XYECOM.Core.Utils.LableSet("调用数量", tbnum.Text.Trim());
        //str += XYECOM.Core.Utils.LableSet("点击次数", tbclicknum.Text.Trim());
        str += XYECOM.Core.Utils.LableSet("排序字段", ddlorderColumuName.SelectedValue);
        str += XYECOM.Core.Utils.LableSet("排序方式", ddlorder.SelectedValue);
        str += XYECOM.Core.Utils.LableSet("日期格式", ddldatetype.SelectedValue);
        //str += XYECOM.Core.Utils.LableSet("是否推荐", this.ddlCommend.SelectedValue);
        this.ClientScript.RegisterClientScriptBlock(GetType(), "", "<script type=\"text/javascript\">parent.setLabelValue(\"" + str + "\");//window.returnValue=\"" + str + "\"; window.close();</" + "" + "script>");
    }

    protected override void InitPageValue(XYECOM.Web.BasePage.MyDictionary table)
    {
        string type = table["XY"].ToLower();
        if ("AssociatorList".ToLower() == type) 
        {
            this.tbnum.Text = table["调用数量"];
            this.ddlorderColumuName.SelectedValue = table["排序字段"];
            this.ddlorder.SelectedValue = table["排序方式"];
            this.ddldatetype.SelectedValue = table["日期格式"];

            ClientScript.RegisterStartupScript(GetType(), "page", "myclick(\"li_base\",\"click\");", true);
        }
        if ("AssociatorPageList".ToLower() == type) 
        {
            this.tbpagenum.Text = table["调用数量"];
            this.ddlpageorder.SelectedValue = table["排序字段"];
            this.ddlpagedesc.SelectedValue = table["排序方式"];
            this.ddlpagedatetype.SelectedValue = table["日期格式"];

            ClientScript.RegisterStartupScript(GetType(), "page", "myclick(\"li_page\",\"click\");", true);
        }
    }
}
