using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace XYECOM.SQLServer
{
    /// <summary>
    /// �ط�վ��ҵ����
    /// </summary>
    public class AreaSite: DataCache
    {
        /// <summary>
        /// ����
        /// </summary>
        /// <param name="info">�ط�վ��ʵ�����</param>
        /// <returns>���ؽ��(Ӱ������)</returns>
        public int Insert(Model.AreaSiteInfo info)
        {
            string cmdText = "Insert Into XY_AreaSite(AreaId,FlagName,IsCustomTemplate) values(@AreaId,@FlagName,@IsCustomTemplate)";

            SqlParameter[] param = new SqlParameter[] 
            { 
                new SqlParameter("@AreaId",info.AreaId),
                new SqlParameter("@FlagName",info.FlagName),
                new SqlParameter("@IsCustomTemplate",info.IsCostomTemplate)
            };

            int i = XYECOM.Core.Data.SqlHelper.ExecuteNonQuery(CommandType.Text, cmdText, param);

            UpdateCache();

            return i;
        }

        /// <summary>
        /// ����
        /// </summary>
        /// <param name="info">�ط�վ��ʵ�����</param>
        /// <returns>���ؽ��(Ӱ������)</returns>
        public int Update(Model.AreaSiteInfo info)
        {
            string cmdText = "Update XY_AreaSite set AreaId = @AreaId,FlagName = @FlagName,IsCustomTemplate= @IsCustomTemplate where id =@Id";

            SqlParameter[] param = new SqlParameter[] 
            { 
                new SqlParameter("@AreaId",info.AreaId),
                new SqlParameter("@FlagName",info.FlagName),
                new SqlParameter("@IsCustomTemplate",info.IsCostomTemplate),
                new SqlParameter("@Id",info.SiteId)
            };

            int i = XYECOM.Core.Data.SqlHelper.ExecuteNonQuery(CommandType.Text, cmdText, param);

            UpdateCache();

            return i;
        }

        /// <summary>
        /// ɾ��һ��
        /// </summary>
        /// <param name="siteId">վ��Id</param>
        /// <returns>���ؽ��(Ӱ������)</returns>
        public int Delete(int siteId)
        {
            string cmdText = "Delete XY_AreaSite where id =@Id";

            SqlParameter[] param = new SqlParameter[] 
            { 
                new SqlParameter("@Id",siteId)
            };

            int i = XYECOM.Core.Data.SqlHelper.ExecuteNonQuery(CommandType.Text, cmdText, param);

            UpdateCache();

            return i;
        }

        /// <summary>
        /// ���ݵط�վId��ȡ��ϸ��Ϣ
        /// </summary>
        /// <param name="siteId">�ط�վId</param>
        /// <returns>������Ӧ�ط�վʵ����</returns>
        public Model.AreaSiteInfo GetItemBySiteId(int siteId)
        {
            XYECOM.Model.AreaSiteInfo info = null;

            DataTable table = GetDataTable();

            DataRow[] rows = table.Select("id =" + siteId);

            if (rows != null && rows.Length > 0)
            {
                info = new XYECOM.Model.AreaSiteInfo();

                info.SiteId = Core.MyConvert.GetInt32(rows[0]["Id"].ToString());
                info.AreaId = Core.MyConvert.GetInt32(rows[0]["AreaId"].ToString());
                info.FlagName = rows[0]["FlagName"].ToString();
                info.IsCostomTemplate = rows[0]["IsCustomTemplate"].ToString().Equals("True") ? true : false;
            }

            return info;
        }

        /// <summary>
        /// ���ݵ���Id��ȡ�ط�վ��Ϣ
        /// </summary>
        /// <param name="areaId">����Id</param>
        /// <returns>��Ӧ�ط�վʵ�����</returns>
        public Model.AreaSiteInfo GetItemByAreaId(int areaId)
        {
            XYECOM.Model.AreaSiteInfo info = null;

            DataTable table = GetDataTable();

            DataRow[] rows = table.Select("areaId =" + areaId);

            if (rows != null && rows.Length > 0)
            {
                info = new XYECOM.Model.AreaSiteInfo();

                info.SiteId = Core.MyConvert.GetInt32(rows[0]["Id"].ToString());
                info.AreaId = Core.MyConvert.GetInt32(rows[0]["AreaId"].ToString());
                info.FlagName = rows[0]["FlagName"].ToString();
                info.IsCostomTemplate = rows[0]["IsCustomTemplate"].ToString().Equals("True") ? true : false;
            }

            return info;
        }

        /// <summary>
        /// ���ݱ�ʶ���ƻ�ȡ�ط�վ��Ϣ
        /// </summary>
        /// <param name="flagName">��ʾ����</param>
        /// <returns>�ط�վ��ʵ�����</returns>
        public Model.AreaSiteInfo GetItemByFlagName(string flagName)
        {
            XYECOM.Model.AreaSiteInfo info = null;

            DataTable table = GetDataTable();

            DataRow[] rows = table.Select("flagName ='" + flagName + "'");

            if (rows != null && rows.Length > 0)
            {
                info = new XYECOM.Model.AreaSiteInfo();

                info.SiteId = Core.MyConvert.GetInt32(rows[0]["Id"].ToString());
                info.AreaId = Core.MyConvert.GetInt32(rows[0]["AreaId"].ToString());
                info.FlagName = rows[0]["FlagName"].ToString();
                info.IsCostomTemplate = rows[0]["IsCustomTemplate"].ToString().Equals("True") ? true : false;
            }

            return info;
        }

        /// <summary>
        /// ������������
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTable()
        {
            Object obj = GetCache();

            if (obj == null) return new DataTable();

            DataTable table = (DataTable)obj;

            return table;
        }

        /// <summary>
        /// �õ�Sql��ѯ���
        /// </summary>
        public override string SQL_Get_All
        {
            get { return "select * from xy_areasite"; }
        }
    }
}
