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

namespace XYECOM.Web.xymanage.News
{
    public partial class SetTitleStyle : XYECOM.Web.BasePage.ManagePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CheckRole("news");

            backURL = XYECOM.Core.XYRequest.GetQueryString("backURL");
            if (XYECOM.Core.XYRequest.GetQueryString("backURL").Equals(""))
                backURL = "NewsList.aspx";

            btnBack.Attributes["onclick"] = "location='" + backURL + "'";

            if (Request.QueryString["NS_ID"] != null)
            {
                string newsIds = Request.QueryString["NS_ID"].ToString();

                this.hidNewsIds.Value = newsIds;

                string[] aryIds = newsIds.Split('|');

                string titles = "";

                long nsid = 0;

                this.lbNewsTitles.Text = "";
                foreach (string s in aryIds)
                {
                    nsid = XYECOM.Core.MyConvert.GetInt64(s);

                    titles += GetNewsTitle(nsid) + "<br/>";
                }
                this.lbNewsTitles.Text += titles;
            }
            else
            {
                Alert("��ѡ����Ҫ���õ���Ѷ", backURL);
            }
        }

        /// <summary>
        /// ��ȡ���ű���
        /// </summary>
        /// <param name="nsid">���ŵı��</param>
        /// <returns>�����ŵı���</returns>
        private string GetNewsTitle(Int64 nsid)
        {
            XYECOM.Business.News ne = new XYECOM.Business.News();
            if (nsid <= 0)
                Alert("����������,�޷�����,�����ѡ��", backURL);

            return ne.GetNewsName(nsid);
        }

        protected void btnOK_Click(object sender, EventArgs e)
        {
            string newsIds = this.hidNewsIds.Value.Replace("|",",");

            string titleStyle = "";

            if (!this.txtTitleColor.Value.Trim().Equals("")) titleStyle += "color:" + this.txtTitleColor.Value.Trim() + ";";

            if (this.chkFontBold.Checked) titleStyle += "font-weight:bold;";

            if (this.chkFontItalic.Checked) titleStyle += "font-style:italic;";

            if (this.chkFontUnderline.Checked) titleStyle += "text-decoration:underline";

            if (newsIds.Equals(""))
            {
                Alert("������ѡ��һ����Ѷ��");
                return;
            }
            //���±�
            XYECOM.Core.Function.UpdateColumuByWhere("NS_TitleStyle", titleStyle, " where NS_ID in(" + newsIds + ")", "n_news");

            Response.Redirect(backURL);
        }
    }
}
