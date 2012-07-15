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
                new SqlParameter("@UserId",info.CompanyId),
                new SqlParameter("@DepartmentId",info.DepartmentId),
                new SqlParameter("@LinePrice",info.LinePrice),
                new SqlParameter("@Description",info.Description),
                new SqlParameter("@ForeColseTypeName",info.ForeColseTypeName)
            };
            int rowAffected = SqlHelper.ExecuteNonQuery(CommandType.Text, sql, param);
            return rowAffected;
        }

        /// <summary>
        /// 修改抵债信息
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public int UpdateForeclosedByID(ForeclosedInfo info)
        {
            string sql = @"UPDATE ForeclosedInfo SET Title =                                                                                                              
                                    @Title,Address=@Address,AreaId=@AreaId,EndDate=@EndDate,LinePrice=@LinePrice,Description=@Description,
                                    ForeColseTypeName=@ForeColseTypeName WHERE ForeclosedId=@Id";

            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@Title",info.Title),
                new SqlParameter("@Address",info.Address),
                new SqlParameter("@AreaId",info.AreaId),
                new SqlParameter("@EndDate",info.EndDate),
                new SqlParameter("@LinePrice",info.LinePrice),
                new SqlParameter("@Description",info.Description),
                new SqlParameter("@ForeColseTypeName",info.ForeColseTypeName),
                new SqlParameter("@Id",info.ForeclosedId)
            };
            int rowAffected = SqlHelper.ExecuteNonQuery(CommandType.Text, sql, param);
            return rowAffected;
        }

        /// <summary>
        /// 删除一条记录
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public int Delete(int ID)
        {
            string sql = "delete bidinfo where foreclosedid =  @Id ";
            SqlParameter[] param = new SqlParameter[] 
            { 
                new SqlParameter("@Id",ID),
            };
            int rowAffected = SqlHelper.ExecuteNonQuery(CommandType.Text, sql, param);

            sql = "DELETE ForeclosedInfo WHERE ForeclosedId=@Id";
            rowAffected = SqlHelper.ExecuteNonQuery(CommandType.Text, sql, param);

            return rowAffected;
        }

        /// <summary>
        /// 删除多条记录
        /// </summary>
        /// <param name="Ids"></param>
        /// <returns></returns>
        public int Deletes(string Ids)
        {
            SqlParameter[] param = new SqlParameter[] 
            { 
                new SqlParameter("@Id",Ids),
            };
            string sql = "delete bidinfo where foreclosedid in ( @Id )";
            int rowAffected = SqlHelper.ExecuteNonQuery(CommandType.Text, sql, param);

            sql = "DELETE ForeclosedInfo WHERE ForeclosedId in ( @Id )";
            rowAffected = SqlHelper.ExecuteNonQuery(CommandType.Text, sql, param);

            return rowAffected;
        }

        /// <summary>
        /// 根据抵债ID获取抵债信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ForeclosedInfo GetForeclosedInfoById(int id)
        {
            string sql = "SELECT * FROM dbo.ForeclosedInfo WHERE ForeclosedId = @Id";
            SqlParameter[] param = new SqlParameter[] 
            { 
                new SqlParameter("@Id",id),
            };
            ForeclosedInfo info = null;

            using (SqlDataReader reader = XYECOM.Core.Data.SqlHelper.ExecuteReader(CommandType.Text, sql, param))
            {
                if (reader.Read())
                {
                    info = new ForeclosedInfo();

                    info.ForeclosedId = id;
                    info.Title = reader["Title"].ToString();
                    info.IdentityNumber = reader["IdentityNumber"].ToString();
                    info.HighPrice = Core.MyConvert.GetDecimal(reader["HighPrice"].ToString());
                    info.Address = reader["Address"].ToString();
                    info.EndDate = Core.MyConvert.GetDateTime(reader["EndDate"].ToString());
                    info.CreateDate = Core.MyConvert.GetDateTime(reader["CreateDate"].ToString());
                    info.State = Core.MyConvert.GetInt32(reader["State"].ToString());
                    info.PassDate = Core.MyConvert.GetDateTime(reader["PassDate"].ToString());
                    info.UserId = Core.MyConvert.GetInt32(reader["UserId"].ToString());
                    info.AreaId = Core.MyConvert.GetInt32(reader["AreaId"].ToString());
                    info.DepartmentId = Core.MyConvert.GetInt32(reader["DepartmentId"].ToString());
                    info.Description = reader["Description"].ToString();
                    info.ForeCloseTypeId = Core.MyConvert.GetInt32(reader["ForeCloseTypeId"].ToString());
                    info.ForeColseTypeName = reader["ForeColseTypeName"].ToString();
                    info.LinePrice = Core.MyConvert.GetDecimal(reader["LinePrice"].ToString());
                    info.PassDate = Core.MyConvert.GetDateTime(reader["PassDate"].ToString());
                }
            }
            return info;
        }

        /// <summary>
        /// 单条审核操作
        /// </summary>
        /// <param name="fId">抵债信息编号</param>
        /// <param name="state">审核通过or审核不通过</param>
        /// <returns></returns>
        public int AuditById(int fId, bool state)
        {
            string sql = string.Empty;
            if (state)
            {
                sql = "UPDATE dbo.ForeclosedInfo SET State = 1,PassDate=getDate() WHERE ForeclosedId= " + fId;
            }
            else
            {
                sql = "UPDATE dbo.ForeclosedInfo SET State = 0,PassDate=getDate() WHERE ForeclosedId= " + fId;
            }
            int rowAffected = SqlHelper.ExecuteNonQuery(CommandType.Text, sql, null);
            return rowAffected;
        }

        /// <summary>
        /// 多条审核操作
        /// </summary>
        /// <param name="fIds">抵债信息编号</param>
        /// <param name="state">审核通过or审核不通过</param>
        /// <returns></returns>
        public int AuditByIds(string fIds, bool state)
        {
            string sql = string.Empty;
            if (state)
            {
                sql = "UPDATE dbo.ForeclosedInfo SET State = 1 WHERE ForeclosedId in (" + fIds + ")";
            }
            else
            {
                sql = "UPDATE dbo.ForeclosedInfo SET State = 0 WHERE ForeclosedId in (" + fIds + ")";
            }
            int rowAffected = SqlHelper.ExecuteNonQuery(CommandType.Text, sql, null);
            return rowAffected;
        }

        /// <summary>
        /// 关闭抵债信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int ClosedByID(int id)
        {
            string sql = "UPDATE dbo.ForeclosedInfo SET EndDate = '" + DateTime.Now.ToString("yyyy-MM-dd") + "' WHERE ForeclosedId = " + id;
            int rowAffected = SqlHelper.ExecuteNonQuery(CommandType.Text, sql, null);
            return rowAffected;
        }
    }
}
