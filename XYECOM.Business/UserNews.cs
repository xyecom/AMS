using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Data.SqlClient;

namespace XYECOM.Business
{
    /// <summary>
    /// ��ҵ��̬ҵ����
    /// </summary>
    public class UserNews
    {
        private static readonly XYECOM.SQLServer.UserNews DAL = new XYECOM.SQLServer.UserNews();

        /// <summary>
        /// ���
        /// </summary>
        /// <param name="en">ʵ�����</param>
        /// <returns>Ӱ������</returns>
        public int Insert(XYECOM.Model.UserNewsInfo en)
        {
            return DAL.Insert(en);
        }
        /// <summary>
        /// ɾ��
        /// </summary>
        /// <param name="N_ID">���Id</param>
        /// <returns>Ӱ������</returns>
        public int Delete(string N_ID)
        {
            return DAL.Delete(N_ID);
        }

        /// <summary>
        /// ��ȡ�û���Ѷ��Ϣ
        /// </summary>
        /// <param name="N_ID">���Id</param>
        /// <returns>ʵ�����</returns>
        public XYECOM.Model.UserNewsInfo GetItem(int N_ID)
        {
            return DAL.GetItem(N_ID);
        }

        /// <summary>
        ///���»�ȡ�û���Ѷ��Ϣ
        /// </summary>
        /// <param name="en">ʵ�����</param>
        /// <returns>Ӱ������</returns>
        public int Update(XYECOM.Model.UserNewsInfo en)
        {
            return DAL.Update(en);
        }

        /// <summary>
        /// ��ȡ�û���Ѷ��Ϣ
        /// </summary>
        /// <param name="N_ID">���Id</param>
        /// <returns>ʵ�����</returns>
        public bool IsDeletdTitleInfo(int ID, int UserId)
        {
            DataTable tableinfo = new DataTable();
            
            if(ID != null && UserId != null)
                tableinfo = DAL.SelectByparam(ID, UserId);
            
            if (tableinfo.Rows.Count > 0)
                return true;
            return false;
        }
    }
}
