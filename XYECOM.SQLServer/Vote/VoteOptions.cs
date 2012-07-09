using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace XYECOM.SQLServer
{
    /// <summary>
    /// 投票选项数据操作类
    /// </summary>
    public class VoteOptions
    {
        /// <summary>
        /// 插入选项
        /// </summary>
        /// <param name="info">数据对象</param>
        /// <returns></returns>
        public int Insert(Model.VoteOptionsInfo info)
        {
            string cmdText = "Insert Into XY_VoteOptions(SubjectId,text,VoteTotal) values(@SubjectId,@Text,@VoteTotal)";

            SqlParameter[] param = new SqlParameter[] 
            { 
                new SqlParameter("@SubjectId",info.SubjectId),
                new SqlParameter("@Text",info.Text),
                new SqlParameter("@VoteTotal",info.VoteTotal),
            };

            return XYECOM.Core.Data.SqlHelper.ExecuteNonQuery(CommandType.Text, cmdText, param);
        }

        /// <summary>
        /// 更新选项信息
        /// </summary>
        /// <param name="info">数据对象</param>
        /// <returns></returns>
        public int Update(Model.VoteOptionsInfo info)
        {
            string cmdText = "Update XY_VoteOptions set SubjectId = @SubjectId,Text=@Text,VoteTotal=@VoteTotal where optionId = @OptionId";

            SqlParameter[] param = new SqlParameter[] 
            { 
                new SqlParameter("@SubjectId",info.SubjectId),
                new SqlParameter("@Text",info.Text),
                new SqlParameter("@VoteTotal",info.VoteTotal),
                new SqlParameter("@OptionId",info.OptionId),
            };

            return XYECOM.Core.Data.SqlHelper.ExecuteNonQuery(CommandType.Text, cmdText, param);
        }

        /// <summary>
        /// 获取指定主题下的所有选项
        /// </summary>
        /// <param name="subjectId">主题Id</param>
        /// <returns></returns>
        public List<Model.VoteOptionsInfo> GetItemsBySubjectId(int subjectId)
        {
            string cmdText = "select * from XY_VoteOptions where subjectId =@SubjectId";

            SqlParameter[] param = new SqlParameter[] 
            { 
                new SqlParameter("@SubjectId",subjectId)
            };

            List<Model.VoteOptionsInfo> list = new List<XYECOM.Model.VoteOptionsInfo>();

            using (SqlDataReader reader = XYECOM.Core.Data.SqlHelper.ExecuteReader(CommandType.Text, cmdText, param))
            {
                while (reader.Read())
                {
                    Model.VoteOptionsInfo info = new XYECOM.Model.VoteOptionsInfo();

                    info.OptionId = XYECOM.Core.MyConvert.GetInt32(reader["OptionId"].ToString());
                    info.Text = reader["Text"].ToString();
                    info.SubjectId = XYECOM.Core.MyConvert.GetInt32(reader["SubjectId"].ToString());
                    info.VoteTotal = XYECOM.Core.MyConvert.GetInt32(reader["VoteTotal"].ToString());

                    list.Add(info);
                }
            }

            return list;
        }

        /// <summary>
        /// 获取问题信息
        /// </summary>
        /// <param name="optionId">问题Id</param>
        /// <returns></returns>
        public Model.VoteOptionsInfo GetItem(int optionId)
        {
            string cmdText = "select * from XY_VoteOptions where optionId =@OptionId";

            SqlParameter[] param = new SqlParameter[] 
            { 
                new SqlParameter("@OptionId",optionId)
            };

            Model.VoteOptionsInfo info = null;

            using (SqlDataReader reader = XYECOM.Core.Data.SqlHelper.ExecuteReader(CommandType.Text, cmdText, param))
            {
                if (reader.Read())
                {
                    info = new XYECOM.Model.VoteOptionsInfo();

                    info.OptionId = XYECOM.Core.MyConvert.GetInt32(reader["OptionId"].ToString());
                    info.Text = reader["Text"].ToString();
                    info.VoteTotal = XYECOM.Core.MyConvert.GetInt32(reader["VoteTotal"].ToString());
                    info.SubjectId = XYECOM.Core.MyConvert.GetInt32(reader["SubjectId"].ToString());
                }
            }

            return info;
        }

        /// <summary>
        /// 投票
        /// </summary>
        /// <param name="optionId">选项Id</param>
        /// <returns></returns>
        public int Vote(int optionId)
        {
            string cmdText = "Update XY_VoteOptions set VoteTotal=VoteTotal+1 where optionId = @OptionId";

            SqlParameter[] param = new SqlParameter[] 
            { 
                new SqlParameter("@OptionId",optionId)
            };

            return XYECOM.Core.Data.SqlHelper.ExecuteNonQuery(CommandType.Text, cmdText, param);
        }

        /// <summary>
        /// 删除指定主题下的所有选项
        /// </summary>
        /// <param name="optionId">主题Id</param>
        /// <returns></returns>
        public int Delete(int optionId)
        {
            string cmdText = "Delete XY_VoteOptions where optionId = @OptionId";

            SqlParameter[] param = new SqlParameter[] 
            { 
                new SqlParameter("@OptionId",optionId)
            };

            return XYECOM.Core.Data.SqlHelper.ExecuteNonQuery(CommandType.Text, cmdText, param);
        }
    }
}
