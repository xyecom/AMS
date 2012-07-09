using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace XYECOM.Business
{
    /// <summary>
    /// 会员简历业务类
    /// </summary>
    public  class Resume
    {
        private static readonly XYECOM.SQLServer.Resume DAL = new XYECOM.SQLServer.Resume();

        /// <summary>
        /// 投简历
        /// </summary>
        /// <param name="U_ID">用户id</param>
        /// <param name="EI_ID">职位Id</param>
        /// <returns>影响行数</returns>
        public int AddResume(long U_ID, long EI_ID)
        {
            return DAL.AddResume(U_ID, EI_ID);
 
        }

        /// <summary>
        /// 根据用户编号Id得到用户简历信息
        /// </summary>
        /// <param name="U_ID">用户编号Id</param>
        /// <returns>用户简历类实体对象</returns>
        public XYECOM.Model.ResumeInfo GetItem(long U_ID)
        {
            return DAL.GetItem(U_ID);
 
        }

        /// <summary>
        /// 更新简历
        /// </summary>
        /// <param name="Re">简历类实体对象</param>
        /// <returns>影响行数</returns>
        public int Update(XYECOM.Model.ResumeInfo Re)
        {
            return DAL.Update(Re);
 
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="Re">简历类实体对象</param>
        /// <returns></returns>
        public int Insert(XYECOM.Model.ResumeInfo Re)
        {
            return DAL.Insert(Re);
 
        }

        /// <summary>
        /// 获取申请职位信息
        /// </summary>
        /// <param name="ER_ID">申请职位编号Id</param>
        /// <returns>申请职位信息</returns>
        public DataTable GetDataTable(long ER_ID)
        {
            return DAL.GetDataTable(ER_ID);
        }

        /// <summary>
        /// 修改简历状态
        /// </summary>
        /// <param name="RE_ID">申请职位Id</param>
        /// <param name="type">简历状体</param>
        /// <returns>影响行数</returns>
        public int UpdateType(long RE_ID, int type)
        {
            return DAL.UpdateType(RE_ID, type);
        }

        /// <summary>
        /// 删除申请职位记录
        /// </summary>
        /// <param name="ID">申请职位编号Id</param>
        /// <returns>影响行数</returns>
        public int Deletes(string ID)
        {
            return DAL.Deletes(ID);
        }
        
        /// <summary>
        /// 返回满足条件的简历
        /// </summary>
        /// <param name="PageSize">每页几条</param>
        /// <param name="PageIndex">第几页</param>
        /// <param name="strWhere">条件</param>
        /// <param name="strOrder">排序</param>
        /// <param name="strTableName">表明</param>
        /// <param name="strColumuName">列名</param>
        /// <param name="strPrimaryKey">主键</param>
        /// <returns></returns>
        public DataTable GetDataTable(int PageSize, int PageIndex, string strWhere, string strOrder, string strTableName, string strColumuName, string strPrimaryKey)
        {
            return DAL.GetDataTable(PageSize, PageIndex, strWhere, strOrder, strTableName, strColumuName, strPrimaryKey);
        }

        //public DataTable GetDataTables(long id, String tablename) {
        //    return DAL.GetDataTables(id, tablename);
        //}
        /// <summary>
        /// 查看招聘信息并更改报名状态
        /// </summary>
        /// <param name="EF_ID">报名批次编号</param>
        /// <param name="type">要更改的状态</param>
        /// <returns>数字,大于或等于0表成功,否则表失败</returns>
        public int UpdateLookTyep(long RE_ID, int type)
        {
            return DAL.UpdateLookTyep(RE_ID,type);
        }
    }
}
