using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XYECOM.Page;
using System.Text;
using System.Data;
using XYECOM.Core;
using XYECOM.Business;

namespace XYECOM.Web
{
    public partial class ForeclosedDetail : ForeBasePage
    {
        XYECOM.Business.AMS.ForeclosedManager foreManage = new Business.AMS.ForeclosedManager();
        XYECOM.Business.AMS.BidInfoManager bidInfoManage = new Business.AMS.BidInfoManager();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int id = XYECOM.Core.XYRequest.GetInt("Id", 0);
                if (id <= 0)
                {
                    GotoMsgBoxPageForDynamicPage("该抵债信息不存在！", 1, "ForeclosedList.aspx");
                }
                this.hidId.Value = id.ToString();
                BindData(id);
            }
        }

        #region 分页相关代码

        protected void Page1_PageChanged(object sender, System.EventArgs e)
        {
            this.BindData();
        }
        #endregion

        public void BindData(int id)
        {
            XYECOM.Model.AMS.ForeclosedInfo info = foreManage.GetForeclosedInfoById(id);
            if (info == null)
            {
                GotoMsgBoxPageForDynamicPage("该抵债信息不存在！", 1, "ForeclosedList.aspx");
            }

            if (null != info)
            {
                this.labAddress.Text = info.Address;
                this.labAreid.Text = new Area().GetItem(info.AreaId).FullNameAll;
                this.labTitle.Text = info.Title;
                this.labIdentityNumber.Text = info.IdentityNumber;
                this.labEndDate.Text = info.EndDate.ToString("yyyy-MM-dd");
                this.labHighPrice.Text = info.HighPrice.ToString();
                this.labLinePrice.Text = info.LinePrice.ToString();
                this.spnDescription.InnerHtml = info.Description;
            }

            DataTable dtLing = bidInfoManage.GetLingXian(id);
            if (dtLing.Rows.Count > 0)
            {
                this.rptList.DataSource = dtLing;
                this.rptList.DataBind();
            }
            else
            {
                this.lblMessage.Text = "还没人出价";
                this.rptList.DataBind();
            }

            StringBuilder strWhere = new StringBuilder(" 1=1 and (ForeclosedId = " + id + ") and ( BidId not in (select top 3 BidId from bidinfo where ForeclosedId = " + id + " order by Price desc))");
            int totalRecord = 0;
            DataTable dt = XYECOM.Business.Utils.GetPaginationData("BidInfo", "BidId", "*", " Price desc", strWhere.ToString(), this.Page1.PageSize, this.Page1.CurPage, out totalRecord);
            this.Page1.RecTotal = totalRecord;

            if (dt.Rows.Count > 0)
            {
                this.rpChuJu.DataSource = dt;
                this.rpChuJu.DataBind();
            }
        }

        /// <summary>
        /// 联系方式
        /// </summary>
        /// <param name="contact"></param>
        /// <returns></returns>
        public string GetContact(string contact)
        {
            int adminID = 0;
            if (Session["UM_ID"] != null)
            {
                adminID = MyConvert.GetInt32(Session["UM_ID"].ToString());
            }
            int foreId = MyConvert.GetInt32(this.hidId.Value);
            XYECOM.Model.AMS.ForeclosedInfo info = foreManage.GetForeclosedInfoById(foreId);
            XYECOM.Model.GeneralUserInfo userInfo = Business.CheckUser.UserInfo;
            if ((userInfo != null && userInfo.userid == info.DepartmentId) || adminID != 0)
            {
                return contact;
            }
            else
            {
                return contact.Substring(0, 6) + "*****";
            }
        }

        protected void btnOK_Click(object sender, EventArgs e)
        {
            int foreId = MyConvert.GetInt32(this.hidId.Value);
            if (foreId <= 0)
            {
                GotoMsgBoxPageForDynamicPage("该抵债信息不存在！", 1, "Index.aspx");
            }
            DateTime date = XYECOM.Core.MyConvert.GetDateTime(labEndDate.Text);
            if (date.CompareTo(DateTime.Now) < 0)
            {
                GotoMsgBoxPageForDynamicPage("该抵债信息已过期不能进行竞标！", 1, "Index.aspx");
            }
            XYECOM.Model.AMS.ForeclosedInfo info = foreManage.GetForeclosedInfoById(foreId);
            XYECOM.Model.GeneralUserInfo userInfo = Business.CheckUser.UserInfo;
            if (userInfo != null && userInfo.userid == info.DepartmentId)
            {
                GotoMsgBoxPageForDynamicPage("不能对自己的抵债信息发布竞价！", 1, "Index.aspx");
            }
            string name = this.txtName.Text.Trim();
            decimal price = MyConvert.GetDecimal(this.txtPrice.Text.Trim());
            string address = this.txtAddress.Text.Trim();
            string contact = this.txtContact.Text.Trim();
            string remark = this.txtRemark.Text.Trim();
            XYECOM.Model.AMS.BidInfo bidInfo = new Model.AMS.BidInfo();
            bidInfo.ForeclosedId = foreId;
            bidInfo.Contact = contact;
            bidInfo.FromAddress = address;
            bidInfo.Price = price;
            bidInfo.PriceDate = DateTime.Now;
            bidInfo.Remark = remark;
            bool isok = bidInfoManage.InserBidInfo(bidInfo);
            if (isok)
            {
                GotoMsgBoxPageForDynamicPage("报价成功！", 1, "ForeclosedDetail.aspx?Id=" + foreId);
            }
            else
            {
                GotoMsgBoxPageForDynamicPage("报价失败！", 1, "ForeclosedDetail.aspx?Id=" + foreId);
            }
        }

    }
}