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
using XYECOM.Core;

namespace XYECOM.Web.xymanage.LabelManage
{
    public partial class VoteSet : XYECOM.Web.BasePage.LabelBasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //防止调用页面缓存
            Response.Buffer = true;
            Response.ExpiresAbsolute = System.DateTime.Now.AddSeconds(-1);
            Response.Expires = 0;
            Response.CacheControl = "no-cache";

            CheckRole("label");

            if (!Page.IsPostBack)
            {
         
            }
        }
        protected void btnVoteOK_Click(object sender, EventArgs e)
        {
            string str = "";

            str += XYECOM.Core.Utils.LableSet(Function.LabelPrefix.Remove(Function.LabelPrefix.Length - 1, 1), "VoteList").Substring(1);
            str += XYECOM.Core.Utils.LableSet("调用数量", txtVoteNumber.Text.Trim());
            str += XYECOM.Core.Utils.LableSet("排序字段", ddlVoteOrderFieldName.SelectedValue);
            str += XYECOM.Core.Utils.LableSet("排序方式", ddlVoteOrderType.SelectedValue);
            str += XYECOM.Core.Utils.LableSet("仅调用已开始未结束信息", chkOnlyNoEnd.Checked ? "1" : "0");

            this.ClientScript.RegisterClientScriptBlock(GetType(), "", "<script type=\"text/javascript\">parent.setLabelValue(\"" + str + "\");//window.returnValue=\"" + str + "\"; window.close();</" + "" + "script>");
        }

        protected override void InitPageValue(XYECOM.Web.BasePage.MyDictionary table)
        {            
            string type = table["XY"].ToLower();
            if ("VoteList".ToLower() == type)
            {

                this.txtVoteNumber.Text = table["调用数量"];
                this.ddlVoteOrderFieldName.SelectedValue = table["排序字段"];
                this.ddlVoteOrderType.SelectedValue = table["排序方式"];

                this.chkOnlyNoEnd.Checked = table["仅调用已开始未结束信息"] == "1" ? true : false;

                ClientScript.RegisterStartupScript(GetType(), "base", "myclick(\"li_base\",\"click\");", true);
            }
        }
    }
}
