using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Configuration
{
    /// <summary>
    /// 模块信息实体类
    /// </summary>
    public class ModuleInfo
    {
        private List<ModuleInfo> subItems = new List<ModuleInfo>();

        public List<ModuleInfo> SubItems
        {
            get { return subItems; }
            set { subItems = value; }
        }

        private string eName;
        /// <summary>
        /// 模块英文名
        /// </summary>
        public string EName
        {
            get { return eName; }
            set { eName = value; }
        }
        private string sEName;
        /// <summary>
        /// 模块显示英文名
        /// </summary>
        public string SEName
        {
            get { return sEName; }
            set { sEName = value; }
        }
        private string pEName;
        /// <summary>
        /// 父节点英文名
        /// </summary>
        public string PEName
        {
            get { return pEName; }
            set { pEName = value; }
        }
        private string cName;
        /// <summary>
        /// 模块中文名
        /// </summary>
        public string CName
        {
            get { return cName; }
            set { cName = value; }
        }
        private int order;
        /// <summary>
        /// 排序
        /// </summary>
        public int Order
        {
            get { return order; }
            set { order = value; }
        }
        private string description;
        /// <summary>
        /// 模块描述
        /// </summary>
        public string Description
        {
            get { return description; }
            set { description = value; }
        }
        private bool state;
        /// <summary>
        /// 状态是否启用
        /// </summary>
        public bool State
        {
            get { return state; }
            set { state = value; }
        }

        /// <summary>
        /// 获取信息类型字符串表示
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string GetInfoType(int id)
        {
            foreach (ModuleItemInfo itemInfo in item)
            {
                if (itemInfo.ID == id)
                    return itemInfo.InfoTypeStr;
            }
            return "";
        }

        /// <summary>
        /// 获取信息类型枚举表示
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public InfoType GetInfoTypeEnum(int id)
        {
            foreach (ModuleItemInfo itemInfo in item)
            {
                if (itemInfo.ID == id)
                    return itemInfo.InfoType;
            }
            return InfoType.Sell;
        }

        /// <summary>
        /// 返回当前模块信息的Table数据格式
        /// </summary>
        public System.Data.DataTable ToTable
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

                System.Data.DataRow row = null;

                row = table.NewRow();
                row["EName"] = this.eName;
                row["CName"] = this.cName;
                row["SEName"] = this.sEName;
                row["PEname"] = this.pEName;
                row["State"] = this.state;
                row["Description"] = this.description;

                table.Rows.Add(row);
  

                return table;
            }
        }

        /// <summary>
        /// 返回当前模块及子模块信息的Table数据格式
        /// </summary>
        public System.Data.DataTable ToTables 
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

                System.Data.DataRow row = null;

                row = table.NewRow();
               
                row["EName"] = this.eName;
                row["CName"] = this.cName;
                row["SEName"] = this.sEName;
                row["PEname"] = this.pEName;
                row["State"] = this.state;
                row["Description"] = this.description;
                table.Rows.Add(row);
                for (int i = 0; i < this.SubItems.Count;i++ )
                {
                    row = table.NewRow();
                    row["EName"] = this.SubItems[i].eName;
                    row["CName"] = this.SubItems[i].cName;
                    row["SEName"] = this.SubItems[i].sEName;
                    row["PEname"] = this.SubItems[i].pEName;
                    row["State"] = this.SubItems[i].state;
                    row["Description"] = this.SubItems[i].description;
                    table.Rows.Add(row);
                }
                return table;
            }
        }

        private List<ModuleItemInfo> item = new List<ModuleItemInfo>();
        /// <summary>
        /// 前后缀信息
        /// </summary>
        public List<ModuleItemInfo> Item
        {
            get { return item; }
        }

        /// <summary>
        /// 所有供信息的id集合
        /// </summary>
        public string SellIDs
        {
            get {
                string value = "";

                foreach (ModuleItemInfo info in item) {
                    if (info.InfoType == InfoType.Sell)
                    {
                        if (value.Equals(""))
                            value = info.ID.ToString();
                        else
                            value += "," + info.ID.ToString();
                    }
                }
                return value;
            }
        }

        /// <summary>
        /// 所有<求>信息的id集合
        /// </summary>
        public string BuyIDs
        {
            get {
                string value = "";

                foreach (ModuleItemInfo info in item) {
                    if (info.InfoType == InfoType.Buy)
                    {
                        if (value.Equals(""))
                            value = info.ID.ToString();
                        else
                            value += "," + info.ID.ToString();
                    }
                }
                return value;
            }
        }
    }
}
