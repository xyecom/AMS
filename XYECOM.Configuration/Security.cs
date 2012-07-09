using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;


namespace XYECOM.Configuration
{
    /// <summary>
    /// Security.config �ļ�������
    /// </summary>
    public class Security:BaseConfig
    {
        private static Security instance = null;

        private Security() 
        {
        }

        /// <summary>
        /// ��ȡ��̬ʵ��
        /// </summary>
        public static Security Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (lockHelper)
                    {
                        instance = new Security();        
                    }
                }

                return instance;
            }
        }

        /// <summary>
        /// ת����ʽ
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public Byte[] Str2Byte(string str)
        {
            string[] strs = str.Split(',');
            int length = strs.Length;

            Byte[] bytes = new byte[length];

            for(int i=0;i<length;i++)
            {
                bytes[i] = Convert.ToByte(str[i]);    
            }

            return bytes;
        }

        /// <summary>
        /// ת����ʽ
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public string Byte2Str(byte[] bytes)
        {
            int length = bytes.Length;

            StringBuilder val = new StringBuilder("");
            for (int i = 0; i < length; i++)
            {
                val.Append(Convert.ToString(bytes[i],16));
            }

            return val.ToString();
        }

        /// <summary>
        /// ��ʼ��
        /// </summary>
        protected override void Init()
        {
            XmlDocument docXml = new XmlDocument();
            docXml.Load(System.Web.HttpContext.Current.Server.MapPath("/Config/Security.config"));
            passwordKey = GetNodeValue(docXml, "PasswordKey");
            md5value = GetNodeValue(docXml, "MD5");
            forbidIP = GetNodeValue(docXml, "ForbidIP");
            validateCodeItem = GetNodeValue(docXml, "ValidateCodeItem");
            vCodeLength = Core.MyConvert.GetInt32(GetNodeValue(docXml, "VCodeLength"));
            vCodeTortuosity = Core.MyConvert.GetInt32(GetNodeValue(docXml, "VCodeTortuosity"));
            vCodeCharPool = GetNodeValue(docXml, "VCodeCharPool");

            string strAESKey = GetNodeValue(docXml, "AESKey");

            _AESKey = Str2Byte(strAESKey);
        }

        /// <summary>
        /// ����
        /// </summary>
        /// <returns></returns>
        public override bool Update()
        {
            XmlDocument docXml = new XmlDocument();
            docXml.Load(System.Web.HttpContext.Current.Server.MapPath("/Config/Security.config"));
            //SetNodeValue(docXml, "PasswordKey", PasswordKey);

            //SetNodeValue(docXml, "AESKey", Byte2Str(_AESKey));
            SetNodeValue(docXml, "ForbidIP", forbidIP);
            SetNodeValue(docXml, "ValidateCodeItem", validateCodeItem);
            SetNodeValue(docXml, "VCodeLength", vCodeLength);
            SetNodeValue(docXml, "VCodeTortuosity", vCodeTortuosity);
            SetNodeValue(docXml, "VCodeCharPool", vCodeCharPool);

            try
            {
                docXml.Save(System.Web.HttpContext.Current.Server.MapPath("/Config/Security.config"));
                return true;
            }
            catch
            {
                return false;
            }
            finally 
            {
                Refresh();
            }
        }
        private string passwordKey;
        private byte[] _AESKey;
        private string md5value;

        /// <summary>
        /// Md5 ֵ
        /// </summary>
        public string Md5value
        {
            get { return md5value; }
            set { md5value = value; }
        }

        /// <summary>
        /// AESKey
        /// </summary>
        public byte[] AESKey
        {
            get { return _AESKey; }
        }



        /// <summary>
        /// ��ȡϵͳ PasswordKey
        /// </summary>
        public string PasswordKey
        {
            get 
            {
                if (String.IsNullOrEmpty(passwordKey)) passwordKey = "";
                return passwordKey; 
            }
            set { passwordKey = value; }
        }

        private string forbidIP;

        /// <summary>
        /// ��ֹ���ʵ�IP�б�
        /// </summary>
        public string ForbidIP
        {
            get
            {
                return forbidIP;
            }
            set
            {
                forbidIP = value;
            }
        }

        /// <summary>
        /// ��ֹ����IP�б�
        /// </summary>
        public System.Collections.ArrayList _ForbidIP
        {
            get
            {
                System.Collections.ArrayList ipList = new System.Collections.ArrayList();

                forbidIP = forbidIP.Trim();

                if (forbidIP.Equals("")) return ipList;

                string[] ips = forbidIP.Split('|');

                foreach (string ip in ips)
                {
                    ipList.Add(ip);
                }

                return ipList;
            }
        }



        private string validateCodeItem;
        /// <summary>
        /// ��֤�뿪����
        /// </summary>
        public string ValidateCodeItemStr
        {
            get { return validateCodeItem; }
            set { validateCodeItem = value; }
        }



        /// <summary>
        /// �Ƿ�������֤��
        /// </summary>
        /// <param name="item">��֤�������</param>
        /// <returns></returns>
        public bool IsEnabledValidateCode(ValidateCodeItem item)
        {
            string strFlag = "";

            if (item == ValidateCodeItem.Register) strFlag = "register";

            if (item == ValidateCodeItem.Login) strFlag = "login";

            if (item == ValidateCodeItem.Comment) strFlag = "comment";

            if (item == ValidateCodeItem.Message) strFlag = "message";

            if (item == ValidateCodeItem.MakeTheOrder) strFlag = "order";

            if (item == ValidateCodeItem.QuickPost) strFlag = "quickpost";

            string str = Regex.Match(validateCodeItem, strFlag + ",[(0,1)]").Groups[0].ToString();

            if (str.Equals("")) return false;

            try
            {
                if (str.Split(',')[1].ToString().Equals("1"))
                    return true;
            }
            catch { }

            return false;
        }

        /// <summary>
        /// ������֤��״̬
        /// </summary>
        /// <param name="item">��֤����</param>
        /// <param name="value">���÷�</param>
        public void SetValidateCodeIsEnabled(ValidateCodeItem item, bool isEnabled)
        {
            string strFlag = "";
            string value = isEnabled ? "1" : "0";

            if (item == ValidateCodeItem.Register) strFlag = "register";

            if (item == ValidateCodeItem.Login) strFlag = "login";

            if (item == ValidateCodeItem.Comment) strFlag = "comment";

            if (item == ValidateCodeItem.Message) strFlag = "message";

            if (item == ValidateCodeItem.MakeTheOrder) strFlag = "order";

            if (item == ValidateCodeItem.QuickPost) strFlag = "quickpost";

            validateCodeItem = System.Text.RegularExpressions.Regex.Replace(validateCodeItem, strFlag + ",(0|1)", strFlag + "," + value);
        }

        private int vCodeLength;

        /// <summary>
        /// ��֤�볤��
        /// </summary>
        public int VCodeLength
        {
            get 
            {
                if (vCodeLength > 15 || vCodeLength < 2) vCodeLength = 6;

                return vCodeLength; 
            }
            set { vCodeLength = value; }
        }

        private int vCodeTortuosity;

        /// <summary>
        /// ��֤��Ť����
        /// </summary>
        public int VCodeTortuosity
        {
            get 
            {
                if (vCodeTortuosity < 1 || vCodeTortuosity > 5) vCodeTortuosity = 3;

                return vCodeTortuosity; 
            }
            set { vCodeTortuosity = value; }
        }

        private string vCodeCharPool;

        /// <summary>
        /// ��֤���ַ���
        /// </summary>
        public string VCodeCharPool
        {
            get
            {
                if (vCodeCharPool.Trim().Equals(""))
                    vCodeCharPool = "2,3,4,5,6,7,8,9,a,b,c,d,e,f,g,h,j,k,m,n,p,q,r,s,t,u,v,w,x,y,z,A,B,C,D,E,F,G,H,J,K,L,M,N,P,Q,R,S,T,U,V,W,X,Y,Z";

                return vCodeCharPool; 
            }
            set { vCodeCharPool = value; }
        }
    }
}
