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


        #region Web ������������ɵĴ���
        override protected void OnInit(EventArgs e)
        {
            //
            // CODEGEN: �õ����� ASP.NET Web ���������������ġ�
            //
            InitializeComponent();
            base.OnInit(e);
        }

        /// <summary>
        ///		�����֧������ķ��� - ��Ҫʹ�ô���༭��
        ///		�޸Ĵ˷��������ݡ�
        /// </summary>
        private void InitializeComponent()
        {
            this.Load += new System.EventHandler(this.Page_Load);

        }
        #endregion

        #region ���������

        #region ��
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

        #region ����ӽڵ�

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
            strhtml.AppendLine(info.HasSub ? imgParent + " " + info.ClassName + "    " + img3 + "[&nbsp;<a href=\"AreaAdd.aspx?ParentID=" + info.ClassId + "\" >���</a>&nbsp;]" +
                                             " [&nbsp;<a href=\"AreaAdd.aspx?ParentID=" + info.ClassId + "&ID=" + info.ClassId + "\" >�༭</a>&nbsp;]"
                                            : imgchird + " " + info.ClassName + "    " + img3 + "[&nbsp;<a href=\"AreaAdd.aspx?ParentID=" + info.ClassId + "\" >���</a>&nbsp;]" +
                                              " [&nbsp;<a href=\"AreaAdd.aspx?ParentID=" + info.ClassId + "&ID=" + info.ClassId + "\" >�༭</a>&nbsp;]" +
                                              " [&nbsp;<a onclick=\"javascript:return confirm('ȷ��ɾ����')\" href=\"AreaList.aspx?delID=" + info.ClassId + "\" >ɾ��</a>&nbsp;]");
            strhtml.AppendLine("</li>");
            this.pnlSuperClass.Controls.Add(new LiteralControl(strhtml.ToString()));
        }
        #endregion


        #region ɾ��

        private void Del(String id) {

            int num = 0;
            XYECOM.Business.Area area = new Area();
            XYECOM.Business.XYClass xy = new XYClass();
            num = ((xy.InfoNum("i_engageinfo", "Area_ID", id)) + (xy.InfoNum("pl_Message", "Area_ID", id))
                    + (xy.InfoNum("u_Individual", "Area_ID", id)) + (xy.InfoNum("u_UserInfo", "Area_ID", id)));
            if (num > 0)
            {
                Alert("��ѡ��ĵ����»�����Ϣ.��ɾ�������Ϣ��ɾ������","AreaList.aspx");
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
                    Alert("ɾ��ʧ��", "AreaList.aspx");
                }
            }
        }

        #endregion
    }
}
