using System;
using System.Collections.Generic;
using System.Text;
using XYECOM.Model.AMS;
using XYECOM.SQLServer.AMS;

namespace XYECOM.Business.AMS
{
    /// <summary>
    /// 评价业务逻辑类
    /// </summary>
    public class EvaluationManager
    {
        EvaluationAccess DAL = new EvaluationAccess();

        /// <summary>
        /// 新增评价信息
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public int InsertEvaluation(Evaluation info)
        {
            if (info == null)
            {
                return 0;
            }
            return DAL.InsertEvaluation(info);
        }
    }
}
