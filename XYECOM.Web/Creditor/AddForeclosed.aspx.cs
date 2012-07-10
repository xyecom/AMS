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
            string no ="FLS"+ number.ToString();
            if (no.Length < 7)
            {
                int length = 7 - no.Length;
                no.PadRight(length, '0');
            }
            return no;
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
            info.IdentityNumber = GetUniqueNo();
            info.Title = title;
            info.LinePrice = linePrice;
            info.AreaId = areaId;
            info.ForeColseTypeName = typeName;
            info.Address = address;
            info.EndDate = date;
            info.Description = description;
            info.State = (int)AuditingState.Null;
            //info.UserId = userinfo;   //TODO:缺少所属公司编号
            info.UserId = userinfo.userid;
            info.CreateDate = DateTime.Now;

            bool isOK = foreclosedManager.InsertForeclosed(info);

            if (isOK)
            {
                string gotoUrl = "/Creditor/index.aspx";
                GotoMsgBoxPageForDynamicPage("添加抵债信息成功！", 1, gotoUrl);
            }
            else
            {
                Alert("添加抵债信息失败！");
            }
        }
    }
}