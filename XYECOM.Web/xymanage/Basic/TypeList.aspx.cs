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
using XYECOM.Core;
using XYECOM.Model;
using System.Collections.Generic;
using System.Text;
public partial class xymanage_basic_Typelist : XYECOM.Web.BasePage.ManagePage
{

    private string ename = "";
    private const string Img1 = "<img src=\"../images/bg_shrink.gif\" />";
    private const string Img2 = "<img src=\"../images/bg_spread.gif\" />";
    private const String img3 = "<img src=\"../images/arrow_black.gif\" />";
    private const String imgParent = "<img src=\"../images/folders.gif\" />";
    private const String imgchird = "<img src=\"../images/folder.gif\" />";
    //删除判断
    private String isfirstid = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        CheckRole("typemanage");

        ename = Request.QueryString["ename"];
        if (string.IsNullOrEmpty(ename))
        {
            ename = "offer";
        }

        if (XYECOM.Core.XYRequest.GetQueryString("del_ID") != "" && !isfirstid.Equals(XYECOM.Core.XYRequest.GetQueryString("del_ID")))
        {
            Del(XYECOM.Core.XYRequest.GetQueryString("del_ID"));
        }

        if (XYECOM.Core.XYRequest.GetQueryString("upID") != "" && !isfirstid.Equals(XYECOM.Core.XYRequest.GetQueryString("upID")))
        {
            MoveOrder(XYECOM.Core.XYRequest.GetQueryString("upID"), 1);
        }

        if (XYECOM.Core.XYRequest.GetQueryString("downID") != "" && !isfirstid.Equals(XYECOM.Core.XYRequest.GetQueryString("downID")))
        {
            MoveOrder(XYECOM.Core.XYRequest.GetQueryString("downID"), 0);
        }

        if (this.strdel.Value != "")
        {
            Del(this.strdel.Value);
        }
        if (!IsPostBack)
        {
            DataBindddlTypeAdd();
            InitTabs();
            BindClassList(ename);
            string oid = XYECOM.Core.XYRequest.GetQueryString("orderid");
            if (oid != "")
            {
                string curTypeFullId = XYECOM.Business.XYClass.GetFullid(ename, oid);
                ClientScript.RegisterStartupScript(this.GetType(), "expr", "expran('" + ename + "','" + curTypeFullId + "')", true);
            }
        }

    }

    #region 绑定ddlTypeAdd

    public void DataBindddlTypeAdd()
    {
        System.Collections.Specialized.ListDictionary list = GetAllInfoModules();
        list.Add("exhibition", "展会分类");
        //list.Add("brand", "品牌分类");
        list.Add("job", "招聘岗位");

        IDictionaryEnumerator cacheEnum = list.GetEnumerator();


        ddlTypeAdd.Items.Clear();
        ListItem item = new ListItem("新增分类", "");
        ddlTypeAdd.Items.Add(item);
        while (cacheEnum.MoveNext())
        {
            ListItem items = new ListItem(cacheEnum.Value.ToString(), cacheEnum.Key.ToString());
            ddlTypeAdd.Items.Add(items);
        }
    }

    #endregion

    #region 初始化选项卡
    /// <summary>
    /// 初始化选项卡
    /// </summary>
    private void InitTabs()
    {
        string tabHTML = GetModuleListHTMLByYTabs(ename, "");

        this.leftYMenu.InnerHtml = tabHTML;
    }

    /// <summary>
    /// 重写父类方法
    /// </summary>
    /// <param name="currentModuleName"></param>
    /// <param name="parentModuleName"></param>
    /// <returns></returns>
    protected override string GetModuleListHTMLByYTabs(string currentModuleName, string parentModuleName)
    {
        StringBuilder tabHTML = new StringBuilder();

        System.Collections.Specialized.ListDictionary list = GetAllInfoModules();

        //Hashtable table = GetAllInfoModules();

        list.Add("exhibition", "展会分类");       
        list.Add("job", "招聘岗位");

        IDictionaryEnumerator cacheEnum = list.GetEnumerator();

        while (cacheEnum.MoveNext())
        {
            if (cacheEnum.Key.Equals(currentModuleName))
                tabHTML.Append("<li  class=\"Yhover\">" + cacheEnum.Value + "</li>");
            else
                tabHTML.Append("<li id=\"menuItem_" + cacheEnum.Key + "\"><a href='?ename=" + cacheEnum.Key + "' >" + cacheEnum.Value + "</a></li>");
        }

        return tabHTML.ToString();
    }
    #endregion

    #region Web 窗体设计器生成的代码
    override protected void OnInit(EventArgs e)
    {
        this.Load += new System.EventHandler(this.Page_Load);
        //this.Page1.PageChanged += new xymanage_UserControl_page.EventHandler(Page1_PageChanged);
        base.OnInit(e);
    }
    #endregion

    #region 换位置
    private void MoveOrder(String id, int type)
    {
        int i = 0;

        i = XYECOM.Business.XYClass.UpdateOrder(ename, id, type);

        if (i > 0)
        {
            Alert("修改成功");
            Response.Redirect("Typelist.aspx?ename=" + ename + "&orderid=" + id);
        }
        else
        {
            Alert("修改失败");
        }
    }
    #endregion

    #region 删除
    /// <summary>
    /// 删除
    /// </summary>
    /// <param name="id"></param>

    private void Del(String id)
    {
        int i = 0;
        int j = 0;
        XYECOM.Business.XYClass xy = new XYECOM.Business.XYClass();

        if (id.Contains(","))
        {
            id = id.Substring(0, (id.Length - 1));
        }
        if (isfirstid.Equals("") || !isfirstid.Equals(id))
        {

            if (ename.Equals("job") || ename.Equals("exhibition"))
            {
                if (ename.Equals("job"))
                {
                    XYECOM.Business.Post post = new Post();
                    j = xy.InfoNum("i_engageinfo", "P_ID", id);
                    if (j <= 0)
                    {
                        i = post.Delete(id);
                    }
                }
                if (ename.Equals("exhibition"))
                {
                    XYECOM.Business.ShowType showtype = new XYECOM.Business.ShowType(); ;
                    j = xy.InfoNum("XY_showinfo", "typeid", id);
                    if (j <= 0)
                    {
                        i = showtype.Delete(id);
                    }
                }
            }
            else
            {
                if (ename.Equals("offer") || XYECOM.Configuration.Module.Instance.GetItem(ename).PEName.Equals("offer"))
                {
                    XYECOM.Business.ProductType pt = new XYECOM.Business.ProductType();
                    j = xy.InfoNum("i_supply", "PT_ID", id);
                    if (j <= 0)
                    {
                        i = pt.Delete(id);
                    }
                }
                if (ename.Equals("investment") || XYECOM.Configuration.Module.Instance.GetItem(ename).PEName.Equals("investment"))
                {
                    XYECOM.Business.InviteBusinessType it = new XYECOM.Business.InviteBusinessType();
                    j = xy.InfoNum("i_invitebusinessmaninfo", "IT_ID", id);
                    if (j <= 0)
                    {
                        i = it.Delete(id);
                    }
                }
                if (ename.Equals("service") || XYECOM.Configuration.Module.Instance.GetItem(ename).PEName.Equals("service"))
                {
                    XYECOM.Business.ServiceType st = new XYECOM.Business.ServiceType(); ;
                    j = xy.InfoNum("i_serviceinfo", "ST_ID", id);
                    if (j <= 0)
                    {
                        i = st.Delete(id);
                    }
                }
            }
        }
        if (j > 0)
        {
            backURL = "Typelist.aspx?ename=" + ename + "&del='1'&orderid=" + XYECOM.Core.XYRequest.GetQueryString("ParentID");
            Alert("该分类下含有信息！", backURL);
        }
        if (i > 0)
        {
            isfirstid = id;
            Response.Redirect("Typelist.aspx?ename=" + ename + "&del='1'&orderid=" + XYECOM.Core.XYRequest.GetQueryString("ParentID"));
        }
    }
    #endregion

    #region 类型树相关

    #region 绑定
    private void BindClassList(string moduleName)
    {
        //List<XYECOM.Model.XYClassInfo> infos = XYECOM.Business.XYClass.GetItemsAll(moduleName);
        List<XYECOM.Model.XYClassInfo> infos = XYECOM.Business.XYClass.GetSubItems(moduleName, 0); //modify by botao
        this.pnlSuperClass.Controls.Clear();
        this.pnlSuperClass.Controls.Add(new LiteralControl("<ul>"));


        string curTypeFullId = "";

        if (XYECOM.Core.XYRequest.GetQueryString("orderid") != "")
        {
            curTypeFullId = XYECOM.Business.XYClass.GetFullid(XYECOM.Core.XYRequest.GetQueryString("ename"), XYECOM.Core.XYRequest.GetQueryString("orderid"));
        }

        foreach (XYECOM.Model.XYClassInfo info in infos)
        {
            AddInfoHtml(info, "0", "", moduleName, curTypeFullId);
            if (info.HasSub)
            {
                AddChild(info, "&nbsp;&nbsp;&nbsp;&nbsp;", moduleName, curTypeFullId);
            }
        }
        this.pnlSuperClass.Controls.Add(new LiteralControl("</ul>"));
    }
    #endregion

    #region 添加子节点

    private void AddChild(XYECOM.Model.XYClassInfo info, string str, String ename, string curTypeFullId)
    {
        string fullids = "";

        if (curTypeFullId != "")
        {
            if (XYECOM.Core.XYRequest.GetQueryString("add") != "")
                fullids = curTypeFullId + XYECOM.Core.XYRequest.GetQueryString("orderid") + ",";

            if (XYECOM.Core.XYRequest.GetQueryString("del") != "")
                fullids = curTypeFullId + XYECOM.Core.XYRequest.GetQueryString("orderid") + ",";

            if (fullids.Contains("," + info.ClassId.ToString() + ","))
                this.pnlSuperClass.Controls.Add(new LiteralControl("<li id=\"li_" + info.ClassId + "\" style=\"display:none;\"><ul>"));
            else
                this.pnlSuperClass.Controls.Add(new LiteralControl("<li id=\"li_" + info.ClassId + "\" style=\"display:none;\"><ul>"));
        }
        else
        {
            this.pnlSuperClass.Controls.Add(new LiteralControl("<li id=\"li_" + info.ClassId + "\" style=\"display:none;\"><ul>"));
        }

        foreach (XYECOM.Model.XYClassInfo info2 in info.childList)
        {
            AddInfoHtml(info2, info.ClassId.ToString(), str, ename, curTypeFullId);

            if (info2.HasSub)
            {
                AddChild(info2, str + "&nbsp;&nbsp;&nbsp;&nbsp;", ename, curTypeFullId);
            }
        }
        this.pnlSuperClass.Controls.Add(new LiteralControl("</ul></li>"));
    }
    #endregion

    private void AddInfoHtml(XYECOM.Model.XYClassInfo info, string parentID, string str, String ename, string curTypeFullId)
    {
        string fullids = "";

        StringBuilder strhtml = new StringBuilder();

        strhtml.Append("<li id=\"lithis").Append(info.ClassId).Append("\">");
        strhtml.Append(str);

        if (curTypeFullId != "")
        {
            if (XYECOM.Core.XYRequest.GetQueryString("add") != "")
                fullids = curTypeFullId + XYECOM.Core.XYRequest.GetQueryString("orderid") + ",";

            if (XYECOM.Core.XYRequest.GetQueryString("del") != "")
                fullids = curTypeFullId + XYECOM.Core.XYRequest.GetQueryString("orderid") + ",";

            if (fullids.Contains("," + info.ClassId.ToString() + ","))
            {
                if (info.HasSub)
                {
                    strhtml.Append("<a href=\"javascript:LabelClassDisplay2('").Append(ename).Append("',").Append(info.ClassId).Append(",'');\">").Append(Img1).Append("</a>");
                }
                else
                {
                    strhtml.Append(Img2);
                }
            }
            else
            {
                if (info.HasSub)
                {
                    strhtml.Append("<a href=\"javascript:LabelClassDisplay2('").Append(ename).Append("',").Append(info.ClassId).Append(",'');\">").Append(Img1).Append("</a>");
                }
                else
                {
                    strhtml.Append(Img2);
                }
            }
        }
        else
        {
            if (info.HasSub)
            {
                //strhtml.Append("<a href=\"javascript:LabelClassDisplay('li_").Append(info.ClassId).Append("','lithis").Append(info.ClassId).Append("');\">").Append(Img1).Append("</a>");                
                strhtml.Append("<a href=\"javascript:LabelClassDisplay2('").Append(ename).Append("',").Append(info.ClassId).Append(",'');\">").Append(Img1).Append("</a>");
            }
            else
            {
                strhtml.Append(Img2);
            }

        }

        if (ename == "offer")
        {
            if (info.HasSub)
            {
                strhtml.Append("<input id=\"input_").Append(parentID).Append("_").Append(info.ClassId).Append("\"type=\"checkbox\" value=\"").Append(info.ClassId).Append("\" disabled/>").Append(imgParent).Append("").Append(info.ClassName).Append("").Append(img3)
                                  .Append("[&nbsp;<a href=\"Typelist.aspx?ename=").Append(ename).Append("&upid=").Append(info.ClassId).Append("\" >↑</a>&nbsp;]")
                                  .Append("[&nbsp;<a href=\"Typelist.aspx?ename=").Append(ename).Append("&downid=").Append(info.ClassId).Append("\" >↓</a>&nbsp;]")
                                  .Append("[&nbsp;<a href=\"ProductTypeAdd.aspx?type=0&ename=").Append(ename).Append("&PT_ID=").Append(info.ClassId).Append("\">添加</a>&nbsp;]")
                                  .Append(" [&nbsp;<a href=\"ProductTypeAdd.aspx?type=1&ename=").Append(ename).Append("&PT_ID=").Append(info.ClassId).Append("\">编辑</a>&nbsp;]")
                                  .Append(" [&nbsp;<a href=\"ProductMove.aspx?ename=").Append(ename).Append("&PT_ParentID=").Append(info.ClassId).Append("\">移动</a>&nbsp;]");

                strhtml.Append(" [&nbsp;<a href=\"../BrandManage/BandBrand.aspx?id=").Append(info.ClassId).Append("\">品牌管理</a>&nbsp;]");
                strhtml.Append(" [&nbsp;<a href=\"BandUnits.aspx?id=").Append(info.ClassId).Append("\">计量单位管理</a>&nbsp;]");

            }
            else
            {
                strhtml.Append("<input id=\"input_").Append(parentID).Append("_").Append(info.ClassId).Append("\" type=\"checkbox\" value=\"").Append(info.ClassId).Append("\" />").Append(imgchird).Append("").Append(info.ClassName).Append("").Append(img3)
                                   .Append("[&nbsp;<a href=\"Typelist.aspx?ename=").Append(ename).Append("&upid=").Append(info.ClassId).Append("\" >↑</a>&nbsp;]")
                                   .Append("[&nbsp;<a href=\"Typelist.aspx?ename=").Append(ename).Append("&downid=").Append(info.ClassId).Append("\" >↓</a>&nbsp;]")
                                   .Append("[&nbsp;<a href=\"ProductTypeAdd.aspx?type=0&ename=").Append(ename).Append("&PT_ID=").Append(info.ClassId).Append("\">添加</a>]&nbsp;")
                                   .Append(" [&nbsp;<a href=\"ProductTypeAdd.aspx?type=1&ename=").Append(ename).Append("&PT_ID=").Append(info.ClassId).Append("\">编辑</a>&nbsp;]")
                                   .Append(" [&nbsp;<a href=\"ProductMove.aspx?ename=").Append(ename).Append("&PT_ParentID=").Append(info.ClassId).Append("\">移动</a>&nbsp;]")
                                   .Append("[&nbsp;<a style=\"cursor:hand;\" onclick=\"javascript:delType('").Append(ename).Append("',").Append(info.ClassId).Append(",").Append(parentID).Append(")\">删除</a>&nbsp;]");

                strhtml.Append(" [&nbsp;<a href=\"../BrandManage/BandBrand.aspx.aspx?id=").Append(info.ClassId).Append("\">品牌管理</a>&nbsp;]");
                strhtml.Append(" [&nbsp;<a href=\"BandUnits.aspx?id=").Append(info.ClassId).Append("\">计量单位管理</a>&nbsp;]");
            }
        }
        else
        {
            if (info.HasSub)
            {
                strhtml.Append("<input id=\"input_").Append(parentID).Append("_").Append(info.ClassId).Append("\" type=\"checkbox\" value=\"").Append(info.ClassId).Append("\" disabled/>").Append(imgParent).Append(" ").Append(info.ClassName).Append("    ").Append(img3)
                       .Append("[&nbsp;<a href=\"Typelist.aspx?ename=").Append(ename).Append("&upid=").Append(info.ClassId).Append("\" >↑</a>&nbsp;]")
                       .Append("[&nbsp;<a href=\"Typelist.aspx?ename=").Append(ename).Append("&downid=").Append(info.ClassId).Append("\" >↓</a>&nbsp;]")
                       .Append("[&nbsp;<a href=\"TypeAdd.aspx?type=0&ename=").Append(ename).Append("&PT_ID=").Append(info.ClassId).Append("\">添加</a>&nbsp;]")
                       .Append(" [&nbsp;<a href=\"TypeAdd.aspx?type=1&ename=").Append(ename).Append("&PT_ID=").Append(info.ClassId).Append("\">编辑</a>&nbsp;]")
                       .Append(" [&nbsp;<a href=\"ProductMove.aspx?ename=").Append(ename).Append("&PT_ParentID=").Append(info.ClassId).Append("\">移动</a>&nbsp;]");
            }
            else
            {
                strhtml.Append("<input id=\"input_").Append(parentID).Append("_").Append(info.ClassId).Append("\" type=\"checkbox\" value=\"").Append(info.ClassId).Append("\" />").Append(imgchird).Append(" ").Append(info.ClassName).Append("    ").Append(img3)
                       .Append("[&nbsp;<a href=\"Typelist.aspx?ename=").Append(ename).Append("&upid=").Append(info.ClassId).Append("\" >↑</a>&nbsp;]")
                       .Append("[&nbsp;<a href=\"Typelist.aspx?ename=").Append(ename).Append("&downid=").Append(info.ClassId).Append("\" >↓</a>&nbsp;]")
                       .Append("[&nbsp;<a href=\"TypeAdd.aspx?type=0&ename=").Append(ename).Append("&PT_ID=").Append(info.ClassId).Append("\">添加</a>]&nbsp;")
                       .Append(" [&nbsp;<a href=\"TypeAdd.aspx?type=1&ename=").Append(ename).Append("&PT_ID=").Append(info.ClassId).Append("\">编辑</a>&nbsp;]")
                       .Append(" [&nbsp;<a href=\"ProductMove.aspx?ename=").Append(ename).Append("&PT_ParentID=").Append(info.ClassId).Append("\">移动</a>&nbsp;]")
                       .Append("[&nbsp;<a style=\"cursor:hand;\" onclick=\"javascript:delType('").Append(ename).Append("',").Append(info.ClassId).Append(",").Append(parentID).Append(")\">删除</a>&nbsp;]");
            }
        }

        if ("exhibition" != ename && "brand" != ename && "job" != ename)
            strhtml.Append("[&nbsp;<a  href=\"Field.aspx?ModuleName=").Append(ename).Append("&TypeID=").Append(info.ClassId).Append("\">自定义字段管理</a>&nbsp;]");

        strhtml.AppendLine("</li>");

        this.pnlSuperClass.Controls.Add(new LiteralControl(strhtml.ToString()));
    }
    #endregion
    protected void ddlTypeAdd_SelectedIndexChanged(object sender, EventArgs e)
    {
        string moduleName = ddlTypeAdd.SelectedValue;

        XYECOM.Configuration.ModuleInfo moduleInfo = moduleConfig.GetItem(moduleName);

        if (moduleInfo != null && (moduleInfo.EName.Equals("offer") || moduleInfo.PEName.Equals("offer")))
        {
            Response.Redirect("ProductTypeAdd.aspx?pt_id=0&type=0&ename=" + moduleName + "&add=1");
        }
        else
        {
            Response.Redirect("TypeAdd.aspx?pt_id=0&type=0&ename=" + moduleName + "");
        }
    }
}
