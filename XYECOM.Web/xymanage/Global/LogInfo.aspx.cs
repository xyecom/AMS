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


namespace XYECOM.Web.xymanage.Global
{
    public partial class LogInfo : XYECOM.Web.BasePage.ManagePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CheckRole("log");

            if (!Page.IsPostBack)
            {
                if (Request.QueryString["L_ID"] != null && Request.QueryString["L_ID"].ToString() != "")
                {
                    XYECOM.Business.Log l = new XYECOM.Business.Log();

                    XYECOM.Model.LogInfo Info = l.GetItem(Convert.ToInt32(Request.QueryString["L_ID"].ToString()));
                    if (null != Info)
                    {
                        this.lbtitle.Text = Info.L_Title;

                        try
                        {
                            this.lbname.Text = new XYECOM.Business.Admin().GetItem(Info.UM_ID).UM_Name;
                        }
                        catch { }

                        this.lbcontent.Text = Info.L_Content;
                        this.lbdate.Text = Info.L_AddTime.ToShortDateString();
                        this.lbmf.Text = Info.L_MF;
                    }
                }
            }
        }


        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect(XYECOM.Core.XYRequest.GetQueryString("backURL"));
        }
        
    }
}
