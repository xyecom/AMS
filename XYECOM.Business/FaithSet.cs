using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using XYECOM.Model;

namespace XYECOM.Business
{
    /// <summary>
    /// �ؼ���ҵ����
    /// </summary>
    public class FaithSet
    {
        /// <summary>
        /// ʹ�ó��󹤳����ɹؼ��ֵ�DAL
        /// </summary>
        private static readonly XYECOM.SQLServer.FaithSet DAL = new XYECOM.SQLServer.FaithSet();

        /// <summary>
        /// ����¹ؼ��ֵĳ��󷽷�
        /// </summary>
        /// <param name="ki">Ҫ��ӵĹؼ��ֶ���</param>
        /// <returns>����,���ڻ����0����ӳɹ�
        /// -1���Ѵ�����ͬ��¼,-2�����ʧ��</returns>
        public int Insert(FaithSetInfo fsi)
        {
            return DAL.Insert(fsi);
        }

        /// <summary>
        /// �޸�ָ���Ĺؼ��ֶ���ĳ��󷽷�
        /// </summary>
        /// <param name="ki">Ҫ�޸ĵĹؼ��ֶ���</param>
        /// <returns>����,���ڻ����0��ɹ�
        /// -1�������޸�(�ùؼ������ھ���),-2���޸�ʧ��</returns>
        public int Update(FaithSetInfo fsi)
        {
            return DAL.Update(fsi);
        }


        /// <summary>
        /// ɾ��ָ���ؼ��ֱ�ż��ĳ��󷽷�
        /// </summary>
        /// <param name="kiids">Ҫɾ���Ĺؼ��ֱ�ż�</param>
        /// <returns>����,���ڻ����0��ɾ���ɹ�</returns>
        public int Delete(string kiids)
        {
            if (string.IsNullOrEmpty(kiids))
                return -2;

            return DAL.Delete(kiids);
        }

        /// <summary>
        /// ��ȡ����ָ�������ĳ���ָ������ĳ��󷽷�
        /// </summary>
        /// <param name="strWhere">ָ����strWhere����</param>
        /// <param name="strOrderBy">ָ����OrderBy����</param>
        /// <returns>������������ĳ���ָ����������ݼ�</returns>
        public DataTable GetDataTable()
        {
            return DAL.GetDataTable();
        }
    }
}
