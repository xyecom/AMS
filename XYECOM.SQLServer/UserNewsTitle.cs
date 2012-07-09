using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using XYECOM.Core.Data;
using XYECOM.Core;

namespace XYECOM.SQLServer
{
    public class UserNewsTitle
    {
        #region 添加新闻栏目
        /// <summary>
        ///  添加新闻栏目信息
        /// </summary>
        /// <param name="info">栏目信息对象</param>
        /// <param name="nt_id">所添加的新闻栏目的ID值</param>
        /// <returns>数字，大于或等于0表示添加成功</returns>
        public int Insert(XYECOM.Model.User.UserNewsTitleInfo info, out int nt_id)
        {
            SqlParameter[] prarm = new SqlParameter[]
            {
                new SqlParameter("@Id",info.Id),
                new SqlParameter("@Name",info.Name),
                new SqlParameter("@UserId",info.UserId),
                new SqlParameter("@ParentId",info.ParentId),
                new SqlParameter("@OrderId",info.OrderId)
            };

            prarm[0].Direction = ParameterDirection.Output;
            string sql = "INSERT INTO XY_UserNewsTitleInfo (";
            sql += "Name,";
            sql += "UserId,";
            sql += "ParentId,";
            sql += "OrderId)";
            sql += "values (";
            sql += "@Name,";
            sql += "@UserId,";
            sql += "@ParentId,";
            sql += "@OrderId)";

            int rowAffected = SqlHelper.ExecuteNonQuery(CommandType.Text, sql, prarm);
            if (rowAffected >= 0)
            {
                if (prarm[0].Value != null && prarm[0].Value.ToString() != "")
                    nt_id = Core.MyConvert.GetInt32(prarm[0].Value.ToString());
                else
                    nt_id = 0;
            }
            else
            {
                nt_id = -1;
            }

            return rowAffected;
        }
        #endregion

        #region  修改新闻栏目信息
        /// <summary>
        /// 修改指定的新闻栏目信息
        /// </summary>
        /// <param name="info">栏目信息对象</param>
        /// <returns>数字，大于或等于0表示修改成功</returns>
        public int Update(XYECOM.Model.User.UserNewsTitleInfo info)
        {
            SqlParameter[] param = new SqlParameter[] 
            {
                new SqlParameter("@Id",info.Id),
                new SqlParameter("@Name",info.Name),
                new SqlParameter("@UserId",XYECOM.Core.MyConvert.GetInt32(info.UserId)),
                new SqlParameter("@ParentId",info.ParentId),
                new SqlParameter("@OrderId",info.OrderId)
            };

            string sql = @"update XY_UserNewsTitleInfo set Name=@Name,UserId=@UserId,ParentId=@ParentId,OrderId=@OrderId where Id = @Id";

            return SqlHelper.ExecuteNonQuery(CommandType.Text, sql, param);

        }
        #endregion

        #region 删除指定的新闻栏目
        /// <summary>
        /// 删除指定的新闻栏目信息
        /// </summary>
        /// <param name="nt_ids">指定的新闻栏目编号字符串</param>
        /// <returns>数字，大于或等于0表示删除成功</returns>
        public int Delete(string ids)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@Id",ids)
            };

            string sql = "delete XY_UserNewsTitleInfo where Id=@Id";

            return SqlHelper.ExecuteNonQuery(CommandType.Text, sql, param);

        }
        #endregion

        /// <summary>
        /// 获取栏目信息
        /// </summary>
        /// <param name="id">栏目Id</param>
        /// <returns>栏目数据对象</returns>
        public Model.User.UserNewsTitleInfo GetItem(int Id)
        {
            XYECOM.Model.User.UserNewsTitleInfo info = new Model.User.UserNewsTitleInfo();

            SqlParameter[] parame = new SqlParameter[]
			{
				new SqlParameter("@Id",Id)
			};
            string sql = "select * from XY_UserNewsTitleInfo where Id = @Id";
            using (SqlDataReader reader = SqlHelper.ExecuteReader(CommandType.Text, sql, parame))
            {
                if (reader.Read())
                {
                    info.Id = Core.MyConvert.GetInt32(reader["Id"].ToString());
                    info.Name = reader["Name"].ToString();
                    info.UserId = reader["UserId"].ToString();
                    info.OrderId = Core.MyConvert.GetInt32(reader["OrderId"].ToString());
                    info.ParentId = Core.MyConvert.GetInt32(reader["ParentId"].ToString());
                }
            }
            return info;
        }

        /// <summary>
        /// 获取多条记录
        /// </summary>
        /// <returns>多条记录</returns>
        public DataTable Select()
        {
            string sql = "select * from XY_UserNewsTitleInfo";
            return SqlHelper.ExecuteTable(sql);
        }

        /// <summary>
        /// 获取多条记录
        /// </summary>
        /// <returns>多条记录</returns>
        public List<Model.User.UserNewsTitleInfo> SelectPId()
        {
            XYECOM.Model.User.UserNewsTitleInfo info = new Model.User.UserNewsTitleInfo();
            List<Model.User.UserNewsTitleInfo> infos = new List<Model.User.UserNewsTitleInfo>();

            string sql = "select * from XY_UserNewsTitleInfo where ParentId = '0'";

            DataTable Table = SqlHelper.ExecuteTable(sql);

            DataRow[] rows = Table.Select();

            foreach (DataRow row in rows)
            {
                info.Id = Core.MyConvert.GetInt32(row["Id"].ToString());
                info.Name = row["Name"].ToString();
                info.UserId = row["UserId"].ToString();
                info.OrderId = Core.MyConvert.GetInt32(row["OrderId"].ToString());
                info.ParentId = Core.MyConvert.GetInt32(row["ParentId"].ToString());

                infos.Add(info);
            }
            return infos;
        }
    }
}
