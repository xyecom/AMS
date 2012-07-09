using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Label
{
    /// <summary>
    /// 外部参数信息实体类
    /// </summary>
    public class OuterParameterInfo
    {
        /// <summary>
        /// 地区Id，主要用于地方站的建设
        /// </summary>
        public int AreaId = 0;

        /// <summary>
        /// 行业Id，主要用于行业频道建设
        /// </summary>
        public int TradeId = 0;

        /// <summary>
        /// 产品分类Id
        /// </summary>
        public long ProTypeId = 0;

        /// <summary>
        /// 排序规则（不带 Order by）
        /// </summary>
        public string OrderStr = "";
    }
}
