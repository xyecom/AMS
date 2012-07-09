using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Data.SqlClient;
using XYECOM.Model;

namespace XYECOM.SQLServer
{
    /// <summary>
    /// �շ���Ѷ���ݴ�����
    /// </summary>
    public class ChargeNewsSet
    {
        /// <summary>
        /// ���һ���µ��������ö���
        /// </summary>
        /// <param name="ci">Ҫ��ӵ��������ö���</param>
        /// <returns>����,���ڻ����0��ɹ�,����-1������ͬ����,������ʧ��</returns>
        public int Insert(ChargeNewsSetInfo ci)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@CN_VisitPopedom",ci.CN_VisitPopedom),
                new SqlParameter("@CN_ConsumeWebMoney",ci.CN_ConsumeWebMoney),
                new SqlParameter("@CN_ConsumeMoney",ci.CN_ConsumeMoney),
                new SqlParameter("@NS_ID",ci.NS_ID)
            };

            return XYECOM.Core.Data.SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "XYP_InsertChargeNews", param);
        }

        /// <summary>
        /// ����ָ���������ö���
        /// </summary>
        /// <param name="ci">Ҫ�޸ĵ��������ö���</param>
        /// <returns>����,���ڻ����0��ɹ�,�����ʧ��</returns>
        public int Update(ChargeNewsSetInfo ci)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@CN_ID",ci.CN_ID),
                new SqlParameter("@CN_VisitPopedom",ci.CN_VisitPopedom),
                new SqlParameter("@CN_ConsumeWebMoney",ci.CN_ConsumeWebMoney),
                new SqlParameter("@CN_ConsumeMoney",ci.CN_ConsumeMoney),
                new SqlParameter("@NS_ID",ci.NS_ID)
            };

            return XYECOM.Core.Data.SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure,"XYP_UpdateChargeNews", param);
        }

        /// <summary>
        /// ɾ��ָ����ż����շ���������
        /// </summary>
        /// <param name="newsIds">Ҫɾ�����շ����ű�ż�</param>
        /// <returns>����,���ڻ����0��ɹ�,�����ʧ��</returns>
        public int Delete(string newsIds)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@strWhere"," where NS_ID in ("+newsIds+")"),
                new SqlParameter("@strTableName","n_ChargeNewsSet")
            };

            return XYECOM.Core.Data.SqlHelper.DeleteByWhere("usp_DeleteByWhere", param);
        }

        /// <summary>
        /// ����Ա�ȼ�ɾ���շ������ʷ���Ϣ
        /// </summary>
        /// <param name="userGradeId"></param>
        /// <returns></returns>
        public int DeleteByUserGradeId(int userGradeId)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@strWhere"," where CN_VisitPopedom =" + userGradeId),
                new SqlParameter("@strTableName","n_ChargeNewsSet")
            };

            return XYECOM.Core.Data.SqlHelper.DeleteByWhere("usp_DeleteByWhere", param); 
        }

        /// <summary>
        /// ��ȡ����ָ���������շ��������ö���
        /// </summary>
        /// <param name="strWhere">ָ����Where����</param>
        /// <param name="Oder">ָ������������</param>
        /// <returns>����ָ���������շ��������ö���</returns>
        public DataTable GetDataTable(string strWhere, string Order)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@strWhere",strWhere),
                new SqlParameter("@strTableName","n_ChargeNewsSet"),
                new SqlParameter("@strOrder",Order)
            };

            return XYECOM.Core.Data.SqlHelper.GetDataTable("XYP_SelectByWhere", param);
        }

        /// <summary>
        /// ��ȡָ����ŵ��շ����Ŷ���
        /// </summary>
        /// <param name="ciid">ָ�����շ����ű��</param>
        /// <returns>�ñ�Ŷ�Ӧ���շ����Ŷ���</returns>
        public ChargeNewsSetInfo GetItem(Int64 ciid)
        {
            ChargeNewsSetInfo info = null;

            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@strWhere"," where CN_ID="+ciid.ToString()),
                new SqlParameter("@strTableName","n_ChargeNewsSet"),
                new SqlParameter("@strOrder","")
            };

            using (SqlDataReader dr = XYECOM.Core.Data.SqlHelper.ExecuteReader(CommandType.StoredProcedure, "XYP_SelectByWhere", param))
            {
                if (dr.Read())
                {
                    info = new ChargeNewsSetInfo();
                    info.NS_ID = Convert.ToInt64(dr["NS_ID"]);
                    info.CN_VisitPopedom = Convert.ToInt16(dr["CN_VisitPopedom"]);
                    info.CN_ConsumeWebMoney = Convert.ToInt32(dr["CN_ConsumeWebMoney"]);
                    info.CN_ConsumeMoney = Convert.ToInt32(dr["CN_ConsumeMoney"]);
                    info.CN_ID = Convert.ToInt64(dr["CN_ID"]);
                }
            }

            return info;
        }

        /// <summary>
        /// ��ȡָ����Ѷ��ź��û��ȼ����շ����Ŷ���
        /// </summary>
        /// <param name="newsId">����ID</param>
        /// <param name="userGaadeId">�ȼ�Id</param>
        /// <returns></returns>
        public ChargeNewsSetInfo GetItem(long newsId, int userGradeId)
        {
            ChargeNewsSetInfo info = null;

            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@strWhere"," where NS_ID="+newsId + "and CN_VisitPopedom=" + userGradeId),
                new SqlParameter("@strTableName","n_ChargeNewsSet"),
                new SqlParameter("@strOrder","")
            };

            using (SqlDataReader dr = XYECOM.Core.Data.SqlHelper.ExecuteReader(CommandType.StoredProcedure, "XYP_SelectByWhere", param))
            {
                if (dr.Read())
                {
                    info = new ChargeNewsSetInfo();
                    info.NS_ID = Convert.ToInt64(dr["NS_ID"]);
                    info.CN_VisitPopedom = Convert.ToInt16(dr["CN_VisitPopedom"]);
                    info.CN_ConsumeWebMoney = Convert.ToInt32(dr["CN_ConsumeWebMoney"]);
                    info.CN_ConsumeMoney = Convert.ToInt32(dr["CN_ConsumeMoney"]);
                    info.CN_ID = Convert.ToInt64(dr["CN_ID"]);
                }
            }

            return info;
        }

        /// <summary>
        /// ��ȡ����ָ���������ֶεļ���
        /// </summary>
        /// <param name="strWhere">ָ����Where����</param>
        /// <param name="Field">Ҫ��ȡ���ֶ�</param>
        /// <returns>�����������ֶεļ���</returns>
        public DataTable GetDataTableForField(string strWhere, string Field)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@strWhere",strWhere),
                new SqlParameter("@strTable","n_ChargeNewsSet"),
                new SqlParameter("@strField",Field)
            };

            return XYECOM.Core.Data.SqlHelper.GetDataTable("XYP_GetFieldByWhere", param);
        }
    }
}
