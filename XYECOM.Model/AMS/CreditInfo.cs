using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Model.AMS
{
    /// <summary>
    /// 债权信息
    /// </summary>
    public class CreditInfo
    {
        /// <summary>
        /// 债权编号
        /// </summary>	
        public int CreditId
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
        /// 欠款人姓名
        /// </summary>
        public string DebtorName
        {
            get;
            set;
        }
        /// <summary>
        /// 欠款人联系电话
        /// </summary>
        public string DebtorTelpone
        {
            get;
            set;
        }
        /// <summary>
        /// 催收期限
        /// </summary>
        public string CollectionPeriod
        {
            get;
            set;
        }
        /// <summary>
        /// 欠款原因
        /// </summary>
        public string DebtorReason
        {
            get;
            set;
        }
        /// <summary>
        /// 欠款金额
        /// </summary>
        public decimal Arrears
        {
            get;
            set;
        }
        /// <summary>
        /// 悬赏金额
        /// </summary>
        public decimal Bounty
        {
            get;
            set;
        }
        /// <summary>
        /// 备注
        /// </summary>

        public string Remark
        {
            get;
            set;
        }
        /// <summary>
        /// 授权类型
        /// </summary>
        public string LicenseType
        {
            get;
            set;
        }
        /// <summary>
        /// 欠款类型
        /// </summary>
        public string DebtorType
        {
            get;
            set;
        }
        /// <summary>
        /// 案情简介
        /// </summary>
        public string Introduction
        {
            get;
            set;
        }
        /// <summary>
        /// 账龄
        /// </summary>
        public int Age
        {
            get;
            set;
        }
        /// <summary>
        /// 是否在诉讼期
        /// </summary>
        public bool IsInLitigation
        {
            get;
            set;
        }
        /// <summary>
        /// 是否经过诉讼
        /// </summary>
        public bool IsLitigationed
        {
            get;
            set;
        }
        /// <summary>
        /// 是否自行催收过
        /// </summary>
        public bool IsSelfCollection
        {
            get;
            set;
        }
        /// <summary>
        /// 债务人债务确认
        /// </summary>
        public bool IsConfirm
        {
            get;
            set;
        }
        /// <summary>
        /// 债权凭证
        /// </summary>
        public string DebtObligation
        {
            get;
            set;
        }
        /// <summary>
        /// 所属部门
        /// </summary>
        public int DepartId
        {
            get;
            set;
        }
        /// <summary>
        /// 所属公司
        /// </summary>

        public int UserId
        {
            get;
            set;
        }
        /// <summary>
        /// 审核状态
        /// </summary>

        public int ApprovaStatus
        {
            get;
            set;
        }
        /// <summary>
        /// 创建时间
        /// </summary>

        public DateTime CreateDate
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
        /// 是否是草稿
        /// </summary>

        public bool IsDraft
        {
            get;
            set;
        }
        /// <summary>
        /// 案件进展状态
        /// </summary>
        public int ProcessState
        {
            get;
            set;
        }
        /// <summary>
        /// 所属地区
        /// </summary>
        public int AreaId
        {
            get;
            set;
        }
        /// <summary>
        /// 债权人是否已评价
        /// </summary>
        public int IsCreditEvaluation
        {
            get;
            set;
        }
        /// <summary>
        /// 服务商是否已评价
        /// </summary>
        public int IsServerEvaluation
        {
            get;
            set;
        }
    }
}
