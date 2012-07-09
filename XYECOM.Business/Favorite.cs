using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Data.SqlClient;

namespace XYECOM.Business
{
    /// <summary>
    /// �ղ���Ϣҵ����
    /// </summary>
    public class Favorite
    {

        private static readonly XYECOM.SQLServer.Favorite DAL = new XYECOM.SQLServer.Favorite();
        /// <summary>
        /// ����ղ���Ϣ
        /// </summary>
        /// <param name="ef">ʵ����</param>
        /// <returns>��Ӱ�������</returns>
        public int Insert(XYECOM.Model.FavoriteInfo ef)
        {
            return DAL.Insert(ef);
        }

        /// <summary>
        /// �޸��ղ���Ϣ
        /// </summary>
        /// <param name="ef">ʵ����</param>
        /// <returns>��Ӱ�������</returns>
        public int Update(XYECOM.Model.FavoriteInfo ef)
        {
            return DAL.Update(ef);
        }

        /// <summary>
        /// ��ȡһ����¼
        /// </summary>
        /// <param name="Fa_ID">��¼���</param>
        /// <returns>һ����¼</returns>
        public XYECOM .Model.FavoriteInfo  GetItem(int Fa_ID)
        {
            return DAL.GetItem(Fa_ID);
        }

        /// <summary>
        /// ɾ��һ����¼
        /// </summary>
        /// <param name="Fa_ID">��¼���</param>
        /// <returns>��Ӱ�������</returns>
        public int Delete(string  Fa_IDs)
        {
            return DAL.Delete(Fa_IDs);
        }
    }
}
