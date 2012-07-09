using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace XYECOM.Business
{
    /// <summary>
    /// 证书业务类
    /// </summary>
    public class Certificate
    {
        private static readonly XYECOM.SQLServer.Certificate DAL = new XYECOM.SQLServer.Certificate();
        /// <summary>
        /// 添加证书
        /// </summary>
        /// <param name="Cet">证书实体</param>
        /// <returns>是否成功</returns>
        public int Insert(XYECOM.Model.CertificateInfo Cet, out long CE_ID)
        {
            return DAL.Insert(Cet, out CE_ID); 
        }
        /// <summary>
        /// 修改证书
        /// </summary>
        /// <param name="Cet">证书实体</param>
        /// <returns>是否成功</returns>
        public int Update(XYECOM.Model.CertificateInfo Cet)
        {
            return DAL.Update(Cet); 
        }
        /// <summary>
        /// 根据id返会证书
        /// </summary>
        /// <param name="CE_ID">证书编号</param>
        /// <returns>证书实体</returns>
        public XYECOM.Model.CertificateInfo GetItem(long CE_ID)
        {
            if (CE_ID <= 0) return null;

            return DAL.GetItem(CE_ID);
        }
        ///// <summary>
        ///// 返回符合条件的记录
        ///// </summary>
        ///// <param name="strWhere"> 条件</param>
        ///// <param name="strOrderBy">排序字段</param>
        ///// <returns>datatable数据表 </returns>
        //public DataTable GetDataTable(string strWhere, string strOrderBy)
        //{
        //    return DAL.GetDataTable(strWhere, strOrderBy);
 
        //}
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="CE_ID">id s</param>
        /// <returns>是否成功</returns>
        public int Deletes(string ids)
        {
            Business.Attachment attBLL = new Attachment();

            attBLL.Delete(ids, XYECOM.Model.AttachmentItem.Certificate, XYECOM.Model.UploadFileType.All);

            return DAL.Deletes(ids);
        }
        /// <summary>
        /// 启用
        /// </summary>
        /// <param name="CE_ID">证书编号</param>
        /// <param name="isopen">启用true不启用 false </param>
        /// <returns>是否成功</returns>
        public int UpdateIsopen(long CE_ID, bool isopen)
        {
            return DAL.UpdateIsopen(CE_ID, isopen);
        }
    }
}
