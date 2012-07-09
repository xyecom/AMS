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
using XYECOM.Business;
using XYECOM.Core;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Web.xymanage.basic
{
    public partial class AreaList : XYECOM.Web.BasePage.ManagePage
    {
        private const string Img1 = "<img src=\"../images/bg_shrink.gif\" />";
        private const string Img2 = "<img src=\"../images/bg_spread.gif\" />";
        private const String img3 = "<img src=\"../images/arrow_black.gif\" />";
        private const String imgParent = "<img src=\"../images/folders.gif\" />";
        private const String imgchird = "<img src=\"../images/folder.gif\" />";
        private String isfirstid = "";
        protected string strParentID = "0";
        protected void Page_Load(object sender, EventArgs e)
        {
            CheckRole("area");
            if (!IsPostBack)
            {
                string strParentID = XYECOM.Core.XYRequest.GetQueryString("ParentID");
                if (!string.IsNullOrEmpty(strParentID))
                {
                    string curTypeFullId = XYECOM.Business.XYClass.GetFullid("Area", strParentID);
                    ClientScript.RegisterStartupScript(this.GetType(), "expr", "expran('Area','" + curTypeFullId + "')", true);
                }
                else 
                {
                    strParentID = "0";
                }

                BindClassList("Area");
            }
            if (XYECOM.Core.XYRequest.GetQueryString("delID") != "" && !isfirstid.Equals(XYECOM.Core.XYRequest.GetQueryString("delID")))
            {
                Del(XYECOM.Core.XYRequest.GetQueryString("delID"));
            }
        }


        #region Web 窗体设计器生成的代码
        override protected void OnInit(EventArgs e)
        {
            //
            // CODEGEN: 该调用是 ASP.NET Web 窗体设计器所必需的。
            //
            InitializeComponent();
            base.OnInit(e);
        }

        /// <summary>
        ///		设计器支持所需的方法 - 不要使用代码编辑器
        ///		修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.Load += new System.EventHandler(this.Page_Load);

        }
        #endregion

        #region 类型树相关

        #region 绑定
        private void BindClassList(string moduleName)
        {
            //List<XYECOM.Model.XYClassInfo> infos = XYECOM.Business.XYClass.GetItemsAll(moduleName);
            List<XYECOM.Model.XYClassInfo> infos = XYECOM.Business.XYClass.GetSubItems(moduleName, 0);
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
            this.pnlSuperClass.Controls.Add(new LiteralControl("<li id=\"li_" + info.ClassId + "\" style=\"display:none;\"><ul>"));
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
            strhtml.AppendLine(info.HasSub ? "<a href=\"javascript:LabelClassDisplay2('" + ename + "','" + info.ClassId + "','" + str + "');\">" + Img1 + "</a>" : Img2);
            strhtml.AppendLine(info.HasSub ? imgParent + " " + info.ClassName + "    " + img3 + "[&nbsp;<a href=\"AreaAdd.aspx?ParentID=" + info.ClassId + "\" >添加</a>&nbsp;]" +
                                             " [&nbsp;<a href=\"AreaAdd.aspx?ParentID=" + info.ClassId + "&ID=" + info.ClassId + "\" >编辑</a>&nbsp;]"
                                            : imgchird + " " + info.ClassName + "    " + img3 + "[&nbsp;<a href=\"AreaAdd.aspx?ParentID=" + info.ClassId + "\" >添加</a>&nbsp;]" +
                                              " [&nbsp;<a href=\"AreaAdd.aspx?ParentID=" + info.ClassId + "&ID=" + info.ClassId + "\" >编辑</a>&nbsp;]" +
                                              " [&nbsp;<a onclick=\"javascript:return confirm('确定删除？')\" href=\"AreaList.aspx?delID=" + info.ClassId + "\" >删除</a>&nbsp;]");
            strhtml.AppendLine("</li>");
            this.pnlSuperClass.Controls.Add(new LiteralControl(strhtml.ToString()));
        }
        #endregion


        #region 删除

        private void Del(String id) {

            int num = 0;
            XYECOM.Business.Area area = new Area();
            XYECOM.Business.XYClass xy = new XYClass();
            num = ((xy.InfoNum("i_engageinfo", "Area_ID", id)) + (xy.InfoNum("pl_Message", "Area_ID", id))
                    + (xy.InfoNum("u_Individual", "Area_ID", id)) + (xy.InfoNum("u_UserInfo", "Area_ID", id)));
            if (num > 0)
            {
                Alert("你选择的地区下还有信息.请删除相关信息再删除地区","AreaList.aspx");
            }
            else {
                int i = 0;
                i = area.Delete(id);
                if (i > 0)
                {
                    isfirstid = id;
                    Response.Redirect("AreaList.aspx");
                }
                else {
                    Alert("删除失败", "AreaList.aspx");
                }
            }
        }

        #endregion
    }
}
