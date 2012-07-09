using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using XYECOM.Business;
using XYECOM.Core;

namespace XYECOM.Web.xymanage.LabelManage
{
    public partial class baikeset : XYECOM.Web.BasePage.LabelBasePage
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
                this.ddlorderColumuName.Items.Add(new ListItem("自动编号", "LemmaId"));
                this.ddlorderColumuName.Items.Add(new ListItem("创建时间", "CreateTime"));
                this.ddlorderColumuName.Items.Add(new ListItem("浏览次数", "BrowseTimes"));
                this.ddlorderColumuName.Items.Add(new ListItem("编辑次数", "EditTimes"));

                this.ddlpageorder.Items.Add(new ListItem("自动编号", "LemmaId"));
                this.ddlpageorder.Items.Add(new ListItem("创建时间", "CreateTime"));
                this.ddlpageorder.Items.Add(new ListItem("浏览次数", "BrowseTimes"));
                this.ddlpageorder.Items.Add(new ListItem("编辑次数", "EditTimes"));
            }
        }

        #region 分页搜索列表
        protected void BtnBaikePageList(object sender, EventArgs e)
        {
            string str = "";
            str += XYECOM.Core.Utils.LableSet(Function.LabelPrefix.Remove(Function.LabelPrefix.Length - 1, 1), "BaikePageList").Substring(1);
            str += XYECOM.Core.Utils.LableSet("每页调用数量", tbpagenum.Text.Trim());
            str += XYECOM.Core.Utils.LableSet("日期格式", ddlpagedatetype.SelectedValue);
            str += XYECOM.Core.Utils.LableSet("排序字段", ddlpageorder.SelectedValue);
            str += XYECOM.Core.Utils.LableSet("排序方式", ddlpagedesc.SelectedValue);
            str += XYECOM.Core.Utils.LableSet("内容显示字数", this.txtpageContentLength.Text);

            this.ClientScript.RegisterClientScriptBlock(GetType(), "", "<script type=\"text/javascript\">parent.setLabelValue(\"" + str + "\");</" + "" + "script>");
        }
        #endregion

        #region 百科列表
        protected void BtnBaikeList(object sender, EventArgs e)
        {
            string str = "";

            str += XYECOM.Core.Utils.LableSet(Function.LabelPrefix.Remove(Function.LabelPrefix.Length - 1, 1), "BaikeList").Substring(1);

            str += XYECOM.Core.Utils.LableSet("调用数量", tbnum.Text.Trim());
            str += XYECOM.Core.Utils.LableSet("浏览次数", tbclicknum.Text.Trim());
            str += XYECOM.Core.Utils.LableSet("排序字段", ddlorderColumuName.SelectedValue);
            str += XYECOM.Core.Utils.LableSet("排序方式", ddlorder.SelectedValue);
            str += XYECOM.Core.Utils.LableSet("日期格式", ddldatetype.SelectedValue);
            str += XYECOM.Core.Utils.LableSet("是否推荐", this.ddlrecommend.SelectedValue);
            str += XYECOM.Core.Utils.LableSet("是否优秀", this.ddlbest.SelectedValue);
            str += XYECOM.Core.Utils.LableSet("百科分类", this.typeId.Value);
            str += XYECOM.Core.Utils.LableSet("内容显示字数", this.txtContentLength.Text);
            this.ClientScript.RegisterClientScriptBlock(GetType(), "", "<script type=\"text/javascript\">parent.setLabelValue(\"" + str + "\");</" + "" + "script>");
        }
        #endregion

        protected override void InitPageValue(XYECOM.Web.BasePage.MyDictionary table)
        {
            string type = table["XY"].ToLower();
            if ("BaikePageList".ToLower() == type)
            {
                this.tbpagenum.Text = table["每页调用数量"];
                this.ddlpagedatetype.SelectedValue = table["日期格式"];
                this.ddlpageorder.SelectedValue = table["排序字段"];
                this.ddlpagedesc.SelectedValue = table["排序方式"];
                this.txtpageContentLength.Text = table["内容显示字数"];

                ClientScript.RegisterStartupScript(GetType(), "page", "myclick(\"li_page\",\"click\");", true);
            }
            if ("BaikeList".ToLower() == type)
            {
                this.tbnum.Text = table["调用数量"];
                this.tbclicknum.Text = table["浏览次数"];
                this.ddlorderColumuName.SelectedValue = table["排序字段"];
                this.ddlorder.SelectedValue = table["排序方式"];
                this.ddldatetype.SelectedValue = table["日期格式"];
                this.ddlrecommend.SelectedValue = table["是否推荐"];
                this.ddlbest.SelectedValue = table["是否优秀"];
                this.typeId.Value = table["百科分类"];
                this.txtContentLength.Text = table["内容显示字数"];

                ClientScript.RegisterStartupScript(GetType(), "page", "myclick(\"li_base\",\"click\");", true);
            }
        }
    }
}
