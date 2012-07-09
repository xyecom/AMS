using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using XYECOM.Model;

namespace XYECOM.Business
{
    /// <summary>
    /// �������Ѽ�¼ҵ����
    /// </summary>
    public class FictitiouConsumption
    {
        /// <summary>
        /// ʹ�ó��󹤳������������Ѽ�¼��DAL
        /// </summary>
        private static readonly XYECOM.SQLServer.FictitiouConsumption DAL = new XYECOM.SQLServer.FictitiouConsumption();

        /// <summary>
        /// ����µ��������Ѽ�¼����
        /// </summary>
        /// <param name="aci">Ҫ��ӵ��µ��������Ѽ�¼����</param>
        /// <returns>����,���ڻ����0��ɹ�,�����ʧ��</returns>
        public int Insert(FictitiouConsumptionInfo fci)
        {
            if (object.Equals(null, fci))
                throw new Exception("The Object is Null");

            return DAL.Insert(fci);
        }

        /// <summary>
        /// ��ȡָ����ŵ��������Ѽ�¼����
        /// </summary>
        /// <param name="acid">Ҫ��ȡ���������Ѽ�¼����ı��</param>
        /// <returns>�ñ���¶�Ӧ�����Ѷ���</returns>
        public FictitiouConsumptionInfo GetItem(Int64 fcid)
        {
            if (fcid <= 0)
                throw new Exception("The ID is Error");

            return DAL.GetItem(fcid);
        }

        /// <summary>
        /// ��ȡ����ָ���������������Ѷ���
        /// </summary>
        /// <param name="strWhere">ָ����where����</param>
        /// <param name="Order">ָ����order����</param>
        /// <returns>����ָ���������������Ѷ���</returns>
        public DataTable GetDataTable(string where, string order)
        {
            if (string.IsNullOrEmpty(where) || string.IsNullOrEmpty(order))
                throw new Exception("The where or order is Error");

            return DAL.GetDataTable(where, order);
        }
    }
}
