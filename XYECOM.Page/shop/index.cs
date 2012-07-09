using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace XYECOM.Page.shop
{
    /// <summary>
    /// ģ�� shop/index.htm ������
    /// </summary>
    public class index : ShopBasePage
    {
        public XYECOM.Business.FiltrateKeyWord filtrateKeyWordBLL = new XYECOM.Business.FiltrateKeyWord();

        protected XYECOM.Configuration.ModuleInfo module = null;

        protected override void OnLoad(EventArgs e)
        {            
            base.OnLoad(e);
            if (!pageinfo.IsPost)
            {
                string uname = "";
                uname = XYECOM.Core.XYRequest.GetQueryString("u_name");

                module = moduleConfig.GetItem("offer");

                InitInfoLinkList("offer");

                if (shopuserinfo != null)
                {
                    shopuserinfo.synopsis = XYECOM.Business.FiltrateKeyWord.LeachKeyWord(shopuserinfo.gradeid, XYECOM.Core.Utils.IsLength(500, shopuserinfo.synopsis));

                    shopuserinfo.synopsis = shopuserinfo.synopsis.Replace("\r\n", "<br />");
                }
            }

            //���ʼ�¼
            PageRecordBLL.InsertPageRecord((int)XYECOM.Model.PageRecord.OtherRecord, userinfo, shopuserinfo.userid, 0);
        }

        protected override Model.UserSEOFlag UserSeoFlg
        {
            get
            {
                return Model.UserSEOFlag.Index;
            }
        }

        /// <summary>
        /// ������������(��ͼƬ)
        /// </summary>
        /// <param name="topNumber">����</param>
        /// <returns>��������</returns>
        protected DataTable GetNewPro(int topNumber)
        {
            string infoTypeIds = XYECOM.Configuration.Module.Instance.GetItem("offer").SellIDs;

            string columns = "SD_ID as infoId,SD_Title as infoTitle,IsHasImage,SD_HTMLPage as HtmlPage,SD_Flag as infoflag";

            string where = " U_Id=" + shopuserinfo.userid + " and AuditingState=1 and SD_IsSupply='1' ";

            string order = "sd_publishdate desc";

            return XYECOM.Business.Utils.ExecuteTable("xyv_supply", columns, where, order, topNumber);
        }

        /// <summary>
        /// ��ȡ�Ƽ���������ҳ�Ĳ�Ʒ����
        /// </summary>
        /// <param name="topNumber">����</param>
        /// <returns>�Ƽ���������ҳ�Ĳ�Ʒ����</returns>
        protected DataTable GetShopIndexPro(int topNumber)
        {
            string columns = "SD_ID as infoId,SD_Title as infoTitle,IsHasImage,SD_HTMLPage as HtmlPage,SD_Flag as infoflag,SD_PublishDate as addtime,SD_Description as details";

            string where = " U_Id=" + shopuserinfo.userid + " and AuditingState=1 and isshop=1 and SD_IsSupply='1'";

            string order = "sd_publishdate desc";

            return XYECOM.Business.Utils.ExecuteTable("xyv_supply", columns, where, order, topNumber);
        }
    }
}
