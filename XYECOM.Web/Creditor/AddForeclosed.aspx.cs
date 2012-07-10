using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XYECOM.Model.AMS;
using XYECOM.Core;

namespace XYECOM.Web.Creditor
{
    public partial class AddForeclosed : XYECOM.Web.AppCode.UserCenter.Creditor
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnOK_Click(object sender, EventArgs e)
        {
            string title = this.txtTitle.Text.Trim();
            decimal linePrice = MyConvert.GetDecimal(this.txtLinePrice.Text.Trim());
            int areaId = MyConvert.GetInt32(this.city.Value);
            string typeName = this.droTypeName.SelectedValue;
            string address = this.txtAddress.Text.Trim();
            DateTime date = MyConvert.GetDateTime(this.endDate.Value);
            string description = this.fckDescription.Value;

            ForeclosedInfo info = new ForeclosedInfo();
            info.Title = title;
            info.LinePrice = linePrice;
            info.AreaId = areaId;
            info.TypeName = typeName;
            info.Address = address;
            info.EndDate = date;
            info.Description = description;
        }
    }
}