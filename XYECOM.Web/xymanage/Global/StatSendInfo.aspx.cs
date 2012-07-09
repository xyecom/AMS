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
    public partial class StatSendInfo : XYECOM.Web.BasePage.ManagePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CheckRole("Statistics");
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            _BindData();
        }

        #region 数据绑定
        /// <summary>
        /// 定义数据绑定事件
        /// </summary>
        protected void _BindData()
        {
            //获取条件
            //1.资讯栏目 2.新闻来源NS_NewsOrigin 3审核状态 4发布时间段 5 新闻作者NS_NewsAuthor
            string nt_id = "";
            string state = "";
            string bgtime = "";
            string egtime = "";
            string AreaIds = "";
            string TradeIds = "";

            if (!(XYECOM.Core.Utils.AppendComma(this.hidTypeId.Value).Equals(",")))
                nt_id = this.hidTypeId.Value;

            if (this.ddlState.SelectedValue != "-1")
                state = this.ddlState.SelectedValue;

            if (this.bgdate.Value != "")
                bgtime = this.bgdate.Value;

            if (this.egdate.Value != "")
                egtime = this.egdate.Value;


            if (!(XYECOM.Core.Utils.AppendComma(this.areaId.Value).Equals(",")))
                AreaIds = XYECOM.Core.Utils.AppendComma(this.areaId.Value);

            if (!(XYECOM.Core.Utils.AppendComma(this.typeid.Value).Equals(",")))
                TradeIds = XYECOM.Core.Utils.AppendComma(this.typeid.Value);




            DataTable dt = XYECOM.Business.News.GetStatSendInfo(nt_id, state, bgtime, egtime, AreaIds, TradeIds);


            if (dt.Rows.Count > 0)
            {
                string count = dt.Rows[0][0].ToString();
                this.lblExecSqlResult.InnerHtml = "您所查询的数据共有" + count + "条！";
            }
            else
            {
                this.lblExecSqlResult.InnerHtml = "没有您所查询的数据!";
                return;
            }
        }
        #endregion


    }
}
