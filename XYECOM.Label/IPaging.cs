using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Label
{
    /// <summary>
    /// ��ҳ��ǩͨ�ýӿ�
    /// </summary>
    public interface IPaging
    {
        /// <summary>
        /// ÿҳ��¼����
        /// </summary>
        int PageSize { get;set;}

        /// <summary>
        /// �Զ���ҳ��
        /// </summary>
        int CustomPageSize { get;set;}

        /// <summary>
        /// ��¼����
        /// </summary>
        int TotalRecord { get;set;}

        /// <summary>
        /// ��ҳ��
        /// </summary>
        int PageCount { set;get;}

        /// <summary>
        /// ��ǰҳ
        /// </summary>
        int PageIndex { get;set;}

        /// <summary>
        /// ҳ��URI��ַ
        /// </summary>
        string PageURL { get;set;}

        /// <summary>
        /// ��һҳ����
        /// </summary>
        string NextPage{get;set;}

        /// <summary>
        /// ��һҳ����
        /// </summary>
        string PreviousPage{get;set;}

        /// <summary>
        /// ��ҳ
        /// </summary>
        string FirstPage { get;set;}

        /// <summary>
        /// βҳ
        /// </summary>
        string LastPage { get;set;}

        /// <summary>
        /// ����ҳ���б����
        /// </summary>
        string NumPage{get;set;}

        /// <summary>
        /// ��������
        /// </summary>
        string StrPageSearchWhere { get;set;}

        /// <summary>
        /// �ؼ��־�����Ϣ����
        /// </summary>
        string StrKeySearchWhere { get;set;}

        /// <summary>
        /// ����������ش���
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageUrl"></param>
        /// <param name="default_page">��pageUrl�޷�ƥ��ʱʹ�õ�Ĭ��ҳ��</param>
        /// <param name="moduleFlag">ģ���ʶ</param>
        /// <returns></returns>
        void SetPagination(int pageIndex,string pageUrl,SEARCH_PAGE_LIST default_page,string moduleFlag);
    }
}
