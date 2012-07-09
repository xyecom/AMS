using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.IO;
using System.Xml;

namespace XYECOM.Template
{
    /// <summary>
    /// ����ģ�崦����
    /// </summary>
    public class ShopTemplate:TemplateManage
    {

        /// <summary>
        /// ��ȡ�����
        /// </summary>
        /// <returns></returns>
        private DataTable GetTableFrame()
        {
            DataTable infolist = new System.Data.DataTable();

            infolist.Columns.Add("id", Type.GetType("System.Int32"));
            infolist.Columns.Add("filename", Type.GetType("System.String"));
            infolist.Columns.Add("filepath", Type.GetType("System.String"));
            infolist.Columns.Add("img", Type.GetType("System.String"));
            infolist.Columns.Add("cname", Type.GetType("System.String"));
            infolist.Columns.Add("access", Type.GetType("System.String"));
            infolist.Columns.Add("user", Type.GetType("System.String"));
            infolist.Columns.Add("author", Type.GetType("System.String"));
            infolist.Columns.Add("createdate", Type.GetType("System.String"));
            infolist.Columns.Add("ver", Type.GetType("System.String"));
            infolist.Columns.Add("copyright", Type.GetType("System.String"));

            return infolist;
        }

        #region ��Ա��������

        #region ��ȡ���з���б�
        /// <summary>
        /// ��ȡ���з���б�
        /// </summary>
        /// <returns></returns>
        public DataTable GetSkins(long userId, int userGradeId)
        {
            DataTable skins = new DataTable();

            skins.Columns.Add("dir", Type.GetType("System.String"));
            skins.Columns.Add("name", Type.GetType("System.String"));

            DataRow row = skins.NewRow();

            row["dir"] = "";
            row["name"] = "����ģ��";

            skins.Rows.Add(row);

            string tempPath = System.Web.HttpContext.Current.Server.MapPath("/templates/_shop");

            System.IO.DirectoryInfo info = new System.IO.DirectoryInfo(tempPath);

            XYECOM.Template.ShopStyleInfo styleInfo = null;

            XYECOM.Template.ShopStyle styleBLL = new ShopStyle();

            foreach (System.IO.DirectoryInfo subInfo in info.GetDirectories())
            {
                if (IsStyle(subInfo.FullName))
                {
                    row = skins.NewRow();

                    styleInfo = ShopStyle.GetItem(subInfo.Name);

                    if (styleInfo == null) continue;

                    if (!IsAllowUse(userId.ToString(), userGradeId.ToString(), styleInfo)) continue;

                    row["dir"] = subInfo.Name;
                    row["name"] = styleInfo.Name;

                    skins.Rows.Add(row);
                }
            }

            return skins;
        }
        #endregion 
        /// <summary>
        /// ��ȡ����ģ��(ֱ�ӷ���shopĿ¼�µ�ģ��)
        /// </summary>
        /// <returns></returns>
        private DataTable GetBasicThemes(long userId,int userGradeId)
        {
            DataTable infolist = GetTableFrame();

            XYECOM.Template.ShopAboutInfo shopAbout = null;

            string tempPath = System.Web.HttpContext.Current.Server.MapPath("/templates/_shop");

            System.IO.DirectoryInfo info = new System.IO.DirectoryInfo(tempPath);

            int num = 1;

            foreach (DirectoryInfo subDir in info.GetDirectories())
            {
                //�����ϵ������������
                if (IsStyle(subDir.FullName)) continue;

                shopAbout = XYECOM.Template.ShopAbout.GetItem(Path.Combine(tempPath, subDir.Name));

                //�����ǰ�û���Ȩʹ��������
                if (!IsAllowUse(userId.ToString(), userGradeId.ToString(), shopAbout)) continue;

                System.Data.DataRow row = infolist.NewRow();

                row["id"] = num;
                row["filename"] = subDir.Name;
                row["cname"] = shopAbout.CName;
                row["access"] = shopAbout.AccessStr;
                row["user"] = shopAbout.User;
                row["author"] = shopAbout.Author;
                row["createdate"] = shopAbout.CreateDate;
                row["ver"] = shopAbout.Ver;
                row["copyright"] = shopAbout.Copyright;
                row["img"] = "/templates/_shop/" + subDir.Name + "/about.gif";

                infolist.Rows.Add(row);
                num++;
            }

            return infolist;
        }

        /// <summary>
        /// ��ȡϵ��ģ��
        /// </summary>
        /// <returns></returns>
        private DataTable GetSeriesThemes(string dir,long userId,int userGradeId)
        {
            DataTable infolist = GetTableFrame();

            XYECOM.Template.ShopStyleInfo styleInfo = XYECOM.Template.ShopStyle.GetItem(dir);

            XYECOM.Template.ShopAboutInfo shopAbout = null;

            string tempPath = System.Web.HttpContext.Current.Server.MapPath("/templates/_shop/" + dir);

            System.IO.DirectoryInfo info = new System.IO.DirectoryInfo(tempPath);

            //�������һ��ϵ��ģ���򷵻ؿձ��
            if (!IsStyle(info.FullName)) return new DataTable();

            tempPath = System.Web.HttpContext.Current.Server.MapPath("/templates/_shop/" + dir);

            info = new System.IO.DirectoryInfo(tempPath);

            int num = 1;

            foreach (DirectoryInfo subDir in info.GetDirectories())
            {
                shopAbout = XYECOM.Template.ShopAbout.GetItem(Path.Combine(tempPath, subDir.Name));

                if (shopAbout == null) continue;

                if (styleInfo != null)
                {
                    if (!IsAllowUse(userId.ToString(), userGradeId.ToString(), styleInfo)) continue;
                }

                if (!IsAllowUse(userId.ToString(), userGradeId.ToString(), shopAbout)) continue;

                System.Data.DataRow row = infolist.NewRow();

                row["id"] = num;
                row["filename"] = dir + "|" + subDir.Name;
                row["cname"] = shopAbout.CName;
                row["access"] = shopAbout.AccessStr;
                row["user"] = shopAbout.User;
                row["author"] = shopAbout.Author;
                row["createdate"] = shopAbout.CreateDate;
                row["ver"] = shopAbout.Ver;
                row["copyright"] = shopAbout.Copyright;
                row["img"] = "/templates/_shop/" + dir + "/" +subDir.Name + "/about.gif";

                infolist.Rows.Add(row);
                num++;
            }

            return infolist;
        }

        /// <summary>
        /// ����ָ����Ŀ¼��ȡ���е���ʽ
        /// </summary>
        /// <param name="skinDir"></param>
        /// <returns></returns>
        public DataTable GetThemes(string skinDir,long userId,int userGradeId)
        {
            if (skinDir.ToString().Equals("")) return GetBasicThemes(userId, userGradeId);

            return GetSeriesThemes(skinDir.ToString(), userId, userGradeId);
        }

        /// <summary>
        /// ��ǰ�û��Ƿ����ʹ��ģ��
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="userGradeId"></param>
        /// <param name="shopInfo"></param>
        /// <returns></returns>
        private bool IsAllowUse(string userId, string userGradeId, XYECOM.Template.ShopTemplateInfo shopInfo)
        {
            if (shopInfo.Access == XYECOM.Template.ShopTemplateAccess.Public && shopInfo.User.ToLower().Equals("all"))
            {
                return true;
            }

            if (shopInfo.Access == XYECOM.Template.ShopTemplateAccess.Public
                && (shopInfo.User.Equals(userGradeId)
                || shopInfo.User.StartsWith(userGradeId + ",")
                || shopInfo.User.Contains("," + userGradeId + ",")
                || shopInfo.User.EndsWith("," + userGradeId)))
            {
                return true;
            }

            if (shopInfo.Access == XYECOM.Template.ShopTemplateAccess.Private
                && (shopInfo.User.Equals(userId)
                || shopInfo.User.StartsWith(userId + ",")
                || shopInfo.User.Contains("," + userId + ",")
                || shopInfo.User.EndsWith("," + userId)))
            {
                return true;
            }

            return false;
        }
        #endregion

        #region ��̨ר��
        #region ��ȡ���з���б�
        /// <summary>
        /// ��ȡ���з���б�
        /// </summary>
        /// <returns></returns>
        public DataTable GetSkins()
        {
            DataTable skins = new DataTable();

            skins.Columns.Add("dir", Type.GetType("System.String"));
            skins.Columns.Add("name", Type.GetType("System.String"));

            DataRow row = skins.NewRow();

            row["dir"] = "";
            row["name"] = "����ģ��";

            skins.Rows.Add(row);

            string tempPath = System.Web.HttpContext.Current.Server.MapPath("/templates/_shop");

            System.IO.DirectoryInfo info = new System.IO.DirectoryInfo(tempPath);

            XYECOM.Template.ShopStyleInfo styleInfo = null;

            XYECOM.Template.ShopStyle styleBLL = new ShopStyle();

            foreach (System.IO.DirectoryInfo subInfo in info.GetDirectories())
            {
                if (IsStyle(subInfo.FullName))
                {
                    row = skins.NewRow();

                    styleInfo = ShopStyle.GetItem(subInfo.Name);

                    if (styleInfo == null) continue;

                    row["dir"] = subInfo.Name;
                    row["name"] = styleInfo.Name;

                    skins.Rows.Add(row);
                }
            }

            return skins;
        }
                #endregion 
        /// <summary>
        /// ��ȡ����ģ��(ֱ�ӷ���shopĿ¼�µ�ģ��)
        /// </summary>
        /// <returns></returns>
        private DataTable GetBasicThemes()
        {
            DataTable infolist = GetTableFrame();

            XYECOM.Template.ShopAboutInfo shopAbout = null;

            string tempPath = System.Web.HttpContext.Current.Server.MapPath("/templates/_shop");

            System.IO.DirectoryInfo info = new System.IO.DirectoryInfo(tempPath);

            int num = 1;

            foreach (DirectoryInfo subDir in info.GetDirectories())
            {
                //�����ϵ������������
                if (IsStyle(subDir.FullName)) continue;

                shopAbout = XYECOM.Template.ShopAbout.GetItem(Path.Combine(tempPath, subDir.Name));

                if (shopAbout == null) continue;

                System.Data.DataRow row = infolist.NewRow();

                row["id"] = num;
                row["filename"] = subDir.Name;
                row["cname"] = shopAbout.CName;
                row["access"] = shopAbout.AccessStr;
                row["user"] = shopAbout.User;
                row["author"] = shopAbout.Author;
                row["createdate"] = shopAbout.CreateDate;
                row["ver"] = shopAbout.Ver;
                row["copyright"] = shopAbout.Copyright;
                row["img"] = "/templates/_shop/" + subDir.Name + "/about.gif";

                infolist.Rows.Add(row);
                num++;
            }

            return infolist;
        }

        /// <summary>
        /// ��ȡϵ��ģ��
        /// </summary>
        /// <returns></returns>
        private DataTable GetSeriesThemes(string dir)
        {
            DataTable infolist = GetTableFrame();

            XYECOM.Template.ShopAboutInfo shopAbout = null;

            string tempPath = System.Web.HttpContext.Current.Server.MapPath("/templates/_shop/" + dir);

            System.IO.DirectoryInfo info = new System.IO.DirectoryInfo(tempPath);

            //�������һ��ϵ��ģ���򷵻ؿձ��
            if (!IsStyle(info.FullName)) return new DataTable();

            //tempPath = System.Web.HttpContext.Current.Server.MapPath("/templates/_shop/" + dir);

            info = new System.IO.DirectoryInfo(tempPath);

            int num = 1;

            foreach (DirectoryInfo subDir in info.GetDirectories())
            {
                shopAbout = XYECOM.Template.ShopAbout.GetItem(Path.Combine(tempPath, subDir.Name));

                if (shopAbout == null) continue;

                System.Data.DataRow row = infolist.NewRow();

                row["id"] = num;
                row["filename"] = dir + "|" + subDir.Name;
                row["cname"] = shopAbout.CName;
                row["access"] = shopAbout.AccessStr;
                row["user"] = shopAbout.User;
                row["author"] = shopAbout.Author;
                row["createdate"] = shopAbout.CreateDate;
                row["ver"] = shopAbout.Ver;
                row["copyright"] = shopAbout.Copyright;
                row["img"] = "/templates/_shop/" + dir + "/" + subDir.Name + "/about.gif";

                infolist.Rows.Add(row);
                num++;
            }

            return infolist;
        }

        /// <summary>
        /// ����ָ����Ŀ¼��ȡ���е���ʽ
        /// </summary>
        /// <param name="skinDir"></param>
        /// <returns></returns>
        public DataTable GetThemes(string skinDir)
        {
            if (string.IsNullOrEmpty(skinDir)) return GetBasicThemes();

            return GetSeriesThemes(skinDir.ToString());
        }
        #endregion

        /// <summary>
        ///  �ǲ���һ��ģ�����ļ���
        /// �ж��ļ������Ƿ�ģ��style.xml �� themes �ļ���
        /// </summary>
        /// <returns></returns>
        private bool IsStyle(string dir)
        {
            if (File.Exists(Path.Combine(dir, "style.xml"))
                && Directory.Exists(Path.Combine(dir, "default")))
                return true;

            return false;
        }

    }
}
