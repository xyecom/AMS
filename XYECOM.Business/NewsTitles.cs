using System;
using System.Collections.Generic;
using System.Text;
using System.Data;


namespace XYECOM.Business
{
    /// <summary>
    /// ������Ŀҵ����
    /// </summary>
    public class NewsTitles
    {
        private static readonly XYECOM.SQLServer.NewsTitles DAL = new XYECOM.SQLServer.NewsTitles();
        
        /// <summary>
        ///  ���������Ŀ��Ϣ
        /// </summary>
        /// <param name="nt">ʵ����NewsTitles</param>
        /// <param name="nt_id">����ӵ�������Ŀ��IDֵ</param>
        /// <returns>���֣����ڻ����0��ʾ��ӳɹ�</returns>
        public int Insert(XYECOM.Model.NewsTitlesInfo info, out int nt_id)
        {
            if (info == null)
            {
                nt_id = 0;
                return 0;
            }

            return DAL.Insert(info, out nt_id);
        }

        /// <summary>
        /// �޸�ָ����������Ŀ��Ϣ
        /// </summary>
        /// <param name="info">ָ������Ŀ��Ϣ</param>
        /// <param name="subChannelAutoInheritCustomFolderValue">����Ŀ�Ƿ��Զ��̳��Զ����ļ�������</param>
        /// <param name="subDomain">����Ŀ�̳�����</param>
        /// <returns>���֣����ڻ����0��ʾ�޸ĳɹ�</returns>
        public int Update(XYECOM.Model.NewsTitlesInfo info, bool subChannelAutoInheritCustomFolderValue, bool subDomain)
        {
            string subIds = XYECOM.Business.XYClass.GetSubIds("news", info.Id).Trim();
            XYECOM.Model.NewsTitlesInfo baseinfo = new XYECOM.Business.NewsTitles().GetItem(info.Id);

            //������ö���������������Զ����ļ���
            if (subDomain)
            {
                if (!subIds.Equals(""))
                {
                    XYECOM.SQLServer.Utils.UpdateColumuByWhere("NT_TempletFolderAddress", info.TempletFolderAddress, "where NT_ID in(" + subIds + ")", "n_newsTitleInfo");

                    XYECOM.SQLServer.Utils.UpdateColumuByWhere("DomainName", info.DomainName, "where NT_ID in(" + subIds + ")", "n_newsTitleInfo");
                }
            }
            //���Զ�����Ŀ�ļ��в�Ϊ��ʱ�����������Զ��̳�Ϊ��������Ŀ
            else if (subChannelAutoInheritCustomFolderValue)          
            {
                if (!subIds.Equals(""))
                {
                    XYECOM.SQLServer.Utils.UpdateColumuByWhere("NT_TempletFolderAddress", info.TempletFolderAddress, "where NT_ID in(" + subIds + ")", "n_newsTitleInfo");
                }
            }            

            return DAL.Update(info);
        }

        /// <summary>
        /// ɾ��ָ����������Ŀ��Ϣ
        /// </summary>
        /// <param name="nt_ids">ָ����������Ŀ����ַ���</param>
        /// <returns>���֣����ڻ����0��ʾɾ���ɹ�</returns>
        public int Delete(string nt_ids)
        {
            if (String.IsNullOrEmpty(nt_ids) || nt_ids.Trim().Equals("")) return 0;

            return DAL.Delete(nt_ids);
        }

        /// <summary>
        /// ����ָ����IDֵ��ø���������Ŀ����
        /// </summary>
        /// <param name="ntid">������Ŀ����</param>
        /// <returns>��������Ŀ������</returns>
        public Model.NewsTitlesInfo GetItem(int Id)
        {
            if (Id <= 0) return null;

            return DAL.GetItem(Id);
        }

        /// <summary>
        /// ���ݶ��������õ�������Ŀ��Ϣ
        /// </summary>
        /// <param name="domainname">��������</param>
        /// <returns>������Ŀʵ�����</returns>
        public Model.NewsTitlesInfo GetItemByDomainName(string domainname)
        {
            if (string.IsNullOrEmpty(domainname)) return null;

            return DAL.GetItemByDomainName(domainname);
        }

        /// <summary>
        /// ��ȡָ����Id����������Ŀ
        /// </summary>
        /// <param name="parentId"></param>
        /// <returns></returns>
        public List<Model.NewsTitlesInfo> GetItems(int parentId)
        {
            if (parentId <= 0) return new List<XYECOM.Model.NewsTitlesInfo>();

            return DAL.GetItems(parentId);
        }
    }
}
