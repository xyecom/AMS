using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using XYECOM.Core.XML;

namespace XYECOM.Configuration
{
    public class JsInterface : BaseConfig
    {
        private static JsInterface instance = null;

        private List<JsInterfaceInfo> list = new List<JsInterfaceInfo>();

        private JsInterface()
            : base()
        { }
        
        /// <summary>
        /// 获取单态实例
        /// </summary>
        public static JsInterface Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (lockHelper)
                    {
                        instance = new JsInterface();
                    }
                }

                return instance;
            }
        }

        /// <summary>
        /// 返回所有字段信息
        /// </summary>
        public List<JsInterfaceInfo> Filelds
        {
            get { return this.list; }
        }

        /// <summary>
        /// 初始化
        /// </summary>
        protected override void Init()
        {
            XmlDocument docXml = new XmlDocument();
            docXml.Load(System.Web.HttpContext.Current.Server.MapPath("/Config/JsInterfaceConfig.config"));

            //IM 相关读取
            XmlNodeList nodeList = docXml.GetElementsByTagName("Item");

            foreach (XmlElement ele in nodeList)
            {
                JsInterfaceInfo _info = new JsInterfaceInfo();

                _info.Key = GetNodeValue(ele,"Key");
                _info.Value = GetNodeValue(ele, "Value");
                _info.Enable = XYECOM.Core.MyConvert.GetBoolean(GetNodeValue(ele, "Enable"));
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
            docXml.Load(System.Web.HttpContext.Current.Server.MapPath("/Config/JsInterfaceConfig.config"));
            XmlElement ele = docXml.DocumentElement;
            XmlNode node = (XmlNode)ele;
            node.RemoveAll();
            foreach (JsInterfaceInfo info in this.list)
            {
                XmlNode mnode = XMLUtil.AppendElement(node, "Item");

                XmlNode item = XMLUtil.AppendElement(mnode, "Key");
                item.InnerText = info.Key;
                
                item = XMLUtil.AppendElement(mnode, "Value");
                item.InnerText = info.Value;

                item = XMLUtil.AppendElement(mnode, "Enable");
                item.InnerText = info.Enable ? "true" : "false";

            }
            try
            {
                docXml.Save(System.Web.HttpContext.Current.Server.MapPath("/Config/JsInterfaceConfig.config"));
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                instance = new JsInterface();
            }
        }

        /// <summary>
        /// 插入一个值
        /// </summary>
        /// <param name="key">key</param>
        /// <param name="value">value</param>
        /// <returns>true:插入成功,false:插入失败</returns>
        protected bool Insert(string key,string value,bool enable)
        {
            if (key.Trim().Equals("")) return false;

            this.list.Add(new JsInterfaceInfo(key, value, enable));

            return Update();
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <returns>true:更新成功,false:更新失败</returns>
        protected bool Update(string key, string value,bool enable)
        {
            if (key.Trim().Equals("")) return false;

            foreach (JsInterfaceInfo info in this.list)
            {
                if (info.Key.Equals(key))
                {
                    info.Value = value;
                    info.Enable = enable;
                    break;
                }                
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
            foreach (JsInterfaceInfo info in this.list)
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
            foreach(JsInterfaceInfo info in this.list)
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
        public JsInterfaceInfo Get(string key)
        {
            foreach (JsInterfaceInfo info in this.list)
            {   
                if (info.Key.Equals(key)) 
                {
                    return info;
                }
            }
            return null;
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
                table.Columns.Add("Enable");

                System.Data.DataRow row = null;

                foreach (JsInterfaceInfo info in this.list)
                {
                    row = table.NewRow();
                    row["Key"] = info.Key;
                    row["Value"] = info.Value;
                    row["Enable"] = info.Enable;
                    table.Rows.Add(row);
                }

                return table;
            }
        }

        public bool Insert(JsInterfaceInfo jsInfo)
        {
            return this.Insert(jsInfo.Key, jsInfo.Value, jsInfo.Enable);
        }

        public bool Update(JsInterfaceInfo jsInfo)
        {
            return this.Update(jsInfo.Key, jsInfo.Value, jsInfo.Enable);
        }

        public string GetJs(string key)
        {
            JsInterfaceInfo info = Get(key);
            return ((info == null || !info.Enable) ? "" : info.Value);
        }
    }
}
