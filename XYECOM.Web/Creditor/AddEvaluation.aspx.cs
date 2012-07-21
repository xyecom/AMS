using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XYECOM.Model.AMS;
using XYECOM.Core;
using XYECOM.Model;
using XYECOM.Business.AMS;
using XYECOM.Business;

namespace XYECOM.Web.Creditor
{
    public partial class AddEvaluation : XYECOM.Web.AppCode.UserCenter.Creditor
    {
        EvaluationManager manage = new EvaluationManager();
        Business.UserInfo userInfoManage = new Business.UserInfo();
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
            info.User2Name = userInfoManage.GetUserNameByID(tenderInfo.LayerId);
            int result = manage.InsertEvaluation(info);
            if (result > 0)
            {
                new CreditInfoManager().UpdateEvaluationByCredId(credId, false);
                GotoMsgBoxPageForDynamicPage("评价成功！", 1, "Index.aspx");
            }
            else
            {
                GotoMsgBoxPageForDynamicPage("评价失败！", 1, "Index.aspx");
            }
        }
    }
}