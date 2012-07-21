using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace XYECOM.Web.Other.UserContorl
{
    public partial class ReceiveMessageInfo : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
            }
        }

        protected string GetUserName(string uid, string uname, string companyName, string messageId)
        {
            if (uid == "-1" || uid == "-2")
            {
                return @"<a href='receivemessageinfo.{config.Suffix}?m_id=" + messageId + @"'>
                </a><em>(系统信息)</em>
                <br />";
            }
            else
            {
                if (uid == "0")
                {
                    return uname + " <em>(游客)</em>";
                }
                else
                {
                    return uname + "　" + companyName;
                }
            }
        }

        private void BindData()
        {
            this.MultiView1.ActiveViewIndex = 0;

            XYECOM.Business.Message message = new XYECOM.Business.Message();

            int infoId = XYECOM.Core.XYRequest.GetQueryInt("m_id", 0);
            if (infoId < 1)
            {
                this.MultiView1.ActiveViewIndex = 1;
                return;
            }

            Model.MessageInfo info = message.GetItem(infoId);

            if (info == null)
            {
                this.MultiView1.ActiveViewIndex = 1;
                return;
            }

            this.sender.InnerHtml = GetUserName(info.U_ID.ToString(), info.M_UserName, info.M_CompanyName, info.M_ID.ToString());

            this.addtime.InnerHtml = info.M_AddTime.ToString("yyyy-MM-dd hh:mm:ss");
            this.subject.InnerHtml = info.M_Title;
            this.content.InnerHtml = info.M_Content;
        }
    }
}