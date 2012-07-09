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

namespace XYECOM.Web.xymanage.UserManage
{
    public partial class ResumeList : XYECOM.Web.BasePage.ManagePage
    {

        #region 页面加载
        protected void Page_Load(object sender, EventArgs e)
        {
            CheckRole("individual");
            if (!IsPostBack)
            {
                this.Page1.PageSize = 20;
                int page = XYECOM.Core.XYRequest.GetQueryInt("page", 0);
                if (page > 0) Page1.CurPage = page;
                if (XYECOM.Core.XYRequest.GetQueryString("level") != "")
                {
                    this.edulevel.SelectedValue = XYECOM.Core.XYRequest.GetQueryString("level");
                }
                if (XYECOM.Core.XYRequest.GetQueryString("years") != "")
                {
                    this.workyears.SelectedValue = XYECOM.Core.XYRequest.GetQueryString("years");
                }
                if (XYECOM.Core.XYRequest.GetQueryString("city") != "")
                {
                    this.areatypeid.Value = XYECOM.Core.XYRequest.GetQueryString("city");
                }
                Bind();
            }
        }
        #endregion

        #region 绑定数据行初始化

        protected void gvlist_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes.Add("onmouseover", "javascript:__XY_GV_Row_MouseOver(this)");
                e.Row.Attributes.Add("onmouseout", "javascript:__XY_GV_Row_MouseOut(this);");
            }
        }
        #endregion

        #region 绑定
        protected void Bind() {

            backURL = XYECOM.Core.Utils.JSEscape("ResumeList.aspx?page=" + this.Page1.CurPage.ToString() + "&level=" + this.edulevel.SelectedValue + "&years=" + this.workyears.SelectedValue + "&city=" + this.areatypeid.Value);

            String strwhere = " 1=1 ";
            if(this.edulevel.SelectedValue != "-1")
            {
                strwhere += " and RE_Schoolage ='"+ this.edulevel.SelectedValue +"' ";
            }

            if(this.workyears.SelectedValue !="-1")
            {
                strwhere += " and RE_JobYear ='"+ this.workyears.SelectedValue +"'";
            }
            if(this.areatypeid.Value !="")
            {
                strwhere += " and Area_ID =" + this.areatypeid.Value;
            }

            string begindate = this.bgdate.Value;
            string enddate = this.egdate.Value;
            try
            {
                DateTime bgdate = Convert.ToDateTime(begindate);
            }
            catch (Exception)
            {
                begindate = "";
            }
            try
            {
                DateTime eddate = Convert.ToDateTime(enddate);
            }
            catch (Exception)
            {
                enddate = "";
            }


            if (begindate != "" && enddate != "")
            {
                strwhere += " and (RE_Gyear between '" + begindate + "' and '" + enddate + "')";
            }

            int totalRecord = 0;

            DataTable news = XYECOM.Business.Utils.GetPaginationData("XYV_Individual", "U_ID", "U_ID,U_Name,RE_JobYear,RE_School,RE_Speciality,RE_Gyear,RE_Schoolage,RE_Experience,RE_HtmlPage,Area_Id", "U_ID desc", strwhere, this.Page1.PageSize, this.Page1.CurPage, out totalRecord);

            this.Page1.RecTotal =totalRecord;

            if (news.Rows.Count > 0)
            {
                this.gvlist.DataSource = news;
                this.gvlist.DataBind();
            }
            else
            {
                this.gvlist.DataBind();
                this.lblMessage.Text = "没有相关简历!";
            }
        }
        #endregion


        protected string GetAreaName(object objAreaId)
        {
            int areaId = Core.MyConvert.GetInt32(objAreaId.ToString());

            if (areaId <= 0) return "";

            Model.AreaInfo area = new Business.Area().GetItem(areaId);

            if (area == null) return "";

            return area.Name;
        }

        #region 生成删除静态页面
        protected void btnCreateHtml_Click(object sender, EventArgs e)
        {
            string j = "";

            foreach (GridViewRow GR in this.gvlist.Rows)
            {
                if (((CheckBox)(GR.FindControl("chkExport"))).Checked == true)
                {
                    j += "" == j ? "" : ",";
                    j += gvlist.DataKeys[GR.DataItemIndex].Value.ToString();
                }
            }
            if ("" != j)
            {
                CreateHTML(j, "othermodule", "resum");

                Alert("操作成功！", Request.RawUrl);
            }
        }

        protected void btnDelHtml_Click(object sender, EventArgs e)
        {
            string j = "";

            foreach (GridViewRow GR in this.gvlist.Rows)
            {
                if (((CheckBox)(GR.FindControl("chkExport"))).Checked == true)
                {
                    j += "" == j ? "" : ",";
                    j += gvlist.DataKeys[GR.DataItemIndex].Value.ToString();
                }
            }
            if ("" != j)
            {
                DeleteHTML(j, "othermodule", "resum");
                Alert("操作成功！", Request.RawUrl);
            }
        }
        #endregion

        #region 搜索
        protected void Button2_Click(object sender, EventArgs e)
        {
            Bind();
        }
        #endregion

        #region Web 窗体设计器生成的代码
        override protected void OnInit(EventArgs e)
        {
            this.Load += new System.EventHandler(this.Page_Load);
            this.Page1.PageChanged += new xymanage_UserControl_page.EventHandler(Page1_PageChanged);
            base.OnInit(e);
        }
        #endregion

        #region 分页
        private void Page1_PageChanged(object sender, System.EventArgs e)
        {
            Bind();
        }
        #endregion
    }
}
