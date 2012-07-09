using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace XYECOM.Business
{
    /// <summary>
    /// �ط�վ��ҵ����
    /// </summary>
    public class AreaSite
    {
        private static readonly XYECOM.SQLServer.AreaSite DAL = new XYECOM.SQLServer.AreaSite();

        /// <summary>
        /// ����
        /// </summary>
        /// <param name="info">�ط�վ��ʵ�����</param>
        /// <returns>Ӱ������</returns>
        public int Insert(Model.AreaSiteInfo info)
        {
            if (info == null) return 0;

            return DAL.Insert(info);
        }

        /// <summary>
        /// ����
        /// </summary>
        /// <param name="info">�ط�վ��ʵ�����</param>
        /// <returns>Ӱ������</returns>
        public int Update(Model.AreaSiteInfo info)
        {
            if (info == null) return 0;

            return DAL.Update(info);
        }

        /// <summary>
        /// ɾ��һ��
        /// </summary>
        /// <param name="siteId">վ��Id</param>
        /// <returns>Ӱ������</returns>
        public int Delete(int siteId)
        {
            if (siteId <=0) return 0;

            return DAL.Delete(siteId);
        }

        /// <summary>
        /// ���ݵط�վId��ȡ��ϸ��Ϣ
        /// </summary>
        /// <param name="siteId">�ط�վId</param>
        /// <returns>ʵ�����</returns>
        public Model.AreaSiteInfo GetItemBySiteId(int siteId)
        {
            if (siteId <= 0) return null;

            return DAL.GetItemBySiteId(siteId);
        }

        /// <summary>
        /// ���ݱ�ʶ���ƻ�ȡ�ط�վ��Ϣ
        /// </summary>
        /// <param name="flagName">��ʾ����</param>
        /// <returns>�ط�վ��ʵ�����</returns>
        public Model.AreaSiteInfo GetItemByFlagName(string flagName)
        {
            if (string.IsNullOrEmpty(flagName)) return null;

            return DAL.GetItemByFlagName(flagName);
        }

        /// <summary>
        /// ���ݵ���Id��ȡ�ط�վ��Ϣ
        /// </summary>
        /// <param name="areaId">����Id</param>
        /// <returns>�ط�վ��ʵ�����</returns>
        public Model.AreaSiteInfo GetItemByAreaId(int areaId)
        {
            if (areaId <= 0) return null;

            return DAL.GetItemByAreaId(areaId);
        }

        /// <summary>
        /// ������������
        /// </summary>
        /// <returns>�ط�վ���������ĵ�Datable</returns>
        public DataTable GetDataTable()
        {
            return DAL.GetDataTable();
        }
    }
}
