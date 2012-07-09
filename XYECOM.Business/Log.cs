using System;
using System.Collections.Generic;
using System.Text;

using System.Data ;
using System.Data.SqlClient;

namespace XYECOM.Business
{
    /// <summary>
    /// ��־ҵ����
    /// </summary>
    public class Log
    {
        private static readonly XYECOM.SQLServer.Log DAL = new XYECOM.SQLServer.Log();

        /// <summary>
        /// �����־
        /// </summary>
        /// <param name="el">��־ʵ�����</param>
        /// <returns>Ӱ������</returns>
        public int Insert(XYECOM.Model.LogInfo el)
        {
            return DAL.Insert(el);
        }

        /// <summary>
        /// ɾ����־
        /// </summary>
        /// <param name="L_ID">��־���Id</param>
        /// <returns>Ӱ������</returns>
        public int Delete(int L_ID)
        {
            return DAL.Delete(L_ID);
        }

        /// <summary>
        /// ������־���Id�õ���־��Ϣ
        /// </summary>
        /// <param name="L_ID">��־���Id</param>
        /// <returns>��־ʵ�����</returns>
        public XYECOM .Model  .LogInfo  GetItem(int L_ID)
        {
            return DAL.GetItem(L_ID);
        }

        /// <summary>
        /// ɾ����־
        /// </summary>
        /// <param name="L_ID">��־���id</param>
        /// <returns>Ӱ������</returns>
        public int Delete(string  L_ID)
        {
            return DAL.Delete(L_ID);
        }

        /// <summary>
        /// ɾ��������־
        /// </summary>
        /// <returns>Ӱ������</returns>
        public int DeleteAll()
        {
            return DAL.DeleteAll();
        }

        public string GetOperInfo(string Opertae)
        {
            string ReStr = "";

            if (Opertae != "")
            {
                switch (XYECOM.Core.MyConvert.GetInt32(Opertae))
                {
                    case (int)XYECOM.Model.AccountOperate.ContractMargin:
                        ReStr = "��ֵ��ͬ��֤��";
                        break;
                    case (int)XYECOM.Model.AccountOperate.InputMoney:
                        ReStr = "���߳�ֵ";
                        break;
                    case (int)XYECOM.Model.AccountOperate.PayContractMargin:
                        ReStr = "֧����ͬ��֤��";
                        break;
                    case (int)XYECOM.Model.AccountOperate.PayOrders:
                        ReStr = "֧������";
                        break;
                    case (int)XYECOM.Model.AccountOperate.PaySupMargin:
                        ReStr = "֧����Ʒ��֤��";
                        break;
                }
            }

            return ReStr;
        }
    }
}
