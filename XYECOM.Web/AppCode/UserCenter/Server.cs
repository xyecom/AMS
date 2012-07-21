using System;
using System.Collections.Generic;
using System.Web;

namespace XYECOM.Web.AppCode.UserCenter
{
    public class Server : XYECOM.Page.UserCenter
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
                case XYECOM.Model.UserType.Layer:
                case XYECOM.Model.UserType.NotLayer:
                    //nothing
                    break;
                case XYECOM.Model.UserType.CreditorEnterprise:
                case XYECOM.Model.UserType.CreditorIndividual:
                default:
                    Response.Redirect("/Creditor/Index.aspx");
                    return;
            }

            base.OnLoad(e);
        }
    }
}