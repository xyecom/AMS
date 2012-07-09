using System;
using System.Xml;
using System.Collections.Generic;
using System.Text;
using XYECOM.Core;
using XYECOM.Core.XML;

namespace XYECOM.URL
{
    /// <summary>
    /// URL规则插入结果状态枚举
    /// </summary>
    public enum UrlsInsertState
    {
        /// <summary>
        /// 添加成功
        /// </summary>
        Inserted = 1,
        /// <summary>
        /// 已经有重名项目
        /// </summary>
        Iterance,
        /// <summary>
        /// 发生错误，添加失败
        /// </summary>
        Error
    }

    /// <summary>
    /// urls.config 配置文件处理类
    /// </summary>
    public class Urls : XYECOM.Configuration.BaseConfig
    {
        /// <summary>
        /// 全部
        /// </summary>
        public List<URLPatternInfo> UrlItems = new List<URLPatternInfo>();

        /// <summary>
        /// 普通组
        /// </summary>
        public List<URLPatternInfo> GeneralUrlItems = new List<URLPatternInfo>();

        /// <summary>
        /// 网店组
        /// </summary>
        public List<URLPatternInfo> ShopUrlItems = new List<URLPatternInfo>();

        /// <summary>
        /// 新闻二级域名组
        /// </summary>
        public List<URLPatternInfo> NewsUrlItems = new List<URLPatternInfo>();

        /// <summary>
        /// 行业二级域名组
        /// </summary>
        public List<URLPatternInfo> TradeUrlItems = new List<URLPatternInfo>();

        /// <summary>
        /// 地区二级域名组
        /// </summary>
        public List<URLPatternInfo> AreaUrlItems = new List<URLPatternInfo>();

        /// <summary>
        /// 产品分类相关
        /// </summary>
        public List<URLPatternInfo> ProCateUrlItems = new List<URLPatternInfo>();

        public List<URLPatternInfo> TopShopUrlItems = new List<URLPatternInfo>();

        /// <summary>
        /// 普通网店
        /// </summary>
        public List<URLPatternInfo> SpUrlItems = new List<URLPatternInfo>();


        private static Urls instance = null;

        private Urls()
        {
        }

        /// <summary>
        /// 初始化
        /// </summary>
        protected override void Init()
        {
            XmlDocument docXml = new XmlDocument();
            docXml.Load(System.Web.HttpContext.Current.Server.MapPath("/Config/urls.config"));
            XmlNodeList list = docXml.GetElementsByTagName("rewrite");
            for (int i = 0; i < list.Count; i++)
            {
                URLPatternInfo info = new URLPatternInfo();
                info.Name = list[i].Attributes["name"].Value.ToString();
                info.Page = list[i].Attributes["page"].Value.ToString().Replace("^", "&");
                info.Pattern = list[i].Attributes["pattern"].Value.ToString();
                info.QueryString = list[i].Attributes["querystring"].Value.ToString().Replace("^", "&");
                info.Path = list[i].Attributes["path"].Value.ToString();

                XmlAttribute att = list[i].Attributes["group"];

                info.Group = "";
                if (att != null) info.Group = att.Value.ToString();

                UrlItems.Add(info);

                string gp = info.Group.Trim().ToLower();
                switch (gp)
                {
                    case "shop":
                        ShopUrlItems.Add(info);
                        break;
                    case "news":
                        NewsUrlItems.Add(info);
                        break;
                    case "trade":
                        TradeUrlItems.Add(info);
                        break;
                    case "area":
                        AreaUrlItems.Add(info);
                        break;
                    case "cate":
                        ProCateUrlItems.Add(info);
                        break;
                    case "topshop":
                        TopShopUrlItems.Add(info);
                        break;
                    case "sp":
                        SpUrlItems.Add(info);
                        break;
                    default:
                        GeneralUrlItems.Add(info);
                        break;
                }
            }
        }

        /// <summary>
        /// 获取单态实例
        /// </summary>
        public static Urls Instance
        {
            get
            {
                if (instance == null)
                    instance = new Urls();
                return instance;
            }
        }

        /// <summary>
        /// 获取表格形式
        /// </summary>
        public System.Data.DataTable GetDataTable
        {
            get
            {
                System.Data.DataTable table = new System.Data.DataTable();

                table.Columns.Add("name");
                table.Columns.Add("page");
                table.Columns.Add("pattern");
                table.Columns.Add("querystring");
                table.Columns.Add("path");
                table.Columns.Add("group");

                System.Data.DataRow row = null;

                foreach (URLPatternInfo info in this.UrlItems)
                {
                    row = table.NewRow();
                    row["name"] = info.Name;
                    row["page"] = info.Page;
                    row["pattern"] = info.Pattern;
                    row["querystring"] = info.QueryString;
                    row["path"] = info.Path;
                    row["group"] = info.Group;

                    table.Rows.Add(row);
                }

                return table;
            }
        }

        /// <summary>
        /// 获取规则
        /// </summary>
        /// <param name="name">名称</param>
        /// <returns></returns>
        public URLPatternInfo GetItem(string name)
        {
            foreach (URLPatternInfo info in UrlItems)
            {
                if (info.Name == name)
                    return info;
            }
            return null;
        }

        /// <summary>
        /// 插入规则
        /// </summary>
        /// <param name="info">规则信息</param>
        /// <returns></returns>
        public UrlsInsertState Insert(URLPatternInfo info)
        {
            if (null == GetItem(info.Name))
            {
                //urlItems.Add(info);
                UrlItems.Insert(0, info);
                if (Update())
                    return UrlsInsertState.Inserted;
                else
                    return UrlsInsertState.Error;
            }
            else
            {
                return UrlsInsertState.Iterance;
            }
        }

        /// <summary>
        /// 删除规则
        /// </summary>
        /// <param name="name">规则名称</param>
        /// <returns></returns>
        public bool Delete(string name)
        {
            bool isUpdate = false;
            foreach (URLPatternInfo info in UrlItems)
            {
                if (info.Name == name)
                {
                    UrlItems.Remove(info);
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
        /// <returns></returns>
        public override bool Update()
        {
            XmlDocument docXml = new XmlDocument();
            docXml.Load(System.Web.HttpContext.Current.Server.MapPath("/Config/urls.config"));
            XmlElement ele = docXml.DocumentElement;
            XmlNode node = (XmlNode)ele;
            node.RemoveAll();
            foreach (URLPatternInfo info in UrlItems)
            {
                //XmlNode mnode = docXml.CreateNode(XmlNodeType.Element, "mnode", "");
                XmlNode rewrite = XMLUtil.AppendElement(node, "rewrite");
                XMLUtil.SetAttribute(rewrite, "name", info.Name);
                XMLUtil.SetAttribute(rewrite, "page", info.Page.Replace("&", "^"));
                XMLUtil.SetAttribute(rewrite, "pattern", info.Pattern);
                XMLUtil.SetAttribute(rewrite, "querystring", info.QueryString.Replace("&", "^"));
                XMLUtil.SetAttribute(rewrite, "path", info.Path);
                XMLUtil.SetAttribute(rewrite, "group", info.Group);
            }
            try
            {
                docXml.Save(System.Web.HttpContext.Current.Server.MapPath("/Config/urls.config"));
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                instance = new Urls();
            }
        }
    }
}
