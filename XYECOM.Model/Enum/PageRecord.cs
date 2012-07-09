using System;
using System.Collections.Generic;

using System.Text;

namespace XYECOM.Model
{
    /// <summary>
    /// 审核状态枚举
    /// </summary>
    public enum PageRecord
    {
        /// <summary>
        /// 网店其他页(网店首页,列表页,分类页等)
        /// </summary>
        OtherRecord,

        /// <summary>
        /// 产品信息页
        /// </summary>
        ProRecord,

        /// <summary>
        /// 融资信息页
        /// </summary>
        VentureRecord,

        /// <summary>
        /// 资讯信息页
        /// </summary>
        NewsRecord,

        /// <summary>
        /// 服务信息页
        /// </summary>
        ServiceRecord,

        /// <summary>
        /// 代理信息页
        /// </summary>
        InvestmentRecord,

        /// <summary>
        /// 品牌信息页
        /// </summary>
        BrandRecord,

        /// <summary>
        /// 网店页(标识)
        /// </summary>
        ShopRecord
    }
}
