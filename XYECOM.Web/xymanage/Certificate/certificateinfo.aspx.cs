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
using System.IO;
using XYECOM.Core;
using XYECOM.Business;

public partial class xymanage_Certificate_certificateinfo : XYECOM.Web.BasePage.ManagePage
{
    public static int A_ID;
    protected void Page_Load(object sender, EventArgs e)
    {
        CheckRole("certificate");
        
        if (!IsPostBack)
        {
            Getlist();
        }
    }

    #region 读取数据
    public void Getlist()
    {
        long ceId = XYECOM.Core.XYRequest.GetQueryInt64("ce_id");

        string strwhere = " where CE_ID=" + ceId;
        DataTable DT = XYECOM.Core.Function.GetDataTable(strwhere, "", "XYV_Certificate");

        //证书信息
        
        this.lbU_Name.InnerHtml = "<a href=\"../UserManage/UserInfo.aspx?U_ID=" + DT.Rows[0]["U_ID"].ToString() + "&backURL=" + XYECOM.Core.Utils.JSEscape("../Certificate/certificateinfo.aspx?CE_ID=" + Request.QueryString["CE_ID"] + "&CE_Type=" + DT.Rows[0]["CE_Type"].ToString() + "&U_ID=" + DT.Rows[0]["U_ID"].ToString()) + " \" >" + DT.Rows[0]["U_Name"].ToString() + "</a>";
        this.LbCE_Name.Text = DT.Rows[0]["CE_Name"].ToString();
        this.lbCE_Organ.Text = DT.Rows[0]["CE_Organ"].ToString();
        this.lbCE_Addtime.Text = DT.Rows[0]["CE_Addtime"].ToString();
        this.lbCE_Begin.Text = DT.Rows[0]["CE_Begin"].ToString(); ;
        this.lbCE_Upto.Text = DT.Rows[0]["CE_Upto"].ToString();
        string strtype = DT.Rows[0]["CE_Type"].ToString();
        
        if (DT.Rows[0]["CE_Type"].ToString() != "")
        {
            this.CE_Type.Value = DT.Rows[0]["CE_Type"].ToString();
        }
        if (strtype == "1")
        {
            this.lbCE_Type.Text  = "营业执照"; 
        }
        else if (strtype == "2")
        {
            this.lbCE_Type.Text  = "税务登记类";
        }
        else if (strtype == "3")
        {
            this.lbCE_Type.Text  = "经营许可类";
        }
        else 
        {
            this.lbCE_Type.Text  = "其他类证书";
        }
        if (DT.Rows[0]["U_ID"].ToString() != "")
        {
            this.U_ID.Value  =DT.Rows[0]["U_ID"].ToString();
        }
        if (DT.Rows[0]["AuditingState"].ToString() != "")
        {
            if (DT.Rows[0]["AuditingState"].ToString() == "1")
            {
                this.lblMessage.Text = "通过审核";
                this.Button2.Enabled = false;
            }
            else if (DT.Rows[0]["AuditingState"].ToString() == "0")
            {
                this.lblMessage.Text = "未通过审核";
            }
        }
        else
        {
            this.lblMessage.Text = "未审核";
        }
        
        //  获取图片路径
        XYECOM.Business.Attachment at = new XYECOM.Business.Attachment();

        string imgUrl =XYECOM.Business.Attachment.GetInfoDefaultImgHref(XYECOM.Model.AttachmentItem.Certificate, ceId);

        this.Image1.ImageUrl =imgUrl;

        aZoom.HRef = imgUrl;
    }
    #endregion

    #region 审核通过
    protected void Button2_Click(object sender, EventArgs e)
    {
        int i = 0;
        string url = "certificatelist.aspx";
        if (Request.QueryString["CE_ID"] != null && Request.QueryString["CE_ID"].ToString() != "")
        {
            long infoId = XYECOM.Core.MyConvert.GetInt64(Request.QueryString["CE_ID"].ToString());

            i = new Auditing().UpdatesAuditing(infoId, "U_Certificate", XYECOM.Model.AuditingState.Passed);

            if (i > 0)
            {
                if (this.U_ID.Value != "")
                {                   
                    //资料完善度
                    new XYECOM.Business.UserReg().UpdateUserPerfectPercent(XYECOM.Core.MyConvert.GetInt64(this.U_ID.Value));
                }
                Alert("审核成功！",url);
            }
            else
            {
                Alert("审核失败！", url);
            }
        }
    }
    #endregion

    protected void Button3_Click(object sender, EventArgs e)
    {
        if (XYECOM.Core.XYRequest.GetQueryString("backURL").Equals(""))
            Response.Redirect("certificatelist.aspx");
        else
            Response.Redirect(XYECOM.Core.XYRequest.GetQueryString("backURL"));
    }

}
