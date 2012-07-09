using System;
using System.Collections.Generic;
using System.Text;

using System.Data ;

namespace XYECOM.Business
{
    
    /// <summary>
    /// 用户等级业务类
    /// </summary>
    public class UserGradeRelation
    {
        private static readonly XYECOM.SQLServer.UserGradeRelation DAL = new XYECOM.SQLServer.UserGradeRelation();

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="info">实体对象</param>
        /// <returns>影响行数</returns>
        public int Insert(XYECOM.Model.UserGradeRelationInfo info)
        {
            return DAL.Insert(info);
        }
      
        /// <summary>
        /// 获取一条信息
        /// </summary>
        /// <param name="userId">用户编号Id</param>
        /// <returns>实体对象</returns>
        public XYECOM.Model.UserGradeRelationInfo GetItem(long userId)
        {
            return DAL.GetItem(userId);
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="info">实体对象</param>
        /// <returns>影响行数</returns>
        public int UpdateGradeRelation(Model.UserGradeRelationInfo info)
        {
            if (info == null) return 0;

            return DAL.UpdateGradeRelation(info);
        }
    }

}
