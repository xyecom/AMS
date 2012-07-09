using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using XYECOM.Model;

namespace XYECOM.Business
{
    /// <summary>
    /// ������Ϣ��ҵ����
    /// </summary>
    public class Show
    {
        /// <summary>
        /// ��DAL���������ɺ�����Ϣ�Ľӿڶ���
        /// </summary>
        private static readonly XYECOM.SQLServer.Show DAL = new XYECOM.SQLServer.Show();

        /// <summary>
        /// ���һ���µĺ�����Ϣ����
        /// </summary>
        /// <param name="info">Ҫ��ӵ��µĺ�����Ϣ����</param>
        /// <param name="infoId"></param>
        /// <returns>����,���ڻ����0��ɹ�,���ʧ��</returns>
        public int Insert(ShowInfo info,out long infoId)
        {
            if (object.Equals(null, info))
            {
                infoId = -1;
                return -2;
            }
               

            return DAL.Insert(info,out infoId);
        }

        /// <summary>
        /// ����һ��ָ���ĺ�����Ϣ����
        /// </summary>
        /// <param name="info">Ҫ�޸ĵĺ�����Ϣ����</param>
        /// <returns>����,���ڻ����0��ɹ�,�����ʧ��</returns>
        public int Update(ShowInfo info)
        {
            if (object.Equals(null, info))
                return -2;

            return DAL.Update(info);
        }

        /// <summary>
        /// ɾ��ָ����ŵ�չ��
        /// </summary>
        /// <param name="ids">չ��Id����</param>
        /// <returns>����,���ڻ����0��ɾ���ɹ�,�����ʧ��</returns>
        public int Delete(string ids)
        {
            if (string.IsNullOrEmpty(ids))
                return -2;

            Business.Attachment attBLL = new Attachment();

            attBLL.Delete(ids, XYECOM.Model.AttachmentItem.Exhibition, UploadFileType.All);

            return DAL.Delete(ids);
        }

        /// <summary>
        /// ��ȡ����ָ�������ĺ�����Ϣ����
        /// </summary>
        /// <param name="strWhere">ָ����where����</param>
        /// <param name="Order">ָ����order����</param>
        /// <returns>����ָ��������DataTable����</returns>
        public DataTable GetDataTable(string strWhere, string Order)
        {
            DataTable dt = null;
            if (string.IsNullOrEmpty(strWhere))
                return dt;

            return DAL.GetDataTable(strWhere, Order);
        }

        /// <summary>
        /// ��ȡָ����ŵĺ�����Ϣ����
        /// </summary>
        /// <param name="infoId">ָ����ŵĺ�����Ϣ����</param>
        /// <returns>�ñ�Ŷ�Ӧ�ĺ�����Ϣ����</returns>
        public ShowInfo GetItem(Int64 infoId)
        {
            ShowInfo shinfo = null;
            if (infoId <= 0)
                return shinfo;

            return DAL.GetItem(infoId);
        }

        /// <summary>
        /// ����ָ����ŵĺ�����Ϣ���Ƽ�״̬
        /// </summary>
        /// <param name="infoId">ָ���ĺ�����Ϣ�ı��</param>
        /// <param name="IsCommend">���ĵ��Ƽ�״̬</param>
        /// <returns>����,���ڻ����0��ɹ�,�����ʧ��</returns>
        public int SetIsCommend(Int64 infoId, bool IsCommend)
        {
            if (infoId <= 0 || object.Equals(null, IsCommend))
                return -2;

            return DAL.SetIsCommend(infoId, IsCommend);
        }
    }
}
