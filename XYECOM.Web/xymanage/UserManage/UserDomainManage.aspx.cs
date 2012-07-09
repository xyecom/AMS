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

namespace XYECOM.Web.xymanage.UserManage
{
    public partial class UserDomainManage : XYECOM.Web.BasePage.ManagePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //CheckUserState("userDomain");

            this.Page1.PageSize = 20;

            if (!Page.IsPostBack)
            {
                SetValueByquery(Page1, "page");
                SetValueByquery(txtDomain, "domain");
                SetValueByquery(txtICP, "icp");
                this.btnDelete.Attributes.Add("onclick", "javascript:return del();");
                
            }
        }

        #region ������
        protected override void BindData()
        {
            string domain = txtDomain.Text.Trim();
            string icp = txtICP.Text.Trim();

            backURL = XYECOM.Core.Utils.JSEscape("UserDomainManage.aspx?page=" + Page1.CurPage.ToString() +
            "&domain=" + domain +
            "&icp=" + icp
            );

            this.lblMessage.Text = "";

            string where = " 1=1 ";

            if (!domain.Equals(""))
                where += " and domain like '%" + domain + "%'";

            if (!icp.Equals(""))
                where += " and icpinfo like '%" + icp + "%'";

            int totalRecord = 0;

            DataTable dt = XYECOM.Business.Utils.GetPaginationData("XY_UserDomain", "InfoId", "*", "InfoId desc", where, this.Page1.PageSize, this.Page1.CurPage, out totalRecord);

            this.Page1.RecTotal = totalRecord;

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


        #region ����
        protected void gvlist_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int iRowNo = Convert.ToInt32(e.CommandArgument);
            int infoID = Convert.ToInt32(this.gvlist.DataKeys[iRowNo].Value);

            if (e.CommandName == "shenhe")
            {
                LinkButton linkBtn = (LinkButton)this.gvlist.Rows[iRowNo].Cells[6].Controls[0];

                XYECOM.Business.Auditing auditingBLL = new XYECOM.Business.Auditing();

                if (linkBtn.Text == "���ͨ��")
                {
                    int j = auditingBLL.UpdatesAuditing(infoID, "XY_UserDomain", XYECOM.Model.AuditingState.NoPass);
                }
                else if (linkBtn.Text == "���δͨ��" || linkBtn.Text == "δ���")
                {
                    int t = auditingBLL.UpdatesAuditing(infoID, "XY_UserDomain", XYECOM.Model.AuditingState.Passed);
                }

                this.BindData();
            }
        }
        #endregion

        protected void gvlist_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes.Add("onmouseover", "javascript:__XY_GV_Row_MouseOver(this)");
                e.Row.Attributes.Add("onmouseout", "javascript:__XY_GV_Row_MouseOut(this);");

                LinkButton LB = (LinkButton)e.Row.Cells[6].Controls[0];
                string LS = LB.Text.Trim();
                if (LS == "-1")
                {
                    LB.Text = "δ���";
                }
                else if (LS == "0")
                {
                    LB.Text = "���δͨ��";
                }
                else
                {
                    LB.Text = "���ͨ��";
                }
            }
        }


        #region ��ҳ��ش���
        override protected void OnInit(EventArgs e)
        {
            this.Load += new System.EventHandler(this.Page_Load);
            this.Page1.PageChanged += new xymanage_UserControl_page.EventHandler(Page1_PageChanged);
            base.OnInit(e);
        }

        private void Page1_PageChanged(object sender, System.EventArgs e)
        {
            this.BindData();
        }
        #endregion
        
        protected void btnFind_Click(object sender, EventArgs e)
        {
            this.BindData();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            XYECOM.Business.Log l = new XYECOM.Business.Log();
            XYECOM.Model.LogInfo el = new XYECOM.Model.LogInfo();
            XYECOM.Business.UserDomain ur = new XYECOM.Business.UserDomain();
            string ids = "";
            foreach (GridViewRow GR in this.gvlist.Rows)
            {
                HtmlInputCheckBox checkbox = GR.FindControl("chkExport") as HtmlInputCheckBox;
                if (checkbox != null && checkbox.Checked)
                {
                    ids += "," + checkbox.Value;
                }
            }
            if (ids.IndexOf(",") == 0)
            {
                ids = ids.Substring(1);
                int i = ur.Delete(ids);
                if (i >= 0)
                {
                    el.L_Title = "��������������";
                    el.L_Content = "ɾ��������������Ϣ�ɹ�";
                    el.L_MF = "�û�����";
                    
                    {
                        el.UM_ID = AdminId;
                    }
                    l.Insert(el);
                }
                else
                {
                    el.L_Title = "��������������";
                    el.L_Content = "ɾ��������������Ϣʧ��";
                    el.L_MF = "�û�����";
                    
                    {
                        el.UM_ID = AdminId;
                    }
                    l.Insert(el);
                    Alert("ɾ��ʧ�ܣ�");                    
                }
                this.DataBind();
            }
        }
    }
}
