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
    public partial class EditAreaSite : XYECOM.Web.BasePage.ManagePage
    {
        private static bool isEdit = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            CheckRole("areasite");

            if (!IsPostBack)
            {
                int siteId = XYECOM.Core.XYRequest.GetQueryInt("siteid", 0);

                if (siteId > 0)
                {
                    isEdit = true;
                    BindData(siteId);
                }
                else
                {
                    isEdit = false;
                }
            }
        }

        private void BindData(int siteId)
        {
            Model.AreaSiteInfo info = new Business.AreaSite().GetItemBySiteId(siteId);

            if (info == null) return;

            txtAraeID.Text = info.AreaId.ToString();

            txtFlagName.Text = info.FlagName;

            if (info.IsCostomTemplate)
                chkIsCustomTemplate.Checked = true;
            else
                chkIsCustomTemplate.Checked = false;
        }

        protected void btnOK_Click(object sender, EventArgs e)
        {
            int areaId = Core.MyConvert.GetInt32(txtAraeID.Text.Trim());
            string flagName = txtFlagName.Text.Trim();
            bool isCustomTemplate = chkIsCustomTemplate.Checked;

            if (areaId <= 0)
            {
                Alert("��ѡ�������");
                return;
            }

            if (flagName.Equals(""))
            {
                Alert("��ʶ���Ʋ���Ϊ�գ�");
                return;
            }

            Model.AreaSiteInfo info = null;
            XYECOM.Business.AreaSite BLL = new XYECOM.Business.AreaSite();

            if (!isEdit)
            {
                bool result = IsExistsAreaId(areaId);

                if (result)
                {
                    Alert("������Ӧ��վ�Ѿ����ڣ���ѡ������������");
                    return;
                }

                result = IsExistsFlagName(flagName);

                if (result)
                {
                    Alert("��ʶ�����ظ���");
                    return;
                }

                info = new XYECOM.Model.AreaSiteInfo();

                info.AreaId = areaId;
                info.FlagName = flagName;
                info.IsCostomTemplate = isCustomTemplate;

                int i = BLL.Insert(info);
                if (i > 0)
                    Response.Redirect("AreaSiteManage.aspx");
                else
                    Alert("����ʧ�ܣ�");
            }
            else
            {
                int siteId = XYECOM.Core.XYRequest.GetQueryInt("siteid",0);

                bool result = IsExistsFlagName(flagName, siteId);

                if (result)
                {
                    Alert("��ʶ�����ظ���");
                    return;
                }

                info = BLL.GetItemBySiteId(siteId);

                info.AreaId = areaId;
                info.FlagName = flagName;
                info.IsCostomTemplate = isCustomTemplate;

                int i = BLL.Update(info);
                if (i > 0)
                    Response.Redirect("AreaSiteManage.aspx");
                else
                    Alert("����ʧ�ܣ�");

            }
        }

        private bool IsExistsAreaId(int areaId)
        {
            Business.AreaSite BLL = new XYECOM.Business.AreaSite();

            Model.AreaSiteInfo info = BLL.GetItemByAreaId(areaId);

            if (info == null) return false;

            return true;
        }

        private bool IsExistsFlagName(string flagName)
        {
            DataTable table = new XYECOM.Business.AreaSite().GetDataTable();

            DataRow[] rows = table.Select("flagName='"+flagName+"'");

            if (rows != null && rows.Length > 0) return true;

            return false;
        }

        private bool IsExistsFlagName(string flagName, int siteId)
        {
            DataTable table = new XYECOM.Business.AreaSite().GetDataTable();

            DataRow[] rows = table.Select("flagName='" + flagName + "' and id <> " + siteId);

            if (rows != null && rows.Length > 0) return true;

            return false;
        }
    }
}
