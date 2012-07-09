using System;
using System.Collections.Generic;
using System.Text;

using System.Data;

namespace XYECOM.Business
{
    /// <summary>
    /// ����ҵ����
    /// </summary>
    public class Message
    {
        private static readonly XYECOM.SQLServer.Message DAL = new XYECOM.SQLServer.Message();

        /// <summary>
        /// ���������Ϣ
        /// </summary>
        /// <param name="ea">ʵ����</param>
        /// <returns>��Ӱ�������</returns>
        public int Insert(XYECOM.Model.MessageInfo em)
        {
            return DAL.Insert(em);
        }


        /// <summary>
        /// �޸�������Ϣ
        /// </summary>
        /// <param name="ea">ʵ����</param>
        /// <returns>��Ӱ�������</returns>
        public int UpdateMess(long M_ID)
        {
            return DAL.UpdateMess(M_ID);
        }

        /// <summary>
        /// �޸�������Ϣ�鿴״̬
        /// </summary>
        /// <param name="ea">ʵ����</param>
        /// <returns>��Ӱ�������</returns>
        public int Update(long M_ID)
        {
            return DAL.Update(M_ID);
        }

        /// <summary>
        /// ��ȡһ����¼
        /// </summary>
        /// <param name="M_ID">��¼���</param>
        /// <returns>һ����¼</returns>
        public XYECOM.Model.MessageInfo GetItem(long M_ID)
        {
            return DAL.GetItem(M_ID);                
        }

        /// <summary>
        /// ɾ��һ����¼
        /// </summary>
        /// <param name="M_ID">��¼���</param>
        /// <returns>��Ӱ�������</returns>
        public int Delete(long M_ID)
        {
            return DAL.Delete(M_ID);
        }

        /// <summary>
        /// ɾ��������¼
        /// </summary>
        /// <param name="M_ID">��¼��ż���</param>
        /// <returns>Ӱ������</returns>
        public int Deletes(string M_ID)
        {
            return DAL.Deletes(M_ID);
        }
      
    }
}
