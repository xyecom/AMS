using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using XYECOM.Core.Data;
using XYECOM.Core;

namespace XYECOM.SQLServer
{
    /// <summary>
    /// ��λ���ݴ�����
    /// </summary>
    public class Post
    {
        /// <summary>
        /// ��ȡ����Id
        /// </summary>
        /// <param name="parentID">����Id</param>
        /// <returns></returns>
        private string GetFullID(int parentID)
        {
            string strFullIDs = "";

            XYECOM.Model.PostInfo info = GetItem(parentID);

            if (info == null) return "0";

            if (info.P_ParentID != 0)
            {
                strFullIDs = GetFullID(info.P_ParentID) + "," + info.P_ID.ToString() + strFullIDs;
            }
            else
            {
                strFullIDs = info.P_ID.ToString();
            }

            return strFullIDs;
        }
        /// <summary>
        /// ��Ӹ�λ��Ϣ
        /// </summary>
        /// <param name="enp">��λ��Ϣ���������</param>
        /// <returns>��Ӱ�������</returns>
        public int Insert(XYECOM.Model.PostInfo info)
        {
            string fullId = Core.Utils.AppendComma(GetFullID(info.P_ParentID));

            SqlParameter[] param = new SqlParameter[] 
            { 
                new SqlParameter("@P_Name",info.P_Name),
                new SqlParameter("@P_ParentID",info.P_ParentID),
                new SqlParameter("@FullId",fullId),
            };

            return SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "XYP_InsertPost", param);
        }

        /// <summary>
        /// �޸ĸ�λ��Ϣ
        /// </summary>
        /// <param name="enp">��λ��Ϣ���������</param>
        /// <returns>��Ӱ�������</returns>
        public int Update(XYECOM.Model.PostInfo info)
        {
            string fullId = Core.Utils.AppendComma(GetFullID(info.P_ParentID));

            SqlParameter[] param = new SqlParameter[] 
            { 
                new SqlParameter("@P_Name",info.P_Name),
                new SqlParameter("@P_ParentID",info.P_ParentID),
                new SqlParameter("@P_ID",info.P_ID),
                new SqlParameter("@FullId",fullId),
            };

            return SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "XYP_UpdatePost", param);
        }

        /// <summary>
        /// ɾ����λ��Ϣ
        /// </summary>
        /// <param name="P_ID">��λ���</param>
        /// <returns>��Ӱ�������</returns>
        public int Delete(int P_ID)
        {
            SqlParameter[] param = new SqlParameter[] 
            { 
                new SqlParameter("@strwhere","where P_ID="+P_ID.ToString()),
                new SqlParameter("@strTableName","b_Post")
            };

            return XYECOM.Core.Data.SqlHelper.DeleteByWhere("usp_DeleteByWhere", param);
        }

        /// <summary>
        /// ɾ�������λ��¼
        /// </summary>
        /// <param name="P_IDs">��¼Id�ַ���,����ö��Ÿ���</param>
        /// <returns>��Ӱ������</returns>
        public int Delete(string P_IDs)
        {
            SqlParameter[] param = new SqlParameter[] 
            { 
                new SqlParameter("@strwhere","where P_ID in ( "+P_IDs+ " )"),
                new SqlParameter("@strTableName","b_Post")
            };

            return XYECOM.Core.Data.SqlHelper.DeleteByWhere("usp_DeleteByWhere", param);
        }

        /// <summary>
        /// ��ȡָ����λ��Ϣ
        /// </summary>
        /// <param name="P_ID">��λ��Ϣ���</param>
        /// <returns>��λ��Ϣ���������</returns>
        public XYECOM.Model.PostInfo GetItem(int P_ID)
        {
            SqlParameter[] param = new SqlParameter[] 
            { 
                new SqlParameter("@strWhere","Where P_ID=" + P_ID.ToString()),
                new SqlParameter("@strTableName","b_Post"),
                new SqlParameter("@strOrder","")
            };

            XYECOM.Model.PostInfo enp = null;

            using (SqlDataReader dr = XYECOM.Core.Data.SqlHelper.ExecuteReader(CommandType.StoredProcedure, "XYP_SelectByWhere", param))
            {
                if (dr.Read())
                {
                    enp = new XYECOM.Model.PostInfo();

                    enp.P_ID = Convert.ToInt32(dr["P_ID"].ToString());
                    enp.P_Name = dr["P_Name"].ToString();
                    enp.P_ParentID = Convert.ToInt32(dr["P_ParentID"].ToString());
                    enp.FullId = dr["FullID"].ToString();
                    enp.InfoCount = Core.MyConvert.GetInt32(dr["InfoCount"].ToString());
                }
            }

            return enp;
        }

        /// <summary>
        /// ��ȡָ������Id�µ����м�¼
        /// </summary>
        /// <param name="P_ParentID">����Id</param>
        /// <returns>���ݱ����</returns>
        public DataTable GetDataTableForParentID(int P_ParentID)
        {
            string WhereClause = "";

            if (P_ParentID >= 0)
            {
                WhereClause = "Where P_ParentID=" + P_ParentID.ToString();
            }

            SqlParameter[] param = new SqlParameter[] 
            { 
                new SqlParameter("@strWhere",WhereClause),
                new SqlParameter("@strTableName","b_Post"),
                new SqlParameter("@strOrder","")
            };

            return XYECOM.Core.Data.SqlHelper.ExecuteTable(CommandType.StoredProcedure, "XYP_SelectByWhere", param);
        }

        /// <summary>
        /// ��ȡ���ݱ�
        /// </summary>
        /// <param name="P_ID">��λ��¼Id</param>
        /// <returns>���ݱ�</returns>
        public DataTable GetDataTable(int P_ID)
        {
            SqlParameter[] param = new SqlParameter[] 
            { 
                new SqlParameter("@strWhere"," where P_ID="+P_ID .ToString ()),
                new SqlParameter("@strTableName","b_Post"),
                new SqlParameter("@strOrder","")
            };

            return XYECOM.Core.Data.SqlHelper.ExecuteTable(CommandType.StoredProcedure, "XYP_SelectByWhere", param);
        }

        /// <summary>
        /// ��ȡ�����¼
        /// </summary>
        /// <param name="ids">��¼id�ַ���������ö��Ÿ���</param>
        /// <returns>���ݱ�</returns>
        public DataTable GetDataTable(string ids)
        {
            SqlParameter[] param = new SqlParameter[] 
            { 
                new SqlParameter("@strWhere"," where P_ID in ("+ids+")"),
                new SqlParameter("@strTableName","b_Post"),
                new SqlParameter("@strOrder","")
            };

            return XYECOM.Core.Data.SqlHelper.ExecuteTable(CommandType.StoredProcedure, "XYP_SelectByWhere", param);
        }
    }
}
