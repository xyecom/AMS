using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace XYECOM.Web.xymanage.Interface
{
    public partial class EditJsInterface : XYECOM.Web.BasePage.ManagePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CheckRole("interface");
        }

        protected override void BindData()
        {
            string key = Request.QueryString["key"];
            XYECOM.Configuration.JsInterfaceInfo jsInfo = null;
            if (!string.IsNullOrEmpty(key))
            {
                XYECOM.Configuration.JsInterface js = XYECOM.Configuration.JsInterface.Instance;

                jsInfo = js.Get(key);
            }

            if (jsInfo != null)
            {
                this.txtKey.ReadOnly = true;
            }
            else
            {
                this.txtKey.ReadOnly = false;
                jsInfo = new XYECOM.Configuration.JsInterfaceInfo();
            }
            this.hidKeyName.Value = jsInfo.Key;
            this.rdoEnabled.Checked = jsInfo.Enable;
            this.rdoDisabled.Checked = !jsInfo.Enable;
            this.txtValue.Text = jsInfo.Value;
            this.txtKey.Text = jsInfo.Key;
        }

        protected void btnOK_Click(object sender, EventArgs e)
        {
            string key = this.hidKeyName.Value;
            XYECOM.Configuration.JsInterface js = XYECOM.Configuration.JsInterface.Instance;
            XYECOM.Configuration.JsInterfaceInfo jsInfo = null;
            if (!string.IsNullOrEmpty(key))
            {
                jsInfo = js.Get(key);
            }
            bool isInsert = true;
            if (jsInfo != null)
            {
                isInsert = false;
            }
            else
            {
                jsInfo = new XYECOM.Configuration.JsInterfaceInfo();
            }
            string newkey = this.txtKey.Text.Trim();
            jsInfo.Key = newkey;
            jsInfo.Value = this.txtValue.Text.Trim();
            jsInfo.Enable = this.rdoEnabled.Checked;

            bool res = false;
            if (isInsert)
            {
                if (js.IsExists(newkey))
                {
                    Alert("已经存在该索引！", "EditJsInterface.aspx");
                    return;
                }
                res = js.Insert(jsInfo);
            }
            else
            {
                res = js.Update(jsInfo);
            }

            if (res)
            {
                Alert("保存成功！", "JsInterface.aspx");
                return;
            }
            else
            {
                Alert("保存失败！", "JsInterface.aspx");
                return;
            }
        }
    }
}
