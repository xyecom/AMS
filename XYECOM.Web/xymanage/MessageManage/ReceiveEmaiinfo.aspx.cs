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

public partial class xymanage_basic_ReceiveEmaiinfo : XYECOM.Web.BasePage.ManagePage
{
    #region  页面加载
    protected void Page_Load(object sender, EventArgs e)
    {
        CheckRole("sysmessage");

        if (!Page.IsPostBack)
        {
            
            this.Button3.Attributes.Add("onclick", "Javascript:return adminmessage();");
            if (Request.QueryString["M_ID"] != null && Request.QueryString["M_ID"].ToString() != "")
            {
                XYECOM.Business.Message m = new XYECOM.Business.Message();
                XYECOM.Model.MessageInfo emy = new XYECOM.Model.MessageInfo();

                emy = m.GetItem(Convert.ToInt64(Request.QueryString["M_ID"].ToString()));
                
                if (emy != null)
                {
                    this.U_ID.Value = emy.U_ID.ToString();
                    this.username.InnerText = emy.M_UserName.ToString();
                    this.title.Text = "回复：" + emy.M_Title.ToString();
                    if (emy.M_PHMa.ToString() != "")
                    {
                        this.phone.InnerText = emy.M_PHMa.ToString();
                    }
                    this.moblie.InnerText = emy.M_Moblie.ToString();
                    this.info.InnerHtml = emy.M_Content.ToString();
                    this.addtime.InnerText = emy.M_AddTime.ToShortDateString();
                }

                m.Update(Convert.ToInt64(XYRequest.GetQueryString("M_ID")));
            }
        }
    }
    #endregion

    #region  管理员给用户回复留言
    protected void Button3_Click(object sender, EventArgs e)
    {
        XYECOM.Business.UserInfo ui = new XYECOM.Business.UserInfo();
        XYECOM.Model.UserInfo eui = new XYECOM.Model.UserInfo();
        XYECOM.Business.Message m = new XYECOM.Business.Message();
        XYECOM.Model.MessageInfo ems = new XYECOM.Model.MessageInfo();
        int k = 0;
          
        ems.Area_ID =-1;
        ems.M_Adress ="";
        ems.M_CompanyName ="";
        ems.M_Content = this.content.Text;
        ems.M_Email = "";
        ems.M_FHM = "";
        ems.M_HasReply = true;
        ems.M_Moblie = "";
        ems.M_PHMa = "";
        ems.M_RecverType = "administrator";
        ems.M_Restore = true;
        ems.M_SenderType = "user";
        ems.M_Sex = false ;
        ems.M_Title = this.title.Text;
        ems.M_UserName ="";
        ems.M_UserType = true;
        ems.U_ID =-1;
        ems.UR_ID = XYECOM.Core.MyConvert.GetInt64(this.U_ID.Value);
        k = m.Insert(ems);

       
          
        if (k > 0)
        {
           if (Request.QueryString["M_ID"].ToString() != "")
            {
                m.UpdateMess(Convert.ToInt64(Request.QueryString["M_ID"].ToString()));
            }
            Alert("回复成功！", "ReceiveEmail.aspx");
        }
        else
        {
            Alert("回复失败.", "ReceiveEmail.aspx");
        }
    }
    #endregion

    protected void btn_back_Click(object sender, EventArgs e)
    {
        this.Response.Redirect(XYECOM.Core.XYRequest.GetQueryString("backURL"));
    }

    protected void btn_back2_Click(object sender, EventArgs e)
    {
        this.Response.Redirect(XYECOM.Core.XYRequest.GetQueryString("backURL"));
    }

}
