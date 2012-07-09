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
                Alert("����(key)����Ϊ�գ�");
                return;
            }

            if (!isEdit && XYECOM.Configuration.CustomConfigField.Instance.IsExists(key))
            {
                Alert("����(key)�ظ�����ѡ���������ƣ�");
                return;
            }

            if (isEdit)
            {
                if (!XYECOM.Configuration.CustomConfigField.Instance.Update(key, value))
                {
                    Alert("�༭ʧ�ܣ�����/Config/Ŀ¼д��Ȩ�ޣ�");
                    return;
                }
            }
            else
            {
                if (!XYECOM.Configuration.CustomConfigField.Instance.Insert(key, value))
                {
                    Alert("����ʧ�ܣ�����/Config/Ŀ¼д��Ȩ�ޣ�");
                    return;
                }
            }

            Response.Redirect("CustomConfigField.aspx");
        }
    }
}
