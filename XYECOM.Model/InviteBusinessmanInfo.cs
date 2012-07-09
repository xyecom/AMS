using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Model
{
    /// <summary>
    /// 招商加盟信息实体类
    /// </summary>
    public class InviteBusinessmanInfo : BaseInfo
    {
        //private Int64 _a_id;
        private string _a_area;
        private string _a_advice;
        private string _a_reason;

        public InviteBusinessmanInfo()
        {
            ModuleFlag = "investment";
        }

        /// <summary>
        /// 招商区域
        /// </summary>
        public string A_Area
        {
            get { return _a_area; }
            set { _a_area = value; }
        }

        private string _AreaName;

        public string AreaName
        {
            get { return _AreaName; }
            set { _AreaName = value; }
        }

        /// <summary>
        /// 推荐意见
        /// </summary>
        public string A_Advice
        {
            set { _a_advice = value; }
            get { return _a_advice; }
        }

        /// <summary>
        /// 未通过原因
        /// </summary>
        public string A_Reason
        {
            set { _a_reason = value; }
            get { return _a_reason; }
        }

        #region 新增的属性值

        private string quondamProduct;
        /// <summary>
        /// 以前代理的产品名称
        /// </summary>
        public string QuondamProduct
        {
            get { return quondamProduct; }
            set { quondamProduct = value; }
        }

        private string support;
        /// <summary>
        /// 可提供支持
        /// </summary>
        public string Support
        {
            get { return support; }
            set { support = value; }
        }

        private string demand;
        /// <summary>
        /// 对代理商要求
        /// </summary>
        public string Demand
        {
            get { return demand; }
            set { demand = value; }
        }

        private string url;
        /// <summary>
        /// 招商的网址
        /// </summary>
        public string URL
        {
            get { return url; }
            set { url = value; }
        }

        #endregion
    }
}
