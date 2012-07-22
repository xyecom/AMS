using System;
using System.Collections.Generic;
using System.Web;

namespace XYECOM.Web.AppCode
{
    public class Utitl
    {
        public static object GetInfoCount(string tblName, string strWhere)
        {
            string sqlFmt = "select Count(1) from {0} where {1}";

            string sql = string.Format(sqlFmt, tblName, strWhere);

            return XYECOM.Core.Data.SqlHelper.ExecuteScalar(sql);
        }
    }
}