using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XYECOM.Core;
using XYECOM.Web.AppCode;
using System.Text;
using XYECOM.Model;
using System.Data;
namespace XYECOM.Web.Server
{
    public partial class Index : XYECOM.Web.AppCode.UserCenter.Server
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected override void BindData()
        {
            BindOtherInfo();
            BindZqInfo();
        }

        void BindZqInfo()
        {
            this.lblZqMessage.Text = "";
            int totalRecord = 0;
            StringBuilder strWhere = new StringBuilder(" 1=1 and LayerId = " + userinfo.userid);
            DataTable dt = XYECOM.Business.Utils.GetPaginationData("TenderInfo", "TenderId", "*", " TenderDate desc", strWhere.ToString(), 20, 1, out totalRecord);

            if (dt.Rows.Count > 0)
            {
                this.rptCreadit.DataSource = dt;
                this.rptCreadit.DataBind();
            }
            else
            {
                this.lblZqMessage.Text = "没有相关信息记录";
                this.rptCreadit.DataBind();
            }
        }

        void BindOtherInfo()
        {
            this.imgPicture.ImageUrl = userinfo.LayerPicture;
            this.imgSj.ImageUrl = userinfo.IsBoundMobile ? "/Other/images/sjyes.gif" : "/Other/images/sjno.gif";
            this.imgYx.ImageUrl = userinfo.IsBoundEmail ? "/Other/images/yxyes.gif" : "/Other/images/yxno.gif";
            this.ltlSjMessage.Text = userinfo.IsBoundMobile ? "手机已绑定" : "手机未绑定";
            this.ltlYxMessage.Text = userinfo.IsBoundEmail ? "邮箱已绑定" : "邮箱未绑定";

            this.labCanCount.Text = Utitl.GetInfoCount("TenderInfo", "LayerId=" + userinfo.userid).ToString();
            this.ltlCompanyName.Text = userinfo.CompanyName;
            this.labZhongCount.Text = Utitl.GetInfoCount("TenderInfo", "LayerId=" + userinfo.userid + " and IsSuccess = 1").ToString();
            this.ltlLastLoginTime.Text = new Business.UserLogin().GetItem(userinfo.userid).LastLoginDate;
            this.ltlMessageCount.Text = Utitl.GetInfoCount("XYV_RecverManage", "UR_ID=" + userinfo.userid).ToString();
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
            return new XYECOM.Business.Area().GetItem(aId).FullNameAll;
        }

        /// <summary>
        /// 获取默认图片
        /// </summary>
        /// <param name="foreId"></param>
        /// <returns></returns>
        public string GetInfoImgHref(object foreId)
        {
            int id = MyConvert.GetInt32(foreId.ToString());
            return XYECOM.Business.Attachment.GetInfoDefaultImgHref(XYECOM.Model.AttachmentItem.ForeclosedInfo, id);
        }
    }
}