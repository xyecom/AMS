using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace XYECOM.SQLServer
{
   /// <summary>
   /// ͶƱѡ�����ݴ�����
   /// </summary>
    public class PollOption
    {
        /// <summary>
        /// �����¼
        /// </summary>
        /// <param name="info">���ݶ���</param>
        /// <returns>��Ӱ������</returns>
        public int Insert(Model.PollOptionInfo info)
        {
            string cmdText = "Insert Into XY_PollOption(PollId,[Option]) values(@PollId,@Option)";

            SqlParameter[] param = new SqlParameter[] 
            { 
                new SqlParameter("@PollId",info.PollId),
                new SqlParameter("@Option",info.Option)
            };

            return XYECOM.Core.Data.SqlHelper.ExecuteNonQuery(CommandType.Text, cmdText, param);
        }

        /// <summary>
        /// ���¼�¼
        /// </summary>
        /// <param name="info">���ݶ���</param>
        /// <returns>��Ӱ������</returns>
        public int Update(Model.PollOptionInfo info)
        {
            string cmdText = "Update XY_PollOption Set PollId = @PollId,[Option] = @Option,Total = @Total where OptionId=@OptionId";

            SqlParameter[] param = new SqlParameter[] 
            { 
                new SqlParameter("@PollId",info.PollId),
                new SqlParameter("@Option",info.Option),
                new SqlParameter("@Total",info.Total),
                new SqlParameter("@OptionId",info.OptionId),
            };

            return XYECOM.Core.Data.SqlHelper.ExecuteNonQuery(CommandType.Text, cmdText, param);
        }

        /// <summary>
        /// ɾ����¼
        /// </summary>
        /// <param name="optionId">ѡ���¼Id</param>
        /// <returns>��Ӱ������</returns>
        public int Delete(int optionId)
        {
            string cmdText = "Delete XY_PollOption where OptionId =@OptionId";

            SqlParameter[] param = new SqlParameter[] 
            { 
                new SqlParameter("@OptionId",optionId)
            };

            return XYECOM.Core.Data.SqlHelper.ExecuteNonQuery(CommandType.Text, cmdText, param);
        }

        /// <summary>
        /// ɾ����¼
        /// </summary>
        /// <param name="pollId">ͶƱId</param>
        /// <returns>��Ӱ������</returns>
        public int DeleteByPollId(int pollId)
        {
            string cmdText = "Delete XY_PollOption where PollId =@PollId";

            SqlParameter[] param = new SqlParameter[] 
            { 
                new SqlParameter("@PollId",pollId)
            };

            return XYECOM.Core.Data.SqlHelper.ExecuteNonQuery(CommandType.Text, cmdText, param);
        }

        /// <summary>
        /// ��ȡ��¼
        /// </summary>
        /// <param name="optionId">ѡ��Id</param>
        /// <returns>���ݶ���</returns>
        public Model.PollOptionInfo GetItem(int optionId)
        {
            Model.PollOptionInfo info = null;

            string cmdText = "select OptionId,PollId,[Option],Total From XY_PollOption where OptionId= @OptionId";

            SqlParameter[] param = new SqlParameter[] 
            { 
                new SqlParameter("@OptionId",optionId)
            };

            using (SqlDataReader reader = XYECOM.Core.Data.SqlHelper.ExecuteReader(CommandType.Text, cmdText, param))
            {
                while (reader.Read())
                {
                    info = new XYECOM.Model.PollOptionInfo();

                    info.OptionId = reader.GetInt32(0);
                    info.PollId = reader.GetInt32(1);
                    info.Option = reader.GetString(2);
                    info.Total = reader.GetInt32(3);
                }
            }

            return info;
        }

        /// <summary>
        /// ��ȡָ��ͶƱ�µ�����ѡ��
        /// </summary>
        /// <param name="pollId">ͶƱ��¼Id</param>
        /// <returns>���ݶ��󼯺�</returns>
        public List<Model.PollOptionInfo> GetItems(int pollId)
        {
            List<Model.PollOptionInfo> list = new List<XYECOM.Model.PollOptionInfo>();

            string cmdText = "select OptionId,PollId,[Option],Total From XY_PollOption "
                            + " where PollId =@PollId"
                            + " Order By OptionId asc";

            SqlParameter[] param = new SqlParameter[] 
            { 
                new SqlParameter("@PollId",pollId)
            };

            Model.PollOptionInfo info = null;

            using (SqlDataReader reader = XYECOM.Core.Data.SqlHelper.ExecuteReader(CommandType.Text, cmdText, param))
            {
                while (reader.Read())
                {
                    info = new XYECOM.Model.PollOptionInfo();

                    info.OptionId = reader.GetInt32(0);
                    info.PollId = reader.GetInt32(1);
                    info.Option = reader.GetString(2);
                    info.Total = reader.GetInt32(3);

                    list.Add(info);
                }
            }

            return list;
        }
    }
}
