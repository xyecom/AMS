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

namespace XYECOM.Web.xymanage.Ranking
{
    public partial class Info :XYECOM.Web.BasePage.ManagePage
    {
        int rid =0;
        protected void Page_Load(object sender, EventArgs e)
        {
            CheckRole("rank");

            rid = XYECOM.Core.XYRequest.GetQueryInt("rid", 0);

            if (rid <= 0)
            {
                Alert("参数不正确！", backURL);
                return;
            }

            backURL = XYECOM.Core.XYRequest.GetQueryString("backURL");

        }

        protected override void BindData()
        {
            DataTable rankData = XYECOM.Business.Utils.ExecuteTable("XYV_Ranking", "Rid,keyword,UI_Name,beginTime,endtime,Rank,userID,KeyId", "RID=" + rid);

            if (rankData.Rows.Count<1)
            {
                Alert("排名信息不存在或已被删除！",backURL);
                return;
            }

            DataRow row = rankData.Rows[0];

            this.lblKeyword.Text = row["keyword"].ToString();
            this.lblRank.Text = row["rank"].ToString();
            this.lblUserName.Text = row["UI_Name"].ToString();
            this.lblBeginTime.Text = row["beginTime"].ToString();

            this.txtEndTime.Value = Core.MyConvert.GetDateTime(row["endTime"].ToString()).ToString("yyyy-MM-dd");
        }

        protected void btnOK_Click(object sender, EventArgs e)
        {
            Business.Ranking BLL = new XYECOM.Business.Ranking();

            Model.RankingInfo info = BLL.GetItem(rid);

            if (info == null)
            {
                Alert("排名信息不存在或已被删除！", backURL);
                return;
            }

            string strNewEndTime = this.txtEndTime.Value.Trim();

            DateTime newEndTime = info.EndTime;

            try
            {
                newEndTime = Convert.ToDateTime(strNewEndTime);
            }
            catch
            {
                Response.Redirect(backURL);
            }

            info.EndTime = newEndTime;

            BLL.Update(info);

            Response.Redirect(backURL);
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect(backURL);
        }
    }
}
