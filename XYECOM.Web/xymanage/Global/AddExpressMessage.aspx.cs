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

namespace XYECOM.Web.xymanage.Global
{
    public partial class AddExpressMessage : XYECOM.Web.BasePage.ManagePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CheckRole("ExpressMessage");
            if (!IsPostBack)
            {
                this.hidMsgId.Value = "";

                this.caption.InnerHtml = "���ϵͳ��������";

                this.btnAdd.Attributes.Add("onclick", "javascript:return input();");

                BindModuleList();

                if (Request.QueryString["sm_id"] != null)
                {
                    BindData(Request.QueryString["sm_id"].ToString());
                }
            }
        }

        private void BindModuleList()
        {
            List<ListItem> list = GetAllModules(false);

            list.Add(new ListItem("��ҵƷ��", "brand"));
            list.Add(new ListItem("��ҵ����", "company"));

            list.Insert(0, new ListItem("ͨ������", "general"));

            chklstModules.Items.Clear();
            foreach (ListItem item in list)
            {
                this.chklstModules.Items.Add(item);
            }
        }

        #region ��Ҫ�޸ĵ�ϵͳ��������
        /// <summary>
        /// ��Ҫ�޸ĵ�ϵͳ��������
        /// </summary>
        /// <param name="smid"></param>
        private void BindData(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                ExpressMessageInfo info = new ExpressMessage().GetItem(int.Parse(id)); ;

                this.caption.InnerHtml = "�޸�:";

                if (info.Body.Length > 10)
                    this.caption.InnerHtml += XYECOM.Core.Utils.IsLength(10, info.Body);
                else
                    this.caption.InnerHtml += info.Body;

                this.hidMsgId.Value = info.Id.ToString();
                this.chklstModules.Visible = false;
                this.hidModuleName.Value = info.ModuleName.ToString();
                this.lbtype.Text = GetExpMsgModuleName(info.ModuleName);
                this.txtBody.Text = info.Body;
            }
        }
        #endregion

        #region �����������а�
        /// <summary>
        /// ת���������
        /// </summary>
        /// <param name="smtype">�������ı��</param>
        /// <returns>�ñ�Ŷ�Ӧ������</returns>
        private string GetExpMsgModuleName(string moduleName)
        {
            if (!string.IsNullOrEmpty(moduleName))
            {
                if (moduleName.Equals("general")) return "ͨ������";

                return GetModuleCNName(moduleName);
            }

            return "";
        }
        #endregion

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            ExpressMessageInfo expMsgInfo = new ExpressMessageInfo();
            ExpressMessage expMsgBLL = new ExpressMessage();

            expMsgInfo.Body = this.txtBody.Text.Trim();
            
            string names = "";
            string errnames = "";

            if (this.hidMsgId.Value == "")
            {
                for (int i = 0; i < this.chklstModules.Items.Count; i++)
                {
                    if (this.chklstModules.Items[i].Selected == true)
                    {
                        expMsgInfo.ModuleName = this.chklstModules.Items[i].Value;

                        int row = expMsgBLL.Insert(expMsgInfo);
                        if (row == -1)
                        {
                            names += this.chklstModules.Items[i].Text;
                        }
                        else if (row == -2)
                        {
                            errnames += this.chklstModules.Items[i].Text;
                        }
                    }
                }
                if (names != "")
                    Alert(names + "��������ͬ����.","ExpressMessageList.aspx");
                else if (errnames != "")
                {
                    Alert(errnames + "��������������ʧ��,�ɴ������.","ExpressMessageList.aspx");
                }
                else
                {
                    Response.Redirect("ExpressMessageList.aspx");
                }
            }
            else
            {
                expMsgInfo.Id = int.Parse(this.hidMsgId.Value);
                expMsgInfo.ModuleName = this.hidModuleName.Value;

                int rowAff = expMsgBLL.Update(expMsgInfo);
                if (rowAff >= 0)
                {
                    Response.Redirect("ExpressMessageList.aspx");
                }
                else
                {
                    Alert("�޸�ϵͳ����ʧ��,�ɴ��²���.", "ExpressMessageList.aspx");
                }
            }
        }

        protected void btnCancel_ServerClick(object sender, EventArgs e)
        {
            this.ClientScript.RegisterClientScriptBlock(GetType(), "01", "<script>window.location.href(\"ExpressMessageList.aspx\");</script>");
        }
    }
}
