using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Label
{
    /// <summary>
    /// 分页标签通用接口
    /// </summary>
    public interface IPaging
    {
        /// <summary>
        /// 每页记录条数
        /// </summary>
        int PageSize { get;set;}

        /// <summary>
        /// 自定义页数
        /// </summary>
        int CustomPageSize { get;set;}

        /// <summary>
        /// 记录总数
        /// </summary>
        int TotalRecord { get;set;}

        /// <summary>
        /// 总页数
        /// </summary>
        int PageCount { set;get;}

        /// <summary>
        /// 当前页
        /// </summary>
        int PageIndex { get;set;}

        /// <summary>
        /// 页面URI地址
        /// </summary>
        string PageURL { get;set;}

        /// <summary>
        /// 下一页链接
        /// </summary>
        string NextPage{get;set;}

        /// <summary>
        /// 上一页链接
        /// </summary>
        string PreviousPage{get;set;}

        /// <summary>
        /// 首页
        /// </summary>
        string FirstPage { get;set;}

        /// <summary>
        /// 尾页
        /// </summary>
        string LastPage { get;set;}

        /// <summary>
        /// 数字页码列表代码
        /// </summary>
        string NumPage{get;set;}

        /// <summary>
        /// 搜索条件
        /// </summary>
        string StrPageSearchWhere { get;set;}

        /// <summary>
        /// 关键字竞价信息条件
        /// </summary>
        string StrKeySearchWhere { get;set;}

        /// <summary>
        /// 创建分类相关代码
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageUrl"></param>
        /// <param name="default_page">当pageUrl无法匹配时使用的默认页面</param>
        /// <param name="moduleFlag">模块标识</param>
        /// <returns></returns>
        void SetPagination(int pageIndex,string pageUrl,SEARCH_PAGE_LIST default_page,string moduleFlag);
    }
}
