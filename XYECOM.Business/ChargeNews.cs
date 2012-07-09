using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using XYECOM.Model;

namespace XYECOM.Business
{
    /// <summary>
    /// �շ����ŵ��շ���Ϣ�߼���
    /// </summary>
    public class ChargeNews
    {
        // ͨ���ӿڹ�����������Ҫ����շ���Ϣ��
        private static readonly XYECOM.SQLServer.ChargeNews DAL = new XYECOM.SQLServer.ChargeNews();

        /// <summary>
        /// ����µ��շ���Ϣ����
        /// </summary>
        /// <param name="cn">Ҫ��ӵ��շ���Ϣ����</param>
        /// <returns>����,���ڻ����0��ɹ�,�����ʧ��</returns>
        public int Insert(ChargeNewsInfo ci)
        {
            if (object.Equals(null, ci))
                return -2;

            return DAL.Insert(ci);
        }

        /// <summary>
        /// ɾ��ָ�����շ���Ϣ����
        /// </summary>
        /// <param name="ids">Ҫɾ�����շ���Ϣ�����ż�</param>
        /// <returns>����,���ڻ����0��ɹ�,�����ʧ��</returns>
        public int Delete(string ciids)
        {
            if (string.IsNullOrEmpty(ciids))
                return -2;

            return DAL.Delete(ciids);
        }

        /// <summary>
        /// ��ȡ����ָ���������շ���Ϣ��
        /// </summary>
        /// <param name="strWhere">ָ����Where����</param>
        /// <param name="Order">ָ����Order����</param>
        /// <returns>����������DataTable��</returns>
        public DataTable GetDataTable(string strWhere, string Order)
        {
            DataTable dt = null;
            if (string.IsNullOrEmpty(strWhere))
                return dt;

            if (object.Equals(null, Order))
                Order = "";

            return DAL.GetDataTable(strWhere, Order);
        }

        /// <summary>
        /// ��ȡָ����ŵ��շ���Ϣ����
        /// </summary>
        /// <param name="cnid">ָ�����շ���Ϣ������</param>
        /// <returns>�ñ���µ��շ���Ϣ����</returns>
        public ChargeNewsInfo GetItem(Int64 cnid)
        {
            ChargeNewsInfo cninfo = null;
            if (cnid <= 0)
                return cninfo;

            return DAL.GetItem(cnid);
        }

        /// <summary>
        /// �ж��û���ĳ�շ������Ƿ񸶹���
        /// </summary>
        /// <param name="uid">ָ�����û����</param>
        /// <param name="nsid">ָ�������ű��</param>
        /// <returns>int��,����0���Ѹ���,������û����δ����</returns>
        public int GetIsCharged(Int64 uid, Int64 nsid, out int webmoney, out int money)
        {
            if (uid < 0 || nsid <= 0)
            {
                webmoney = 0;
                money = 0;
                return -5; // ��ʾ��ѯ����
            }

            return DAL.GetIsCharged(uid, nsid, out webmoney, out money);
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
            if (uid <= 0 || nsid <= 0)
                return -2;

            return DAL.ConsumeUpdateMoney(uid, nsid, webmoney, money);
        }
    }
}
