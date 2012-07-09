//------------------------------------------------------------------------------
//
// file name：XY_BankAccountAccessor.cs
// author: wangzhen
// create date：2011-3-29 16:07:06
//
//------------------------------------------------------------------------------
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using XYECOM.Core.Data;

namespace XYECOM.SQLServer
{
    /// <summary>
    /// Data accessor of BankAccountAccess
    /// </summary>
    public partial class BankAccountAccess
    {
        public int UpdateAccountActive(int infoId, bool isActive)
        {
            string sql = "UPDATE XY_BankAccount SET IsActivation=" + (isActive ? "1" : "0") + " WHERE Id=" + infoId;
            return SqlHelper.ExecuteNonQuery(sql);
        }
    }
}
