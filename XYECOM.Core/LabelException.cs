using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Core
{
    /// <summary>
    /// ��ǩ�����Զ����쳣
    /// </summary>
    public class LabelException:Exception
    {
        public LabelException()
        { }

        public LabelException(string message):base(message)
        { }

        public override string ToString()
        {
            return "��ǩ��������:" + base.Message;
        }
    }
}
