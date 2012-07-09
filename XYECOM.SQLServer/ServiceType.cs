using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using XYECOM.Model;

namespace XYECOM.SQLServer
{
    /// <summary>
    /// ������Ϣ�������ݴ�����
    /// </summary>
    public class ServiceType
    {
        /// <summary>
        /// ��ȡ����Id
        /// </summary>
        /// <param name="parentID"></param>
        /// <returns></returns>
        private string GetFullID(long parentID)
        {
            string strFullIDs = "";

            XYECOM.Model.ServiceTypeInfo info = GetItem(parentID);

            if (info == null) return "0";

            if (info.ST_ParentID != 0)
            {
                strFullIDs = GetFullID(info.ST_ParentID) + "," + info.ST_ID.ToString() + strFullIDs;
            }
            else
            {
                strFullIDs = info.ST_ID.ToString();
            }

            return strFullIDs;
        }

        /// <summary> 
        /// ���һ���µķ�����Ϣ������
        /// </summary>
        /// <param name="ct">Ҫ��ӵķ�����Ϣ������</param>
        /// <returns>����,���ڻ����0��ɹ�,�����ʧ��,-1��������ͬ���</returns>
        public int Insert(ServiceTypeInfo info)
        {
            string fullId = Core.Utils.AppendComma(GetFullID(info.ST_ParentID));

            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@ST_Name",info.ST_Name),
                new SqlParameter("@ST_ParentID",info.ST_ParentID),
                new SqlParameter("@ModuleName",info.ModuleName),
                new SqlParameter("@FullId",fullId),
            };

            return XYECOM.Core.Data.SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "XYP_InsertServiceType", param);
        }

        /// <summary>
        /// ����ָ���ķ�����Ϣ������
        /// </summary>
        /// <param name="ct">Ҫ���ĵķ�����Ϣ������</param>
        /// <returns>����,���ڻ����0��ɹ�,�����ʧ��</returns>
        public int Update(ServiceTypeInfo info)
        {
            string fullId = Core.Utils.AppendComma(GetFullID(info.ST_ParentID));

            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@ST_ID",info.ST_ID),
                new SqlParameter("@ST_Name",info.ST_Name),
                new SqlParameter("@ModuleName",info.ModuleName),
                new SqlParameter("@ST_ParentID",info.ST_ParentID),
                new SqlParameter("@FullId",fullId),
            };

            return XYECOM.Core.Data.SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "XYP_UpdateServiceType", param);
        }

        /// <summary>
        /// ɾ��ָ����ŵķ������
        /// </summary>
        /// <param name="ctids">Ҫɾ���ķ�������ż�</param>
        /// <returns>����,���ڻ����0��ɹ�</returns>
        public int Delete(string stids)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@strWhere"," where ST_ID in ("+stids+")"),
                new SqlParameter("@strTableName","i_ServiceType")
            };

            return XYECOM.Core.Data.SqlHelper.DeleteByWhere("usp_DeleteByWhere", param);
        }

        /// <summary>
        /// ��ȡָ����ŵķ���������
        /// </summary>
        /// <param name="ctid">Ҫ��ȡ�ķ���������ı��</param>
        /// <returns>�ñ���µķ���������</returns>
        public ServiceTypeInfo GetItem(Int64 stid)
        {
            ServiceTypeInfo sti = null;

            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@strWhere"," where ST_ID ="+stid.ToString()),
                new SqlParameter("@strTableName","i_ServiceType"),
                new SqlParameter("@strOrder","")
            };

            using (SqlDataReader dr = XYECOM.Core.Data.SqlHelper.ExecuteReader(CommandType.StoredProcedure, "XYP_SelectByWhere", param))
            {
                if (dr.Read())
                    sti = new ServiceTypeInfo(
                        Convert.ToInt64(dr["ST_ID"]), 
                        dr["ST_Name"].ToString(), 
                        Convert.ToInt64(dr["ST_ParentID"]),  
                        dr["ModuleName"].ToString(),
                        dr["FullId"].ToString(),
                        Core.MyConvert.GetInt32(dr["InfoCount"].ToString())    
                        );
            }

            return sti;
        }

        /// <summary>
        /// ��ȡ����ָ�������ķ���������
        /// </summary>
        /// <param name="strWhere">ָ����where����</param>
        /// <param name="strOrder">ָ����order����</param>
        /// <returns>����ָ�������ķ���������</returns>
        public DataTable GetDataTable(string strWhere, string strOrder)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@strWhere",strWhere),
                new SqlParameter("@strTableName","i_ServiceType"),
                new SqlParameter("@strOrder","")
            };

            return XYECOM.Core.Data.SqlHelper.GetDataTable("XYP_SelectByWhere", param);
        }
        /// <summary>
        /// �ж�ָ���ķ�����������Ƿ��������
        /// </summary>
        /// <param name="ctid">Ҫ�ж��Ƿ�������������ż�</param>
        /// <returns>����,����0��������,�����������</returns>
        public int IsHaveSonType(string stid)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@strWhere"," where ST_ParentID in ("+stid+")"),
                new SqlParameter("@strField"," ST_ID "),
                new SqlParameter("@strTable","i_ServiceType"),
                new SqlParameter("@strCount",SqlDbType.BigInt)
            };

            param[3].Direction = ParameterDirection.Output;

            int result = XYECOM.Core.Data.SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "[" + "XYP_GetRecordCount" + "]", param);

            if (param[3] != null)
                result = Convert.ToInt32(param[3].Value.ToString());

            return result;
        }

        /// <summary>
        /// ���ݷ�����Ϣ������Ż�ȡ������������
        /// </summary>
        /// <param name="ctid">Ҫ��ȡ���Ƶķ������ı��</param>
        /// <returns>����������</returns>
        public string GetServiceTypeName(Int64 stid)
        {
            ServiceTypeInfo sti = GetItem(stid);

            if (!object.Equals(null, sti))
                return sti.ST_Name;
            else
                return "";
        }
    }
}
