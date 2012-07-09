using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using XYECOM.Model;

namespace XYECOM.Business
{
    /// <summary>
    /// 合作信息的业务类
    /// </summary>
    public class Show
    {
        /// <summary>
        /// 由DAL工厂类生成合作信息的接口对象
        /// </summary>
        private static readonly XYECOM.SQLServer.Show DAL = new XYECOM.SQLServer.Show();

        /// <summary>
        /// 添加一条新的合作信息对象
        /// </summary>
        /// <param name="info">要添加的新的合作信息对象</param>
        /// <param name="infoId"></param>
        /// <returns>数字,大于或等于0表成功,否表失败</returns>
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
        /// 更改一条指定的合作信息对象
        /// </summary>
        /// <param name="info">要修改的合作信息对象</param>
        /// <returns>数字,大于或等于0表成功,否则表失败</returns>
        public int Update(ShowInfo info)
        {
            if (object.Equals(null, info))
                return -2;

            return DAL.Update(info);
        }

        /// <summary>
        /// 删除指定编号的展会
        /// </summary>
        /// <param name="ids">展会Id集合</param>
        /// <returns>数字,大于或等于0表删除成功,否则表失败</returns>
        public int Delete(string ids)
        {
            if (string.IsNullOrEmpty(ids))
                return -2;

            Business.Attachment attBLL = new Attachment();

            attBLL.Delete(ids, XYECOM.Model.AttachmentItem.Exhibition, UploadFileType.All);

            return DAL.Delete(ids);
        }

        /// <summary>
        /// 获取满足指定条件的合作信息对象集
        /// </summary>
        /// <param name="strWhere">指定的where条件</param>
        /// <param name="Order">指定的order条件</param>
        /// <returns>满足指定条件的DataTable对象集</returns>
        public DataTable GetDataTable(string strWhere, string Order)
        {
            DataTable dt = null;
            if (string.IsNullOrEmpty(strWhere))
                return dt;

            return DAL.GetDataTable(strWhere, Order);
        }

        /// <summary>
        /// 获取指定编号的合作信息对象
        /// </summary>
        /// <param name="infoId">指定编号的合作信息对象</param>
        /// <returns>该编号对应的合作信息对象</returns>
        public ShowInfo GetItem(Int64 infoId)
        {
            ShowInfo shinfo = null;
            if (infoId <= 0)
                return shinfo;

            return DAL.GetItem(infoId);
        }

        /// <summary>
        /// 更改指定编号的合作信息的推荐状态
        /// </summary>
        /// <param name="infoId">指定的合作信息的编号</param>
        /// <param name="IsCommend">更改的推荐状态</param>
        /// <returns>数字,大于或等于0表成功,否则表失败</returns>
        public int SetIsCommend(Int64 infoId, bool IsCommend)
        {
            if (infoId <= 0 || object.Equals(null, IsCommend))
                return -2;

            return DAL.SetIsCommend(infoId, IsCommend);
        }
    }
}
