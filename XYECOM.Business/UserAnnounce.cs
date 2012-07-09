using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Data.SqlClient;

namespace XYECOM.Business
{
    /// <summary>
    /// ��վ����ҵ����
    /// </summary>
    public class UserAnnounce
    {

        private static readonly XYECOM.SQLServer.UserAnnounce DAL = new XYECOM.SQLServer.UserAnnounce();

        #region ��ӻ����һ����վ����
        /// <summary>
        /// ��ӻ����һ����վ����
        /// </summary>
        /// <param name="info">��վ����ʵ�����</param>
        /// <returns>Ӱ������</returns>
        public int InsertAndUpdate(XYECOM.Model.UserAnnounceInfo info)
        {
            if (info != null) return DAL.InsertAndUpdate(info);
            else return -1;
        }
        #endregion

        #region ɾ����վ����
        /// <summary>
        /// ɾ����վ����
        /// </summary>
        /// <param name="UA_IDs">���Id</param>
        /// <returns>Ӱ������</returns>
        public int Delete(string UA_IDs)
        {
            if (UA_IDs != null) return DAL.Delete(UA_IDs);
            else return -1;
        }
        #endregion

        #region ��ȡ��վ����
        /// <summary>
        /// ��ȡ��վ����
        /// </summary>
        /// <param name="UserID">�û����id</param>
        /// <returns>��վ����ʵ�����</returns>
        public XYECOM.Model.UserAnnounceInfo GetItem(long UserID)
        {
            if (UserID > 0)
            {
                return DAL.GetItem(UserID);
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// �������������վ������Ϣ
        /// </summary>
        /// <param name="strWhere">��ѯ����</param>
        /// <param name="strOrderBy">����</param>
        /// <returns>�����վ������Ϣ</returns>
        public DataTable GetDataTable(string strWhere, string strOrderBy)
        {
            if (strWhere != null) return DAL.GetDataTable(strWhere, strOrderBy);
            else return null;
        }
        #endregion

    }
}
