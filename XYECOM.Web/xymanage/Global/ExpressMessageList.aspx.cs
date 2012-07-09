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


        #region 数据绑定方法
        private void BindModuleList()
        {
            List<ListItem> list = GetAllModules(false);

            list.Add(new ListItem("行业品牌", "brand"));
            list.Add(new ListItem("企业导航", "company"));

            list.Insert(0, new ListItem("通用留言","general"));

            ddlModules.Items.Clear();
            foreach (ListItem item in list)
            {
                this.ddlModules.Items.Add(item);
            }

            this.ddlModules.Items.Insert(0, new ListItem("请选择所属模块", ""));
        }

        /// <summary>
        /// 数据绑定方法
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
                this.lblMessage.Text = "没有相关信息！";
            }
        }
        #endregion

        #region 绑定数据
        protected void gvlist_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes.Add("onmouseover", "javascript:__XY_GV_Row_MouseOver(this)");
                e.Row.Attributes.Add("onmouseout", "javascript:__XY_GV_Row_MouseOut(this);");

            }
        }
        #endregion

        #region 删除事件
        /// <summary>
        /// 定义删除事件
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
                Alert("删除失败,可以重新操作.", "ExpressMessageList.aspx");
            }
        }
        #endregion

        #region 添加事件
        /// <summary>
        /// 添加按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lnkAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddExpressMessage.aspx");
        }
        #endregion

        #region  留言类型进行转换
        /// <summary>
        /// 对留言类型进行转换
        /// </summary>
        /// <param name="type">留言类型</param>
        /// <returns>转换后的数据</returns>
        public string GetExpMsgModuleName(string moduleName)
        {
            if (!string.IsNullOrEmpty(moduleName))
            {
                if (moduleName.Equals("general")) return "通用留言";

                return GetModuleCNName(moduleName);
            }

            return "";
        }
        #endregion

        #region 定义分页事件
        /// <summary>
        /// 定义分页事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Page1_PageChanged(object sender, System.EventArgs e)
        {
            BindData();
        }
        #endregion

        #region Web窗体设计器生成的代码
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
