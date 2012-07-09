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
using System.Net;
using System.IO;
using XYECOM.Business;
using XYECOM.Core;

public partial class xymanage_FriendLink_AddNewLink : XYECOM.Web.BasePage.ManagePage
{
	short sid;
    XYECOM.Business.Attachment Attm = new XYECOM.Business.Attachment();

    #region 页面加载事件
    protected void Page_Load(object sender, EventArgs e) 
	{
        HttpContext.Current.Response.Buffer = true;
        HttpContext.Current.Response.ExpiresAbsolute = System.DateTime.Now.AddSeconds(-1);
        HttpContext.Current.Response.Expires = 0;
		//根据选择类型显示所要输入的值
        CheckRole("friendlink");

		if (!IsPostBack) 
		{       
            flsortid.DataSource = new XYECOM.Business.FriendLinkSort().GetDataTable("where FS_PID=0", "");
            flsortid.DataTextField = "FS_Name";
            flsortid.DataValueField = "FS_ID";
            flsortid.DataBind();
            
            this.imagetype.Value = webInfo.UploadFileType.ToString();

            this.rbtext.Checked = true;
            if (Request.QueryString["id"] != null)
            {
                //如果为修改，则初始化上传文件
                UploadFile1.InfoID = MyConvert.GetInt64(XYRequest.GetQueryString("id"));
                BindData(int.Parse(Request.QueryString["id"].ToString()));
            }
			this.rbtext.Attributes.Add("onclick", "javascript:return TypeChange(1)");
			this.rbpic.Attributes.Add("onclick", "javascript:return TypeChange(2)");
			this.rbpicurl.Attributes.Add("onclick", "javascript:return TypeChange(3)");
			this.rbpicupload.Attributes.Add("onclick", "javascript:return TypeChange(4)");
			this.btnAdd.Attributes.Add("onclick", "javascript:return Input();");
		}
    }
    #endregion

    #region 对需要编辑的友情链接进行绑定
    private void BindData(int flid)
    {
        string strWhere = "where FL_ID=" + flid;
        XYECOM.Business.FriendLink fl = new XYECOM.Business.FriendLink();
        XYECOM.Business.FriendLinkSort fls = new XYECOM.Business.FriendLinkSort();
        DataTable dt = fl.GetDataTable(strWhere, "");
        if (dt.Rows.Count > 0)
        {
            if (Convert.ToBoolean(dt.Rows[0]["FL_Type"]) == false)
            {
                this.rbtext.Checked = true;
                this.tblinkfont.Text = dt.Rows[0]["FL_Font"].ToString();
            }
            else
            {
                this.rbpic.Checked = true;
                if (dt.Rows[0]["Fl_Font"].ToString() != "Image")
                {
                    this.rbpicurl.Checked = true;
                    this.tbpicaddress.Text = dt.Rows[0]["FL_Font"].ToString();
                    
                }
                else
                {
                    this.rbpicupload.Checked = true;            
                }
            }

           
            this.tblinkrul.Text = dt.Rows[0]["FL_URL"].ToString();
            this.tblinkalt.Text = dt.Rows[0]["FL_Alt"].ToString();

            this.flsortid.Text = dt.Rows[0]["FS_ID"].ToString(); 
        }

    }
    #endregion

    #region 单击添加按钮事件
    /// <summary>
     /// 添加或修改友情链接
     /// </summary>
     /// <param name="sender"></param>
     /// <param name="e"></param>
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        XYECOM.Model.FriendLinkInfo MyLink = new XYECOM.Model.FriendLinkInfo();
        XYECOM.Business.FriendLink fl = new XYECOM.Business.FriendLink();

        if (this.rbtext.Checked == true)
        {
            MyLink.FL_Type = false;
            MyLink.FL_Font = this.tblinkfont.Text.Trim();
            MyLink.FL_URL = this.tblinkrul.Text.Trim();
            MyLink.FL_Alt = this.tblinkalt.Text.Trim();
            MyLink.FL_Flag = true;
            MyLink.FS_ID = int.Parse(this.flsortid.Text.ToString());

            if (Request.QueryString["id"] != null)
            {
                MyLink.FL_ID = Convert.ToInt16(Request.QueryString["id"]);
                int a = fl.Update(MyLink);
                if (a > -1)
                {
                   // this.ClientScript.RegisterClientScriptBlock(GetType(), "", "<script>alertmsg(\"修改文字链接成功.\",\"List.aspx\")</script>");
                    this.Response.Redirect("List.aspx?" + XYECOM.Core.XYRequest.GetQueryString("backURL"));
                }
                else
                {
                    Alert("修改文字链接失败,可以进行重新操作.", "List.aspx");
                }
            }
            else
            {
                int a = fl.Insert(MyLink, out sid);
                if (a > -1)
                {
                    //this.ClientScript.RegisterClientScriptBlock(GetType(), "", "<script>alertmsg(\"添加文字链接成功.\",\"List.aspx\")</script>");
                    this.Response.Redirect("List.aspx?" + XYECOM.Core.XYRequest.GetQueryString("backURL"));
                }
                else
                {
                    Alert("添加文字链接失败,可以进行重新操作","List.aspx");
                }
            }
        }
        else if (this.rbpic.Checked == true)
        {
            MyLink.FL_Type = true;
            MyLink.FL_URL = this.tblinkrul.Text.Trim();
            MyLink.FL_Alt = this.tblinkalt.Text.Trim();
            MyLink.FL_Flag = true;
            MyLink.FS_ID = int.Parse(this.flsortid.Text.ToString());

            if (this.rbpicurl.Checked == true)
            {
                MyLink.FL_Font = this.tbpicaddress.Text.Trim();
                int b = 0;
                if (Request.QueryString["id"] != null)
                {
                    MyLink.FL_ID = Convert.ToInt16(Request.QueryString["id"].ToString());
                    b = fl.Update(MyLink);
                    if (b > -1)
                    {
                       // this.ClientScript.RegisterClientScriptBlock(GetType(), "", "<script>alertmsg(\"图片友情链接修改成功.\",\"List.aspx\")</script>");
                        this.Response.Redirect("List.aspx?" + XYECOM.Core.XYRequest.GetQueryString("backURL"));
                       
                    }
                    else
                    {
                        Alert("图片友情链接修改失败.","List.aspx");
                    }
                }
                else
                {
                    b = fl.Insert(MyLink, out sid);
                    if (b > -1)
                    {
                        //this.ClientScript.RegisterClientScriptBlock(GetType(), "", "<script>alertmsg(\"图片友情链接添加成功.\",\"List.aspx\")</script>");
                        this.Response.Redirect("List.aspx?" + XYECOM.Core.XYRequest.GetQueryString("backURL"));
                    }
                    else
                    {
                        Alert("图片友情链接添加失败.", "List.aspx");
                    }
                }
            }
            else if (this.rbpicupload.Checked == true)
            {
                MyLink.FL_Font = "Image";
                int b = 0;
                if (Request.QueryString["id"] != null)
                {
                    MyLink.FL_ID = Convert.ToInt16(Request.QueryString["id"].ToString());
                    b = fl.Update(MyLink);
                    UploadFile1.InfoID = MyLink.FL_ID;
                    UploadFile1.Update();
                    if (b > -1)
                    {
                        //this.ClientScript.RegisterClientScriptBlock(GetType(), "", "<script>alertmsg(\"图片友情链接修改成功.\",\"List.aspx\")</script>");
                        this.Response.Redirect("List.aspx?" + XYECOM.Core.XYRequest.GetQueryString("backURL"));
                    }
                    else
                    {
                        Alert("图片友情链接修改失败.", "List.aspx");
                    }
                }
                else
                {
                    b = fl.Insert(MyLink, out sid);
                    UploadFile1.InfoID = sid;
                    UploadFile1.Update();
                    if (b > -1)
                    {
                        //this.ClientScript.RegisterClientScriptBlock(GetType(), "", "<script>alertmsg(\"图片友情链接添加成功.\",\"List.aspx\")</script>");
                        this.Response.Redirect("List.aspx?" + XYECOM.Core.XYRequest.GetQueryString("backURL"));
                    }
                    else
                    {
                        Alert("图片友情链接添加失败.", "List.aspx");
                    }
                }
            }
        }
    }
    #endregion

    #region 点击返回
    protected void btcancel_ServerClick(object sender, EventArgs e)
    {
        if (XYECOM.Core.XYRequest.GetQueryString("backURL") != "")
            this.Response.Redirect("List.aspx?" + XYECOM.Core.XYRequest.GetQueryString("backURL"));
        else
            this.Response.Redirect("List.aspx");
    }
    #endregion
}
