using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace XYECOM.Web.xymanage.UserManage
{
    public partial class SubUserList : XYECOM.Web.BasePage.ManagePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CheckRole("user");
        }

        #region 绑定数据
        protected override void BindData()
        {
            this.lblMessage.Text = "";
            long userId = Core.XYRequest.GetQueryInt64("userId");
            DataTable dt = new Business.UserReg().GetPartList(userId);
            lblCompanyName.Text = new XYECOM.Business.UserInfo().GetItem(userId).Name;

            if (dt.Rows.Count > 0)
            {
                this.gvlist.DataSource = dt;
                this.gvlist.DataBind();
            }
            else
            {
                this.lblMessage.Text = "没有相关信息记录";
                this.gvlist.DataBind();
            }
        }
        #endregion


        #region 绑定数据
        protected void gvlist_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes.Add("onmouseover", "javascript:__XY_GV_Row_MouseOver(this)");
                e.Row.Attributes.Add("onmouseout", "javascript:__XY_GV_Row_MouseOut(this);");
            }
        }
        #endregion
    }
}