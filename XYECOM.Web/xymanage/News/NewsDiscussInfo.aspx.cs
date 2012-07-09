using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using System.Data.SqlClient;
using XYECOM.Business;
using XYECOM.Model;
using XYECOM.Core;

public partial class xymanage_news_NewsDiscussInfo : XYECOM.Web.BasePage.ManagePage
{
    Int64 ndid = 0;
    Int64 nsid = 0;
    string nsname;
    NewsDiscussInfo ndinfo;
    NewsDiscuss ndis = new NewsDiscuss();
    protected void Page_Load(object sender, EventArgs e)
    {
        CheckRole("newscomment");

        if (Request.QueryString["ND_ID"] != null && Request.QueryString["NS_ID"] != null)
        {
            ndid = Int64.Parse(Request.QueryString["ND_ID"].ToString());
            nsid = Int64.Parse(Request.QueryString["NS_ID"].ToString());
        }
        if (!IsPostBack)
        {
            if (ndid != 0 && nsid != 0)
                BindData(ndid, nsid);
            else
                Alert("请先选择你要查看的具体评论.", "NewsDiscussList.aspx?NS_ID=" + nsid);
        }
    }

    #region 绑定要查看的新闻评论
    private void BindData(Int64 nd, Int64 ns)
    {
        XYECOM.Business.News ne = new XYECOM.Business.News();
        nsname = ne.GetNewsName(ns);
        this.caption.InnerHtml = nsname;
        
        ndinfo = ndis.GetItem(nd);
        
        if (ndinfo.U_ID.ToString() == "0")
            this.lbname.Text = ndinfo.U_Name+"(游客)";
        else
            this.lbname.Text = ndinfo.U_Name+"(会员)";
        this.lbtime.Text = ndinfo.ND_AddTime.ToString();
        this.tbcontent.Text = ndinfo.ND_Content.Replace("</n>", "</br>");
        if (ndinfo.ND_IsShow == true)
        {
            this.rbisshowtrue.Checked = true;
        }
        else
        {
            this.rbisshowfalse.Checked = true;
        }
    }
    #endregion

    #region 单击提交事件
    protected void btsub_Click(object sender, EventArgs e)
    {
        int row = -1;
        if (this.rbisshowfalse.Checked == true)
        {
            row = ndis.SetIsShow(Int64.Parse(Request.QueryString["ND_ID"].ToString()), false);
        }
        if(this.rbisshowtrue.Checked == true)
        {
            row = ndis.SetIsShow(Int64.Parse(Request.QueryString["ND_ID"].ToString()), true);
        }

        if (row >= 0)
        {
            Alert("操作评论成功.", "NewsDiscussList.aspx?NS_ID=" + Request.QueryString["NS_ID"].ToString());
        }
        else
        {
            Alert("操作评论失败.", "NewsDiscussList.aspx?NS_ID=" + Request.QueryString["NS_ID"].ToString());
        }
    }
	#endregion

    #region 单击返回事件
    protected void btcancel_ServerClick(object sender, EventArgs e)
    {
        if (XYECOM.Core.XYRequest.GetQueryString("backURL") != "")
            this.Response.Redirect(XYECOM.Core.XYRequest.GetQueryString("backURL"));
        else
            this.Response.Redirect("NewsDiscussList.aspx?NS_ID=" + Request.QueryString["NS_ID"].ToString());
    }
	#endregion
}
