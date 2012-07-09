using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Data.SqlClient;

namespace XYECOM.Business
{
    /// <summary>
    /// 意见反馈业务类
    /// </summary>
    public class Feedback
    {

        private static readonly XYECOM.SQLServer.Feedback DAL = new XYECOM.SQLServer.Feedback();

        #region 添加意见反馈
        /// <summary>
        /// 添加意见反馈
        /// </summary>
        /// <param name="efl">意见反馈属性类对象</param>
        /// <returns>数字。大于等于0表示添加成功</returns>
        public int Insert(XYECOM.Model.FeedbackInfo info)
        {
            if (info != null) return DAL.Insert(info);
            else return -2;
        }
        #endregion

        #region 删除意见反馈信息
        /// <summary>
        /// 删除意见反馈信息
        /// </summary>
        /// <param name="FL_IDs">意见反馈信息编号字符串</param>
        /// <returns>数字。大于等于0表示删除成功</returns>
        public int Delete(string FeedbackID)
        {
            if (FeedbackID != null) return DAL.Delete(FeedbackID);
            else return -1;
        }
        #endregion

        #region 获取意见反馈信息
        /// <summary>
        /// 获取意见反馈信息
        /// </summary>
        /// <param name="strWhere">条件</param>
        /// <returns>意见反馈信息</returns>
        public DataTable GetDataTable(string strWhere)
        {
            if (strWhere != "") return DAL.GetDataTable(strWhere);
            else return new DataTable();;
        }
        /// <summary>
        /// 返回一条意见反馈信息
        /// </summary>
        /// <param name="FeedbackID">意见反馈信息编号</param>
        /// <returns>意见反馈信息实体对象</returns>
        public XYECOM.Model.FeedbackInfo GetItem(long FeedbackID)
        {
            if (FeedbackID <= 0) return null;
            else return DAL.GetItem(FeedbackID);                   
        }

        /// <summary>
        /// 更新一条意见反馈信息
        /// </summary>
        /// <param name="FeedbackID">意见反馈信息编号</param>
        /// <param name="IsAdminAgree">管理员操作标识</param>
        /// <returns>影响行数</returns>
        public int UpateItemById(int FeedbackID, int IsAdminAgree)
        {
            if (FeedbackID <= 0) return 0;
            else return DAL.UpdateFeedBackById(FeedbackID, IsAdminAgree);
        }

        #endregion
    
    }
}
