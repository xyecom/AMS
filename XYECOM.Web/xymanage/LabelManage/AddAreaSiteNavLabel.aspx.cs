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
    public partial class AddAreaSiteNavLabelaspx : XYECOM.Web.BasePage.ManagePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CheckRole("label");
        }

        protected override void BindData()
        {
            DataTable table = new Business.AreaSite().GetDataTable();

            string areaName = "";

            Business.Area areaBLL = new XYECOM.Business.Area();
            Model.AreaInfo area = null;

            foreach (DataRow row in table.Rows)
            {
                int areaId = Core.MyConvert.GetInt32(row["areaId"].ToString());

                area = areaBLL.GetItem(areaId);

                if (area == null) continue;

                areaName = area.Name;

                this.chklstAreaSite.Items.Add(new ListItem(areaName,row["id"].ToString()));
            }
        }

        protected void btnOK_Click(object sender, EventArgs e)
        {
            string labelName = "XY_ASN_" + txtName.Text.Trim();

            string CNName = txtCNName.Text.Trim();

            if (labelName.Equals("") || CNName.Equals(""))
            {
                Alert("标签名称及中文名称不能为空！");
                return;
            }

            Model.ClassLabelInfo info = new XYECOM.Model.ClassLabelInfo();

            System.Text.StringBuilder  body = new System.Text.StringBuilder("");

            body.Append("<ul>").Append(((char)10).ToString());

            for (int i = 0; i < chklstAreaSite.Items.Count; i++)
            {
                if (chklstAreaSite.Items[i].Selected)
                {
                    body.Append("<li><a href='[ASN:" + chklstAreaSite.Items[i].Value + "]' target='_blank'>" + chklstAreaSite.Items[i].Text + "</a></li>");
                    body.Append(((char)10).ToString());
                }
            }

            body.Append("</ul>");

            info.Body = body.ToString();
            info.Name = labelName;
            info.CNName = CNName;
            info.TableName = "xy_areasite";

            new Business.ClassLabel().Insert(info);

            Response.Redirect("ClassLabelList.aspx");
        }
    }
}
