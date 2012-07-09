using System;
using System.Collections.Generic;
using System.Text;
using XYECOM.Core.Data;
using System.Data;
using System.Data.SqlClient;
using XYECOM.Core;

namespace XYECOM.SQLServer
{
    /// <summary>
    /// �������������ݴ�����
    /// </summary>
    public class Server:DataCache
    {
        private const string SQL_IS_USED = "select top 1 * from pl_attachment where S_ID={0}";

        #region Insert
        /// <summary>
        /// ��ӷ�������Ϣ
        /// </summary>
        /// <param name="ea">ʵ�����</param>
        /// <returns>��Ӱ�������</returns>
        public int Insert(XYECOM.Model.ServerInfo es)
        {
            SqlParameter[] param = new SqlParameter[] 
            {                                                      
                new SqlParameter("@S_Name",es.S_Name),
                new SqlParameter("@S_Path",es.S_Path),
                new SqlParameter("@S_URL",es.S_URL),
                new SqlParameter("@S_IsCurrent",es .S_IsCurrent ),
                new SqlParameter("@S_Flag",es .S_Flag )
            };

            int value =  SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure,"XYP_InsertServer", param);

            if (value > 0) InitCache();

            return value;
        }
        #endregion

        #region Update
        /// <summary>
        /// �޸ķ�������Ϣ
        /// </summary>
        /// <param name="ea">ʵ�����</param>
        /// <returns>��Ӱ�������</returns>
        public int Update(XYECOM.Model.ServerInfo es)
        {
            SqlParameter[] param = new SqlParameter[] 
            { 
                new SqlParameter("@S_ID",es.S_ID),                                                       
                new SqlParameter("@S_Name",es.S_Name),
                new SqlParameter("@S_Path",es.S_Path),
                new SqlParameter("@S_URL",es.S_URL)
            };

            int value = SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "XYP_UpdateServer", param);

            if (value > 0) InitCache();

            return value;
        }

        /// <summary>
        /// ����Ϊ��ǰ��������
        /// </summary>
        /// <param name="Id">��¼Id</param>
        /// <returns>��Ӱ�������</returns>
        public int UpdateIsCurrent(int Id)
        {
            SqlParameter[] param = new SqlParameter[] 
            { 
                new SqlParameter("@ID",Id)                          
            };

            int value =  SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "XYP_UpdateDefaultServer", param);

            if (value > 0) InitCache();

            return value;
        }

        #endregion

        /// <summary>
        /// ɾ����¼
        /// </summary>
        /// <param name="serverId">��������¼Id</param>
        /// <returns>��Ӱ�������</returns>
        public int Delete(int serverId)
        {
            SqlParameter[] parm = new SqlParameter[]
            { 
                new SqlParameter("@strwhere","where S_ID="+serverId),
                new SqlParameter("@strTableName","b_Server")
            };

            int value =  XYECOM.Core.Data.SqlHelper.DeleteByWhere("usp_DeleteByWhere", parm);

            if (value > 0)
            {
                RemoveCache(string.Format(SQL_IS_USED, serverId));

                InitCache();
            }

            return value;
        }

        #region Read Data
        /// <summary>
        /// ��ȡһ����¼
        /// </summary>
        /// <param name="serverID">��¼���</param>
        /// <returns>���ݶ���</returns>
        public XYECOM.Model.ServerInfo GetItem(int serverID)
        {
            DataTable table = GetDataTable();

            DataRow[] rows = table.Select( "s_id =" + serverID);

            if (rows == null || rows.Length < 1) return null;

            XYECOM.Model.ServerInfo info = new XYECOM.Model.ServerInfo();

            info.S_Name = rows[0]["S_Name"].ToString();
            info.S_Path = rows[0]["S_Path"].ToString();
            info.S_URL = rows[0]["S_URL"].ToString();
            info.S_Flag = Convert.ToBoolean(rows[0]["S_Flag"].ToString());
            info.S_IsCurrent = Convert.ToBoolean(rows[0]["S_IsCurrent"].ToString());

            return info;
        }
        /// <summary>
        /// ��ȡͼƬ�ķ������ı��
        /// </summary>
        /// <returns>ͼƬ���������</returns>
        public int GetCurrentServerID()
        {
            DataTable table = GetDataTable();

            DataRow[] rows = table.Select("S_IsCurrent=1 and S_Flag=0");

            if (rows == null || rows.Length < 1) return -1;

            return Convert.ToInt32(rows[0]["S_ID"].ToString());
        }
        /// <summary>
        /// ��ȡ��ǰ���õ����ַ������ı��
        /// </summary>
        /// <returns>���ַ��������</returns>
        public int GetCharacterServerID()
        {
            DataTable table = GetDataTable();

            DataRow[] rows = table.Select("S_IsCurrent=1 and S_Flag=1");

            if (rows == null || rows.Length < 1) return -1;

            return Convert.ToInt32(rows[0]["S_ID"].ToString());
        }
        /// <summary>
        /// ��ȡ���м�¼
        /// </summary>
        /// <returns>��¼��</returns>
        public DataTable GetDataTable()
        {
            Object obj = GetCache();

            if (obj == null) return new DataTable(); ;

            DataTable table = (DataTable)obj;

            if (table == null) return new DataTable();

            return table;
        }

        /// <summary>
        /// �Ƿ��Ѿ���ʹ��
        /// </summary>
        /// <param name="serverId"></param>
        /// <returns></returns>
        public bool IsUsed(int serverId) 
        {
            string cmdText = string.Format(SQL_IS_USED,serverId);

            object value = GetCache(cmdText);

            if (value != null) return Convert.ToBoolean(value);

            bool _value = false;

            using (SqlDataReader dr = XYECOM.Core.Data.SqlHelper.ExecuteReader(cmdText))
            {
                if (dr.Read())
                    _value = true;
            }

            InsertCache(cmdText, _value);

            return _value;
        }

        #endregion

   
        public override string SQL_Get_All
        {
            get { return "select * from b_server"; }
        }
    }
}
