//------------------------------------------------------------------------------
//
// file name：CompanyProductTypeManager.cs
// author: wangzhen
// create date：2011-3-29 16:07:07
//
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Data;

namespace XYECOM.Business
{
    /// <summary>
    /// Business logic for dbo.XY_CompanyProductType.
    /// </summary>
    public partial class CompanyProductTypeManager
    {
        private XYECOM.SQLServer.CompanyProductTypeAccess comProTypeDAL = new SQLServer.CompanyProductTypeAccess();

        /// <summary>
        /// 根据用户编号获取该用户的所有自定义分类（王振添加 2011-03-30）
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public DataTable GetListByUserId(long userid)
        {
            return comProTypeDAL.GetListByUserId(userid);
        }
        
        /// <summary>
        /// 根据用户和产品编号获取该用户的所有自定义分类（王振添加 2011-03-30）
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public Model.CompanyProductTypeInfo GetListByIdAndUserId(int id, int userid)
        {
            if (id <= 0 || userid <= 0)
            {
                return null;
            }
            return comProTypeDAL.GetListByIdAndUserId(id, userid);
        }

        /// <summary>
        /// 获取某个用户的所以自定义顶级分类
        /// </summary>
        /// <returns></returns>
        public DataTable GetRootType(int userId)
        {
            DataTable data = new DataTable();
            if (userId <= 0)
            {
                return data;
            }
            data = comProTypeDAL.GetRootType(userId);
            return data;
        }
    }
}

