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
using XYECOM.Core;
using XYECOM.Business;

namespace XYECOM.Web.xymanage.Global
{
    public partial class LogManage : XYECOM.Web.BasePage.ManagePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CheckRole("log");

            if (!Page.IsPostBack)
            {
                this.Button1.Attributes.Add("onclick", "javascript:return del();");
                this.Page1.PageSize = 20;

                string url = XYECOM.Core.XYRequest.GetUrl();

                SetValueByquery(Page1, "Page1");
                SetValueByquery(txtname, "txtname");
                SetValueByquery(txtadmin, "txtadmin");
                SetValueByquery(txtmould, "txtmould");
                SetValueByquery(begindate, "begindate");
                SetValueByquery(enddate, "enddate");

                gvDataBind();
            }
        }

        #region ������
        private void gvDataBind()
        {
            //���ñ༭��鿴���ۺ�Ҫ���ص�ǰҳ���״̬
            backURL = XYECOM.Core.Utils.JSEscape(
            "LogManage.aspx?Page1=" + Page1.CurPage.ToString() +
            "&txtname=" + txtname.Text.Trim() +
            "&txtadmin=" + txtadmin.Text.Trim() +
            "&txtmould=" + txtmould.Text.Trim() +
            "&begindate=" + begindate.Value +
            "&enddate=" + enddate.Value
            );

            string strWhere = " where 1=1 ";
            string strOrder = "order by L_addtime desc  ";
            this.lblMessage.Text = "";
            string strTableName = "XYV_Log";
            string BegDate = this.begindate.Value;
            string EndDate = this.enddate.Value;

            if (BegDate != "")
            {
                strWhere += " and (L_addtime > '" + BegDate + "') ";
            }

            if (EndDate != "")
            {
                strWhere += " and (L_addtime < '" + XYECOM.Core.MyConvert.GetDateTime(EndDate).AddDays(1) + "') ";
            }

            if (this.txtname.Text != "")
            {
                strWhere += "  and L_Title like '%" + this.txtname.Text + "%'";
            }
            else if (this.txtadmin.Text != "")
            {
                strWhere += "  and UM_Name like '%" + this.txtadmin.Text + "%'";

            }
            else if (this.txtmould.Text != "")
            {
                strWhere += " and L_MF like '%" + this.txtmould.Text + "%'";
            }
            this.Page1.RecTotal = Function.GetRows(strTableName, "L_ID", strWhere);
            DataTable dt = Function.GetPages(this.Page1.PageSize, this.Page1.CurPage, strWhere, strOrder, strTableName, " * ", "L_ID");
            if (dt.Rows.Count > 0)
            {
                this.gvlist.DataSource = dt;
                this.gvlist.DataBind();
            }
            else
            {
                this.lblMessage.Text = "û�������Ϣ";
                this.gvlist.DataBind();
            }

        }
        #endregion

        #region �����
        protected void gvlist_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //�ж��Ƿ�������
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes.Add("onmouseover", "javascript:__XY_GV_Row_MouseOver(this)");
                e.Row.Attributes.Add("onmouseout", "javascript:__XY_GV_Row_MouseOut(this);");
            }
        }
        #endregion

        #region ��ҳ
        private void Page1_PageChanged(object sender, System.EventArgs e)
        {
            gvDataBind();
        }
        #endregion

        #region Web ������������ɵĴ���
        override protected void OnInit(EventArgs e)
        {
            this.Load += new System.EventHandler(this.Page_Load);
            this.Page1.PageChanged += new xymanage_UserControl_page.EventHandler(Page1_PageChanged);
            base.OnInit(e);
        }
        #endregion

        #region ��ѯ
        protected void Button4_Click(object sender, EventArgs e)
        {
            gvDataBind();
        }
        #endregion

        protected void Button1_Click(object sender, EventArgs e)
        {
            string ids = "";

            foreach (GridViewRow GR in this.gvlist.Rows)
            {
                if (((CheckBox)(GR.FindControl("chkExport"))).Checked == true)
                {
                    ids += "," + this.gvlist.DataKeys[GR.DataItemIndex].Value.ToString();
                }
            }
            if (ids.IndexOf(",") == 0)
            {
                ids = ids.Substring(1);
                int i = 0;
                XYECOM.Business.Log l = new XYECOM.Business.Log();
                i = l.Delete(ids);
                string url = "LogManage.aspx";
                if (i >= 0)
                {
                    Alert("ɾ���ɹ���", url);
                    gvDataBind();
                }
                else
                {
                    Alert("ɾ��ʧ�ܣ�", url);
                }
            }
        }

        protected void btnDelAll_Click(object sender, EventArgs e)
        {
            int result = new XYECOM.Business.Log().DeleteAll();
            if (result > 0)
                Alert("ɾ���ɹ�����ɾ��" + result.ToString() + "����¼��");
            else
                Alert("ɾ��ʧ�ܣ�");
        }
    }
}
