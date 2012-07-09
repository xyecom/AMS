using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace XYECOM.SQLServer
{
    /// <summary>
    /// ͶƱ��Ϣ���ݴ�����
    /// </summary>
    public class Poll:DataCache
    {
        /// <summary>
        /// �����¼
        /// </summary>
        /// <param name="info">��¼����</param>
        /// <param name="lastId">���ص���ϢId</param>
        /// <returns>��Ӱ������</returns>
        public int Insert(Model.PollInfo info,out int lastId)
        {
            string cmdText = "Insert Into XY_Poll(labelName,title,mode) values(@LabelName,@Title,@Mode)"
                            + "Select @@identity";

            SqlParameter[] param = new SqlParameter[] 
            { 
                new SqlParameter("@LabelName",info.LabelName),
                new SqlParameter("@Title",info.Title),
                new SqlParameter("@Mode",info.Mode == XYECOM.Model.PollMode.Single ? "single":"check")
            };

            lastId =0;
            using(SqlDataReader reader =  XYECOM.Core.Data.SqlHelper.ExecuteReader(CommandType.Text, cmdText, param))
            {
                if(reader.Read())
                    lastId = Core.MyConvert.GetInt32(reader[0].ToString());
            }

            UpdateCache();

            return lastId;
        }

        /// <summary>
        /// ���¼�¼
        /// </summary>
        /// <param name="info">���ݶ���</param>
        /// <returns>��Ӱ������</returns>
        public int Update(Model.PollInfo info)
        {
            string cmdText = "Update XY_Poll set LabelName = @LabelName ,Title = @Title,mode = @Mode where PollId = @PollId";

            SqlParameter[] param = new SqlParameter[] 
            { 
                new SqlParameter("@LabelName",info.LabelName),
                new SqlParameter("@Title",info.Title),
                new SqlParameter("@Mode",info.Mode == XYECOM.Model.PollMode.Single ? "single":"check"),
                new SqlParameter("@PollId",info.PollId),
            };

            int i = XYECOM.Core.Data.SqlHelper.ExecuteNonQuery(CommandType.Text, cmdText, param);

            UpdateCache();

            return i;
        }

        /// <summary>
        /// ɾ����¼
        /// </summary>
        /// <param name="pollId">��¼Id</param>
        /// <returns>��Ӱ������</returns>
        public int Delete(int pollId)
        {
            string cmdText = "Delete XY_Poll where PollId =@PollId";

            SqlParameter[] param = new SqlParameter[] 
            { 
                new SqlParameter("@PollId",pollId)
            };

            int i = XYECOM.Core.Data.SqlHelper.ExecuteNonQuery(CommandType.Text, cmdText, param);

            UpdateCache();

            return i;
        }

        /// <summary>
        /// ��ȡ���ݶ���
        /// </summary>
        /// <param name="pollId">��¼Id</param>
        /// <returns>���ݶ���</returns>
        public Model.PollInfo GetItem(int pollId)
        {
            XYECOM.Model.PollInfo info = null;

            Object obj = GetCache();

            if (obj == null) return info;

            DataTable table = (DataTable)obj;

            DataRow[] rows = table.Select("pollid =" + pollId);

            if (rows != null && rows.Length > 0)
            {
                info = new XYECOM.Model.PollInfo();

                info.PollId = Core.MyConvert.GetInt32(rows[0]["PollId"].ToString());
                info.LabelName = rows[0]["LabelName"].ToString();
                info.Title = rows[0]["Title"].ToString();
                info.Mode = rows[0]["Mode"].ToString() == "single" ? Model.PollMode.Single: XYECOM.Model.PollMode.Check;
            }

            return info;
        }

        /// <summary>
        /// ��ȡ����
        /// </summary>
        /// <param name="labelName">��ǩ����</param>
        /// <returns>���ݶ���</returns>
        public Model.PollInfo GetItem(string labelName)
        {
            XYECOM.Model.PollInfo info = null;

            Object obj = GetCache();

            if (obj == null) return info;

            DataTable table = (DataTable)obj;

            DataRow[] rows = table.Select("labelName ='" + labelName + "'");

            if (rows != null && rows.Length > 0)
            {
                info = new XYECOM.Model.PollInfo();

                info.PollId = Core.MyConvert.GetInt32(rows[0]["PollId"].ToString());
                info.LabelName = rows[0]["LabelName"].ToString();
                info.Title = rows[0]["Title"].ToString();
                info.Mode = rows[0]["Mode"].ToString() == "single" ? Model.PollMode.Single : XYECOM.Model.PollMode.Check;
            }

            return info;
        }

        /// <summary>
        /// 
        /// </summary>
        public override string SQL_Get_All
        {
            get { return "select * from xy_poll"; }
        }
    }
}
