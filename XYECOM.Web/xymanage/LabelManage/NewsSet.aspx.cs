using System;
using System.Web.UI.WebControls;
using XYECOM.Core;
using System.Data;

public partial class xymanage_LabelManage_NewsSet : XYECOM.Web.BasePage.LabelBasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //防止调用页面缓存
        Response.Buffer = true;
        Response.ExpiresAbsolute = System.DateTime.Now.AddSeconds(-1);
        Response.Expires = 0;
        Response.CacheControl = "no-cache";

        if (LabelUserId != 0)
        {
            this.btnOK.Enabled = false;
            this.btnPageOK.Enabled = false;
            Alert("所选择的标签数据结构仅用于整个平台，请重新将标签应用范围选择为整个平台");
        }

        CheckRole("label");

        if (!IsPostBack)
        {
            this.btnOK.Attributes.Add("onclick", "javascript:return labelvalidate(8);");
            this.btnPageOK.Attributes.Add("onclick", "javascript:return labelvalidate(8);");

            this.ddlorderColumuName.Items.Add(new ListItem("自动编号", "NS_ID"));
            this.ddlorderColumuName.Items.Add(new ListItem("发布时间", "NS_AddTime"));
            this.ddlorderColumuName.Items.Add(new ListItem("点击次数", "NS_Count"));

            this.ddlpageorder.Items.Add(new ListItem("自动编号", "NS_ID"));
            this.ddlpageorder.Items.Add(new ListItem("发布时间", "NS_AddTime"));
            this.ddlpageorder.Items.Add(new ListItem("点击次数", "NS_Count"));

            
            this.ddlTopicid.Items.Insert(0, new ListItem("普通资讯", ""));
        }
    }

    #region 新闻列表
    protected void BtnNewsList(object sender, EventArgs e)
    {
        string str = "";
        String rbtstr = "";
        string rbtcontributor = "";
        rbtcontributor = GetContributorNews();
        rbtstr = GetRtnText();
        str += XYECOM.Core.Utils.LableSet(Function.LabelPrefix.Remove(Function.LabelPrefix.Length - 1, 1), "NewsList").Substring(1);
        str += XYECOM.Core.Utils.LableSet("资讯栏目", hdgetid.Value.Trim());
        str += XYECOM.Core.Utils.LableSet("专题属性", ddlTopicid.SelectedValue);
        str += XYECOM.Core.Utils.LableSet("调用数量", tbnum.Text.Trim());
        str += XYECOM.Core.Utils.LableSet("标题字数", tbtitlenum.Text.Trim());
        str += XYECOM.Core.Utils.LableSet("点击次数", tbclicknum.Text.Trim());
        str += XYECOM.Core.Utils.LableSet("排序字段", ddlorderColumuName.SelectedValue);
        str += XYECOM.Core.Utils.LableSet("排序方式", ddlorder.SelectedValue);
        str += XYECOM.Core.Utils.LableSet("日期格式", ddldatetype.SelectedValue);
        str += XYECOM.Core.Utils.LableSet("新闻导读字数", tbcontentnum.Text.Trim());
        str += XYECOM.Core.Utils.LableSet("是否推荐", this.ddlCommend.SelectedValue);
        str += XYECOM.Core.Utils.LableSet("是否为图片资讯", this.ddlimg.SelectedValue);
        str += XYECOM.Core.Utils.LableSet("资讯类型", rbtstr);
        str += XYECOM.Core.Utils.LableSet("投稿资讯", rbtcontributor);
        this.ClientScript.RegisterClientScriptBlock(GetType(), "", "<script type=\"text/javascript\">parent.setLabelValue(\"" + str + "\");</" + "" + "script>");
    }
    #endregion

    private string GetContributorNews()
    {
        if (this.rbtcobyes.Checked)
        {
            return "1";
        }
        if (this.rbtcobno.Checked)
        {
            return "0";
        }
        return "";
    }


    #region 获取单选按钮的文本值
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    private String GetRtnText()
    {
        String str = "";
        if (this.Rbt_base.Checked)
        {
            str = this.Rbt_base.Text;
            return str;
        }
        else if (this.Rbt_filmstrip.Checked)
        {
            str = this.Rbt_filmstrip.Text;
            return str;
        }
        else if (this.Rbt_hot.Checked)
        {
            str = this.Rbt_hot.Text;
            return str;
        }
        else if (this.Rbt_index.Checked)
        {
            str = this.Rbt_index.Text;
            return str;
        }
        else if (this.Rbt_Scheme.Checked)
        {
            str = this.Rbt_Scheme.Text;
            return str;
        }
        else
        {
            str = this.Rbt_base.Text;
            return str;
        }
    }
    #endregion

    #region 分页搜索列表
    protected void BtnNewsPageList(object sender, EventArgs e)
    {
        string str = "";
        str += XYECOM.Core.Utils.LableSet(Function.LabelPrefix.Remove(Function.LabelPrefix.Length - 1, 1), "NewsPageList").Substring(1);
        str += XYECOM.Core.Utils.LableSet("专题属性", ddlTopicid.Text.Trim());
        str += XYECOM.Core.Utils.LableSet("调用数量", tbpagenum.Text.Trim());
        str += XYECOM.Core.Utils.LableSet("标题字数", tbpagetitlenum.Text.Trim());
        str += XYECOM.Core.Utils.LableSet("日期格式", ddlpagedatetype.SelectedValue);
        str += XYECOM.Core.Utils.LableSet("排序字段", ddlpageorder.SelectedValue);
        str += XYECOM.Core.Utils.LableSet("排序方式", ddlpagedesc.SelectedValue);
        str += XYECOM.Core.Utils.LableSet("导读显示字数", tbpageproductnum.Text.Trim());

        this.ClientScript.RegisterClientScriptBlock(GetType(), "", "<script type=\"text/javascript\">parent.setLabelValue(\"" + str + "\");</" + "" + "script>");
    }
    #endregion

    protected void Rbt_filmstrip_CheckedChanged(object sender, EventArgs e)
    {
        if (this.Rbt_filmstrip.Checked == true)
        {
            this.ddlimg.SelectedIndex = 2;
            this.ddlimg.Enabled = false;
        }
        else
        {
            this.ddlimg.SelectedIndex = 0;
            this.ddlimg.Enabled = true;
        }
    }

    /// <summary>
    /// 创建企业新闻列表
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    //protected void btnCreateEnterpriseNews_Click(object sender, EventArgs e)
    //{
    //    string userLoginName = txtLoginNameForUserNews.Text.Trim();
    //    long userId = 0;

    //    if (!userLoginName.Equals(""))
    //    {
    //        XYECOM.Model.UserInfo userInfo = new XYECOM.Business.UserInfo().GetItem(userLoginName);

    //        if (null == userInfo)
    //        {
    //            Alert("用户登录名不正确，请重新输入!", "", true, "window.onload=function(){showBody(3);}");
    //            return;
    //        }

    //        userId = userInfo.UserId;
    //    }

    //    string str = "";
    //    str += XYECOM.Core.Utils.LableSet(Function.LabelPrefix.Remove(Function.LabelPrefix.Length - 1, 1), "UserNews").Substring(1);
    //    str += XYECOM.Core.Utils.LableSet("调用数量", txtTopNumberForUserNews.Text.Trim().Equals("") ? "10" : txtTopNumberForUserNews.Text.Trim());
    //    str += XYECOM.Core.Utils.LableSet("标题字数", txtTitleNumberForUserNews.Text.Trim());
    //    str += XYECOM.Core.Utils.LableSet("日期格式", ddlDateFormatForUserNews.SelectedValue);
    //    str += XYECOM.Core.Utils.LableSet("用户Id", userId.ToString());

    //    this.ClientScript.RegisterClientScriptBlock(GetType(), "", "<script type=\"text/javascript\">parent.setLabelValue(\"" + str + "\");</" + "" + "script>");
    //}

    protected override void InitPageValue(XYECOM.Web.BasePage.MyDictionary table)
    {
        string type = table["XY"].ToLower();
        if ("NewsList".ToLower() == type)
        {
            string newstype = table["资讯类型"];
            if (newstype == "头条")
            {
                Rbt_index.Checked = true;
            }
            else if (newstype == "基本")
            {
                Rbt_base.Checked = true;
            }
            else if (newstype == "热点")
            {
                Rbt_hot.Checked = true;
            }
            else if (newstype == "幻灯")
            {
                Rbt_filmstrip.Checked = true;
            }
            else if (newstype == "方案式采购")
            {
                Rbt_Scheme.Checked = true;
            }
            this.hdgetid.Value = table["资讯栏目"];
            this.ddlTopicid.SelectedValue = table["专题属性"];
            this.tbnum.Text = table["调用数量"];
            this.tbtitlenum.Text = table["标题字数"];
            this.tbclicknum.Text = table["点击次数"];
            this.ddlorderColumuName.SelectedValue = table["排序字段"];
            this.ddlorder.SelectedValue = table["排序方式"];
            this.ddldatetype.SelectedValue = table["日期格式"];
            this.tbcontentnum.Text = table["新闻导读字数"];
            this.ddlCommend.SelectedValue = table["是否推荐"];
            this.ddlimg.SelectedValue = table["是否为图片资讯"];
            //this.rbtcobyes.Checked
            string rbttype = table["投稿资讯"];
            if (rbttype == "")
            {
                rbtcobmay.Checked = true;
                rbtcobyes.Checked = false;
                rbtcobno.Checked = false;
            }
            else if (rbttype == "1")
            {
                rbtcobyes.Checked = true;
                rbtcobno.Checked = false;
                rbtcobmay.Checked = false;
            }
            else
            {
                rbtcobno.Checked = true;
                rbtcobyes.Checked = false;
                rbtcobmay.Checked = false;
            }

            ClientScript.RegisterStartupScript(GetType(), "base", "myclick(\"li_base\",\"click\");", true);

        }
        if ("NewsPageList".ToLower() == type)
        {
            this.tbpagenum.Text = table["调用数量"];
            tbpagetitlenum.Text = table["标题字数"];
            ddlpagedatetype.SelectedValue = table["日期格式"];
            ddlpageorder.SelectedValue = table["排序字段"];
            ddlpagedesc.SelectedValue = table["排序方式"];
            tbpageproductnum.Text = table["导读显示字数"];

            ClientScript.RegisterStartupScript(GetType(), "page", "myclick(\"li_page\",\"click\");", true);

        }
        //if ("UserNews".ToLower() == type)
        //{
        //    this.txtTopNumberForUserNews.Text = table["调用数量"];
        //    txtTitleNumberForUserNews.Text = table["标题字数"];
        //    ddlDateFormatForUserNews.SelectedValue = table["日期格式"];
        //    txtLoginNameForUserNews.Text = table["用户ID"];
        //    ClientScript.RegisterStartupScript(GetType(), "key", "myclick(\"li_key\",\"click\");", true);
        //}
    }
}