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
    /// ��ҵ�������ݴ�����
    /// </summary>
    public class UserType:DataCache
    {
        /// <summary>
        /// ��ȡ��������
        /// </summary>
        /// <param name="parentID"></param>
        /// <returns></returns>
        private string GetFullID(long parentID)
        {
            string strFullIDs = "";

            XYECOM.Model.UserTypeInfo info = GetItem(parentID);

            if (info == null) return "0";

            if (info.UT_PID != 0)
            {
                strFullIDs = GetFullID(info.UT_PID) + "," + info.UT_ID.ToString() + strFullIDs;
            }
            else
            {
                strFullIDs = info.UT_ID.ToString();
            }

            return strFullIDs;
        }
        /// <summary>
        /// ����û�����
        /// </summary>
        /// <param name="eut">ʵ����</param>
        /// <returns>��Ӱ�������</returns>
        public int Insert(XYECOM.Model.UserTypeInfo info)
        {
            string fullId = Core.Utils.AppendComma(GetFullID(info.UT_PID));

            SqlParameter[] param = new SqlParameter[] 
            { 
                new SqlParameter("@UT_Type",info.UT_Type),
                new SqlParameter("@UT_PID",info.UT_PID),
                new SqlParameter("@UT_FullId",fullId)
            };

            int result =  SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "XYP_InsertUserType", param);

            UpdateCache();

            return result;
        }
        
        /// <summary>
        /// �޸��û�������Ϣ
        /// </summary>
        /// <param name="eut">ʵ����</param>
        /// <returns>��Ӱ�������</returns>
        public int Update(XYECOM.Model.UserTypeInfo info)
        {
            string fullId = Core.Utils.AppendComma(GetFullID(info.UT_PID));

            SqlParameter[] param = new SqlParameter[] 
            { 
                new SqlParameter("@UT_Type",info.UT_Type),
                new SqlParameter("@UT_PID",info.UT_PID),
                new SqlParameter("@UT_ID",info.UT_ID),
                new SqlParameter("@UT_FullID",fullId)
            };

            int result = SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "XYP_UpdateUserType", param);

            UpdateCache();

            return result;
        }
      
        /// <summary>
        /// ɾ��һ����¼
        /// </summary>
        /// <param name="UT_ID">��¼���</param>
        /// <returns>һ����¼</returns>
        public int Delete(long UT_ID)
        {
            SqlParameter[] param = new SqlParameter[] 
            { 
                new SqlParameter("@strwhere","where UT_ID="+UT_ID.ToString()),
                new SqlParameter("@strTableName","b_UserType")
            };

            int result = XYECOM.Core.Data.SqlHelper.DeleteByWhere("usp_DeleteByWhere", param);

            UpdateCache();

            return result;
        }

        /// <summary>
        /// ɾ��������¼
        /// </summary>
        /// <param name="UT_IDs">id�ַ���������ö��Ÿ���</param>
        /// <returns></returns>
        public int Delete(string UT_IDs)
        {
            SqlParameter[] param = new SqlParameter[] 
            { 
                new SqlParameter("@strwhere","where UT_ID in ("+UT_IDs.ToString() + ")"),
                new SqlParameter("@strTableName","b_UserType")
            };

            int result = XYECOM.Core.Data.SqlHelper.DeleteByWhere("usp_DeleteByWhere", param);

            UpdateCache();

            return result;
        }

        /// <summary>
        /// ��ȡһ����¼
        /// </summary>
        /// <param name="UT_ID">��¼���</param>
        /// <returns>һ����¼</returns>
        public XYECOM.Model.UserTypeInfo GetItem(long UT_ID)
        {
            XYECOM.Model.UserTypeInfo info = null;
            
            Object obj= GetCache();

            if (obj != null)
            {
                DataTable table = (DataTable)obj;

                DataRow[] rows = table.Select("UT_ID =" + UT_ID.ToString());

                if (rows != null && rows.Length > 0)
                {
                    info = new XYECOM.Model.UserTypeInfo();
                    info.UT_ID = Convert.ToInt64(rows[0]["UT_ID"].ToString());
                    info.UT_PID = Convert.ToInt64(rows[0]["UT_PID"].ToString());
                    info.UT_Type = rows[0]["UT_Type"].ToString();
                    info.UT_FullID = rows[0]["UT_FullID"].ToString();
                    info.UT_InfoCount = Core.MyConvert.GetInt32(rows[0]["UT_InfoCount"].ToString());
                }
            }

            return info;
        }

        /// <summary>
        /// ��ȡ��ҵ������Ϣ
        /// </summary>
        /// <param name="typeName">��������</param>
        /// <returns></returns>
        public XYECOM.Model.UserTypeInfo GetItem(string typeName)
        {
            XYECOM.Model.UserTypeInfo info = null;

            Object obj = GetCache();

            if (obj != null)
            {
                DataTable table = (DataTable)obj;

                DataRow[] rows = table.Select("UT_Type ='" + typeName +"'");

                if (rows != null && rows.Length > 0)
                {
                    info = new XYECOM.Model.UserTypeInfo();
                    info.UT_ID = Convert.ToInt64(rows[0]["UT_ID"].ToString());
                    info.UT_PID = Convert.ToInt64(rows[0]["UT_PID"].ToString());
                    info.UT_Type = rows[0]["UT_Type"].ToString();
                    info.UT_FullID = rows[0]["UT_FullID"].ToString();
                    info.UT_InfoCount = Core.MyConvert.GetInt32(rows[0]["UT_InfoCount"].ToString());
                }
            }

            return info;
        }

        /// <summary>
        /// ��ȡ�û�������Ϣ
        /// </summary>
        /// <param name="UT_PID">
        /// ��� UT_PID ���ڵ��� 0 ����һ����������Ϣ
        /// ���� ��������������Ϣ
        /// </param>
        /// <returns></returns>
        public DataTable GetDataTable(long userTypeId)
        {
            string where = "";

            if (userTypeId >= 0) where = " UT_PID=" + userTypeId.ToString();

            DataTable _table = new DataTable();
            
            Object obj= GetCache();

            if (obj != null)
            {
                DataTable table = (DataTable)obj;

                _table = table.Clone();

                DataRow[] rows = table.Select(where);

                if (rows != null && rows.Length > 0)
                {
                    foreach(DataRow row in rows)
                    {
                        _table.ImportRow(row);
                    }
                }
            }

            return _table;
        }

        public override string SQL_Get_All
        {
            get { return "select * from b_UserType"; }
        }
    }
}
