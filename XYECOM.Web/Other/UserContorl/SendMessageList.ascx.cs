using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace XYECOM.Web.Other.UserContorl
{
    public partial class SendMessageList : System.Web.UI.UserControl
    {
        Model.GeneralUserInfo userinfo = XYECOM.Business.CheckUser.UserInfo;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (userinfo == null)
            {
                Response.Redirect("/Login.aspx");
                return;
            }

            if (!IsPostBack)
            {
                BindData();
            }
        }

        protected void BindData()
        {
            this.pageinfo.CurPage = XYECOM.Core.XYRequest.GetQueryInt("pageindex", 1);

            string strwhere = " where  UR_ID=" + userinfo.userid.ToString();

           

            pageinfo.PageSize = 10;
            this.pageinfo.RecTotal = XYECOM.Core.Function.GetRows(" XYV_SendMessage ", "M_ID", strwhere);
            this.pageinfo.CurPage = XYECOM.Core.XYRequest.GetInt("PageIndex", 1);

            DataTable table = XYECOM.Core.Function.GetPages(this.pageinfo.PageSize, this.pageinfo.CurPage, strwhere, " order by M_AddTime  desc ", " XYV_SendMessage ", "M_ID, Title,M_AddTime,M_HasReply,type,UR_ID,M_Title,U_ID,M_UserName,M_CompanyName,type", " M_ID ");
            this.DataList1.DataSource = table;
            this.DataList1.DataBind();
        }

        protected void Page1_PageChanged(object sender, System.EventArgs e)
        {
            this.BindData();
        }
    }
}

