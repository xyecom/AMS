using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Configuration
{
    public class JsInterfaceInfo
    {
        public JsInterfaceInfo()
            : this("", "")
        {
        }

        public JsInterfaceInfo(string k, string v)
            : this(k, v, true)
        {
        }

        public JsInterfaceInfo(string k, string v, bool e)
        {
            this._key = k;
            this._value = v;
            this._enable = e;
        }

        private string _key;

        public string Key
        {
            get { return _key; }
            set { _key = value; }
        }
        private string _value;

        public string Value
        {
            get { return this._value; }
            set { this._value = value; }
        }
        private bool _enable;

        public bool Enable
        {
            get { return _enable; }
            set { _enable = value; }
        }
    }
}
