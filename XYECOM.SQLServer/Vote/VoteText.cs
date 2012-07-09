using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace XYECOM.SQLServer
{
    /// <summary>
    /// 调查文本内容数据操作类
    /// </summary>
    public class VoteText
    {
        /// <summary>
        /// 插入一条信息
        /// </summary>
        /// <param name="info">数据对象</param>
        /// <returns></returns>
        public int Insert(Model.VoteTextInfo info)
        {
            string cmdText = "Insert Into XY_VoteText(Body,SubjectId) values(@Body,@SubjectId)";

            SqlParameter[] param = new SqlParameter[] 
            { 
                new SqlParameter("@Body",info.Body),
                new SqlParameter("@SubjectId",info.SubjectId)
            };

            return XYECOM.Core.Data.SqlHelper.ExecuteNonQuery(CommandType.Text, cmdText, param);
        }

        /// <summary>
        /// 通过主题Id返回所有的文本内容
        /// </summary>
        /// <param name="subjectId">主题Id</param>
        /// <returns></returns>
        public List<Model.VoteTextInfo> GetItemsBySubjectId(int subjectId)
        {
            string cmdText = "select * from XY_VoteText where subjectId =@SubjectId";

            SqlParameter[] param = new SqlParameter[] 
            { 
                new SqlParameter("@SubjectId",subjectId)
            };

            List<Model.VoteTextInfo> list = new List<XYECOM.Model.VoteTextInfo>();

            using (SqlDataReader reader = XYECOM.Core.Data.SqlHelper.ExecuteReader(CommandType.Text, cmdText, param))
            {
                while (reader.Read())
                {
                    Model.VoteTextInfo info = new XYECOM.Model.VoteTextInfo();

                    info.TextId = XYECOM.Core.MyConvert.GetInt32(reader["TextId"].ToString());
                    info.Body = reader["Body"].ToString();
                    info.SubjectId = XYECOM.Core.MyConvert.GetInt32(reader["SubjectId"].ToString());

                    list.Add(info);
                }
            }

            return list;
        }

        /// <summary>
        /// 删除文本
        /// </summary>
        /// <param name="textId">文本Id</param>
        /// <returns></returns>
        public int Delete(int textId)
        {
            string cmdText = "Delete XY_VoteText where textId = @TextId";

            SqlParameter[] param = new SqlParameter[] 
            { 
                new SqlParameter("@TextId",textId)
            };

            return XYECOM.Core.Data.SqlHelper.ExecuteNonQuery(CommandType.Text, cmdText, param);
        }
    }
}
