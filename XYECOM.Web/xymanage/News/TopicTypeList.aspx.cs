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
            //�õ�Ҫ�������ŵ�����id
            string newsIds = XYECOM.Core.XYRequest.GetString("ids");

            //�õ���ѡ���value�����б�ѡר���id
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
                Response.Write("<script>alert('��ѡ���й�ר�⣡');</script>");
                return;
            }
            if (j.IndexOf(',') == 0)
            {
                j = j.Substring(1);
            }

            //�Ѵ�ű�ѡ������id���ַ���ת��Ϊ����
            string[] arr1 = newsIds.Split(',');
            //���һ��һ��Ҫ�޸�ר�����ŵ�����
            int newsidsCount = arr1.Length;

            //����һ����������¼һ�����ĳɹ�������
            int count = 0;

            XYECOM.Business.News newsBLL = new XYECOM.Business.News();
            NewsInfo newsInfo = null;

            for (int i = 0; i < arr1.Length; i++)
            {
                //���������ŵ�ר������޸�
                newsInfo = newsBLL.GetItem(long.Parse(arr1[i]));

                if (newsInfo == null) continue;

                newsInfo.TopicType = j;
                int num = newsBLL.Update(newsInfo);
                if (num > 0)
                {
                    count = count + 1;
                }

            }
            //���Ҫ�޸�ר�����ŵ���������һ���޸ĳɹ�������˵����������ɹ�
            if (newsidsCount == count)
            {
               
               
                Response.Write("<script>parent.CloseTopicType();parent.ClearSelect();parent.alertmsg('��������ɹ���');</script>");
                                
            }
            else
            {
                Response.Write("<script>parent.CloseTopicType();parent.alertmsg('��������ʧ�ܣ�');</script>");
            }
        }
    }
}
