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
using System.Text;
using System.Collections.Generic;
using XYECOM.Business;

namespace XYECOM.Web.xymanage.Basic
{
    public partial class ProductMove : XYECOM.Web.BasePage.ManagePage
    {
        private const string Img1 = "<img src=\"../images/bg_shrink.gif\" />";
        private const string Img2 = "<img src=\"../images/bg_spread.gif\" />";

        String ename = "";

        String modeTypeId = "";

        long toTypeId = 0;

        XYECOM.Business.ProductType proTypeBLL = new XYECOM.Business.ProductType();
        XYECOM.Model.ProductTypeInfo proTypeInfo = new XYECOM.Model.ProductTypeInfo();
        
        XYECOM.Business.InviteBusinessType it = new XYECOM.Business.InviteBusinessType();
        XYECOM.Model.InviteBusinessTypeInfo iti = new XYECOM.Model.InviteBusinessTypeInfo();

        XYECOM.Business.ServiceType st = new XYECOM.Business.ServiceType();
        XYECOM.Model.ServiceTypeInfo sti = new XYECOM.Model.ServiceTypeInfo();

        XYECOM.Business.ShowType showtype = new XYECOM.Business.ShowType();
        XYECOM.Model.ShowTypeInfo showinfo = new XYECOM.Model.ShowTypeInfo();

        XYECOM.Business.Post post = new Post();
        XYECOM.Model.PostInfo postinfo = new XYECOM.Model.PostInfo();

        protected void Page_Load(object sender, EventArgs e)
        {
            CheckRole("typemanage");

            ename = XYECOM.Core.XYRequest.GetQueryString("ename");

            modeTypeId = XYECOM.Core.XYRequest.GetQueryString("PT_ParentID");

            if (ename != "")
            {
                BindClassList(ename);
            }
            else
            {
                BindClassList("offer");
            }

            toTypeId = XYECOM.Core.MyConvert.GetInt64(this.hidptid.Value);

            if (this.rbttype.Checked)
            {
                if (toTypeId > 0)
                {
                    Move(ename, XYECOM.Core.MyConvert.GetInt64(modeTypeId), "0");
                }
            }

            if (this.rbtdata.Checked)
            {
                MoveData(ename, modeTypeId, toTypeId.ToString());
            }

            if (ename.Equals("brand") || ename.Equals("job") || ename.Equals("exhibition"))
            {
                if (ename.Equals("brand"))
                {
                    this.Label1.Text = "品牌分类 > " + GetTypeAllName(ename, XYECOM.Core.MyConvert.GetInt64(modeTypeId));
                }

                if (ename.Equals("job"))
                {
                    this.Label1.Text = "招聘岗位 > " + GetTypeAllName(ename, XYECOM.Core.MyConvert.GetInt64(modeTypeId));
                }

                if (ename.Equals("exhibition"))
                {
                    this.Label1.Text = "展会分类 > " + GetTypeAllName(ename, XYECOM.Core.MyConvert.GetInt64(modeTypeId));
                }
            }
            else
            {
                this.Label1.Text = XYECOM.Configuration.Module.Instance.GetItem(ename).CName + " > "
                                + GetTypeAllName(ename, XYECOM.Core.MyConvert.GetInt64(modeTypeId));
            }
        }


        #region 分类转移
        /// <summary>
        /// 对分类进行转移
        /// </summary>
        /// <param name="ename">模块名称</param>
        /// <param name="pt_parentID">分类ID</param>
        /// <param name="flag">flag:0 将转移到子类 flag:1 设置为父类</param>
        private void Move(String ename, long lngMoveTypeId, String flag)
        {
            int err = 0;

            if (ename.Equals("job") || ename.Equals("exhibition"))
            {
                if (ename.Equals("job"))
                {
                    postinfo = post.GetItem(Convert.ToInt32(lngMoveTypeId));
                    XYECOM.Model.PostInfo info = new XYECOM.Model.PostInfo();
                    info.P_ID = postinfo.P_ID;
                    info.P_Name = postinfo.P_Name;
                    if (toTypeId.Equals(lngMoveTypeId))
                    {
                        info.P_ParentID = postinfo.P_ParentID;
                    }
                    else
                    {
                        info.P_ParentID = Convert.ToInt32(toTypeId);
                    }
                    if (flag.Equals("1"))
                    {
                        info.P_ParentID = 0;
                    }
                    err = post.Update(info);
                }
                if (ename.Equals("exhibition"))
                {
                    showinfo = showtype.GetItem(lngMoveTypeId);
                    XYECOM.Model.ShowTypeInfo info = new XYECOM.Model.ShowTypeInfo();
                    info.SHT_Name = showinfo.SHT_Name;

                    if (toTypeId.Equals(lngMoveTypeId))
                    {
                        info.SHT_ParentID = showinfo.SHT_ParentID;
                    }
                    else
                    {
                        info.SHT_ParentID = toTypeId;
                    }
                    if (flag.Equals("1"))
                    {
                        info.SHT_ParentID = 0;
                    }
                    info.SHT_ID = showinfo.SHT_ID;
                    err = showtype.Update(info);
                }
            }
            else
            {
                if (ename.Equals("offer") || XYECOM.Configuration.Module.Instance.GetItem(ename).PEName.Equals("offer"))
                {
                    proTypeInfo = proTypeBLL.GetItem(lngMoveTypeId);

                    if (flag.Equals("1"))
                    {
                        proTypeInfo.PT_ParentID = 0;
                    }
                    else
                    {
                        if (toTypeId != lngMoveTypeId)
                        {
                            Model.ProductTypeInfo _tempInfo = proTypeBLL.GetItem(toTypeId);

                            if (_tempInfo != null) proTypeInfo.TradeId = _tempInfo.TradeId;

                            proTypeInfo.PT_ParentID = toTypeId;
                        }
                    }

                    err = proTypeBLL.Update(proTypeInfo);

                }
                
                if (ename.Equals("investment") || XYECOM.Configuration.Module.Instance.GetItem(ename).PEName.Equals("investment"))
                {
                    iti = it.GetItem(lngMoveTypeId);
                    XYECOM.Model.InviteBusinessTypeInfo info = new XYECOM.Model.InviteBusinessTypeInfo();
                    info.IT_Name = iti.IT_Name;

                    if (toTypeId.Equals(lngMoveTypeId))
                    {
                        info.IT_ParentID = iti.IT_ParentID;
                    }
                    else
                    {
                        info.IT_ParentID = toTypeId;
                    }
                    if (flag.Equals("1"))
                    {
                        info.IT_ParentID = 0;
                    }
                    info.ModuleName = iti.ModuleName;
                    info.IT_ID = iti.IT_ID;
                    err = it.Update(info);
                }
                if (ename.Equals("service") || XYECOM.Configuration.Module.Instance.GetItem(ename).PEName.Equals("service"))
                {
                    sti = st.GetItem(lngMoveTypeId);
                    XYECOM.Model.ServiceTypeInfo info = new XYECOM.Model.ServiceTypeInfo();
                    info.ST_Name = sti.ST_Name;

                    if (toTypeId.Equals(lngMoveTypeId))
                    {
                        info.ST_ParentID = sti.ST_ParentID;
                    }
                    else
                    {
                        info.ST_ParentID = toTypeId;
                    }
                    if (flag.Equals("1"))
                    {
                        info.ST_ParentID = 0;
                    }
                    info.ModuleName = sti.ModuleName;
                    info.ST_ID = sti.ST_ID;
                    err = st.Update(info);
                }
            }

            if (err > 0)
            {
                Response.Redirect("Typelist.aspx?ename=" + ename + "&orderid=" + lngMoveTypeId);
            }
            else
            {
                this.lblMessage.Text = "转移失败！";
            }

        }
        #endregion

        #region 绑定分类相关
        private void BindClassList(string moduleName)
        {
            List<Model.XYClassInfo> infos = Business.XYClass.GetItemsAll(moduleName);

            this.pnlSuperClass.Controls.Add(new LiteralControl("<ul>"));
            foreach (Model.XYClassInfo info in infos)
            {
                AddInfoHtml(info, "0", "");
                if (info.HasSub)
                {
                    AddChild(info, "&nbsp;&nbsp;&nbsp;&nbsp;");
                }
            }
            this.pnlSuperClass.Controls.Add(new LiteralControl("</ul>"));
        }

        private void AddChild(Model.XYClassInfo info, string str)
        {
            this.pnlSuperClass.Controls.Add(new LiteralControl("<li id=\"li_" + info.ClassId + "\" style=\"display:none;\"><ul>"));
            foreach (Model.XYClassInfo info2 in info.childList)
            {
                AddInfoHtml(info2, info.ClassId.ToString(), str);
                if (info2.HasSub)
                {
                    AddChild(info2, str + "&nbsp;&nbsp;&nbsp;&nbsp;");
                }
            }
            this.pnlSuperClass.Controls.Add(new LiteralControl("</ul></li>"));
        }

        private void AddInfoHtml(Model.XYClassInfo info, string parentID, string str)
        {
            StringBuilder strhtml = new StringBuilder();
            strhtml.AppendLine("<li id=\"lithis" + info.ClassId + "\">");
            strhtml.AppendLine(str);
            //strhtml.AppendLine("<input id=\"input_" + parentID + "_" + info.ClassId + "\" type=\"checkbox\" value=\"" + info.ClassId + "\"/>");
            strhtml.AppendLine("<input id=\"input_" + parentID + "_" + info.ClassId + "\" type=\"radio\" name=\"RadioGroup\" value=\"" + info.ClassId + "\"/>");
            strhtml.AppendLine(info.HasSub ? "<a href=\"javascript:LabelClassDisplay('li_" + info.ClassId + "','lithis" + info.ClassId + "');\">" + Img1 + "</a>" : Img2);
            strhtml.AppendLine(info.ClassName);
            strhtml.AppendLine("</li>");
            this.pnlSuperClass.Controls.Add(new LiteralControl(strhtml.ToString()));
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

        #region  设置为父级分类
        protected void btnok_Click(object sender, EventArgs e)
        {
            Move(XYECOM.Core.XYRequest.GetQueryString("ename"), XYECOM.Core.MyConvert.GetInt64(modeTypeId), "1");
        }
        #endregion

        #region 转移数据
        /// <summary>
        /// 转移数据
        /// </summary>
        /// <param name="modulename">模块名称</param>
        /// <param name="oldid">要找信息的分类ID</param>
        /// <param name="newid">更新为新分类的ID</param>
        private void MoveData(String modulename, String oldid, String newid)
        {
            //表名
            String tablename = "";
            //更新的字段名称
            String flagname = "";
            //信息ID名称
            String infoname = "";
            int result = 0;
            XYECOM.Business.XYClass xy = new XYECOM.Business.XYClass();

            if (ename.Equals("job") || ename.Equals("exhibition"))
            {
                if (ename.Equals("job"))
                {
                    tablename = "i_engageinfo";
                    flagname = "P_ID";
                    infoname = "EI_ID";
                    result = xy.UpdatesByID(tablename, flagname, infoname, oldid, newid);
                }
                if (ename.Equals("exhibition"))
                {
                    tablename = "XY_showinfo";
                    flagname = "typeid";
                    infoname = "id";
                    result = xy.UpdatesByID(tablename, flagname, infoname, oldid, newid);
                }
            }
            else
            {
                if (ename.Equals("offer") || XYECOM.Configuration.Module.Instance.GetItem(ename).PEName.Equals("offer"))
                {
                    tablename = "i_supply";
                    flagname = "PT_ID";
                    infoname = "SD_ID";
                    result = xy.UpdatesByID(tablename, flagname, infoname, oldid, newid);
                }

                if (ename.Equals("investment") || XYECOM.Configuration.Module.Instance.GetItem(ename).PEName.Equals("investment"))
                {
                    tablename = "i_invitebusinessmaninfo";
                    flagname = "IT_ID";
                    infoname = "IBI_ID";
                    result = xy.UpdatesByID(tablename, flagname, infoname, oldid, newid);
                }
                if (ename.Equals("service") || XYECOM.Configuration.Module.Instance.GetItem(ename).PEName.Equals("service"))
                {
                    tablename = "i_serviceinfo";
                    flagname = "ST_ID";
                    infoname = "S_ID";
                    result = xy.UpdatesByID(tablename, flagname, infoname, oldid, newid);
                }
            }
            if (result > 0)
            {
                Alert("数据转移成功！", "Typelist.aspx?ename=" + ename + "&orderid=" + XYECOM.Core.XYRequest.GetQueryInt64("PT_ParentID"));
            }
            else
            {
                this.lblMessage.Text = "转移数据失败或指定分类下无数据可转移！";
            }
        }
        #endregion

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Typelist.aspx?orderid=" + XYECOM.Core.XYRequest.GetQueryInt64("PT_ParentID") + "&ename=" + XYECOM.Core.XYRequest.GetQueryString("ename"));
        }

    }
}
