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
    public partial class IndexCreditList1 : ForeBasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected override void BindData()
        {
            this.lblMessage.Text = "";
            string areid = this.city.Value;
            string arrears = this.drpArrears.SelectedValue;
            string title = this.txtTitle.Text.Trim();
            StringBuilder strWhere = new StringBuilder(" 1=1 and ( ApprovaStatus  =2)");
            if (arrears != "所有")
            {
                if (arrears == "小于1万")
                {
                    strWhere.Append(" and ( Arrears <=10000)");
                }
                else if (arrears == "大于1万小于5万")
                {
                    strWhere.Append(" and (Arrears<=50000 and Arrears>=10000)");
                }
                else if (arrears == "大于5万小于10万")
                {
                    strWhere.Append(" and (Arrears<=100000 and Arrears>=50000)");
                }
                else if (arrears == "大于10万")
                {
                    strWhere.Append(" and (Arrears>=100000)");
                }
            }
            if (!string.IsNullOrEmpty(title))
            {
                strWhere.Append(" and (Title like '%" + title + "%')");
            }
            int totalRecord = 0;
            DataTable dt = XYECOM.Business.Utils.GetPaginationData("CreditInfo", "CreditId", "*", " CreateDate desc", strWhere.ToString(), this.Page1.PageSize, this.Page1.CurPage, out totalRecord);
            this.Page1.RecTotal = totalRecord;

            if (dt.Rows.Count > 0)
            {
                this.dlCreditList.DataSource = dt;
                this.dlCreditList.DataBind();
            }
            else
            {
                this.lblMessage.Text = "没有相关信息记录";
                this.dlCreditList.DataBind();
            }
        }

        public string GetEndDate(object endDate)
        {
            DateTime date = XYECOM.Core.MyConvert.GetDateTime(endDate.ToString());
            if (date.CompareTo(DateTime.Now) < 0)
            {
                return "已过期";
            }
            else
            {
                return date.ToString("yyyy-MM-dd");
            }
        }

        #region 分页相关代码

        protected void Page1_PageChanged(object sender, System.EventArgs e)
        {
            this.BindData();
        }
        #endregion

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindData();
        }

        /// <summary>
        /// 获取物品地址
        /// </summary>
        /// <param name="areaId"></param>
        /// <returns></returns>
        public string GetAreaIdFull(object areaId)
        {
            int aId = MyConvert.GetInt32(areaId.ToString());
            return new Area().GetItem(aId).FullNameAll;
        }

        /// <summary>
        /// 根据债权信息ID获取该债权信息的投标个数
        /// </summary>
        /// <param name="CreditID"></param>
        /// <returns></returns>
        public int GetTenderCountByCreditID(object CreditID)
        {
            int id = MyConvert.GetInt32(CreditID.ToString());
            return new XYECOM.Business.AMS.TenderInfoManager().GetTenderCountByCreditID(id);
        }

        /// <summary>
        /// 根据用户编号获取用户名称
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        protected string GetUserName(object userID)
        {
            int uId = MyConvert.GetInt32(userID.ToString());
            return new Business.UserInfo().GetCompNameByUId(uId);
        }
    }
}