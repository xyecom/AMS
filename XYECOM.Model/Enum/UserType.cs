using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Model
{
    /// <summary>
    /// 会员类型枚举
    /// </summary>
    public enum UserType
    {
        /// <summary>
        /// 企业
        /// </summary>
        CreditorEnterprise = 1,
        /// <summary>
        /// 个人
        /// </summary>
        CreditorIndividual,
        /// <summary>
        /// 律师
        /// </summary>
        Layer,
        /// <summary>
        /// 非律师
        /// </summary>
        NotLayer
    }
}
