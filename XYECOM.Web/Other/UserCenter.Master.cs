﻿using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace XYECOM.Web.Other
{
    public partial class UserCenter : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack && XYECOM.Business.CheckUser.CheckUserLogin())
            {
                this.lblUserName.Text = XYECOM.Business.CheckUser.UserInfo.LoginName;
            }
        }
    }
}