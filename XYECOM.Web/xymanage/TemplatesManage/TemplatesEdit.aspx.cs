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
using System.Text;
using XYECOM.Core;
using XYECOM.Business;

public partial class xymanage_TemplatesManage_TemplatesEdit : XYECOM.Web.BasePage.ManagePage
{
    public string path;

    protected void Page_Load(object sender, EventArgs e)
    {
        CheckRole("template");
        
        path = XYRequest.GetString("path");

        if (!this.Page.IsPostBack)
        {
            if (this.path == "")
            {
                this.ClientScript.RegisterClientScriptBlock(this.GetType(), "", "<script>closewindows();</script>");
            }

            string fileFullName = base.Server.MapPath(path);

            FileInfo fi = new FileInfo(fileFullName);

            if ((!fi.Extension.Equals(".htm") && !fi.Extension.Equals(".css")))
            {
                this.ClientScript.RegisterClientScriptBlock(this.GetType(), "", "<script>alert('非法操作!');closewindows();</script>");
                return;
            }

            using (StreamReader reader = new StreamReader(base.Server.MapPath(path), Encoding.Default))
            {
                txtContent.Text = reader.ReadToEnd();
                reader.Close();
            }
        }
    }
     
    protected void btnOK_Click(object sender, EventArgs e)
    {
        using (FileStream stream = new FileStream(Server.MapPath(path), FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite))
        {
            byte[] bytes = Encoding.Default.GetBytes(this.txtContent.Text);
            stream.Write(bytes, 0, bytes.Length);
            stream.Close();
        }
        this.ClientScript.RegisterClientScriptBlock(this.GetType(), "", "<script>parent.TemplatesClose();</script>");
    }
}
