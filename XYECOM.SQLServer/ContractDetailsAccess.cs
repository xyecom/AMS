using System;
using System.Collections.Generic;

using System.Text;
using System.Data;
using System.Data.SqlClient;
using XYECOM.Core.Data;

namespace XYECOM.SQLServer
{
    public partial class ContractDetailsAccess
    {
        public List<Model.ContractDetailsInfo> GetDetailListByConId(int conId)
        {
            List<Model.ContractDetailsInfo> list = new List<Model.ContractDetailsInfo>();

            SqlParameter[] parame = new SqlParameter[]
			{
				new SqlParameter("@conId",conId)
			};
            XYECOM.Model.ContractDetailsInfo info = null;
            string sql = "select * from xy_contractdetails where contractid = @conId";
            using (SqlDataReader reader = SqlHelper.ExecuteReader(CommandType.Text, sql, parame))
            {
                while (reader.Read())
                {
                    info = new XYECOM.Model.ContractDetailsInfo();
                    info.Id = Core.MyConvert.GetInt32(reader["Id"].ToString());
                    info.Count = Core.MyConvert.GetInt32(reader["count"].ToString());
                    info.Price = Core.MyConvert.GetDecimal(reader["Price"].ToString());
                    info.Unit = reader["Unit"].ToString();
                    info.Title =reader["title"].ToString();
                    info.TotalAmount = Core.MyConvert.GetDecimal(reader["TotalAmount"].ToString());
                    info.Remar = reader["remar"].ToString();
                    info.ContractId = conId;
                    list.Add(info);
                }
            }

            return list;
        }

        /// <summary>
        /// 删除操作(删除单条)
        /// </summary>
        /// <param name="conId">信息主键合同编号</param>
        /// <returns>受影响的行数</returns>
        public int DeleteByConId(int conId)
        {
            SqlParameter[] parame = new SqlParameter[]
			{
				new SqlParameter("@conId",conId)
			};
            string sql = "delete XY_ContractDetails where contractid = @conId";
            return SqlHelper.ExecuteNonQuery(CommandType.Text, sql, parame);
        }
    }
}
