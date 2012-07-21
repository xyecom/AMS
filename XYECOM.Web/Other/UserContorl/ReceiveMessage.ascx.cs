using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace XYECOM.Web.Other.UserContorl
{
    public partial class ReceiveMessage : System.Web.UI.UserControl
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

        protected string GetUserName(string uid, string uname, string companyName, string messageId)
        {
            if (uid == "-1" || uid == "-2")
            {
                return @"<a href='receivemessageinfo.{config.Suffix}?m_id=" + messageId + @"'>
                </a><em>(系统信息)</em>
                <br />";
            }
            else
            {
                if (uid == "0")
                {
                    return uname + " <em>(游客)</em>";
                }
                else
                {
                    return uname + "　" + companyName;
                }
            }
        }

        protected void BindData()
        {
            this.pageinfo.CurPage = XYECOM.Core.XYRequest.GetQueryInt("pageindex", 1);

            string strwhere = " where  UR_ID=" + userinfo.userid.ToString();

            //if (XYECOM.Core.XYRequest.GetFormString("nokan") != "")
            //{
            //    strwhere += " and M_HasReply=" + XYECOM.Core.XYRequest.GetFormString("nokan");
            //}

            //if (XYECOM.Core.XYRequest.GetFormString("datemes") != "")
            //{
            //    strwhere += " and M_AddTime  between  '" + DateTime.Now.AddMonths(-Convert.ToInt32(XYECOM.Core.XYRequest.GetFormString("datemes"))) + "' and  '" + DateTime.Now + "'";
            //}
            //if (XYECOM.Core.XYRequest.GetQueryString("datemes") != "")
            //{
            //    strwhere += " and M_AddTime  between  '" + DateTime.Now.AddMonths(-Convert.ToInt32(XYECOM.Core.XYRequest.GetFormString("datemes"))) + "' and  '" + DateTime.Now + "'";
            //}
            //if (XYECOM.Core.XYRequest.GetQueryString("type") != "")
            //{
            //    strwhere += " and M_SenderType=" + XYECOM.Core.XYRequest.GetQueryString("type");
            //}
            //if (XYECOM.Core.XYRequest.GetQueryString("infoid") != "")
            //{
            //    strwhere += " and InfoID=" + XYECOM.Core.XYRequest.GetQueryString("infoid");
            //}

            //if (XYECOM.Core.XYRequest.GetQueryString("nosee") != "")
            //{
            //    strwhere += " and M_HasReply=" + XYECOM.Core.XYRequest.GetQueryString("nosee");
            //}

            //string url = System.Web.HttpContext.Current.Request.RawUrl;
            //if (url.IndexOf("pageindex") > 0)
            //    url = url.Remove(url.IndexOf("pageindex") - 1, url.Substring(url.IndexOf("pageindex")).Length + 1);

            pageinfo.PageSize = 10;
            this.pageinfo.RecTotal = XYECOM.Core.Function.GetRows(" XYV_RecverManage ", "M_ID", strwhere);
            this.pageinfo.CurPage = XYECOM.Core.XYRequest.GetInt("PageIndex", 1);

            DataTable table = XYECOM.Core.Function.GetPages(this.pageinfo.PageSize, this.pageinfo.CurPage, strwhere, " order by M_AddTime  desc ", " XYV_RecverManage ", "M_ID, Title,M_AddTime,M_HasReply,type,UR_ID,M_Title,U_ID,M_UserName,M_CompanyName,type", " M_ID ");
            this.DataList1.DataSource = table;
            this.DataList1.DataBind();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindData();
        }

        protected void Page1_PageChanged(object sender, System.EventArgs e)
        {
            this.BindData();
        }

        protected void btndel_Click(object sender, EventArgs e)
        {

            XYECOM.Business.Message message = new XYECOM.Business.Message();
            message.Deletes((sender as LinkButton).CommandArgument);

            BindData();
        }
    }
}