using System;
using System.Collections.Generic;
using System.Text;


using System.Data;

namespace XYECOM.Business
{
    /// <summary>
    /// 投融资信息业务类
    /// </summary>
    public class Demand
    {

        private static readonly XYECOM.SQLServer.Demand DAL = new XYECOM.SQLServer.Demand();
        /// <summary>
        /// 添加加工信息
        /// </summary>
        /// <param name="info">实体类</param>
        /// <returns>受影响的行数</returns>
        public int Insert(XYECOM.Model.DemandInfo info, out int infoId)
        {
            infoId = 0;
            if (info == null)
            {
                return 0;
            }
            return DAL.Insert(info, out infoId);
        }

        /// <summary>
        /// 修改求购信息
        /// </summary>
        /// <param name="ea">实体类</param>
        /// <returns>受影响的行数</returns>
        public int Update(XYECOM.Model.DemandInfo es)
        {
            return DAL.Update(es);
        }

        /// <summary>
        /// 获取一条记录
        /// </summary>
        /// <param name="SD_ID">记录编号</param>
        /// <returns>一条记录</returns>
        public XYECOM.Model.DemandInfo GetItem(int SD_ID)
        {
            if (SD_ID < 1)
            {
                return null;
            }
            return DAL.GetItem(SD_ID);
        }

        /// <summary>
        /// 删除多条记录
        /// </summary>
        /// <param name="SD_ID">记录编号</param>
        /// <returns>受影响的行数</returns>
        public int Deletes(string ids)
        {
            if (string.IsNullOrEmpty(ids))
            {
                return 0;
            }
            //new XYECOM.Business.Attachment().Delete(ids, XYECOM.Model.AttachmentItem.Venture, XYECOM.Model.UploadFileType.All);

            return DAL.DeleteByIds(ids);
        }


        /// <summary>
        /// 删除操作(删除单条)
        /// </summary>
        /// <param name="infoId">信息主键Id</param>
        /// <returns>受影响的行数</returns>
        public int Delete(int infoId)
        {
            if (infoId < 1)
            {
                return 0;
            }
            return DAL.Delete(infoId);
        }

        /// <summary>
        /// 修改推荐信息
        /// </summary>
        /// <param name="es">实体类</param>
        /// <returns>受影响的行数</returns>
        public int UpdateSD_Vouch(XYECOM.Model.DemandInfo es)
        {
            return DAL.UpdateSD_Vouch(es);
        }
        /// <summary>
        /// 修改暂停信息
        /// </summary>
        /// <param name="SD_ID">编号</param>
        /// <returns>影响行数</returns>
        public int UpdateSD_Pause(string SD_ID)
        {
            return DAL.UpdateSD_Pause(SD_ID);
        }
        /// <summary>
        /// 修改投融资信息的审核状态
        /// </summary>
        /// <param name="id">投融资信息ID</param>
        /// <param name="state">要审核的状态</param>
        /// <returns>受影响的行数</returns>
        public int UpdateStateById(int id, int state)
        {
            if (id < 1)
            {
                return 0;
            }
            return DAL.UpdateStateById(id,state);
        }

        /// <summary>
        /// 修改投融资信息的推荐状态
        /// </summary>
        /// <param name="id">投融资信息</param>
        /// <returns>受影响的行数</returns>
        public int UpdateVouchById(int id)
        {
            if (id < 1)
            {
                return 0;
            }
            return DAL.UpdateVouchById(id);
        }
        /// <summary>
        /// 修改投融资信息的推荐状态
        /// </summary>
        /// <param name="id">投融资信息</param>
        /// <param name="vouch">要推荐的状态</param>
        /// <returns>受影响的行数</returns>
        public int UpdateVouchById(int id,int vouch)
        {
            if (id < 1)
            {
                return 0;
            }
            return DAL.UpdateVouchById(id,vouch);
        }

        #region 批量移动
        /// <summary>
        /// 批量移动
        /// </summary>
        /// <returns>影响行数</returns>
        public int MoveMachining(String strwhere, String content)
        {
            return DAL.MoveMachining(strwhere, content);
        }
        #endregion
    }
}
