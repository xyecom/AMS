using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace XYECOM.Web.Other.UserContorl
{
    public partial class SetQuestion : System.Web.UI.UserControl
    {
        Business.UserReg regBll = new Business.UserReg();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!XYECOM.Business.CheckUser.CheckUserLogin())
            {
                Response.Redirect("/Login.aspx");
                return;
            }

            if (!IsPostBack)
            {
                Model.GeneralUserInfo guInfo = XYECOM.Business.CheckUser.UserInfo;
                Model.UserRegInfo regInfo = regBll.GetItem(guInfo.userid);

                if (regInfo != null)
                {
                    this.txtQuestion.Text = regInfo.Question;
                    this.txtAnswer.Text = regInfo.Answer;
                    this.hidUserId.Value = regInfo.UserId.ToString();
                }

            }
        }


        protected void btnOk_Click(object sender, EventArgs e)
        {
            long userId = XYECOM.Core.MyConvert.GetInt64(this.hidUserId.Value);
            string question = this.txtQuestion.Text.Trim();
            string answer = this.txtAnswer.Text.Trim();
            int result = regBll.SetQuestAndAnswer(userId, question, answer);
            if (result > 0) 
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "alert('保存成功!');history.back();", true);
                return;
            }
            else 
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "alert('保存失败！');", true);
                return;
            }
        }
    }
}