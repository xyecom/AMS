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
            this.lblMessage.Text = "";
            this.labCreditMessage.Text = "";

            //加载抵债信息
            StringBuilder strWhere = new StringBuilder(" 1=1 and (State = " + (int)AuditingState.Passed + ")");
            int totalRecord = 0;
            DataTable dt = XYECOM.Business.Utils.GetPaginationData("ForeclosedInfo", "ForeclosedId", "*", " CreateDate desc", strWhere.ToString(), 4, 1, out totalRecord);

            if (dt.Rows.Count > 0)
            {
                this.dlForeclosed.DataSource = dt;
                this.dlForeclosed.DataBind();
            }
            else
            {
                this.lblMessage.Text = "没有可查看的抵债信息";
                this.dlForeclosed.DataBind();
            }



            //加载债权信息
            StringBuilder where = new StringBuilder(" 1=1 and ( ApprovaStatus  =2) and IsDraft = 'false'");
            DataTable dtZ = XYECOM.Business.Utils.GetPaginationData("CreditInfo", "CreditId", "*", " CreateDate desc", where.ToString(), 20, 1, out totalRecord);

            if (dtZ.Rows.Count > 0)
            {
                this.dlCreditList.DataSource = dtZ;
                this.dlCreditList.DataBind();
            }
            else
            {
                this.dlCreditList.DataBind();
            }

            StringBuilder whereJian = new StringBuilder(" 1=1 and ( ApprovaStatus  =2) and IsDraft = 'true'");
            DataTable dtJian = XYECOM.Business.Utils.GetPaginationData("CreditInfo", "CreditId", "*", " CreateDate desc", whereJian.ToString(),3, 1, out totalRecord);

            if (dtJian.Rows.Count > 0)
            {
                this.rpJian.DataSource = dtJian;
                this.rpJian.DataBind();
            }
            else
            {
                if (dtZ.Rows.Count <= 0)
                {
                    this.labCreditMessage.Text = "没有可查看的债权信息";
                }
                this.rpJian.DataBind();
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

        /// <summary>
        /// 根据债权信息ID获取该债权信息的投标个数
        /// </summary>
        /// <param name="CreditID"></param>
        /// <returns></returns>
        public int GetTenderCountByCreditID(object CreditID)
        {
            int id = MyConvert.GetInt32(CreditID.ToString());
            return new XYECOM.Business.AMS.TenderInfoManager().GetTenderCountByCreditID(id);
        }

        /// <summary>
        /// 获取债权信息
        /// </summary>
        /// <param name="title"></param>
        /// <returns></returns>
        public string GetTitle(object title)
        {
            string strTitle = title.ToString();
            if (strTitle.Length > 15)
            {
                return strTitle.Substring(0, 15) + "……";
            }
            else
            {
                return strTitle;
            }
        }
    }
}