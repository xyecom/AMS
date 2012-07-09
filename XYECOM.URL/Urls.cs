using System;
using System.Xml;
using System.Collections.Generic;
using System.Text;
using XYECOM.Core;
using XYECOM.Core.XML;

namespace XYECOM.URL
{
    /// <summary>
    /// URL���������״̬ö��
    /// </summary>
    public enum UrlsInsertState
    {
        /// <summary>
        /// ��ӳɹ�
        /// </summary>
        Inserted = 1,
        /// <summary>
        /// �Ѿ���������Ŀ
        /// </summary>
        Iterance,
        /// <summary>
        /// �����������ʧ��
        /// </summary>
        Error
    }

    /// <summary>
    /// urls.config �����ļ�������
    /// </summary>
    public class Urls : XYECOM.Configuration.BaseConfig
    {
        /// <summary>
        /// ȫ��
        /// </summary>
        public List<URLPatternInfo> UrlItems = new List<URLPatternInfo>();

        /// <summary>
        /// ��ͨ��
        /// </summary>
        public List<URLPatternInfo> GeneralUrlItems = new List<URLPatternInfo>();

        /// <summary>
        /// ������
        /// </summary>
        public List<URLPatternInfo> ShopUrlItems = new List<URLPatternInfo>();

        /// <summary>
        /// ���Ŷ���������
        /// </summary>
        public List<URLPatternInfo> NewsUrlItems = new List<URLPatternInfo>();

        /// <summary>
        /// ��ҵ����������
        /// </summary>
        public List<URLPatternInfo> TradeUrlItems = new List<URLPatternInfo>();

        /// <summary>
        /// ��������������
        /// </summary>
        public List<URLPatternInfo> AreaUrlItems = new List<URLPatternInfo>();

        /// <summary>
        /// ��Ʒ�������
        /// </summary>
        public List<URLPatternInfo> ProCateUrlItems = new List<URLPatternInfo>();

        public List<URLPatternInfo> TopShopUrlItems = new List<URLPatternInfo>();

        /// <summary>
        /// ��ͨ����
        /// </summary>
        public List<URLPatternInfo> SpUrlItems = new List<URLPatternInfo>();


        private static Urls instance = null;

        private Urls()
        {
        }

        /// <summary>
        /// ��ʼ��
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
        /// ��ȡ��̬ʵ��
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
        /// ��ȡ�����ʽ
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
        /// ��ȡ����
        /// </summary>
        /// <param name="name">����</param>
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
        /// �������
        /// </summary>
        /// <param name="info">������Ϣ</param>
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
        /// ɾ������
        /// </summary>
        /// <param name="name">��������</param>
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
        /// ����
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
