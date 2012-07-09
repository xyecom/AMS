using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Data.SqlClient;

namespace XYECOM.Business
{
    /// <summary>
    /// 招商代理信息业务类
    /// </summary>
    public class InviteBusinessmanInfo
    {
        private static readonly XYECOM.SQLServer.InviteBusinessmanInfo DAL = new XYECOM.SQLServer.InviteBusinessmanInfo();

        /// <summary>
        /// 获取指定编号的招商代理对象
        /// </summary>
        /// <param name="IBI_ID">要获取的招商代理编号</param>
        /// <returns>该编号标示的对象</returns>
        public XYECOM.Model.InviteBusinessmanInfo GetItem(int IBI_ID)
        {
            if (IBI_ID <= 0) return null;

            return DAL.GetItem(IBI_ID);
        }

        /// <summary>
        /// 添加招商信息
        /// </summary>
        /// <param name="ei">实体类</param>
        /// <param name="eiid">所添加的招商信息的记录编号</param>
        /// <returns>受影响的行数</returns>
        public int Insert(XYECOM.Model.InviteBusinessmanInfo info, out int infoId)
        {
            return DAL.Insert(info, out infoId);
        }

        /// <summary>
        /// 修改招商信息
        /// </summary>
        /// <param name="ei">实体类</param>
        /// <returns>受影响的行数</returns>
        public int Update(XYECOM.Model.InviteBusinessmanInfo info)
        {
            return DAL.Update(info);
        }

        /// <summary>
        /// 获取满足指定条件的招商代理记录集
        /// </summary>
        /// <param name="strwhere">指定的where条件</param>
        /// <param name="strOrder">指定的order条件</param>
        /// <returns>满足条件的datatable类型的记录集</returns>
        public DataTable GetDataTable(string strwhere, string strOrder)
        {
            return DAL.GetDataTable(strwhere, strOrder);
        }

        /// <summary>
        /// 删除一条记录
        /// </summary>
        /// <param name="IBI_ID">记录编号</param>
        /// <returns>受影响的行数</returns>
        public int Delete(long IBI_ID)
        {
            new XYECOM.Business.Attachment().Delete(IBI_ID, XYECOM.Model.AttachmentItem.Investment, XYECOM.Model.UploadFileType.All);

            return DAL.Delete(IBI_ID);
        }


        /// <summary>
        /// 获取所有招商代理记录的DataTable类型的记录集
        /// </summary>
        /// <returns>DataTable类型的所有招商代理记录集</returns>
        public DataTable GetDataTable()
        {
            return DAL.GetDataTable();
        }
        /// <summary>
        /// 修改招商状态
        /// </summary>
        /// <param name="isPause">
        /// true:暂停招商
        /// false:招商进行中</param>
        /// <param name="IBI_ID_Scope">要修改的招商信息的编号范围,example:(1,3)</param>
        /// <returns>受影响的行数</returns>
        public int UpdateEntityState(bool isPause, string IBI_ID_Scope)
        {
            return DAL.UpdateEntityState(isPause, IBI_ID_Scope);
        }
        /// <summary>
        /// 删除多条记录
        /// </summary>
        /// <param name="IBI_ID_Scope">记录编号范围</param>
        /// <returns>受影响的行数</returns>
        public int Delete(string ids)
        {
            Business.Attachment attBLL = new Attachment();

            attBLL.Delete(ids, XYECOM.Model.AttachmentItem.Investment, XYECOM.Model.UploadFileType.All);

            return DAL.Delete(ids);
        }

        #region Audit Management
        /// <summary>
        /// 对该条信息审核通过
        /// </summary>
        /// <param name="IBI_ID">在对应标中的编号</param>
        /// <returns>受影响的行数</returns>
        public int AddAuditState(long IBI_ID, bool IsAudited, string A_Reason, string A_Advice)
        {
            return DAL.AddAuditState(IBI_ID, IsAudited, A_Reason, A_Advice);
        }
        /// <summary>
        /// 修改信息的审核状态
        /// </summary>
        /// <param name="IBI_ID">在对应标中的编号</param>
        /// <param name="isAudited">所在表</param>
        /// <returns>受影响的行数</returns>
        public int UpdateAuditState(long IBI_ID, bool isAudited, string A_Reason, string A_Advice)
        {
            return DAL.UpdateAuditState(IBI_ID, isAudited, A_Reason, A_Advice);
        }
        #endregion

        #region 修改推荐
        /// <summary>
        /// 更正指定编号的招商代理信息的推荐状态
        /// </summary>
        /// <param name="IBI_ID">要更改的招商代理编号</param>
        /// <param name="Vouch">要更改的状态</param>
        /// <returns>数字,大于或等于0表成功,否则表失败</returns>
        public int UpdateVouch(long IBI_ID, bool Vouch)
        {
            return DAL.UpdateVouch(IBI_ID, Vouch);
        }
        #endregion

        #region 获取一条招商信息
        /// <summary>
        /// 获取指定编号的招商代理信息的DataTable类型数据集
        /// </summary>
        /// <param name="IBI_ID">要获取的招商代理信息编号</param>
        /// <returns>该记录的datatable类型数据集</returns>
        public DataTable GetDataTable(long IBI_ID)
        {
            return DAL.GetDataTable(IBI_ID);
        }
        #endregion



        #region 批量移动
        /// <summary>
        /// 批量移动
        /// </summary>
        /// <returns>影响行数</returns>
        public int MoveInvestment(String strwhere, String content)
        {
            return DAL.MoveInvestment(strwhere, content);
        }
        #endregion
    }
}
