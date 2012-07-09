//------------------------------------------------------------------------------
//
// file name：XY_CreditLeavlAccessor.cs
// author: wangzhen
// create date：2011-5-31 12:06:00
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
    /// Data accessor of CreditLeavlAccess
    /// </summary>
    public partial class CreditLeavlAccess
    {
        public Model.CreditLeavlInfo GetLastItem()
        {
            XYECOM.Model.CreditLeavlInfo info = null;

            string sql = "select top 1 * from XY_CreditLeavl order by leavl Desc";
            using (SqlDataReader reader = SqlHelper.ExecuteReader(CommandType.Text, sql))
            {
                if (reader.Read())
                {
                    info = new XYECOM.Model.CreditLeavlInfo();
                    info.Id = Core.MyConvert.GetInt32(reader["Id"].ToString());
                    info.LeavlName = reader["LeavlName"].ToString();
                    info.Leavl = Core.MyConvert.GetInt32(reader["Leavl"].ToString());
                    info.UpPoint = Core.MyConvert.GetInt32(reader["UpPoint"].ToString());
                    info.DownPoint = Core.MyConvert.GetInt32(reader["DownPoint"].ToString());
                    info.ImagePath = reader["ImagePath"].ToString();
                }
            }
            return info;
        }



        public Model.CreditLeavlInfo GetItemByPoint(decimal points)
        {
            XYECOM.Model.CreditLeavlInfo info = null;

            string sql = "select top 1 * from XY_CreditLeavl where (DownPoint<= " + points + " and (UpPoint>=" + points + " or UpPoint=-1))";

            using (SqlDataReader reader = SqlHelper.ExecuteReader(CommandType.Text, sql))
            {
                if (reader.Read())
                {
                    info = new XYECOM.Model.CreditLeavlInfo();
                    info.Id = Core.MyConvert.GetInt32(reader["Id"].ToString());
                    info.LeavlName = reader["LeavlName"].ToString();
                    info.Leavl = Core.MyConvert.GetInt32(reader["Leavl"].ToString());
                    info.UpPoint = Core.MyConvert.GetInt32(reader["UpPoint"].ToString());
                    info.DownPoint = Core.MyConvert.GetInt32(reader["DownPoint"].ToString());
                    info.ImagePath = reader["ImagePath"].ToString();
                }
            }
            return info;
        }

        public int AddCreditIntegral(int userId, decimal increa)
        {
            string sql = string.Empty;
            if (increa < 0)
            {
                sql = "update u_User set CreditIntegral=CreditIntegral-" + (-1 * increa) + " where U_ID=" + userId;
            }
            else
            {
                sql = "update u_User set CreditIntegral=CreditIntegral+" + increa + " where U_ID=" + userId;
            }

            return SqlHelper.ExecuteNonQuery(sql);
        }
    }
}
