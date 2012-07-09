using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using XYECOM.Model;

namespace XYECOM.Page.search
{
    /// <summary>
    /// Ä£°å search/ForeBasePage.htm ´úÂëÀà
    /// </summary>
    public class compare : ForeBasePage
    {
        public DataTable dt = new DataTable();
        public string infoflag = "";
        public string linkmodule = "";
        public ArrayList list = new ArrayList();
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (XYECOM.Core.XYRequest.GetQueryString("id") != "" && XYECOM.Core.XYRequest.GetQueryString("flag") != "")
            {
                String[] numids = (XYECOM.Core.XYRequest.GetQueryString("id")).Split(',');
                switch (XYECOM.Core.XYRequest.GetQueryString("flag"))
                {
                    case "offer":
                        pageinfo.ModuleFlag = "offer";
                        XYECOM.Business.Supply sBLL = new XYECOM.Business.Supply();
                        for (int i = 0; i < numids.Length; i++)
                        {
                            XYECOM.Model.SupplyInfo sinfo = new XYECOM.Model.SupplyInfo();
                            sinfo = sBLL.GetItem(Convert.ToInt32(numids[i]));
                            list.Add(sinfo);
                        }
                        break;
                    case "venture":
                        pageinfo.ModuleFlag = "venture";
                        XYECOM.Business.Demand dBLL = new XYECOM.Business.Demand();
                        for (int i = 0; i < numids.Length; i++)
                        {
                            XYECOM.Model.DemandInfo dinfo = new DemandInfo();
                            dinfo = dBLL.GetItem(Convert.ToInt32(numids[i]));
                            list.Add(dinfo);
                        }
                        break;
                    case "investment":
                        pageinfo.ModuleFlag = "investment";
                        XYECOM.Business.InviteBusinessmanInfo iBLL = new XYECOM.Business.InviteBusinessmanInfo();
                        for (int i = 0; i < numids.Length; i++)
                        {
                            XYECOM.Model.InviteBusinessmanInfo iinfo = new InviteBusinessmanInfo();
                            iinfo = iBLL.GetItem(Convert.ToInt32(numids[i]));
                            list.Add(iinfo);
                        }
                        break;
                    case "service":
                        pageinfo.ModuleFlag = "service";
                        XYECOM.Business.ServiceInfo seBLL = new XYECOM.Business.ServiceInfo();
                        for (int i = 0; i < numids.Length; i++)
                        {
                            XYECOM.Model.ServiecInfo seinfo = new ServiecInfo();
                            seinfo = seBLL.GetItem(Convert.ToInt32(numids[i]));
                            list.Add(seinfo);
                        }
                        break;
                }
            }
        }
    }
}
