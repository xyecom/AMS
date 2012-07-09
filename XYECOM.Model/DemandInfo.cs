using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Model
{
    /// <summary>
    /// 投融资信息实体类
    /// </summary>
    public class DemandInfo : BaseInfo
    {
        private string _a_reason;
        private string _a_advice;


        public DemandInfo()
        {
            ModuleFlag = "venture";
        }

        /// <summary>
        /// 未通过原因
        /// </summary>
        public string A_Reason
        {
            set { _a_reason = value; }
            get { return _a_reason; }
        }
        /// <summary>
        /// 推荐意见
        /// </summary>
        public string A_Advice
        {
            set { _a_advice = value; }
            get { return _a_advice; }
        }

        #region 新增新的属性

        private string trade;
        /// <summary>
        /// 投融资所属行业
        /// </summary>
        public string Trade
        {
            get { return trade; }
            set { trade = value; }
        }

        private int typeId;
        /// <summary>
        /// 分类id
        /// </summary>
        public int TypeId
        {
            get { return typeId; }
            set { typeId = value; }
        }

        private string typeName = string.Empty;

        /// <summary>
        /// 投融资类型
        /// </summary>
        public string TypeName
        {
            get { return typeName; }
            set { typeName = value; }
        }

        private string area = string.Empty;

        /// <summary>
        /// 投融资地区
        /// </summary>
        public string Area
        {
            get { return area; }
            set { area = value; }
        }

        private string webSite = string.Empty;

        /// <summary>
        /// 融资项目网址
        /// </summary>
        public string WebSite
        {
            get { return webSite; }
            set { webSite = value; }
        }
        private string summary = string.Empty;

        /// <summary>
        /// 项目摘要
        /// </summary>
        public string Summary
        {
            get { return summary; }
            set { summary = value; }
        }

        private int tradeId;
        /// <summary>
        /// 所属行业编号
        /// </summary>
        public int TradeId
        {
            get { return tradeId; }
            set { tradeId = value; }
        }

        private int areaId;

        /// <summary>
        /// 投融资地区编号
        /// </summary>
        public int AreaId
        {
            get { return areaId; }
            set { areaId = value; }
        }
        #endregion
    }
}
