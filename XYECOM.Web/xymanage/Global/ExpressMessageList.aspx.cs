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
using XYECOM.Business;
using XYECOM.Model;
using XYECOM.Core;

namespace XYECOM.Web.xymanage.Global
{
    public partial class ExpressMessageList : XYECOM.Web.BasePage.ManagePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CheckRole("ExpressMessage");
        }


        #region ���ݰ󶨷���
        private void BindModuleList()
        {
            List<ListItem> list = GetAllModules(false);

            list.Add(new ListItem("��ҵƷ��", "brand"));
            list.Add(new ListItem("��ҵ����", "company"));

            list.Insert(0, new ListItem("ͨ������","general"));

            ddlModules.Items.Clear();
            foreach (ListItem item in list)
            {
                this.ddlModules.Items.Add(item);
            }

            this.ddlModules.Items.Insert(0, new ListItem("��ѡ������ģ��", ""));
        }

        /// <summary>
        /// ���ݰ󶨷���
        /// </summary>
        protected override void BindData()
        {
            this.lnkDel.Attributes.Add("onclick", "javascript:return del();");

            this.page1.PageSize = 20;

            BindModuleList();

            string strWhere = "";
            if (this.ddlModules.SelectedValue != "")
                strWhere = "  ModuleName='" + this.ddlModules.SelectedValue + "'";

            int totalRecord = 0;

            DataTable dt = Business.Utils.GetPaginationData("XY_ExpressMessage", "Id", "Id,ModuleName,Body", "Id Desc",strWhere, page1.PageSize, this.page1.CurPage, out totalRecord);
            
            this.page1.RecTotal = totalRecord;

            if (dt.Rows.Count > 0)
            {
                this.gvlist.DataSource = dt;
                this.gvlist.DataBind();
            }
            else
            {
                this.gvlist.DataBind();
                this.lblMessage.Text = "û�������Ϣ��";
            }
        }
        #endregion

        #region ������
        protected void gvlist_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes.Add("onmouseover", "javascript:__XY_GV_Row_MouseOver(this)");
                e.Row.Attributes.Add("onmouseout", "javascript:__XY_GV_Row_MouseOut(this);");

            }
        }
        #endregion

        #region ɾ���¼�
        /// <summary>
        /// ����ɾ���¼�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lnkDel_Click(object sender, EventArgs e)
        {
            XYECOM.Business.ExpressMessage expBLL = new XYECOM.Business.ExpressMessage();
            string id = "";
            foreach (GridViewRow row in this.gvlist.Rows)
            {
                if (((CheckBox)(row.FindControl("chkExport"))).Checked == true)
                    id += "," + this.gvlist.DataKeys[row.DataItemIndex].Value.ToString();
            }

            if (id.IndexOf(",") == 0)
                id = id.Substring(1);

            int rowAff = expBLL.Delete(id);

            if (rowAff >= 0)
            {
                Response.Redirect("ExpressMessageList.aspx");
            }
            else
            {
                Alert("ɾ��ʧ��,�������²���.", "ExpressMessageList.aspx");
            }
        }
        #endregion

        #region ����¼�
        /// <summary>
        /// ��Ӱ�ť�¼�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lnkAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddExpressMessage.aspx");
        }
        #endregion

        #region  �������ͽ���ת��
        /// <summary>
        /// ���������ͽ���ת��
        /// </summary>
        /// <param name="type">��������</param>
        /// <returns>ת���������</returns>
        public string GetExpMsgModuleName(string moduleName)
        {
            if (!string.IsNullOrEmpty(moduleName))
            {
                if (moduleName.Equals("general")) return "ͨ������";

                return GetModuleCNName(moduleName);
            }

            return "";
        }
        #endregion

        #region �����ҳ�¼�
        /// <summary>
        /// �����ҳ�¼�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Page1_PageChanged(object sender, System.EventArgs e)
        {
            BindData();
        }
        #endregion

        #region Web������������ɵĴ���
        protected override void OnInit(EventArgs e)
        {
            this.Load += new System.EventHandler(this.Page_Load);
            this.page1.PageChanged += new xymanage_UserControl_page.EventHandler(Page1_PageChanged);
            base.OnInit(e);
        }
        #endregion

        protected void ddlModules_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.page1.CurPage = 1;
            lblMessage.Text = "";
            this.BindData();
        }
    }
}
