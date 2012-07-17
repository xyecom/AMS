using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using XYECOM.Business.AMS;
using XYECOM.Core;
namespace XYECOM.Web.Creditor
{
    public partial class DeparForeclosedList : XYECOM.Web.AppCode.UserCenter.Creditor
    {
        protected ForeclosedManager manage = new ForeclosedManager();

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
        /// <summary>
        /// 绑定数据
        /// </summary>
        protected override void BindData()
        {
            string typeName = this.droTypeName.SelectedValue;
            string title = this.txtTitle.Text.Trim();

            this.lblMessage.Text = "";

            StringBuilder strWhere = new StringBuilder(" 1=1 and (DepartmentId in (select u_id from dbo.u_User where companyid = " + userinfo.userid + " and isPrimary = 'false'))");
            if (!string.IsNullOrEmpty(typeName) && typeName != "所有")
            {
                strWhere.Append(" and (ForeColseTypeName like '%" + typeName + "%')");
            }
            if (!string.IsNullOrEmpty(title))
            {
                strWhere.Append(" and (Title like '%" + title + "%')");
            }
            int totalRecord = 0;
            DataTable dt = XYECOM.Business.Utils.GetPaginationData("ForeclosedInfo", "ForeclosedId", "*", " CreateDate desc", strWhere.ToString(), this.Page1.PageSize, this.Page1.CurPage, out totalRecord);
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

        /// <summary>
        /// 搜索操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                int Id = XYECOM.Core.MyConvert.GetInt32(linkButton.CommandArgument);
                int count = GetBidInfoCountByForeID(Id);
                if (count > 0)
                {
                    GotoMsgBoxPageForDynamicPage("该抵债信息已经有人竞价不能删除！", 1, "ForeclosedList.aspx");
                }
                if (Id > 0)
                {
                    int result = manage.Delete(Id);
                    if (result > 0)
                    {
                        BindData();
                    }
                }
            }
        }

        /// <summary>
        /// 判断该抵债信息是否已过期
        /// </summary>
        /// <param name="endDate"></param>
        /// <returns></returns>
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