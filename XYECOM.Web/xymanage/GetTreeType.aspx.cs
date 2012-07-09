using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using XYECOM.Core;
using XYECOM.Business;

public partial class xymanage_GetTreeType : XYECOM.Web.BasePage.ManagePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //防止调用页面缓存
            HttpContext.Current.Response.Buffer = true;
            HttpContext.Current.Response.ExpiresAbsolute = System.DateTime.Now.AddSeconds(-1);
            HttpContext.Current.Response.Expires = 0;


            if (XYRequest.GetQueryString("type") != "")
            {
                switch (XYRequest.GetQueryString("type"))
                { 
                    case "product":
                        if (XYRequest.GetQueryString("PT_ID") != "" && XYECOM.Core.XYRequest.GetQueryString("ename") != "")
                            CreateProductTypeHTML(Convert.ToInt32(XYRequest.GetQueryString("PT_ID")), XYECOM.Core.XYRequest.GetQueryString("ename"));
                        else
                            createProductTypeListHTML(XYECOM.Core.XYRequest.GetQueryString("ename"));
                        break;
                    case "suogateselist":
                        if (XYRequest.GetQueryString("IT_ID") != "")
                            CreateSuogateTypeInnerHTML(Convert.ToInt64(XYRequest.GetQueryString("IT_ID")));
                        else
                            initSuogateTypeInnerHTML();
                        break;
                    case "serverlist":
                        if (XYRequest.GetQueryString("ST_ID") != "")
                            CreateServerTypeInnerHTML(Convert.ToInt64(XYRequest.GetQueryString("ST_ID")));
                        else
                            initServerTypeInnerHTML();
                        break;
                    case "showlist":
                        if (XYRequest.GetQueryString("SHT_ID") != "")
                            CreateShowTypeInnerHTML(Convert.ToInt64(XYRequest.GetQueryString("SHT_ID")));
                        else
                            initShowTypeInnerHTML();
                        break;
                    case "label":
                        if (XYRequest.GetQueryString("LT_ID") != "")
                            CreateLabelTypeHTML(Convert.ToInt32(XYRequest.GetQueryString("LT_ID")));
                        else
                            createlabletypehtmll();
                        break;
                    case "selectlabel":
                        if (XYRequest.GetQueryString("LT_IDS") != "")
                            createselectlabelTypeHTML(XYRequest.GetQueryString("LT_IDs"));
                        break;
                    case "newtitles":
                        //if (XYRequest.GetQueryString("NT_ID") != "")
                        //    createNewTitlesHTML(Convert.ToInt32(XYRequest.GetQueryString("NT_ID")));
                        //else
                        //    initnewstypehtml();
                        break;
                    case "adtype":
                        if (XYRequest.GetQueryString("AT_ID") != "")
                            createAdPlaceTypeHTML(Convert.ToInt32(XYRequest.GetQueryString("AT_ID")));
                        else
                            createadplacetypeshtml();
                        break;
                    case "companytype":
                        if (XYRequest.GetQueryString("UT_ID") != "")
                            CreateCompanyTypeHTML(Convert.ToInt32(XYRequest.GetQueryString("UT_ID")));
                        else
                            InitCompanyTypeListHTML();
                        break;
                    case "shoptype":
                        
                        InitCompanyTypeListHTML();
                        break;
                   case "jobtype":
                        if (XYECOM.Core.XYRequest.GetQueryString("P_ID") == "")
                            InitJobTypeList();
                        else
                            GetJobTypeList(Convert.ToInt32(XYECOM.Core.XYRequest.GetQueryString("P_ID")));
                        break;
                    case "ljobtype":
                        if (XYECOM.Core.XYRequest.GetQueryString("P_ID") == "")
                            InitlJobTypeList();
                        else
                            GetlJobTypeList(Convert.ToInt32(XYECOM.Core.XYRequest.GetQueryString("P_ID")));
                        break;
                    case "keyword":
                        CreateKeywordHTML();
                        break;

                  
                }
            }
        }
    }

    #region 生成指定类别的子类别
    private void CreateProductTypeHTML(int PT_ID,string moduleName)
    {
        try
        {
            string str = "";
            string strlist = "";
            XYECOM.Business.ProductType pt = new XYECOM.Business.ProductType();
            XYECOM.Model.ProductTypeInfo et = new XYECOM.Model.ProductTypeInfo();
            if (PT_ID == 0)
            {
                str += "请选择供求类别";
                strlist += "<a href=\"#\" onclick=\"selecttypelist(0,this);\">请选择供求类别</a>";
            }
            else
            {
                et = pt.GetItem(PT_ID);
                
                str += et.PT_Name.ToString();
                strlist += "<a href=\"#\" onclick=\"selecttypelist(" + et.PT_ID.ToString() + ",this);\">" + et.PT_Name.ToString() + "</a>";
            }
            str += "$";
            DataTable dt = pt.GetDataTable(PT_ID, moduleName);
            DataTable dt1 = pt.GetDataTable(-1);
            if (dt.Rows.Count > 0)
            {
                strlist += " <ul class=\"subset\">";
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    str += "    <a href=\"#\" title=\"点击选择此项\" onclick=\"selecttypeinfo(" + dt.Rows[i]["PT_ID"].ToString() + ",'" + dt.Rows[i]["PT_Name"].ToString() + "');\">" + dt.Rows[i]["PT_Name"].ToString() + "</a>";
                    strlist += "<li class=\"";
                    dt1.DefaultView.RowFilter = "PT_ParentID=" + dt.Rows[i]["PT_ID"].ToString();
                    DataView dv1 = dt1.DefaultView;
                    if (dv1.Count > 0)
                        strlist += "shrink\" ><a href=\"#\" onclick=\"selecttypelist(" + dt.Rows[i]["PT_ID"].ToString() + ",this);\">" + dt.Rows[i]["PT_Name"].ToString() + "</a></li>";
                    else
                        strlist += "sublast\" >" + dt.Rows[i]["PT_Name"].ToString() + "</li>";

                }
                strlist += "</ul>";

            }
            else
            {
                str += " ";
            }

            str += "$";

            str += strlist;
            Response.Write(str);
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message.Replace("\n", ""));
        }
    }
    #endregion

    #region 初始化类别
    private void createProductTypeListHTML(string moduleName)
    {
        string str = "";
        string strlist = "";
        ProductType pt = new ProductType();
        DataTable dt = pt.GetDataTable(0, moduleName);
        DataTable dt1 = pt.GetDataTable(-1);
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            str += " <li class=\"";
            strlist += "    <a href=\"#\" title=\"点击选择此项\" onclick=\"selecttypeinfo(" + dt.Rows[i]["PT_ID"].ToString() + ",'" + dt.Rows[i]["PT_Name"].ToString() + "');\">" + dt.Rows[i]["PT_Name"].ToString() + "</a>";

            dt1.DefaultView.RowFilter = "PT_ParentID=" + dt.Rows[i]["PT_ID"].ToString();
            DataView dv1 = dt1.DefaultView;
            if (dv1.Count > 0)
                str += "shrink\" ><a href=\"#\" onclick=\"selecttypelist(" + dt.Rows[i]["PT_ID"].ToString() + ",this);\">" + dt.Rows[i]["PT_Name"].ToString() + "</a></li>";
            else
                str += "sublast\" >" + dt.Rows[i]["PT_Name"].ToString() + "</li>";
        }

        str = str.Insert(0, strlist + "$");
        Response.Write(str);
    }
    #endregion


    #region 初始化招商代理类别
    void initSuogateTypeInnerHTML()
    {
        string str = "";
        string strlist = "";
        XYECOM.Business.InviteBusinessType it = new XYECOM.Business.InviteBusinessType();
        DataTable dt = it.GetDataTable(" where IT_ParentID=0", "");
        DataTable dt1 = it.GetDataTable(" where 1=1 ", "");

        for (int i = 0; i < dt.Rows.Count; i++)
        {
            str += "<li class=\"";
            strlist += "    <a href=\"#\" title=\"点击选择此项\" onclick=\"selectsuogateypeinfo(" + dt.Rows[i]["IT_ID"].ToString() + ",'" + dt.Rows[i]["IT_Name"].ToString() + "');\">" + dt.Rows[i]["IT_Name"].ToString() + "</a>";
            
            dt1.DefaultView.RowFilter = "IT_ParentID=" + dt.Rows[i]["IT_ID"].ToString();
            DataView dv1 = dt1.DefaultView;
            if (dv1.Count > 0)
                str += "shrink\" ><a href=\"#\" onclick=\"selectsuogateype(" + dt.Rows[i]["IT_ID"].ToString() + ",this);\">" + dt.Rows[i]["IT_Name"].ToString() + "</a></li>";
            else
                str += "sublast\" >" + dt.Rows[i]["IT_Name"].ToString() + "</li>";

        }
        str = str.Insert(0, strlist + "$");

        System.Web.HttpContext.Current.Response.Write(str);
    }
    #endregion

    #region 指定招商代理类别的子类别
    void CreateSuogateTypeInnerHTML(long IT_ID)
    {
        try
        {
            string str = "";
            string strlist = "";
            XYECOM.Business.InviteBusinessType it = new XYECOM.Business.InviteBusinessType();
            if (IT_ID == 0)
            {
                str += "请选择招商代理类别";
                strlist += "<li onclick=\"selectsuogateype(0,this);\">请选择招商代理类别</li>";
            }
            else
            {
                DataTable dtx = it.GetDataTable(" where IT_ID=" + IT_ID.ToString(), "");
                str += dtx.Rows[0]["IT_Name"].ToString();
                strlist += "<a href=\"#\" onclick=\"selectsuogateype(" + dtx.Rows[0]["IT_ID"].ToString() + ",this);\">" + dtx.Rows[0]["IT_Name"].ToString() + "</a>";
            }
            str += "$";
            DataTable dt = it.GetDataTable(" where IT_ParentID="+IT_ID, "");
            DataTable dt1 = it.GetDataTable(" where 1=1 ", "");
            if (dt.Rows.Count > 0)
            {
                strlist += " <ul class=\"subset\">";
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    str += "    <a href=\"#\" title=\"点击选择此项\" onclick=\"selectsuogateypeinfo(" + dt.Rows[i]["IT_ID"].ToString() + ",'" + dt.Rows[i]["IT_Name"].ToString() + "');\">" + dt.Rows[i]["IT_Name"].ToString() + "</a>";
                    strlist += "<li class=\"";
                    dt1.DefaultView.RowFilter = "IT_ParentID=" + dt.Rows[i]["IT_ID"].ToString();
                    DataView dv1 = dt1.DefaultView;
                    if (dv1.Count > 0)
                        strlist += "shrink\" ><a href=\"#\" onclick=\"selectsuogateype(" + dt.Rows[i]["IT_ID"].ToString() + ",this);\">" + dt.Rows[i]["IT_Name"].ToString() + "</a></li>";
                    else
                        strlist += "sublast\" >" + dt.Rows[i]["IT_Name"].ToString() + "</li>";

                }
                strlist += "</ul>";

            }
            else
            {
                str += " ";
            }

            str += "$";

            str += strlist;
            System.Web.HttpContext.Current.Response.Write(str);
        }
        catch (Exception ex)
        {
            XYECOM.Core .ErrMessage.WriteErrFile(ex);
        }

    }
    #endregion

    #region 初始化服务类别
    void initServerTypeInnerHTML()
    {
        try
        {
            string str = "";
            string strlist = "";
            XYECOM.Business.ServiceType st = new XYECOM.Business.ServiceType();
            DataTable dt = st.GetDataTable(" where ST_ParentID=0 ", "");
            DataTable dt1 = st.GetDataTable(" where 1=1 ", "");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                strlist += "    <a href=\"#\" title=\"点击选择此项\" onclick=\"selectserverypeinfo(" + dt.Rows[i]["ST_ID"].ToString() + ",'" + dt.Rows[i]["ST_Name"].ToString() + "');\">" + dt.Rows[i]["ST_Name"].ToString() + "</a>";
                str += "<li class=\"";
                dt1.DefaultView.RowFilter = "ST_ParentID=" + dt.Rows[i]["ST_ID"].ToString();
                DataView dv1 = dt1.DefaultView;
                if (dv1.Count > 0)
                    str += "shrink\" ><a href=\"#\" onclick=\"selectserverype(" + dt.Rows[i]["ST_ID"].ToString() + ",this);\">" + dt.Rows[i]["ST_Name"].ToString() + "</a></li>";
                else
                    str += "sublast\" >" + dt.Rows[i]["ST_Name"].ToString() + "</li>";


            }

            str = str.Insert(0, strlist + "$");

            System.Web.HttpContext.Current.Response.Write(str);

        }
        catch (Exception ex)
        {
            XYECOM.Core .ErrMessage.WriteErrFile(ex);
        }
    }
    #endregion

    #region 指定服务类别的子类别
    void CreateServerTypeInnerHTML(long ST_ID)
    {
        try
        {
            string str = "";
            string strlist = "";
            XYECOM.Business.ServiceType st = new XYECOM.Business.ServiceType();
            if (ST_ID == 0)
            {
                str += "请选择服务类别";
                strlist += "<li onclick=\"selectserverype(0,this);\">请选择服务类别</li>";
            }
            else
            {
                DataTable dtx = st.GetDataTable(" where ST_ID=" + ST_ID.ToString(), "");
                str += dtx.Rows[0]["ST_Name"].ToString();
                strlist += "<a href=\"#\" onclick=\"selectserverype(" + dtx.Rows[0]["ST_ID"].ToString() + ",this);\">" + dtx.Rows[0]["ST_Name"].ToString() + "</a>";
            }
            str += "$";
            DataTable dt = st.GetDataTable(" where ST_ParentID="+ST_ID, "");
            DataTable dt1 = st.GetDataTable(" where 1=1 ", "");
            if (dt.Rows.Count > 0)
            {
                strlist += " <ul class=\"subset\">";
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    str += "    <a href=\"#\" title=\"点击选择此项\" onclick=\"selectserverypeinfo(" + dt.Rows[i]["ST_ID"].ToString() + ",'" + dt.Rows[i]["ST_Name"].ToString() + "');\">" + dt.Rows[i]["ST_Name"].ToString() + "</a>";
                    strlist += "<li class=\"";
                    dt1.DefaultView.RowFilter = "ST_ParentID=" + dt.Rows[i]["ST_ID"].ToString();
                    DataView dv1 = dt1.DefaultView;
                    if (dv1.Count > 0)
                        strlist += "shrink\" ><a href=\"#\" onclick=\"selectserverype(" + dt.Rows[i]["ST_ID"].ToString() + ",this);\">" + dt.Rows[i]["ST_Name"].ToString() + "</a></li>";
                    else
                        strlist += "sublast\" >" + dt.Rows[i]["ST_Name"].ToString() + "</li>";

                }
                strlist += "</ul>";

            }
            else
            {
                str += " ";
            }

            str += "$";

            str += strlist;
            System.Web.HttpContext.Current.Response.Write(str);
        }
        catch (Exception ex)
        {
            XYECOM.Core .ErrMessage.WriteErrFile(ex);
        }
    }
    #endregion

    #region 初始化展会类别
    void initShowTypeInnerHTML()
    {
        try
        {
            string str = "";
            string strlist = "";
            XYECOM.Business.ShowType st = new XYECOM.Business.ShowType();


            DataTable dt = st.GetDataTable(" where SHT_ParentID=0 ", "");
            DataTable dt1 = st.GetDataTable(" where 1=1 ", "");

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                strlist += "    <a href=\"#\" title=\"点击选择此项\" onclick=\"selectcooperatetypeinfo(" + dt.Rows[i]["SHT_ID"].ToString() + ",'" + dt.Rows[i]["SHT_Name"].ToString() + "');\">" + dt.Rows[i]["SHT_Name"].ToString() + "</a>";
                str += "<li class=\"";
                dt1.DefaultView.RowFilter = "SHT_ParentID=" + dt.Rows[i]["SHT_ID"].ToString();
                DataView dv1 = dt1.DefaultView;
                if (dv1.Count > 0)
                    str += "shrink\" ><a href=\"#\" onclick=\"selectcooperatetype(" + dt.Rows[i]["SHT_ID"].ToString() + ",this);\">" + dt.Rows[i]["SHT_Name"].ToString() + "</a></li>";
                else
                    str += "sublast\" >" + dt.Rows[i]["SHT_Name"].ToString() + "</li>";

            }
            str = str.Insert(0, strlist + "$");

            System.Web.HttpContext.Current.Response.Write(str);
        }
        catch (Exception ex)
        {
            XYECOM.Core .ErrMessage.WriteErrFile(ex);
        }
    }
    #endregion

    #region 指定展会类别的子类别
    void CreateShowTypeInnerHTML(long SHT_ID)
    {

        try
        {
            string str = "";
            string strlist = "";
            XYECOM.Business.ShowType st = new XYECOM.Business.ShowType();
            if (SHT_ID == 0)
            {
                str += "请选择展会类别";
                strlist += "<li onclick=\"selectcooperatetype(0,this);\">请选择展会类别</li>";
            }
            else
            {
                DataTable dtx = st.GetDataTable(" where SHT_ID=" + SHT_ID.ToString(), "");
                str += dtx.Rows[0]["SHT_Name"].ToString();
                strlist += "<a href=\"#\" onclick=\"selectcooperatetype(" + dtx.Rows[0]["SHT_ID"].ToString() + ",this);\">" + dtx.Rows[0]["SHT_Name"].ToString() + "</a>";
            }
            str += "$";
            DataTable dt = st.GetDataTable(" where SHT_ParentID=" + SHT_ID, "");
            DataTable dt1 = st.GetDataTable(" where 1=1 ", "");
            if (dt.Rows.Count > 0)
            {
                strlist += " <ul class=\"subset\">";
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    str += "    <a href=\"#\" title=\"点击选择此项\" onclick=\"selectcooperatetypeinfo(" + dt.Rows[i]["SHT_ID"].ToString() + ",'" + dt.Rows[i]["SHT_Name"].ToString() + "');\">" + dt.Rows[i]["SHT_Name"].ToString() + "</a>";
                    strlist += "<li class=\"";
                    dt1.DefaultView.RowFilter = "SHT_ParentID=" + dt.Rows[i]["SHT_ID"].ToString();
                    DataView dv1 = dt1.DefaultView;
                    if (dv1.Count > 0)
                        strlist += "shrink\" ><a href=\"#\" onclick=\"selectcooperatetype(" + dt.Rows[i]["SHT_ID"].ToString() + ",this);\">" + dt.Rows[i]["SHT_Name"].ToString() + "</a></li>";
                    else
                        strlist += "sublast\" >" + dt.Rows[i]["SHT_Name"].ToString() + "</li>";

                }
                strlist += "</ul>";

            }
            else
            {
                str += " ";
            }

            str += "$";

            str += strlist;
            System.Web.HttpContext.Current.Response.Write(str);
        }
        catch (Exception ex)
        {
            XYECOM.Core .ErrMessage.WriteErrFile(ex);
        }
    }
    #endregion

    #region 指定标签类别子类别
    void CreateLabelTypeHTML(int LT_ID)
    {
        try
        {
            string str = "";
            string strlist = "";
            XYECOM.Model.LabelTypeInfo el = new XYECOM.Model.LabelTypeInfo();
            XYECOM.Business.LabelType lt = new XYECOM.Business.LabelType();
            if (LT_ID == 0)
            {
                str += "请选择标签分类";
                strlist += "<a href=\"#\" onclick=\"selecttypelist(0,this);\">请选择标签分类</a>";
            }
            else
            {
            
              el = lt.GetItem(LT_ID);

                str += el.LT_Name;

                strlist += "<a href=\"#\" onclick=\"selecttypelist(" + el.LT_ID + ",this);\">" + el.LT_Name + "</a>";

            }
            str += "$";
            DataTable dt = lt.GetDataTable("where LT_ParentID=" + LT_ID);
            DataTable dt1 = lt.GetDataTable(" where 1=1 ");
            if (dt.Rows.Count > 0)
            {
                strlist += " <ul class=\"subset\">";
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    str += "    <a href=\"#\" title=\"点击选择此项\" onclick=\"selecttypeinfo(" + dt.Rows[i]["LT_ID"].ToString() + ",'" + dt.Rows[i]["LT_Name"].ToString() + "');\">" + dt.Rows[i]["LT_Name"].ToString() + "</a>";
                    strlist += "<li class=\"";
                    dt1.DefaultView.RowFilter = "LT_ParentID=" + dt.Rows[i]["LT_ID"].ToString();
                    DataView dv1 = dt1.DefaultView;
                    if (dv1.Count > 0)
                        strlist += "shrink\" ><a href=\"#\" onclick=\"selecttypelist(" + dt.Rows[i]["LT_ID"].ToString() + ",this);\">" + dt.Rows[i]["LT_Name"].ToString() + "</a></li>";
                    else
                        strlist += "sublast\" >" + dt.Rows[i]["LT_Name"].ToString() + "</li>";

                }
                strlist += "</ul>";

            }
            else
            {
                str += " ";
            }

            str += "$";

            str += strlist;
            Response.Write(str);
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message.Replace("\n", ""));
        }
    }
    void createlabletypehtmll()
    {
        try
        {
            string str = "";
            string strlist = "";
            XYECOM.Model.LabelTypeInfo el = new XYECOM.Model.LabelTypeInfo();
            XYECOM.Business.LabelType lt = new XYECOM.Business.LabelType();
            DataTable dt = lt.GetDataTable("where LT_ParentID=0");
            DataTable dt1 = lt.GetDataTable(" where 1=1 ");

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                str += "    <a href=\"#\" title=\"点击选择此项\" onclick=\"selecttypeinfo(" + dt.Rows[i]["LT_ID"].ToString() + ",'" + dt.Rows[i]["LT_Name"].ToString() + "');\">" + dt.Rows[i]["LT_Name"].ToString() + "</a>";
                strlist += "<li class=\"";
                dt1.DefaultView.RowFilter = "LT_ParentID=" + dt.Rows[i]["LT_ID"].ToString();
                DataView dv1 = dt1.DefaultView;
                if (dv1.Count > 0)
                    strlist += "shrink\" ><a href=\"#\" onclick=\"selecttypelist(" + dt.Rows[i]["LT_ID"].ToString() + ",this);\">" + dt.Rows[i]["LT_Name"].ToString() + "</a></li>";
                else
                    strlist += "sublast\" >" + dt.Rows[i]["LT_Name"].ToString() + "</li>";

            }


            str += "$" + strlist;
            Response.Write(str);
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message.Replace("\n", ""));
        }
    }
    #endregion

    #region 获取指定标签类别
    private void createselectlabelTypeHTML(string LT_IDs)
    {
        string str = "";
        XYECOM.Business.LabelType lt = new XYECOM.Business.LabelType();
        DataTable dt = lt.GetDataTable(" where LT_ID in (" + LT_IDs + ")");

        for (int i = 0; i < dt.Rows.Count; i++)
        {
            str += "<a href=\"#\" onclick=\"canceltype(" + dt.Rows[i]["LT_ID"].ToString() + ");\" class=\"result\">" + dt.Rows[i]["LT_Name"].ToString() + "</a>";
        }
        Response.Write(str);
    }
    #endregion

    #region 初始化新闻栏目
    //private void initnewstypehtml()
    //{
    //    string str = "";
    //    string strlist = "";
    //    XYECOM.Business.NewsTitles nt = new XYECOM.Business.NewsTitles();
    //    DataTable DT = nt.GetDataTable("where NT_PID=0","");
    //    DataTable dte = nt.GetDataTable("where 1=1 ", "");
    //    if (DT.Rows.Count > 0)
    //    {
    //        for (int i = 0; i < DT.Rows.Count; i++)
    //        {
    //            str += "   <a href=\"#\" title=\"点击选择此项\" onclick=\"selectnewstypeinfo(" + DT.Rows[i]["NT_ID"].ToString() + ",'" + DT.Rows[i]["NT_Name"].ToString() + "');\">" + DT.Rows[i]["NT_Name"].ToString() + "</a>";
    //            strlist += "<li class=\"";
    //            dte.DefaultView.RowFilter = "NT_PID=" + DT.Rows[i]["NT_ID"].ToString();
    //            DataView dv1 = dte.DefaultView;

    //            strlist += "shrink\" ><a href=\"#\" onclick=\"selectnewstypelist(" + DT.Rows[i]["NT_ID"].ToString() + ",this);\">" + DT.Rows[i]["NT_Name"].ToString() + "</a></li>";

    //        }
    //    }
    //    else
    //    {
    //        str += "";
    //    }

    //    str = str.Insert(0, strlist+"$");
    //    Response.Write(str);
    //}
    #endregion

    #region  生成指定新闻栏目的子栏目

    //private void createNewTitlesHTML(int id)
    //{
    //    try
    //    {
    //        string str = "";
    //        string strlist = "";
    //        string strWhere = "";
    //        XYECOM.Business.NewsTitles nt = new XYECOM.Business.NewsTitles();
    //        if (id == 0)
    //        {
    //            str += "请选择新闻栏目";
    //            strlist += "<a href=\"#\" onclick=\"selectnewstypelist(0,this);\">请选择新闻栏目</a>";
    //        }
    //        else
    //        {
    //            strWhere = "where NT_ID=" + id;
    //            DataTable dt = nt.GetDataTable(strWhere, "");
    //            if (dt.Rows.Count > 0)
    //            {
    //                str += dt.Rows[0]["NT_Name"].ToString();
    //                strlist += "<a href=\"#\" onclick=\"selectnewstypelist(" + dt.Rows[0]["NT_ID"].ToString() + ",this);\">" + dt.Rows[0]["NT_Name"].ToString() + "</a>";
    //            }
    //        }

    //        str += "$";
    //        DataTable DT = nt.GetDataTable("where NT_PID=" + id, "");
    //        DataTable dte = nt.GetDataTable("where 1=1 ", "");
    //        if (DT.Rows.Count > 0)
    //        {
    //            strlist += "<ul class=\"subset\">";
    //            for (int i = 0; i < DT.Rows.Count; i++)
    //            {
    //                str += "   <a href=\"#\" title=\"点击选择此项\" onclick=\"selectnewstypeinfo(" + DT.Rows[i]["NT_ID"].ToString() + ",'" + DT.Rows[i]["NT_Name"].ToString() + "');\">" + DT.Rows[i]["NT_Name"].ToString() + "</a>";
    //                strlist += "<li class=\"";
    //                dte.DefaultView.RowFilter = "NT_PID=" + DT.Rows[i]["NT_ID"].ToString();
    //                DataView dv1 = dte.DefaultView;

    //                    strlist += "shrink\" ><a href=\"#\" onclick=\"selectnewstypelist(" + DT.Rows[i]["NT_ID"].ToString() + ",this);\">" + DT.Rows[i]["NT_Name"].ToString() + "</a></li>";

    //            }
    //            strlist += "</ul>";
    //        }
    //        else
    //        {
    //            str += "";
    //        }

    //        str += "$";

    //        str += strlist;
    //        Response.Write(str);
    //    }
    //    catch (Exception ex)
    //    {
    //        Response.Write(ex.Message.Replace("\n", ""));
    //    }
    //}
    #endregion

    #region 初始化广告位类别
    private void createadplacetypeshtml()
    {
        try
        {
            string str = "";
            string strlist = "";
            XYECOM.Business.AdPlaceType at = new XYECOM.Business.AdPlaceType();
            DataTable DT = at.GetDataTable("where AT_PID=0", "");
            DataTable dte = at.GetDataTable("where 1=1", "");
            if (DT.Rows.Count > 0)
            {
                for (int i = 0; i < DT.Rows.Count; i++)
                {
                    str += " <a href=\"#\" title=\"点此选择此项\" onclick=\"selecttypeinfo(" + DT.Rows[i]["AT_ID"].ToString() + ",'" + DT.Rows[i]["AT_Name"].ToString() + "');\">" + DT.Rows[i]["AT_Name"].ToString() + "</a>";
                    strlist += "<li class=\"";
                    dte.DefaultView.RowFilter = "AT_PID=" + DT.Rows[i]["AT_ID"].ToString();
                    DataView dv1 = dte.DefaultView;

                    if (dv1.Count > 0)
                        strlist += "shrink\"><a href=\"#\" onclick=\"selecttypelist(" + DT.Rows[i]["AT_ID"].ToString() + ",this);\">" + DT.Rows[i]["AT_Name"].ToString() + "</a></li>";
                    else
                        strlist += "spread\">" + DT.Rows[i]["AT_Name"].ToString() + "</li>";
                }
            }
            else
            {
                str += "";
            }
            str = str.Insert(0, strlist + "$");
            Response.Write(str);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    #endregion

    #region 生成指定广告位类别的子栏目

    private void createAdPlaceTypeHTML(int id)
    {
        try
        {
            string str = "";
            string strlist = "";
            string strWhere = "";
            XYECOM.Business.AdPlaceType at = new XYECOM.Business.AdPlaceType();
            if (id == 0)
            {
                str += "请选择广告位类别";
                strlist += "<a href=\"#\" onclick=\"selecttypelist(0,this);\">请选择广告位类别</a>";
            }
            else
            {
                strWhere = "where AT_ID=" + id;
                DataTable dt = at.GetDataTable(strWhere, "");
                if (dt.Rows.Count > 0)
                {
                    str += dt.Rows[0]["AT_Name"].ToString();
                    strlist += "<a href=\"#\" onclick=\"selecttypelist(" + dt.Rows[0]["AT_ID"].ToString() + ",this);\">" + dt.Rows[0]["AT_Name"].ToString() + "</a>";
                }
            }

            str += "$";
            DataTable DT = at.GetDataTable("where AT_PID=" + id, "");
            DataTable dte = at.GetDataTable("where 1=1", "");
            if (DT.Rows.Count > 0)
            {
                strlist += "<ul class=\"subset\">";
                for (int i = 0; i < DT.Rows.Count; i++)
                {
                    str += " <a href=\"#\" title=\"点击选择此项\" onclick=\"selecttypeinfo(" + DT.Rows[i]["AT_ID"].ToString() + ",'" + DT.Rows[i]["AT_Name"].ToString() + "');\">" + DT.Rows[i]["AT_Name"].ToString() + "</a>";
                    strlist += "<li class=\"";
                    dte.DefaultView.RowFilter = "AT_PID=" + DT.Rows[i]["AT_ID"].ToString();
                    DataView dv1 = dte.DefaultView;

                    if (dv1.Count > 0)
                    {
                        strlist += "shrink\"><a href=\"#\" onclick=\"selecttypelist(" + DT.Rows[i]["AT_ID"].ToString() + ",this);\">" + DT.Rows[i]["AT_Name"].ToString() + "</a></li>";
                    }
                    else
                        strlist += "sublast\">" + DT.Rows[i]["AT_Name"].ToString() + "</li>";
                }
                strlist += "</ul>";
            }
            else
            {
                str += "";
            }
            str += "$";
            str += strlist;
            Response.Write(str);
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message.Replace("\n", ""));
        }
    }

    #endregion

    #region 生成岗位子信息
    private void CreatepostTypeHTML(int P_ID)
    {
        try
        {
            string str = "";
            string strlist = "";
            XYECOM.Model.PostInfo ep = new XYECOM.Model.PostInfo();
            XYECOM.Business.Post p = new XYECOM.Business.Post();
            if (P_ID == 0)
            {
                str += "请选择岗位名称";
                strlist += "<a href=\"#\" onclick=\"selecttypelist(0,this);\">请选择岗位名称</a>";
            }
            else
            {
                ep = p.GetItem(P_ID);
                str += ep.P_Name.ToString();
                strlist += "<a href=\"#\" onclick=\"selecttypelist(" + ep.P_ID.ToString() + ",this);\">" + ep.P_Name.ToString() + "</a>";
            }
            str += "$";
            DataTable dt;
            dt = p.GetDataTable(P_ID);
            DataTable dt1 = p.GetDataTable(-1);
            if (dt.Rows.Count > 0)
            {
                strlist += " <ul class=\"subset\">";
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    str += "    <a href=\"#\" title=\"点击选择此项\" onclick=\"selecttypeinfo(" + dt.Rows[i]["P_ID"].ToString() + ",'" + dt.Rows[i]["P_Name"].ToString() + "');\">" + dt.Rows[i]["P_Name"].ToString() + "</a>";
                    strlist += "<li class=\"";
                    dt1.DefaultView.RowFilter = "P_ParentID=" + dt.Rows[i]["P_ID"].ToString();
                    DataView dv1 = dt1.DefaultView;
                    if (dv1.Count > 0)
                        strlist += "shrink\" ><a href=\"#\" onclick=\"selecttypelist(" + dt.Rows[i]["P_ID"].ToString() + ",this);\">" + dt.Rows[i]["P_Name"].ToString() + "</a></li>";
                    else
                        strlist += "sublast\" >" + dt.Rows[i]["P_Name"].ToString() + "</li>";

                }
                strlist += "</ul>";
            }
            else
            {
                str += " ";
            }
            str += "$";
            str += strlist;
            Response.Write(str);
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message.Replace("\n", ""));
        }
    }
    #endregion

    #region 初始化岗位信息
    private void createpostTypeListHTML()
    {
        string str = "";
        XYECOM.Business.Post p = new XYECOM.Business.Post();
        DataTable dt = p.GetDataTable(0);
        DataTable dt1 = p.GetDataTable(-1);
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            str += " <li class=\"";
            dt1.DefaultView.RowFilter = "P_ParentID=" + dt.Rows[i]["P_ID"].ToString();
            DataView dv1 = dt1.DefaultView;
            if (dv1.Count > 0)
                str += "shrink";
            else
                str += "sublast";
            str += "\" ><a href=\"#\" onclick=\"selecttypelist(" + dt.Rows[i]["P_ID"].ToString() + ",this);\">" + dt.Rows[i]["P_Name"].ToString() + "</a></li>";
        }
        Response.Write(str);
    }
    #endregion

    #region 获取指定岗位名称
    private void createselectpostTypeHTML(string P_IDs)
    {
        string str = "";

        Post p = new Post();
        DataTable dt = p.GetDataTable(P_IDs);
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            str += "<li class=\"result\">" + dt.Rows[i]["P_Name"].ToString() + "</li>";
        }
        Response.Write(str);
    }
    #endregion

    #region 生成企业类型
    private void CreateCompanyTypeHTML(int UT_ID)
    {
        try
        {
            string str = "";
            string strlist = "";
            XYECOM.Business.UserType ut = new XYECOM.Business.UserType();
            XYECOM.Model.UserTypeInfo et = new XYECOM.Model.UserTypeInfo();
            if (UT_ID == 0)
            {
                str += "请选择企业类别";
                strlist += "<a href=\"#\" onclick=\"selectcompanytypelist(0,this);\">请选择企业类别</a>";
            }
            else
            {
                et = ut.GetItem(UT_ID);

                str += et.UT_Type.ToString();
                strlist += "<a href=\"#\" onclick=\"selectcompanytypelist(" + et.UT_ID.ToString() + ",this);\">" + et.UT_Type.ToString() + "</a>";
            }

            str += "$";
            DataTable dt;
            dt = ut.GetDataTable(UT_ID);
            DataTable dt1 = ut.GetDataTable(-1);

            if (dt.Rows.Count > 0)
            {
                strlist += " <ul class=\"subset\">";
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    str += "    <a href=\"#\" title=\"点击选择此项\" onclick=\"selectcompanytypeinfo(" + dt.Rows[i]["UT_ID"].ToString() + ",'" + dt.Rows[i]["UT_Type"].ToString() + "');\">" + dt.Rows[i]["UT_Type"].ToString() + "</a>";
                    strlist += "<li class=\"";
                    dt1.DefaultView.RowFilter = "UT_PID=" + dt.Rows[i]["UT_ID"].ToString();
                    DataView dv1 = dt1.DefaultView;
                    if (dv1.Count > 0)
                        strlist += "shrink\" ><a href=\"#\" onclick=\"selectcompanytypelist(" + dt.Rows[i]["UT_ID"].ToString() + ",this);\">" + dt.Rows[i]["UT_Type"].ToString() + "</a></li>";
                    else
                        strlist += "sublast\" >" + dt.Rows[i]["UT_Type"].ToString() + "</li>";

                }
                strlist += "</ul>";
            }
            else
            {
                str += " ";
            }
            str += "$";
            str += strlist;
            Response.Write(str);
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message.Replace("\n", ""));
        }
    }
    #endregion

    #region 初始化企业类型信息
    private void InitCompanyTypeListHTML()
    {

        string str = "";
        string strlist = "";
        XYECOM.Business.UserType ut = new XYECOM.Business.UserType();
        DataTable dt = ut.GetDataTable(0);
        DataTable dt1 = ut.GetDataTable(-1);
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            strlist += "    <a href=\"#\" title=\"点击选择此项\" onclick=\"selectcompanytypeinfo(" + dt.Rows[i]["UT_ID"].ToString() + ",'" + dt.Rows[i]["UT_Type"].ToString() + "');\">" + dt.Rows[i]["UT_Type"].ToString() + "</a>";
            str += "<li class=\"";
            dt1.DefaultView.RowFilter = "UT_PID=" + dt.Rows[i]["UT_ID"].ToString();
            DataView dv1 = dt1.DefaultView;
            if (dv1.Count > 0)
                str += "shrink\" ><a href=\"#\" onclick=\"selectcompanytypelist(" + dt.Rows[i]["UT_ID"].ToString() + ",this);\">" + dt.Rows[i]["UT_Type"].ToString() + "</a></li>";
            else
                str += "sublast\" >" + dt.Rows[i]["UT_Type"].ToString() + "</li>";


        }

        str = str.Insert(0, strlist + "$");

        System.Web.HttpContext.Current.Response.Write(str);

    }
    #endregion

    #region 初始化岗位列表
    private void InitJobTypeList()
    {
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        XYECOM.Business.Post p = new Post();
        DataTable dt = p.GetDataTable(0);

        for (int i = 0; i < dt.Rows.Count; i++)
        {
            sb.Append("<li><a href=\"#\" title=\"点击选择此项\" onclick=\"selectpjobtypelist(");
            sb.Append(dt.Rows[i]["P_ID"].ToString());
            sb.Append(",'");
            sb.Append(dt.Rows[i]["P_Name"].ToString());
            sb.Append("');\">");
            sb.Append(dt.Rows[i]["P_Name"].ToString());
            sb.Append("</a></li>");
        }

        HttpContext.Current.Response.Write(sb.ToString());
    }
    #endregion

    #region 获取指定岗位子岗位
    private void GetJobTypeList(int P_ID)
    {
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        Post p = new Post();

        DataTable dt = p.GetDataTable(P_ID);

        for (int i = 0; i < dt.Rows.Count; i++)
        {
            sb.Append("<li><a href=\"#\" title=\"点击选择此项\" onclick=\"selectjobtypeinfo(");
            sb.Append(dt.Rows[i]["P_ID"].ToString());
            sb.Append(",'");
            sb.Append(dt.Rows[i]["P_Name"].ToString());
            sb.Append("');\">");
            sb.Append(dt.Rows[i]["P_Name"].ToString());
            sb.Append("</a></li>");
        }

        HttpContext.Current.Response.Write(sb.ToString());
    }
    #endregion

    #region 初始化岗位列表
    private void InitlJobTypeList()
    {
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        XYECOM.Business.Post p = new Post();
        DataTable dt = p.GetDataTable(0);

        for (int i = 0; i < dt.Rows.Count; i++)
        {
            sb.Append("<li><a href=\"#\" title=\"点击选择此项\" onclick=\"selectlpjobtypelist(");
            sb.Append(dt.Rows[i]["P_ID"].ToString());
            sb.Append(",'");
            sb.Append(dt.Rows[i]["P_Name"].ToString());
            sb.Append("');\">");
            sb.Append(dt.Rows[i]["P_Name"].ToString());
            sb.Append("</a></li>");
        }

        HttpContext.Current.Response.Write(sb.ToString());
    }
    #endregion

    #region 获取指定岗位子岗位
    private void GetlJobTypeList(int P_ID)
    {
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        Post p = new Post();

        DataTable dt = p.GetDataTable(P_ID);

        for (int i = 0; i < dt.Rows.Count; i++)
        {
            sb.Append("<li><a href=\"#\" title=\"点击选择此项\" onclick=\"selectljobtypeinfo(");
            sb.Append(dt.Rows[i]["P_ID"].ToString());
            sb.Append(",'");
            sb.Append(dt.Rows[i]["P_Name"].ToString());
            sb.Append("');\">");
            sb.Append(dt.Rows[i]["P_Name"].ToString());
            sb.Append("</a></li>");
        }

        HttpContext.Current.Response.Write(sb.ToString());
    }
    #endregion

    #region 获取关键字
    private void CreateKeywordHTML()
    {
        //System.Text.StringBuilder str = new System.Text.StringBuilder();
        //XYECOM.Business.Keyword kw = new XYECOM.Business.Keyword();
        //XYECOM.Model.KeywordInfo ki = new XYECOM.Model.KeywordInfo();
        //string strWhere = "where 1=1";
        //string strOrder = " Order by KI_ID desc";
        //DataTable dt = kw.GetDataTable(strWhere, strOrder);

        //for (int i = 0; i < dt.Rows.Count; i++)
        //{
        //    str.Append("<li class=\"\"><a href=\"#\" title=\"点此选择此项\" onclick=\"selectkeywordlist(");
        //    str.Append(Convert.ToInt32(dt.Rows[i]["KI_ID"]));
        //    str.Append(",'");
        //    str.Append(dt.Rows[i]["KI_Name"].ToString());
        //    str.Append("');\">");
        //    str.Append(dt.Rows[i]["KI_Name"].ToString());
        //    str.Append("</a></li>");
        //}

        //HttpContext.Current.Response.Write(str.ToString());
    }
    #endregion
}


          