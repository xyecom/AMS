using System;
using System.Collections.Generic;


namespace XYECOM.Model
{
    /// <summary>
    /// ��Ѷ��Ŀʵ����
    /// </summary>
    public class NewsTitlesInfo
    {
        private int _Id;
        private string _Name;
        private string _ShortName;
        private int _ParentId;
        private string _EnName;
        private string _TempletFolderAddress;
        private string _TempletViewAddress;
        private string _HTMLPage;
        private bool _IsShow;
        private bool _IsAllowContribut;
        private string _DomainName;

    
        public NewsTitlesInfo()
        {
            _Id = 0;
            _Name = "";
            _ShortName = "";
            _ParentId = 0;
            _EnName = "";
            _TempletFolderAddress = "";
            _TempletViewAddress = "";
            _HTMLPage = "";
            _DomainName = "";
        }

        #region ����������Ŀ��NewsTitles����
        /// <summary>
        /// ��Ŀ��Ϣ���
        /// </summary>
        public int Id
        {
            set { _Id = value; }
            get { return _Id; }
        }
        /// <summary>
        /// ��Ŀ����
        /// </summary>
        public string Name
        {
            set { _Name = value; }
            get { return _Name; }
        }
        /// <summary>
        /// ��Ŀ���
        /// </summary>
        public string ShortName
        {
            set { _ShortName = value; }
            get { return _ShortName; }
        }
        /// <summary>
        /// ����ĿID  
        /// </summary>
        public int ParentId
        {
            set { _ParentId = value; }
            get { return _ParentId; }
        }
        /// <summary>
        /// ��ĿӢ������
        /// </summary>
        public string EnName
        {
            set { _EnName = value; }
            get { return _EnName; }
        }
        /// <summary>
        /// ��Ŀ�ļ��е�ַ
        /// </summary>
        public string TempletFolderAddress
        {
            set { _TempletFolderAddress = value; }
            get { return _TempletFolderAddress; }
        }

        /// <summary>
        /// ��Ŀ���ʵ�ַ
        /// </summary>
        public string TempletViewAddress
        {
            set { _TempletViewAddress = value; }
            get { return _TempletViewAddress; }
        }

        /// <summary>
        /// ���ɾ�̬ҳ���ַ
        /// </summary>
        public string HTMLPage
        {
            get { return _HTMLPage; }
            set { _HTMLPage = value; }
        }

        /// <summary>
        /// �Ƿ���ʾ
        /// </summary>
        public bool IsShow
        {
            get { return _IsShow; }
            set { _IsShow = value; }
        }

        /// <summary>
        /// �Ƿ������ڸ���Ŀ��Ͷ��
        /// </summary>
        public bool IsAllowContribut
        {
            get { return _IsAllowContribut; }
            set { _IsAllowContribut = value; }
        }

        public override string ToString()
        {
            return this._Name;
        }
        /// <summary>
        /// ��������
        /// </summary>
        public string DomainName
        {
            get { return _DomainName; }
            set { _DomainName = value; }
        }

        #endregion
    }
}
