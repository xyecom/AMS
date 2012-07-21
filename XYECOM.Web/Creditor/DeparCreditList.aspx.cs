using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using XYECOM.Core;
using System.Data;
using XYECOM.Business.AMS;

namespace XYECOM.Web.Creditor
{
    public partial class DeparCreditList : XYECOM.Web.AppCode.UserCenter.Creditor
    {
        protected CreditInfoManager manage = new CreditInfoManager();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!userinfo.IsPrimary)
                {
                    GotoMsgBoxPageForDynamicPage("您无权操作该列表，请联系主账户！", 1, "Index.aspx");                    
                }
            }
        }
        protected override void BindData()
        {
            this.lblMessage.Text = "";
            int state = MyConvert.GetInt32(this.drpState.SelectedValue);
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
            StringBuilder strWhere = new StringBuilder(" 1=1 and (DepartId in (select u_id from dbo.u_User where companyid = "+userinfo.userid+" and isPrimary = 'false'))");
            if (state == -2)
            {
                strWhere.Append(" and ( ApprovaStatus ! =7)");
            }
            else
            {
                strWhere.Append(" and (ApprovaStatus = " + state + ")");
            }

            //开始日期
            if (begindate != "")
            {
                strWhere.Append(" and (CreateDate >= '" + begindate + "')");
            }
            //结束日期
            if (enddate != "")
            {
                strWhere.Append(" and (CreateDate <= '" + enddate + "')");
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
                this.rptList.DataSource = dt;
                this.rptList.DataBind();
            }
            else
            {
                this.lblMessage.Text = "没有相关信息记录";
                this.rptList.DataBind();
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
        /// 删除操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lbtnDelete_Click(object sender, EventArgs e)
        {
            LinkButton linkButton = (LinkButton)(sender as LinkButton);
            if (linkButton != null)
            {
                int Id = MyConvert.GetInt32(linkButton.CommandArgument);
                if (Id > 0)
                {
                    int result = manage.UpdateApprovaStatusByID(Id, XYECOM.Model.CreditState.Delete);
                    if (result > 0)
                    {
                        BindData();
                    }
                }
            }
        }

        protected string GetApprovaStatus(object state)
        {
            int stateId = MyConvert.GetInt32(state.ToString());
            Model.CreditState sta = (Model.CreditState)stateId;
            string name = "";
            switch (sta)
            {
                case XYECOM.Model.CreditState.Draft:
                    name = "草稿";
                    break;
                case XYECOM.Model.CreditState.Null:
                    name = "未审核";
                    break;
                case XYECOM.Model.CreditState.NoPass:
                    name = "审核未通过";
                    break;
                case XYECOM.Model.CreditState.Tender:
                    name = "投标中";
                    break;
                case XYECOM.Model.CreditState.InProgress:
                    name = "案件进行中";
                    break;
                case XYECOM.Model.CreditState.CreditConfirm:
                    name = "服务商案件完成等待债权人确认";
                    break;
                case XYECOM.Model.CreditState.CreditEnd:
                    name = "案件结束";
                    break;
                case XYECOM.Model.CreditState.Canceled:
                    name = "债权人取消案件";
                    break;
            }
            return name;
        }

        /// <summary>
        /// 根据债权信息ID获取该债权信息的投标个数
        /// </summary>
        /// <param name="CreditID"></param>
        /// <returns></returns>
        public int GetTenderCountByCreditID(object CreditID)
        {
            int id = MyConvert.GetInt32(CreditID.ToString());
            return new TenderInfoManager().GetTenderCountByCreditID(id);
        }

        /// <summary>
        /// 获取部门名称
        /// </summary>
        /// <param name="DeparID"></param>
        /// <returns></returns>
        public string GetDeparName(object DeparID)
        {
            int parId = MyConvert.GetInt32(DeparID.ToString());
            if (parId <= 0)
            {
                return "";
            }
            return new XYECOM.Business.UserInfo().GetPartNameById(parId);
        }
    }
}