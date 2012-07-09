using System;
using System.Xml;
using System.Collections.Generic;
using System.Text;
using XYECOM.Core;
using XYECOM.Core.XML;

namespace XYECOM.Configuration
{
    /// <summary>
    /// Module.config �ļ�������
    /// </summary>
    public class Module:BaseConfig
    {
        private List<ModuleInfo> moduleItems = new List<ModuleInfo>();

        private static Module instance = null;

        private Module()
        {
        }

        /// <summary>
        /// ��ʼ��
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
        /// ����ģ���Ĺ�ϵ
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
        /// ��ȡ��̬ʵ��
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
        /// ��������ģ����Ϣ
        /// </summary>
        public List<ModuleInfo> ModuleItems
        {
            get { return moduleItems; }
        }

        /// <summary>
        /// ��������ģ����Ϣ(������ݽṹ)
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
        /// ��ȡģ����Ϣ
        /// </summary>
        /// <param name="name">ģ����������Ӣ����</param>
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
        /// ����һ��ģ��
        /// </summary>
        /// <param name="info">ģ����Ϣ</param>
        /// <returns></returns>
        public bool Insert(ModuleInfo info)
        {
            moduleItems.Add(info);
            return Update();
        }

        /// <summary>
        /// ɾ��ģ��
        /// </summary>
        /// <param name="ename">ģ��Ӣ����</param>
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
        /// ����
        /// </summary>
        /// <returns>true:���³ɹ�,false:����ʧ��</returns>
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
