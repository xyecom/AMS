using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Data.SqlClient;

namespace XYECOM.Business
{
    /// <summary>
    /// ���̴�����Ϣҵ����
    /// </summary>
    public class InviteBusinessmanInfo
    {
        private static readonly XYECOM.SQLServer.InviteBusinessmanInfo DAL = new XYECOM.SQLServer.InviteBusinessmanInfo();

        /// <summary>
        /// ��ȡָ����ŵ����̴������
        /// </summary>
        /// <param name="IBI_ID">Ҫ��ȡ�����̴�����</param>
        /// <returns>�ñ�ű�ʾ�Ķ���</returns>
        public XYECOM.Model.InviteBusinessmanInfo GetItem(int IBI_ID)
        {
            if (IBI_ID <= 0) return null;

            return DAL.GetItem(IBI_ID);
        }

        /// <summary>
        /// ���������Ϣ
        /// </summary>
        /// <param name="ei">ʵ����</param>
        /// <param name="eiid">����ӵ�������Ϣ�ļ�¼���</param>
        /// <returns>��Ӱ�������</returns>
        public int Insert(XYECOM.Model.InviteBusinessmanInfo info, out int infoId)
        {
            return DAL.Insert(info, out infoId);
        }

        /// <summary>
        /// �޸�������Ϣ
        /// </summary>
        /// <param name="ei">ʵ����</param>
        /// <returns>��Ӱ�������</returns>
        public int Update(XYECOM.Model.InviteBusinessmanInfo info)
        {
            return DAL.Update(info);
        }

        /// <summary>
        /// ��ȡ����ָ�����������̴����¼��
        /// </summary>
        /// <param name="strwhere">ָ����where����</param>
        /// <param name="strOrder">ָ����order����</param>
        /// <returns>����������datatable���͵ļ�¼��</returns>
        public DataTable GetDataTable(string strwhere, string strOrder)
        {
            return DAL.GetDataTable(strwhere, strOrder);
        }

        /// <summary>
        /// ɾ��һ����¼
        /// </summary>
        /// <param name="IBI_ID">��¼���</param>
        /// <returns>��Ӱ�������</returns>
        public int Delete(long IBI_ID)
        {
            new XYECOM.Business.Attachment().Delete(IBI_ID, XYECOM.Model.AttachmentItem.Investment, XYECOM.Model.UploadFileType.All);

            return DAL.Delete(IBI_ID);
        }


        /// <summary>
        /// ��ȡ�������̴����¼��DataTable���͵ļ�¼��
        /// </summary>
        /// <returns>DataTable���͵��������̴����¼��</returns>
        public DataTable GetDataTable()
        {
            return DAL.GetDataTable();
        }
        /// <summary>
        /// �޸�����״̬
        /// </summary>
        /// <param name="isPause">
        /// true:��ͣ����
        /// false:���̽�����</param>
        /// <param name="IBI_ID_Scope">Ҫ�޸ĵ�������Ϣ�ı�ŷ�Χ,example:(1,3)</param>
        /// <returns>��Ӱ�������</returns>
        public int UpdateEntityState(bool isPause, string IBI_ID_Scope)
        {
            return DAL.UpdateEntityState(isPause, IBI_ID_Scope);
        }
        /// <summary>
        /// ɾ��������¼
        /// </summary>
        /// <param name="IBI_ID_Scope">��¼��ŷ�Χ</param>
        /// <returns>��Ӱ�������</returns>
        public int Delete(string ids)
        {
            Business.Attachment attBLL = new Attachment();

            attBLL.Delete(ids, XYECOM.Model.AttachmentItem.Investment, XYECOM.Model.UploadFileType.All);

            return DAL.Delete(ids);
        }

        #region Audit Management
        /// <summary>
        /// �Ը�����Ϣ���ͨ��
        /// </summary>
        /// <param name="IBI_ID">�ڶ�Ӧ���еı��</param>
        /// <returns>��Ӱ�������</returns>
        public int AddAuditState(long IBI_ID, bool IsAudited, string A_Reason, string A_Advice)
        {
            return DAL.AddAuditState(IBI_ID, IsAudited, A_Reason, A_Advice);
        }
        /// <summary>
        /// �޸���Ϣ�����״̬
        /// </summary>
        /// <param name="IBI_ID">�ڶ�Ӧ���еı��</param>
        /// <param name="isAudited">���ڱ�</param>
        /// <returns>��Ӱ�������</returns>
        public int UpdateAuditState(long IBI_ID, bool isAudited, string A_Reason, string A_Advice)
        {
            return DAL.UpdateAuditState(IBI_ID, isAudited, A_Reason, A_Advice);
        }
        #endregion

        #region �޸��Ƽ�
        /// <summary>
        /// ����ָ����ŵ����̴�����Ϣ���Ƽ�״̬
        /// </summary>
        /// <param name="IBI_ID">Ҫ���ĵ����̴�����</param>
        /// <param name="Vouch">Ҫ���ĵ�״̬</param>
        /// <returns>����,���ڻ����0��ɹ�,�����ʧ��</returns>
        public int UpdateVouch(long IBI_ID, bool Vouch)
        {
            return DAL.UpdateVouch(IBI_ID, Vouch);
        }
        #endregion

        #region ��ȡһ��������Ϣ
        /// <summary>
        /// ��ȡָ����ŵ����̴�����Ϣ��DataTable�������ݼ�
        /// </summary>
        /// <param name="IBI_ID">Ҫ��ȡ�����̴�����Ϣ���</param>
        /// <returns>�ü�¼��datatable�������ݼ�</returns>
        public DataTable GetDataTable(long IBI_ID)
        {
            return DAL.GetDataTable(IBI_ID);
        }
        #endregion



        #region �����ƶ�
        /// <summary>
        /// �����ƶ�
        /// </summary>
        /// <returns>Ӱ������</returns>
        public int MoveInvestment(String strwhere, String content)
        {
            return DAL.MoveInvestment(strwhere, content);
        }
        #endregion
    }
}
