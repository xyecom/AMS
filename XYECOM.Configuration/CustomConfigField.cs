using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using XYECOM.Core.XML;

namespace XYECOM.Configuration
{
    /// <summary>
    /// CustomConfigField.config 文件处理类
    /// </summary>
    public class CustomConfigField:BaseConfig
    {
        private static CustomConfigField instance = null;

        private List<CustomConfigFieldInfo> list = new List<CustomConfigFieldInfo>();

        private CustomConfigField() { }
        
        /// <summary>
        /// 获取单态实例
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
        /// 返回所有字段信息
        /// </summary>
        public List<CustomConfigFieldInfo> Filelds
        {
            get { return this.list; }
        }

        /// <summary>
        /// 初始化
        /// </summary>
        protected override void Init()
        {
            XmlDocument docXml = new XmlDocument();
            docXml.Load(System.Web.HttpContext.Current.Server.MapPath("/Config/CustomConfigField.config"));

            //IM 相关读取
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
        /// 更新
        /// </summary>
        /// <returns>true:更新成功,false:更新失败</returns>
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
        /// 插入一个值
        /// </summary>
        /// <param name="key">key</param>
        /// <param name="value">value</param>
        /// <returns>true:插入成功,false:插入失败</returns>
        public bool Insert(string key,string value)
        {
            if (key.Trim().Equals("")) return false;

            this.list.Add(new CustomConfigFieldInfo(key,value));

            return Update();
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <returns>true:更新成功,false:更新失败</returns>
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
        /// 删除节点
        /// </summary>
        /// <param name="keys">以逗号分来的key集合</param>
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
        /// 删除节点
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
        /// 判断指定的key是否已经存在
        /// </summary>
        /// <param name="key">key</param>
        /// <returns>true:存在,false:不存在</returns>
        public bool IsExists(string key)
        { 
            foreach(CustomConfigFieldInfo info in this.list)
            {
                if (info.Key.Equals(key)) return true;
            }

            return false;
        }

        /// <summary>
        /// 获取指定key的值
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
        /// 以表格形式返回所有的自定义配置字段
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
