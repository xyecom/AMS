using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Data.SqlClient;
using XYECOM.Core.Data;
using XYECOM.Core;
using XYECOM.Model.AMS;

namespace XYECOM.SQLServer.AMS
{
    public class ForeclosedAccess
    {
        public int InsertForeclosed(ForeclosedInfo info)
        {
            string sql = @"insert into ForeclosedInfo (Title,IdentityNumber,Address,AreaId,EndDate,CreateDate,State,
                                    UserId,DepartmentId,LinePrice,description,ForeColseTypeName)
                                    values (@Title,@Identitynumber,@Address,@AreaId,@EndDate,@CreateDate,@State,@UserId,
                                    @DepartmentId,@LinePrice,@Description,@ForeColseTypeName)";
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@Title",info.Title),
                new SqlParameter("@Identitynumber",info.IdentityNumber),
                new SqlParameter("@Address",info.Address),
                new SqlParameter("@AreaId",info.AreaId==0?null:info.AreaId),
                new SqlParameter("@EndDate",info.EndDate),
                new SqlParameter("@CreateDate",info.CreateDate),
                new SqlParameter("@State",info.State),
                new SqlParameter("@UserId",info.UserId==0?null:info.UserId),
                new SqlParameter("@DepartmentId",info.DepartmentId==0?null:info.DepartmentId),
                new SqlParameter("@LinePrice",info.LinePrice),
                new SqlParameter("@Description",info.Description),
                new SqlParameter("@ForeColseTypeName",info.ForeColseTypeName)
            };
            int rowAffected = SqlHelper.ExecuteNonQuery(CommandType.Text, sql, param);
            return rowAffected;
        }
    }
}
