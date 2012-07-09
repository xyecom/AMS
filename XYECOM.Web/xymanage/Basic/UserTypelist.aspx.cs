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
public partial class xymanage_basic_UserType : XYECOM.Web.BasePage.ManagePage
{
    public string UT_PID = "0";
    private const string Img1 = "<img src=\"../images/bg_shrink.gif\" />";
    private const string Img2 = "<img src=\"../images/bg_spread.gif\" />";
    private const String img3 = "<img src=\"../images/arrow_black.gif\" />";
    private const String imgParent = "<img src=\"../images/folders.gif\" />";
    private const String imgchird = "<img src=\"../images/folder.gif\" />";
    private String isfirstid = "";

    #region 页面加载
    protected void Page_Load(object sender, EventArgs e)
    {
        CheckRole("userType");
        BindClassList("company"); 
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
            if (XYECOM.Core.XYRequest.GetQueryString("delID") != "" && !isfirstid.Equals(XYECOM.Core.XYRequest.GetQueryString("delID")))
            {
                Del(XYECOM.Core.XYRequest.GetQueryString("delID"));
            }   
        } 

        if (this.strdel.Value != "")
        {
            Del(this.strdel.Value.Substring(0,(this.strdel.Value.Length-1)));
        }
    }
    #endregion

    #region 换位置
    private void MoveOrder(String id, int type)
    {
        int i = 0;

        i = XYECOM.Business.XYClass.UpdateOrder("company", id, type);

        if (i > 0)
        {
            Alert("修改成功");
            Response.Redirect("UserTypelist.aspx?&orderid=" + id);
        }
        else
        {
            Alert("修改失败");
        }


    }
    #endregion


    #region Web 窗体设计器生成的代码
    override protected void OnInit(EventArgs e)
    {
        this.Load += new System.EventHandler(this.Page_Load); 
        base.OnInit(e);
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
        //strhtml.AppendLine("<input id=\"input_" + parentID + "_" + info.ClassId + "\" type=\"checkbox\" value=\"" + info.ClassId + "\" />");
        strhtml.AppendLine(info.HasSub ? "<a href=\"javascript:LabelClassDisplay('li_" + info.ClassId + "','lithis" + info.ClassId + "');\">" + Img2 + "</a>" : Img2);
        strhtml.AppendLine(info.HasSub ? "<input id=\"input_" + parentID + "_" + info.ClassId + "\" type=\"checkbox\" value=\"" + info.ClassId + "\" disabled/>" + imgParent + " " + info.ClassName + "    " + img3 +
                                                         "[&nbsp;<a href=\"UserTypelist.aspx?upid=" + info.ClassId + "\" >↑</a>&nbsp;]" +
                                                    "[&nbsp;<a href=\"UserTypelist.aspx?downid=" + info.ClassId + "\" >↓</a>&nbsp;]" +
                                                        "[&nbsp;<a href=\"UserTypeAdd.aspx?UT_PID=" + info.ClassId + "\" >添加</a>&nbsp;]" +
                                                        " [&nbsp;<a href=\"UserTypeAdd.aspx?UT_ID=" + info.ClassId + "\" >编辑</a>&nbsp;]" +
                                                        " [&nbsp;<a href=\"UserTypeMove.aspx?PT_ParentID=" + info.ClassId + "\" >移动</a>&nbsp;]"
                            : "<input id=\"input_" + parentID + "_" + info.ClassId + "\" type=\"checkbox\" value=\"" + info.ClassId + "\" />" + imgchird + " " + info.ClassName + "    " + img3 +
                                                    "[&nbsp;<a href=\"UserTypelist.aspx?upid=" + info.ClassId + "\" >↑</a>&nbsp;]" +
                                                    "[&nbsp;<a href=\"UserTypelist.aspx?downid=" + info.ClassId + "\" >↓</a>&nbsp;]" +
                                                    "[&nbsp;<a href=\"UserTypeAdd.aspx?UT_PID=" + info.ClassId + "\" >添加</a>&nbsp;]" +
                                                " [&nbsp;<a href=\"UserTypeAdd.aspx?UT_ID=" + info.ClassId + "\" >编辑</a>&nbsp;]" +
                                                " [&nbsp;<a href=\"UserTypeMove.aspx?PT_ParentID=" + info.ClassId + "\" >移动</a>&nbsp;]" +
                                                " [&nbsp;<a href=\"javascript:confirm('确定删除？') ? window.location.href='UserTypelist.aspx?delID=" + info.ClassId + "' : 'javascript:history.go(-1);' \" >删除</a>&nbsp;]");
        strhtml.AppendLine("</li>");
        this.pnlSuperClass.Controls.Add(new LiteralControl(strhtml.ToString()));
    }
    #endregion

    //private string GetHref(int classId)
    //{
    //    if (classId <= 0) return "";

    //    XYECOM.Model.UserTypeInfo info = new XYECOM.Business.UserType().GetItem(classId);

    //    if (info == null) return "";

    //    string flagName = info.UT_FlagName;

    //    if (webInfo.IsTradeDomain)
    //    {
    //        return webInfo.GetSubDomain(flagName);
    //    }
    //    else
    //    {
    //        if (webInfo.IsBogusStatic)
    //            return "/trade/" + flagName + "-index." + webInfo.WebSuffix;
    //        else
    //            return "/trade/index." + webInfo.WebSuffix + "?fn=" + flagName;
    //    }
    //}

    #region 删除
    private void Del(String id) 
    {
        int i = 0;
        int j = 0;
        XYECOM.Business.UserType ut = new UserType();
        XYECOM.Business.XYClass xy = new XYECOM.Business.XYClass();
        j = xy.InfoNum("u_userinfo", "UT_ID", id);
        String backURL = "UserTypelist.aspx";
        if(j <= 0){
            i = ut.Delete(id);
        }

        if (j > 0)
        {
            Alert("该分类下含有信息！", backURL);
        }
        if (i > 0)
        {
            isfirstid = id;
            Response.Redirect("UserTypelist.aspx");
        }

    }
    #endregion
}
