using System;
using System.Xml;
using System.Web.UI.WebControls;
using System.IO;
using System.Collections.Generic;

namespace XYECOM.Web.xymanage.Global
{
    public partial class NewsSource : XYECOM.Web.BasePage.ManagePage
    {
        protected XYECOM.Business.NewsSource newsSourceBLL = new XYECOM.Business.NewsSource();

        protected void Page_Load(object sender, EventArgs e)
        {
            CheckRole("NewsSource");
        }

        protected override void BindData()
        {
            this.txtDomainName.Text = XYECOM.Configuration.WebInfo.Instance.WebDomain;

            IList<XYECOM.Model.NewsFile> list = newsSourceBLL.GetList();

            if (list.Count < 1)
            {
                this.lblMessage.Text = "上没有生成新闻源文件！";
            }
            else
            {
                this.lblMessage.Text = "";
                this.gvlist.DataSource = list;
            }
            this.gvlist.DataBind();
        }

        protected void btadGeneral_Click(object sender, EventArgs e)
        {
            Model.NewsFileProperty info = new XYECOM.Model.NewsFileProperty();
            info.Count = XYECOM.Core.MyConvert.GetInt32(this.txtCount.Text.Trim());
            info.VirtualPath = this.txtFullPath.Text.Trim();
            info.NewsTypeId = this.hdgetid.Value;
            info.OnlyToday = this.ckToday.Checked ? "1" : "0";
            info.WebMaster = this.txtWebMaster.Text.Trim();
            info.UpdatePeri = this.txtUpdatePeri.Text.Trim();
            info.DomainName = this.txtDomainName.Text.Trim().ToLower();
            //验证
            //Server.MapPath
            //保存
            int res = newsSourceBLL.GeneralNewsSourceXML(info);

            if (res > 0) 
            {
                BindData();
            }
        }

        protected void gvlist_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //判断是否数据行
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes.Add("onmouseover", "javascript:__XY_GV_Row_MouseOver(this)");
                e.Row.Attributes.Add("onmouseout", "javascript:__XY_GV_Row_MouseOut(this);");
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            LinkButton btn = sender as LinkButton;
            
            if (btn == null) return;

            string path = btn.CommandArgument;        

            newsSourceBLL.DeleteFile(path);

            BindData();
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            LinkButton btn = sender as LinkButton;

            if (btn == null) return;

            string path = btn.CommandArgument;

            if (newsSourceBLL.UpdateNewsXml(path.Split('$')))
            {
                BindData();
            }
        }

        protected string GetProperties(string propertiesPath) 
        {
            Model.NewsFileProperty info = newsSourceBLL.AnalyzePropertyFile(propertiesPath);
            if (info == null) 
            {
                return "不存在的属性文件！";
            }
            Model.NewsTitlesInfo title = new XYECOM.Business.NewsTitles().GetItem(XYECOM.Core.MyConvert.GetInt32(info.NewsTypeId));
            return string.Format("新闻栏目:{0}<br />新闻条数:{1}<br />网站域名:{2}<br />", (title == null ? "所有栏目" : title.Name), info.Count, info.DomainName);
        }
    }
}
