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

namespace XYECOM.Web.xymanage.LabelManage
{
    public partial class AddPartLabel : XYECOM.Web.BasePage.ManagePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CheckRole("label");

            this.lstUsers.Attributes.Add("ondblclick", "javascript:SelectUser(this,'txtUserId');");
        }

        protected void btnOK_Click(object sender, EventArgs e)
        {
            string labelName = txtName.Text.Trim();
            string cnName = txtCName.Text.Trim();
            string beginTime = txtBeginTime.Value.Trim();
            string endTime = txtEndTime.Value.Trim();
            string format = ddlFormat.SelectedValue;
            string userId = txtUserId.Text.Trim();

            DateTime _beginTime = DateTime.Now;
            DateTime _endTime = DateTime.Now;

            try {
                _beginTime = Convert.ToDateTime(beginTime);
                _endTime = Convert.ToDateTime(endTime);
            }
            catch {
                Alert("请输入有效的时间！");
                return;
            }

            if (_beginTime.CompareTo(_endTime)>=0)
            {
                Alert("结束时间必须晚于开始时间！");
                return;
            }

            long _UserId = Core.MyConvert.GetInt64(userId);

            if (_UserId <= 0)
            {
                Alert("请输入有效的企业Id！");
                return;
            }

            Model.UserRegInfo regInfo = new Business.UserReg().GetItem(_UserId);

            if (regInfo == null)
            {
                Alert("指定Id的企业信息不存在！");
                return;
            }

            labelName = "XY_Part_" + labelName;

            Model.PartLabelInfo info = new Business.PartLabel().GetItem(labelName);

            if (info != null)
            {
                Alert("标签名称重复，请指定其他名称！");
                return; 
            }

            info = new XYECOM.Model.PartLabelInfo();
            info.LabelName = "XY_Part_" + labelName;
            info.PartName = cnName;
            info.BeginTime = _beginTime;
            info.EndTime = _endTime;
            info.Body = "";
            info.InfoIds = "";
            info.Format = format;
            info.UserId = _UserId;

            int i = new Business.PartLabel().Insert(info);

            if (i <= 0)
            {
                Alert("新增失败！");
                return;
            }
            Response.Redirect("PartLabelList.aspx");
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string key = txtUserName.Text.Trim();

            if (key.Equals("") || key.Equals("请输入用户名或公司名称"))
            {
                this.lblMessage.Text = "搜索关键字不能为空！";
                return;
            }

            this.lstUsers.Items.Clear();

            DataTable table = XYECOM.Business.Utils.ExecuteTable("XYV_UserInfo", "U_ID,UI_Name", "UI_Name <> ''  and (U_Name like'%" + key + "%' or UI_Name like '%" + key + "%')");

            if (table.Rows.Count <= 0)
            {
                this.lblMessage.Text = "没有符合条件的记录！";
                return;
            }

            foreach (DataRow row in table.Rows)
            {
                ListItem item = new ListItem(row["UI_Name"].ToString(), row["U_ID"].ToString());
                this.lstUsers.Items.Add(item);
            }
        }
    }
}
