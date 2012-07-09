using System;
using System.Collections.Generic;
using System.Text;

using System.Data;



namespace XYECOM.Business
{
    /// <summary>
    /// 服务信息业务类
    /// </summary>
    public class ServiceInfo
    {
        private static readonly XYECOM.SQLServer.ServiceInfo DAL = new XYECOM.SQLServer.ServiceInfo();

        #region 添加服务信息
        /// <summary>
        /// 添加服务信息
        /// </summary>
        /// <param name="es">服务信息类的实体对象</param>
        /// <param name="infoId">服务信息编号Id</param>
        /// <returns>影响行数</returns>
        public int Insert(XYECOM.Model.ServiecInfo es,out int infoId)
        {
            return DAL.Insert(es, out infoId);

        }
        #endregion 

        #region 修改服务信息
        /// <summary>
        /// 修改服务信息
        /// </summary>
        /// <param name="es">服务信息类实体对象</param>
        /// <returns>影响行数</returns>
        public int Update(XYECOM.Model.ServiecInfo es)
        {
            return DAL.Update(es);
        }
        #endregion 
        
        #region 读一条服务信息
        /// <summary>
        /// 读取一条服务信息
        /// </summary>
        /// <param name="S_ID">服务信息编号Id</param>
        /// <returns>服务信息类实体对象</returns>
        public XYECOM.Model.ServiecInfo GetItem(int S_ID)
        {
            return DAL.GetItem(S_ID);
        }
        #endregion  

        #region  删除多条记录
        /// <summary>
        /// 删除多条记录
        /// </summary>
        /// <param name="ids">记录编号集合</param>
        /// <returns>影响行数</returns>
        public int Deletes(string ids)
        {
            new XYECOM.Business.Attachment().Delete(ids, XYECOM.Model.AttachmentItem.Service, XYECOM.Model.UploadFileType.All);

            return DAL.Deletes(ids);
        }
        #endregion

        #region 修改推荐信息
        /// <summary>
        /// 修改推荐信息
        /// </summary>
        /// <param name="es">服务信息类实体对象</param>
        /// <returns>影响行数</returns>
        public int UpdateVouch(XYECOM.Model.ServiecInfo es)
        {
            return DAL.UpdateVouch(es);
        }
        #endregion

        #region  修改暂停信
        /// <summary>
        /// 修改暂停
        /// </summary>
        /// <param name="S_ID">服务信息编号Id</param>
        /// <returns>影响行数</returns>
        public int UpdatePause(string S_ID)
        {
            return DAL.UpdatePause(S_ID);
        }
        #endregion

        #region 批量移动
        /// <summary>
        /// 批量移动
        /// </summary>
        /// <returns>影响行数</returns>
        public int MoveService(String strwhere, String content)
        {
            return DAL.MoveService(strwhere, content);
        }
        #endregion
    }
}