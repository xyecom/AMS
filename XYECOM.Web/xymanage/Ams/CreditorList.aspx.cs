using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using XYECOM.Core;
using XYECOM.Business;
using XYECOM.Business.AMS;

namespace XYECOM.Web.xymanage
{
    public partial class CreditorList : XYECOM.Web.BasePage.ManagePage
    {
        CreditInfoManager coreManage = new CreditInfoManager();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.txtPageSize.Text != "")
            {
                this.Page1.PageSize = XYECOM.Core.MyConvert.GetInt32(this.txtPageSize.Text);
            }
            else
            {
                this.Page1.PageSize = 20;
            }
            if (!IsPostBack)
            {
                SetValueByquery(Page1, "page");
                SetValueByquery(txtKeyword, "keyword");
                SetValueByquery(drpState, "state");
                SetValueByquery(txtPageSize, "pagesize");
                SetValueByquery(txtdays, "isdays");
                SetValueByquery(cbdays, "cbday", "1");
                SetValueByquery(txtId, "Id");

                this.Button2.Attributes.Add("onclick", "javascript:return del();");
                this.btnIsPass.Attributes.Add("onclick", "javascript:return ChkSelete();");
                this.btnNotIsPass.Attributes.Add("onclick", "javascript:return ChkSelete();");
            }
        }

        #region 绑定数据
        protected override void BindData()
        {
            int state = MyConvert.GetInt32(this.drpState.SelectedValue);
            //设置编辑或查看后要返回当前页面的状态
            backURL = XYECOM.Core.Utils.JSEscape(
                "CreditorList.aspx?" +
                "page=" + Page1.CurPage.ToString() +
                "&keyWord=" + txtKeyword.Text.Trim() +
                "&State=" + drpState.Text.Trim() +
                "&pagesize=" + txtPageSize.Text +
                "&cbday=" + cbdays.Checked.ToString().ToLower() +
                "&Id=" + txtId.Text.Trim() +
                "&isdays=" + txtdays.Text + "");

            this.lbmanage.Text = "";

            string strwhere = " 1=1";
            //标题
            if (this.txtKeyword.Text.Trim() != "")
            {
                strwhere += " and  title like '%" + this.txtKeyword.Text.Trim() + "%' ";
            }
            //案件状态
            if (state == -2)
            {
                strwhere += " and ( ApprovaStatus ! =7  and  ApprovaStatus ! =0)";
            }
            else
            {
                strwhere += " and (ApprovaStatus = " + state + ")";
            }

            if (txtId.Text.Trim() != "")
            {
                strwhere += " and DepartId in (SELECT U_Id FROM dbo.u_User WHERE U_Name LIKE '%" + txtId.Text.Trim() + "%')";
            }
            else
            {

                this.cbdays.Checked = false;
            }

            if (this.txtdays.Text != "" && this.cbdays.Checked)
            {
                strwhere += " and datediff(day,CreateDate,getdate())<=" + (XYECOM.Core.MyConvert.GetInt32(this.txtdays.Text) - 1) + " and datediff(day,CreateDate,getdate())>=0 ";
            }


            int totalRecord = 0;

            DataTable dt = XYECOM.Business.Utils.GetPaginationData("CreditInfo", "CreditId", "*", "CreateDate desc", strwhere, XYECOM.Core.MyConvert.GetInt32(this.txtPageSize.Text), this.Page1.CurPage, out totalRecord);

            this.Page1.RecTotal = totalRecord;

            if (dt.Rows.Count > 0)
            {
                this.GV1.DataSource = dt;
                this.GV1.DataBind();
            }
            else
            {
                this.lbmanage.Text = "没有相关记录";
                this.GV1.DataBind();
            }
        }
        #endregion
        /// <summary>
        /// 获取债权状态
        /// </summary>
        /// <param name="state"></param>
        /// <returns></returns>
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

        protected void GV1_RowDataBound1(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes.Add("onmouseover", "javascript:__XY_GV_Row_MouseOver(this)");
                e.Row.Attributes.Add("onmouseout", "javascript:__XY_GV_Row_MouseOut(this);");
            }
        }

        /// <summary>
        /// 根据用户编号获取公司名称
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        protected string GetComName(object companyID)
        {
            int uId = MyConvert.GetInt32(companyID.ToString());
            return GetCompanyName(uId);
        }

        /// <summary>
        /// 根据用户编号获取用户名称
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        protected string GetUserName(object userID)
        {
            int uId = MyConvert.GetInt32(userID.ToString());
            return new Business.UserInfo().GetUserNameByID(uId);
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

        #region 删除操作
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            string j = "";
            foreach (GridViewRow GR in this.GV1.Rows)
            {
                if (((CheckBox)(GR.FindControl("chkExport"))).Checked == true)
                {
                    j += "," + GV1.DataKeys[GR.DataItemIndex].Value.ToString();
                }
            }
            if (j.IndexOf(",") == 0)
            {
                j = j.Substring(1);
                int i = coreManage.UpdateApprovaStatusByID(j, XYECOM.Model.CreditState.Delete);
                if (i >= 0)
                {
                    BindData();
                }
                else
                {
                    Alert("删除失败！");
                }
            }
        }
        #endregion

        /// <summary>
        /// 审核通过操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnIsPass_Click(object sender, EventArgs e)
        {
            int infoId = 0;
            foreach (GridViewRow GR in this.GV1.Rows)
            {
                if (((CheckBox)(GR.FindControl("chkExport"))).Checked == true)
                {
                    infoId = XYECOM.Core.MyConvert.GetInt32(GV1.DataKeys[GR.DataItemIndex].Value.ToString());

                    if (infoId <= 0) continue;

                    coreManage.UpdateApprovaStatusByID(infoId, XYECOM.Model.CreditState.Tender);
                }
            }

            BindData();
        }

        /// <summary>
        /// 审核不通过操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnNotIsPass_Click(object sender, EventArgs e)
        {
            int infoId = 0;
            foreach (GridViewRow GR in this.GV1.Rows)
            {
                if (((CheckBox)(GR.FindControl("chkExport"))).Checked == true)
                {
                    infoId = XYECOM.Core.MyConvert.GetInt32(GV1.DataKeys[GR.DataItemIndex].Value.ToString());

                    if (infoId <= 0) continue;

                    coreManage.UpdateApprovaStatusByID(infoId, XYECOM.Model.CreditState.NoPass);
                }
            }

            BindData();
        }

        /// <summary>
        /// 搜索
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button1_Click(object sender, EventArgs e)
        {
            BindData();
        }

        #region 定义分页事件
        protected override void OnInit(EventArgs e)
        {
            this.Load += new System.EventHandler(this.Page_Load);
            this.Page1.PageChanged += new xymanage_UserControl_page.EventHandler(Page1_PageChanged);
            base.OnInit(e);
        }

        private void Page1_PageChanged(object sender, System.EventArgs e)
        {
            BindData();
        }
        #endregion

        /// <summary>
        /// 审核不通过
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lbtnNo_Click(object sender, EventArgs e)
        {
            LinkButton linkButton = (LinkButton)(sender as LinkButton);
            if (linkButton != null)
            {
                int Id = XYECOM.Core.MyConvert.GetInt32(linkButton.CommandArgument);
                if (Id > 0)
                {
                    int result = coreManage.UpdateApprovaStatusByID(Id, XYECOM.Model.CreditState.NoPass);
                    if (result > 0)
                    {
                        BindData();
                    }
                }
            }
        }

        /// <summary>
        /// 审核通过
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lbtnYes_Click(object sender, EventArgs e)
        {
            LinkButton linkButton = (LinkButton)(sender as LinkButton);
            if (linkButton != null)
            {
                int Id = XYECOM.Core.MyConvert.GetInt32(linkButton.CommandArgument);
                if (Id > 0)
                {
                    int result = coreManage.UpdateApprovaStatusByID(Id, XYECOM.Model.CreditState.Tender);
                    if (result > 0)
                    {
                        BindData();
                    }
                }
            }
        }

        /// <summary>
        /// 不推荐
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lbtnNoJian_Click(object sender, EventArgs e)
        {
            LinkButton linkButton = (LinkButton)(sender as LinkButton);
            if (linkButton != null)
            {
                int Id = XYECOM.Core.MyConvert.GetInt32(linkButton.CommandArgument);
                if (Id > 0)
                {
                    int result = coreManage.UpdateIsDraftById(Id,false);
                    if (result > 0)
                    {
                        BindData();
                    }
                }
            }
        }

        /// <summary>
        /// 推荐
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lbtnJian_Click(object sender, EventArgs e)
        {
            LinkButton linkButton = (LinkButton)(sender as LinkButton);
            if (linkButton != null)
            {
                int Id = XYECOM.Core.MyConvert.GetInt32(linkButton.CommandArgument);
                if (Id > 0)
                {
                    int result = coreManage.UpdateIsDraftById(Id, true);
                    if (result > 0)
                    {
                        BindData();
                    }
                }
            }
        }

        #region 审核商业信息失败给用户留言
        private void SendToMessage(long U_ID)
        {
            if (webInfo.IsAuditingInfoMessage)
            {
                XYECOM.Model.MessageInfo em = new XYECOM.Model.MessageInfo();
                XYECOM.Business.Message m = new Message();
                em.M_Adress = "";
                em.M_CompanyName = "";
                em.M_Email = "";
                em.M_FHM = "";
                em.M_HasReply = false;
                em.M_Moblie = "";
                em.M_PHMa = "";
                em.M_RecverType = "administrator";
                em.M_Restore = false;
                em.M_SenderType = "user";

                em.M_Title = webInfo.AuditingInfoMessageTitle;
                em.M_Content = webInfo.AuditingInfoMessageContent;

                em.M_UserName = "";
                em.M_UserType = false;
                em.U_ID = -1;
                em.UR_ID = U_ID;
                m.Insert(em);
            }
        }
        #endregion

        #region  审核失败给用户发送邮件
        private void SendToEmail(string title, string Email)
        {
            if (webInfo.IsAuditingInfoEmail)
            {
                string messtitle = "商业信息审核报告";
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                string[] a = new string[] { webInfo.WebName, webInfo.WebDomain, title, webInfo.WebDomain + "login." + webInfo.WebSuffix };
                string[] ac = new string[] { "{$WI_Name$}", "{$WI_url$}", "{$title$}", "{$pdateurl$}" };
                string strcont = XYECOM.Core.TemplateEmail.GetContent(a, ac, "/templateEmail/AuditingInfo.htm");

                if (strcont != "-1")
                {
                    XYECOM.Business.Utils.SendMail(Email, messtitle, strcont);
                }
            }
        }
        #endregion
    }
}