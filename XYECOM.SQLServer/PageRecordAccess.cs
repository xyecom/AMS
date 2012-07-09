//------------------------------------------------------------------------------
//
// file name：XY_PageRecordAccessor.cs
// author: wangzhen
// create date：2011-6-2 11:51:40
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
    /// Data accessor of PageRecordAccess
    /// </summary>
    public partial class PageRecordAccess
    {

        /// <summary>
        /// 根据Id获取最后访问时间实体信息
        /// </summary>
        /// <param name="infoId">信息主键Id</param>
        /// <returns>数据实体对象</returns>
        public XYECOM.Model.PageRecordInfo GetTopItemById(int infoId)
        {
            XYECOM.Model.PageRecordInfo info = null;
            SqlParameter[] parame = new SqlParameter[]
			{
				new SqlParameter("@Id",infoId)
			};
            string sql = "select TOP 1 * from XY_PageRecord where UserId = @Id order by date desc";
            using (SqlDataReader reader = SqlHelper.ExecuteReader(CommandType.Text, sql, parame))
            {
                if (reader.Read())
                {
                    info = new XYECOM.Model.PageRecordInfo();
                    info.Id = Core.MyConvert.GetInt32(reader["Id"].ToString());
                    info.Guest = reader["Guest"].ToString();
                    info.Date = Core.MyConvert.GetDateTime(reader["Date"].ToString());
                    info.UserId = Core.MyConvert.GetInt32(reader["UserId"].ToString());
                    info.Flag = Core.MyConvert.GetInt32(reader["Flag"].ToString());
                    info.FlagInfo = Core.MyConvert.GetInt32(reader["FlagInfo"].ToString());
                    info.IP = reader["IP"].ToString();
                }
            }
            return info;
        }

        /// <summary>
        /// 获取某用户登录登陆次数[附带条件]带活跃度排序
        /// </summary>
        /// <param name="strWhere">联合查询条件</param>
        /// <param name="strWhere2">最终查询条件</param>
        /// <returns></returns>
        public DataTable GetPageRecordBystrWhere(string sql)
        {
            if(sql != "")
                return XYECOM.Core.Data.SqlHelper.ExecuteTable(sql);
            return null;
        }
    }
}
