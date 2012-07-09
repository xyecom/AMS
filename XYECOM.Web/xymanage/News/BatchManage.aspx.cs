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
using System.Collections.Generic;

namespace XYECOM.Web.xymanage.News
{
    public partial class BatchManage : XYECOM.Web.BasePage.ManagePage
    {
        #region 页面初始化
        protected void Page_Load(object sender, EventArgs e)
        {
            CheckRole("news");
            if(!IsPostBack){
                ListBox_DataBound();
                
            }
        }
        #endregion

        #region 绑定列表框

        protected void ListBox_DataBound()
        {
            this.ListBox1.Items.Clear();
            this.ListBox2.Items.Clear();
            List<ListItem> items = _BindData(0, "|-");
            List<ListItem> item1 = _BindData(0, "|-");

            foreach (ListItem item in items)
            {
                this.ListBox1.Items.Add(item);
            }
            foreach (ListItem item in item1)
            {
                this.ListBox2.Items.Add(item);
            }
            this.ListBox2.SelectedIndex = 0;
            String id = XYECOM.Core.XYRequest.GetQueryString("PT_ParentID");
            
            for (int i = 0; i < this.ListBox1.Items.Count;i++ )
            {
                if (this.ListBox1.Items[i].Value.Equals(id))
                {
                    this.ListBox1.Items[i].Selected = true;
                }
                
            }
        }

        private List<ListItem> _BindData(long parentID, string splitStr)
        {
            List<ListItem> listItems = new List<ListItem>();
            List<XYECOM.Model.XYClassInfo> infos = XYECOM.Business.XYClass.GetSubItems("news", parentID);

            foreach (XYECOM.Model.XYClassInfo info in infos)
            {
                listItems.Add(new ListItem(splitStr + info.ClassName, info.ClassId.ToString()));

                if (XYECOM.Business.XYClass.IsHasSubClass("news", info.ClassId))
                    listItems.AddRange(_BindData(info.ClassId, "　" + splitStr));
            }

            return listItems;
        }

        #endregion

        #region 确定

        protected void btnok_Click(object sender, EventArgs e)
        {
            String content = "NT_ID='" + XYECOM.Core.Utils.AppendComma(this.ListBox2.SelectedValue) +"'";
            XYECOM.Business.News news = new XYECOM.Business.News();

            if (this.ListBox1.SelectedItem.Selected.Equals(true) || this.ListBox2.SelectedItem.Selected.Equals(true))
            {
                if (this.rbtone.Checked == true)
                {
                    String strwhere = "where NT_ID=" + "'" + XYECOM.Core.Utils.AppendComma(this.ListBox1.SelectedValue) + "'";
                    news.MoveNews(strwhere, content);
                    this.lblMessage.Text = "操作成功";
                }
                if (this.rbtmany.Checked == true)
                {
                    String strwhere = "where " + XYECOM.Business.Utils.GetNewsChannelQueryWhere(Core.MyConvert.GetInt32(this.ListBox1.SelectedValue));
                    news.MoveNews(strwhere, content);
                    this.lblMessage.Text = "操作成功";
                }
            }
        }

        #endregion
    }
}
