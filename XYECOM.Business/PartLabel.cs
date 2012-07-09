using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Business
{
    /// <summary>
    /// ��ҵר���ǩҵ����
    /// </summary>
    public class PartLabel
    {
        private static readonly XYECOM.SQLServer.PartLabel DAL = new XYECOM.SQLServer.PartLabel();

        /// <summary>
        /// ����ר���ǩ
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public int Insert(Model.PartLabelInfo info)
        {
            if (info == null) return 0;

            return DAL.Update(info);
        }

        /// <summary>
        /// �༭ר���ǩ
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public int Update(Model.PartLabelInfo info)
        {
            if (info == null) return 0;

            return DAL.Update(info);
        }

        /// <summary>
        /// ɾ������
        /// </summary>
        /// <param name="partId"></param>
        /// <returns></returns>
        public int Delete(int partId)
        {
            if (partId <= 0) return 0;

            return DAL.Delete(partId);
        }

        /// <summary>
        /// ���ݱ�ǩ���ƻ�ȡ����
        /// </summary>
        /// <param name="labelName"></param>
        /// <returns></returns>
        public Model.PartLabelInfo GetItem(string labelName)
        {
            if (string.IsNullOrEmpty(labelName) || labelName.Trim().Equals("")) return null;

            return DAL.GetItem(labelName);
        }

        /// <summary>
        /// ���ݱ�ǩId��ȡ����
        /// </summary>
        /// <param name="partId">��ǩId</param>
        /// <returns></returns>
        public Model.PartLabelInfo GetItem(int partId)
        {
            if (partId <= 0) return null;

            return DAL.GetItem(partId);
        }
    }
}
