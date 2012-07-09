using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Collections;

namespace XYECOM.Core.Data
{
    /// <summary>
    /// ϵͳ����SQL Server ���ݷ�����
    /// </summary>
    public abstract class SqlHelper
    {
        public static readonly string ConnectionString = ConfigurationManager.ConnectionStrings["XYWebData"].ConnectionString;

        private static Hashtable parmCache = Hashtable.Synchronized(new Hashtable());

        #region ExecuteNonQuery()

        public static int ExecuteNonQuery(string connectionString, CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {

            SqlCommand cmd = new SqlCommand();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                PrepareCommand(cmd, conn, null, cmdType, cmdText, commandParameters);
                int val = cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                return val;
            }
        }

        public static int ExecuteNonQuery(CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {
            return ExecuteNonQuery(ConnectionString, cmdType, cmdText, commandParameters);
        }

        public static int ExecuteNonQuery(CommandType cmdType, string cmdText)
        {
            return ExecuteNonQuery(ConnectionString, cmdType, cmdText, null);
        }

        /// <summary>
        /// Ĭ����������ΪCommandType.Text
        /// </summary>
        /// <param name="uspName">Sql���</param>
        /// <returns></returns>
        public static int ExecuteNonQuery(string cmdText)
        {
            return ExecuteNonQuery(ConnectionString, CommandType.Text, cmdText, null);
        }

        public static int ExecuteNonQuery(SqlConnection connection, CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {

            SqlCommand cmd = new SqlCommand();

            PrepareCommand(cmd, connection, null, cmdType, cmdText, commandParameters);
            int val = cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            return val;
        }

        public static int ExecuteNonQuery(SqlTransaction trans, CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {
            SqlCommand cmd = new SqlCommand();
            PrepareCommand(cmd, trans.Connection, trans, cmdType, cmdText, commandParameters);
            int val = cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            return val;
        }
        #endregion

        #region ExecuteReader()
        public static SqlDataReader ExecuteReader(string connectionString, CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {
            SqlCommand cmd = new SqlCommand();
            SqlConnection conn = new SqlConnection(connectionString);

            try
            {
                PrepareCommand(cmd, conn, null, cmdType, cmdText, commandParameters);
                SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                cmd.Parameters.Clear();
                return rdr;
            }
            catch
            {
                conn.Close();
                throw;
            }
        }

        public static SqlDataReader ExecuteReader(CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {
            return ExecuteReader(ConnectionString, cmdType, cmdText, commandParameters);
        }

        public static SqlDataReader ExecuteReader(CommandType cmdType, string cmdText)
        {
            return ExecuteReader(ConnectionString, cmdType, cmdText, null);
        }

        /// <summary>
        /// Ĭ����������ΪText
        /// </summary>
        /// <param name="uspName">Sql���</param>
        /// <returns></returns>
        public static SqlDataReader ExecuteReader(string cmdText)
        {
            return ExecuteReader(ConnectionString, CommandType.Text, cmdText, null);
        }

        #endregion

        #region ExecuteScalar()

        public static object ExecuteScalar(string connectionString, CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {
            SqlCommand cmd = new SqlCommand();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                PrepareCommand(cmd, connection, null, cmdType, cmdText, commandParameters);
                object val = cmd.ExecuteScalar();
                cmd.Parameters.Clear();
                return val;
            }
        }

        public static object ExecuteScalar(CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {
            return ExecuteScalar(ConnectionString, cmdType, cmdText, commandParameters);
        }

        public static object ExecuteScalar(CommandType cmdType, string cmdText)
        {
            return ExecuteScalar(ConnectionString, cmdType, cmdText, null);
        }

        public static object ExecuteScalar(string cmdText)
        {
            return ExecuteScalar(ConnectionString, CommandType.Text, cmdText, null);
        }

        public static object ExecuteScalar(SqlConnection connection, CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {
            SqlCommand cmd = new SqlCommand();

            PrepareCommand(cmd, connection, null, cmdType, cmdText, commandParameters);
            object val = cmd.ExecuteScalar();
            cmd.Parameters.Clear();
            return val;
        }

        #endregion

        #region ExecuteTable()
        /// <summary>
        /// ��ȡ�������
        /// </summary>
        /// <param name="cmdType">��������</param>
        /// <param name="cmdText">�����ı�</param>
        /// <param name="param">����</param>
        /// <returns></returns>
        public static DataTable ExecuteTable(CommandType cmdType, string cmdText, SqlParameter[] param)
        {
            SqlCommand cmd = new SqlCommand();

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                PrepareCommand(cmd, connection, null, cmdType, cmdText, param);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                cmd.Parameters.Clear();
                return dt;
            }
        }

        /// <summary>
        /// ��ȡ�������
        /// </summary>
        /// <param name="cmdText"></param>
        /// <returns></returns>
        public static DataTable ExecuteTable(string cmdText)
        {
            SqlCommand cmd = new SqlCommand();

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                PrepareCommand(cmd, connection, null, CommandType.Text, cmdText, null);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                cmd.Parameters.Clear();
                return dt;
            }
        }


        #endregion

        #region About Parameters

        public static void CacheParameters(string cacheKey, params SqlParameter[] commandParameters)
        {
            parmCache[cacheKey] = commandParameters;
        }

        public static SqlParameter[] GetCachedParameters(string cacheKey)
        {
            SqlParameter[] cachedParms = (SqlParameter[])parmCache[cacheKey];

            if (cachedParms == null)
                return null;

            SqlParameter[] clonedParms = new SqlParameter[cachedParms.Length];

            for (int i = 0, j = cachedParms.Length; i < j; i++)
                clonedParms[i] = (SqlParameter)((ICloneable)cachedParms[i]).Clone();

            return clonedParms;
        }

        #endregion

        #region PrepareCommand
        private static void PrepareCommand(SqlCommand cmd, SqlConnection conn, SqlTransaction trans, CommandType cmdType, string cmdText, SqlParameter[] cmdParms)
        {

            if (conn.State != ConnectionState.Open)
                conn.Open();

            cmd.Connection = conn;
            cmd.CommandText = cmdText;

            if (trans != null)
                cmd.Transaction = trans;

            cmd.CommandType = cmdType;

            if (cmdParms != null)
            {
                foreach (SqlParameter parm in cmdParms)
                    cmd.Parameters.Add(parm);
            }
        }
        #endregion


        /// <summary>
        /// �ô洢���� ��ӻ��޸�����  
        /// </summary>
        /// <param name="UspName">�洢��������</param>
        /// <param name="param">SqlParameter����</param>
        /// <returns>��Ӱ�������</returns>
        public static int UspExecuteNoneQuery(string UspName, SqlParameter[] param)
        {
            SqlCommand cmd = new SqlCommand();

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                PrepareCommand(cmd, connection, null, CommandType.StoredProcedure, UspName, param);
                int val = cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                return val;
            }
        }

        public static void ExecuteSqlNoneQueryForGO(string sql)
        {
            int startPos = 0;
            string splitter = "\r\nGO\r\n";
            do
            {
                int lastPos = sql.IndexOf(splitter, startPos);
                int len = (lastPos > startPos ? lastPos : sql.Length) - startPos;
                string query = sql.Substring(startPos, len);

                if (query.Trim().Length > 0)
                {
                    ExecuteNonQuery(query);
                }

                if (lastPos == -1)
                    break;
                else
                    startPos = lastPos + splitter.Length;
            } while (startPos < sql.Length);
        }

        public static DataSet GetDataSet(string UspName, SqlParameter[] param)
        {
            SqlCommand cmd = new SqlCommand();

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                PrepareCommand(cmd, connection, null, CommandType.StoredProcedure, UspName, param);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adp.Fill(ds);
                cmd.Parameters.Clear();
                return ds;
            }

        }

        /// <summary>
        /// ����ɾ��
        /// </summary>
        /// <param name="UspName">�洢��������</param>
        /// <param name="param">SqlParameter����</param>
        /// <returns>��Ӱ�������</returns>
        public static int DeleteByWhere(string UspName, SqlParameter[] param)
        {
            SqlCommand cmd = new SqlCommand();

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                PrepareCommand(cmd, connection, null, CommandType.StoredProcedure, UspName, param);
                int val = cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                return val;
            }
        }

        /// <summary>
        /// ������ѯ
        /// </summary>
        /// <param name="strTableName">SqlParameter:������</param>
        /// <param name="strWhere">SqlParameter:�����Ӿ�</param>
        /// <param name="strOrder">SqlParameter:�����Ӿ�</param>
        /// <returns>���ݱ�</returns>
        public static DataTable SelectByWhere(string strTableName, string strWhere, string strOrder)
        {
            SqlCommand cmd = new SqlCommand();

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlParameter[] param = new SqlParameter[]
				{
					new SqlParameter("@strTableName",strTableName),
					new SqlParameter("@strWhere",strWhere),
					new SqlParameter("@strOrder",strOrder)
				};
                PrepareCommand(cmd, connection, null, CommandType.StoredProcedure, "XYP_SelectByWhere", param);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                cmd.Parameters.Clear();
                return dt;
            }
        }

        /// <summary>
        /// �ѹ�ʱ����ʹ���·��� ExecuteTable()
        /// </summary>
        /// <param name="UspName"></param>
        /// <param name="Param"></param>
        /// <returns></returns>
        public static DataTable ExecuteSqlQuery(string sql)
        {
            SqlCommand cmd = new SqlCommand();

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                PrepareCommand(cmd, connection, null, CommandType.Text, sql, null);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                cmd.Parameters.Clear();
                return dt;
            }

        }

        /// <summary>
        /// �ѹ�ʱ����ʹ���·��� ExecuteTable()
        /// </summary>
        /// <param name="UspName"></param>
        /// <param name="Param"></param>
        /// <returns></returns>
        public static DataTable GetDataTable(string UspName, SqlParameter[] Param)
        {
            SqlCommand cmd = new SqlCommand();

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                PrepareCommand(cmd, connection, null, CommandType.StoredProcedure, UspName, Param);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                cmd.Parameters.Clear();
                return dt;
            }
        }
    }
}