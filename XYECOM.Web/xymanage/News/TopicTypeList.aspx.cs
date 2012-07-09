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
using XYECOM.Model;
namespace XYECOM.Web.xymanage.News
{
    public partial class TopicTypeList : Web.BasePage.ManagePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               // button.attribute["onclick"] = "return a();"; 
               
                CheckRole("news");

                string mode = XYECOM.Core.XYRequest.GetString("mode");

                if (mode == "list")
                {
                    btnOKToTopic.Visible = true;
                    btnOk.Visible = false;
                }
                else
                {
                    btnOKToTopic.Visible = false;
                    btnOk.Visible = true;
                }
            }
           
        }

       

        protected void btnOKToTopic_ServerClick(object sender, EventArgs e)
        {
            //得到要处理新闻的所有id
            string newsIds = XYECOM.Core.XYRequest.GetString("ids");

            //得到复选框的value即所有被选专题的id
            string j = "";
            foreach (RepeaterItem item in this.rptList.Items)
            {
                HtmlInputCheckBox cb = (HtmlInputCheckBox)item.FindControl("cbsel");
                if (cb.Checked)
                {

                    j = "," + cb.Value.ToString() + j;

                }
            }
            if (j == "")
            {
                Response.Write("<script>alert('请选择有关专题！');</script>");
                return;
            }
            if (j.IndexOf(',') == 0)
            {
                j = j.Substring(1);
            }

            //把存放被选中新闻id的字符串转换为数组
            string[] arr1 = newsIds.Split(',');
            //存放一下一共要修改专题新闻的条数
            int newsidsCount = arr1.Length;

            //定义一个计数器记录一共更改成功的条数
            int count = 0;

            XYECOM.Business.News newsBLL = new XYECOM.Business.News();
            NewsInfo newsInfo = null;

            for (int i = 0; i < arr1.Length; i++)
            {
                //对逐条新闻的专题进行修改
                newsInfo = newsBLL.GetItem(long.Parse(arr1[i]));

                if (newsInfo == null) continue;

                newsInfo.TopicType = j;
                int num = newsBLL.Update(newsInfo);
                if (num > 0)
                {
                    count = count + 1;
                }

            }
            //如果要修改专题新闻的条数等于一共修改成功的条数说明批量处理成功
            if (newsidsCount == count)
            {
               
               
                Response.Write("<script>parent.CloseTopicType();parent.ClearSelect();parent.alertmsg('批量处理成功！');</script>");
                                
            }
            else
            {
                Response.Write("<script>parent.CloseTopicType();parent.alertmsg('批量处理失败！');</script>");
            }
        }
    }
}
