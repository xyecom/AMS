using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using XYECOM.Core.Data;

namespace XYECOM.SQLServer
{
    public class CaseAccess
    {
        public Model.CaseInfo GetItem(int infoId)
        {
            XYECOM.Model.CaseInfo info = null;
            SqlParameter[] parame = new SqlParameter[]
			{
				new SqlParameter("@Id",infoId)
			};
            string sql = "select * from CaseInfo where Id = @Id";
            using (SqlDataReader reader = SqlHelper.ExecuteReader(CommandType.Text, sql, parame))
            {
                if (reader.Read())
                {
                    info = new XYECOM.Model.CaseInfo();
                    info.Id = Core.MyConvert.GetInt32(reader["Id"].ToString());
                    info.CaseName = reader["CaseName"].ToString();
                    info.CaseTypeId = Core.MyConvert.GetInt32(reader["CaseTypeId"].ToString());
                    info.CaseTypeName = reader["CaseTypeName"].ToString();
                    info.CreateDate = Core.MyConvert.GetDateTime(reader["CreateDate"].ToString());
                    info.Description = reader["Description"].ToString();
                    info.FilePath = reader["FilePath"].ToString();
                    info.PartId = Core.MyConvert.GetInt32(reader["PartId"].ToString());
                    info.PartName = reader["PartName"].ToString();
                    info.CompanyId = Core.MyConvert.GetInt32(reader["CompanyId"].ToString());
                    info.CompanyName = reader["CompanyName"].ToString();
                }
            }
            return info;
        }

        public int Update(Model.CaseInfo info)
        {
            SqlParameter[] parame = new SqlParameter[]
			{
				new SqlParameter("@Id",info.Id),
				new SqlParameter("@CaseName",info.CaseName),
				new SqlParameter("@Description",info.Description)
			};

            string sql = "update CaseInfo set ";
            sql += "CaseName=@CaseName,";
            sql += "Description=@Description";            
            sql += " where Id = @Id";
            return SqlHelper.ExecuteNonQuery(CommandType.Text, sql, parame);
        }

        public int Insert(Model.CaseInfo info)
        {
            SqlParameter[] parame = new SqlParameter[]
			{
				new SqlParameter("@CaseName",info.CaseName),
				new SqlParameter("@CaseTypeId",info.CaseTypeId),
				new SqlParameter("@CaseTypeName",info.CaseTypeName),
				new SqlParameter("@CompanyId",info.CompanyId),
				new SqlParameter("@CompanyName",info.CompanyName),
				new SqlParameter("@Description",info.Description),
				new SqlParameter("@FilePath",info.FilePath),
				new SqlParameter("@PartId",info.PartId),
				new SqlParameter("@PartName",info.PartName)		
			};

            string sql = @"INSERT INTO CaseInfo
                        (CaseName
                        ,Description
                        ,CaseTypeName
                        ,CaseTypeId
                        ,FilePath
                        ,CreateDate
                        ,PartId
                        ,PartName
                        ,CompanyId
                        ,CompanyName)
                    VALUES
                        (@CaseName
                        ,@Description
                        ,@CaseTypeName
                        ,@CaseTypeId
                        ,@FilePath
                        ,GETDATE()
                        ,@PartId
                        ,@PartName
                        ,@CompanyId
                        ,@CompanyName)";

            return SqlHelper.ExecuteNonQuery(CommandType.Text, sql, parame);
        }

        public int Delete(string infoids)
        {
            string sql = "delete CaseInfo where Id in (" + infoids + ")";
            return SqlHelper.ExecuteNonQuery(CommandType.Text, sql, null);
        }
    }
}
