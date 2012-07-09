using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Business
{
    /// <summary>
    /// �����ǩҵ����
    /// </summary>
    public class ClassLabel
    {
        private static readonly XYECOM.SQLServer.ClassLabel DAL = new XYECOM.SQLServer.ClassLabel();
        /// <summary>
        /// ���ݷ����ǩ���ƻ�ȡ�����ǩʵ�����
        /// </summary>
        /// <param name="labelName">�����ǩ����</param>
        /// <returns>�����ǩʵ�����</returns>
        public Model.ClassLabelInfo GetItem(string labelName)
        {
            if (String.IsNullOrEmpty(labelName) || labelName == "") return null;

            return DAL.GetItem(labelName);
        }

        public XYECOM.Model.ClassLabelInfo GetItem(int labelId)
        {
            return DAL.GetItem(labelId);
        }

        public int Update(XYECOM.Model.ClassLabelInfo info)
        {
            return DAL.Update(info);
        }

        public int Insert(XYECOM.Model.ClassLabelInfo info)
        {
            return DAL.Insert(info);
        }

        public int Delete(int p)
        {
            return DAL.Delete(p);
        }

        public bool IsExists(string p)
        {
            return DAL.IsExists(p);
        }
    }
}
