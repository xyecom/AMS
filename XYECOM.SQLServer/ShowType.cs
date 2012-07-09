using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using XYECOM.Model;

namespace XYECOM.SQLServer
{
    /// <summary>
    /// չ�����L���ݴ�����
    /// </summary> 
    public class ShowType
    {
        /// <summary>
        /// ��ȡ����id
        /// </summary>
        /// <param name="parentID"></param>
        /// <returns></returns>
        private string GetFullID(long parentID)
        {
            string strFullIDs = "";

            XYECOM.Model.ShowTypeInfo info = GetItem(parentID);

            if (info == null) return "0";

            if (info.SHT_ParentID != 0)
            {
                strFullIDs = GetFullID(info.SHT_ParentID) + "," + info.SHT_ID.ToString() + strFullIDs;
            }
            else
            {
                strFullIDs = info.SHT_ID.ToString();
            }

            return strFullIDs;
        }

        /// <summary>
        /// ���һ���µĺ�����Ϣ������
        /// </summary>
        /// <param name="ct">Ҫ��ӵĺ�����Ϣ������</param>
        /// <returns>����,���ڻ����0��ɹ�,�����ʧ��,-1��������ͬ���</returns>
        public int Insert(ShowTypeInfo info)
        {
            string fullId = Core.Utils.AppendComma(GetFullID(info.SHT_ParentID));

            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@SHT_Name",info.SHT_Name),
                new SqlParameter("@SHT_ParentID",info.SHT_ParentID),
                new SqlParameter("@FullId",fullId)
            };

            return XYECOM.Core.Data.SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "XYP_InsertShowType", param);
        }

        /// <summary>
        /// ����ָ���ĺ�����Ϣ������
        /// </summary>
        /// <param name="ct">Ҫ���ĵĺ�����Ϣ������</param>
        /// <returns>����,���ڻ����0��ɹ�,�����ʧ��</returns>
        public int Update(ShowTypeInfo info)
        {
            string fullId = Core.Utils.AppendComma(GetFullID(info.SHT_ParentID));

            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@SHT_ID",info.SHT_ID),
                new SqlParameter("@SHT_Name",info.SHT_Name),
                new SqlParameter("@SHT_ParentID",info.SHT_ParentID),
                new SqlParameter("@FullId",fullId),
            };

            return XYECOM.Core.Data.SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "XYP_UpdateShowType", param);
        }

        /// <summary>
        /// ɾ��ָ����ŵĺ������
        /// </summary>
        /// <param name="ctids">Ҫɾ���ĺ�������ż�</param>
        /// <returns>����,���ڻ����0��ɹ�</returns>
        public int Delete(string shtids)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@strWhere"," where SHT_ID in ("+shtids+")"),
                new SqlParameter("@strTableName","i_ShowType")
            };

            return XYECOM.Core.Data.SqlHelper.DeleteByWhere("usp_DeleteByWhere", param);
        }

        /// <summary>
        /// ��ȡָ����ŵĺ���������
        /// </summary>
        /// <param name="ctid">Ҫ��ȡ�ĺ���������ı��</param>
        /// <returns>�ñ���µĺ���������</returns>
        public ShowTypeInfo GetItem(Int64 shtid)
        {
            ShowTypeInfo info = null;

            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@strWhere"," where SHT_ID ="+shtid.ToString()),
                new SqlParameter("@strTableName","i_ShowType"),
                new SqlParameter("@strOrder","")
            };

            using (SqlDataReader dr = XYECOM.Core.Data.SqlHelper.ExecuteReader(CommandType.StoredProcedure, "XYP_SelectByWhere", param))
            {
                if (dr.Read())
                    info = new ShowTypeInfo(
                        Convert.ToInt64(dr["SHT_ID"]), 
                        dr["SHT_Name"].ToString(), 
                        Convert.ToInt64(dr["SHT_ParentID"]),
                        dr["FullId"].ToString(),
                        Core.MyConvert.GetInt32(dr["InfoCount"].ToString())
                        );
            }

            return info;
        }

        /// <summary>
        /// ��ȡ����ָ�������ĺ���������
        /// </summary>
        /// <param name="strWhere">ָ����where����</param>
        /// <param name="strOrder">ָ����order����</param>
        /// <returns>����ָ�������ĺ���������</returns>
        public DataTable GetDataTable(string strWhere, string Order)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@strWhere",strWhere),
                new SqlParameter("@strTableName","i_ShowType"),
                new SqlParameter("@strOrder","")
            };

            return XYECOM.Core.Data.SqlHelper.GetDataTable("XYP_SelectByWhere", param);
        }

        /// <summary>
        /// �ж�ָ������������Ƿ��������
        /// </summary>
        /// <param name="ctid">Ҫ�ж��Ƿ��������������</param>
        /// <returns>����,����0��������,�����������</returns>
        public int IsHaveSonType(string shtid)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@strWhere"," where SHT_ParentID in ("+shtid+")"),
                new SqlParameter("@strField"," SHT_ID "),
                new SqlParameter("@strTable","i_ShowType"),
                new SqlParameter("@strCount",SqlDbType.BigInt)
            };

            param[3].Direction = ParameterDirection.Output;

            int result = XYECOM.Core.Data.SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "[" + "XYP_GetRecordCount" + "]", param);

            if (param[3] != null)
                result = Convert.ToInt32(param[3].Value.ToString());

            return result;
        }

        /// <summary>
        /// ���ݺ�����Ϣ������Ż�ȡ������������
        /// </summary>
        /// <param name="ctid">Ҫ��ȡ���Ƶĺ������ı��</param>
        /// <returns>����������</returns>
        public string GetCooperateTypeName(Int64 shtid)
        {
            ShowTypeInfo shti = GetItem(shtid);

            if (!object.Equals(null, shti))
                return shti.SHT_Name;
            else
                return "";
        }
    }
}
