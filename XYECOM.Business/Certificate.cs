using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace XYECOM.Business
{
    /// <summary>
    /// ֤��ҵ����
    /// </summary>
    public class Certificate
    {
        private static readonly XYECOM.SQLServer.Certificate DAL = new XYECOM.SQLServer.Certificate();
        /// <summary>
        /// ���֤��
        /// </summary>
        /// <param name="Cet">֤��ʵ��</param>
        /// <returns>�Ƿ�ɹ�</returns>
        public int Insert(XYECOM.Model.CertificateInfo Cet, out long CE_ID)
        {
            return DAL.Insert(Cet, out CE_ID); 
        }
        /// <summary>
        /// �޸�֤��
        /// </summary>
        /// <param name="Cet">֤��ʵ��</param>
        /// <returns>�Ƿ�ɹ�</returns>
        public int Update(XYECOM.Model.CertificateInfo Cet)
        {
            return DAL.Update(Cet); 
        }
        /// <summary>
        /// ����id����֤��
        /// </summary>
        /// <param name="CE_ID">֤����</param>
        /// <returns>֤��ʵ��</returns>
        public XYECOM.Model.CertificateInfo GetItem(long CE_ID)
        {
            if (CE_ID <= 0) return null;

            return DAL.GetItem(CE_ID);
        }
        ///// <summary>
        ///// ���ط��������ļ�¼
        ///// </summary>
        ///// <param name="strWhere"> ����</param>
        ///// <param name="strOrderBy">�����ֶ�</param>
        ///// <returns>datatable���ݱ� </returns>
        //public DataTable GetDataTable(string strWhere, string strOrderBy)
        //{
        //    return DAL.GetDataTable(strWhere, strOrderBy);
 
        //}
        /// <summary>
        /// ɾ��
        /// </summary>
        /// <param name="CE_ID">id s</param>
        /// <returns>�Ƿ�ɹ�</returns>
        public int Deletes(string ids)
        {
            Business.Attachment attBLL = new Attachment();

            attBLL.Delete(ids, XYECOM.Model.AttachmentItem.Certificate, XYECOM.Model.UploadFileType.All);

            return DAL.Deletes(ids);
        }
        /// <summary>
        /// ����
        /// </summary>
        /// <param name="CE_ID">֤����</param>
        /// <param name="isopen">����true������ false </param>
        /// <returns>�Ƿ�ɹ�</returns>
        public int UpdateIsopen(long CE_ID, bool isopen)
        {
            return DAL.UpdateIsopen(CE_ID, isopen);
        }
    }
}
