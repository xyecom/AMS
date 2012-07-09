using System;
using System.Data;
using System.Configuration;
using System.Collections.Generic;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class xymanage_ModuleManage_ModuleEdit : XYECOM.Web.BasePage.ManagePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        this.CheckRole("module");

        if (XYECOM.Core.XYRequest.IsPost())
        {
            XYECOM.Configuration.ModuleInfo info = moduleConfig.GetItem(XYECOM.Core.XYRequest.GetQueryString("ename"));
            info.CName = tbcname.Text.Trim();
            info.Description = tbDescription.Text.Trim();
            info.SEName = tbename.Text.Trim();

            info.Item.Clear();

            int total = XYECOM.Core.MyConvert.GetInt32(this.infoTypeTotal.Value.ToString());

            XYECOM.Configuration.ModuleItemInfo iteminfo = null;

            string prefix = "";
            string postfix = "";

            int index = 0;
            for (int i = 1; i <= total; i++)
            {
                prefix = XYECOM.Core.XYRequest.GetFormString("tbprefix" + i);
                postfix = XYECOM.Core.XYRequest.GetFormString("tbpostfix" + i);

                if (prefix.Equals("") && postfix.Equals("")) continue;

                iteminfo = new XYECOM.Configuration.ModuleItemInfo();
                iteminfo.InfoTypeStr = XYECOM.Core.XYRequest.GetFormString("hidInfoType_" + i);

                iteminfo.ID = index + 1;
                iteminfo.Prefix = prefix;
                iteminfo.Postfix = postfix;

                info.Item.Add(iteminfo);
                index++;
            }

            if (index == 0)
            {
                Alert("模块必须包含至少一种信息类型！");
                return;
            }

            if (moduleConfig.Update())
            {
                Alert("“" + this.tbename.Text + "”模块修改成功！", "ModuleList.aspx");
            }
            else
            {
                Alert("“" + this.tbename.Text + "”模块修改失败，请检查 /Config/ 目录写权限！","ModuleList.aspx");
            }

            return;
        }

        if (!IsPostBack)
        {
            if (XYECOM.Core.XYRequest.GetQueryString("ename").Equals("exhibition"))
            {
                this.pnlSEOSetting.Visible = false;
            }

            if (XYECOM.Core.XYRequest.GetQueryString("ename") != "")
            {
                XYECOM.Configuration.ModuleInfo info = moduleConfig.GetItem(XYECOM.Core.XYRequest.GetQueryString("ename"));
                
                this.tbcname.Text = info.CName;
                this.tbDescription.Text = info.Description;
                this.tbename.Text = info.SEName;


                try
                {
                    InitItemList(info.Item);
                }
                catch { }
               
                if (moduleConfig.GetItem(info.PEName) != null)
                {
                    this.lblName.Text = moduleConfig.GetItem(info.PEName).CName;
                }
                else
                {
                    this.lblName.Text = "基本模块";
                }
            }
        }
    }

    private void InitItemList(List<XYECOM.Configuration.ModuleItemInfo> infos)
    {
        Table t = new Table();

        t.ID = "tableInfoType";
        t.Attributes.Add("class", "s_f_p");

        TableRow row = new TableRow();
        TableCell cell = new TableCell();

        row.Attributes.Add("class","t");

        cell.Text = "";
        row.Cells.Add(cell);

        cell = new TableCell();
        cell.Text = "前缀";
        row.Cells.Add(cell);

        cell = new TableCell();
        cell.Text = "后缀";
        row.Cells.Add(cell);

        cell = new TableCell();
        cell.Text = "信息类型";
        row.Cells.Add(cell);

        cell = new TableCell();
        cell.Text = "&nbsp;";
        row.Cells.Add(cell);

        t.Rows.Add(row);

        int i= 1;
        foreach(XYECOM.Configuration.ModuleItemInfo item in infos)
        {
            row = new TableRow();

            cell = new TableCell();
            HtmlInputText txt = new HtmlInputText();
            txt.ID = "tbid" + item.ID;
            txt.Value = item.ID.ToString();
            txt.Attributes.Add("readonly","readonly");
            txt.Attributes.Add("class", "m_i");
            cell.Controls.Add(txt);

            row.Cells.Add(cell);

            cell = new TableCell();
            txt = new HtmlInputText();
            txt.ID = "tbprefix" + item.ID;
            txt.Value = item.Prefix;
            cell.Controls.Add(txt);
            row.Cells.Add(cell);

            cell = new TableCell();
            txt = new HtmlInputText();
            txt.ID = "tbpostfix" + item.ID;
            txt.Value = item.Postfix;
            cell.Controls.Add(txt);
            row.Cells.Add(cell);

            cell = new TableCell();


            string isBuyStr = "checked=\"checked\"";
            string isSellStr = "checked=\"checked\"";
            string infoTypeStr = "";
            if (item.InfoType == XYECOM.Configuration.InfoType.Sell)
            {
                isBuyStr = "";
                infoTypeStr = "sell";
            }
            else
            {
                isSellStr = "";
                infoTypeStr = "buy";
            }

            string body = "<input type=\"radio\" name=\"rb" + item.ID + "\" value=\"sell\" " + isSellStr + " onclick=\"SetInfoTypeValue(" + item.ID + ");\"/>供&nbsp;"
                + "<input type=\"radio\" name=\"rb" + item.ID + "\" value=\"buy\" " + isBuyStr + " onclick=\"SetInfoTypeValue(" + item.ID + ");\"/>求"
                + "<input type=\"hidden\" id=\"hidInfoType_" + item.ID + "\" name=\"hidInfoType_" + item.ID + "\" value=\"" + infoTypeStr + "\" />";

            cell.Text = body;
            row.Cells.Add(cell);
                
            cell = new TableCell();
            cell.ID = "tdDel_" + item.ID;

            if(i== infos.Count && i != 1)
                cell.Attributes.Add("style", "display:;");
            else
                cell.Attributes.Add("style", "display:none;");

            cell.Text = "<a href=\"#\" onclick=\"DeleteInfoType("+item.ID+");\"><img src=\"../images/delete1.gif\" alt=\"删除\" border=\"0\"/></a>";

            row.Cells.Add(cell);

            t.Rows.Add(row);
            i++;
        }

        this.infoTypeTotal.Value = infos.Count.ToString();
        phMain.Controls.Add(t);
    }
}
