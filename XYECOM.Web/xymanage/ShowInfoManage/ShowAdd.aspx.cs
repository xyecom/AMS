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
            this.Label1.Text = "修改展会信息";
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


        #region 添加展会信息
        /// <summary>
        /// 添加展会信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button1_Click(object sender, EventArgs e)
        {
            XYECOM.Business.Show showBLL = new XYECOM.Business.Show();
            XYECOM.Model.ShowInfo showinfo = new XYECOM.Model.ShowInfo();
    
            showinfo.Infotitle = this.txtname.Text; //展会名称
            showinfo.Typeid = XYECOM.Core.MyConvert.GetInt32(this.hidptid.Value); //展会类别

            if (this.lbcontent.Value == "")
                showinfo.Contents = "暂无信息";
            else
                showinfo.Contents = this.lbcontent.Value; //展会信息

            showinfo.BeginTime = this.bgdate.Value; //开幕时间
            showinfo.EndTime = this.egdate.Value;//闭幕时间
            showinfo.District = this.txtshowaddress.Text; //展会地点
            showinfo.Site = this.txtshowchang.Text; //展会场馆
            showinfo.Sponsor = this.txtdanwei.Text; //主办单位

            if (this.txtundertakepost.Text == "")
                showinfo.Undertake = "暂无信息";
            else
                showinfo.Undertake = this.txtundertakepost.Text; //承办单位

            if (this.txtxieban.Text == "")
                showinfo.Coorganizor = "暂无信息";
            else
                showinfo.Coorganizor = this.txtxieban.Text; //协办单位

            if (this.txtshowsuoppt.Text =="")
                showinfo.Sustain = "暂无信息";
            else
                showinfo.Sustain = this.txtshowsuoppt.Text; //支持单位

            showinfo.Sycle = this.showzhouqi.SelectedValue; //展会周期
            showinfo.Type = this.showtype.Text; // 展会类型

            if (this.txtshowhomepage.Text == "")
                showinfo.URL = "暂无信息";
            else
                showinfo.URL = this.txtshowhomepage.Text; //展会网址

            if (this.txtshowareaunit.Text == "")
                showinfo.Area = "暂无信息";
            else
                showinfo.Area = this.txtshowareaunit.Text; //净地面积单位

            if (this.txtshowprice.Text == "")
                showinfo.UnitPrice = 0;
            else
                showinfo.UnitPrice = XYECOM.Core.MyConvert.GetInt32(this.txtshowprice.Text); //净地单价
            
            if (this.txtshowunit.Text == "")
                showinfo.LeastRation = 0;
            else
                showinfo.LeastRation = XYECOM.Core.MyConvert.GetInt32(this.txtshowunit.Text); //净地起定量

            if (this.txtshowarea.Text == "")
                showinfo.AreaTotal = 0;
            else
                showinfo.AreaTotal = XYECOM.Core.MyConvert.GetInt32(this.txtshowarea.Text); //展位面积总量

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
                //上传图片
                UploadFile1.InfoID = id;
                UploadFile1.Update();
                Response.Redirect("ShowInfoList.aspx");
            }
            else {
                Alert("添加失败，请重新添加！");
            }
        }
        #endregion
    }
}
