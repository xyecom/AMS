using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Data.SqlClient;


namespace XYECOM.Business
{
    /// <summary>
    /// ����ҵ����
    /// </summary>
    public class Finance
    {
        private static readonly XYECOM.SQLServer.Finance DAL =new XYECOM.SQLServer.Finance();

        /// <summary>
        /// ��Ӳ�����Ϣ
        /// </summary>
        /// <param name="ef">����ʵ�����</param>
        /// <returns>Ӱ������</returns>
        public int Insert(XYECOM.Model.FinanceInfo ef)
        {
            return DAL.Insert(ef);
        }
        /// <summary>
        /// �޸Ĳ�����Ϣ
        /// </summary>
        /// <param name="F_ID">���</param>
        /// <param name="FT_ID">���������</param>
        /// <param name="M_Money">Ǯ</param>
        /// <param name="U_Name">�û���</param>
        /// <param name="F_Remark">����</param>
        /// <returns></returns>
        public int Update(int F_ID ,int FT_ID, decimal M_Money,string U_Name,string F_Remark)
        {
            return DAL.Update(F_ID, FT_ID, M_Money, U_Name, F_Remark);
        }
        /// <summary>
        /// ɾ��������Ϣ
        /// </summary>
        /// <param name="F_ID">���Id</param>
        /// <returns>Ӱ������</returns>
        public int Delete(int F_ID)
        {
            return DAL.Delete(F_ID);
        }
        /// <summary>
        /// ���ݱ�ŵõ�һ��������Ϣ
        /// </summary>
        /// <param name="F_ID">���</param>
        /// <returns>������Ϣʵ�����</returns>
        public XYECOM .Model .FinanceInfo  GetItem(int F_ID)
        {
            return DAL.GetItem(F_ID);
        }
    }
}
