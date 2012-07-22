using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XYECOM.Model.AMS;
using XYECOM.Core;
using XYECOM.Model;
using XYECOM.Business.AMS;
using System.Text;
using System.Data;

namespace XYECOM.Web.Creditor
{
    public partial class ForeclosedDetail : XYECOM.Web.AppCode.UserCenter.Creditor
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
                    GotoMsgBoxPageForDynamicPage("该抵债信息不存在！", 1, "Index.aspx");
                }
                this.hidId.Value = id.ToString();
                BindData(id);
            }
        }

        #region 分页相关代码

        protected void Page1_PageChanged(object sender, System.EventArgs e)
        {
            int foreId = MyConvert.GetInt32(this.hidId.Value);
            this.BindData(foreId);
        }
        #endregion

        public void BindData(int id)
        {
            XYECOM.Model.AMS.ForeclosedInfo info = foreManage.GetForeclosedInfoById(id);
            if (info == null)
            {
                GotoMsgBoxPageForDynamicPage("该抵债信息不存在！", 1, "Index.aspx");
            }
            if (info.State != (int)AuditingState.Passed)
            {
                GotoMsgBoxPageForDynamicPage("该抵债信息未通过审核！", 1, "Index.aspx");
            }
            if (null != info)
            {
                this.labAddress.Text = info.Address;
                this.labTitle.Text = info.Title;
                this.labEndDate.Text = info.EndDate.ToString("yyyy-MM-dd");
                this.labHighPrice.Text = info.HighPrice.ToString();
                this.labLinePrice.Text = info.LinePrice.ToString();
                this.labCount.Text = GetBidInfoCountByForeID(info.ForeclosedId).ToString();
            }
            DataTable price = XYECOM.Business.Attachment.GetAllImgHref(AttachmentItem.ForeclosedInfo, info.ForeclosedId);
            if (price.Rows.Count > 0)
            {
                this.rpPrice.DataSource = price;
                this.rpPrice.DataBind();
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
        /// <summary>
        ///获取竞价个数
        /// </summary>
        /// <param name="foreId"></param>
        /// <returns></returns>
        public int GetBidInfoCountByForeID(object foreId)
        {
            int id = XYECOM.Core.MyConvert.GetInt32(foreId.ToString());
            if (id <= 0)
            {
                return 0;
            }
            return new BidInfoManager().GetBidInfoCountByForeID(id);
        }
    }
}