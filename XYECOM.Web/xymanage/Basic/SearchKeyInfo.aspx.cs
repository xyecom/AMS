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
using System.Data.SqlClient;
using XYECOM.Model;
using XYECOM.Business;

public partial class xymanage_basic_SearchKeyInfo : XYECOM.Web.BasePage.ManagePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        CheckRole("hotkeyword");

        backURL = XYECOM.Core.XYRequest.GetQueryString("backURL");

        if (backURL.Equals("")) backURL = "SearchKeyList.aspx";

        btcancel.Attributes["onclick"] = "location='" + backURL + "'";

        if (!IsPostBack)
        {            
            this.hidskid.Value = "-1";
            
            this.cantion.InnerHtml = "添加热门关键字信息";
            
            this.txtCount.Text = "0";
            
            BindModuleList();

            //this.btadd.Attributes.Add("onclick", "javascript:return Input();");

            InitPriceData();

            if (Request.QueryString["sk_id"] != null)
            {
                this.rbIsCommendFalse.Checked = false;
                this.cantion.InnerHtml = "修改热门关键字信息";
                this.chkModules.Visible = false;
                this.lblKeywordsTips.Visible = false;
                this.txtKeywords.Rows = 1;

                BindData(Request.QueryString["sk_id"].ToString());
            }
        }            
    }

    private void BindModuleList()
    {
        foreach (ListItem item in GetAllModules(true))
        {
            this.chkModules.Items.Add(item);
        }
    }

    #region 绑定要修改的热门关键字
    /// <summary>
    /// 绑定要修改的热门关键字
    /// </summary>
    /// <param name="skid"></param>
    private void BindData(string skid)
    {
        if (!string.IsNullOrEmpty(skid))
        {
            SearchKeyInfo ski = new SearchKey().GetItem(int.Parse(skid));

            if (ski == null) return;

            this.hidskid.Value = ski.SK_ID.ToString();
            this.txtKeywords.Text = ski.SK_Name;
            this.hidModuleName.Value = ski.SK_Sort.Trim();

            this.lbtype.Text = GetModuleCNName(ski.SK_Sort);

            this.txtCount.Text = ski.SK_Count.ToString();

            if (ski.SK_IsCommend == true)
                this.rbIsCommendTrue.Checked = true;

            if (ski.SK_IsCommend == false)
                this.rbIsCommendFalse.Checked = true;

            if (ski.SK_IsRanking)
            {
                this.rbIsRankingTrue.Checked = true;
                this.rbIsRankingFalse.Checked = false;
            }
            else
            {
                this.rbIsRankingTrue.Checked = false;
                this.rbIsRankingFalse.Checked = true;
            }

            if (!ski.SK_CustomPrice.Equals(""))
            {
                this.chkIsCustomPrice.Checked = true;
                InitPriceData(ski);
            }
        }
        else
        {
            Alert("要修改的热门关键字编号错误", backURL);
        }
    }
    #endregion
    
    #region 添加或修改热门关键字
    protected void btadd_Click(object sender, EventArgs e)
    {
        XYECOM.Model.SearchKeyInfo keyInfo = new XYECOM.Model.SearchKeyInfo();
        XYECOM.Business.SearchKey BLL = new XYECOM.Business.SearchKey();

        string keywords = this.txtKeywords.Text.Trim().Replace(",,",",").Replace("，",",");

        string[] keys = keywords.Split(',');

        keyInfo.SK_Count = XYECOM.Core.MyConvert.GetInt32(this.txtCount.Text.Trim());

        if (this.rbIsCommendTrue.Checked == true)
            keyInfo.SK_IsCommend = true;
        else
            keyInfo.SK_IsCommend = false;

        if (rbIsRankingTrue.Checked)
            keyInfo.SK_IsRanking = true;
        else
            keyInfo.SK_IsRanking = false;

        keyInfo.SK_CustomPrice = "";

        //如果选定自定义价格
        if (chkIsCustomPrice.Checked)
        {
            XYECOM.Configuration.Ranking objRank = XYECOM.Configuration.Ranking.Instance;

            int total = objRank.Total;

            string strPrice = "";
            int iPrice = 0;

            //记录数据一样的数目
            int tempNumber = 0;

            string customPrice ="";

            for (short i = 1; i <= total; i++)
            {
                strPrice = XYECOM.Core.XYRequest.GetFormString("rank_" + i).Trim();

                iPrice =XYECOM.Core.MyConvert.GetInt32(strPrice);

                if(iPrice <=0) 
                {
                    iPrice = objRank.GetPrice(i);
                }
                else
                {
                    if(iPrice == objRank.GetPrice(i))
                    {
                        tempNumber++;
                    }
                }

                if (customPrice.Equals(""))
                    customPrice = strPrice;
                else
                    customPrice += "|" + strPrice;
            }

            if (tempNumber == total)
                customPrice = "";

            keyInfo.SK_CustomPrice = customPrice;
        }

        string names = "";
        string errnames = "";

        if (this.hidskid.Value == "-1")
        {
            foreach (string k in keys)
            {
                if (k.Trim().Equals("")) continue;
                
                keyInfo.SK_Name = k;

                for (int i = 0; i < this.chkModules.Items.Count; i++)
                {
                    if (this.chkModules.Items[i].Selected == true)
                    {
                        keyInfo.SK_Sort = this.chkModules.Items[i].Value.Trim();
                        int row = BLL.Insert(keyInfo);
                        if (row == -1)
                        {
                            names += this.chkModules.Items[i].Text.Trim();
                        }
                        else if (row == -2)
                        {
                            errnames += this.chkModules.Items[i].Text.Trim();
                        }
                    }
                }
            }
            if (names != "")
            {
                Alert(names + "下已有雷同热词！", "/XYManage/basic/SearchKeyInfo.aspx");
                return;
            }
            else if (errnames != "")
            {
                Alert(errnames + "类别下热词添加失败,可重新添加！", "/XYManage/basic/SearchKeyInfo.aspx");
                return;
            }
            else
            {
                Response.Redirect(backURL);
            }
        }
        else
        {
            
            keyInfo.SK_Name = keywords;
            keyInfo.SK_ID = Int64.Parse(this.hidskid.Value.Trim());
            keyInfo.SK_Sort = this.hidModuleName.Value.Trim();
            if (!BLL.IsExistsOnUpdate(keyInfo))
            {
                int row = BLL.Update(keyInfo);
                if (row >= 0)
                {
                    Response.Redirect(backURL);
                }
                else
                {
                    Alert("修改热词失败,可重新操作！", "/XYManage/basic/SearchKeyInfo.aspx?sk_id=" + keyInfo.SK_ID);
                    return;
                }
            }
            else 
            {
                //存在同名
                Alert(keywords + "下已有雷同热词！", "/XYManage/basic/SearchKeyInfo.aspx?sk_id=" + keyInfo.SK_ID);
                return;
            }
            
        }

    }


    private void InitPriceData()
    {
        List<XYECOM.Configuration.RankingPriceInfo> infos = XYECOM.Configuration.Ranking.Instance.PriceInfo;

        Table t = new Table();

        phMain.Controls.Clear();

        t.ID = "tablePrice";
        TableRow row = new TableRow();
        TableCell cell = new TableCell();

        foreach (XYECOM.Configuration.RankingPriceInfo info in infos)
        {
            cell = new TableCell();
            cell.Text = info.Rank + ".";

            row.Cells.Add(cell);

            cell = new TableCell();

            HtmlInputText txt = new HtmlInputText();
            txt.Size = 5;
            txt.MaxLength = 5;
            txt.ID = "rank_" + info.Rank;
            txt.Value = info.Price.ToString();
            cell.Controls.Add(txt);
            row.Cells.Add(cell);            
        }

        t.Rows.Add(row);
        phMain.Controls.Add(t);
    }

    private void InitPriceData(XYECOM.Model.SearchKeyInfo keyInfo)
    {
        List<XYECOM.Configuration.RankingPriceInfo> infos = XYECOM.Configuration.Ranking.Instance.PriceInfo;

        string[] customPrices = keyInfo.SK_CustomPrice.Split('|');

        Table t = new Table();

        phMain.Controls.Clear();

        t.ID = "tablePrice";
        TableRow row = new TableRow();
        TableCell cell = new TableCell();

        int i = 0;
        foreach (XYECOM.Configuration.RankingPriceInfo info in infos)
        {
            cell = new TableCell();
            cell.Text = info.Rank + ".";

            row.Cells.Add(cell);

            cell = new TableCell();

            HtmlInputText txt = new HtmlInputText();
            txt.Size = 5;
            txt.MaxLength = 5;
            txt.ID = "rank_" + info.Rank;

            if (i < customPrices.Length)
                txt.Value = customPrices[i];
            else
                txt.Value = info.Price.ToString();

            cell.Controls.Add(txt);
            row.Cells.Add(cell);

            i++;
        }

        t.Rows.Add(row);
        phMain.Controls.Add(t);
    }
    #endregion
}
