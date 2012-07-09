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

using XYECOM.Business;
using XYECOM.Model;

public partial class xymanage_news_ChargeNewsSetInfo : XYECOM.Web.BasePage.ManagePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        CheckRole("chargenews");

        backURL = XYECOM.Core.XYRequest.GetQueryString("backURL");
        if (XYECOM.Core.XYRequest.GetQueryString("backURL").Equals(""))
            backURL = "ChargeNewsSetList.aspx";

        Button1.Attributes["onclick"] = "location='" + backURL + "'";

        this.nsid.Value = "0";
        if (Request.QueryString["NS_ID"] != null)
        {
            string newsIds = Request.QueryString["NS_ID"].ToString();

            this.nsid.Value = newsIds;

            string[] aryIds = newsIds.Split('|');
            
            string titles = "";

            long nsid = 0;

            this.tbnewstitle.Text = "";
            foreach (string s in aryIds)
            {
                nsid = XYECOM.Core.MyConvert.GetInt64(s);

                titles += GetNewsTitle(nsid) +"<br/>";
            }
            this.tbnewstitle.Text += titles;    

            if (XYECOM.Core.XYRequest.GetQueryString("action") == "edit")
            {
                InitPageControl(nsid);
            }
            else
            {
                InitPageControl(0);
            }
        }
        else
        {
            Alert("请选择你要设置的对象", backURL);
        }
    }

    /// <summary>
    /// 获取新闻标题
    /// </summary>
    /// <param name="nsid">新闻的编号</param>
    /// <returns>该新闻的标题</returns>
    private string GetNewsTitle(Int64 nsid)
    {
        XYECOM.Business.News ne = new XYECOM.Business.News();
        if (nsid <= 0)
            Alert("该新闻有误,无法设置,请从新选择", backURL);

        return ne.GetNewsName(nsid);
    }

    private void InitPageControl(long newsId)
    {
        Table t = new Table();

        TableRow row = new TableRow();
        TableCell cell = new TableCell();
        row.CssClass = "vtop";

        cell.Text = "用户组";
        row.Cells.Add(cell);

        cell = new TableCell();

        cell.Text = "扣除虚拟货币数";
        row.Cells.Add(cell);

        cell = new TableCell();
        cell.Text = "扣除现金货币数";
        row.Cells.Add(cell);

        t.Rows.Add(row);

        XYECOM.Business.ChargeNewsSet cnBLL = new XYECOM.Business.ChargeNewsSet();
        XYECOM.Model.ChargeNewsSetInfo cnInfo = new XYECOM.Model.ChargeNewsSetInfo();

        this.phMain.Controls.Add(t);
    }

    protected void btadd_Click(object sender, EventArgs e)
    {
        XYECOM.Business.ChargeNewsSet cnBLL = new XYECOM.Business.ChargeNewsSet();
        XYECOM.Model.ChargeNewsSetInfo cnInfo = new XYECOM.Model.ChargeNewsSetInfo();
        
        string newsIds = this.nsid.Value;

        this.nsid.Value = newsIds;

        string[] aryIds = newsIds.Split('|');

        long newsId = 0;

        foreach (string s in aryIds)
        {
            newsId = XYECOM.Core.MyConvert.GetInt64(s);

            //更新表，使HTML页面字段保持为空
            XYECOM.Core.Function.UpdateColumuByWhere("NS_HTMLPage", "", " where NS_ID=" + this.nsid.Value, "n_news");
        }

        Alert("收费新闻设置成功", backURL);
    }
}
