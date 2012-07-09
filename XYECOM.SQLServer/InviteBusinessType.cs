using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using XYECOM.Model;

namespace XYECOM.SQLServer
{
    /// <summary>
    /// ���̼��˷������ݴ�����
    /// </summary>
    public class InviteBusinessType
    {
        /// <summary>
        /// ��ȡ����Id
        /// </summary>
        /// <param name="parentID"></param>
        /// <returns></returns>
        private string GetFullID(long parentID)
        {
            string strFullIDs = "";

            XYECOM.Model.InviteBusinessTypeInfo info = GetItem(parentID);

            if (info == null) return "0";

            if (info.IT_ParentID != 0)
            {
                strFullIDs = GetFullID(info.IT_ParentID) + "," + info.IT_ID.ToString() + strFullIDs;
            }
            else
            {
                strFullIDs = info.IT_ID.ToString();
            }

            return strFullIDs;
        }

        /// <summary> 
        /// ���һ���µ����̴���������
        /// </summary>
        /// <param name="ct">Ҫ��ӵ����̴���������</param>
        /// <returns>����,���ڻ����0��ɹ�,�����ʧ��,-1��������ͬ���</returns>
        public int Insert(InviteBusinessTypeInfo info)
        {
            string fullId = Core.Utils.AppendComma(GetFullID(info.IT_ParentID));

            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@IT_Name",info.IT_Name),
                new SqlParameter("@IT_ParentID",info.IT_ParentID),
                new SqlParameter("@ModuleName",info.ModuleName),
                new SqlParameter("@FullId",fullId)
            };

            return XYECOM.Core.Data.SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "XYP_InsertInviteBusinessType", param);
        }

        /// <summary>
        /// ����ָ�������̴���������
        /// </summary>
        /// <param name="ct">Ҫ���ĵ����̴���������</param>
        /// <returns>����,���ڻ����0��ɹ�,�����ʧ��</returns>
        public int Update(InviteBusinessTypeInfo info)
        {
            string fullId = Core.Utils.AppendComma(GetFullID(info.IT_ParentID));

            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@IT_ID",info.IT_ID),
                new SqlParameter("@IT_Name",info.IT_Name),
                new SqlParameter("@ModuleName",info.ModuleName),
                new SqlParameter("@IT_ParentID",info.IT_ParentID),
                new SqlParameter("@FullId",fullId),
            };

            return XYECOM.Core.Data.SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "XYP_UpdateInviteBusinessType", param);
        }

        /// <summary>
        /// ɾ��ָ����ŵ����̴������
        /// </summary>
        /// <param name="ctids">Ҫɾ�������̴�������ż�</param>
        /// <returns>����,���ڻ����0��ɹ�</returns>
        public int Delete(string itids)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@strWhere"," where IT_ID in ("+itids+")"),
                new SqlParameter("@strTableName","i_InviteBusinessType")
            };

            return XYECOM.Core.Data.SqlHelper.DeleteByWhere("usp_DeleteByWhere", param);
        }

        /// <summary>
        /// ��ȡָ����ŵ����̴���������
        /// </summary>
        /// <param name="infoid">Ҫ��ȡ�����̴���������ı��</param>
        /// <returns>�ñ���µ����̴���������</returns>
        public InviteBusinessTypeInfo GetItem(long infoid)
        {
            InviteBusinessTypeInfo info = null;
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@strWhere"," where IT_ID ="+infoid.ToString()),
                new SqlParameter("@strTableName","i_InviteBusinessType"),
                new SqlParameter("@strOrder","")
            };
            using (SqlDataReader dr = XYECOM.Core.Data.SqlHelper.ExecuteReader(CommandType.StoredProcedure, "XYP_SelectByWhere", param))
            {
                if (dr.Read())
                    info = new InviteBusinessTypeInfo(Convert.ToInt64(dr["IT_ID"]), dr["IT_Name"].ToString(), Convert.ToInt64(dr["IT_ParentID"]), dr["ModuleName"].ToString(), dr["FullId"].ToString(), Core.MyConvert.GetInt32(dr["InfoCount"].ToString()));
            }

            return info;
        }

        /// <summary>
        /// ��ȡ����ָ�����������̴���������
        /// </summary>
        /// <param name="strWhere">ָ����where����</param>
        /// <param name="strOrder">ָ����order����</param>
        /// <returns>����ָ�����������̴���������</returns>
        public DataTable GetDataTable(string strWhere, string strOrder)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@strWhere",strWhere),
                new SqlParameter("@strTableName","i_InviteBusinessType"),
                new SqlParameter("@strOrder","")
            };

            return XYECOM.Core.Data.SqlHelper.GetDataTable("XYP_SelectByWhere", param);
        }

        /// <summary>
        /// �ж�ָ������������Ƿ��������
        /// </summary>
        /// <param name="infoId">Ҫ�ж��Ƿ�������������ż�</param>
        /// <returns>����,����0��������,�����������</returns>
        public int IsHaveSonType(string infoId)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@strWhere"," where IT_ParentID in ("+infoId+")"),
                new SqlParameter("@strField"," IT_ID "),
                new SqlParameter("@strTable","i_InviteBusinessType"),
                new SqlParameter("@strCount",SqlDbType.BigInt)
            };

            param[3].Direction = ParameterDirection.Output;
            int result = XYECOM.Core.Data.SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "[" + "XYP_GetRecordCount" + "]", param);

            if (param[3] != null)
                result = Convert.ToInt32(param[3].Value.ToString());

            return result;
        }

        /// <summary>
        /// �������̴��������Ż�ȡ������������
        /// </summary>
        /// <param name="infoId">Ҫ��ȡ���Ƶ����̴������ı��</param>
        /// <returns>����������</returns>
        public string GetInviteBusinessTypeName(long infoId)
        {
            InviteBusinessTypeInfo ibt = GetItem(infoId);

            if (!object.Equals(null, ibt))
                return ibt.IT_Name;
            else
                return "";
        }
    }
}
