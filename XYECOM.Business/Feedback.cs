using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Data.SqlClient;

namespace XYECOM.Business
{
    /// <summary>
    /// �������ҵ����
    /// </summary>
    public class Feedback
    {

        private static readonly XYECOM.SQLServer.Feedback DAL = new XYECOM.SQLServer.Feedback();

        #region ����������
        /// <summary>
        /// ����������
        /// </summary>
        /// <param name="efl">����������������</param>
        /// <returns>���֡����ڵ���0��ʾ��ӳɹ�</returns>
        public int Insert(XYECOM.Model.FeedbackInfo info)
        {
            if (info != null) return DAL.Insert(info);
            else return -2;
        }
        #endregion

        #region ɾ�����������Ϣ
        /// <summary>
        /// ɾ�����������Ϣ
        /// </summary>
        /// <param name="FL_IDs">���������Ϣ����ַ���</param>
        /// <returns>���֡����ڵ���0��ʾɾ���ɹ�</returns>
        public int Delete(string FeedbackID)
        {
            if (FeedbackID != null) return DAL.Delete(FeedbackID);
            else return -1;
        }
        #endregion

        #region ��ȡ���������Ϣ
        /// <summary>
        /// ��ȡ���������Ϣ
        /// </summary>
        /// <param name="strWhere">����</param>
        /// <returns>���������Ϣ</returns>
        public DataTable GetDataTable(string strWhere)
        {
            if (strWhere != "") return DAL.GetDataTable(strWhere);
            else return new DataTable();;
        }
        /// <summary>
        /// ����һ�����������Ϣ
        /// </summary>
        /// <param name="FeedbackID">���������Ϣ���</param>
        /// <returns>���������Ϣʵ�����</returns>
        public XYECOM.Model.FeedbackInfo GetItem(long FeedbackID)
        {
            if (FeedbackID <= 0) return null;
            else return DAL.GetItem(FeedbackID);                   
        }

        /// <summary>
        /// ����һ�����������Ϣ
        /// </summary>
        /// <param name="FeedbackID">���������Ϣ���</param>
        /// <param name="IsAdminAgree">����Ա������ʶ</param>
        /// <returns>Ӱ������</returns>
        public int UpateItemById(int FeedbackID, int IsAdminAgree)
        {
            if (FeedbackID <= 0) return 0;
            else return DAL.UpdateFeedBackById(FeedbackID, IsAdminAgree);
        }

        #endregion
    
    }
}
