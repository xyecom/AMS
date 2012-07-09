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
    /// ���˹ؼ������ݴ�����
    /// </summary>
    public class FiltrateKeyWord:DataCache
    {
        /// <summary>
        /// �޸Ĺ�������Ϣ
        /// </summary>
        /// <param name="ef">ʵ����</param>
        /// <returns>��Ӱ�������</returns>
        public int Insert(XYECOM.Model.FiltrateKeyWordInfo ef)
        {
            SqlParameter[] param = new SqlParameter[] 
            {
                new SqlParameter("@FKW_Name",ef.FKW_Name) 
            };

            int result =  SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "XYP_InsertFiltrateKeyWord", param);

            UpdateCache();

            return result;
        }

        /// <summary>
        /// �޸Ĺ�������Ϣ
        /// </summary>
        /// <param name="ef">ʵ����</param>
        /// <returns>��Ӱ�������</returns>
        public int Update(XYECOM.Model.FiltrateKeyWordInfo ef)
        {
            SqlParameter[] param = new SqlParameter[] 
            {
               new SqlParameter ("@FKW_ID",ef .FKW_ID ),
                new SqlParameter ("@FKW_Name",ef .FKW_Name )
            };

            int result =  SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "XYP_UpdateFiltrateKeyWord", param);

            UpdateCache();

            return result;
        }

        /// <summary>
        /// ɾ��һ����¼
        /// </summary>
        /// <param name="FKW_ID">��¼���</param>
        /// <returns>��Ӱ�������</returns>
        public int Delete(int FKW_ID)
        {
            SqlParameter[] param = new SqlParameter[] 
            {
                new SqlParameter("@strwhere","where FKW_ID="+FKW_ID.ToString()),
                new SqlParameter("@strTableName","b_FiltrateKeyWord")
            };

            int result =  XYECOM.Core.Data.SqlHelper.DeleteByWhere("usp_DeleteByWhere", param);

            UpdateCache();

            return result;
        }


        /// <summary>
        /// ɾ��������¼
        /// </summary>
        /// <param name="FKW_ID">��¼���</param>
        /// <returns>��Ӱ�������</returns>
        public int Deletes(string FKW_ID)
        {
            SqlParameter[] param = new SqlParameter[] 
            {
                new SqlParameter("@strwhere","where FKW_ID in ("+FKW_ID .ToString ()+")"),
                new SqlParameter("@strTableName","b_FiltrateKeyWord")
            };

            int result =  XYECOM.Core.Data.SqlHelper.DeleteByWhere("usp_DeleteByWhere", param);

            UpdateCache();

            return result;
        }

        /// <summary>
        /// ��ȡһ����¼
        /// </summary>
        /// <param name="FKW_ID">��¼���</param>
        /// <returns>һ����¼</returns>
        public XYECOM.Model.FiltrateKeyWordInfo GetItem(int FKW_ID)
        {
            XYECOM.Model.FiltrateKeyWordInfo info = null;

            Object obj = GetCache();

            if (obj == null) return info;

            DataTable table = (DataTable)obj;

            DataRow[] rows = table.Select("FKW_ID =" + FKW_ID);

            if (rows != null && rows.Length > 0)
            {
                info = new XYECOM.Model.FiltrateKeyWordInfo();
                info.FKW_ID = Int32.Parse(rows[0]["FKW_ID"].ToString());
                info.FKW_Name = rows[0]["FKW_Name"].ToString();
            }

            return info;
        }

        /// <summary>
        /// ��ȡ���м�¼
        /// </summary>
        /// <returns>��¼��</returns>
        public DataTable GetDataTable()
        {
            Object obj = GetCache();

            if (obj == null) return new DataTable();

            DataTable table = (DataTable)obj;

            return table;
        }

        public override string SQL_Get_All
        {
            get { return "select * from b_FiltrateKeyWord"; }
        }
    }
}
