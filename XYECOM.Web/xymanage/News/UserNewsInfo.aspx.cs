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

using System.Data.SqlClient;
using XYECOM.Core;
using XYECOM.Business;
using System.Net;
using System.IO;
using System.Text;

namespace XYECOM.Web.xymanage.News
{
    public partial class UserNewsInfo : XYECOM.Web.BasePage.ManagePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            XYECOM.Model.UserNewsInfo info = new XYECOM.Model.UserNewsInfo();

            CheckRole("usernews");

            if (!IsPostBack)
            {
                long newsId = 0;
                newsId = XYECOM.Core.XYRequest.GetQueryInt64("id");
                NewsDataBind(newsId);
                //this.AddOrUpdate的值为0，则表示修改新闻

            }
        }


        #region 绑定要修改的新闻信息
        /// <summary>
        /// 绑定要修改的新闻信息
        /// </summary>
        /// <param name="id">要修改的新闻ID</param>
        private void NewsDataBind(Int64 id)
        {
            int n_id = XYECOM.Core.MyConvert.GetInt16(id.ToString());

            XYECOM.Model.UserNewsInfo newsInfo = new XYECOM.Business.UserNews().GetItem(n_id);

            if (newsInfo != null)
            {
                this.txtTitle.Text = newsInfo.Title.ToString();

                XYECOM.Model.User.UserNewsTitleInfo usertitleinfo = new XYECOM.Business.UserNewsTitle().GetItem(newsInfo.TitleInfoId);
                if (usertitleinfo != null)
                {
                    this.txtTitleInfo.Text = usertitleinfo.Name;
                }
                this.txtTowTitle.Text = newsInfo.TowTitle.ToString();
                this.txtKeyWord.Text = newsInfo.KeyWord.ToString();
                this.txtAuthor.Text = newsInfo.Author.ToString();
                this.txtOrigin.Text = newsInfo.Origin.ToString();
                this.txtLess.Text = newsInfo.Less.ToString();
                this.newsBody.Value = newsInfo.Content.ToString();
            }
        }
        #endregion

        protected void btadadd_Click(object sender, EventArgs e)
        {
            int UserNewsId = XYECOM.Core.MyConvert.GetInt16(XYECOM.Core.XYRequest.GetQueryInt64("id").ToString());
            XYECOM.Model.UserNewsInfo New_newsinfo = new XYECOM.Model.UserNewsInfo();
            XYECOM.Business.UserNews bll = new XYECOM.Business.UserNews();
            XYECOM.Model.UserNewsInfo newsinfo = bll.GetItem(UserNewsId);

            New_newsinfo.NewsId = XYECOM.Core.MyConvert.GetInt16(XYECOM.Core.XYRequest.GetQueryInt64("id").ToString());
            New_newsinfo.Title = this.txtTitle.Text.Trim();
            New_newsinfo.Content = this.newsBody.Value;
            New_newsinfo.TowTitle = this.txtTowTitle.Text.Trim();
            New_newsinfo.KeyWord = this.txtKeyWord.Text.Trim();
            New_newsinfo.Author = this.txtAuthor.Text.Trim();
            New_newsinfo.Origin = this.txtOrigin.Text.Trim();
            New_newsinfo.Less = this.txtLess.Text.Trim();
            New_newsinfo.State = newsinfo.State;
            New_newsinfo.AuditingState = newsinfo.AuditingState;
            New_newsinfo.TitleInfoId = newsinfo.TitleInfoId;

            int k = 0;
            k = bll.Update(New_newsinfo);
            if (k > 0)
            {
                Alert("修改成功！", XYECOM.Core.XYRequest.GetQueryString("backURL"));
            }
            else
            {
                Alert("修改新闻失败,可重新操作.", XYECOM.Core.XYRequest.GetQueryString("backURL"));
            }
        }

        protected void btcancel_ServerClick(object sender, EventArgs e)
        {
            Response.Redirect(XYECOM.Core.XYRequest.GetQueryString("backURL"));
        }
    }
}
