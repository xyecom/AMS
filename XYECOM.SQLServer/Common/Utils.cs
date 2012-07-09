using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace XYECOM.SQLServer
{
    /*----------------------------------------------------------------
     * Copyright (C) 2008 �ݺ�����������޹�˾
     * ��Ȩ���С� 
     *
     * �ļ�����XYECOM.SQLServer.Utils.cs
     * �ļ�����������ͨ�����ݴ�����
     *
     * ������ʶ��TC   20080506
     *
     * �޸ı�ʶ��
     * �޸�������
     ----------------------------------------------------------------*/
    /// <summary>
    /// ���ݴ����ͨ����
    /// </summary>
    public class Utils
    {
        #region ExecuteTable
        /// <summary>
        /// ����������ȡ��Ӧ����
        /// ʹ����ʾ�������ڶ�ȡС�����ݣ�����������ѡ����������
        /// </summary>
        /// <param name="tableName">����</param>
        /// <param name="colums">����</param>
        /// <param name="where">����</param>
        /// <param name="order">����</param>
        /// <param name="topNumber">��¼����</param>
        /// <returns></returns>
        public static DataTable ExecuteTable(string tableName, string colums, string where, string order, int topNumber)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@Top",topNumber),
                new SqlParameter("@Columns",colums),
                new SqlParameter("@Table",tableName),
                new SqlParameter("@Where",where),
                new SqlParameter("@Order",order)
            };

            return Core.Data.SqlHelper.ExecuteTable(CommandType.StoredProcedure, "[XYP_CommonSelect]", param);
        }

        /// <summary>
        /// ����������ȡ��Ӧ����
        /// </summary>
        /// <param name="tableName">����</param>
        /// <param name="colums">����</param>
        /// <param name="where">����</param>
        /// <returns></returns>
        public static DataTable ExecuteTable(string tableName, string colums, string where)
        {
            return ExecuteTable(tableName, colums, where, "", 0);
        }

        #endregion


        /// <summary>
        /// �����ƶ���������������
        /// </summary>
        /// <param name="tableName">����</param>
        /// <param name="primaryKey">����</param>
        /// <param name="where">����</param>
        /// <returns></returns>
        public static int GetTotalRecotd(string tableName, string primaryKey, string where)
        {
            string cmdText = "Select Count(" + primaryKey + ") From " + tableName;

            if (!where.Trim().Equals("")) cmdText += " where " + where;

            object result = Core.Data.SqlHelper.ExecuteScalar(cmdText);

            if (null == result) return 0;

            return XYECOM.Core.MyConvert.GetInt32(result.ToString());
        }

        /// <summary>
        /// ��ȡ��ҳ����
        /// </summary>
        /// <param name="tableName">�����ͼ��</param>
        /// <param name="primaryKey">����</param>
        /// <param name="fieldNames">��ȡ�ֶ��б�</param>
        /// <param name="orderFields">�����ֶ��б�(֧�ֶ��,eg. field1 desc,field2 asc)</param>
        /// <param name="where">����</param>
        /// <param name="pageSize">��ǰҳ</param>
        /// <param name="pageIndex">ÿҳ����</param>
        /// <param name="totalRecord">�ܼ�¼����</param>
        /// <returns></returns>
        public static System.Data.DataTable GetPaginationData(string tableName, string primaryKey, string fieldNames, string orderFields, string where, int pageSize, int pageIndex, out int totalRecord)
        {
            if (string.IsNullOrEmpty(orderFields.Trim()))
            {
                orderFields = primaryKey;
            }
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@TableName",tableName),
                new SqlParameter("@PrimaryKey",primaryKey),
                new SqlParameter("@CurPage",pageIndex),
                new SqlParameter("@PageSize",pageSize),
                new SqlParameter("@Fields",fieldNames),
                new SqlParameter("@FieldOrder",orderFields),
                new SqlParameter("@Where",where),
                new SqlParameter("@TotalRecord",SqlDbType.Int),
            };

            param[7].Direction = ParameterDirection.Output;

            DataTable table = Core.Data.SqlHelper.ExecuteTable(CommandType.StoredProcedure, "[XYP_Pagination]", param);

            if (param[7].Value != null && param[7].Value.ToString() != "")
                totalRecord = Core.MyConvert.GetInt32(param[7].Value.ToString());
            else
                totalRecord = 0;

            return table;
        }

        #region �޸�ָ���ֶε�ֵ
        /// <summary>
        /// �޸�ָ���ֶε�ֵ
        /// </summary>
        /// <param name="strColumuName">����</param>
        /// <param name="strColumuValue">ֵ</param>
        /// <param name="strWhere">����</param>
        /// <param name="strTableName">����</param>
        /// <returns></returns>
        public static int UpdateColumuByWhere(string strColumuName, string strColumuValue, string strWhere, string strTableName)
        {
            int rows;
            try
            {
                SqlParameter[] parameters =	
                {
                    new SqlParameter("@TableName",strTableName),
                    new SqlParameter("@ColumuName",strColumuName),
                    new SqlParameter("@ColumuValue","'" + strColumuValue + "'"),
                    new SqlParameter("@StrWhere",strWhere)
                };


                rows = XYECOM.Core.Data.SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "usp_updatecolumubywhere", parameters);
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                rows = 0;
            }
            return rows;
        }

        #endregion

        /// <summary>
        /// ���ݱ�tableName�Լ�����vwhereɾ��һ���������¼��
        /// </summary>
        /// <param name="tableName">����</param>
        /// <param name="where">����</param>
        /// <returns>��Ӱ������</returns>
        public static int Delete(string tableName, string where)
        {
            System.Data.SqlClient.SqlParameter[] pars = new System.Data.SqlClient.SqlParameter[]
            {
                new SqlParameter("@tableName", tableName),
                new SqlParameter("@strWhere", where)
            };
            return XYECOM.Core.Data.SqlHelper.ExecuteNonQuery(System.Data.CommandType.StoredProcedure, "XYP_Delete", pars);
        }

        /// <summary>
        /// ��ȡ������Ϣ��Fullid
        /// </summary>
        /// <param name="ename"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public static string GetFullid(string ename, string id)
        {
            string fullids = "";
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@Ename",ename),
                new SqlParameter("@id",id)
            };

            using (SqlDataReader reader = XYECOM.Core.Data.SqlHelper.ExecuteReader(CommandType.StoredProcedure, "usp_SelectGetFullid", param))
            {
                if (reader.Read())
                {
                    fullids = reader["fullid"].ToString();
                }
                return fullids;
            }

        }
    }
}
