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
using System.Text;

namespace XYECOM.Web.xymanage.TemplatesManage
{
    public partial class ShopTemplateManage : XYECOM.Web.BasePage.ManagePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CheckRole("template");
        }

        protected DataTable GetSkins()
        {
            XYECOM.Template.ShopTemplate shop = new XYECOM.Template.ShopTemplate();

            DataTable table = shop.GetSkins();

            return table;
        }

        protected DataTable GetThemes(string dirName)
        {
            XYECOM.Template.ShopTemplate shop = new XYECOM.Template.ShopTemplate();

            DataTable tableThemes = shop.GetThemes(dirName);

            return tableThemes;
        }
    }
}
