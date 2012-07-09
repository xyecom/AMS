using System;
using System.Collections.Generic;
using System.Text;

using System.Data;

namespace XYECOM.Business
{
    /// <summary>
    /// ������ҵ����
    /// </summary>
    public class Server
    {
        private static readonly XYECOM.SQLServer.Server DAL = new XYECOM.SQLServer.Server();

        /// <summary>
        /// ��ӷ�������Ϣ
        /// </summary>
        /// <param name="ea">ʵ����</param>
        /// <returns>��Ӱ�������</returns>
        public int Insert(XYECOM.Model.ServerInfo es)
        {
            return DAL.Insert(es);
        }

        /// <summary>
        /// �޸ķ�������Ϣ
        /// </summary>
        /// <param name="ea">ʵ����</param>
        /// <returns>��Ӱ�������</returns>
        public int Update(XYECOM.Model.ServerInfo es)
        {
            return DAL.Update(es);
        }

        /// <summary>
        /// �޸ķ�����״̬
        /// </summary>
        /// <param name="ID">���������Id</param>
        /// <returns>Ӱ������</returns>
        public int UpdateIsCurrent(int ID)
        {
            return DAL.UpdateIsCurrent(ID);        
        }

        /// <summary>
        /// ��ȡһ����¼
        /// </summary>
        /// <param name="S_ID">��¼���</param>
        /// <returns>һ����¼</returns>
        public XYECOM.Model.ServerInfo GetItem(int S_ID)
        {
            return DAL.GetItem(S_ID);
        }
        /// <summary>
        /// ��ȡͼƬ�ķ������ı��
        /// </summary>
        /// <returns>ͼƬ���������</returns>
        public int GetCurrentServerID()
        {
            return DAL.GetCurrentServerID();
        }
        /// <summary>
        /// ��ȡ��ǰ���õ����ַ������ı��
        /// </summary>
        /// <returns>���ַ��������</returns>
        public int GetCharacterServerID()
        {
            return DAL.GetCharacterServerID();
        }
        /// <summary>
        /// ��ȡ���м�¼
        /// </summary>
        /// <returns>��¼��</returns>
        public DataTable GetDataTable()
        {
            return DAL.GetDataTable();
        }

        /// <summary>
        /// ɾ��
        /// </summary>
        /// <param name="S_ID">���������Id</param>
        /// <returns>Ӱ������</returns>
        public int Delete(int S_ID)
        {
            return DAL.Delete(S_ID);
        }
        /// <summary>
        /// �ж��ڸ��������Ƿ����
        /// </summary>
        /// <returns>�Ƿ����</returns>
        public bool IsUsed(int S_ID) 
        {
            return DAL.IsUsed(S_ID);
        }
    }
}
