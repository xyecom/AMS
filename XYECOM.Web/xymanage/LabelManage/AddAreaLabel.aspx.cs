using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using XYECOM.Model;

namespace XYECOM.Web.xymanage.LabelManage
{
    public partial class AddAreaLabel : XYECOM.Web.BasePage.ManagePage
    {
        private const string Img1 = "<img src=\"../images/bg_shrink.gif\" />";
        private const string Img2 = "<img src=\"../images/bg_spread.gif\" />";

        protected void Page_Load(object sender, EventArgs e)
        {
            CheckRole("label");
            if (!IsPostBack)
            {
                BindClassList();
            }
        }

        /// <summary>
        /// 绑定数据
        /// </summary>
        protected override void BindData()
        {
            foreach (XYECOM.Configuration.ModuleInfo info in moduleConfig.ModuleItems)
            {
                ddlClass.Items.Add(new ListItem(info.CName, info.EName));
            }

            ddlClass.Items.Add(new ListItem("行业品牌", "brand"));
            ddlClass.Items.Add(new ListItem("人才招聘", "job"));
            ddlClass.Items.Add(new ListItem("企业导航", "company"));

            ddlClass.Items.Insert(0, new ListItem("请选择导航至模块", ""));
        }

        private void BindClassList()
        {
            List<Model.AreaInfo> infos = new Business.Area().GetItems(0);

            this.pnlSuperClass.Controls.Add(new LiteralControl("<dt>"));
            foreach (Model.AreaInfo info in infos)
            {
                AddInfoHtml(info, "0", "");
                if (info.HasSubArea)
                {
                    AddChild(info, "&nbsp;&nbsp;&nbsp;&nbsp;");
                }
            }
            this.pnlSuperClass.Controls.Add(new LiteralControl("</dt>"));
        }

        private void AddChild(Model.AreaInfo info, string str)
        {
            this.pnlSuperClass.Controls.Add(new LiteralControl("<dl id=\"li_" + info.ID + "\" style=\"display:none;\"><dt>"));
            List<Model.AreaInfo> infos = new Business.Area().GetItems(info.ID);
            foreach (Model.AreaInfo info2 in infos)
            {
                AddInfoHtml(info2, info.ID.ToString(), str);
                if (info2.HasSubArea)
                {
                    AddChild(info2, str + "&nbsp;&nbsp;&nbsp;&nbsp;");
                }
            }
            this.pnlSuperClass.Controls.Add(new LiteralControl("</dl></dt>"));
        }

        private void AddInfoHtml(Model.AreaInfo info, string parentID, string str)
        {
            StringBuilder strhtml = new StringBuilder();
            strhtml.AppendLine("<dl id=\"lithis" + info.ID + "\">");
            strhtml.AppendLine(str);
            strhtml.AppendLine("<input id=\"input_" + parentID + "_" + info.ID + "\" type=\"checkbox\" value=\"" + info.ID + "|" + Core.Utils.JSEscape(info.Name) + "\" />");
            strhtml.AppendLine(info.HasSubArea ? "<a href=\"javascript:LabelClassDisplay('li_" + info.ID + "','lithis" + info.ID + "');\">" + Img1 + "</a>" : Img2);
            strhtml.AppendLine(info.HasSubArea ? " <a href=\"javascript:SetLabelClass2('" + info.ID + "');\" title=\"添加到二级分类\">" + info.Name + "</a>" : info.Name);
            strhtml.AppendLine("</dl>");
            this.pnlSuperClass.Controls.Add(new LiteralControl(strhtml.ToString()));
        }

        /// <summary>
        /// 完成
        /// </summary>
        protected void btnFinish_Click(object sender, EventArgs e)
        {
            try
            {
                if (CombinationHTML())
                {
                    Response.Redirect("ClassLabelList.aspx");
                }
            }
            catch
            {
                Alert("组合失败,请重新组合！\",\"组合失败,请重新组合！", "ClassLabelList.aspx");
            }
        }

        protected void btnCall_Click(object sender, EventArgs e)
        {
            if ("" == ddlClass.Text) return;
            if (!Core.Utils.IsNumber(txtLevel.Text.Trim())) return;
            int level = Core.MyConvert.GetInt32(txtLevel.Text.Trim());

            List<Model.AreaInfo> infos = new Business.Area().GetItems(0);

            System.Text.StringBuilder strHTML = new System.Text.StringBuilder("");
            strHTML.Append("<ul>");
            foreach (Model.AreaInfo info in infos)
            {
                strHTML.Append("<li>");
                strHTML.Append("<span>");

                strHTML.Append(SetHtmlUrl(info.ID.ToString(), info.Name));

                //strHTML = strHTML.Append("//");
                strHTML.Append("</span>");

                if (info.HasSubArea)
                {
                    List<Model.AreaInfo> childList = new Business.Area().GetItems(info.ID);
                    strHTML.Append(GetChildHTML(childList, 1, level));
                }
                strHTML.Append("</li>");
            }
            strHTML.Append("</ul>");


            string labelName = this.txtLabelName.Text.Trim();

            XYECOM.Business.ClassLabel dal = new XYECOM.Business.ClassLabel();

            if (dal.IsExists("XY_CLS_" + labelName))
            {
                this.lblMsg.Text = "标签名称重复，请选择其他名称！";
                return;
            }

            Model.ClassLabelInfo clsLabelInfo = new XYECOM.Model.ClassLabelInfo();

            clsLabelInfo.Name = "XY_CLS_" + labelName;
            clsLabelInfo.CNName = this.txtCNName.Text.Trim();
            clsLabelInfo.Body = strHTML.ToString().Replace("///", "");
            clsLabelInfo.TableName = "XY_Area";

            new Business.ClassLabel().Insert(clsLabelInfo);
            Response.Redirect("ClassLabelList.aspx");
        }

        private string GetChildHTML(List<Model.AreaInfo> infolist, int thislevel, int level)
        {
            if (thislevel >= level) return "";
            string htmllistflag = "dl";
            string htmlitemflag = "dd";

            if (thislevel == 1)
            {
                htmllistflag = "ol";
                htmlitemflag = "li";
            }

            System.Text.StringBuilder strHTML = new System.Text.StringBuilder();

            strHTML.Append("<" + htmllistflag + ">");
            foreach (Model.AreaInfo info in infolist)
            {
                strHTML.Append("<" + htmlitemflag + ">");
                strHTML.Append(SetHtmlUrl(info.ID.ToString(), info.Name));
                if (info.HasSubArea)
                {
                    List<Model.AreaInfo> childs = new Business.Area().GetItems(info.ID);
                    strHTML.Append(GetChildHTML(childs, ++thislevel, level));
                }
                strHTML.Append("</" + htmlitemflag + ">");
            }
            strHTML.Append("</" + htmllistflag + ">");
            return strHTML.ToString();
        }

        /// <summary>
        /// 组合HTML
        /// </summary>
        private bool CombinationHTML()
        {
            System.Text.StringBuilder strHTML = new System.Text.StringBuilder("");
            strHTML.Append("<ul>");
            //岗位
            string[] arrCom = hddValue.Value.Split('$');
            foreach (string com in arrCom)
            {
                strHTML.Append("<li>");

                string[] arrcls = com.Split('#');
                string[] arrcls1 = arrcls[0].Split(',');
                strHTML.Append("<span>");
                foreach (string cls in arrcls1)
                {
                    string[] obj = cls.Split('|');
                    strHTML.Append(SetHtmlUrl(obj[0], Core.Utils.JSunescape(obj[1])));
                }
                //strHTML = strHTML.Append("//");
                strHTML.Append("</span>");

                if ("" != arrcls[1])
                {
                    string[] arrcls2 = arrcls[1].Split(',');
                    strHTML.Append("<ol>");
                    foreach (string cls in arrcls2)
                    {
                        string[] obj = cls.Split('|');
                        strHTML.Append("<li>");
                        strHTML.Append(SetHtmlUrl(obj[0], Core.Utils.JSunescape(obj[1])));
                        strHTML.Append("</li>");
                    }
                    strHTML.Append("</ol>");
                }
                strHTML.Append("</li>");
            }
            strHTML.Append("</ul>");


            string labelName = this.txtLabelName.Text.Trim();

            XYECOM.Business.ClassLabel dal = new XYECOM.Business.ClassLabel();

            if (dal.IsExists("XY_CLS_" + labelName))
            {
                this.lblMsg.Text = "标签名称重复，请选择其他名称！";
                return false;
            }

            Model.ClassLabelInfo clsLabelInfo = new XYECOM.Model.ClassLabelInfo();

            clsLabelInfo.Name = "XY_CLS_" + labelName;
            clsLabelInfo.CNName = this.txtCNName.Text.Trim();
            clsLabelInfo.Body = strHTML.ToString().Replace("///", "");
            clsLabelInfo.TableName = "XY_Area";

            new Business.ClassLabel().Insert(clsLabelInfo);

            return true;
        }

        private string SetHtmlUrl(string id, string name)
        {
            System.Text.StringBuilder strHTML = new System.Text.StringBuilder();
            if ("job" == ddlClass.Text.ToLower())
            {
                strHTML.Append(string.Format("<a href='[area-job:{0}]' target=_blank>{1}</a> ", id, name));
            }
            else
            {
                strHTML.Append(string.Format("<a href='[area-" + rblToPage.SelectedValue.Trim() + ":{0},{1}]' target=_blank>{2}</a> ", id, ddlClass.SelectedValue.Trim(), name));
            }
            return strHTML.ToString();
        }
    }
}
