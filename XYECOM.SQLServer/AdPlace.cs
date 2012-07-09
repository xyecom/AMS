using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Data.SqlClient;
using XYECOM.Core.Data;
using XYECOM.Core;

namespace XYECOM.SQLServer {

	#region ���λ������
    /// <summary>
    /// ���λ���ݴ�����
    /// </summary>
	public class AdPlace
	{		
	      /// <summary>
	      /// ��ӹ��λ
	      /// </summary>
	      /// <param name="ap">���λ������</param>
	      /// <returns>��Ӱ������</returns>
        public int Insert(XYECOM.Model.AdPlaceInfo ap)
        {
            SqlParameter[] param = new SqlParameter[] 
			{
			    new SqlParameter("@AP_Name",ap.AP_Name),
				new SqlParameter("@AP_Alt",ap.AP_Alt),
                new SqlParameter("@AT_ID",ap.AT_ID),
                new SqlParameter("@AP_IsUse",ap.AP_IsUse)
			};

            int RowAfferent = SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "XYP_InsertAdPlace", param);

            return RowAfferent;
        }
        /// <summary>
        /// �޸�ָ���Ĺ��λ��Ϣ
        /// </summary>
        /// <param name="ap">�ù��λ����</param>
        /// <returns>���֣����ڻ����0��ʾ�޸ĳɹ�</returns>
        public int Update(XYECOM.Model.AdPlaceInfo ap)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@AP_ID",ap.AP_ID),
                new SqlParameter("@AP_Name",ap.AP_Name),
                new SqlParameter("@AP_Alt",ap.AP_Alt),
                new SqlParameter("@AT_ID",ap.AT_ID),
                new SqlParameter("@AP_IsUse",ap.AP_IsUse)
            };

            return SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "XYP_UpdateAdPlace", param);
        }
		  /// <summary>
		  /// �õ����������Ĺ��Ϊ��Ϣ
		  /// </summary>
		  /// <param name="strWhere">�ض��Ĳ�������</param>
		  /// <param name="OrderBy">�ض�����������</param>
		  /// <returns>DataTable���͵Ĺ����Ϣ</returns>
		public DataTable GetDataTable(string strWhere ,string OrderBy) 
		{
			SqlParameter [] param = new SqlParameter[]
			{
				new SqlParameter("@strWhere",strWhere),
				new SqlParameter("@strTableName","b_AdPlaceInfo"),
				new SqlParameter("@strOrder",OrderBy)
			};

			return XYECOM.Core.Data.SqlHelper.ExecuteTable(CommandType.StoredProcedure,"XYP_SelectByWhere", param);
		}
		  /// <summary>
		  /// ɾ��ָ���Ĺ��λ
		  /// </summary>
		  /// <param name="AP_ID">ָ���Ĺ��λ���</param>
		  /// <returns>������Ӱ�������</returns>
		public int Delete(string  AP_ID) 
		{
			SqlParameter[] param = new SqlParameter[]
			{
                new SqlParameter("@strWhere","where AP_ID in ("+AP_ID+")"),
				new SqlParameter("@strTableName","b_AdPlaceInfo")
			};

			return XYECOM.Core.Data.SqlHelper.DeleteByWhere("usp_DeleteByWhere", param);
		}
         /// <summary>
         /// ����ָ�����λ������״̬
         /// </summary>
         /// <param name="AP_ID">ָ�����λ��ID</param>
         /// <param name="AP_IsUse">Ҫ���ĵĹ��λ״̬</param>
         /// <returns>���֣����ڻ����0����ĳɹ�</returns>
        public int UpdateForIsUse(int AP_ID, bool AP_IsUse)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@AP_ID",AP_ID),
                new SqlParameter("@AP_IsUse",AP_IsUse)
            };

            return SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "XYP_UpdateAdPlaceForIsUse", param);
        }
	}
	#endregion
}
