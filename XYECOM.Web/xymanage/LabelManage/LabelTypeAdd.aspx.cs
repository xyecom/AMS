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

public partial class xymanage_LabelManage_LabelTypeAdd : XYECOM.Web.BasePage.ManagePage
{
    #region  页面加载
    protected void Page_Load(object sender, EventArgs e)
    {
        CheckRole("label");
    }
    #endregion

    #region 初始化页面数据
    protected override void BindData()
    {
        this.btnok.Attributes.Add("onclick", "javascript:return AddLabel();");

        XYECOM.Business.LabelType lt = new XYECOM.Business.LabelType();
        XYECOM.Model.LabelTypeInfo elt = new XYECOM.Model.LabelTypeInfo();
        string ltId = Request.QueryString["LT_ID"];

        this.title.InnerHtml = "标签分类添加";

        if (!string.IsNullOrEmpty(ltId))
        {
            int infoId = XYECOM.Core.MyConvert.GetInt32(ltId);
            elt = lt.GetItem(infoId);

            if (elt != null)
            {
                LT_ID = elt.LT_ID;
                this.tbName.Text = elt.LT_Name;
                this.tbRemark.Text = elt.LT_Remark;                
                this.title.InnerHtml = "标签分类编辑";
            }
        }
    }
    #endregion

    #region 保存
    protected void btnok_Click(object sender, EventArgs e)
    {
        string str = "";
        XYECOM.Business.Log l = new XYECOM.Business.Log();
        XYECOM.Model.LogInfo el = new XYECOM.Model.LogInfo();        

        XYECOM.Model.LabelTypeInfo elt = new XYECOM.Model.LabelTypeInfo();
        XYECOM.Business.LabelType lt = new XYECOM.Business.LabelType();
        elt.LT_Name = this.tbName.Text;
        
        elt.LT_Remark = this.tbRemark.Text;

        int err = 0;
        if (LT_ID == 0)
        {
            err = lt.Insert(elt);
            if (err > 0)
            {
                el.L_Title = "标签管理";
                el.L_Content = "标签类别添加成功";
                el.L_MF = "模板标签";
                el.UM_ID = AdminId;
                l.Insert(el);
                Alert("标签类别添加成功！", "LabelTypeList.aspx" + str);
            }
            else if (err == -1)
            {
                el.L_Title = "标签管理";
                el.L_Content = "该标签已存在";
                el.L_MF = "模板标签";
                el.UM_ID = AdminId;
                l.Insert(el);
                Alert("该标签已存在！");
            }
            else
            {
                el.L_Title = "标签管理";
                el.L_Content = "标签类别添加失败！请稍后再试！";
                el.L_MF = "模板标签";
                
                {
                    el.UM_ID = AdminId;
                }
                l.Insert(el);
                Alert("标签类别添加失败！请稍后再试！", "LabelTypeList.aspx" + str);
            }
        }
        else
        {
            elt.LT_ID = LT_ID;
            err = lt.Update(elt);
            if (err > 0)
            {
                el.L_Title = "标签管理";
                el.L_Content = "标签类别修改成功";
                el.L_MF = "模板标签";
                
                {
                    el.UM_ID = AdminId;
                }
                l.Insert(el);
                Alert("标签类别修改成功！", "LabelTypeList.aspx" + str);
            }
            else
            {
                el.L_Title = "标签管理";
                el.L_Content = "标签类别修改！请稍后再试！";
                el.L_MF = "模板标签";
                
                {
                    el.UM_ID = AdminId;
                }
                l.Insert(el);
                Alert("标签类别修改！请稍后再试！", "LabelTypeList.aspx" + str);
            }
        }

    }
    #endregion

    #region 属性
    private int LT_ID
    {
        set { ViewState["LT_ID"] = value; }
        get
        {
            string ltid = string.Empty; ;

            if (ViewState["LT_ID"] == null || string.IsNullOrEmpty(ltid = ViewState["LT_ID"].ToString())) return 0;

            return XYECOM.Core.MyConvert.GetInt32(ltid);
        }
    }
    #endregion
}
