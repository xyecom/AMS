﻿//------------------------------------------------------------------------------
//
// 说明： 该文件中的内容是由代码生成器自动生成的，请勿手工修改！
//
// file name：CreditLeavlAccess.autogenerated.cs
// author: wangzhen
// create date：2011-5-31 12:06:01
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
    public partial class CreditLeavlAccess
    {

        /// <summary>
        /// 根据Id获取实体信息
        /// </summary>
        /// <param name="infoId">信息主键Id</param>
        /// <returns>数据实体对象</returns>
        public XYECOM.Model.CreditLeavlInfo GetItem(int infoId)
        {
            XYECOM.Model.CreditLeavlInfo info = null;
            SqlParameter[] parame = new SqlParameter[]
			{
				new SqlParameter("@Id",infoId)
			};
            string sql = "select * from XY_CreditLeavl where Id = @Id";
            using (SqlDataReader reader = SqlHelper.ExecuteReader(CommandType.Text, sql, parame))
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

        /// <summary>
        /// 删除操作(删除单条)
        /// </summary>
        /// <param name="infoId">信息主键Id</param>
        /// <returns>受影响的行数</returns>
        public int Delete(int infoId)
        {
            SqlParameter[] parame = new SqlParameter[]
			{
				new SqlParameter("@Id",infoId)
			};
            string sql = "delete XY_CreditLeavl where Id = @Id";
            return SqlHelper.ExecuteNonQuery(CommandType.Text, sql, parame);
        }


        /// <summary>
        /// 删除操作(删除多条)
        /// </summary>
        /// <param name="infoIds">以逗号隔开的主键Id集合</param>
        /// <returns>受影响的行数</returns>
        public int DeleteByIds(string infoIds)
        {
            string sql = "delete XY_CreditLeavl where Id in (" + infoIds + ")";
            return SqlHelper.ExecuteNonQuery(CommandType.Text, sql, null);
        }


        /// <summary>
        /// 修改操作
        /// </summary>
        /// <param name="info">实体对象</param>
        /// <returns>受影响行数</returns>
        public int Update(XYECOM.Model.CreditLeavlInfo info)
        {
            SqlParameter[] parame = new SqlParameter[]
			{
				new SqlParameter("@Id",info.Id),
				new SqlParameter("@LeavlName",info.LeavlName),
				new SqlParameter("@Leavl",info.Leavl),
				new SqlParameter("@UpPoint",info.UpPoint),
				new SqlParameter("@DownPoint",info.DownPoint),
				new SqlParameter("@ImagePath",info.ImagePath)	
			};

            string sql = "update XY_CreditLeavl set ";
            sql += "LeavlName=@LeavlName,";
            sql += "Leavl=@Leavl,";
            sql += "UpPoint=@UpPoint,";
            sql += "DownPoint=@DownPoint,";
            sql += "ImagePath=@ImagePath";
            sql += " where Id = @Id";
            return SqlHelper.ExecuteNonQuery(CommandType.Text, sql, parame);
        }

        /// <summary>
        /// 插入操作
        /// </summary>
        /// <param name="info">要插入的实体对象</param>
        /// <returns></returns>
        public int Insert(XYECOM.Model.CreditLeavlInfo info)
        {
            SqlParameter[] parame = new SqlParameter[]
			{
				new SqlParameter("@LeavlName",info.LeavlName),
				new SqlParameter("@Leavl",info.Leavl),
				new SqlParameter("@UpPoint",info.UpPoint),
				new SqlParameter("@DownPoint",info.DownPoint),
				new SqlParameter("@ImagePath",info.ImagePath)	
			};

            string sql = "INSERT INTO XY_CreditLeavl (";
            sql += "LeavlName,";
            sql += "Leavl,";
            sql += "UpPoint,";
            sql += "DownPoint,";
            sql += "ImagePath) values (";
            sql += "@LeavlName,";
            sql += "@Leavl,";
            sql += "@UpPoint,";
            sql += "@DownPoint,";
            sql += "@ImagePath)";

            return SqlHelper.ExecuteNonQuery(CommandType.Text, sql, parame);
        }


        /// <summary>
        /// 插入操作
        /// </summary>
        /// <param name="info">要插入的实体对象</param>
        /// <param name="ceInfoid">新增信息的ID</param>
        /// <returns></returns>
        public int Insert(XYECOM.Model.CreditLeavlInfo info, out int infoId)
        {
            SqlParameter[] parame = new SqlParameter[]
			{
				new SqlParameter("@Id",SqlDbType.Int),
				new SqlParameter("@LeavlName",info.LeavlName),
				new SqlParameter("@Leavl",info.Leavl),
				new SqlParameter("@UpPoint",info.UpPoint),
				new SqlParameter("@DownPoint",info.DownPoint),
				new SqlParameter("@ImagePath",info.ImagePath),
			};
            parame[0].Direction = ParameterDirection.Output;
            string sql = "INSERT INTO XY_CreditLeavl (";
            sql += "LeavlName,";
            sql += "Leavl,";
            sql += "UpPoint,";
            sql += "DownPoint,";
            sql += "ImagePath) values (";
            sql += "@LeavlName,";
            sql += "@Leavl,";
            sql += "@UpPoint,";
            sql += "@DownPoint,";
            sql += "@ImagePath);select @Id=ident_current('XY_CreditLeavl')";

            int rowAffected = SqlHelper.ExecuteNonQuery(CommandType.Text, sql, parame);

            if (rowAffected >= 0)
            {
                if (parame[0].Value != null && parame[0].Value.ToString() != "")
                    infoId = Core.MyConvert.GetInt32(parame[0].Value.ToString());
                else
                    infoId = 0;
            }
            else
            {
                infoId = -1;
            }
            return rowAffected;
        }


        /// <summary>
        /// 获取多条记录
        /// </summary>
        /// <returns>多条记录</returns>
        public DataTable Select()
        {
            string sql = "select * from XY_CreditLeavl order by Leavl Asc";
            return SqlHelper.ExecuteTable(sql);
        }
        /*
        /// <summary>
        /// 获取多条记录
        /// </summary>
        /// <param name="pinfo">分页条件</param>
        /// <returns>多条记录</returns>
        public DataTable GetDataTable(XYECOM.Model.PageInfo pagingDescription)
        {			
            string sql = "SELECT * FROM ("+
                    "SELECT "+pagingDescription.Columns+", row_number() over(order by "+pagingDescription.OrderStatement+") rownumber"+
                    "FROM XY_CreditLeavl where "+pagingDescription.Condition+") t"+
                    "WHERE t.rownumber between "+pagingDescription.PageSize+" * ("+pagingDescription.PageIndex+" - 1) + 1 and  "+pagingDescription.PageSize+" * ("+pagingDescription.PageIndex+" - 1) + "+pagingDescription.PageSize;
			
            DataTable data = new DataTable();
            data = SqlHelper.ExecuteTable(sql);
            pagingDescription.Total = data.Rows.Count;
            return data;
        }
        */
        //符合条件的总条数
        public int Count(string strWhere)
        {
            string sql = "select count(*) from XY_CreditLeavl " + strWhere;
            return (int)SqlHelper.ExecuteScalar(sql);
        }
    }
}
