using System;
using System.Collections.Generic;
using System.Text;

using System.Data;


namespace XYECOM.Business
{
    /// <summary>
    /// ģ��ҵ����
    /// </summary>
    public class Template
    {
        private static readonly XYECOM.SQLServer.Template DAL = new XYECOM.SQLServer.Template();

        #region ��ȡģ����
        /// <summary>
        /// ��ȡģ����
        /// </summary>
        /// <param name="templateid">ģ����</param>
        /// <returns>ģ����ʵ�����</returns>
        public XYECOM.Model.TemplateInfo GetTemplateItem(int templateid)
        {
            return DAL.GetTemplateItem(templateid);
        }
        #endregion

        #region ��ȡģ����Ϣ
        /// <summary>
        ///  ��ȡģ����Ϣ
        /// </summary>
        /// <param name="templatePath">ָ����·��</param>
        /// <returns>ģ����Ϣ</returns>
        public DataTable GetAllTemplateList(string templatePath)
        {
            return DAL.GetAllTemplateList(templatePath);
        }
        /// <summary>
        /// �õ�����ģ�����Ϣ
        /// </summary>
        /// <returns>����ģ����Ϣ</returns>
        //public DataTable GetValidTemplateList()
        //{
        //    return DAL.GetValidTemplateList();
        //}


        public int SelectMaxID(string tablename, string maxid)
        {

            return DAL.SelectMaxID(tablename, maxid);
        }

        #endregion

        #region ɾ��ģ����Ϣ
        /// <summary>
        /// ɾ��ģ����Ϣ
        /// </summary>
        /// <param name="templateidlist">ģ����Ϣ��ż���</param>
        /// <returns>Ӱ������</returns>
        public int DeleteTemplateItem(string templateidlist)
        {
            return DAL.DeleteTemplateItem(templateidlist);
        }

        /// <summary>
        /// ɾ��һ��ģ����Ϣ
        /// </summary>
        /// <param name="T_ID">ģ����Ϣ���</param>
        /// <returns>Ӱ������</returns>
        public int DeleteTemplateItem(int T_ID)
        {
            return DAL.DeleteTemplateItem(T_ID);
        }
        #endregion

        #region �޸�����״̬
        /// <summary>
        /// �޸�����״̬
        /// </summary>
        /// <param name="T_ID">ģ����</param>
        /// <returns>Ӱ������</returns>
        public int UpdateFlag(int T_ID)
        {
            return DAL.UpdateFlag(T_ID);
        }
        #endregion

    }
}
