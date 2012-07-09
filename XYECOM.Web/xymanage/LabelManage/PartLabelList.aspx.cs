using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace XYECOM.Web.xymanage.LabelManage
{
    public partial class PartLabelList : XYECOM.Web.BasePage.ManagePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CheckRole("partlabel");
        }

        #region ������
        protected override void BindData()
        {
            backURL = XYECOM.Core.Utils.JSEscape("../LabelManage/PartLabelList.aspx");

            DataTable dt = XYECOM.Business.Utils.ExecuteTable("XY_PartLabel", "*", "", "PartId desc", 0);

            if (dt.Rows.Count > 0)
            {
                this.gvlist.DataSource = dt;
                this.gvlist.DataBind();
            }
            else
            {
                this.lblMessage.Text = "û����ؼ�¼";
                this.gvlist.DataBind();
            }
        }
        #endregion

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            Business.PartLabel DAL = new XYECOM.Business.PartLabel();

            foreach (GridViewRow row in this.gvlist.Rows)
            {
                if (((CheckBox)(row.FindControl("chkExport"))).Checked == true)
                {
                    DAL.Delete(Convert.ToInt32(gvlist.DataKeys[row.DataItemIndex].Value.ToString()));
                }
            }

            BindData();
        }

        #region �����ݰ�ǰ�����������ͺ����״̬ת��
        /// <summary>
        /// �����ݰ�ǰ�����������ͺ����״̬ת��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gvlist_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes.Add("onmouseover", "javascript:__XY_GV_Row_MouseOver(this)");
                e.Row.Attributes.Add("onmouseout", "javascript:__XY_GV_Row_MouseOut(this);");

                e.Row.Cells[2].Text = "{" + e.Row.Cells[2].Text + "}";

                LinkButton lb = (LinkButton)e.Row.Cells[8].Controls[0];
                if (lb.Text == "1")
                    lb.Text = "ͨ�����";
                else if (lb.Text == "0")
                    lb.Text = "δͨ�����";
                else
                    lb.Text = "δ���";
            }
        }
        #endregion

        #region �������״̬ת���¼�
        protected void gvlist_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            XYECOM.Business.Auditing audBLL = new XYECOM.Business.Auditing();

            int row = Convert.ToInt32(e.CommandArgument);
            Int64 id = Convert.ToInt64(this.gvlist.DataKeys[row][0].ToString());

            LinkButton lb = (LinkButton)this.gvlist.Rows[row].Cells[8].Controls[0];

            if (e.CommandName == "ChangeAuditing")
            {
                if (lb.Text == "ͨ�����")
                {
                    audBLL.UpdatesAuditing(id, "XY_PartLabel", XYECOM.Model.AuditingState.NoPass);
                }
                else if (lb.Text == "δͨ�����" || lb.Text =="δ���")
                {
                    audBLL.UpdatesAuditing(id, "XY_PartLabel", XYECOM.Model.AuditingState.Passed);
                }
            }
            BindData();
        }
        #endregion
    }
}
