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

namespace XYECOM.Web.xymanage.Basic
{
    public partial class SEO : XYECOM.Web.BasePage.ManagePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CheckRole("basic");

            if (!IsPostBack)
            {
                BindModuleList();
            }
        }
        private void BindModuleList()
        {
            DataTable table = XYECOM.Configuration.Module.Instance.GetDataTable;

            for (int i = 0; i < table.Rows.Count; i++)
            {
                lstModules.Items.Add(new ListItem(table.Rows[i]["CName"].ToString(), table.Rows[i]["EName"].ToString()));
            }

            this.lstModules.Items.Insert(0, new ListItem("网站首页", "webindex"));
            this.lstModules.Items.Add(new ListItem("展会设置", "exhibition"));
            this.lstModules.Items.Add(new ListItem("品牌设置", "brand"));
            this.lstModules.Items.Add(new ListItem("企业设置", "company"));
            this.lstModules.Items.Add(new ListItem("资讯设置", "news"));
            this.lstModules.Items.Add(new ListItem("人才设置", "job"));

            lstModules.Items[0].Selected = true;
            lstModuls_SelectedChanged(lstModules, new EventArgs());
        }

        protected void lstModuls_SelectedChanged(object sender, EventArgs e)
        {
            string module = lstModules.SelectedValue;

            XYECOM.Configuration.SEO seo = XYECOM.Configuration.SEO.Instance;
            XYECOM.Configuration.SEOInfo seoInfo = null;

            if (seo.IsAppendWebName)
                chkAutoAppendWebName.Checked = true;
            else
                chkAutoAppendWebName.Checked = false;

            seoInfo = seo.GetIndexPageSEO(module);

            if (seoInfo != null)
            {
                txtIndexTitle.Text = seoInfo.Title;
                txtIndexDesc.Text = seoInfo.Description;
                txtIndexKeywords.Text = seoInfo.Keywords;

                if (seoInfo.IsRobots)
                    rdoIsRobotsYes.Checked = true;
                else
                    rdoIsRobotsNo.Checked = true;
            }
            else
            {
                txtIndexTitle.Text = "";
                txtIndexDesc.Text = "";
                txtIndexKeywords.Text = "";
                rdoIsRobotsYes.Checked = true;
            }

            if (module.Equals("webindex"))
            {
                pnlListPage.Visible = false;
                pnlInfoPage.Visible = false;
                return;
            }

            pnlListPage.Visible = true;
            pnlInfoPage.Visible = true;

            seoInfo = seo.GetListPageSEO(module);

            if (seoInfo != null)
            {
                txtListTitle.Text = seoInfo.Title;
                txtListDesc.Text = seoInfo.Description;
                txtListKeywords.Text = seoInfo.Keywords;

                if (seoInfo.IsMatch)
                    chkListIsMatch.Checked = true;
                else
                    chkListIsMatch.Checked = false;
            }
            else
            {
                txtListTitle.Text = "";
                txtListDesc.Text = "";
                txtListKeywords.Text = "";

                chkListIsMatch.Checked = false;
            }

            seoInfo = seo.GetInfoPageSEO(module);

            if (seoInfo != null)
            {
                txtInfoTitle.Text = seoInfo.Title;
                txtInfoDesc.Text = seoInfo.Description;
                txtInfoKeywords.Text = seoInfo.Keywords;

                if (seoInfo.IsMatch)
                    chkInfoIsMatch.Checked = true;
                else
                    chkInfoIsMatch.Checked = false;
            }
            else
            {
                txtInfoTitle.Text = "";
                txtInfoDesc.Text = "";
                txtInfoKeywords.Text = "";

                chkInfoIsMatch.Checked = false;
            }

        }

        protected void btnOK_Click(object sender, EventArgs e)
        {
            string module = this.lstModules.SelectedValue.Trim();

            if (module.Equals("")) return;

            XYECOM.Configuration.SEO seo = XYECOM.Configuration.SEO.Instance;
            XYECOM.Configuration.SEOInfo seoInfo = null;

            if (chkAutoAppendWebName.Checked)
                seo.IsAppendWebName = true;
            else
                seo.IsAppendWebName = false;

            seoInfo = seo.GetIndexPageSEO(module);

            if (seoInfo == null)
            {
                seoInfo = new XYECOM.Configuration.SEOInfo();
                seoInfo.ModuleName = module;
                seoInfo.Title = txtIndexTitle.Text.Trim();
                seoInfo.Description = txtIndexDesc.Text.Trim();
                seoInfo.Keywords = txtIndexKeywords.Text.Trim();
                if (rdoIsRobotsYes.Checked) seoInfo.IsRobots = true;

                seo.IndexPageSEO.Add(seoInfo);
            }
            else
            {
                seoInfo.Title = txtIndexTitle.Text.Trim();
                seoInfo.Description = txtIndexDesc.Text.Trim();
                seoInfo.Keywords = txtIndexKeywords.Text.Trim();
                if (rdoIsRobotsYes.Checked)
                    seoInfo.IsRobots = true;
                else
                    seoInfo.IsRobots = false;
            }

            if (!module.Equals("webindex"))
            {
                seoInfo = seo.GetListPageSEO(module);

                if (seoInfo == null)
                {
                    seoInfo = new XYECOM.Configuration.SEOInfo();
                    seoInfo.ModuleName = module;
                    seoInfo.Title = txtListTitle.Text.Trim();
                    seoInfo.Description = txtListDesc.Text.Trim();
                    seoInfo.Keywords = txtListKeywords.Text.Trim();
                    if (chkListIsMatch.Checked) seoInfo.IsMatch = true;

                    seo.ListPageSEO.Add(seoInfo);
                }
                else
                {
                    seoInfo.Title = txtListTitle.Text.Trim();
                    seoInfo.Description = txtListDesc.Text.Trim();
                    seoInfo.Keywords = txtListKeywords.Text.Trim();
                    if (chkListIsMatch.Checked)
                        seoInfo.IsMatch = true;
                    else
                        seoInfo.IsMatch = false;
                }

                seoInfo = seo.GetInfoPageSEO(module);

                if (seoInfo == null)
                {
                    seoInfo = new XYECOM.Configuration.SEOInfo();
                    seoInfo.ModuleName = module;
                    seoInfo.Title = txtInfoTitle.Text.Trim();
                    seoInfo.Description = txtInfoDesc.Text.Trim();
                    seoInfo.Keywords = txtInfoKeywords.Text.Trim();
                    if (chkInfoIsMatch.Checked) seoInfo.IsMatch = true;

                    seo.InfoPageSEO.Add(seoInfo);
                }
                else
                {
                    seoInfo.Title = txtInfoTitle.Text.Trim();
                    seoInfo.Description = txtInfoDesc.Text.Trim();
                    seoInfo.Keywords = txtInfoKeywords.Text.Trim();

                    if (chkInfoIsMatch.Checked)
                        seoInfo.IsMatch = true;
                    else
                        seoInfo.IsMatch = false;
                }
            }

            seo.Update();
        }

        protected void btnSaveCommon_Click(object sender, EventArgs e)
        {
            XYECOM.Configuration.SEO seo = XYECOM.Configuration.SEO.Instance;

            if (chkAutoAppendWebName.Checked)
                seo.IsAppendWebName = true;
            else
                seo.IsAppendWebName = false;

            seo.Update();
        }
    }
}
