using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.UI.HtmlControls;

namespace XYECOM.Web.xymanage.Basic
{
    public partial class UnitsList : XYECOM.Web.BasePage.ManagePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // CheckRole("brand");

            if (!IsPostBack)
            {
                SetValueByquery(page1, "page");
                SetValueByquery(txtKeyword, "keyword");
                this.page1.PageSize = 20;
                this.lnkDel.Attributes.Add("onclick", "javascript:return del()");

            }
        }
        #region 设置控件的初始值

        protected override void SetValueByquery(ref string var, string query)
        {
            if (XYECOM.Core.XYRequest.GetQueryString(query) != "")
                var = XYECOM.Core.XYRequest.GetQueryString(query);
        }

        protected override void SetValueByquery(xymanage_UserControl_page control, string query)
        {
            if (XYECOM.Core.XYRequest.GetQueryInt(query, 0) > 0)
                control.CurPage = XYECOM.Core.XYRequest.GetQueryInt(query, 0);
        }

        protected override void SetValueByquery(TextBox control, string query)
        {
            if (XYECOM.Core.XYRequest.GetQueryString(query) != "")
                control.Text = XYECOM.Core.XYRequest.GetQueryString(query);
        }

        protected override void SetValueByquery(RadioButtonList control, string query)
        {
            if (XYECOM.Core.XYRequest.GetQueryString(query) != "")
                control.Text = XYECOM.Core.XYRequest.GetQueryString(query);
        }

        protected override void SetValueByquery(HtmlInputHidden control, string query)
        {
            if (XYECOM.Core.XYRequest.GetQueryString(query) != "")
                control.Value = XYECOM.Core.XYRequest.GetQueryString(query);
        }

        protected override void SetValueByquery(HtmlSelect control, string query)
        {
            if (XYECOM.Core.XYRequest.GetQueryString(query) != "")
                control.Value = XYECOM.Core.XYRequest.GetQueryString(query);
        }

        protected override void SetValueByquery(HtmlInputText control, string query)
        {
            if (XYECOM.Core.XYRequest.GetQueryString(query) != "")
                control.Value = XYECOM.Core.XYRequest.GetQueryString(query);
        }

        protected override void SetValueByquery(DropDownList control, string query)
        {
            if (XYECOM.Core.XYRequest.GetQueryString(query) != "")
                control.Text = XYECOM.Core.XYRequest.GetQueryString(query);
        }

        protected override void SetValueByquery(CheckBoxList control, string query)
        {
            if (XYECOM.Core.XYRequest.GetQueryString(query) != "")
                control.Text = XYECOM.Core.XYRequest.GetQueryString(query);
        }

        protected override void SetValueByquery(ListBox control, string query)
        {
            if (XYECOM.Core.XYRequest.GetQueryString(query) != "")
                control.Text = XYECOM.Core.XYRequest.GetQueryString(query);
        }

        protected override void SetValueByquery(CheckBox control, string query, string checkedstate)
        {
            if (checkedstate == "1")
            {
                if (XYECOM.Core.XYRequest.GetQueryString(query) != "true" && XYECOM.Core.XYRequest.GetQueryString(query) != "")
                    control.Checked = false;
                else
                    control.Checked = true;
            }
            else
            {
                if (XYECOM.Core.XYRequest.GetQueryString(query) != "true")
                    control.Checked = false;
                else
                    control.Checked = true;
            }

        }

        #endregion
        #region 数据绑定事件
        protected override void BindData()
        {
            //设置编辑或查看后要返回当前页面的状态
            backURL = XYECOM.Core.Utils.JSEscape(
                "unitslist.aspx?" +
                "&page=" + page1.CurPage.ToString() +
                "&keyWord=" + txtKeyword.Text.Trim());
            string strwhere = "1=1 ";
            this.lblMessage.Text = "";

            //标题
            if (this.txtKeyword.Text.Trim() != "")
            {
                strwhere += " and  MeasuringUnitName like '%" + this.txtKeyword.Text.Trim() + "%' ";
            }

            int totalRecord = 0;

            DataTable dt = XYECOM.Business.Utils.GetPaginationData("XY_MeasuringUnit", "id", "id,MeasuringUnitName ", "id desc", strwhere, this.page1.PageSize, this.page1.CurPage, out totalRecord);

            this.page1.RecTotal = totalRecord;

            if (dt.Rows.Count > 0)
            {
                this.gvlist.DataSource = dt;
                this.gvlist.DataBind();
            }
            else
            {
                this.lblMessage.Text = "没有相关信息";
                dt.Rows.Add(dt.NewRow());
                gvlist.DataSource = dt;
                this.gvlist.DataBind();
                int coulumnCount = gvlist.Rows[0].Cells.Count;
                gvlist.Rows[0].Cells.Clear();
                gvlist.Rows[0].Cells.Add(new TableCell());
            }
        }
        #endregion

        #region 单击删除事件
        protected void lnkDel_Click(object sender, EventArgs e)
        {
            XYECOM.Business.MeasuringUnitManager cp = new XYECOM.Business.MeasuringUnitManager();
            int id = 0;
            bool isall = true;
            XYECOM.Business.Supply su = new Business.Supply();
            foreach (GridViewRow row in this.gvlist.Rows)
            {
                if (((CheckBox)(row.FindControl("chkExport"))).Checked == true)
                {
                    id = XYECOM.Core.MyConvert.GetInt32(this.gvlist.DataKeys[row.DataItemIndex].Value.ToString());
                    if (id > 0)
                    {
                        if (su.GetBrandSupplyForUnitId(id) == 0)
                        {
                            cp.Delete(id);
                        }
                        else
                        {
                            isall = false;
                        }
                    }
                }
            }
            if (isall)
            {
                Alert("删除成功！");
            }
            else
            {
                Alert("删除成功，部分有产品引用,不能执行删除操作");
            }
            this.BindData();
        }
        #endregion



        #region 点击查询按钮事件
        protected void btFind_Click(object sender, EventArgs e)
        {
            this.page1.CurPage = 1;
            lblMessage.Text = "";
            this.BindData();
        }
        #endregion

        #region 定义分页事件
        private void Page1_PageChanged(object sender, System.EventArgs e)
        {
            BindData();
        }
        #endregion

        #region Web窗体设计器生成的代码
        protected override void OnInit(EventArgs e)
        {
            this.Load += new EventHandler(this.Page_Load);
            this.page1.PageChanged += new xymanage_UserControl_page.EventHandler(Page1_PageChanged);
            base.OnInit(e);
        }
        #endregion


        #region gridview控件绑定数据事件
        protected void gvlist_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes.Add("onmouseover", "javascript:__XY_GV_Row_MouseOver(this)");
                e.Row.Attributes.Add("onmouseout", "javascript:__XY_GV_Row_MouseOut(this);");

            }
        }
        #endregion
    }
}