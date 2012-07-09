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

namespace XYECOM.Web.xymanage.Global
{
    public partial class StatisticsNew : XYECOM.Web.BasePage.ManagePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CheckRole("Statistics");

            if (!IsPostBack)
            {
                DataBindpromulgator();
                DataBindClumn();
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            lblMessage.Text = "";
            this._BindData();
        }
        #region ���ݰ�
        /// <summary>
        /// �������ݰ��¼�
        /// </summary>
        protected void _BindData()
        {
            this.gvlist.ShowFooter = true;
            //��ȡ����
            //1.��Ѷ��Ŀ 2.������ 3���״̬ 4����ʱ���
            string nt_id="";
            string um_id = "";
            string state = "";
            string bgtime = "";
            string egtime = "";
            if (this.ddcolumn.SelectedValue != "-1")
                nt_id = this.ddcolumn.SelectedValue;

            if (this.ddlPromulgator.SelectedValue != "-1")
            {
                um_id = this.ddlPromulgator.SelectedValue.ToString();
                this.gvlist.ShowFooter = false;
            }
            if (this.ddlState.SelectedValue != "-1")
                state = this.ddlState.SelectedValue;

            if (this.bgdate.Value != "")
                bgtime = this.bgdate.Value;

            if (this.egdate.Value != "")
                egtime = this.egdate.Value;

            DataTable dt = XYECOM.Business.News.GetStatisticsData(nt_id, um_id, state, bgtime, egtime);

            if (dt.Rows.Count > 0)
            {
                this.gvlist.DataSource = dt;
                this.gvlist.DataBind();
            }
            else
            {
                this.gvlist.DataBind();
                this.lblMessage.Text = "û���������!";
            }
        }
        #endregion
        #region ����Ŀ�����б�

        protected void DataBindClumn()
        {
            this.ddcolumn.Items.Clear();
            ListItem itemdf = new ListItem("��ѡ����Ŀ", "-1");
            this.ddcolumn.Items.Add(itemdf);
            List<ListItem> items = _BindData(0, "|-");

            foreach (ListItem item in items)
            {
                this.ddcolumn.Items.Add(item);
            }
        }

        private List<ListItem> _BindData(long parentID, string splitStr)
        {
            XYECOM.Business.XYClass BLL = new XYClass();

            List<ListItem> listItems = new List<ListItem>();
            List<XYECOM.Model.XYClassInfo> infos = XYECOM.Business.XYClass.GetSubItems("news", parentID);

            foreach (XYECOM.Model.XYClassInfo info in infos)
            {
                listItems.Add(new ListItem(splitStr + info.ClassName, info.ClassId.ToString()));

                if (XYECOM.Business.XYClass.IsHasSubClass("news", info.ClassId))
                    listItems.AddRange(_BindData(info.ClassId, "��" + splitStr));
            }
            
            return listItems;
        }
        //��ddlPromulgator�ϵ�����  ��ӷ�����ѡ��
        protected void DataBindpromulgator()
        {
            DataTable dt = new XYECOM.Business.Admin().GetDataTable();
            this.ddlPromulgator.DataSource = dt.DefaultView;
            ddlPromulgator.DataTextField = "um_name";
            ddlPromulgator.DataValueField = "um_id";
            this.ddlPromulgator.DataBind();
            ListItem item = new ListItem("��ѡ��", "-1");
            this.ddlPromulgator.Items.Insert(0, item);
        }
        #endregion
        int mysum1 = 0;

        protected void gvlist_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DataRowView myrows = (DataRowView)e.Row.DataItem;
                mysum1 += Convert.ToInt32(myrows[1].ToString());
            }
            // �ϼ�
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[0].Text = "�ϼ�";
                e.Row.Cells[1].Text = mysum1.ToString();
            }
        }

        
    }

}
