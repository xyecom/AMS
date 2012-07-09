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
using XYECOM.Core;
using XYECOM.Business;

public partial class xymanage_FriendLink_FriendLinkTypeAdd : XYECOM.Web.BasePage.ManagePage
{
    #region 页面加载事件
    /// <summary>
    /// 页面加载事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        CheckRole("friendlink");

        btnback.Attributes.Add("onclick", "location='FriendLinkList.aspx'");

        if (!IsPostBack)
        {            
            PostType();
            this.btadd.Attributes.Add("onclick", "javascript:return Input();");
        }
    }
    #endregion

    #region 判断加载类别方法
    /// <summary>
    /// 判断加载类别方法
    /// </summary>
    private void PostType()
    {
        XYECOM.Business.FriendLinkSort flk = new XYECOM.Business.FriendLinkSort();

        if (XYECOM.Core.XYRequest.GetQueryString("FS_ID") != "")
        {
            BindData(int.Parse(XYECOM.Core.XYRequest.GetQueryString("FS_ID")));
        }
    }
    #endregion

    #region 如果类型是修改，则定义数据绑定事件
    /// <summary>
    /// 定义修改信息时的数据绑定事件
    /// </summary>
    /// <param name="id"></param>
    protected void BindData(int id)
    {
        string strWhere = "where FS_ID=" + id;
        XYECOM.Business.FriendLinkSort fl = new XYECOM.Business.FriendLinkSort();
        DataTable dt = fl.GetDataTable(strWhere, "");

        if (dt.Rows.Count > 0)
        {
            this.tbfltypename.Text = dt.Rows[0]["FS_Name"].ToString();
            this.tbfltypealt.Text = dt.Rows[0]["FS_Alt"].ToString();
        }
    }
    #endregion

    #region 定义单击添加按钮事件
    /// <summary>
    /// 定义单击添加按钮事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btadd_Click(object sender, EventArgs e)
    {
        int fsid = 0;
        int rowAff = 0;
        XYECOM.Model.FriendLinkSortInfo fs = new XYECOM.Model.FriendLinkSortInfo();
        XYECOM.Business.FriendLinkSort flk = new XYECOM.Business.FriendLinkSort();
        fs.FS_Name = this.tbfltypename.Text;
        fs.FS_Alt = this.tbfltypealt.Text;


        if (Request.QueryString["Type"] != null)
        {
            if (int.Parse(Request.QueryString["Type"]) == 0)
            {
                fs.FS_PID = 0;
                rowAff = flk.Insert(fs, out fsid);
                if (rowAff >= 0)
                {
                    Alert("添加友情链接分类成功！", "FriendLinkList.aspx?FS_PID=" + fs.FS_PID, true);
                }
                else if (rowAff == -2)
                {
                    Alert("添加友情链接分类添加失败！", "FriendLinkList.aspx?FS_PID=" + fs.FS_PID, true);
                }
                else if (rowAff == -1)
                {
                    Alert("该友情链接分类名称已经存在,请重新输入！");
                }
            }
            else
            {
                fs.FS_ID = int.Parse(Request.QueryString["FS_ID"].ToString());
                fs.FS_PID = 0;
                rowAff = flk.Update(fs);
                if (rowAff >= 0)
                {
                    Alert("修改友情链接分类成功！", "FriendLinkList.aspx?FS_PID=0", true);
                }
                else
                {
                    Alert("修改友情链接分类失败,可选择重新操作！", "FriendLinkList.aspx", true);
                }
            }
        }
        else
        {
            fs.FS_PID = 0;
            rowAff = flk.Insert(fs, out fsid);
            if (rowAff >= 0)
            {
                Alert("添加友情链分类成功！","FriendLinkList.aspx",true);
            }
            else if (rowAff == -2)
            {
                Alert("添加友情链接分类失败！", "FriendLinkList.aspx", true);
            }
            else if (rowAff == -1)
            {
                Alert("该友情链接分类名称已经存在,请重新输入！");
            }
        }
    }
    #endregion
}
