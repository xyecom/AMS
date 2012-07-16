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
    public partial class UpdateForeclosed : XYECOM.Web.AppCode.UserCenter.Creditor
    {
        XYECOM.Business.AMS.ForeclosedManager manager = new Business.AMS.ForeclosedManager();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            { 
                int id =XYECOM.Core.XYRequest.GetInt("Id", 0);
                if (id <= 0)
                {
                    GotoMsgBoxPageForDynamicPage("该抵债信息不存在！", 1, "ForeclosedList.aspx");                    
                }
                this.hiddID.Value = id.ToString();
                BindData(id);
            }
        }

        public void BindData(int id)
        {
            ForeclosedInfo info = manager.GetForeclosedInfoById(id);
            if (info == null)
            {
                GotoMsgBoxPageForDynamicPage("该抵债信息不存在！", 1, "ForeclosedList.aspx");                    
            }
            this.txtTitle.Text = info.Title;
            this.txtAddress.Text = info.Address;
            this.txtLinePrice.Text = info.LinePrice.ToString();
            this.areaid.Value = info.AreaId.ToString();
            this.txtDescription.Text = info.Description;
            this.endDate.Value = info.EndDate.ToString("yyyy-MM-dd");
            this.droTypeName.SelectedValue = info.ForeColseTypeName;
            //supplyImages.InfoID = info.ForeclosedId;
        }

        protected void btnOK_Click(object sender, EventArgs e)
        {
            int id = MyConvert.GetInt32(this.hiddID.Value);
            if (id < 0)
            {
                GotoMsgBoxPageForDynamicPage("该抵债信息不存在！", 1, "ForeclosedList.aspx");                                
            }
            ForeclosedInfo info = manager.GetForeclosedInfoById(id);
            if (info == null)
            {
                GotoMsgBoxPageForDynamicPage("该抵债信息不存在！", 1, "ForeclosedList.aspx");
                return;                
            }
            string title = this.txtTitle.Text.Trim();
            decimal linePrice = MyConvert.GetDecimal(this.txtLinePrice.Text.Trim());
            int areaId = MyConvert.GetInt32(this.areaid.Value);
            string typeName = this.droTypeName.SelectedValue;
            string address = this.txtAddress.Text.Trim();
            DateTime date = MyConvert.GetDateTime(this.endDate.Value);
            string description = this.txtDescription.Text;
            info.Title = title;
            info.LinePrice = linePrice;
            //info.AreaId = areaId;
            info.AreaId = 10;
            info.ForeColseTypeName = typeName;
            info.Address = address;
            info.EndDate = date;
            info.Description = description;
            info.State = (int)AuditingState.Null;

            bool isOK = manager.UpdateForeclosedByID(info);

            if (isOK)
            {
                GotoMsgBoxPageForDynamicPage("抵债信息修改成功！", 1, "ForeclosedList.aspx");
            }
            else
            {
                GotoMsgBoxPageForDynamicPage("抵债信息修改失败！", 1, "ForeclosedList.aspx");
            }
        }
    }
}