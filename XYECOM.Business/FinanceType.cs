using System;
using System.Collections.Generic;
using System.Text;

using System.Data  ;
using System.Data.SqlClient;

namespace XYECOM.Business
{
    /// <summary>
    /// �������ҵ����
    /// </summary>
    public  class FinanceType
    {
        private static readonly XYECOM.SQLServer.FinanceType DAL = new XYECOM.SQLServer.FinanceType();
        
        /// <summary>
        /// ��Ӳ������
        /// </summary>
        /// <param name="et">������ʵ�����</param>
        /// <returns>Ӱ������</returns>
        public int Insert(XYECOM.Model.FinanceTypeInfo et)
        {
            return DAL.Insert(et);
        }
        /// <summary>
        /// �޸Ĳ������
        /// </summary>
        /// <param name="et">������ʵ�����</param>
        /// <returns>Ӱ������</returns>
        public int Update(XYECOM.Model.FinanceTypeInfo et)
        {
            return DAL.Update(et);        
        }

        /// <summary>
        /// ɾ���������
        /// </summary>
        /// <param name="FT_ID">���������</param>
        /// <returns>Ӱ������</returns>
        public int Delete(int FT_ID)
        {
            return DAL.Delete(FT_ID);
        }

        /// <summary>
        /// ���ݱ�ŵõ����������Ϣ
        /// </summary>
        /// <param name="FT_ID">���������</param>
        /// <returns>�������ʵ�����</returns>
        public XYECOM .Model.FinanceTypeInfo  GetItem(int FT_ID)
        {
            return DAL.GetItem(FT_ID);
        }
        public DataTable GetDataTable()
        {
            return DAL.GetDataTable();
        }
    }
}
