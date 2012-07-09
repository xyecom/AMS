using System;
using System.Collections.Generic;
using System.Text;


using System.Data;

namespace XYECOM.Business
{
    /// <summary>
    /// Ͷ������Ϣҵ����
    /// </summary>
    public class Demand
    {

        private static readonly XYECOM.SQLServer.Demand DAL = new XYECOM.SQLServer.Demand();
        /// <summary>
        /// ��Ӽӹ���Ϣ
        /// </summary>
        /// <param name="info">ʵ����</param>
        /// <returns>��Ӱ�������</returns>
        public int Insert(XYECOM.Model.DemandInfo info, out int infoId)
        {
            infoId = 0;
            if (info == null)
            {
                return 0;
            }
            return DAL.Insert(info, out infoId);
        }

        /// <summary>
        /// �޸�����Ϣ
        /// </summary>
        /// <param name="ea">ʵ����</param>
        /// <returns>��Ӱ�������</returns>
        public int Update(XYECOM.Model.DemandInfo es)
        {
            return DAL.Update(es);
        }

        /// <summary>
        /// ��ȡһ����¼
        /// </summary>
        /// <param name="SD_ID">��¼���</param>
        /// <returns>һ����¼</returns>
        public XYECOM.Model.DemandInfo GetItem(int SD_ID)
        {
            if (SD_ID < 1)
            {
                return null;
            }
            return DAL.GetItem(SD_ID);
        }

        /// <summary>
        /// ɾ��������¼
        /// </summary>
        /// <param name="SD_ID">��¼���</param>
        /// <returns>��Ӱ�������</returns>
        public int Deletes(string ids)
        {
            if (string.IsNullOrEmpty(ids))
            {
                return 0;
            }
            //new XYECOM.Business.Attachment().Delete(ids, XYECOM.Model.AttachmentItem.Venture, XYECOM.Model.UploadFileType.All);

            return DAL.DeleteByIds(ids);
        }


        /// <summary>
        /// ɾ������(ɾ������)
        /// </summary>
        /// <param name="infoId">��Ϣ����Id</param>
        /// <returns>��Ӱ�������</returns>
        public int Delete(int infoId)
        {
            if (infoId < 1)
            {
                return 0;
            }
            return DAL.Delete(infoId);
        }

        /// <summary>
        /// �޸��Ƽ���Ϣ
        /// </summary>
        /// <param name="es">ʵ����</param>
        /// <returns>��Ӱ�������</returns>
        public int UpdateSD_Vouch(XYECOM.Model.DemandInfo es)
        {
            return DAL.UpdateSD_Vouch(es);
        }
        /// <summary>
        /// �޸���ͣ��Ϣ
        /// </summary>
        /// <param name="SD_ID">���</param>
        /// <returns>Ӱ������</returns>
        public int UpdateSD_Pause(string SD_ID)
        {
            return DAL.UpdateSD_Pause(SD_ID);
        }
        /// <summary>
        /// �޸�Ͷ������Ϣ�����״̬
        /// </summary>
        /// <param name="id">Ͷ������ϢID</param>
        /// <param name="state">Ҫ��˵�״̬</param>
        /// <returns>��Ӱ�������</returns>
        public int UpdateStateById(int id, int state)
        {
            if (id < 1)
            {
                return 0;
            }
            return DAL.UpdateStateById(id,state);
        }

        /// <summary>
        /// �޸�Ͷ������Ϣ���Ƽ�״̬
        /// </summary>
        /// <param name="id">Ͷ������Ϣ</param>
        /// <returns>��Ӱ�������</returns>
        public int UpdateVouchById(int id)
        {
            if (id < 1)
            {
                return 0;
            }
            return DAL.UpdateVouchById(id);
        }
        /// <summary>
        /// �޸�Ͷ������Ϣ���Ƽ�״̬
        /// </summary>
        /// <param name="id">Ͷ������Ϣ</param>
        /// <param name="vouch">Ҫ�Ƽ���״̬</param>
        /// <returns>��Ӱ�������</returns>
        public int UpdateVouchById(int id,int vouch)
        {
            if (id < 1)
            {
                return 0;
            }
            return DAL.UpdateVouchById(id,vouch);
        }

        #region �����ƶ�
        /// <summary>
        /// �����ƶ�
        /// </summary>
        /// <returns>Ӱ������</returns>
        public int MoveMachining(String strwhere, String content)
        {
            return DAL.MoveMachining(strwhere, content);
        }
        #endregion
    }
}
