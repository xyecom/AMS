using System;
using System.Data;
using System.Configuration;
using System.Collections.Generic;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using XYECOM.Core;
using XYECOM.Business;

public partial class xymanage_basic_ProductTypeAdd : XYECOM.Web.BasePage.ManagePage
{
    private string backUrl = "";
    private bool error = false;
    private String ename = "";
    private String type = "";
    private String pt_id = "";

    XYECOM.Business.ProductType pt = new XYECOM.Business.ProductType();
    XYECOM.Model.ProductTypeInfo ept = new XYECOM.Model.ProductTypeInfo();


    #region 页面加载
    protected void Page_Load(object sender, EventArgs e)
    {
        CheckRole("typemanage");

        if (!IsPostBack)
        {
            pageinit();
        }

        backUrl = PT_ParentID > 0 ? "Typelist.aspx?PT_ParentID=" + PT_ParentID : "Typelist.aspx";
    }
    #endregion

    #region 初始化页面数据
    private void pageinit()
    {

        if (XYECOM.Core.XYRequest.GetQueryString("pt_id").Equals("0"))
        {
            lblType.Text = "供求信息";
            lblName.Text = "根类别";
            this.module.Visible = true;
            this.module2.Visible = true;
        }
        //模块名称
        

        //type:0添加 / type:1编辑
        type = XYECOM.Core.XYRequest.GetQueryString("type");

        ename = "offer";

        pt_id = XYECOM.Core.XYRequest.GetQueryString("pt_id");

        int parentId = XYECOM.Core.MyConvert.GetInt32(pt_id);

        #region 加载添加子类
        if (type.Equals("0"))
        {
            if ((ename.Equals("offer") || XYECOM.Configuration.Module.Instance.GetItem(ename).PEName.Equals("offer")) && pt_id != "0")
            {
                ept = pt.GetItem(parentId);

                lblName.Text = GetTypeAllName(ename, ept.PT_ID);

                lblType.Text = "供求信息";

                this.tradeid.Value = ept.TradeId.ToString();
            }
        }
        #endregion

        #region 加载编辑类别
        if (type.Equals("1"))
        {
            this.IsEdit.Value = "1";

            lbremark.Visible = false;

            tbName.TextMode = TextBoxMode.SingleLine;

            txtFlagName.TextMode = TextBoxMode.SingleLine;

            SetTradeVisable(ename);

            if ((ename.Equals("offer") || XYECOM.Configuration.Module.Instance.GetItem(ename).PEName.Equals("offer")) && pt_id != "0")
            {
                ept = pt.GetItem(Convert.ToInt64(pt_id));
                PT_ID = ept.PT_ID;

                this.tbName.Text = ept.PT_Name;

                this.PT_ParentID = ept.PT_ParentID;

                this.tradeid.Value = ept.TradeId.ToString();

                this.txtFlagName.Text = ept.FlagName.ToString();

                this.chkIsCustomTemplate.Checked = ept.IsCustomTemplate;
                
                this.trTrade1.Visible = true;

                if (PT_ParentID != 0)
                {
                    ept = pt.GetItem(PT_ParentID);
                    lblName.Text = GetTypeAllName(ename, ept.PT_ID);
                    lblType.Text = "供求信息";
                }
                else
                {
                    this.ParentModuleName.Value = "offer";
                    this.lblName.Text = "一级类别";
                    lblType.Text = "供求信息";
                }
            }
        }
        #endregion
    }
    #endregion

    #region  插入数据
    private void InsertData(string tbName, string flagName)
    {
        String ename = "";

        string type = XYECOM.Core.XYRequest.GetQueryString("type");

        if (type.Equals("0"))
        {
            ename = XYECOM.Core.XYRequest.GetQueryString("ename");
            PT_ParentID = XYECOM.Core.MyConvert.GetInt64(XYECOM.Core.XYRequest.GetQueryString("pt_id"));
        }

        int err = 0;

        if ("" != tbName)
        {
            if (ename.Equals("offer") || XYECOM.Configuration.Module.Instance.GetItem(ename).PEName.Equals("offer"))
            {
                ept.PT_Name = tbName;
                ept.PT_ParentID = PT_ParentID;
                ept.ModuleName = ename;
                ept.FlagName = flagName;
                ept.IsCustomTemplate = chkIsCustomTemplate.Checked;

                ept.TradeId = XYECOM.Core.MyConvert.GetInt32(this.tradeid.Value.ToString());
            }
        }
    }
    #endregion

    #region 保存
    protected void btnok_Click(object sender, EventArgs e)
    {
        PT_ID = XYECOM.Core.MyConvert.GetInt64(XYECOM.Core.XYRequest.GetQueryString("PT_ID"));
        ename = XYECOM.Core.XYRequest.GetQueryString("ename");

        if (this.tbName.Text == "")
        {
            Alert("分类名称不能为空！");
            return;
        }
        type = XYECOM.Core.XYRequest.GetQueryString("type");

        //判断是添加保存还是编辑保存
        if (type.Equals("0") || XYECOM.Core.XYRequest.GetQueryString("pt_id").Equals("0"))
        {

            string TypeName = tbName.Text.Trim().Replace("，", ",");

            string[] arr = TypeName.Split(',');
            string[] biaoshis = txtFlagName.Text.Trim().Split(',');
            for (int i = 0; i < arr.Length; i++)
            {
                InsertData(arr[i].Trim(),biaoshis[i].Trim());

                if (error) continue;
            }

            if (!error)
                Response.Redirect("Typelist.aspx?ename=" + ename + "&orderid=" + PT_ID + "&add=1");
        }

        if (type.Equals("1"))
        {

            int err = 0;

            if (ename.Equals("offer") || XYECOM.Configuration.Module.Instance.GetItem(ename).PEName.Equals("offer"))
            {
                ept = pt.GetItem(PT_ID);

                ept.PT_Name = this.tbName.Text.Trim();
                ept.TradeId = XYECOM.Core.MyConvert.GetInt32(this.tradeid.Value.ToString());
                ept.FlagName = "";

                ept.IsCustomTemplate = false;

                if (this.txtFlagName.Text.Trim() != "")
                    ept.FlagName = this.txtFlagName.Text.Trim();

                if (chkIsCustomTemplate.Checked == true)
                    ept.IsCustomTemplate = true;


                if (ept.TradeId == 0)
                {
                    Alert("请选择相关行业！一级分类必须绑定行业！");
                }
                else
                {
                    err = pt.Update(ept);
                }
            }

            if (err > 0)
            {
                Response.Redirect("Typelist.aspx?ename=" + ename + "&orderid=" + PT_ID);
            }
            else
            {
                Alert("修改失败！", backUrl + "?orderid=" + pt_id + "&ename=" + XYECOM.Core.XYRequest.GetQueryString("ename"));
            }
        }
    }

    #endregion

    #region 获取父级所有名称
    private String GetTypeAllName(String modulename, long id)
    {
        String str = "";
        List<XYECOM.Model.XYClassInfo> parentInfos = XYECOM.Business.XYClass.GetParentClassInfos(modulename, id);
        parentInfos.Reverse();
        foreach (XYECOM.Model.XYClassInfo info in parentInfos)
        {
            str += info.ClassName + " > ";
        }
        return str.Substring(0, (str.Length - 3));
    }
    #endregion

    #region 属性
    private long PT_ID
    {
        set { ViewState["PT_ID"] = value; }
        get
        {
            if (ViewState["PT_ID"] != null && ViewState["PT_ID"].ToString() != "")
                return Convert.ToInt32(ViewState["PT_ID"].ToString());
            else
                return 0;
        }
    }
    private long PT_ParentID
    {
        set { ViewState["PT_ParentID"] = value; }
        get
        {
            if (ViewState["PT_ParentID"] != null && ViewState["PT_ParentID"].ToString() != "")
                return Convert.ToInt64(ViewState["PT_ParentID"].ToString());
            else
                return 0;
        }
    }
    #endregion

    private void SetTradeVisable(string moduleName)
    {
        string curSelectValue = moduleName.Trim();

        XYECOM.Configuration.ModuleInfo mInfo = XYECOM.Configuration.Module.Instance.GetItem(curSelectValue);

        if (mInfo != null && (mInfo.EName.Equals("offer") || mInfo.PEName.Equals("offer")))
        {
            this.trTrade1.Style.Add("display", "");
            this.trTrade2.Style.Add("display", "");
        }
        else
        {
            this.trTrade1.Style.Add("display", "none");
            this.trTrade2.Style.Add("display", "none");
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("Typelist.aspx?ename="+XYECOM.Core.XYRequest.GetQueryString("ename")+"&orderid=" + XYECOM.Core.XYRequest.GetQueryInt64("PT_ID"));
    }
}
