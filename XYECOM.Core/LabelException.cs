using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Core
{
    /// <summary>
    /// 标签解析自定义异常
    /// </summary>
    public class LabelException:Exception
    {
        public LabelException()
        { }

        public LabelException(string message):base(message)
        { }

        public override string ToString()
        {
            return "标签解析错误:" + base.Message;
        }
    }
}
