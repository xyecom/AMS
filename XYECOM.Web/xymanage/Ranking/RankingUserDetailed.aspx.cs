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
using XYECOM.Model;
namespace XYECOM.Web.xymanage.Ranking
{
    public partial class RankingUserDetailed : XYECOM.Web.BasePage.ManagePage
    {

        private XYECOM.Model.RankingUserInfo ru
        {
            get { return (RankingUserInfo)ViewState["ru"]; }
            set { ViewState["ru"] = value; }
        }

        XYECOM.Business.RanKingUserInfo BLL = new XYECOM.Business.RanKingUserInfo();

        protected void Page_Load(object sender, EventArgs e)
        {
            CheckRole("rank");

            if (!IsPostBack)
            {
                int InfoId = XYECOM.Core.XYRequest.GetInt("InfoId", 0);

                UploadFile1.InfoID = InfoId;

                //�õ��û��Զ������Ϣ
                XYECOM.Model.RankingUserInfo ruinfo = BLL.GetItem(InfoId);
                //�ѵõ����û��Զ�����Ϣ�ŵ�ҳ���෶Χ����ͼ��
                ru = ruinfo;
                this.txtTitle.Text = ruinfo.Title;
                this.txtUrl.Text = ruinfo.Link;
                this.txtDesc.Text = ruinfo.Desc;
                this.txtImageUrl.Text = ruinfo.ImageUrl;
            }
        }

        protected void btnok_Click(object sender, EventArgs e)
        {
            ru.Title = this.txtTitle.Text.Trim();
            ru.Link = this.txtUrl.Text.Trim();
            ru.Desc = this.txtDesc.Text.Trim();
            ru.ImageUrl = this.txtImageUrl.Text.Trim();
            int num = BLL.Update(ru);
            if (num > 0)
            {
                UploadFile1.InfoID = ru.InfoId;
                UploadFile1.Update();

                string backURL = XYECOM.Core.XYRequest.GetQueryString("backURL");

                Alert("�޸ĳɹ���", backURL);
            }
            else
            {
                Alert("�޸�ʧ�ܣ�");
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            string backURL = XYECOM.Core.XYRequest.GetQueryString("backURL");
            if (backURL == "")
            {
                backURL = "RankingUserList.aspx";
            }
            Response.Redirect(backURL);
        }
    }
}
