using System;
using System.Collections.Generic;
using System.Web;

namespace XYECOM.Web.AppCode.UserCenter
{
    public class Creditor : XYECOM.Page.UserCenter
    {
        protected override void OnLoad(EventArgs e)
        {
            if (userinfo == null)
            {
                Response.Redirect("/login.aspx");
                return;
            }
            switch (userinfo.UserType)
            {
                case XYECOM.Model.UserType.CreditorEnterprise:
                case XYECOM.Model.UserType.CreditorIndividual:
                    //nothing
                    break;
                case XYECOM.Model.UserType.Layer:
                case XYECOM.Model.UserType.NotLayer:
                default:
                    Response.Redirect("/Server/Index.aspx");
                    return;
            }

            base.OnLoad(e);
        }

        protected string ToStateName(string state, bool flag)
        {
            int staus = Core.MyConvert.GetInt32(state);

            Model.AuditingState aus = (Model.AuditingState)staus;

            string result = string.Empty;
            switch (aus)
            {
                case XYECOM.Model.AuditingState.NoPass:
                    if (flag)
                    {
                        result = "已禁用";
                    }
                    else 
                    {
                        result = "启用";
                    }
                    break;
                default:
                    if (flag)
                    {
                        result = "启用中";
                    }
                    else 
                    {
                        result = "禁用";
                    }
                    break;
            }

            return result;
        }
    }
}