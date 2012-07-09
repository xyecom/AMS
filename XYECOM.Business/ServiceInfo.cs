using System;
using System.Collections.Generic;
using System.Text;

using System.Data;



namespace XYECOM.Business
{
    /// <summary>
    /// ������Ϣҵ����
    /// </summary>
    public class ServiceInfo
    {
        private static readonly XYECOM.SQLServer.ServiceInfo DAL = new XYECOM.SQLServer.ServiceInfo();

        #region ��ӷ�����Ϣ
        /// <summary>
        /// ��ӷ�����Ϣ
        /// </summary>
        /// <param name="es">������Ϣ���ʵ�����</param>
        /// <param name="infoId">������Ϣ���Id</param>
        /// <returns>Ӱ������</returns>
        public int Insert(XYECOM.Model.ServiecInfo es,out int infoId)
        {
            return DAL.Insert(es, out infoId);

        }
        #endregion 

        #region �޸ķ�����Ϣ
        /// <summary>
        /// �޸ķ�����Ϣ
        /// </summary>
        /// <param name="es">������Ϣ��ʵ�����</param>
        /// <returns>Ӱ������</returns>
        public int Update(XYECOM.Model.ServiecInfo es)
        {
            return DAL.Update(es);
        }
        #endregion 
        
        #region ��һ��������Ϣ
        /// <summary>
        /// ��ȡһ��������Ϣ
        /// </summary>
        /// <param name="S_ID">������Ϣ���Id</param>
        /// <returns>������Ϣ��ʵ�����</returns>
        public XYECOM.Model.ServiecInfo GetItem(int S_ID)
        {
            return DAL.GetItem(S_ID);
        }
        #endregion  

        #region  ɾ��������¼
        /// <summary>
        /// ɾ��������¼
        /// </summary>
        /// <param name="ids">��¼��ż���</param>
        /// <returns>Ӱ������</returns>
        public int Deletes(string ids)
        {
            new XYECOM.Business.Attachment().Delete(ids, XYECOM.Model.AttachmentItem.Service, XYECOM.Model.UploadFileType.All);

            return DAL.Deletes(ids);
        }
        #endregion

        #region �޸��Ƽ���Ϣ
        /// <summary>
        /// �޸��Ƽ���Ϣ
        /// </summary>
        /// <param name="es">������Ϣ��ʵ�����</param>
        /// <returns>Ӱ������</returns>
        public int UpdateVouch(XYECOM.Model.ServiecInfo es)
        {
            return DAL.UpdateVouch(es);
        }
        #endregion

        #region  �޸���ͣ��
        /// <summary>
        /// �޸���ͣ
        /// </summary>
        /// <param name="S_ID">������Ϣ���Id</param>
        /// <returns>Ӱ������</returns>
        public int UpdatePause(string S_ID)
        {
            return DAL.UpdatePause(S_ID);
        }
        #endregion

        #region �����ƶ�
        /// <summary>
        /// �����ƶ�
        /// </summary>
        /// <returns>Ӱ������</returns>
        public int MoveService(String strwhere, String content)
        {
            return DAL.MoveService(strwhere, content);
        }
        #endregion
    }
}