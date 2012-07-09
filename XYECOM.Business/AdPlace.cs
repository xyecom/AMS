using System;
using System.Collections.Generic;
using System.Text;

using System.Data;


namespace XYECOM.Business {
    
    /// <summary>
    /// ���λҵ����
    /// </summary>
	public class AdPlace
	{
        private static readonly XYECOM.SQLServer.AdPlace DAL = new XYECOM.SQLServer.AdPlace();
		  /// <summary>
		  /// ��ӹ��λ
		  /// </summary>
		  /// <param name="ap">���λ������</param>
		  /// <returns>��Ӱ������</returns>
        public int Insert(XYECOM.Model.AdPlaceInfo ap)
        {
            return DAL.Insert(ap);
        }
        /// <summary>
        /// �޸�ָ���Ĺ��λ��Ϣ
        /// </summary>
        /// <param name="ap">�ù��λ����</param>
        /// <returns>���֣����ڻ����0��ʾ�޸ĳɹ�</returns>
        public int Update(XYECOM.Model.AdPlaceInfo ap)
        {
            return DAL.Update(ap);
        }
		  /// <summary>
		  /// �õ����������Ĺ��Ϊ��Ϣ
		  /// </summary>
		  /// <param name="strWhere">�ض��Ĳ�������</param>
		  /// <param name="OrderBy">�ض�����������</param>
		  /// <returns>DataTable���͵Ĺ����Ϣ</returns>
		public DataTable GetDataTable(string strWhere ,string OrderBy) 
		{
            return DAL.GetDataTable(strWhere, OrderBy);
		}
		  /// <summary>
		  /// ɾ��ָ���Ĺ��λ
		  /// </summary>
		  /// <param name="AP_ID">ָ���Ĺ��λ���</param>
		  /// <returns>������Ӱ�������</returns>
		public int Delete(string  AP_ID) 
		{
            return DAL.Delete(AP_ID);
		}
         /// <summary>
         /// ����ָ�����λ������״̬
         /// </summary>
         /// <param name="AP_ID">ָ�����λ��ID</param>
         /// <param name="AP_IsUse">Ҫ���ĵĹ��λ״̬</param>
         /// <returns>���֣����ڻ����0����ĳɹ�</returns>
        public int UpdateForIsUse(int AP_ID, bool AP_IsUse)
        {
            return DAL.UpdateForIsUse(AP_ID,AP_IsUse);
        }
	}
	
}
