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
using System.Xml;


public partial class xymanage_HtmlPageManage_HTMLSet : XYECOM.Web.BasePage.ManagePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        CheckRole("htmlpage");
    }

    protected override void BindData()
    {
        XYECOM.Configuration.HTML html = XYECOM.Configuration.HTML.Instance;

        if (html._HTMLSaveMode == XYECOM.Configuration.HTMLSaveMode.Default)
            this.rdoDefaultMode.Checked = true;
        else
            this.rdoUnifyMode.Checked = true;

        txtBaseDirName.Value = html.BaseDirName;
        txtDirPath.Value = html.Path;
        txtFileName.Value = html.FileName;
    }

    protected void btnOK_Click(object sender, EventArgs e)
    {
        XYECOM.Configuration.HTML html = XYECOM.Configuration.HTML.Instance;

        html._HTMLSaveMode = XYECOM.Configuration.HTMLSaveMode.Default;

        if (rdoUnifyMode.Checked) html._HTMLSaveMode = XYECOM.Configuration.HTMLSaveMode.Unify;

        html.BaseDirName = txtBaseDirName.Value.Trim();
        html.Path = txtDirPath.Value.Trim();
        html.FileName = txtFileName.Value.Trim();

        if (html.Update())
            Alert("配置保存成功！");
        else
            Alert("配置保存失败！请检查/config/HTML.config 文件读写权限！");
    }
}
