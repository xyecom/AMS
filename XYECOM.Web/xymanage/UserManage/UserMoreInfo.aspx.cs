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

public partial class xymanage_UserManage_UserMoreInfo : XYECOM.Web.BasePage.ManagePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        CheckRole("user");

        if ("" != XYECOM.Core.XYRequest.GetQueryString("backURL"))
            backURL = XYECOM.Core.XYRequest.GetQueryString("backURL");
        else
            backURL = "UserListManger.aspx?";

        btcancel.Attributes["onclick"] = "location='" + backURL + "'";
        if (!Page.IsPostBack)
        {
            if (this.Request.QueryString["U_ID"] != null)
                BindData(Convert.ToInt64(this.Request.QueryString["U_ID"].ToString()));
            else
                Alert("请选择你要修改的具体用户",backURL);
        }
    }

    #region 绑定要查看用户资料
    private void BindData(Int64 uid)
    {
        string moneyformat = "n"; //货币转换格式
        
        XYECOM.Business.UserReg userRegBLL = new XYECOM.Business.UserReg();
        XYECOM.Model.UserRegInfo userRegInfo = new XYECOM.Model.UserRegInfo();
        userRegInfo = userRegBLL.GetItem(uid);
        if (!object.Equals(null, userRegInfo))
        {
            this.tdusername.Text = userRegInfo.LoginName; //用户名
            this.tdemail.Text = userRegInfo.Email;   //电子邮件
            this.bgdate.Value = userRegInfo.RegDate.ToShortDateString(); //注册时间
            txtQuestion.Text = userRegInfo.Question;
            txtAnswer.Text = userRegInfo.Answer;
        }
        else
        {
            Alert("该会员信息有误,请重新选择.", backURL);
        }

        XYECOM.Business.UserInfo userInfoBLL = new XYECOM.Business.UserInfo();
        XYECOM.Model.UserInfo userInfo = new XYECOM.Model.UserInfo();
        userInfo=userInfoBLL.GetItem(uid);
        if (!object.Equals(null, userInfo))
        {
            this.tdrealname.Text = userInfo.LinkMan; //真实姓名
            if (userInfo.Sex == true)                     //性别
                this.tdsex.Text = "1";
            else
                this.tdsex.Text = "0";

            tdIM.InnerHtml = XYECOM.Configuration.FreeCode.Instance.IM.Name + ":";
            txtIM.Text = userInfo.IM;
            this.tdmobil.Text = userInfo.Mobile; //手机
            this.tdsection.Text = userInfo.Section; //所在部门
            this.tdpost.Text = userInfo.Post;    //所任职位


            this.companyname.Text = userInfo.Name; //企业名称

            areatypeid.Value = userInfo.AreaId.ToString();
            txtTelephone.Text = userInfo.Telephone;
            txtFax.Text = userInfo.Fax;
            this.tdpostcode.Text = userInfo.Postcode; //邮政编码
            this.tdhomepage.Text = userInfo.HomePage.Trim(); //企业网址
            this.tdlinkadress.Text = userInfo.Address; //联系地址
            this.tdcharacter.Text = userInfo.Character; //企业性质

            companyid.Value = userInfo.UserTypeId.ToString();
            //this.tdsupply.Text = userInfo.U_SupplyProduct; //提供的产品.服务

            this.tdsupply.Text = userInfo.MainProduct;
            this.tdbuy.Text = userInfo.BuyPro; //需要的产品/服务

            if (userInfo.RegisteredCapital.ToString() != "")
                this.tdmoney.Text = Convert.ToDecimal(userInfo.RegisteredCapital).ToString(moneyformat);
            else
                this.tdmoney.Text = userInfo.Mode;     //注册资金

            this.tdmoneytype.Text = userInfo.MoneyType; //注册资金类别


            tdumode.DataSource = new XYECOM.Business.Mode().GetDataTable();
            tdumode.DataTextField = "M_Type";
            tdumode.DataValueField = "M_Type";
            tdumode.DataBind();

            string[] modes = userInfo.Mode.Split(',');

            foreach (string s in modes)
            {
                for (int i = 0; i < tdumode.Items.Count; i++)
                {
                    if (tdumode.Items[i].Value.Equals(s))
                    {
                        tdumode.Items[i].Selected = true;
                        break;
                    }
                }
            }


            this.lbyear.Text = userInfo.RegYear.ToString(); //注册时间
            this.lbarea.Text = userInfo.BusinessAddress; //主要经营地点
            this.lbaddress.Value = userInfo.RegAreaId.ToString(); //企业注册地
            //this.tdptype.Text = userInfo.U_PType; //主营产品/服务
            this.lbnumber.Text = userInfo.EmployeeTotal; //企业人数
            this.tdsynopsis.Text = userInfo.Synopsis; //企业简介

        }
        else
        {
            Alert("该会员信息有误,请重新选择.", backURL);
        }
    }
    #endregion

    protected void btnOk_Click(object sender, EventArgs e)
    {
        Int64 uid = XYECOM.Core.MyConvert.GetInt64(this.Request.QueryString["U_ID"].ToString());
        
        XYECOM.Business.UserReg userreg = new XYECOM.Business.UserReg();         
        XYECOM.Model.UserRegInfo euser = userreg.GetItem(uid);

        euser.Email = tdemail.Text.Trim();   //电子邮件
        euser.Answer = txtAnswer.Text.Trim();
        euser.Question = txtQuestion.Text.Trim();
        try
        {
            euser.RegDate = XYECOM.Core.MyConvert.GetDateTime(this.bgdate.Value); //注册时间
        }
        catch
        { }
        userreg.Update(euser);
        
        
        XYECOM.Business.UserInfo userinfo = new XYECOM.Business.UserInfo();
        XYECOM.Model.UserInfo info = userinfo.GetItem(uid);

        info.IM = txtIM.Text.Trim();

        info.LinkMan = tdrealname.Text.Trim(); //真实姓名
        info.Sex = tdsex.SelectedValue.Equals("1") ? true : false;//性别

        info.Mobile = tdmobil.Text.Trim(); //手机
        info.Section = tdsection.Text.Trim(); //所在部门
        info.Post = tdpost.Text.Trim();    //所任职位
      

        info.Name = companyname.Text.Trim(); //企业名称

        info.AreaId = XYECOM.Core.MyConvert.GetInt32(areatypeid.Value.ToString());
        info.Telephone = txtTelephone.Text.Trim();
        info.Fax = txtFax.Text.Trim();
        info.Postcode = tdpostcode.Text; //邮政编码
        info.HomePage = tdhomepage.Text.Trim(); //企业网址
        info.Address = tdlinkadress.Text.Trim(); //联系地址
        info.Character = tdcharacter.Text.Trim(); //企业性质

        info.UserTypeId = XYECOM.Core.MyConvert.GetInt64(companyid.Value.ToString());
        //info.U_SupplyProduct = tdsupply.Text.Trim(); //提供的产品.服务
        info.BuyPro = tdbuy.Text.Trim(); //需要的产品/服务
                
        info.RegisteredCapital = XYECOM.Core.MyConvert.GetDecimal(tdmoney.Text.Trim());//注册资金
        
        if (this.tdumode.SelectedValue != "")
        {
            info.Mode = "";
            for (int i = 0; i < tdumode.Items.Count; i++)
            {
                if (tdumode.Items[i].Selected)
                {
                    info.Mode += tdumode.Items[i].Text + ",";
                }
            }
            info.Mode = info.Mode.Substring(0, info.Mode.Length - 1);  //经营模式
        }

        info.RegYear = XYECOM.Core.MyConvert.GetInt32(lbyear.Text.Trim()); //注册时间
        info.BusinessAddress = lbarea.Text.Trim(); //主要经营地点
        info.RegAreaId = XYECOM.Core.MyConvert.GetInt32(lbaddress.Value.Trim()); //企业注册地
        //info.U_PType = tdptype.Text.Trim(); //主营产品/服务
        info.MainProduct = tdsupply.Text.Trim();
        info.EmployeeTotal = lbnumber.Text.Trim(); //企业人数
        info.Synopsis = tdsynopsis.Text.Trim(); //企业简介
        if (userinfo.Update(info) > 0)
            Alert("修改成功！", backURL);
        else
            Alert("发生错误，修改失败！");
    }
}
