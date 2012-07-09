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

namespace XYECOM.Web.xymanage.Global
{
    public partial class EditCustomConfigField : XYECOM.Web.BasePage.ManagePage
    {
        private static bool isEdit = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            CheckRole("customconfigfield");

            if (!IsPostBack)
            {
                string key = XYECOM.Core.XYRequest.GetQueryString("key");

                if (key != "")
                {
                    isEdit = true;
                    BindData(key);
                }
                else {
                    isEdit = false;
                }
            }
        }

        private void BindData(string key) 
        {
            this.txtKey.Text = key;
            this.txtValue.Text = XYECOM.Configuration.CustomConfigField.Instance.Get(key);
        }

        protected void btnOK_Click(object sender, EventArgs e)
        {
            string key = txtKey.Text.Trim();
            string value = txtValue.Text.Trim();

            if (value.Length > 1000) value = value.Substring(0, 1000);

            if (key.Equals(""))
            {
                Alert("名称(key)不能为空！");
                return;
            }

            if (!isEdit && XYECOM.Configuration.CustomConfigField.Instance.IsExists(key))
            {
                Alert("名称(key)重复，请选择其他名称！");
                return;
            }

            if (isEdit)
            {
                if (!XYECOM.Configuration.CustomConfigField.Instance.Update(key, value))
                {
                    Alert("编辑失败，请检查/Config/目录写入权限！");
                    return;
                }
            }
            else
            {
                if (!XYECOM.Configuration.CustomConfigField.Instance.Insert(key, value))
                {
                    Alert("新增失败，请检查/Config/目录写入权限！");
                    return;
                }
            }

            Response.Redirect("CustomConfigField.aspx");
        }
    }
}
