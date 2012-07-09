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
using XYECOM.Business;

namespace XYECOM.Web.xymanage.MessageManage
{
    public partial class LookFeedback : XYECOM.Web.BasePage.ManagePage
    {
        public string title = "";
        private Int64 FeedbackID = 0;

        #region 页面加载

        protected void Page_Load(object sender, EventArgs e)
        {
            CheckRole("feedback");

            FeedbackID = XYECOM.Core.XYRequest.GetQueryInt64("FeedbackID");
            hiFeedBackId.Value = FeedbackID.ToString();

            if (!IsPostBack)
            {
                getlist();
            }
        }

        #endregion

        #region 读取数据
        public void getlist()
        {
            XYECOM.Model.FeedbackInfo info = new XYECOM.Business.Feedback().GetItem(FeedbackID);
            if (info != null)
            {
                if (info.Email.ToString() != "")
                {
                    this.Panelhuifu.Visible = true;
                    this.btnSendMail.Visible = true;
                    this.lb_huifuEmail.Visible = true;
                }
                else
                {
                    this.Panelhuifu.Visible = false;
                    this.btnSendMail.Visible = false;
                    this.lb_huifuEmail.Visible = false;
                }
                lb_Title.Text = info.Title.ToString();
                lb_Name.Text = info.Name.ToString();
                lb_Telephone.Text = info.Telephone.ToString();
                txt_Title.Text = "回复:" + info.Title.ToString();
                switch (info.Type)
                {
                    case 1: lb_Type.Text = "求助";
                        break;
                    case 2: lb_Type.Text = "建议";
                        break;
                    case 3: lb_Type.Text = "投诉";
                        break;
                    case 4: lb_Type.Text = "表扬";
                        break;
                    case 5: lb_Type.Text = "业务联系";
                        break;
                }
                lb_Email.Text = info.Email.ToString();

                lb_content.Text = info.Centent;

                hiUserId.Value = info.ComplaintId.ToString();
                hiDefendantId.Value = info.DefendantId.ToString();
            }
        }
        #endregion

        protected void btnSendMail_Click(object sender, EventArgs e)
        {
            XYECOM.Business.Feedback FeedBakcBLL = new Feedback();

            string title = this.txt_Title.Text.Trim();
            string content = this.txt_content.Text;
            int IsMessageOK = 0;
            bool IsMailOK = false;
            int userId = XYECOM.Core.MyConvert.GetInt32(hiUserId.Value);
            int defendantId = XYECOM.Core.MyConvert.GetInt32(hiDefendantId.Value);
            int feedbackId = XYECOM.Core.MyConvert.GetInt32(hiFeedBackId.Value);
            int isAdminAgree = 0;

            //管理员确认此投诉成立
            if (rbIsAgreeYes.Checked == true)
            {
                //扣除被投诉用户的信用值
                ReduceCreditScore(defendantId);
                isAdminAgree = (int)XYECOM.Model.IsAdminAgree.Agree;
            }
            else
            {
                isAdminAgree = (int)XYECOM.Model.IsAdminAgree.DisAgree;
            }

            //更新投诉信息
            int IsOK = FeedBakcBLL.UpateItemById(feedbackId, isAdminAgree);

            if (!(IsOK > 0))
            {
                Alert("更新投诉信息失败！", backURL);
            }

            if (cbMessage.Items[0].Selected == true && cbMessage.Items[1].Selected == false)
            {
                IsMessageOK = SenMessage(title, content, userId);
                if (IsMessageOK > 0)
                {
                    Alert("发送站内信成功！", backURL);
                }
                else
                {
                    Alert("发送站内信失败！", backURL);
                }
            }

            if (cbMessage.Items[0].Selected == false && cbMessage.Items[1].Selected == true)
            {
                IsMailOK = SendMail();

                if (IsMailOK)
                {
                    Alert("发送站外邮件成功！", backURL);
                }
                else
                {
                    Alert("发送站外邮件失败！", backURL);

                }
            }
            if (cbMessage.Items[0].Selected == true && cbMessage.Items[1].Selected == true)
            {
                IsMessageOK = SenMessage(title, content, userId);
                IsMailOK = SendMail();

                if (IsMessageOK > 0 && IsMailOK)
                {
                    Alert("发送站内信、站外邮件均成功！", backURL);
                }

                if (!(IsMessageOK > 0 || IsMailOK))
                {
                    Alert("发送站内信成功、站外邮件均失败！", backURL);
                }

                if (!(IsMessageOK > 0))
                {
                    Alert("发送站内信失败、站外邮件成功！", backURL);
                }

                if (!IsMailOK)
                {
                    Alert("发送站内信成功、站外邮件失败！", backURL);
                }
            }
        }

        protected void brnBack_Click(object sender, EventArgs e)
        {
            this.Response.Redirect("FeedbackList.aspx?" + XYECOM.Core.XYRequest.GetQueryString("backURL"));
        }

        //发送站内信
        protected int SenMessage(string Title, string Content, int UserId)
        {
            XYECOM.Model.MessageInfo em = new XYECOM.Model.MessageInfo();
            XYECOM.Business.Message m = new Message();
            em.M_Adress = "";
            em.M_CompanyName = "";
            em.M_Email = "";
            em.M_FHM = "";
            em.M_HasReply = false;
            em.M_Moblie = "";
            em.M_PHMa = "";
            em.M_RecverType = "administrator";
            em.M_Restore = false;
            em.M_SenderType = "user";
            if (Title != "")
            {
                em.M_Title = Title;
            }
            else
            {
                em.M_Title = "";
            }
            if (Content != "")
            {
                em.M_Content = Content;
            }
            else
            {
                em.M_Content = "";
            }
            em.M_UserName = "";
            em.M_UserType = false;
            em.U_ID = -1;
            em.UR_ID = UserId;

            return m.Insert(em);
        }

        //发送站外邮件
        protected bool SendMail()
        {
            bool i = false;

            if (this.lb_Email.Text.Trim() != "")
            {
                if (this.txt_Title.Text.Trim() != "")
                {
                    if (this.txt_content.Text != "")
                    {
                        i = XYECOM.Business.Utils.SendMail(this.lb_Email.Text.Trim(), this.txt_Title.Text.Trim(), this.txt_content.Text);
                    }
                }
            }

            return i;
        }

        public void ReduceCreditScore(int DefendantId)
        {
            //扣除被投诉方的信用值(待写)
        }
    }
}
