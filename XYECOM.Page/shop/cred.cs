using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace XYECOM.Page.shop
{
    /// <summary>
    /// ģ�� shop/cred.htm ������
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
        public string avgProductsgrade = "0";//��Ʒ���۷�
        public string avgServicegrade = "0";//�������۷�
        public string avgDeliverygrade = "0";//�������۷�
        public string goodNum = "0";//��������
        public string mediumNum = "0";//��������
        public string poorNum = "0";//��������
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
        /// ��ȡ�����б�
        /// </summary>
        /// <returns>��ҵ֤��</returns>
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
        /// ��ȡ�������ü���������
        /// </summary>
        protected override void BindData()
        {
            info = new Business.CreditLeavlManager().GetItemByPoint(shopuserinfo.creditintegral);
            if (info != null)
            {
                credImag = info.ImagePath;
            }
        }
        protected string credImag = string.Empty;//ͼƬ·��
    }
}
