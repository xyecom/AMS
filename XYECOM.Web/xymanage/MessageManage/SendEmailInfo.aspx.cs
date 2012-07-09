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
using XYECOM.Core;

public partial class xymanage_basic_SendEmailEdit : XYECOM.Web.BasePage.ManagePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        CheckRole("email");
        if (!Page.IsPostBack)
        {
            if (Request.QueryString["E_ID"].ToString() != "")
            {
                SendEmail se = new SendEmail();
                XYECOM.Model.SendEmailInfo Info = se.GetItem(Convert.ToInt32(Request.QueryString["E_ID"].ToString()));
                if (null != Info)
                {
                    this.lbtitle.Text = Info.E_title;
                    this.lbcontent.Text = Info.E_content;
                    this.lbtime.Text = Info.AddTime.ToShortDateString();
                }

            }
        }
    }
}
