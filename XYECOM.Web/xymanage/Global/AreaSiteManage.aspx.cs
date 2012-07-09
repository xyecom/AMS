using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace XYECOM.Web.xymanage.Global
{
    public partial class AreaSiteManage : XYECOM.Web.BasePage.ManagePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
  
        }

        protected override void BindData()
        {
            DataTable dt = new XYECOM.Business.AreaSite().GetDataTable();

            this.gvlist.DataSource = dt;
            this.gvlist.DataBind();
        }

        protected void gvlist_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes.Add("onmouseover", "javascript:__XY_GV_Row_MouseOver(this)");
                e.Row.Attributes.Add("onmouseout", "javascript:__XY_GV_Row_MouseOut(this);");
            }
        }

        protected void lnkDel_Click(object sender, EventArgs e)
        {
            int siteId= 0;

            XYECOM.Business.AreaSite BLL = new XYECOM.Business.AreaSite();

            foreach (GridViewRow row in this.gvlist.Rows)
            {
                if (((CheckBox)(row.FindControl("chkExport"))).Checked == true)
                {
                    siteId = Core.MyConvert.GetInt32(this.gvlist.DataKeys[row.DataItemIndex].Value.ToString());
                    BLL.Delete(siteId);
                }
            }

            BindData();
        }

        protected string GetAraName(object objAreaId)
        {
            int areaId = Core.MyConvert.GetInt32(objAreaId.ToString());

            if (areaId <= 0) return "";

            Model.AreaInfo area = new Business.Area().GetItem(areaId);

            if (area == null) return "";

            return area.Name;
        }

        protected string GetHref(object flagName)
        {
            if (flagName.ToString().Equals("")) return "";

            if (webInfo.IsAreaDomain)
            {
                return webInfo.GetSubDomain(flagName.ToString());
            }
            else
            {
                if (webInfo.IsBogusStatic)
                    return "/area/" + flagName + "-index." + webInfo.WebSuffix;
                else
                    return "/area/index." + webInfo.WebSuffix + "?fn=" + flagName;
            }
        }
    }
}
