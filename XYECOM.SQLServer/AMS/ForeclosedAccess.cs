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
    /// <summary>
    /// 抵债数据访问层
    /// </summary>
    public class ForeclosedAccess
    {
        /// <summary>
        /// 新增抵债信息
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public int InsertForeclosed(ForeclosedInfo info)
        {
            string sql = @"insert into ForeclosedInfo (Title,IdentityNumber,Address,AreaId,EndDate,CreateDate,State,
                                    UserId,DepartmentId,LinePrice,description,ForeColseTypeName,HighPrice)
                                    values (@Title,@Identitynumber,@Address,@AreaId,@EndDate,@CreateDate,@State,@UserId,
                                    @DepartmentId,@LinePrice,@Description,@ForeColseTypeName,0)";
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@Title",info.Title),
                new SqlParameter("@Identitynumber",info.IdentityNumber),
                new SqlParameter("@Address",info.Address),
                new SqlParameter("@AreaId",info.AreaId),
                new SqlParameter("@EndDate",info.EndDate),
                new SqlParameter("@CreateDate",info.CreateDate),
                new SqlParameter("@State",info.State),
                new SqlParameter("@UserId",info.UserId),
                new SqlParameter("@DepartmentId",info.DepartmentId),
                new SqlParameter("@LinePrice",info.LinePrice),
                new SqlParameter("@Description",info.Description),
                new SqlParameter("@ForeColseTypeName",info.ForeColseTypeName)
            };
            int rowAffected = SqlHelper.ExecuteNonQuery(CommandType.Text, sql, param);
            return rowAffected;
        }
    }
}
