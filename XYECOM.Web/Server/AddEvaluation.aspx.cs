using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XYECOM.Core;
using XYECOM.Model.AMS;
using XYECOM.Business.AMS;

namespace XYECOM.Web.Server
{
    public partial class AddEvaluation : XYECOM.Web.AppCode.UserCenter.Server
    {
        EvaluationManager manage = new EvaluationManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int credId = XYECOM.Core.XYRequest.GetQueryInt("Id", 0);
                if (credId <= 0)
                {
                    GotoMsgBoxPageForDynamicPage("请选择要评价的债权信息！", 1, "Index.aspx");
                }
                CreditInfo info = new CreditInfoManager().GetCreditInfoById(credId);
                if (info == null)
                {
                    GotoMsgBoxPageForDynamicPage("该债权信息已经评价过，不能重复评价！", 1, "Index.aspx");
                }
                this.hidCredId.Value = credId.ToString();
            }
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

        protected void btnOk_Click(object sender, EventArgs e)
        {
            int credId = MyConvert.GetInt32(this.hidCredId.Value);
            TenderInfo tenderInfo = new TenderInfoManager().GetTenderByCredId(credId);
            if (tenderInfo == null)
            {
                GotoMsgBoxPageForDynamicPage("请选择要评价的债权信息！", 1, "Index.aspx");
            }

            XYECOM.Model.AMS.Evaluation info = new Evaluation();
            info.CreditInfoId = credId;
            info.Description = this.txtDescription.Text.Trim();
            info.EvaluationResult = MyConvert.GetInt32(this.radEvaluationType.SelectedValue);
            info.User2Id = tenderInfo.LayerId;
            info.UserId = (int)userinfo.userid;
            info.UserName = userinfo.LoginName;
            info.User2Name = GetUserName(tenderInfo.LayerId);
            int result = manage.InsertEvaluation(info);
            if (result > 0)
            {
                new CreditInfoManager().UpdateEvaluationByCredId(credId, true);
                GotoMsgBoxPageForDynamicPage("评价成功！", 1, "Index.aspx");
            }
            else
            {
                GotoMsgBoxPageForDynamicPage("评价失败！", 1, "Index.aspx");
            }
        }
    }
}