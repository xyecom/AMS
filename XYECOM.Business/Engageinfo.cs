using System;
using System.Collections.Generic;
using System.Text;

using System.Data;

namespace XYECOM.Business
{
    /// <summary>
    /// ��Ƹ��Ϣҵ����
    /// </summary>
    public class Engageinfo
    {

        private static readonly XYECOM.SQLServer.Engageinfo DAL = new XYECOM.SQLServer.Engageinfo();
        /// <summary>
        /// �����Ƹ��Ϣ
        /// </summary>
        /// <param name="E">ʵ����</param>
        /// <returns>��Ӱ�������</returns>
        public int Insert(XYECOM.Model.Engageinfo E, out long esid)
        {
            return DAL.Insert(E, out esid);
        }
        /// <summary>
        /// �޸���Ƹ��Ϣ
        /// </summary>
        /// <param name="E">ʵ����</param>
        /// <returns>��Ӱ�������</returns>
        public int Update(XYECOM.Model.Engageinfo E)
        {
            return DAL.Update(E);
        }
        /// <summary>
        /// ɾ��������¼
        /// </summary>
        /// <param name="EI_ID">��¼���</param>
        /// <returns>��Ӱ�������</returns>
        public int Delete(string ID)
        {
            return DAL.Delete(ID);
        }
        /// <summary>
        /// ��ȡһ����¼
        /// </summary>
        /// <param name="SD_ID">��¼���</param>
        /// <returns>һ����¼</returns>
        public XYECOM.Model.Engageinfo GetItem(long JobId)
        {
            if (JobId <= 0) return null;

            return DAL.GetItem(JobId);
        }

        #region   ��ʾһ����Ƹ��Ϣ
        /// <summary>
        /// ��ʾһ����Ƹ��Ϣ
        /// </summary>
        /// <param name="EI_ID">��Ƹ��Ϣ���</param>
        /// <returns>һ����Ƹ��Ϣ</returns>
        public DataTable GetDataTable(long EI_ID)
        {
            return DAL.GetDataTable(EI_ID);
        }
        #endregion

        #region �޸��Ƽ�
        /// <summary>
        /// �޸��Ƽ�
        /// </summary>
        /// <param name="EI_ID">��Ϣ���</param>
        /// <param name="Vouch">�Ƿ��Ƽ�</param>
        /// <returns>Ӱ������</returns>
        public int UpdateVouch(long EI_ID, bool Vouch)
        {
            return DAL.UpdateVouch(EI_ID, Vouch);
        }
        #endregion
    }
}
