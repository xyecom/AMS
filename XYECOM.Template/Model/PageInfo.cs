using System;
using System.Collections.Generic;
using System.Text;

namespace XYECOM.Template
{
    /// <summary>
    /// ҳ����Ϣ��(ģ���п��Ե���)
    /// </summary>
    public class PageInfo
    {
        #region ϵͳ��������Ϣ
        /// <summary>
        /// �û���ǰ�ĵ�¼״̬
        /// </summary>
        public string LoginStatus = "<script>UserStatus();</script>";

        #endregion

        /// <summary>
        /// ��ǰģ���ʶ����ģ���ʶ��
        /// </summary>
        public string ModuleFlag = "";

        /// <summary>
        /// ģ������(ģ������/��ģ������)
        /// </summary>
        public string ModuleName = "";

        public bool IsGet;
        public bool IsPost;

        public string Meta = "";
        /// <summary>
        /// ҳ��״̬��һ�����ڱ�ʾҳ�����н���Ķ���״̬
        /// </summary>
        public string PageState = "";

        public string MsgboxText = "";
        public string MsgboxURL = "";
        public int NewTopicMinute;

        public int PageError;
        public string PageTitle = "";

        public string TabName = "";

        #region ***************��ҳʹ��**********************

        public int PageIndex = 0;
        public string FirstPage = "";
        public string NextPage = "";
        public string LastPage = "";
        public string PreviousPage = "";
        public int PageCount = 0;
        /// <summary>
        /// ��ǩ��ָ����ÿҳ��Ϣ����
        /// </summary>
        public int PageSize = 0;
        /// <summary>
        /// �û�������Զ����ÿҳ��Ϣ����
        /// </summary>
        public int CustomPageSize = 0;
        public string NumPage = "";
        public int TotalRecord = 0;
        #endregion ******************************************


        /// <summary>
        /// �ؼ��ʾ��ۼ�¼����
        /// </summary>
        public int KeyCount = 0;

        public string PageURL = "";
        public string BarFlag = "";
        public bool Activation = false;

        /// <summary>
        /// ҳ������¼�
        /// </summary>
        public string OnLoadEvents = "";


        #region ����ҳ��ʹ��

        public string SearchKey = "";           //�����ؼ���
        public string StrSearchWhere = "";      //��������
        public string StrKeySearchWhere = "";   //�ؼ��ʾ�����������
        public string StrPageSeachWhere = "";   //��ҳ��������
        public bool isplatform = true;


        //����
        public string Navigation = "";

        #endregion

        public string DomainHost = "";         // ������������ͷ

        /// <summary>
        /// �Ƿ�ȥ����Ȩ
        /// </summary>
        public bool IsCopyright = false;

        /// <summary>
        /// �����ؼ���Id
        /// </summary>
        public long RankKeyId = -1;

        /// <summary>
        /// ��ز�Ʒ��Ϣ
        /// </summary>
        public string AboutInfo = "";


        /// <summary>
        /// ��Ա������Ϣ����˵��б�
        /// </summary>
        public string InfoManageMenu = "";

        /// <summary>
        /// ��Ա����ͳ����Ϣ
        /// </summary>
        public string StatInfo = "";
        /// <summary>
        /// ��Ա���Ŀ������췢�б�
        /// </summary>
        public string UserCenterModule = "";
        /// <summary>
        /// ������Ϣ�б�����
        /// </summary>
        public string InfoListLink = "";

        /// <summary>
        /// �Ƿ���������֧��
        /// </summary>
        public bool IsOnlinePayment = false;

        #region ��ǩ�ⲿ����

        /// <summary>
        /// ����Id����ǩ�ⲿ������
        /// </summary>
        public int OuterAreaId = 0;

        /// <summary>
        /// ��ҵId(����ҵ����Id)
        /// </summary>
        public int OuterTradeId = 0;

        /// <summary>
        /// ��ǩ�ⲿָ���������(����Order by)
        /// </summary>
        public string OuterOrderStr = "";

        /// <summary>
        /// ��Ʒ����Id(��ƷƵ����ҳ����)
        /// </summary>
        public long OuterProTypeId = 0;

        #endregion


        /// <summary>
        /// ��ȡ��֤���ı�����֤��ͼƬHTML
        /// </summary>
        /// <returns></returns>
        public string GetValidateCodeHTML()
        {
            string src = XYECOM.Configuration.WebInfo.Instance.WebDomain + "common/ValidateCode.ashx?";

            int length = XYECOM.Configuration.Security.Instance.VCodeLength;

            string js = "<script language=\"javascript\">";
            js += "function  _XY_ShowCode(){document.getElementById(\"vCodeImg\").style.display=\"\"; document.getElementById(\"vCodeImg\").src='" + src + "='+Math.random();}";
            js += "</script>";

            string vcode = "<input type=\"text\" name=\"vcode\" id=\"vcode\" onkeydown =\"try{LoginKeyPress();}catch(e){}\" maxlength=\"" + length + "\" size=\"" + (length + 2) + "\" onfocus=\"_XY_ShowCode();\"/><img  src=\"/common/images/ajax-loading-circle.gif\" id=\"vCodeImg\" style=\"cursor:pointer;display:none;vertical-align:middle;\"/>";

            return js + vcode;
        }

        /// <summary>
        /// ��ȡ��֤���ı�����֤��ͼƬHTML�����һ��ҳ�����һ��������֤����������ֹ������
        /// </summary>
        /// <param name="code">��֤���ı����Id</param>
        /// <param name="imgid">��֤��ͼƬ��Id</param>
        /// <returns></returns>
        public string GetValidateCodeHTML(string code, string imgid)
        {
            string src = XYECOM.Configuration.WebInfo.Instance.WebDomain + "common/ValidateCode.ashx?";

            int length = XYECOM.Configuration.Security.Instance.VCodeLength;

            string js = "<script language=\"javascript\">";
            js += "function  _XY_ShowCode" + code + "(){document.getElementById(\"" + imgid + "\").style.display=\"\"; document.getElementById(\"" + imgid + "\").src='" + src + "='+Math.random();}";
            js += "</script>";

            string vcode = "<input type=\"text\" name=\"" + code + "\" id=\"" + code + "\" onkeydown =\"try{LoginKeyPress();}catch(e){}\" maxlength=\"" + length + "\" size=\"" + (length + 2) + "\" onfocus=\"_XY_ShowCode" + code + "();\"/><img  src=\"/common/images/ajax-loading-circle.gif\" id=\"" + imgid + "\" style=\"cursor:pointer;display:none;vertical-align:middle;\" />";

            return js + vcode;
        }
    }
}
