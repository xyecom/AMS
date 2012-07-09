using System;
using System.Collections.Generic;

using System.Text;

namespace XYECOM.Service
{
    public abstract class BaseService
    {
        /// <summary>
        /// 业务处理逻辑
        /// </summary>
        public abstract void Process();
        public static string ServiceConfigFilePath = string.Empty;
    }
}
