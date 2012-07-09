using System;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using XYECOM.Core;

public partial class UploadImage : System.Web.UI.Page
{
    private XYECOM.Configuration.WebInfo webInfo = XYECOM.Configuration.WebInfo.Instance;

    protected void Page_Load(object sender, EventArgs e)
    {
        //防止调用页面缓存
        HttpContext.Current.Response.Buffer = true;
        HttpContext.Current.Response.ExpiresAbsolute = System.DateTime.Now.AddSeconds(-1);
        HttpContext.Current.Response.Expires = 0;

        if (!XYECOM.Business.CheckUser.CheckUserLogin())
        {
            if (!XYECOM.Business.CheckUser.CheckManageSessionState())
            {
                Response.Write("您还没有登录，请先登录");
                Response.End();
            }
        }

        if (!IsPostBack)
        {
            if (XYECOM.Core.XYRequest.GetQueryString("fileType").Equals("file"))
            {
                this.lblMessage.Text = "允许上传文件类型:" + webInfo.UploadAdjunctType + "<br/>"
                        + "允许上传文件大小:" + webInfo.UploadAdjunctSize + " KB";
            }
            else
            {
                this.lblMessage.Text = "允许上传图片类型:" + webInfo.UploadFileType + "<br/>"
                        + "允许上传图片大小:" + webInfo.UploadFileSize + " KB";
            }
        }
    }

    protected void btnOK_Click(object sender, EventArgs e)
    {
        string result = "";

        string fileType = XYECOM.Core.XYRequest.GetQueryString("filetype");

        if(fileType.Equals("file"))
            result = XYECOM.Page.Upload.UploadManage._UploadFile();
        else
            result = XYECOM.Page.Upload.UploadManage.UploadFile();

        if ("" != result)
            ClientScript.RegisterClientScriptBlock(GetType(), "", result);
    }
}