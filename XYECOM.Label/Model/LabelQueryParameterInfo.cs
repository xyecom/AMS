using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Label
{
    /**************************************************
     * XYECOM.Label.LabelParameter.cs
     * 创建标识：TC 20080618
     * 
     * 功能描述：标签参数实体类
     * 
     *************************************************/

    /// <summary>
    /// 标签数据查询参数实体类
    /// </summary>
    public class LabelQueryParameterInfo
    {
        #region 通用参数
        /// <summary>
        /// 主键
        /// </summary>
        public string PrimaryKey = "";
        /// <summary>
        /// 调用数据条数
        /// </summary>
        public int TopNumbers = 0;
        /// <summary>
        /// 条件
        /// </summary>
        public string Condition = "";

        #region 原数据读取方法需要的排序参数
        /// <summary>
        /// 排序
        /// </summary>
        public string Order = "";
        #endregion

        #region 针对新分类方法需要的参数
        /// <summary>
        /// 排序字段名称
        /// </summary>
        private string sortFields ="";

        public string SortFields
        {
            get {
                if (string.IsNullOrEmpty(sortFields))
                    return "";

                return sortFields;
            }
            set 
            {
                sortFields = value;
            }
        }
        #endregion

        /// 数据源名称
        /// </summary>
        public string DataSourceName = "";
        /// <summary>
        /// 数据列名集
        /// </summary>
        /// 
        private string columns;
        public string Columns
        {
            get 
            {
                if (String.IsNullOrEmpty(columns) || null == columns || columns.Trim().Equals(""))
                    columns = "*";

                return columns;
            }
            set 
            {
                columns = value;
            }
        }
        /// <summary>
        /// 信息标题字数
        /// </summary>
        public int TitleFontNumbers = 0;
        /// <summary>
        /// 产品介绍字数
        /// </summary>
        public int ProductSummaryFontNumbers = 0;
        /// <summary>
        /// 公司名称字数
        /// </summary>
        public int CompanyNameFontNumbers = 0;
        /// <summary>
        /// 公司简介字数
        /// </summary>
        public int CompanySummaryFontNumbers = 0;
        /// <summary>
        /// 日期格式
        /// </summary>
        public string DateFormat = "";
        /// <summary>
        /// 信息类型
        /// </summary>
        public string InfoType = "";

        #endregion

        #region 新闻通用
        /// <summary>
        /// 新闻栏目Id
        /// </summary>
        public int NewsChannelId = 0;

        /// <summary>
        /// 新闻导读字数
        /// </summary>
        public int NewsLeadinFontNumber = 0;

        #endregion

        #region 幻灯新闻专用

        /// <summary>
        /// 幻灯宽度
        /// </summary>
        public int SlideWidth =0;
        /// <summary>
        /// 幻灯高度
        /// </summary>
        public int SlideHeight = 0;
        /// <summary>
        /// 幻灯文本高度
        /// </summary>
        public int SlideTextHeight = 0;

        #endregion

        #region 友情链接专用
        
        /// <summary>
        /// 友情链接类型
        /// </summary>
        public int FriendLinkType = 0;
        /// <summary>
        /// 友情链接提示
        /// </summary>
        public bool IsFriendLinkAlt = false;

        #endregion

        #region 热门关键字专用
        public string ToPage = "";
        #endregion

        #region 模块名称 地区用 liujia 2008-11-17
        /// <summary>
        /// 模块名称
        /// </summary>
        public string moduleName = "";
        #endregion
    }
}
