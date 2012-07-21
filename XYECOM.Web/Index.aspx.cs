using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XYECOM.Page;
using System.Text;
using System.Data;
using XYECOM.Core;
using XYECOM.Business;
using XYECOM.Model;

namespace XYECOM.Web
{
    public partial class Index1 : ForeBasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected override void BindData()
        {
            string typeName = this.droTypeName.SelectedValue;
            int aredId = MyConvert.GetInt32(this.city.Value);

            this.lblMessage.Text = "";

            StringBuilder strWhere = new StringBuilder(" 1=1 and (State = " + (int)AuditingState.Passed + ")");
            if (!string.IsNullOrEmpty(typeName) && typeName != "所有")
            {
                strWhere.Append(" and (ForeColseTypeName like '%" + typeName + "%')");
            }
            if (aredId > 0)
            {
                strWhere.Append(" and (AreaId =" + aredId + ")");
            }
            int totalRecord = 0;
            DataTable dt = XYECOM.Business.Utils.GetPaginationData("ForeclosedInfo", "ForeclosedId", "*", " CreateDate desc", strWhere.ToString(), this.Page1.PageSize, this.Page1.CurPage, out totalRecord);
            this.Page1.RecTotal = totalRecord;

            if (dt.Rows.Count > 0)
            {
                this.dlForeclosed.DataSource = dt;
                this.dlForeclosed.DataBind();
            }
            else
            {
                this.lblMessage.Text = "没有相关信息记录";
                this.dlForeclosed.DataBind();
            }
        }

        public string GetEndDate(object endDate)
        {
            DateTime date = XYECOM.Core.MyConvert.GetDateTime(endDate.ToString());
            if (date.CompareTo(DateTime.Now) < 0)
            {
                return "已过期";
            }
            else
            {
                return date.ToString("yyyy-MM-dd");
            }
        }

        #region 分页相关代码

        protected void Page1_PageChanged(object sender, System.EventArgs e)
        {
            this.BindData();
        }
        #endregion

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindData();
        }

        /// <summary>
        /// 获取物品地址
        /// </summary>
        /// <param name="areaId"></param>
        /// <returns></returns>
        public string GetAreaIdFull(object areaId)
        {
            int aId = MyConvert.GetInt32(areaId.ToString());
            return new Area().GetItem(aId).FullNameAll;
        }

        /// <summary>
        /// 获取默认图片
        /// </summary>
        /// <param name="foreId"></param>
        /// <returns></returns>
        public string GetInfoImgHref(object foreId)
        {
            int id = MyConvert.GetInt32(foreId.ToString());
            return XYECOM.Business.Attachment.GetInfoDefaultImgHref(AttachmentItem.ForeclosedInfo, id);
        }
    }
}