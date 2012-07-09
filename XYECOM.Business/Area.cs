using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace XYECOM.Business
{
    /// <summary>
    /// �������ݲ���ҵ����
    /// </summary>
    public class Area
    {
        private XYECOM.SQLServer.Area DAL = new XYECOM.SQLServer.Area();

        /// <summary>
        /// ���ص�������
        /// </summary>
        /// <param name="areaID">����Id</param>
        /// <returns>�����ݷ���null</returns>
        public XYECOM.Model.AreaInfo GetItem(int areaID)
        {
            if (areaID <= 0) return null;

            return DAL.GetItem(areaID);
        }

        /// <summary>
        /// ��ȡָ��Id���ϵĶ��������Ϣ
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public List<Model.AreaInfo> GetItemsByIDs(string ids)
        {
            return DAL.GetItemsByIDs(ids);
        }

        /// <summary>
        /// ��ָ��Id���ϵĶ��������Ϣƴд���ַ���
        /// </summary>
        /// <param name="ids">������ϢId</param>
        /// <returns>ָ��Id���ϵĶ������ƴд�ɵ��ַ���</returns>
        public string GetNamesByIDs(string ids)
        {
            if (string.IsNullOrEmpty(ids)) return "";

            List<Model.AreaInfo> list = GetItemsByIDs(ids);

            string names = "";

            foreach (Model.AreaInfo info in list)
            {
                if (names.Equals(""))
                    names = info.Name;
                else
                    names += "," + info.Name;
            }

            return names;
        }

        /// <summary>
        /// �����Ӽ���������
        /// </summary>
        /// <param name="parentID">����Id</param>
        /// <returns>�����ݷ��ؿռ���</returns>
        public List<Model.AreaInfo> GetItems(int parentID)
        {
            //���parentIdС��0�򷵻ؿռ���
            if (parentID < 0)
                return new List<XYECOM.Model.AreaInfo>();

            return DAL.GetItems(parentID);
        }

        /// <summary>
        /// ���������Ϣ
        /// </summary>
        /// <param name="info">��Ϣ����ʵ��</param>
        /// <returns>���� 0����ɹ���С�ڵ���0����ʧ��</returns>
        public int Insert(XYECOM.Model.AreaInfo info)
        {
            if (info == null) return 0;

            return DAL.Insert(info);
        }

        /// <summary>
        /// ���µ�����Ϣ
        /// </summary>
        /// <param name="info">��Ϣ����ʵ��</param>
        /// <returns>���� 0 ���³ɹ���С�ڵ���0����ʧ��</returns>
        public int Update(XYECOM.Model.AreaInfo info)
        {
            if (info == null) return 0;

            return DAL.Update(info);
        }

        /// <summary>
        /// ɾ��������Ϣ
        /// </summary>
        /// <param name="areaID">����Id</param>
        /// <returns>���� 0 ɾ���ɹ���С�ڵ���0ɾ��ʧ��</returns>
        public int Delete(string areaID)
        {
            if (string.IsNullOrEmpty(areaID)
                || areaID.Equals(""))
                return 0;

            return DAL.Delete(areaID);
        }

        /// <summary>
        /// �ж��Ƿ����¼�����
        /// </summary>
        /// <param name="parentID">����Id</param>
        /// <returns>true:���Ӽ� false:���Ӽ�</returns>
        public bool HasSubArea(int parentID)
        {
            if (parentID < 0) return false;

            return DAL.HasSubArea(parentID);
        }

        /// <summary>
        /// ��ȡ�ӵ���ID
        /// </summary>
        /// <param name="areaId">����Id</param>
        /// <returns></returns>
        public string GetSubIds(int areaId)
        {
            if (areaId <= 0) return "";

            Model.AreaInfo info = GetItem(areaId);

            if (info == null) return "";

            return DAL.GetSubIds(areaId);
        }
    }
}
