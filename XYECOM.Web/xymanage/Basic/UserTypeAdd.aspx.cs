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
using System.Data.SqlClient;
using XYECOM.Business;
using XYECOM.Core;

public partial class xymanage_basic_UserTypeAdd : XYECOM.Web.BasePage.ManagePage
{
    #region  页面加载
    protected void Page_Load(object sender, EventArgs e)
    {
        CheckRole("userType");

        if (!IsPostBack)
        {
            this.btnok.Attributes.Add("onclick", "javascript:return AddLabel();");
            InitPage();
        }
    }
    #endregion

    #region 初始化页面数据
    private void InitPage()
    {

        if (this.Request.QueryString["UT_PID"] != null && this.Request.QueryString["UT_PID"].ToString() != "")
        {
            if (Request.QueryString["UT_PID"].ToString() != "0")
            {
                XYECOM.Business.UserType ut = new XYECOM.Business.UserType();

                long typeId = XYECOM.Core.XYRequest.GetQueryInt64("UT_PID");

                DataTable dt = ut.GetDataTable(typeId);

                if (dt.Rows.Count > 0)
                {
                    lblName.Text = dt.Rows[0]["UT_Type"].ToString();
                }
            }
            else
                lblName.Text = "一级企业类型";
            UT_PID = Convert.ToInt64(Request.QueryString["UT_PID"].ToString());
        }
        if (this.Request.QueryString["UT_ID"] != null && this.Request.QueryString["UT_ID"].ToString() != "")
        {
            XYECOM.Business.UserType ut = new XYECOM.Business.UserType();
            XYECOM.Model.UserTypeInfo eu = new XYECOM.Model.UserTypeInfo();

            eu = ut.GetItem(Convert.ToInt64(this.Request.QueryString["UT_ID"].ToString()));
            
            UT_ID = eu.UT_ID;
            this.tbName.Text = eu.UT_Type;
             UT_PID = eu.UT_PID;
            if (UT_PID != 0)
            {
                eu = ut.GetItem(UT_PID);
                this.lblName.Text = eu.UT_Type;
            }
            else
            {
                this.lblName.Text = "一级企业类型";
            }
            this.lbremark.Visible = false;
            this.lblName.Text = "企业类型编辑";
        }
       
    }
    #endregion

    #region 保存
    protected void btnok_Click(object sender, EventArgs e)
    {
        XYECOM.Business.UserType ut = new XYECOM.Business.UserType();
        XYECOM.Model.UserTypeInfo eu1 = new XYECOM.Model.UserTypeInfo();
        eu1.UT_PID = UT_PID;
        int err = 0;
        string url = "UserTypelist.aspx";
        if (UT_ID == 0)
        {
            string TypeName = tbName.Text.Trim().Replace("，", ",");

            if (TypeName.Trim().Equals(""))
            {
                Alert("请输入分类名称！");
                return;
            }

            string[] arr = TypeName.Split(',');
            int num = 0;

            string errMessage = "";

            for (int i = 0; i < arr.Length; i++)
            {
                XYECOM.Model.UserTypeInfo eu = new XYECOM.Model.UserTypeInfo();  
                eu.UT_Type = arr[i].Trim();
                eu.UT_PID = UT_PID;
                err = ut.Insert(eu);
                if(err==1)
                {
                    num += 1;
                }
                else if (err == -1)
                {
                    errMessage += "[" + arr[i].Trim() + "]已存在！<br/>";
                    continue;
                }
                else
                {
                    errMessage += "[" + arr[i].Trim() + "]添加失败！<br/>";
                    continue;
                }
            }

            if (!errMessage.Equals("") && num >0)
            {
                Alert(errMessage,url);
                return;
            }

            if (!errMessage.Equals(""))
            {
                Alert(errMessage);
            }

            if (num > 0) Response.Redirect(url);
        }
        else
        {
            string TypeName1 = tbName.Text.Trim().Replace("，", ",");
            string[] arr = TypeName1.Split(',');
            if (arr.Length > 1)
            {
                Alert("填写不正确！", url);
            }
            else {
                eu1.UT_Type = this.tbName.Text;
                eu1.UT_ID = UT_ID;
                err = ut.Update(eu1);
                if (err > 0)
                {
                    Response.Redirect(url);
                }
                else
                {
                    Alert("修改失败！", url);
                }
            } 
        }
    }
    #endregion

    #region 属性
    private long  UT_ID
    {
        set { ViewState["UT_ID"] = value; }
        get
        {
            if (ViewState["UT_ID"] != null && ViewState["UT_ID"].ToString() != "")
                return Convert.ToInt64(ViewState["UT_ID"].ToString());
            else
                return 0;
        }
    }
    private long  UT_PID
    {
        set { ViewState["UT_PID"] = value; }
        get
        {
            if (ViewState["UT_PID"] != null && ViewState["UT_PID"].ToString() != "")
                return Convert.ToInt64(ViewState["UT_PID"].ToString());
            else
                return 0;
        }
    }
    #endregion
}

