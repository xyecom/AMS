using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using XYECOM.Core.XML;

namespace XYECOM.Configuration
{
    /// <summary>
    /// CustomConfigField.config �ļ�������
    /// </summary>
    public class CustomConfigField:BaseConfig
    {
        private static CustomConfigField instance = null;

        private List<CustomConfigFieldInfo> list = new List<CustomConfigFieldInfo>();

        private CustomConfigField() { }
        
        /// <summary>
        /// ��ȡ��̬ʵ��
        /// </summary>
        public static CustomConfigField Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (lockHelper)
                    {
                        instance = new CustomConfigField();
                    }
                }

                return instance;
            }
        }

        /// <summary>
        /// ���������ֶ���Ϣ
        /// </summary>
        public List<CustomConfigFieldInfo> Filelds
        {
            get { return this.list; }
        }

        /// <summary>
        /// ��ʼ��
        /// </summary>
        protected override void Init()
        {
            XmlDocument docXml = new XmlDocument();
            docXml.Load(System.Web.HttpContext.Current.Server.MapPath("/Config/CustomConfigField.config"));

            //IM ��ض�ȡ
            XmlNodeList nodeList = docXml.GetElementsByTagName("Item");

            foreach (XmlElement ele in nodeList)
            {
                CustomConfigFieldInfo _info = new CustomConfigFieldInfo();

                _info.Key = GetNodeValue(ele,"Key");
                _info.Value = GetNodeValue(ele, "Value");

                list.Add(_info);
            }
        }

        /// <summary>
        /// ����
        /// </summary>
        /// <returns>true:���³ɹ�,false:����ʧ��</returns>
        public override bool Update()
        {
            XmlDocument docXml = new XmlDocument();
            docXml.Load(System.Web.HttpContext.Current.Server.MapPath("/Config/CustomConfigField.config"));
            XmlElement ele = docXml.DocumentElement;
            XmlNode node = (XmlNode)ele;
            node.RemoveAll();
            foreach (CustomConfigFieldInfo info in this.list)
            {
                XmlNode mnode = XMLUtil.AppendElement(node, "Item");

                XmlNode item = XMLUtil.AppendElement(mnode, "Key");
                item.InnerText = info.Key;
                item = XMLUtil.AppendElement(mnode, "Value");
                item.InnerText = info.Value;
            }
            try
            {
                docXml.Save(System.Web.HttpContext.Current.Server.MapPath("/Config/CustomConfigField.config"));
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                instance = new CustomConfigField();
            }
        }

        /// <summary>
        /// ����һ��ֵ
        /// </summary>
        /// <param name="key">key</param>
        /// <param name="value">value</param>
        /// <returns>true:����ɹ�,false:����ʧ��</returns>
        public bool Insert(string key,string value)
        {
            if (key.Trim().Equals("")) return false;

            this.list.Add(new CustomConfigFieldInfo(key,value));

            return Update();
        }

        /// <summary>
        /// ����
        /// </summary>
        /// <returns>true:���³ɹ�,false:����ʧ��</returns>
        public bool Update(string key, string value)
        {
            if (key.Trim().Equals("")) return false;

            foreach (CustomConfigFieldInfo info in this.list)
            {
                if (info.Key.Equals(key)) info.Value = value;
            }

            return Update();
            
        }

        /// <summary>
        /// ɾ���ڵ�
        /// </summary>
        /// <param name="keys">�Զ��ŷ�����key����</param>
        /// <returns></returns>
        public bool Deletes(string keys)
        {
            string[] keyArr = keys.Split(',');

            foreach (string s in keyArr)
            {
                Delete(s);
            }

            return Update();
        }

        /// <summary>
        /// ɾ���ڵ�
        /// </summary>
        /// <param name="key">key</param>
        public void Delete(string key)
        {
            foreach (CustomConfigFieldInfo info in this.list)
            {
                if (info.Key.Equals(key))
                {
                    list.Remove(info);
                    break;
                }
            }   
        }

        
        /// <summary>
        /// �ж�ָ����key�Ƿ��Ѿ�����
        /// </summary>
        /// <param name="key">key</param>
        /// <returns>true:����,false:������</returns>
        public bool IsExists(string key)
        { 
            foreach(CustomConfigFieldInfo info in this.list)
            {
                if (info.Key.Equals(key)) return true;
            }

            return false;
        }

        /// <summary>
        /// ��ȡָ��key��ֵ
        /// </summary>
        /// <param name="key">key</param>
        /// <returns>value</returns>
        public string Get(string key)
        {
            foreach (CustomConfigFieldInfo info in this.list)
            {
                if (info.Key.Equals(key)) return info.Value;
            }

            return "";
        }

        /// <summary>
        /// �Ա����ʽ�������е��Զ��������ֶ�
        /// </summary>
        public System.Data.DataTable ToTable
        {
            get 
            {
                System.Data.DataTable table = new System.Data.DataTable();

                table.Columns.Add("Key");
                table.Columns.Add("Value");

                System.Data.DataRow row = null;

                foreach (CustomConfigFieldInfo info in this.list)
                {
                    row = table.NewRow();
                    row["Key"] = info.Key;
                    row["Value"] = info.Value;

                    table.Rows.Add(row);
                }

                return table;
            }
        }
    }
}
