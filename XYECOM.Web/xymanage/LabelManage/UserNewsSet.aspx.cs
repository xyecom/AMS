using System;
using System.Web.UI.WebControls;
using XYECOM.Core;

namespace XYECOM.Web.xymanage.LabelManage
{
    public partial class UserNewsSet : XYECOM.Web.BasePage.LabelBasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //防止调用页面缓存
            Response.Buffer = true;
            Response.ExpiresAbsolute = System.DateTime.Now.AddSeconds(-1);
            Response.Expires = 0;
            Response.CacheControl = "no-cache";

            if (LabelUserId == 0)
            {
                this.btnCreateUserNews.Enabled = false;
                this.btnCreateUserNewsList.Enabled = false;
                Alert("所选择的标签数据结构仅用于单用户，请重新将标签应用范围选择为单用户");
            }

            CheckRole("label");
            if (!IsPostBack)
            {
                this.btnCreateUserNews.Attributes.Add("onclick", "javascript:return labelvalidate(19);");
                this.btnCreateUserNewsList.Attributes.Add("onclick", "javascript:return labelvalidate(19);");

                this.ddlorderColumuName.Items.Add(new ListItem("自动编号", "N_ID"));
                this.ddlorderColumuName.Items.Add(new ListItem("发布时间", "N_AddTime"));
                this.ddlorderColumuName.Items.Add(new ListItem("点击次数", "N_Count"));

                this.ddlpageorder.Items.Add(new ListItem("自动编号", "N_ID"));
                this.ddlpageorder.Items.Add(new ListItem("发布时间", "N_AddTime"));
                this.ddlpageorder.Items.Add(new ListItem("点击次数", "N_Count"));

            }

        }

        #region 新闻基本列表
        protected void BtnNewsList(object sender, EventArgs e)
        {
            string str = "";
            str += XYECOM.Core.Utils.LableSet(Function.LabelPrefix.Remove(Function.LabelPrefix.Length - 1, 1), "UserNewsList").Substring(1);
            str += XYECOM.Core.Utils.LableSet("资讯栏目", hdgetid.Value.Trim());
            str += XYECOM.Core.Utils.LableSet("调用数量", tbnum.Text.Trim());
            str += XYECOM.Core.Utils.LableSet("标题字数", tbtitlenum.Text.Trim());
            str += XYECOM.Core.Utils.LableSet("点击次数", tbclicknum.Text.Trim());
            str += XYECOM.Core.Utils.LableSet("排序字段", ddlorderColumuName.SelectedValue);
            str += XYECOM.Core.Utils.LableSet("排序方式", ddlorder.SelectedValue);
            str += XYECOM.Core.Utils.LableSet("日期格式", ddldatetype.SelectedValue);
            str += XYECOM.Core.Utils.LableSet("是否推荐", this.ddlCommend.SelectedValue);
            str += XYECOM.Core.Utils.LableSet("导读显示字数", tbcontentnum.Text.Trim());
            //str += XYECOM.Core.Utils.LableSet("是否为图片资讯", this.ddlimg.SelectedValue);
            this.ClientScript.RegisterClientScriptBlock(GetType(), "", "<script type=\"text/javascript\">parent.setLabelValue(\"" + str + "\");</" + "" + "script>");
        }
        #endregion

        protected void BtnNewsPageList(object sender, EventArgs e)
        {
            string str = "";
            str += XYECOM.Core.Utils.LableSet(Function.LabelPrefix.Remove(Function.LabelPrefix.Length - 1, 1), "UserNewsPageList").Substring(1);
            str += XYECOM.Core.Utils.LableSet("调用数量", tbpagenum.Text.Trim());
            str += XYECOM.Core.Utils.LableSet("标题字数", tbpagetitlenum.Text.Trim());
            str += XYECOM.Core.Utils.LableSet("日期格式", ddlpagedatetype.SelectedValue);
            str += XYECOM.Core.Utils.LableSet("排序字段", ddlpageorder.SelectedValue);
            str += XYECOM.Core.Utils.LableSet("排序方式", ddlpagedesc.SelectedValue);
            str += XYECOM.Core.Utils.LableSet("导读显示字数", tbpageproductnum.Text.Trim());

            this.ClientScript.RegisterClientScriptBlock(GetType(), "", "<script type=\"text/javascript\">parent.setLabelValue(\"" + str + "\");</" + "" + "script>");

        }

        protected override void InitPageValue(XYECOM.Web.BasePage.MyDictionary table)
        {
            string type = table["XY"].ToLower();
            if ("UserNewsList".ToLower() == type)
            {
                this.hdgetid.Value = table["资讯栏目"];
                this.tbnum.Text = table["调用数量"];
                this.tbtitlenum.Text = table["标题字数"];
                this.tbclicknum.Text = table["点击次数"];
                this.ddlorderColumuName.SelectedValue = table["排序字段"];
                this.ddlorder.SelectedValue = table["排序方式"];
                this.ddldatetype.SelectedValue = table["日期格式"];
                this.ddlCommend.SelectedValue = table["是否推荐"];
                this.tbcontentnum.Text = table["导读显示字数"];
                //this.ddlimg.SelectedValue = table["是否为图片资讯"];
                //this.rbtcobyes.Checked
                
                ClientScript.RegisterStartupScript(GetType(), "base", "myclick(\"li_base\",\"click\");", true);

            }
            if ("UserNewsPageList".ToLower() == type)
            {
                this.tbpagenum.Text = table["调用数量"];
                tbpagetitlenum.Text = table["标题字数"];
                ddlpagedatetype.SelectedValue = table["日期格式"];
                ddlpageorder.SelectedValue = table["排序字段"];
                ddlpagedesc.SelectedValue = table["排序方式"];
                tbpageproductnum.Text = table["导读显示字数"];
                ClientScript.RegisterStartupScript(GetType(), "page", "myclick(\"li_page\",\"click\");", true);
            }
        }
    }
}