using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XYECOM.Model.AMS;
using XYECOM.Core;
using XYECOM.Model;

namespace XYECOM.Web.Creditor
{
    public partial class AddForeclosed : XYECOM.Web.AppCode.UserCenter.Creditor
    {
        XYECOM.Business.AMS.ForeclosedManager foreclosedManager = new Business.AMS.ForeclosedManager();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public static string GetUniqueNo()
        {
            //todo: 为实现
            Random r = new Random();
            var number = r.Next(9999);
            string no = string.Format("{0}{1}", "FLS", DateTime.Now.ToString("yyyyMMddhhmmssfff").PadLeft(20 - 2, '0'));
            return no;
        }

        protected void btnOK_Click(object sender, EventArgs e)
        {
            string title = this.txtTitle.Text.Trim();
            decimal linePrice = MyConvert.GetDecimal(this.txtLinePrice.Text.Trim());
            int areaId = MyConvert.GetInt32(this.areaid.Value);
            string typeName = this.droTypeName.SelectedValue;
            string address = this.txtAddress.Text.Trim();
            DateTime date = MyConvert.GetDateTime(this.endDate.Value);
            string description = this.txtDescription.Text.Trim();

            ForeclosedInfo info = new ForeclosedInfo();
            info.IdentityNumber = GetUniqueNo();
            info.Title = title;
            info.LinePrice = linePrice;
            info.AreaId = areaId;
            info.ForeColseTypeName = typeName;
            info.Address = address;
            info.EndDate = date;
            info.Description = description;
            info.State = (int)AuditingState.Null;
            info.DepartmentId =MyConvert.GetInt32(userinfo.userid.ToString());
            info.CompanyId = userinfo.CompanyId;
            info.CreateDate = DateTime.Now;
            this.udForeclosedInfo.InfoID= 

            bool isOK = foreclosedManager.InsertForeclosed(info);
            string gotoUrl = "ForeclosedList.aspx";
            if (isOK)
            {
                
                GotoMsgBoxPageForDynamicPage("添加抵债信息成功！", 1, gotoUrl);
            }
            else
            {
                GotoMsgBoxPageForDynamicPage("添加抵债信息失败！", 1, gotoUrl);
            }
        }
    }
}