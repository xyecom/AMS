using System;
using System.Collections.Generic;
using System.Text;

using System.Data;

namespace XYECOM.Business
{
    /// <summary>
    /// ��Ӫģʽҵ����
    /// </summary>
    public class Mode
    {
        private static readonly XYECOM.SQLServer.Mode DAL = new XYECOM.SQLServer.Mode();

        /// <summary>
        /// ���һ����Ϣ
        /// </summary>
        /// <param name="em">��Ӫģʽʵ�����</param>
        /// <returns>Ӱ������</returns>
        public int Insert(XYECOM.Model.ModeInfo em)
        {
            return DAL.Insert(em);
        }
        /// <summary>
        /// �޸�
        /// </summary>
        /// <param name="em">��Ӫģʽʵ�����</param>
        /// <returns>Ӱ������</returns>
        public int Update(XYECOM.Model.ModeInfo em)
        {
            return DAL.Update(em);
        }
        /// <summary>
        /// ��ȡһ����¼
        /// </summary>
        /// <param name="UM_ID">��¼���</param>
        /// <returns>һ����¼</returns>
        public XYECOM.Model.ModeInfo GetItem(int M_ID)
        {
            return DAL.GetItem(M_ID);
        }
        /// <summary>
        /// ��ȡ���м�¼
        /// </summary>
        /// <returns>��¼��</returns>
        public  DataTable GetDataTable()
        {
            return DAL.GetDataTable();
        }

        /// <summary>
        /// ɾ��һ����¼
        /// </summary>
        /// <param name="UM_ID">��¼���</param>
        /// <returns>��Ӱ�������</returns>
        public int Delete(int M_ID)
        {
            return DAL.Delete(M_ID);
        }
    }
}
    
    
   

    
   

