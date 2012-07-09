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
    public class ChargeNews
    {
        /// <summary>
        /// ����µ��շ���Ϣ����
        /// </summary>
        /// <param name="cn">Ҫ��ӵ��շ���Ϣ����</param>
        /// <returns>����,���ڻ����0��ɹ�,�����ʧ��</returns>
        public int Insert(ChargeNewsInfo info)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@U_ID",info.U_ID),
                new SqlParameter("@NS_ID",info.NS_ID)
            };

            return XYECOM.Core.Data.SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "XYP_InsertChargeNewsInfo", param);
        }

        /// <summary>
        /// ɾ��ָ�����շ���Ϣ����
        /// </summary>
        /// <param name="ids">Ҫɾ�����շ���Ϣ�����ż�</param>
        /// <returns>����,���ڻ����0��ɹ�,�����ʧ��</returns>
        public int Delete(string ids)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@strWhere"," where CI_ID in ("+ids+")"),
                new SqlParameter("@strTableName","n_ChargeNewsInfo")
            };

            return XYECOM.Core.Data.SqlHelper.DeleteByWhere("usp_DeleteByWhere", param);
        }

        /// <summary>
        /// ��ȡ����ָ���������շ���Ϣ��
        /// </summary>
        /// <param name="strWhere">ָ����Where����</param>
        /// <param name="Order">ָ����Order����</param>
        /// <returns>����������DataTable��</returns>
        public DataTable GetDataTable(string strWhere, string Order)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@strWhere",strWhere),
                new SqlParameter("@strTableName","n_ChargeNewsInfo"),
                new SqlParameter("@strOrder",Order)
            };

            return XYECOM.Core.Data.SqlHelper.GetDataTable("XYP_SelectByWhere", param);
        }

        /// <summary>
        /// ��ȡָ����ŵ��շ���Ϣ����
        /// </summary>
        /// <param name="cnid">ָ�����շ���Ϣ������</param>
        /// <returns>�ñ���µ��շ���Ϣ����</returns>
        public ChargeNewsInfo GetItem(Int64 cnid)
        {
            ChargeNewsInfo chargenew = null;
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@strWhere","where CI_ID="+cnid.ToString()),
                new SqlParameter("@strTableName","n_ChargeNewsInfo"),
                new SqlParameter("@strOrder","")
            };

            using (SqlDataReader dr = XYECOM.Core.Data.SqlHelper.ExecuteReader(CommandType.StoredProcedure, "XYP_SelectByWhere", param))
            {
                if (dr.Read())
                    chargenew = new ChargeNewsInfo(Convert.ToInt64(dr["CI_ID"]), Convert.ToInt64(dr["U_ID"]), Convert.ToInt64(dr["NS_ID"]), Convert.ToDateTime(dr["CI_AddTime"]));
            }
            return chargenew;
        }

        /// <summary>
        /// �ж��û���ĳ�շ������Ƿ񸶹���
        /// </summary>
        /// <param name="uid">ָ�����û����</param>
        /// <param name="nsid">ָ�������ű��</param>
        /// <returns>bool��,false���Ѹ���,true��û����δ����</returns>
        public int GetIsCharged(Int64 uid, Int64 nsid, out int webmoney, out int money)
        {
                SqlParameter[] param = new SqlParameter[]
                {
                    new SqlParameter("@U_ID",uid),
                    new SqlParameter("@NS_ID",nsid),
                    new SqlParameter("@CN_ConsumeWebMoney",SqlDbType.Int),
                    new SqlParameter("@CN_ConsumeMoney",SqlDbType.Int),
                    new SqlParameter("@lue",SqlDbType.Int)
                };

                param[2].Direction = ParameterDirection.Output;
                param[3].Direction = ParameterDirection.Output;
                param[4].Direction = ParameterDirection.ReturnValue;

                object row = XYECOM.Core.Data.SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "XYP_IsChargedForNews", param);

                if (string.IsNullOrEmpty(param[2].Value.ToString()))
                    webmoney = 0;
                else
                    webmoney = Convert.ToInt32(param[2].Value.ToString());

                if (string.IsNullOrEmpty(param[3].Value.ToString()))
                    money = 0;
                else
                    money = Convert.ToInt32(param[3].Value.ToString());

                if (string.IsNullOrEmpty(param[4].Value.ToString()))
                    return -5; //���ѯ����
                else
                    return Convert.ToInt32(param[4].Value.ToString());
        }

        /// <summary>
        /// ָ�����û����ɸ������Ų���,�Ƚ��п۷�,Ȼ��������Ѽ�¼(�ֽ�,����)�����������Ÿ��Ѽ�¼
        /// </summary>
        /// <param name="uid">ָ�����û�</param>
        /// <param name="nsid">Ҫ���ѵ�����</param>
        /// <param name="webmoney">Ҫ���ɵ��������</param>
        /// <param name="money">Ҫ���ɵ��ֽ����</param>
        /// <returns>����,���ڻ����0��ɷѲ����ɹ�,-1������,-2��ɷ�ʧ��</returns>
        public int ConsumeUpdateMoney(Int64 uid, Int64 nsid, Decimal webmoney, Decimal money)
        {
            string AC_Explain = "֧���շ����ŵ��ֽ���ҽ��";
            string FC_Explain = "֧���շ����ŵ�������ҽ��";

            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@U_ID",uid),
                new SqlParameter("@NS_ID",nsid),
                new SqlParameter("@ConsumeFictitiouMoney",webmoney),
                new SqlParameter("@ConsumeAccountMoney",money),
                new SqlParameter("@AC_Explain",AC_Explain),
                new SqlParameter("@FC_Explain",FC_Explain)
            };

            return XYECOM.Core.Data.SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure,"XYP_UpdateConsumption", param);
        }
    }
}
