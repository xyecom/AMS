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
using XYECOM.Configuration;

namespace XYECOM.Web.xymanage.Global
{
    public partial class UpdateCache : XYECOM.Web.BasePage.ManagePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) InitPage();
        }

        private void InitPage()
        {
            XYECOM.Configuration.Cache cache = XYECOM.Configuration.Cache.Instance;

            //this.txtFilePrefix.Text = cache.Prefix;
            //this.txtFileExtension.Text = cache.Extension;
            this.txtCacehTimeSpan.Text = cache.TimeSpan.ToString();
        }

        protected void btnOK_Click(object sender, EventArgs e)
        {
            //string prefix = this.txtFilePrefix.Text.Trim();
            //string extension = this.txtFileExtension.Text.Trim();
            string timeSpan = this.txtCacehTimeSpan.Text.Trim();

            //extension = extension.Replace("..",".");
            //if (!extension.StartsWith(".")) extension = "." + extension;

            int intTimeSpan = XYECOM.Core.MyConvert.GetInt32(timeSpan);

            XYECOM.Configuration.Cache cache = XYECOM.Configuration.Cache.Instance;

            //cache.Prefix = prefix;
            //cache.Extension = extension;
            cache.TimeSpan = intTimeSpan;

            bool update = cache.Update();

            string message = "配置成功！";
            if (!update)
            {
                message = "配置失败，请检查/Config/目录写权限！";
            }
            else
            {
                InitPage();
            }

            this.ClientScript.RegisterClientScriptBlock(GetType(), "01", "<script>sAlert(\"" + message + "\",'',true);</script>");
        }

        protected void btnUpdateWebConfig_Click(object sender, EventArgs e)
        {
            BaseConfig config = null;

            //网站基本配置
            config = WebInfo.Instance;
            config.Refresh();

            config = XYECOM.URL.Urls.Instance;
            config.Refresh();

            config = XYECOM.Configuration.Template.Instance;
            config.Refresh();

            config = XYECOM.Configuration.SEO.Instance;
            config.Refresh();

            config = Security.Instance;
            config.Refresh();

            config = Payment.Instance;
            config.Refresh();

            config = Module.Instance;
            config.Refresh();

            config = FreeCode.Instance;
            config.Refresh();

            config = XYECOM.Configuration.Cache.Instance;
            config.Refresh();

            XYECOM.URL.Urls.Instance.Refresh();

            this.ClientScript.RegisterClientScriptBlock(GetType(), "01", "<script>sAlert(\"更新成功！\",'',true);</script>");
        }

        protected void btnUpdateAllCache_Click(object sender, EventArgs e)
        {
            XYECOM.Label.LabelCache.Clear();
            this.ClientScript.RegisterClientScriptBlock(GetType(), "01", "<script>sAlert(\"更新成功！\",'',true);</script>");
        }

        protected void btnUpdateContentLabelCache_Click(object sender, EventArgs e)
        {
            XYECOM.Label.LabelCache.Remove(XYECOM.Label.LabelCacheType.ContentLabel);

            this.ClientScript.RegisterClientScriptBlock(GetType(), "01", "<script>sAlert(\"更新成功！\",'',true);</script>");
        }

        protected void btnUpdateClassLabelCache_Click(object sender, EventArgs e)
        {
            XYECOM.Label.LabelCache.Remove(XYECOM.Label.LabelCacheType.ClassLabel);

            this.ClientScript.RegisterClientScriptBlock(GetType(), "01", "<script>sAlert(\"更新成功！\",'',true);</script>");
        }

        protected void btnUpdateSystemLabelCache_Click(object sender, EventArgs e)
        {
            XYECOM.Label.LabelCache.Remove(XYECOM.Label.LabelCacheType.SystemLabel);

            this.ClientScript.RegisterClientScriptBlock(GetType(), "01", "<script>sAlert(\"更新成功！\",'',true);</script>");
        }

        protected void btnUpdateClassInfoStatCache_Click(object sender, EventArgs e)
        {
            XYECOM.Label.LabelCache.Remove(XYECOM.Label.LabelCacheType.ClassInfoStat);

            this.ClientScript.RegisterClientScriptBlock(GetType(), "01", "<script>sAlert(\"更新成功！\",'',true);</script>");
        }

        protected void btnUpdateClassTotalStat_Click(object sender, EventArgs e)
        {
            string sortFlagName = this.ddlSortType.SelectedValue;

            if (sortFlagName.Equals("all"))
            {
                Business.XYClass.UpdateInfoCount(XYECOM.Model.SortType.Offer);

                Business.XYClass.UpdateInfoCount(XYECOM.Model.SortType.Venture);

                Business.XYClass.UpdateInfoCount(XYECOM.Model.SortType.Investment);

                Business.XYClass.UpdateInfoCount(XYECOM.Model.SortType.Service);

                Business.XYClass.UpdateInfoCount(XYECOM.Model.SortType.Brand);

                Business.XYClass.UpdateInfoCount(XYECOM.Model.SortType.Exhibition);

                Business.XYClass.UpdateInfoCount(XYECOM.Model.SortType.Company);

                Business.XYClass.UpdateInfoCount(XYECOM.Model.SortType.Job);
            }
            else
            {
                if (sortFlagName.Equals("offer")) Business.XYClass.UpdateInfoCount(XYECOM.Model.SortType.Offer);

                if (sortFlagName.Equals("venture")) Business.XYClass.UpdateInfoCount(XYECOM.Model.SortType.Venture);

                if (sortFlagName.Equals("investment")) Business.XYClass.UpdateInfoCount(XYECOM.Model.SortType.Investment);

                if (sortFlagName.Equals("service")) Business.XYClass.UpdateInfoCount(XYECOM.Model.SortType.Service);

                if (sortFlagName.Equals("brand")) Business.XYClass.UpdateInfoCount(XYECOM.Model.SortType.Brand);

                if (sortFlagName.Equals("exhibition")) Business.XYClass.UpdateInfoCount(XYECOM.Model.SortType.Exhibition);

                if (sortFlagName.Equals("company")) Business.XYClass.UpdateInfoCount(XYECOM.Model.SortType.Company);

                if (sortFlagName.Equals("job")) Business.XYClass.UpdateInfoCount(XYECOM.Model.SortType.Job);
            }

            Alert("更新完成！");
        }

        protected void btnUpdatePollLabelCache_Click(object sender, EventArgs e)
        {
            XYECOM.Label.LabelCache.Remove(XYECOM.Label.LabelCacheType.PollLabel);

            this.ClientScript.RegisterClientScriptBlock(GetType(), "01", "<script>sAlert(\"更新成功！\",'',true);</script>");
        }
    }
}
