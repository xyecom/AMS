using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Model.AMS
{
    /// <summary>
    /// 抵债信息
    /// </summary>
    public class ForeclosedInfo
    {
        /// <summary>
        /// 编号
        /// </summary>
        public int ForeclosedId
        {
            get;
            set;
        }
        /// <summary>
        /// 标题
        /// </summary>
        public string Title
        {
            get;
            set;
        }


        /// <summary>
        /// 物品编号
        /// </summary>
        public string IdentityNumber
        {
            get;
            set;
        }

        /// <summary>
        /// 目前最高价
        /// </summary>
        public decimal HighPrice
        {
            get;
            set;
        }

        /// <summary>
        /// 物品所在地
        /// </summary>
        public string Address
        {
            get;
            set;
        }

        /// <summary>
        /// 地区
        /// </summary>
        public int AreaId
        {
            get;
            set;
        }

        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime EndDate
        {
            get;
            set;
        }

        /// <summary>
        /// 创建时间
        /// </summary>
        public string CreateDate
        {
            get;
            set;
        }

        /// <summary>
        /// 审核状态
        /// </summary>
        public int State
        {
            get;
            set;
        }

        /// <summary>
        /// 审核通过时间
        /// </summary>
        public DateTime PassDate
        {
            get;
            set;
        }

        /// <summary>
        /// 所属公司
        /// </summary>
        public int? UserId
        {
            get;
            set;
        }

        /// <summary>
        /// 所属用户、部门
        /// </summary>
        public int? DepartmentId
        {
            get;
            set;
        }

        /// <summary>
        /// 底价 
        /// </summary>
        public decimal LinePrice
        {
            get;
            set;
        }
        /// <summary>
        /// 说明
        /// </summary>
        public string Description
        {
            get;
            set;
        }

        /// <summary>
        /// 类型
        /// </summary>
        public string TypeName
        {
            get;
            set;
        }

        /// <summary>
        /// 类型编号（扩展字段）
        /// </summary>
        public int? TypeID
        {
            get;
            set;
        }
    }
}
