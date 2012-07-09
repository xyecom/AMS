using System;
using System.Data;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using XYECOM.Core;

public partial class xymanage_LabelManage_currucyset : XYECOM.Web.BasePage.LabelBasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //防止调用页面缓存
        Response.Buffer = true;
        Response.ExpiresAbsolute = System.DateTime.Now.AddSeconds(-1);
        Response.Expires = 0;
        Response.CacheControl = "no-cache";

        CheckRole("label");

        if (!Page.IsPostBack)
        {
            BindModuleList();

            BindLinkSort();

            BindAdPlace();

            this.ddlModulesByHotKeywords.Attributes.Add("onchange", "moduleChanged_hotkeyword(this);");
        }
    }

    protected override void InitPageValue(XYECOM.Web.BasePage.MyDictionary table)
    {
        string type = table["XY"].ToLower();
        if ("FriendLink".ToLower() == type)
        {
            this.ddlLinkType.SelectedValue = table["链接类型"];
            this.ddlLinkSort.SelectedValue = table["链接分类"];
            this.tblinknum.Text = table["调用数量"];
            this.ddllinkalt.SelectedValue = table["连接提示"];
            string isCommend = table["是否推荐"];
            //是否推荐
            if (isCommend == "")
            {
                this.rdoCommendAllForFriendLink.Checked = true;//是否推荐
            }
            else if (isCommend == "1")
            {
                this.rdoCommendYesForFriendLink.Checked = true;
            }
            else
            {
                this.rdoCommendNoForFriendLink.Checked = true;
            }

            ClientScript.RegisterStartupScript(GetType(), "page", "myclick(\"li_page\",\"click\");", true);
        }
        if ("advertisingList".ToLower() == type)
        {
            this.ddladvertising.SelectedValue = table["广告位"];
            this.tbadnum.Text = table["调用数量"];
            ClientScript.RegisterStartupScript(GetType(), "key", "myclick(\"li_key\",\"click\");", true);
        }
        if ("HotKeyword".ToLower() == type)
        {
            this.ddlModulesByHotKeywords.SelectedValue = table["所属模块"];
            this.txtNumberForKeyword.Text = table["调用数量"];
            string isCommend = table["是否推荐"];
            if (isCommend == "")
            {
                this.rdoCommendAllForKeyword.Checked = true;//是否推荐
            }
            else if (isCommend == "1")
            {
                this.rdoCommendYesForKeyword.Checked = true;
            }
            else
            {
                this.rdoCommendNoForKeyword.Checked = true;
            }

            if (table["链接到页面"] == "供求页")
            {
                this.rdoToSellPage.Checked = true;
            }
            else
            {
                this.rdoToBuyPage.Checked = true;
            }
            ClientScript.RegisterStartupScript(GetType(), "base", "myclick(\"li_base\",\"click\");", true);
        }
    }

    private void BindAdPlace()
    {
        XYECOM.Business.AdPlace ap = new XYECOM.Business.AdPlace();
        DataTable dtad = ap.GetDataTable(" where AP_IsUse=1 ", "");

        ddladvertising.DataSource = dtad;
        ddladvertising.DataTextField = "AP_Name";
        ddladvertising.DataValueField = "AP_ID";
        ddladvertising.DataBind();
    }

    /// <summary>
    /// 绑定友情链接分类
    /// </summary>
    private void BindLinkSort()
    {
        List<XYECOM.Model.FriendLinkSortInfo> infos = new XYECOM.Business.FriendLinkSort().GetItems();

        foreach (XYECOM.Model.FriendLinkSortInfo info in infos)
        {
            this.ddlLinkSort.Items.Add(new ListItem(info.FS_Name,info.FS_ID.ToString()));
        }

        this.ddlLinkSort.Items.Insert(0, new ListItem("选择分类",""));
    }

    private void BindModuleList()
    {
        foreach (ListItem item in GetAllModules(true))
        {
            this.ddlModulesByHotKeywords.Items.Add(item);
        }
        this.ddlModulesByHotKeywords.Items.Insert(0, new ListItem("请选择所属模块",""));
    }

    #region 友情连接
    protected void btnfriendlink_Click(object sender, EventArgs e)
    {
        string str = "";

        string isCommend = "";

        if (rdoCommendYesForFriendLink.Checked) isCommend = "1";
        if (rdoCommendNoForFriendLink.Checked) isCommend = "0";

        str += XYECOM.Core.Utils.LableSet(Function.LabelPrefix.Remove(Function.LabelPrefix.Length - 1, 1), "FriendLink").Substring(1);
        str += XYECOM.Core.Utils.LableSet("链接类型", ddlLinkType.SelectedValue);
        str += XYECOM.Core.Utils.LableSet("链接分类", ddlLinkSort.SelectedValue);
        str += XYECOM.Core.Utils.LableSet("调用数量", tblinknum.Text);
        str += XYECOM.Core.Utils.LableSet("连接提示", ddllinkalt.SelectedValue);
        str += XYECOM.Core.Utils.LableSet("是否推荐", isCommend);
        this.ClientScript.RegisterClientScriptBlock(GetType(), "", "<script type=\"text/javascript\">parent.setLabelValue(\"" + str + "\");//window.returnValue=\"" + str + "\"; window.close();</" + "" + "script>");
    }
    #endregion

    #region 广告
    protected void btnguanggao_Click(object sender, EventArgs e)
    {
        string str = "";

        str += XYECOM.Core.Utils.LableSet(Function.LabelPrefix.Remove(Function.LabelPrefix.Length - 1, 1), "advertisingList").Substring(1);
        str += XYECOM.Core.Utils.LableSet("广告位", ddladvertising.SelectedValue);
        str += XYECOM.Core.Utils.LableSet("调用数量", tbadnum.Text);
        this.ClientScript.RegisterClientScriptBlock(GetType(), "", "<script type=\"text/javascript\">parent.setLabelValue(\"" + str + "\");//window.returnValue=\"" + str + "\"; window.close();</" + "" + "script>");
    }
    #endregion

    protected void btnHotKeywordOK_Click(object sender, EventArgs e)
    {
        string str = "";

        string toPage = "";

        if (rdoToSellPage.Checked)
            toPage = "供求页";

        if(rdoToBuyPage.Checked)
            toPage = "求购页";

        int number = MyConvert.GetInt32(txtNumberForKeyword.Text.Trim());

        if (number <= 0) number = 10;

        string isCommend = "";

        if (rdoCommendYesForKeyword.Checked) isCommend = "1";
        if (rdoCommendNoForKeyword.Checked) isCommend = "0";

        str += XYECOM.Core.Utils.LableSet(Function.LabelPrefix.Remove(Function.LabelPrefix.Length - 1, 1), "HotKeyword").Substring(1);
        str += XYECOM.Core.Utils.LableSet("所属模块", ddlModulesByHotKeywords.SelectedValue);
        str += XYECOM.Core.Utils.LableSet("调用数量", number.ToString());
        str += XYECOM.Core.Utils.LableSet("是否推荐", isCommend);
        str += XYECOM.Core.Utils.LableSet("链接到页面", toPage);
        this.ClientScript.RegisterClientScriptBlock(GetType(), "", "<script type=\"text/javascript\">parent.setLabelValue(\"" + str + "\");//window.returnValue=\"" + str + "\"; window.close();</" + "" + "script>");
    }
}

