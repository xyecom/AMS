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

namespace XYECOM.Web.xymanage.LabelManage
{
    public partial class EditClassInfoLabel : XYECOM.Web.BasePage.ManagePage
    {
        private Model.ClassLabelInfo info;
        protected void Page_Load(object sender, EventArgs e)
        {
            CheckRole("label");

            if ("" != XYECOM.Core.XYRequest.GetQueryString("backURL"))
                backURL = XYECOM.Core.XYRequest.GetQueryString("backURL");
            else
                backURL = "ClassLabelList.aspx?";

            btnBack.Attributes["onclick"] = "location.href='" + backURL + "'";

            int id = Core.XYRequest.GetInt("id",0);
            if (id > 0)
            {
                info = new Business.ClassLabel().GetItem(id);
                if (!IsPostBack)
                {
                    txtBody.Text = info.Body;
                }
            }                
            else
            {
                Alert("参数错误！", backURL);
            }
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            info.Body = txtBody.Text.Trim();
            if (new Business.ClassLabel().Update(info) > 0)
                Alert("操作成功！", backURL);
            else
                Alert("发生错误，操作失败！", backURL);
        }

    }
}
