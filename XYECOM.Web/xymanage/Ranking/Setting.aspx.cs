using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace XYECOM.Web.xymanage.Ranking
{
    public partial class Setting : XYECOM.Web.BasePage.ManagePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CheckRole("rank");

            if (!IsPostBack)
            {
                InitData();
            }
        }

        protected void btnOK_Click(object sender, EventArgs e)
        {
            if (!XYECOM.Core.XYRequest.IsPost()) return;

            int total = XYECOM.Core.MyConvert.GetInt32(txtRankNumber.Value.Trim());

            if (total <= 0) total =3;

            string timeUnits = this.ddlTimeUnits.SelectedValue;

            List<XYECOM.Configuration.RankingPriceInfo> infos = new List<XYECOM.Configuration.RankingPriceInfo>();

            XYECOM.Configuration.Ranking objRank = XYECOM.Configuration.Ranking.Instance;

            objRank.Total = total;
            objRank.TimeUnits = timeUnits;
            objRank.MoneyType = XYECOM.Configuration.RankingMoneyType.Cash;

            if (rdoVirtualMoney.Checked)
                objRank.MoneyType = XYECOM.Configuration.RankingMoneyType.VirtualMoney;

            string price;

            XYECOM.Configuration.RankingPriceInfo info = null;

            for (short i = 1; i <= total; i++)
            {
                price = XYECOM.Core.XYRequest.GetFormString("rank_" + i).Trim();

                if (string.IsNullOrEmpty(price)) price = "100";

                info = new XYECOM.Configuration.RankingPriceInfo();

                info.Rank = i;
                info.Price = Core.MyConvert.GetInt32(price);

                infos.Add(info);
            }

            objRank.PriceInfo = infos;

            if(objRank.Update())
                Alert("设置成功！","Setting.aspx");
            else
                Alert("设置失败，请检查 /config/目录读写权限！");
        }

        private void InitData()
        {
            this.txtRankNumber.Value = XYECOM.Configuration.Ranking.Instance.Total.ToString();
            this.ddlTimeUnits.Text = XYECOM.Configuration.Ranking.Instance.TimeUnits;

            this.Total.Value = XYECOM.Configuration.Ranking.Instance.Total.ToString();

            if (XYECOM.Configuration.Ranking.Instance.MoneyType == XYECOM.Configuration.RankingMoneyType.Cash)
                this.rdoCach.Checked = true;
            else
                this.rdoVirtualMoney.Checked = true;

            List<XYECOM.Configuration.RankingPriceInfo> infos = XYECOM.Configuration.Ranking.Instance.PriceInfo;

            Table t = new Table();

            t.ID = "tablePrice";
            t.Attributes.Add("class", "");

            TableRow row = new TableRow();
            TableCell cell = new TableCell();

            //row.Attributes.Add("class", "t");

            foreach (XYECOM.Configuration.RankingPriceInfo info in infos)
            {
                row = new TableRow();

                row.ID = "rand_row_" + info.Rank;

                cell = new TableCell();
                cell.Text = info.Rank + ".";

                row.Cells.Add(cell);

                cell = new TableCell();
                //Option Body
                HtmlInputText txt = new HtmlInputText();
                txt.Size = 5;
                txt.MaxLength = 5;
                txt.ID = "rank_" + info.Rank;
                txt.Value = info.Price.ToString();
                cell.Controls.Add(txt);
                row.Cells.Add(cell);


                t.Rows.Add(row);
            }

            phMain.Controls.Add(t);
        }
    }
}
