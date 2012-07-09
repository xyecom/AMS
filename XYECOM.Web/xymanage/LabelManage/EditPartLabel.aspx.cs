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
    public partial class EditPartLabel : XYECOM.Web.BasePage.ManagePage
    {
        Model.PartLabelInfo labelInfo = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            CheckRole("label");

            int partId = XYECOM.Core.XYRequest.GetInt("partId", 0);

            if (partId <= 0)
            {
                Alert("无效参数！", "PartLableList.aspx");
            }

            labelInfo = new Business.PartLabel().GetItem(partId);

            if (labelInfo == null)
            {
                Alert("专栏不存在或已经被删除！", "PartLableList.aspx");
            }
        }

        protected override void BindData()
        {
            this.lblLabelName.Text =  "{" + labelInfo.LabelName + "}";
            this.lblCName.Text = labelInfo.PartName;
            this.lblFormat.Text = "格式" + labelInfo.Format;
            this.txtBeginTime.Value = labelInfo.BeginTime.ToString("yyyy-MM-dd");
            this.txtEndTime.Value = labelInfo.EndTime.ToString("yyyy-MM-dd");
            this.lblCompanyName.Text = "<a href='../userManage/userinfo.aspx?u_id="+labelInfo.UserId+"&backurl=../LabelManage/EditPartLabel.aspx?partId=" +labelInfo.PartId+"'>"+GetCompanyName(labelInfo.UserId)+"</a>";

        }

        protected void btnOK_Click(object sender, EventArgs e)
        {
            string beginTime = txtBeginTime.Value.Trim();
            string endTime = txtEndTime.Value.Trim();

            DateTime _beginTime = DateTime.Now;
            DateTime _endTime = DateTime.Now;

            try
            {
                _beginTime = Convert.ToDateTime(beginTime);
                _endTime = Convert.ToDateTime(endTime);
            }
            catch
            {
                Alert("请输入有效的时间！");
                return;
            }

            if (_beginTime.CompareTo(_endTime) >= 0)
            {
                Alert("结束时间必须晚于开始时间！");
                return;
            }

            labelInfo.BeginTime = _beginTime;
            labelInfo.EndTime = _endTime;

            new Business.PartLabel().Update(labelInfo);

            Alert("更新成功！","PartLabelList.aspx");
        }
    }
}
