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

namespace XYECOM.Web.xymanage.Creditor.Foreclosed
{
    public partial class ForeclosedList : XYECOM.Web.BasePage.ManagePage
    {
        ForeclosedManager foreManage = new ForeclosedManager();

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
                SetValueByquery(rblState, "state");
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
            //设置编辑或查看后要返回当前页面的状态
            backURL = XYECOM.Core.Utils.JSEscape(
                "ForeclosedList.aspx?" +
                "page=" + Page1.CurPage.ToString() +
                "&keyWord=" + txtKeyword.Text.Trim() +
                "&State=" + rblState.Text.Trim() +
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
            //审核状态
            if (this.rblState.SelectedValue != "-1")
            {
                switch (rblState.SelectedValue)
                {
                    case "1":
                        strwhere += " and State = -1 ";
                        break;
                    case "2":
                        strwhere += " and State = 1 ";
                        break;
                    case "3":
                        strwhere += " and State = 0 ";
                        break;
                }
            }

            if (txtId.Text.Trim() != "")
            {
                strwhere += " and DepartmentId in (SELECT U_Id FROM dbo.u_User WHERE U_Name LIKE '%" + txtId.Text.Trim() + "%')";
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

            DataTable dt = XYECOM.Business.Utils.GetPaginationData("ForeclosedInfo", "ForeclosedId", "ForeclosedId,Title,IdentityNumber,HighPrice,EndDate,CreateDate,State,UserId,DepartmentId,LinePrice,ForeColseTypeName", "CreateDate desc", strwhere, XYECOM.Core.MyConvert.GetInt32(this.txtPageSize.Text), this.Page1.CurPage, out totalRecord);

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

        protected void GV1_RowDataBound1(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes.Add("onmouseover", "javascript:__XY_GV_Row_MouseOver(this)");
                e.Row.Attributes.Add("onmouseout", "javascript:__XY_GV_Row_MouseOut(this);");

                LinkButton LB = (LinkButton)e.Row.Cells[7].Controls[0];
                string state = LB.Text.Trim();
                if (state == "1")
                {
                    LB.Text = "通过审核";
                }
                else if (state == "0")
                {
                    LB.Text = "审核未通过";
                }
                else if (state == "-1" || state == "")
                {
                    LB.Text = "未审核";
                }
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
            return new XYECOM.Business.AMS.BidInfoManager().GetBidInfoCountByForeID(id);
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
                int i = foreManage.Deletes(j);
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

                    foreManage.AuditById(infoId, true);
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

                    foreManage.AuditById(infoId, false);
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

        #region 审核
        protected void GV1_RowCommand1(object sender, GridViewCommandEventArgs e)
        {
            //获取该行的行号
            int iRowNo = Convert.ToInt32(e.CommandArgument);

            //获取该行的主键
            int ID = Convert.ToInt32(GV1.DataKeys[iRowNo].Value);

            if (e.CommandName == "shenhe")
            {
                LinkButton LB = (LinkButton)GV1.Rows[iRowNo].Cells[7].Controls[0];

                if (LB.Text == "通过审核")
                {
                    int JJ = foreManage.AuditById(ID, false);
                }
                else if (LB.Text == "审核未通过" || LB.Text == "未审核" || LB.Text.ToString() == "")
                {
                    foreManage.AuditById(ID, true);
                }
                BindData();
            }
        }
        #endregion

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