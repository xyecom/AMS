using System;
using System.Collections.Generic;
using System.Text;

using System.Data;

namespace XYECOM.Business
{
    /// <summary>
    /// �û���ֵ��¼ҵ����
    /// </summary>
    public class UserInputMoney
    {
        private static readonly XYECOM.SQLServer.UserInputMoney DAL = new XYECOM.SQLServer.UserInputMoney();

        /// <summary>
        /// ���
        /// </summary>
        /// <param name="ei">ʵ�����</param>
        /// <returns>-3��ʾ�����Ѿ������</returns>
        public int Insert(XYECOM.Model.UserInputMoneyInfo ei)
        {
            if (!DAL.CheckOrder(ei.OrderID,ei.U_ID))
                return DAL.Insert(ei);
            else
                return -3;
        }
    }
}

