using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Model.AMS
{
    /// <summary>
    /// 评价信息
    /// </summary>
    public class Evaluation
    {
        /// <summary>
        /// 评价编号
        /// </summary>
        public int EvaluationId
        {
            get;
            set;
        }

        /// <summary>
        /// 评价方Id
        /// </summary>
        public int UserId
        {
            get;
            set;
        }

        /// <summary>
        /// 被评价方Id
        /// </summary>
        public int User2Id
        {
            get;
            set;
        }
        /// <summary>
        /// 评价（好中差）
        /// </summary>
        public int EvaluationResult
        {
            get;
            set;
        }
        /// <summary>
        /// 评价方名称
        /// </summary>
        public string UserName
        {
            get;
            set;
        }

        /// <summary>
        /// 被评价方名称
        /// </summary>
        public string User2Name
        {
            get;
            set;
        }
        /// <summary>
        /// 描述
        /// </summary>
        public string Description
        {
            get;
            set;
        }

        public int CreditInfoId
        {
            get;
            set;
        }
    }
}
