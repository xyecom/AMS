using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using XYECOM.Core;
using System.Data;

namespace XYECOM.Web.Server
{
    public partial class InProgressCreditList : XYECOM.Web.AppCode.UserCenter.Server
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        protected override void BindData()
        {
            this.lblMessage.Text = "";
            string title = this.txtTitle.Text.Trim();
            string begindate = this.bgdate.Value;
            string enddate = this.egdate.Value;
            try
            {
                DateTime bgdate = Convert.ToDateTime(begindate);
            }
            catch (Exception)
            {
                begindate = "";
            }
            try
            {
                DateTime eddate = Convert.ToDateTime(enddate);
            }
            catch (Exception)
            {
                enddate = "";
            }
            StringBuilder strWhere = new StringBuilder(" 1=1 and LayerId = " + userinfo.userid + "and CreditInfoId in (select creditId from dbo.CreditInfo where approvastatus = 3)");
            //开始日期
            if (begindate != "")
            {
                strWhere.Append(" and (TenderDate >= '" + begindate + "')");
            }
            //结束日期
            if (enddate != "")
            {
                strWhere.Append(" and (TenderDate <= '" + enddate + "')");
            }
            if (!string.IsNullOrEmpty(title))
            {
                strWhere.Append(" and CreditInfoId in (select creditId from dbo.CreditInfo where Title like '%" + title + "%')");
            }
            int totalRecord = 0;
            DataTable dt = XYECOM.Business.Utils.GetPaginationData("TenderInfo", "TenderId", "*", " TenderDate desc", strWhere.ToString(), this.Page1.PageSize, this.Page1.CurPage, out totalRecord);
            this.Page1.RecTotal = totalRecord;

            if (dt.Rows.Count > 0)
            {
                this.rptList.DataSource = dt;
                this.rptList.DataBind();
            }
            else
            {
                this.lblMessage.Text = "没有相关信息记录";
                this.rptList.DataBind();
            }
        }

        /// <summary>
        /// 根据债权ID获取债权信息
        /// </summary>
        /// <param name="credID"></param>
        /// <returns></returns>
        public XYECOM.Model.AMS.CreditInfo GetCreditInfoByCredID(object credID)
        {
            int id = XYECOM.Core.MyConvert.GetInt32(credID.ToString());
            XYECOM.Model.AMS.CreditInfo info = new Model.AMS.CreditInfo();
            if (id <= 0)
            {
                return info;
            }
            return new XYECOM.Business.AMS.CreditInfoManager().GetCreditInfoById(id);
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
    }
}