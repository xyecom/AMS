using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace XYECOM.Page.shop
{
    /// <summary>
    /// 模板 shop/cred.htm 代码类
    /// </summary>
    public class cred : ShopBasePage
    {
        public int formation = 0;

        protected int totalscore;
        protected int goodtimes;
        protected int fairtimes;
        protected int poortimes;
        protected Model.CreditLeavlInfo info = null;
        public DataTable dts = new DataTable();
        public DataTable dtj = new DataTable();
        public DataTable dtc = new DataTable();
        public DataTable dtq = new DataTable();
        public string avgProductsgrade = "0";//产品评价分
        public string avgServicegrade = "0";//服务评价分
        public string avgDeliverygrade = "0";//物流评价分
        public string goodNum = "0";//好评数量
        public string mediumNum = "0";//中评数量
        public string poorNum = "0";//差评数量
        public string pageSize = "0";
        public string pageIndex = "0";
        public string strwhere = "1";
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            pageSize = XYECOM.Core.XYRequest.GetString("pageSize");
            pageIndex = XYECOM.Core.XYRequest.GetString("pageIndex");
            strwhere = XYECOM.Core.XYRequest.GetString("selectCred");
            if (shopuserinfo != null)
            {
                formation = shopuserinfo.infoperfectpercent * 2;
            }
        }
        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <returns>企业证书</returns>
        protected DataTable GetCertificate()
        {
            string columns = "*";

            string where = " U_ID=" + shopuserinfo.userid + " and AuditingState = 1 and CE_Isopen='1'";

            string order = "ce_id desc";

            return XYECOM.Business.Utils.ExecuteTable("U_Certificate", columns, where, order, 0);
        }

        protected string GetInfoImgHref(object strInfoId)
        {
            long infoId = Core.MyConvert.GetInt64(strInfoId.ToString());

            return GetInfoImgHref("U_Certificate", infoId);
        }
        /// <summary>
        /// 获取用用信用及订单评价
        /// </summary>
        protected override void BindData()
        {
            info = new Business.CreditLeavlManager().GetItemByPoint(shopuserinfo.creditintegral);
            if (info != null)
            {
                credImag = info.ImagePath;
            }
        }
        protected string credImag = string.Empty;//图片路径
    }
}
