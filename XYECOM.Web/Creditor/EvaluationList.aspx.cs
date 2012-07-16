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
    public partial class EvaluationList : XYECOM.Web.AppCode.UserCenter.Creditor
    {
        protected bool isServer = false;
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected override void BindData()
        {
            StringBuilder strWhere = new StringBuilder(" 1=1");
            string evaType = this.radEvaType.SelectedValue;
            if (evaType == "server")
            {
                isServer = true;
                strWhere.Append(" and (User2Id= " + userinfo.userid + ")");
            }
            else
            {
                strWhere.Append(" and (UserId= " + userinfo.userid + ")");
            }
            int totalRecord = 0;
            DataTable dt = XYECOM.Business.Utils.GetPaginationData("Evaluation", "EvaluationId", "*", " EvaluationId desc", strWhere.ToString(), this.Page1.PageSize, this.Page1.CurPage, out totalRecord);
            this.Page1.RecTotal = totalRecord;

            if (dt.Rows.Count > 0)
            {
                this.rptList.DataSource = dt;
                this.rptList.DataBind();
            }
            else
            {
                this.lblMessage.Text = "还没人对其评价";
                this.rptList.DataBind();
            }
        }


        /// <summary>
        /// 根据用户编号获取公司名称
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        protected string GetComName(object userID)
        {
            int uId = MyConvert.GetInt32(userID.ToString());
            return new Business.UserInfo().GetCompNameByUId(uId);
        }

        /// <summary>
        /// 获取债权标题
        /// </summary>
        /// <param name="credId"></param>
        /// <returns></returns>
        protected string GetCreditTitle(object credId)
        {
            int id = MyConvert.GetInt32(credId.ToString());
            return new CreditInfoManager().GetCreditInfoById(id).Title;
        }
    }
}