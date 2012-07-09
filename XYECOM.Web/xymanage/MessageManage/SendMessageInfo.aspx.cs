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

public partial class xymanage_MessageManage_SendMessageInfo : XYECOM.Web.BasePage.ManagePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        CheckRole("sysmessage");

        if (!IsPostBack)
        {
            if (Request.QueryString["M_ID"] != null && Request.QueryString["M_ID"].ToString() != "")
            {

                XYECOM.Business.Message m = new XYECOM.Business.Message();
                XYECOM.Model.MessageInfo em = new XYECOM.Model.MessageInfo();
                em = m.GetItem(Convert.ToInt64(Request.QueryString["M_ID"]));
                if (em != null)
                {
                    this.username.InnerText = em.M_Title.ToString();
                    this.info.InnerHtml = em.M_Content.ToString();
                    this.addtime.InnerText = em.M_AddTime.ToShortDateString();
                    if (em.M_HasReply.ToString().ToLower() == "true")
                        this.HasReply.InnerHtml = "已查看";
                    else
                        this.HasReply.InnerHtml = "未查看";

                }
            }
        }
    }
}
