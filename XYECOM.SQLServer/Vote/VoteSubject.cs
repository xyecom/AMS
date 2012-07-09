using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace XYECOM.SQLServer
{
    /// <summary>
    /// 网上调查投票主题数据操作类
    /// </summary>
    public class VoteSubject
    {
        /// <summary>
        /// 插入新主题
        /// </summary>
        /// <param name="info">数据对象</param>
        /// <returns></returns>
        public int Insert(Model.VoteSubjectInfo info,out int subjectId)
        {
            string cmdText = "Insert Into XY_VoteSubject(VoteId,Subject,Type) values(@VoteId,@Subject,@Type) "
                            + "Select @@identity";

            SqlParameter[] param = new SqlParameter[] 
            { 
                new SqlParameter("@VoteId",info.VoteId),
                new SqlParameter("@Subject",info.Subject),
                new SqlParameter("@Type",info.StrType),
            };

            subjectId = 0;
            using (SqlDataReader reader = XYECOM.Core.Data.SqlHelper.ExecuteReader(CommandType.Text, cmdText, param))
            {
                if (reader.Read())
                    subjectId = Core.MyConvert.GetInt32(reader[0].ToString());
            }

            return subjectId;
        }

        /// <summary>
        /// 更新主题信息
        /// </summary>
        /// <param name="info">数据对象</param>
        /// <returns></returns>
        public int Update(Model.VoteSubjectInfo info)
        {
            string cmdText = "Update XY_VoteSubject set VoteId = @VoteId,Subject=@Subject,Type=@Type where subjectId = @SubjectId";

            SqlParameter[] param = new SqlParameter[] 
            { 
                new SqlParameter("@SubjectId",info.SubjectId),
                new SqlParameter("@VoteId",info.VoteId),
                new SqlParameter("@Subject",info.Subject),
                new SqlParameter("@Type",info.StrType),
            };

            return XYECOM.Core.Data.SqlHelper.ExecuteNonQuery(CommandType.Text, cmdText, param);
        }

        /// <summary>
        /// 获取指定调查下的所有主题
        /// </summary>
        /// <param name="voteId">调查Id</param>
        /// <returns></returns>
        public List<Model.VoteSubjectInfo> GetItemsByVoteId(int voteId)
        {
            string cmdText = "select * from XY_VoteSubject where voteId =@VoteId";

            SqlParameter[] param = new SqlParameter[] 
            { 
                new SqlParameter("@VoteId",voteId)
            };

            List<Model.VoteSubjectInfo> list = new List<XYECOM.Model.VoteSubjectInfo>();

            using (SqlDataReader reader = XYECOM.Core.Data.SqlHelper.ExecuteReader(CommandType.Text, cmdText, param))
            {
                while (reader.Read())
                {
                    Model.VoteSubjectInfo info = new XYECOM.Model.VoteSubjectInfo();

                    info.SubjectId = XYECOM.Core.MyConvert.GetInt32(reader["SubjectId"].ToString());
                    info.Subject = reader["Subject"].ToString();
                    info.VoteId = XYECOM.Core.MyConvert.GetInt32(reader["VoteId"].ToString());
                    info.StrType = reader["type"].ToString();

                    list.Add(info);
                }
            }

            return list;
        }

        /// <summary>
        /// 获取问题信息
        /// </summary>
        /// <param name="subjectId">问题Id</param>
        /// <returns></returns>
        public Model.VoteSubjectInfo GetItem(int subjectId)
        {
            string cmdText = "select * from XY_VoteSubject where subjectId =@SubjectId";

            SqlParameter[] param = new SqlParameter[] 
            { 
                new SqlParameter("@SubjectId",subjectId)
            };

            Model.VoteSubjectInfo info = null;

            using (SqlDataReader reader = XYECOM.Core.Data.SqlHelper.ExecuteReader(CommandType.Text, cmdText, param))
            {
                if (reader.Read())
                {
                    info = new XYECOM.Model.VoteSubjectInfo();

                    info.SubjectId = XYECOM.Core.MyConvert.GetInt32(reader["SubjectId"].ToString());
                    info.Subject = reader["Subject"].ToString();
                    info.StrType = reader["Type"].ToString();
                    info.VoteId = XYECOM.Core.MyConvert.GetInt32(reader["VoteId"].ToString());
                }
            }

            return info;
        }

        /// <summary>
        /// 删除主题
        /// </summary>
        /// <param name="voteId">主题Id</param>
        /// <returns></returns>
        public int Delete(int subjectId)
        {
            string cmdText = "Delete XY_VoteSubject where subjectId = @SubjectId";

            SqlParameter[] param = new SqlParameter[] 
            { 
                new SqlParameter("@SubjectId",subjectId)
            };

            return XYECOM.Core.Data.SqlHelper.ExecuteNonQuery(CommandType.Text, cmdText, param);
        }
    }
}
