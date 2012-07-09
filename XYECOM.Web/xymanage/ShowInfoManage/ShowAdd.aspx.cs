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
using XYECOM.Page.Upload;
namespace XYECOM.Web.xymanage.ShowInfoManage
{
    public partial class ShowAdd : XYECOM.Web.BasePage.ManagePage
    {
        String whichone = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            CheckRole("exhibition");

            backURL = XYECOM.Core.XYRequest.GetQueryString("backurl");

            whichone = XYECOM.Core.XYRequest.GetQueryString("iswhich");
            if(!IsPostBack){
                if (whichone.Equals("1"))
                {
                    Edit(XYECOM.Core.XYRequest.GetQueryInt64("infoid"));
                }
            } 
        }


        private void Edit(long infoid) {
            this.Label1.Text = "�޸�չ����Ϣ";
            XYECOM.Business.Show infoBLL = new XYECOM.Business.Show();
            XYECOM.Model.ShowInfo info = new XYECOM.Model.ShowInfo();
            info = infoBLL.GetItem(infoid);

            this.txtname.Text = info.Infotitle;
            this.hidptid.Value = info.Typeid.ToString();
            this.lbcontent.Value = info.Contents;        
            this.UploadFile1.InfoID = infoid;
            this.bgdate.Value = info.BeginTime;
            this.egdate.Value = info.EndTime;
            this.txtshowaddress.Text = info.District;
            this.txtshowchang.Text = info.Site;
            this.txtdanwei.Text = info.Sponsor;
            this.txtundertakepost.Text = info.Undertake;
            this.txtxieban.Text = info.Coorganizor;
            this.txtshowsuoppt.Text = info.Sustain;
            this.showzhouqi.SelectedValue = info.Sycle;
            this.showtype.SelectedValue = info.Type;
            this.txtshowhomepage.Text = info.URL;
            this.txtshowareaunit.Text = info.Area;
            this.txtshowprice.Text = info.UnitPrice.ToString();
            this.txtshowunit.Text = info.LeastRation.ToString();
            this.txtshowarea.Text = info.AreaTotal.ToString();

        }


        #region ���չ����Ϣ
        /// <summary>
        /// ���չ����Ϣ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button1_Click(object sender, EventArgs e)
        {
            XYECOM.Business.Show showBLL = new XYECOM.Business.Show();
            XYECOM.Model.ShowInfo showinfo = new XYECOM.Model.ShowInfo();
    
            showinfo.Infotitle = this.txtname.Text; //չ������
            showinfo.Typeid = XYECOM.Core.MyConvert.GetInt32(this.hidptid.Value); //չ�����

            if (this.lbcontent.Value == "")
                showinfo.Contents = "������Ϣ";
            else
                showinfo.Contents = this.lbcontent.Value; //չ����Ϣ

            showinfo.BeginTime = this.bgdate.Value; //��Ļʱ��
            showinfo.EndTime = this.egdate.Value;//��Ļʱ��
            showinfo.District = this.txtshowaddress.Text; //չ��ص�
            showinfo.Site = this.txtshowchang.Text; //չ�᳡��
            showinfo.Sponsor = this.txtdanwei.Text; //���쵥λ

            if (this.txtundertakepost.Text == "")
                showinfo.Undertake = "������Ϣ";
            else
                showinfo.Undertake = this.txtundertakepost.Text; //�а쵥λ

            if (this.txtxieban.Text == "")
                showinfo.Coorganizor = "������Ϣ";
            else
                showinfo.Coorganizor = this.txtxieban.Text; //Э�쵥λ

            if (this.txtshowsuoppt.Text =="")
                showinfo.Sustain = "������Ϣ";
            else
                showinfo.Sustain = this.txtshowsuoppt.Text; //֧�ֵ�λ

            showinfo.Sycle = this.showzhouqi.SelectedValue; //չ������
            showinfo.Type = this.showtype.Text; // չ������

            if (this.txtshowhomepage.Text == "")
                showinfo.URL = "������Ϣ";
            else
                showinfo.URL = this.txtshowhomepage.Text; //չ����ַ

            if (this.txtshowareaunit.Text == "")
                showinfo.Area = "������Ϣ";
            else
                showinfo.Area = this.txtshowareaunit.Text; //���������λ

            if (this.txtshowprice.Text == "")
                showinfo.UnitPrice = 0;
            else
                showinfo.UnitPrice = XYECOM.Core.MyConvert.GetInt32(this.txtshowprice.Text); //���ص���
            
            if (this.txtshowunit.Text == "")
                showinfo.LeastRation = 0;
            else
                showinfo.LeastRation = XYECOM.Core.MyConvert.GetInt32(this.txtshowunit.Text); //��������

            if (this.txtshowarea.Text == "")
                showinfo.AreaTotal = 0;
            else
                showinfo.AreaTotal = XYECOM.Core.MyConvert.GetInt32(this.txtshowarea.Text); //չλ�������

            long id = 0;
            int result = 0;

            if (XYECOM.Core.XYRequest.GetQueryString("iswhich").Equals("1"))
            {
                XYECOM.Model.ShowInfo newinfo = new XYECOM.Model.ShowInfo();
                newinfo = showBLL.GetItem(XYECOM.Core.XYRequest.GetQueryInt64("infoid"));
                showinfo.IsCommend = newinfo.IsCommend;
                showinfo.HtmlPage = newinfo.HtmlPage;
                showinfo.Id = XYECOM.Core.MyConvert.GetInt32(XYECOM.Core.XYRequest.GetQueryString("infoid"));

                id = showinfo.Id;

                result = showBLL.Update(showinfo);
            }
            else {
                result = showBLL.Insert(showinfo, out id);
            }
            
            if (result >= 0)
            {
                //�ϴ�ͼƬ
                UploadFile1.InfoID = id;
                UploadFile1.Update();
                Response.Redirect("ShowInfoList.aspx");
            }
            else {
                Alert("���ʧ�ܣ���������ӣ�");
            }
        }
        #endregion
    }
}
