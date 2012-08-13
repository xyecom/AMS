using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using XYECOM.Web.AppCode;

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

            LinkButton btn = sender as LinkButton;

            long uid = XYECOM.Core.MyConvert.GetInt64(btn.CommandArgument);

            //判断是否有 抵债或债权信息 判断是否有 档案信息            
            int caseCount = XYECOM.Core.MyConvert.GetInt32(Utitl.GetInfoCount("CaseInfo", "PartId=" + uid).ToString());
            int foreCount = XYECOM.Core.MyConvert.GetInt32(Utitl.GetInfoCount("ForeclosedInfo", "DepartmentId=" + uid).ToString());
            int creditCount = XYECOM.Core.MyConvert.GetInt32(Utitl.GetInfoCount("CreditInfo", "DepartId=" + uid).ToString());
            if (caseCount > 0 || foreCount > 0 || creditCount > 0)
            {
                GotoMsgBoxPageForDynamicPage("该部门下存在债权、抵债或档案信息，不能删除！", 2, "/Creditor/PartList.aspx");
                return;
            }

            XYECOM.Business.UserReg ur = new XYECOM.Business.UserReg();
            ur.Delete(uid.ToString());

            BindData();
        }
    }
}