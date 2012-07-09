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

public partial class xymanage_basic_UserPopedom : XYECOM.Web.BasePage.ManagePage
{
    #region  
    protected void Page_Load(object sender, EventArgs e)
    {
        CheckRole("sysadmin");
        if (!Page.IsPostBack)
        {
            if (Request.QueryString["UR_ID"].ToString() != "")
            {
                UserPopedom up = new UserPopedom();

                DataTable dt = up.GetDataTable(Convert.ToInt32(Request.QueryString["UR_ID"].ToString()));

                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        for (int j = 0; j < this.cblbasic.Items.Count; j++)
                        {
                            if (this.cblbasic.Items[j].Value == dt.Rows[i]["P_TableName"].ToString())
                            {
                                if (dt.Rows[i]["P_IsPopedom"].ToString().ToLower() == "true")
                                {
                                    this.cblbasic.Items[j].Selected = true;
                                }
                                else
                                {
                                    this.cblbasic.Items[j].Selected = false;
                                }
                            }
                        }
                        for (int t = 0; t < this.cblbusiness.Items.Count; t++)
                        {
                            if (this.cblbusiness.Items[t].Value == dt.Rows[i]["P_TableName"].ToString())
                            {
                                if (dt.Rows[i]["P_IsPopedom"].ToString().ToLower() == "true")
                                {
                                    this.cblbusiness.Items[t].Selected = true;
                                }
                                else
                                {
                                    this.cblbusiness.Items[t].Selected = false;
                                }
                            }
                        }
                        for (int y = 0; y < this.cblnews.Items.Count; y++)
                        {
                            if (this.cblnews.Items[y].Value == dt.Rows[i]["P_TableName"].ToString())
                            {
                                if (dt.Rows[i]["P_IsPopedom"].ToString().ToLower() == "true")
                                {
                                    this.cblnews.Items[y].Selected = true;
                                }
                                else
                                {
                                    this.cblnews.Items[y].Selected = false;
                                }
                            }
                        }
                        for (int n = 0; n < this.cbluser.Items.Count; n++)
                        {
                            if (this.cbluser.Items[n].Value == dt.Rows[i]["P_TableName"].ToString())
                            {
                                if (dt.Rows[i]["P_IsPopedom"].ToString().ToLower() == "true")
                                {
                                    this.cbluser.Items[n].Selected = true;
                                }
                                else
                                {
                                    this.cbluser.Items[n].Selected = false;
                                }
                            }
                        }
                        for (int m = 0; m < this.cbllable.Items.Count; m++)
                        {
                            if (this.cbllable.Items[m].Value == dt.Rows[i]["P_TableName"].ToString())
                            {
                                if (dt.Rows[i]["P_IsPopedom"].ToString().ToLower() == "true")
                                {
                                    this.cbllable.Items[m].Selected = true;
                                }
                                else
                                {
                                    this.cbllable.Items[m].Selected = false;
                                }
                           }
                        }
                        for (int w = 0; w < this.cblsystem.Items.Count; w++)
                        {
                            if (this.cblsystem.Items[w].Value == dt.Rows[i]["P_TableName"].ToString())
                            {
                                if (dt.Rows[i]["P_IsPopedom"].ToString().ToLower() == "true")
                                {
                                    this.cblsystem.Items[w].Selected = true;
                                }
                                else
                                {
                                    this.cblsystem.Items[w].Selected = false;
                                }
                            }
                        }

                    }
                }
            }
        }
    }
    #endregion 

    #region 设置权限
    protected void Button1_Click1(object sender, EventArgs e)
    {

        XYECOM.Business.UserPopedom up = new XYECOM.Business.UserPopedom();
        XYECOM.Business.Log l = new XYECOM.Business.Log();
        XYECOM.Model.LogInfo el = new XYECOM.Model.LogInfo();
        int UR_ID = 0;
        if (Request.QueryString["UR_ID"].ToString() != "")
        {
            UR_ID = Convert.ToInt32(Request.QueryString["UR_ID"].ToString());
        }
        up.Delete(UR_ID);
        string sql = "";
        for (int j = 0; j < this.cblbasic.Items.Count; j++)
        {
            if (this.cblbasic.Items[j].Selected == true)
            {
                sql += "insert into b_PopedomSet(P_TableName,P_IsPopedom,UR_ID) values('" + this.cblbasic.Items[j].Value + "',1,'" + UR_ID + "')";
            }
            else
            {
                sql += "insert into b_PopedomSet(P_TableName,P_IsPopedom,UR_ID) values('" + this.cblbasic.Items[j].Value + "',0,'" + UR_ID + "')";
            }
        }
        for (int t = 0; t < this.cblbusiness.Items.Count; t++)
        {
            if (this.cblbusiness.Items[t].Selected == true)
            {
                sql += "insert into b_PopedomSet(P_TableName,P_IsPopedom,UR_ID) values('" + this.cblbusiness.Items[t].Value + "',1,'" + UR_ID + "')";
            }
            else
            {
                sql += "insert into b_PopedomSet(P_TableName,P_IsPopedom,UR_ID) values('" + this.cblbusiness.Items[t].Value + "',0,'" + UR_ID + "')";
            }
        }
        for (int y = 0; y < this.cblnews.Items.Count; y++)
        {
            if (this.cblnews.Items[y].Selected == true)
            {
                sql += "insert into b_PopedomSet(P_TableName,P_IsPopedom,UR_ID) values('" + this.cblnews.Items[y].Value + "',1,'" + UR_ID + "')";
            }
            else
            {
                sql += "insert into b_PopedomSet(P_TableName,P_IsPopedom,UR_ID) values('" + this.cblnews.Items[y].Value + "',0,'" + UR_ID + "')";
            }
        }
        for (int n = 0; n < this.cbluser.Items.Count; n++)
        {
            if (this.cbluser.Items[n].Selected == true)
            {
                sql += "insert into b_PopedomSet(P_TableName,P_IsPopedom,UR_ID) values('" + this.cbluser.Items[n].Value + "',1,'" + UR_ID + "')";
            }
            else
            {
                sql += "insert into b_PopedomSet(P_TableName,P_IsPopedom,UR_ID) values('" + this.cbluser.Items[n].Value + "',0,'" + UR_ID + "')";
            }
        }
        for (int m = 0; m < this.cbllable.Items.Count; m++)
        {
            if (this.cbllable.Items[m].Selected == true)
            {
                sql += "insert into b_PopedomSet(P_TableName,P_IsPopedom,UR_ID) values('" + this.cbllable.Items[m].Value + "',1,'" + UR_ID + "')";
            }
            else
            {
                sql += "insert into b_PopedomSet(P_TableName,P_IsPopedom,UR_ID) values('" + this.cbllable.Items[m].Value + "',0,'" + UR_ID + "')";
            }
        }
        for (int w = 0; w < this.cblsystem.Items.Count; w++)
        {
            if (this.cblsystem.Items[w].Selected == true)
            {
                sql += "insert into b_PopedomSet(P_TableName,P_IsPopedom,UR_ID) values('" + this.cblsystem.Items[w].Value + "',1,'" + UR_ID + "')";
            }
            else
            {
                sql += "insert into b_PopedomSet(P_TableName,P_IsPopedom,UR_ID) values('" + this.cblsystem.Items[w].Value + "',0,'" + UR_ID + "')";
            }
        }
        int i = 0;
        string url = "Role.aspx";
        i = XYECOM.Core.Data.SqlHelper.ExecuteNonQuery(sql);
        if (i >= 0)
        {
            el.L_Title = "权限管理";
            el.L_Content = "设置权限信息成功";
            el.L_MF = "系统信息设置";
            
            {
                el.UM_ID = AdminId;
            }
            l.Insert(el);
            Alert("设置成功！", url);
        }
        else
        {
            el.L_Title = "权限管理";
            el.L_Content = "设置权限信息失败";
            el.L_MF = "系统信息设置";
            
            {
                el.UM_ID = AdminId;
            }
            l.Insert(el);
            Alert("设置失败！", url);
        }
    }
     #endregion

    protected void Button2_Click1(object sender, EventArgs e)
    {
        this.Response.Redirect("Role.aspx");
    }
}
