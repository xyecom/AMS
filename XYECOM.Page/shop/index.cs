using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace XYECOM.Page.shop
{
    /// <summary>
    /// Ä£°å shop/index.htm ´úÂëÀà
    /// </summary>
    public class index : ShopBasePage
    {
        protected DataTable data = new DataTable();
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            string strwhere = " U_ID=" + shopuserinfo.userid;

            this.pageinfo.PageIndex = XYECOM.Core.XYRequest.GetInt("PageIndex", 1);

            int totalRecord = 0;

            data = XYECOM.Business.Utils.GetPaginationData("XYV_Certificate ", "CE_ID", "*", "CE_Addtime desc", strwhere, 4, 1, out totalRecord);            
        }

        protected string GetInfoImgHref(object strInfoId)
        {
            long infoId = Core.MyConvert.GetInt64(strInfoId.ToString());

            return GetInfoImgHref("U_Certificate", infoId);
        }
    }
}
