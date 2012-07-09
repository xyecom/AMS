using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace XYECOM.Business
{
    /// <summary>
    /// ��Ա����ҵ����
    /// </summary>
    public  class Resume
    {
        private static readonly XYECOM.SQLServer.Resume DAL = new XYECOM.SQLServer.Resume();

        /// <summary>
        /// Ͷ����
        /// </summary>
        /// <param name="U_ID">�û�id</param>
        /// <param name="EI_ID">ְλId</param>
        /// <returns>Ӱ������</returns>
        public int AddResume(long U_ID, long EI_ID)
        {
            return DAL.AddResume(U_ID, EI_ID);
 
        }

        /// <summary>
        /// �����û����Id�õ��û�������Ϣ
        /// </summary>
        /// <param name="U_ID">�û����Id</param>
        /// <returns>�û�������ʵ�����</returns>
        public XYECOM.Model.ResumeInfo GetItem(long U_ID)
        {
            return DAL.GetItem(U_ID);
 
        }

        /// <summary>
        /// ���¼���
        /// </summary>
        /// <param name="Re">������ʵ�����</param>
        /// <returns>Ӱ������</returns>
        public int Update(XYECOM.Model.ResumeInfo Re)
        {
            return DAL.Update(Re);
 
        }

        /// <summary>
        /// ���
        /// </summary>
        /// <param name="Re">������ʵ�����</param>
        /// <returns></returns>
        public int Insert(XYECOM.Model.ResumeInfo Re)
        {
            return DAL.Insert(Re);
 
        }

        /// <summary>
        /// ��ȡ����ְλ��Ϣ
        /// </summary>
        /// <param name="ER_ID">����ְλ���Id</param>
        /// <returns>����ְλ��Ϣ</returns>
        public DataTable GetDataTable(long ER_ID)
        {
            return DAL.GetDataTable(ER_ID);
        }

        /// <summary>
        /// �޸ļ���״̬
        /// </summary>
        /// <param name="RE_ID">����ְλId</param>
        /// <param name="type">����״��</param>
        /// <returns>Ӱ������</returns>
        public int UpdateType(long RE_ID, int type)
        {
            return DAL.UpdateType(RE_ID, type);
        }

        /// <summary>
        /// ɾ������ְλ��¼
        /// </summary>
        /// <param name="ID">����ְλ���Id</param>
        /// <returns>Ӱ������</returns>
        public int Deletes(string ID)
        {
            return DAL.Deletes(ID);
        }
        
        /// <summary>
        /// �������������ļ���
        /// </summary>
        /// <param name="PageSize">ÿҳ����</param>
        /// <param name="PageIndex">�ڼ�ҳ</param>
        /// <param name="strWhere">����</param>
        /// <param name="strOrder">����</param>
        /// <param name="strTableName">����</param>
        /// <param name="strColumuName">����</param>
        /// <param name="strPrimaryKey">����</param>
        /// <returns></returns>
        public DataTable GetDataTable(int PageSize, int PageIndex, string strWhere, string strOrder, string strTableName, string strColumuName, string strPrimaryKey)
        {
            return DAL.GetDataTable(PageSize, PageIndex, strWhere, strOrder, strTableName, strColumuName, strPrimaryKey);
        }

        //public DataTable GetDataTables(long id, String tablename) {
        //    return DAL.GetDataTables(id, tablename);
        //}
        /// <summary>
        /// �鿴��Ƹ��Ϣ�����ı���״̬
        /// </summary>
        /// <param name="EF_ID">�������α��</param>
        /// <param name="type">Ҫ���ĵ�״̬</param>
        /// <returns>����,���ڻ����0��ɹ�,�����ʧ��</returns>
        public int UpdateLookTyep(long RE_ID, int type)
        {
            return DAL.UpdateLookTyep(RE_ID,type);
        }
    }
}
