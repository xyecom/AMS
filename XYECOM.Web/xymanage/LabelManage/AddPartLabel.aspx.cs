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
                Alert("��������Ч��ʱ�䣡");
                return;
            }

            if (_beginTime.CompareTo(_endTime)>=0)
            {
                Alert("����ʱ��������ڿ�ʼʱ�䣡");
                return;
            }

            long _UserId = Core.MyConvert.GetInt64(userId);

            if (_UserId <= 0)
            {
                Alert("��������Ч����ҵId��");
                return;
            }

            Model.UserRegInfo regInfo = new Business.UserReg().GetItem(_UserId);

            if (regInfo == null)
            {
                Alert("ָ��Id����ҵ��Ϣ�����ڣ�");
                return;
            }

            labelName = "XY_Part_" + labelName;

            Model.PartLabelInfo info = new Business.PartLabel().GetItem(labelName);

            if (info != null)
            {
                Alert("��ǩ�����ظ�����ָ���������ƣ�");
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
                Alert("����ʧ�ܣ�");
                return;
            }
            Response.Redirect("PartLabelList.aspx");
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string key = txtUserName.Text.Trim();

            if (key.Equals("") || key.Equals("�������û�����˾����"))
            {
                this.lblMessage.Text = "�����ؼ��ֲ���Ϊ�գ�";
                return;
            }

            this.lstUsers.Items.Clear();

            DataTable table = XYECOM.Business.Utils.ExecuteTable("XYV_UserInfo", "U_ID,UI_Name", "UI_Name <> ''  and (U_Name like'%" + key + "%' or UI_Name like '%" + key + "%')");

            if (table.Rows.Count <= 0)
            {
                this.lblMessage.Text = "û�з��������ļ�¼��";
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
