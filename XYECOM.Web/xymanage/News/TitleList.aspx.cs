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
using XYECOM.Core;
using XYECOM.Business;
using System.Collections.Generic;
using System.Text;

public partial class xymanage_news_TitleList : XYECOM.Web.BasePage.ManagePage
{
    //int atpid = 0;
    private const string Img1 = "<img src=\"../images/bg_shrink.gif\" />";
    private const string Img2 = "<img src=\"../images/bg_spread.gif\" />";
    private const String img3 = "<img src=\"../images/arrow_black.gif\" />";
    private const String imgParent = "<img src=\"../images/folders.gif\" />";
    private const String imgchird = "<img src=\"../images/folder.gif\" />";
    private String isfirstid = "";
    private String strsids = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        CheckRole("news");

        if (this.cod.Value != "" && this.strids.Value != "")
        {
            strsids = this.strids.Value.Substring(0, (this.strids.Value.Length - 1));

            if (this.cod.Value.Equals("0"))
            {
                CreateHTML(strsids, "newstitle", "newstitle");
                //CreateHtml("newstitle",strsids);
            }
            if (this.cod.Value.Equals("1"))
            {
                DeleteHTML(strsids, "newstitle", "newstitle");
            }
        }
        BindClassList("news");

        if (!IsPostBack)
        {    
            if (XYECOM.Core.XYRequest.GetQueryString("delID") != "" && !isfirstid.Equals(XYECOM.Core.XYRequest.GetQueryString("delID")))
            {
                Del(XYECOM.Core.XYRequest.GetQueryString("delID"));
            }
            if (XYECOM.Core.XYRequest.GetQueryString("upID") != "" && !isfirstid.Equals(XYECOM.Core.XYRequest.GetQueryString("upID")))
            {
                MoveOrder(XYECOM.Core.XYRequest.GetQueryString("upID"), 1);
            }

            if (XYECOM.Core.XYRequest.GetQueryString("downID") != "" && !isfirstid.Equals(XYECOM.Core.XYRequest.GetQueryString("downID")))
            {
                MoveOrder(XYECOM.Core.XYRequest.GetQueryString("downID"), 0);
            }

        }
    }



    #region 换位置
    private void MoveOrder(String id, int type)
    {
        int i = 0;

        i = XYECOM.Business.XYClass.UpdateOrder("news", id, type);

        if (i > 0)
        {
            Alert("修改成功");
            Response.Redirect("TitleList.aspx?=orderid=" + id);
        }
        else
        {
            Alert("修改失败");
        }


    }
    #endregion





    #region Web窗体设计器生成的代码
    protected override void OnInit(EventArgs e)
    {
        InitializeComponent();
        base.OnInit(e);
    }

    private void InitializeComponent()
    {
        this.Load += new System.EventHandler(this.Page_Load);
    }

    #endregion

    #region 类型树相关

    #region 绑定
    private void BindClassList(string moduleName)
    {
        List<XYECOM.Model.XYClassInfo> infos = XYECOM.Business.XYClass.GetItemsAll(moduleName);
        this.pnlSuperClass.Controls.Clear();
        this.pnlSuperClass.Controls.Add(new LiteralControl("<ul>"));
        foreach (XYECOM.Model.XYClassInfo info in infos)
        {
            AddInfoHtml(info, "0", "", moduleName);
            if (info.HasSub)
            {
                AddChild(info, "&nbsp;&nbsp;&nbsp;&nbsp;", moduleName);
            }
        }
        this.pnlSuperClass.Controls.Add(new LiteralControl("</ul>"));
    }
    #endregion

    #region 添加子节点

    private void AddChild(XYECOM.Model.XYClassInfo info, string str, String ename)
    {
        this.pnlSuperClass.Controls.Add(new LiteralControl("<li id=\"li_" + info.ClassId + "\" style=\"display:block;\"><ul>"));
        foreach (XYECOM.Model.XYClassInfo info2 in info.childList)
        {
            AddInfoHtml(info2, info.ClassId.ToString(), str, ename);
            if (info2.HasSub)
            {
                AddChild(info2, str + "&nbsp;&nbsp;&nbsp;&nbsp;", ename);
            }
        }
        this.pnlSuperClass.Controls.Add(new LiteralControl("</ul></li>"));
    }
    #endregion

    private void AddInfoHtml(XYECOM.Model.XYClassInfo info, string parentID, string str, String ename)
    {
        StringBuilder strhtml = new StringBuilder();
        
        strhtml.AppendLine("<li id=\"lithis" + info.ClassId + "\">");
        strhtml.AppendLine(str);
        strhtml.AppendLine(info.HasSub ? "<a href=\"javascript:LabelClassDisplay('li_" + info.ClassId + "','lithis" + info.ClassId + "');\">" + Img2 + "</a>" : Img2);
        strhtml.AppendLine(info.HasSub ? "<input id=\"input_" + parentID + "_" + info.ClassId + "\" type=\"checkbox\" value=\"" + info.ClassId + "\" />" + imgParent + " " + info.ClassName + "    " + img3 +
                                                         "[&nbsp;<a href=\"TitleList.aspx?upid=" + info.ClassId + "\" >↑</a>&nbsp;]" +
                                                    "[&nbsp;<a href=\"TitleList.aspx?downid=" + info.ClassId + "\" >↓</a>&nbsp;]" +
                                                        "[&nbsp;<a href=\"AddTitle.aspx?Type=0&ntid=" + info.ClassId + "\">添加</a>&nbsp;]" +
                                                        " [&nbsp;<a href=\"AddTitle.aspx?Type=1&ntid=" + info.ClassId + "\">编辑</a>&nbsp;]" +
                                                        " [&nbsp;<a href=\"BatchManage.aspx?PT_ParentID=" + info.ClassId + "\" >移动</a>&nbsp;]"
                            : "<input id=\"input_" + parentID + "_" + info.ClassId + "\" type=\"checkbox\" value=\"" + info.ClassId + "\" />" + imgchird + " " + info.ClassName + "    " + img3 +
                                                "[&nbsp;<a href=\"TitleList.aspx?upid=" + info.ClassId + "\" >↑</a>&nbsp;]" +
                                                "[&nbsp;<a href=\"TitleList.aspx?downid=" + info.ClassId + "\" >↓</a>&nbsp;]" +
                                                " [&nbsp;<a href=\"AddTitle.aspx?Type=0&ntid=" + info.ClassId + "\" >添加</a>&nbsp;]" +
                                                " [&nbsp;<a href=\"AddTitle.aspx?Type=1&ntid=" + info.ClassId + "\" >编辑</a>&nbsp;]" +
                                                " [&nbsp;<a href=\"BatchManage.aspx?PT_ParentID=" + info.ClassId + "\" >移动</a>&nbsp;]" +
                                                " [&nbsp;<a onclick=\"javascript:return confirm('确定删除？')\" href=\"TitleList.aspx?delID=" + info.ClassId + "\" >删除</a>&nbsp;]");
        
        XYECOM.Business.NewsTitles newstitle = new NewsTitles();
        XYECOM.Model.NewsTitlesInfo newinfo = new XYECOM.Model.NewsTitlesInfo();
        newinfo = newstitle.GetItem(Convert.ToInt32(info.ClassId));
        if (!newinfo.HTMLPage.Equals(""))
        {
            strhtml.AppendLine("<a href=\"" + XYECOM.Configuration.WebInfo.Instance.WebDomain + newinfo.HTMLPage+ "\" target=\"_black\">查看静态页面</a>");
        }

        strhtml.AppendLine("</li>");
        this.pnlSuperClass.Controls.Add(new LiteralControl(strhtml.ToString()));
    }
    #endregion

    #region 删除
    private void Del(String id) 
    {
        int i = 0;
        int j = 0;
        
        XYECOM.Business.NewsTitles BLL = new NewsTitles();
        XYECOM.Business.XYClass clsBLL = new XYECOM.Business.XYClass();

        string name ="";
        string domain = "";

        XYECOM.Model.NewsTitlesInfo tInfo = BLL.GetItem(XYECOM.Core.MyConvert.GetInt32(id));

        if(tInfo != null)
        {
            name = tInfo.TempletFolderAddress;
            domain = tInfo.DomainName;
        }
  
        j = clsBLL.InfoNum("n_news","NT_ID",id);
        
        if(j <= 0)
        {
            i = BLL.Delete(id);
        } 
        else
        {
            Alert("该栏目下含有信息！", "TitleList.aspx");
        }
        
        if( i > 0)
        {
            isfirstid = id;
            Response.Redirect("TitleList.aspx");
        }
    }
    #endregion

}
