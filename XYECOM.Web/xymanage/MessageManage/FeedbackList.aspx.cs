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

namespace XYECOM.Web.xymanage.MessageManage
{
    public partial class FeedbackList : XYECOM.Web.BasePage.ManagePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CheckRole("feedback");

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
                SetValueByquery(txtTitle, "Title");
                SetValueByquery(ddlType, "Type");
                SetValueByquery(Name, "Name");
                SetValueByquery(Telephone, "Telephone");
                SetValueByquery(txtBeginDate, "begindate");
                SetValueByquery(txtEndDate, "enddate");
                SetValueByquery(Email, "Email");
                SetValueByquery(txtPageSize, "pagesize");
                SetValueByquery(txtdays, "isdays");
                SetValueByquery(cbdays, "cbday", "1");

                this.lnkDel.Attributes.Add("onclick", "javascript:return del();");

            }
        }

        #region ���ݰ�
        /// <summary>
        /// �������ݰ��¼�
        /// </summary>
        protected override void BindData()
        {
            //��ȡ����
            //1.���� 

            //���ñ༭��鿴��Ҫ���ص�ǰҳ���״̬
            backURL = XYECOM.Core.Utils.JSEscape(
            "&page=" + Page1.CurPage.ToString() +
            "&Title=" + txtTitle.Text.Trim() +
            "&Type=" + ddlType.SelectedValue +
            "&begindate=" + txtBeginDate.Text.Trim() +
            "&enddate=" + txtEndDate.Text.Trim() +
            "&Email=" + Email.Text.Trim() +
            "&Name=" + Name.Text.Trim() +
            "&Telephone=" + Telephone.Text.Trim() +
            "&pagesize=" + txtPageSize.Text +
            "&cbday=" + cbdays.Checked.ToString().ToLower() +
            "&isdays=" + txtdays.Text + "");

            string begindate = this.txtBeginDate.Text.Trim();
            string enddate = this.txtEndDate.Text.Trim();
            try
            {
                DateTime bgdt = Convert.ToDateTime(begindate);
            }
            catch (Exception)
            {
                begindate = "";
            }
            try
            {
                DateTime egdt = Convert.ToDateTime(enddate);
            }
            catch (Exception)
            {
                enddate = "";
            }

            this.lblMessage.Text = "";
            string strWhere = " 1=1";

            if (this.ddlType.SelectedValue != "0")
                strWhere += " and Type = '" + this.ddlType.SelectedValue + "'";

            if (this.txtTitle.Text.Trim() != "")
                strWhere += " and Title like '%" + this.txtTitle.Text.Trim() + "%' ";

            if (this.Name.Text.Trim() != "")
                strWhere += " and Name = '" + this.Name.Text.Trim() + "'";

            if (this.Email.Text.Trim() != "")
                strWhere += " and Email = '" + this.Email.Text.Trim() + "'";

            if (this.Telephone.Text.Trim() != "")
                strWhere += " and Telephone = '" + this.Telephone.Text.Trim() + "'";

            //��ʼ����
            if (begindate != "")
                strWhere += " and  addtime >= '" + begindate + "' ";

            //��������
            if (enddate != "")
                strWhere += " and addtime <= '" + enddate + "' ";


            if (this.txtdays.Text != "" && this.cbdays.Checked)
            {
                strWhere += " and datediff(day,addtime,getdate())<=" + (XYECOM.Core.MyConvert.GetInt32(this.txtdays.Text) - 1) + " and datediff(day,addtime,getdate())>=0 ";
            }

            //Ͷ����Ϣ����
            if (XYECOM.Core.MyConvert.GetInt32(DDLInfoFlag.SelectedValue) == (int)XYECOM.Model.Complaint.ComplaintOrder)
            {
                strWhere += " and InfoFlag=" + (int)XYECOM.Model.Complaint.ComplaintOrder;
            }

            if (XYECOM.Core.MyConvert.GetInt32(DDLInfoFlag.SelectedValue) == (int)XYECOM.Model.Complaint.ComplaintContract)
            {
                strWhere += " and InfoFlag=" + (int)XYECOM.Model.Complaint.ComplaintContract;
            }

            if (XYECOM.Core.MyConvert.GetInt32(DDLInfoFlag.SelectedValue) == (int)XYECOM.Model.Complaint.ComplaintTeam)
            {
                strWhere += " and InfoFlag=" + (int)XYECOM.Model.Complaint.ComplaintTeam;
            }


            int totalRecord = 0;

            DataTable dt = XYECOM.Business.Utils.GetPaginationData("XY_Feedback", "FeedbackID", "FeedbackID,Title,Type,Name,telephone,Email,Centent,addtime,InfoFlag", "addtime desc", strWhere, XYECOM.Core.MyConvert.GetInt32(this.txtPageSize.Text), this.Page1.CurPage, out totalRecord);

            this.Page1.RecTotal = totalRecord;



            if (dt.Rows.Count > 0)
            {
                this.GV1.DataSource = dt;
                this.GV1.DataBind();
            }
            else
            {
                this.lblMessage.Text = "û�������Ϣ";
                this.GV1.DataBind();
            }

        }
        #endregion

        #region����ҳ
        private void Page1_PageChanged(object sender, EventArgs e)
        {
            BindData();
        }
        #endregion

        #region ɾ������
        protected void lnkDel_Click(object sender, EventArgs e)
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
                XYECOM.Business.Feedback BLL = new XYECOM.Business.Feedback();
                int i = 0;
                i = BLL.Delete(j);
                if (i < 0)
                {
                    Alert("ɾ��ʧ�ܣ�");
                }
                BindData();
            }
        }
        #endregion

        #region Web������������ɵĴ���
        protected override void OnInit(EventArgs e)
        {
            this.Load += new System.EventHandler(this.Page_Load);
            this.Page1.PageChanged += new xymanage_UserControl_page.EventHandler(Page1_PageChanged);
            base.OnInit(e);
        }
        #endregion

        #region ��ѯ
        protected void btnFind_Click(object sender, EventArgs e)
        {
            this.Page1.CurPage = 1;
            BindData();
        }
        #endregion
        //protected void GV1_RowDataBound(object sender, GridViewRowEventArgs e)
        //{
        //    if (e.Row.RowType == DataControlRowType.DataRow)
        //    {
        //        System.Web.UI.LiteralControl lt = (System.Web.UI.LiteralControl)e.Row.Cells[4].Controls[0];
        //        ////Literal lt = (Literal)e.Row.Cells[4].Controls[0];
        //        ////emplateField TP = (TemplateField)e.Row.Cells[4].Controls[0];
        //        //LinkButton LB = (LinkButton)e.Row.Cells[9].Controls[0];

        //        string WW = lt.Text;

        //        if (WW == "0")
        //        {
        //            lt.Text = "����Ͷ��";
        //        }
        //        else if (WW == "1")
        //        {
        //            lt.Text = "��ͬͶ��";
        //        }
        //        else if (WW == "2")
        //        {
        //            lt.Text = "�Ź�Ͷ��";
        //        }
        //        //else if (WW == "4")
        //        //{
        //        //    lt.Text = "����";
        //        //}
        //        //else if (WW == "5")
        //        //{
        //        //    lt.Text = "ҵ����ϵ";
        //        //}
        //    }

        //}

        protected string GetInfoFlag(string FeedbakcId)
        {
            int infoFlag = 0;

            XYECOM.Business.Feedback FeedBackBBL = new Business.Feedback();
            XYECOM.Model.FeedbackInfo FBInfo = FeedBackBBL.GetItem(XYECOM.Core.MyConvert.GetInt32(FeedbakcId));

            if (FBInfo != null)
            {
                infoFlag = FBInfo.InfoFlag;
                
                if (infoFlag == (int)XYECOM.Model.Complaint.ComplaintOrder)
                {
                    return "����Ͷ��";
                }
                if (infoFlag == (int)XYECOM.Model.Complaint.ComplaintContract)
                {
                    return "��ͬͶ��";
                }
                if (infoFlag == (int)XYECOM.Model.Complaint.ComplaintTeam)
                {
                    return "�Ź�Ͷ��";
                }
            }
            return "";
        }
    }
}
