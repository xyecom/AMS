using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XYECOM.Page;
using System.Text;
using System.Data;
using XYECOM.Core;
using XYECOM.Business.AMS;
using XYECOM.Business;

namespace XYECOM.Web
{
    public partial class CreditInfoDetail : ForeBasePage
    {
        CreditInfoManager manage = new CreditInfoManager();

        #region 页面加载
        protected void Page_Load(object sender, EventArgs e)
        {

            int Id = XYECOM.Core.XYRequest.GetQueryInt("ID", 0);
            if (Id <= 0)
            {
                GotoMsgBoxPageForDynamicPage("该债权信息不存在！", 1, "IndexCreditList.aspx");
            }
            if (!IsPostBack)
            {
                BindData(Id);
            }
        }
        #endregion

        #region 获取数据
        public void BindData(int id)
        {
            XYECOM.Model.AMS.CreditInfo info = manage.GetCreditInfoById(id);
            if (info == null)
            {
                GotoMsgBoxPageForDynamicPage("该债权信息不存在！", 1, "IndexCreditList.aspx");
            }

            if (null != info)
            {
                this.labAge.Text = info.Age.ToString();
                this.labAreaId.Text = new Area().GetItem(info.AreaId).FullNameAll;
                this.labCreateDate.Text = info.CreateDate.ToString();
                this.labCompanyName.Text = GetComName(info.DepartId);
                this.labUserName.Text = GetUserName(info.DepartId);
                this.labTitle.Text = info.Title;
                this.labArrears.Text = info.Arrears.ToString();
                this.labBounty.Text = info.Bounty.ToString();
                this.labCollectionPeriod.Text = info.CollectionPeriod;
                this.labDebtObligation.Text = info.DebtObligation;
                this.labDebtorName.Text = info.DebtorName;
                this.labDebtorReason.Text = info.DebtorReason;
                this.labDebtorTelpone.Text = info.DebtorTelpone;
                this.labIntroduction.Text = info.Introduction;
                this.labState.Text = GetApprovaStatus(info.ApprovaStatus);
                this.labIsConfirm.Text = info.IsConfirm ? "确认" : "不确认";
                this.labIsInLitigation.Text = info.IsInLitigation ? "是" : "否";
                this.labIsLitigationed.Text = info.IsLitigationed ? "是" : "否";
                this.labIsSelfCollection.Text = info.IsSelfCollection ? "是" : "否";
            }
        }
        #endregion
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
        /// 根据用户编号获取用户名称
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        protected string GetUserName(object userID)
        {
            int uId = MyConvert.GetInt32(userID.ToString());
            return new Business.UserInfo().GetCompNameByUId(uId);
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
    }
}