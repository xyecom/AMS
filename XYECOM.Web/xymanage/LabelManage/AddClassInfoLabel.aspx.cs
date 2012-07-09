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
    public partial class AddClassInfoLabel : XYECOM.Web.BasePage.ManagePage
    {
        private const string Img1 = "<img src=\"../images/bg_shrink.gif\" />";
        private const string Img2 = "<img src=\"../images/bg_spread.gif\" />";

        protected void Page_Load(object sender, EventArgs e)
        {
            CheckRole("label");
        }

        /// <summary>
        /// 绑定数据
        /// </summary>
        protected override void BindData()
        {
            foreach (ListItem item in GetAllModules(true))
            {
                ddlClass.Items.Add(new ListItem(item.Text, item.Value));
            }

            ddlClass.Items.Insert(0, new ListItem("请选择要显示的分类", ""));
        }

        protected void ddlClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ("" == ddlClass.Text)
            {
                rblProduct.Visible = false;
                rblMachining.Visible = false;
                rblInvestment.Visible = false;
                rblService.Visible = false;
                rblNewsType.Visible = false;
                return;
            }

            string moduleName = ddlClass.SelectedValue.Trim();

            BindClassList(moduleName);
            
            string parentModuleName = "";

            XYECOM.Configuration.ModuleInfo moduleInfo = moduleConfig.GetItem(moduleName);

            if (moduleInfo != null && "" != moduleInfo.PEName)
                parentModuleName = moduleInfo.PEName;
            else
                parentModuleName = moduleName;

            if ("offer" == parentModuleName)
                rblProduct.Visible = true;
            else
                rblProduct.Visible = false;

            if ("venture" == parentModuleName)
                rblMachining.Visible = true;
            else
                rblMachining.Visible = false;
            if ("investment" == parentModuleName)
                rblInvestment.Visible = true;
            else
                rblInvestment.Visible = false;
            if ("service" == parentModuleName)
                rblService.Visible = true;
            else
                rblService.Visible = false;
            if ("news" == parentModuleName)
                rblNewsType.Visible = true;
            else
                rblNewsType.Visible = false;
        }

        private void BindClassList(string moduleName)
        {
            List<Model.XYClassInfo> infos = Business.XYClass.GetItemsAll(moduleName);

            this.pnlSuperClass.Controls.Add(new LiteralControl("<dt>"));
            foreach (Model.XYClassInfo info in infos)
            {
                AddInfoHtml(info, "0", "");
                if (info.HasSub)
                {
                    AddChild(info, "&nbsp;&nbsp;&nbsp;&nbsp;");
                    //AddChild(info, "");
                }
            }
            this.pnlSuperClass.Controls.Add(new LiteralControl("</dt>"));
        }

        private void AddChild(Model.XYClassInfo info, string str)
        {
            this.pnlSuperClass.Controls.Add(new LiteralControl("<dl id=\"li_" + info.ClassId + "\" style=\"display:none;\"><dt>"));
            //this.pnlSuperClass.Controls.Add(new LiteralControl("<dl id=\"li_" + info.ClassId + "\"><dt>"));
            foreach (Model.XYClassInfo info2 in info.childList)
            {
                AddInfoHtml(info2, info.ClassId.ToString(), str);
                if (info2.HasSub)
                {
                    AddChild(info2, str + "&nbsp;&nbsp;&nbsp;&nbsp;");
                    //AddChild(info2, str + "");
                }
            }
            this.pnlSuperClass.Controls.Add(new LiteralControl("</dt></dl>"));
        }

        private void AddInfoHtml(Model.XYClassInfo info, string parentID, string str)
        {
            StringBuilder strhtml = new StringBuilder();
            strhtml.AppendLine("<dl id=\"lithis" + info.ClassId + "\">");
            strhtml.AppendLine(str);
            strhtml.AppendLine("<input id=\"input_" + parentID + "_" + info.ClassId + "\" type=\"checkbox\" value=\"" + info.ClassId + "|" + Core.Utils.JSEscape(info.ClassName) + "\" />");
            strhtml.AppendLine(info.HasSub ? "<a href=\"javascript:LabelClassDisplay('li_" + info.ClassId + "','lithis" + info.ClassId + "');\">" + Img1 + "</a>" : Img2);
            strhtml.AppendLine(info.HasSub ? " <a href=\"javascript:SetLabelClass2('" + info.ClassId + "');\" title=\"添加到二级分类\">" + info.ClassName + "</a>" : info.ClassName);
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

            List<Model.XYClassInfo> infos = Business.XYClass.GetItemsAll(ddlClass.Text);

            System.Text.StringBuilder strHTML = new System.Text.StringBuilder("");
            
            foreach (Model.XYClassInfo info in infos)
            {
                strHTML.Append("<dl>" + ((char)10).ToString());
                strHTML.Append("<dt>");
                strHTML.Append("<h4>");

                strHTML.Append(SetHtmlUrl(info.ClassId.ToString(), info.ClassName));

                //strHTML = strHTML.Append("//");
                strHTML.Append("</h4>");
                strHTML.Append("</dt>");

                strHTML.Append(((char)10).ToString());
                
                if (info.HasSub)
                {
                    strHTML.Append(GetChildHTML(info.childList, 1, level));
                }
               
                strHTML.Append("</dl>"  +((char)10).ToString());
            }
           


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
            clsLabelInfo.TableName = Business.XYClass.GetTableInfo(ddlClass.Text.ToLower()).TableName;

            new Business.ClassLabel().Insert(clsLabelInfo);
            Response.Redirect("ClassLabelList.aspx");
        }

        private string GetChildHTML(List<Model.XYClassInfo> infolist, int thislevel, int level)
        {
            if (thislevel >= level) return "";
            string htmllistflag = "span";
            string htmlitemflag = "";

            if (thislevel == 1)
            {
                htmllistflag = "dd";
                htmlitemflag = "ul";
            }

            System.Text.StringBuilder strHTML = new System.Text.StringBuilder();

            strHTML.Append("<" + htmllistflag + ">");
            strHTML.Append(((char)10).ToString());

            if (!htmlitemflag.Equals(""))
            {
                strHTML.Append("<" + htmlitemflag + ">");
                strHTML.Append(((char)10).ToString());
            }

            int nextLevel = thislevel + 1;

            foreach (Model.XYClassInfo info in infolist)
            {
                strHTML.Append(SetHtmlUrl(info.ClassId.ToString(), info.ClassName));
                strHTML.Append(((char)10).ToString());

                if (info.HasSub)
                {
                    strHTML.Append(GetChildHTML(info.childList, nextLevel, level));
                }   
            }
            if (!htmlitemflag.Equals(""))
            {
                strHTML.Append("</" + htmlitemflag + ">");
                strHTML.Append(((char)10).ToString());
            }

            strHTML.Append("</" + htmllistflag + ">");
            strHTML.Append(((char)10).ToString());
            return strHTML.ToString();
        }

        /// <summary>
        /// 组合HTML
        /// </summary>
        private bool CombinationHTML()
        {
            System.Text.StringBuilder strHTML = new System.Text.StringBuilder("");
            
            //岗位
            string[] arrCom = hddValue.Value.Split('$');
            foreach (string com in arrCom)
            {
                strHTML.Append("<dl>" + ((char)10).ToString());
                strHTML.Append("<dt>");

                string[] arrcls = com.Split('#');
                string[] arrcls1 = arrcls[0].Split(',');
                strHTML.Append("<h4>");
                foreach (string cls in arrcls1)
                {
                    string[] obj = cls.Split('|');
                    strHTML.Append(SetHtmlUrl(obj[0], Core.Utils.JSunescape(obj[1])));
                }
                //strHTML = strHTML.Append("//");
                strHTML.Append("</h4>");
                strHTML.Append("</dt>" + ((char)10).ToString());

                if ("" != arrcls[1])
                {
                    strHTML.Append("<dd>" + ((char)10).ToString());
                    string[] arrcls2 = arrcls[1].Split(',');
                    strHTML.Append("<ul>" + ((char)10).ToString());
                    foreach (string cls in arrcls2)
                    {
                        string[] obj = cls.Split('|');
                        strHTML.Append(SetHtmlUrl(obj[0], Core.Utils.JSunescape(obj[1])));
                        strHTML.Append(((char)10).ToString());
                    }
                    strHTML.Append("</ul>" + ((char)10).ToString());
                    strHTML.Append("</dd>" + ((char)10).ToString());
                }
                strHTML.Append("</dl>" + ((char)10).ToString());
                //strHTML.Append("</li>" + ((char)10).ToString());
            }
            


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
            clsLabelInfo.TableName = Business.XYClass.GetTableInfo(ddlClass.Text.ToLower()).TableName;

            new Business.ClassLabel().Insert(clsLabelInfo);

            return true;
        }

        private string SetHtmlUrl(string id, string name)
        {
            System.Text.StringBuilder strHTML = new System.Text.StringBuilder();
            if ("job" == ddlClass.Text.ToLower())
            {
                strHTML.Append(string.Format("<a href='[job-link:{0}]' target='_blank'>{1}</a>", id, name));
            }
            else if ("news" == ddlClass.Text.ToLower() && "buy" == rblNewsType.Text.Trim().ToLower())
            {
                strHTML.Append(string.Format("<a href='[news-link:{0}]' target='_blank'>{1}</a>" , id, name));
            }
            else if ("baike" == ddlClass.Text.ToLower())
            {
                strHTML.Append(string.Format("<a href='[baike-link:{0}]' target='_blank'>{1}</a>", id, name));
            }
            else
            {
                string parentModuleName = ddlClass.Text.Trim().ToLower();
                string currentModuleName = parentModuleName;

                if (("offer" == parentModuleName && "cate" == rblProduct.Text.Trim().ToLower()))
                {
                    strHTML.Append(string.Format("<a href='[cate-link:{0},{1}]' target='_blank'>{2}</a>", currentModuleName, id, name));
                }
                else if (("offer" == parentModuleName && "buy" == rblProduct.Text.Trim().ToLower())
                    || ("venture" == parentModuleName && "buy" == rblMachining.Text.Trim().ToLower())
                    || ("investment" == parentModuleName && "buy" == rblInvestment.Text.Trim().ToLower())
                    || ("service" == parentModuleName && "buy" == rblService.Text.Trim().ToLower()))
                {
                    strHTML.Append(string.Format("<a href='[buy-link:{0},{1}]' target='_blank'>{2}</a>", currentModuleName, id, name));
                }
                else
                {
                    strHTML.Append(string.Format("<a href='[link:{0},{1}]' target='_blank'>{2}</a>", currentModuleName, id, name));
                }
            }
            return strHTML.ToString();
        }
    }
}

