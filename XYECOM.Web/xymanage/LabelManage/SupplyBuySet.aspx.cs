using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using XYECOM.Core;

namespace XYECOM.Web.xymanage.LabelManage
{
    public partial class SupplyBuy : XYECOM.Web.BasePage.LabelBasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //防止调用页面缓存
            Response.Buffer = true;
            Response.ExpiresAbsolute = System.DateTime.Now.AddSeconds(-1);
            Response.Expires = 0;
            Response.CacheControl = "no-cache";

            CheckRole("label");

            if (!IsPostBack)
            {
                this.Button1.Attributes.Add("onclick", "javascript:return labelvalidate(1);");
            }
        }

        #region 分页类表
        protected void Button3_Click(object sender, EventArgs e)
        {
            string str = "";
            str += XYECOM.Core.Utils.LableSet(Function.LabelPrefix.Remove(Function.LabelPrefix.Length - 1, 1), "SupplyBuyPageList").Substring(1);
            str += XYECOM.Core.Utils.LableSet("调用数量", tbpagenum.Text.Trim());
            str += XYECOM.Core.Utils.LableSet("标题字数", tbpagetitlenum.Text.Trim());
            str += XYECOM.Core.Utils.LableSet("排序字段", ddlpageorder.SelectedValue);
            str += XYECOM.Core.Utils.LableSet("排序方式", ddlpagedesc.SelectedValue);
            str += XYECOM.Core.Utils.LableSet("日期格式", ddlpagedatetype.SelectedValue);
            str += XYECOM.Core.Utils.LableSet("信息描述字数", tbpageproductnum.Text.Trim());
            str += XYECOM.Core.Utils.LableSet("公司名称字数", tbpagecorporationnum.Text.Trim());
            str += XYECOM.Core.Utils.LableSet("求购所属地区", this.areatypeid2.Value.Trim());
            this.ClientScript.RegisterClientScriptBlock(GetType(), "", "<script type=\"text/javascript\">parent.setLabelValue(\"" + str + "\");//window.returnValue=\"" + str + "\"; window.close();</" + "" + "script>");
        }
        #endregion

        #region 基本列表
        protected void Button1_Click(object sender, EventArgs e)
        {
            string str = "";

            str += XYECOM.Core.Utils.LableSet(Function.LabelPrefix.Remove(Function.LabelPrefix.Length - 1, 1), "SupplyBuyList").Substring(1);
     
            str += XYECOM.Core.Utils.LableSet("调用数量", tbnum.Text.Trim());
            str += XYECOM.Core.Utils.LableSet("标题字数", tbtitlenum.Text.Trim());
           
            str += XYECOM.Core.Utils.LableSet("排序字段", ddlorderColumuName.SelectedValue);
            str += XYECOM.Core.Utils.LableSet("排序方式", ddlorder.SelectedValue);
            str += XYECOM.Core.Utils.LableSet("日期格式", ddldatetype.SelectedValue);
            str += XYECOM.Core.Utils.LableSet("信息描述字数", tbinfonum.Text.Trim());
            str += XYECOM.Core.Utils.LableSet("公司名称字数", tbcorporationNum.Text.Trim());
            str += XYECOM.Core.Utils.LableSet("求购所属地区", this.areatypeid.Value.Trim());
            this.ClientScript.RegisterClientScriptBlock(GetType(), "", "<script type=\"text/javascript\">parent.setLabelValue(\"" + str + "\");//window.returnValue=\"" + str + "\"; window.close();</" + "" + "script>");
        }
        #endregion

        protected override void InitPageValue(XYECOM.Web.BasePage.MyDictionary table)
        {
            string type = table["XY"].ToLower();
            #region 分页
            if ("SupplyBuyPageList".ToLower() == type)
            {
                this.tbpagenum.Text = table["调用数量"];
                this.tbpagetitlenum.Text = table["标题字数"];
                this.ddlpageorder.SelectedValue = table["排序字段"];
                this.ddlpagedesc.SelectedValue = table["排序方式"];
                this.ddlpagedatetype.SelectedValue = table["日期格式"];
                this.tbpageproductnum.Text = table["信息描述字数"];
                this.tbpagecorporationnum.Text = table["公司名称字数"];
                this.areatypeid2.Value = table["求购所属地区"];
                ClientScript.RegisterStartupScript(GetType(), "page", "myclick(\"li_page\",\"click\");", true);
            }
            #endregion
            #region 基本
            if ("SupplyBuyList".ToLower() == type)
            {
             
                this.tbnum.Text = table["调用数量"];
                this.tbtitlenum.Text = table["标题字数"];

                this.ddlorderColumuName.SelectedValue = table["排序字段"];
                this.ddlorder.SelectedValue = table["排序方式"];

                this.ddldatetype.SelectedValue = table["日期格式"];
                this.tbinfonum.Text = table["信息描述字数"];
                this.tbcorporationNum.Text = table["公司名称字数"];
                this.areatypeid.Value = table["求购所属地区"];

                ClientScript.RegisterStartupScript(GetType(), "page", "myclick(\"li_base\",\"click\");", true);
            }
            #endregion
      
        }
    }
}
