using System;
using System.Xml;
using System.Collections.Generic;
using System.Text;
using XYECOM.Core;
using XYECOM.Core.XML;

namespace XYECOM.Configuration
{
    /// <summary>
    /// Module.config 文件处理类
    /// </summary>
    public class Module:BaseConfig
    {
        private List<ModuleInfo> moduleItems = new List<ModuleInfo>();

        private static Module instance = null;

        private Module()
        {
        }

        /// <summary>
        /// 初始化
        /// </summary>
        protected override void Init()
        {
            moduleItems.Clear();

            XmlDocument docXml = new XmlDocument();
            docXml.Load(System.Web.HttpContext.Current.Server.MapPath("/Config/module.config"));
            XmlNodeList list = docXml.GetElementsByTagName("mnode");
            for (int i = 0; i < list.Count; i++)
            {
                ModuleInfo info = new ModuleInfo();
                info.EName = list[i].Attributes["ename"].Value.ToString();
                info.SEName = list[i].Attributes["sename"].Value.ToString();
                info.CName = list[i].Attributes["cname"].Value.ToString();
                info.PEName = list[i].Attributes["pename"].Value.ToString();
                info.Order = MyConvert.GetInt32(list[i].Attributes["order"].Value.ToString());
                info.Description = list[i].Attributes["description"].Value.ToString();
                info.State = MyConvert.GetBoolean(list[i].Attributes["state"].Value.ToString());
                XmlNodeList item = list[i].ChildNodes;                
                for (int j = 0; j < item.Count; j++)
                {                    
                    if (item[j].NodeType == XmlNodeType.Element)
                    {
                        ModuleItemInfo iteminfo = new ModuleItemInfo();
                        
                        iteminfo.ID = MyConvert.GetInt16(item[j].Attributes["id"].Value.ToString());

                        if (iteminfo.ID == 0) continue;

                        iteminfo.Prefix = item[j].Attributes["prefix"].Value.ToString();
                        iteminfo.Postfix = item[j].Attributes["postfix"].Value.ToString();
                        InfoType infoType = InfoType.Sell;
                        if (item[j].Attributes["infotype"].Value.ToString() == "buy")
                            infoType = InfoType.Buy;
                        iteminfo.InfoType = infoType;
                        info.Item.Add(iteminfo);
                    }
                }
                moduleItems.Add(info);
            }
            OrderItems();
        }

        /// <summary>
        /// 处理模块间的关系
        /// </summary>
        private void OrderItems()
        {
            foreach(ModuleInfo info in this.moduleItems)
            {
                if (info.PEName.Equals("") || info.State == false) continue;

                this.GetItem(info.PEName).SubItems.Add(info);
            }
        }

        /// <summary>
        /// 获取单态实例
        /// </summary>
        public static Module Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (lockHelper)
                    {
                        instance = new Module();
                    }
                }
                return instance; 
            }
        }
       
        /// <summary>
        /// 返回所有模块信息
        /// </summary>
        public List<ModuleInfo> ModuleItems
        {
            get { return moduleItems; }
        }

        /// <summary>
        /// 返回所有模块信息(表格数据结构)
        /// </summary>
        public System.Data.DataTable GetDataTable
        {
            get 
            {
                System.Data.DataTable table = new System.Data.DataTable();

                table.Columns.Add("SEName");
                table.Columns.Add("CName");
                table.Columns.Add("EName");
                table.Columns.Add("PEName");
                table.Columns.Add("State");
                table.Columns.Add("Description");
                table.Columns.Add("PCName");

                System.Data.DataRow row = null;

                foreach (ModuleInfo info in this.moduleItems)
                {
                    row = table.NewRow();
                    row["EName"] =info.EName;
                    row["CName"] = info.CName;
                    row["SEName"] = info.SEName;
                    row["PEname"] = info.PEName;
                    row["State"] = info.State;
                    row["Description"] = info.Description;
                    if (info.PEName != "")
                    {
                        ModuleInfo pInfo = GetItem(info.PEName);
                        if(pInfo != null)
                            row["PCName"] = pInfo.CName;
                        else
                            row["PCName"] = "";
                    }
                    else {
                        row["PCName"] = "";
                    }
                    
                    table.Rows.Add(row);
                }

                return table;
            }
        }

        /// <summary>
        /// 获取模块信息
        /// </summary>
        /// <param name="name">模块中文名或英文名</param>
        /// <returns></returns>
        public ModuleInfo GetItem(string name)
        {
            name = name.Trim().ToLower();

            foreach (ModuleInfo info in moduleItems)
            {
                if (info.EName.ToLower().Equals(name)
                    || info.CName.Equals(name))
                    return info;
            }
            return null;
        }

        /// <summary>
        /// 插入一个模块
        /// </summary>
        /// <param name="info">模块信息</param>
        /// <returns></returns>
        public bool Insert(ModuleInfo info)
        {
            moduleItems.Add(info);
            return Update();
        }

        /// <summary>
        /// 删除模块
        /// </summary>
        /// <param name="ename">模块英文名</param>
        /// <returns></returns>
        public bool Delete(string ename)
        {
            bool isUpdate = false;
            foreach (ModuleInfo info in moduleItems)
            {
                if (info.EName == ename)
                {
                    moduleItems.Remove(info);
                    isUpdate = true;
                    break;
                }
            }
            if (isUpdate)
                return Update();
            return false;
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <returns>true:更新成功,false:更新失败</returns>
        public override bool Update()
        {
            XmlDocument docXml = new XmlDocument();
            docXml.Load(System.Web.HttpContext.Current.Server.MapPath("/Config/module.config"));
            XmlElement ele = docXml.DocumentElement;
            XmlNode node = (XmlNode)ele;
            node.RemoveAll();
            foreach (ModuleInfo info in moduleItems)
            {
                //XmlNode mnode = docXml.CreateNode(XmlNodeType.Element, "mnode", "");
                XmlNode mnode = XMLUtil.AppendElement(node, "mnode");
                XMLUtil.SetAttribute(mnode, "ename", info.EName);
                XMLUtil.SetAttribute(mnode, "sename", info.SEName);
                XMLUtil.SetAttribute(mnode, "cname", info.CName);
                XMLUtil.SetAttribute(mnode, "pename", info.PEName);
                XMLUtil.SetAttribute(mnode, "order", info.Order.ToString());
                XMLUtil.SetAttribute(mnode, "description", info.Description);
                XMLUtil.SetAttribute(mnode, "state", info.State.ToString());

                foreach (ModuleItemInfo itemInfo in info.Item)
                {
                    //XmlNode item = docXml.CreateNode(XmlNodeType.Element, "item", "");
                    XmlNode item = XMLUtil.AppendElement(mnode, "item");

                    if (itemInfo.Prefix.Trim().Equals("") && itemInfo.Postfix.Trim().Equals(""))
                    {
                        XMLUtil.SetAttribute(item, "id", "0");
                    }
                    else
                    {
                        XMLUtil.SetAttribute(item, "id", itemInfo.ID.ToString());
                    }

                    XMLUtil.SetAttribute(item, "prefix", itemInfo.Prefix);
                    XMLUtil.SetAttribute(item, "postfix", itemInfo.Postfix);
                    string infoType = "sell";
                    if (itemInfo.InfoType == InfoType.Buy)
                        infoType = "buy";
                    XMLUtil.SetAttribute(item, "infotype", infoType);
                }
            }
            try
            {
                docXml.Save(System.Web.HttpContext.Current.Server.MapPath("/Config/module.config"));
                return true;
            }
            catch
            {
                return false;
            }
            finally {
                instance = new Module();
            }
        }
    }
}
