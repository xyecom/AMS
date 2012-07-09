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

public partial class xymanage_basic_TypeAdd : XYECOM.Web.BasePage.ManagePage
{
    private string backUrl = "";
    private bool error = false;
    private String ename = "";
    private String type = "";
    private String pt_id = "";

    XYECOM.Business.ProductType pt = new XYECOM.Business.ProductType();
    XYECOM.Model.ProductTypeInfo ept = new XYECOM.Model.ProductTypeInfo();
    
    XYECOM.Business.InviteBusinessType it = new XYECOM.Business.InviteBusinessType();
    XYECOM.Model.InviteBusinessTypeInfo iti = new XYECOM.Model.InviteBusinessTypeInfo();

    XYECOM.Business.ServiceType st = new XYECOM.Business.ServiceType();
    XYECOM.Model.ServiceTypeInfo sti = new XYECOM.Model.ServiceTypeInfo();

    XYECOM.Business.ShowType showtype = new XYECOM.Business.ShowType();
    XYECOM.Model.ShowTypeInfo showinfo = new XYECOM.Model.ShowTypeInfo();

    XYECOM.Business.Post post = new Post();
    XYECOM.Model.PostInfo postinfo = new XYECOM.Model.PostInfo();

    #region ҳ�����
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

    #region ��ʼ��ҳ������
    private void pageinit()
    {

        if (XYECOM.Core.XYRequest.GetQueryString("pt_id").Equals("0"))
        {
            lblName.Text = "�����";
            this.module.Visible = true;
            this.module2.Visible = true;
        }
        //ģ������
        ename = XYECOM.Core.XYRequest.GetQueryString("ename");

        switch (ename)
        {
            case "venture":
                lblType.Text = "�ӹ���Ϣ";
                break;
            case "investment":
                lblType.Text = "���̴���";
                break;
            case "service":
                lblType.Text = "������Ϣ";
                break;
            case "brand":
                lblType.Text = "Ʒ�Ʒ���";
                break;
            case "job":
                lblType.Text = "��Ƹ��λ";
                break;
            case "exhibition":
                lblType.Text = "չ�����";
                break;
            case "pifa":
                lblType.Text = "������Ϣ";
                break;
        }

        //type:0��� / type:1�༭
        type = XYECOM.Core.XYRequest.GetQueryString("type");

        if (ename.Equals(""))
        {
            ename = "venture";
        }

        pt_id = XYECOM.Core.XYRequest.GetQueryString("pt_id");

        int parentId = XYECOM.Core.MyConvert.GetInt32(pt_id);

        #region �����������
        if (type.Equals("0"))
        {
            if (ename.Equals("job") || ename.Equals("exhibition"))
            {
                if (ename.Equals("job") && pt_id != "0")
                {
                    postinfo = post.GetItem(parentId);
                    lblName.Text = GetTypeAllName(ename, postinfo.P_ID);
                }
                if ((ename.Equals("exhibition") && pt_id != "0"))
                {
                    showinfo = showtype.GetItem(parentId);
                    lblName.Text = GetTypeAllName(ename, showinfo.SHT_ID);
                }
            }
            else
            {
                if ((ename.Equals("investment") || XYECOM.Configuration.Module.Instance.GetItem(ename).PEName.Equals("investment")) && pt_id != "0")
                {
                    iti = it.GetItem(parentId);
                    lblName.Text = GetTypeAllName(ename, iti.IT_ID);
                }
                if ((ename.Equals("service") || XYECOM.Configuration.Module.Instance.GetItem(ename).PEName.Equals("service")) && pt_id != "0")
                {
                    sti = st.GetItem(parentId);
                    lblName.Text = GetTypeAllName(ename, sti.ST_ID);
                }
            }
        }
        #endregion

        #region ���ر༭���
        if (type.Equals("1"))
        {


            lbremark.Visible = false;
            tbName.TextMode = TextBoxMode.SingleLine;


            if (ename.Equals("job") || ename.Equals("exhibition"))
            {
                if (ename.Equals("job") && pt_id != "0")
                {
                    postinfo = post.GetItem(Convert.ToInt32(pt_id));
                    PT_ID = postinfo.P_ID;
                    this.tbName.Text = postinfo.P_Name;
                    this.PT_ParentID = postinfo.P_ParentID;
                    if (PT_ParentID != 0)
                    {
                        postinfo = post.GetItem(Convert.ToInt32(PT_ParentID));
                        lblName.Text = GetTypeAllName(ename, postinfo.P_ID);
                    }
                    else
                    {
                        this.lblName.Text = "һ�����";
                    }
                }
                if ((ename.Equals("exhibition") && pt_id != "0"))
                {
                    showinfo = showtype.GetItem(Convert.ToInt64(pt_id));
                    PT_ID = showinfo.SHT_ID;
                    this.tbName.Text = showinfo.SHT_Name;
                    this.PT_ParentID = showinfo.SHT_ParentID;
                    if (PT_ParentID != 0)
                    {
                        showinfo = showtype.GetItem(PT_ParentID);
                        lblName.Text = GetTypeAllName(ename, showinfo.SHT_ID);
                    }
                    else
                    {
                        this.lblName.Text = "һ�����";
                    }
                }
            }
            else
            {  
                if ((ename.Equals("investment") || XYECOM.Configuration.Module.Instance.GetItem(ename).PEName.Equals("investment")) && pt_id != "0")
                {
                    iti = it.GetItem(Convert.ToInt64(pt_id));
                    PT_ID = iti.IT_ID;
                    this.tbName.Text = iti.IT_Name;
                    this.PT_ParentID = iti.IT_ParentID;
                    if (PT_ParentID != 0)
                    {
                        iti = it.GetItem(PT_ParentID);
                        lblName.Text = GetTypeAllName(ename, iti.IT_ID);
                    }
                    else
                    {
                        this.lblName.Text = "һ�����";
                    }
                }
                if ((ename.Equals("service") || XYECOM.Configuration.Module.Instance.GetItem(ename).PEName.Equals("service")) && pt_id != "0")
                {
                    sti = st.GetItem(Convert.ToInt64(pt_id));
                    PT_ID = sti.ST_ID;
                    this.tbName.Text = sti.ST_Name;
                    this.PT_ParentID = sti.ST_ParentID;
                    if (PT_ParentID != 0)
                    {
                        sti = st.GetItem(PT_ParentID);
                        lblName.Text = GetTypeAllName(ename, sti.ST_ID);
                    }
                    else
                    {
                        this.lblName.Text = "һ�����";
                    }
                }
            }
        }
        #endregion
    }
    #endregion

    #region  ��������
    private void InsertData(string tbName)
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
            if (ename.Equals("job") || ename.Equals("exhibition"))
            {
                if (ename.Equals("job"))
                {
                    postinfo.P_Name = tbName;
                    postinfo.P_ParentID = (int)PT_ParentID;
                    err = post.Insert(postinfo);
                }

                if (ename.Equals("exhibition"))
                {
                    showinfo.SHT_Name = tbName;
                    showinfo.SHT_ParentID = PT_ParentID;

                    err = showtype.Insert(showinfo);
                }
            }
            else
            {
                if (ename.Equals("investment") || XYECOM.Configuration.Module.Instance.GetItem(ename).PEName.Equals("investment"))
                {
                    iti.IT_Name = tbName;
                    iti.IT_ParentID = PT_ParentID;
                    iti.ModuleName = ename;
                    err = it.Insert(iti);
                }

                if (ename.Equals("service") || XYECOM.Configuration.Module.Instance.GetItem(ename).PEName.Equals("service"))
                {
                    sti.ST_Name = tbName;
                    sti.ST_ParentID = PT_ParentID;
                    sti.ModuleName = ename;

                    err = st.Insert(sti);
                }
            }

            if (err > 0)
            {

            }
            else if (err == -1)
            {
                Alert("����[ " + tbName + " ]�Ѵ��ڣ�������������Ϣ��", backUrl + "?orderid=" + pt_id + "&ename=" + XYECOM.Core.XYRequest.GetQueryString("ename"));
                error = true;
            }
            else
            {
                error = true;
                Alert("���" + tbName + "ʧ�ܣ�", backUrl + "?orderid=" + pt_id + "&ename=" + XYECOM.Core.XYRequest.GetQueryString("ename"));
            }
        }
    }
    #endregion

    #region ����
    protected void btnok_Click(object sender, EventArgs e)
    {
        PT_ID = XYECOM.Core.MyConvert.GetInt64(XYECOM.Core.XYRequest.GetQueryString("pt_id"));
        ename = XYECOM.Core.XYRequest.GetQueryString("ename");


        if (this.tbName.Text == "")
        {
            Alert("�������Ʋ���Ϊ�գ�");
            return;
        }
        type = XYECOM.Core.XYRequest.GetQueryString("type");

        //�ж�����ӱ��滹�Ǳ༭����
        if (type.Equals("0") || XYECOM.Core.XYRequest.GetQueryString("pt_id").Equals("0"))
        {

            string TypeName = tbName.Text.Trim().Replace("��", ",");

            string[] arr = TypeName.Split(',');

            for (int i = 0; i < arr.Length; i++)
            {
                InsertData(arr[i].Trim());

                if (error) continue;
            }

            if (!error)
                Response.Redirect("Typelist.aspx?ename=" + ename + "&orderid=" + PT_ID + "&add=1");
        }

        if (type.Equals("1"))
        {
            int err = 0;

            if (ename.Equals("job") || ename.Equals("exhibition"))
            {
                if (ename.Equals("job"))
                {
                    postinfo = post.GetItem((int)PT_ID);
                    postinfo.P_Name = this.tbName.Text.Trim();

                    err = post.Update(postinfo);
                }
                if (ename.Equals("exhibition"))
                {
                    showinfo = showtype.GetItem(PT_ID);
                    showinfo.SHT_Name = this.tbName.Text.Trim();

                    err = showtype.Update(showinfo);
                }
            }
            else
            {
                if (ename.Equals("investment") || XYECOM.Configuration.Module.Instance.GetItem(ename).PEName.Equals("investment"))
                {
                    iti = it.GetItem(PT_ID);
                    iti.IT_Name = this.tbName.Text.Trim();

                    err = it.Update(iti);
                }
                if (ename.Equals("service") || XYECOM.Configuration.Module.Instance.GetItem(ename).PEName.Equals("service"))
                {
                    sti = st.GetItem(PT_ID);
                    sti.ST_Name = this.tbName.Text.Trim();

                    err = st.Update(sti);
                }
            }
            if (err > 0)
            {
                Response.Redirect("Typelist.aspx?ename=" + ename + "&orderid=" + PT_ID);
            }
            else
            {
                Alert("�޸�ʧ�ܣ�", backUrl + "?orderid=" + pt_id + "&ename=" + XYECOM.Core.XYRequest.GetQueryString("ename"));
            }
        }

    }
    #endregion

    #region ��ȡ������������
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

    #region ����
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



    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("Typelist.aspx?ename=" + XYECOM.Core.XYRequest.GetQueryString("ename") + "&orderid=" + XYECOM.Core.XYRequest.GetQueryInt64("PT_ID"));
    }
}
