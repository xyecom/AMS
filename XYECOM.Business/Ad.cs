using System;
using System.Collections.Generic;
using System.Text;

using System.Data;


namespace XYECOM.Business
{
    /// <summary>
    /// ƽ̨��洦��ҵ����
    /// </summary>
    public class Ad
    {
        private static readonly XYECOM.SQLServer.Ad DAL = new XYECOM.SQLServer.Ad();

        /// <summary>
        /// ��ӹ������Ϣ
        /// </summary>
        /// <param name="ad">Ҫ��ӵĹ��������</param>
        /// <returns>���֣����ڻ����0����ӳɹ�</returns>
        public int Insert(XYECOM.Model.AdInfo ad, out int AD_ID)
        {
            return DAL.Insert(ad, out AD_ID);
        }
        /// <summary>
        /// �޸�ָ���Ĺ������Ϣ����
        /// </summary>
        /// <param name="ad">��Ҫ�޸ĵĹ��������</param>
        /// <returns>���֣����ڻ����0����ӳɹ�</returns>
        public int Update(XYECOM.Model.AdInfo ad)
        {
            return DAL.Update(ad);
        }
        /// <summary>
        /// ɾ��ָ���Ĺ��
        /// </summary>
        /// <param name="adid">ָ�����ı��</param>
        /// <returns>��Ӱ�������</returns>
        public int Delete(string adid)
        {
            return DAL.Delete(adid);
        }
        /// <summary>
        /// �õ�ָ��������DataTable���͵Ĺ��
        /// </summary>
        /// <param name="strWhere">ָ����where��ѯ����</param>
        /// <param name="strOrderBy">ָ������������</param>
        /// <returns>����������DataTable���͵Ĺ���¼</returns>
        public DataTable GetDataTable(string strWhere, string strOrderBy)
        {
            return DAL.GetDataTable(strWhere, strOrderBy);   
        }
        /// <summary>
        /// ����ָ�������������״̬
        /// </summary>
        /// <param name="AP_ID">ָ�����λ��ID</param>
        /// <param name="AP_IsUse">Ҫ���ĵĹ��λ״̬</param>
        /// <returns>���֣����ڻ����0����ĳɹ�</returns>
        public int UpdateForIsUse(string AD_IDs, bool AD_Isuse)
        {
            return DAL.UpdateForIsUse(AD_IDs, AD_Isuse);
        }
    }
}