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

namespace XYECOM.Web.xymanage.Creditor.Foreclosed
{
    public partial class ForeclosedList : XYECOM.Web.BasePage.ManagePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        #region 绑定数据
        protected override void BindData()
        {
            this.lbmanage.Text = "";

            string strwhere = string.Empty;
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
                strwhere += " and U_id=" + txtId.Text.Trim();
            }
            else
            {
                if (uId != 0)
                {
                    strwhere += " and u_id=" + uId;
                    this.cbdays.Checked = false;
                }
            }

            if (this.txtdays.Text != "" && this.cbdays.Checked)
            {
                strwhere += " and datediff(day,SD_PublishDate,getdate())<=" + (XYECOM.Core.MyConvert.GetInt32(this.txtdays.Text) - 1) + " and datediff(day,SD_PublishDate,getdate())>=0 ";
            }


            int totalRecord = 0;

            DataTable dt = XYECOM.Business.Utils.GetPaginationData("XYV_Supply", "SD_ID", "SD_ID,SD_Title,U_ID,SD_PublishDate,U_Name,AuditingState,SD_Vouch,SD_Flag,UI_Name,U_Email,SD_HTMLPage,IsContractVouch", "SD_ID desc", strwhere, XYECOM.Core.MyConvert.GetInt32(this.txtPageSize.Text), this.Page1.CurPage, out totalRecord);

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
    }
}