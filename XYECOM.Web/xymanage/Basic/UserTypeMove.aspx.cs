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
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Web.xymanage.Basic
{
    public partial class UserTypeMove : XYECOM.Web.BasePage.ManagePage
    {
        private const string Img1 = "<img src=\"../images/bg_shrink.gif\" />";
        private const string Img2 = "<img src=\"../images/bg_spread.gif\" />";
        String pt_parentID = "";
        long id = 0;
        protected void Page_Load(object sender, EventArgs e) 
        {
            CheckRole("userType");

            BindClassList("company");

            pt_parentID = XYECOM.Core.XYRequest.GetQueryString("PT_ParentID");
            id = XYECOM.Core.MyConvert.GetInt64(this.hidptid.Value);

            this.Label1.Text = "企业分类 > "+ GetTypeAllName("company", XYECOM.Core.MyConvert.GetInt64(pt_parentID));

            if (this.rbttype.Checked)
            {

                if (id > 0)
                {
                    Move(XYECOM.Core.MyConvert.GetInt64(pt_parentID), "0");
                }
            }
            if (this.rbtdata.Checked)
            {
                MoveData(pt_parentID, id.ToString());
            }
        }

        #region  设置为父级分类
        protected void btnok_Click(object sender, EventArgs e)
        {
            Move(XYECOM.Core.MyConvert.GetInt64(pt_parentID), "1");
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

        #region 分类转移
        /// <summary>
        /// 对分类进行转移
        /// </summary>
        /// <param name="ename">模块名称</param>
        /// <param name="pt_parentID">分类ID</param>
        /// <param name="flag">flag:0 将转移到子类 flag:1 设置为父类</param>
        private void Move(long pt_parentID, String flag)
        {
            int err = 0;

            XYECOM.Business.UserType ut = new XYECOM.Business.UserType();
            XYECOM.Model.UserTypeInfo info = new XYECOM.Model.UserTypeInfo();
            XYECOM.Model.UserTypeInfo typeinfo = new XYECOM.Model.UserTypeInfo();

            typeinfo = ut.GetItem(pt_parentID);
            info.UT_ID = typeinfo.UT_ID;
            info.UT_Type = typeinfo.UT_Type;

            if (id.Equals(pt_parentID))
            {
                info.UT_PID = typeinfo.UT_PID;
            }
            else
            {
                info.UT_PID = Convert.ToInt32(id);
            }
            if (flag.Equals("1"))
            {
                info.UT_PID = 0;
            }
            err = ut.Update(info);

            if (err > 0)
            {
                Response.Redirect("UserTypelist.aspx");
            }
            else
            {
                this.lblMessage.Text = "转移失败！";
            }

        }
        #endregion

        #region 转移数据
        /// <summary>
        /// 转移数据
        /// </summary>
        /// <param name="modulename">模块名称</param>
        /// <param name="oldid">要找信息的分类ID</param>
        /// <param name="newid">更新为新分类的ID</param>
        private void MoveData(String oldid, String newid)
        {
            //表名
            String tablename = "";
            //更新的字段名称
            String flagname = "";
            //信息ID名称
            String infoname = "";
            int result = 0;
            XYECOM.Business.XYClass xy = new XYECOM.Business.XYClass();

            tablename = "u_userinfo";
            flagname = "UT_ID";
            infoname = "U_ID";
            result = xy.UpdatesByID(tablename, flagname, infoname, oldid, newid);

           
            if (result > 0)
            {
                Response.Redirect("UserTypelist.aspx?");
            }
            else
            {
                this.lblMessage.Text = "转移数据失败！";
            }
        }
        #endregion
    }
}
