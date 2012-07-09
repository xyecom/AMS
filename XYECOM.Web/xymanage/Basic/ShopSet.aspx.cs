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

namespace XYECOM.Web.xymanage.Basic
{
    public partial class ShopSet : XYECOM.Web.BasePage.ManagePage
    {
        XYECOM.Configuration.Shop shopObj = XYECOM.Configuration.Shop.Instance;

        protected void Page_Load(object sender, EventArgs e)
        {
            CheckRole("basic");
        }

        protected override void BindData()
        {            
            this.txtProductPageSize.Text = shopObj.ProductPageSize.ToString();
            this.txtInfoPageSize.Text = shopObj.InfoPageSize.ToString();
            this.txtNewsPageSize.Text = shopObj.NewsPageSize.ToString();
            this.txtBrandPageSize.Text = shopObj.BrandPageSize.ToString();
            this.txtJobPageSize.Text = shopObj.JobPageSize.ToString();
        }

        protected void btnok_Click(object sender, EventArgs e)
        {
            shopObj.ProductPageSize = Core.MyConvert.GetInt32(this.txtProductPageSize.Text.Trim());
            shopObj.InfoPageSize = Core.MyConvert.GetInt32(this.txtInfoPageSize.Text.Trim());
            shopObj.NewsPageSize = Core.MyConvert.GetInt32(this.txtNewsPageSize.Text.Trim());
            shopObj.BrandPageSize = Core.MyConvert.GetInt32(this.txtBrandPageSize.Text.Trim());
            shopObj.JobPageSize = Core.MyConvert.GetInt32(this.txtJobPageSize.Text.Trim());

            bool update = shopObj.Update();

            if (!update)
                Alert("设置失败，请检查/Config/目录可写属性！");
            else
                Alert("设置成功！");
        }
    }
}
