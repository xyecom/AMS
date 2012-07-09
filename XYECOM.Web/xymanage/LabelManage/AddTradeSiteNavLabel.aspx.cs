using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace XYECOM.Web.xymanage.LabelManage
{
    public partial class AddTradeSiteNavLabel : XYECOM.Web.BasePage.ManagePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CheckRole("label");
        }

        protected override void BindData()
        {
            List<Model.XYClassInfo> lists = Business.XYClass.GetItemsAll("trade");

            foreach (Model.XYClassInfo info in lists)
            {
                this.chklstTrade.Items.Add(new ListItem(info.ClassName, info.ClassId.ToString()));
            }
        }


        protected void btnOK_Click(object sender, EventArgs e)
        {
            string labelName = "XY_TSN_" + txtName.Text.Trim();

            string CNName = txtCNName.Text.Trim();

            if (labelName.Equals("") || CNName.Equals(""))
            {
                Alert("标签名称及中文名称不能为空！");
                return;
            }

            Model.ClassLabelInfo info = new XYECOM.Model.ClassLabelInfo();

            System.Text.StringBuilder body = new System.Text.StringBuilder("");

            body.Append("<ul>").Append(((char)10).ToString());

            for (int i = 0; i < chklstTrade.Items.Count; i++)
            {
                if (chklstTrade.Items[i].Selected)
                {
                    body.Append("<li><a href='[TSN:" + chklstTrade.Items[i].Value + "]' target='_blank'>" + chklstTrade.Items[i].Text + "</a></li>");
                    body.Append(((char)10).ToString());
                }
            }

            body.Append("</ul>");

            info.Body = body.ToString();
            info.Name = labelName;
            info.CNName = CNName;
            info.TableName = "";

            new Business.ClassLabel().Insert(info);

            Response.Redirect("ClassLabelList.aspx");

        }
    }
}
