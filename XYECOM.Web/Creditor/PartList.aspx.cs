using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace XYECOM.Web.Creditor
{
    public partial class PartList : XYECOM.Web.AppCode.UserCenter.Creditor
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!userinfo.IsPrimary)
            {
                GotoMsgBoxPageForDynamicPage("您无权查看部门列表", 1, "/Creditor/PartIndex.aspx");
            }
        }

        protected override void BindData()
        {
            XYECOM.Business.UserReg regBll = new Business.UserReg();
            DataTable table = regBll.GetPartList(userinfo.CompanyId);

            this.rptPartList.DataSource = table;
            this.rptPartList.DataBind();
        }

        protected void lbtnStatus_Click(object sender, EventArgs e)
        {
            XYECOM.Business.UserReg regBll = new Business.UserReg();

            LinkButton lbtn = sender as LinkButton;

            string ca = lbtn.CommandArgument;

            string[] ids = ca.Split(new char[] { '|' });

            regBll.UpdatePartState(ids[0], ids[1]);

            BindData();
        }
        protected void lbtnDel_Click(object sender, EventArgs e)
        {
            //先判断 该用户是否有档案信息及债权或抵债信息，若没有则删除，否则不能删除。


        }
    }
}